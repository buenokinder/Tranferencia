using Docway.Domain.Commands.Patient;
using Docway.Domain.Core.Bus;
using Docway.Domain.Core.Events;
using Docway.Domain.Core.Notifications;
using Docway.Domain.Events.Patient;
using Docway.Domain.Interfaces;
using Docway.Domain.Interfaces.Repository;
using Docway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.CommandHandlers
{

    public class PatientCommandHandler : CommandHandler,
        IHandler<RegisterNewPatientCommand>,
        IHandler<UpdatePatientCommand>,
        IHandler<RemovePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IBus Bus;

        public PatientCommandHandler(IPatientRepository patientRepository,
                                      IUnitOfWork uow,
                                      IBus bus,
                                      IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _patientRepository = patientRepository;
            Bus = bus;
        }

        public void Handle(RegisterNewPatientCommand message)
        {
            this.Validation(message);

            var patient = new Patient(Guid.NewGuid(), message.Name, message.Email, message.Cpf, message.Telefone, message.Password);

            if (_patientRepository.GetByEmail(patient.user.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Não é possível realizar o cadastro com o mesmo email de médico."));
                return;
            }

            _patientRepository.Add(patient);

            if (Commit()) Bus.RaiseEvent(new PatientRegisteredEvent(patient.Id, patient.user.Name, patient.user.Email, patient.Cpf, patient.user.PhoneNumber));
        }

        public void Handle(UpdatePatientCommand message)
        {
            this.Validation(message);

            var patient = new Patient(message.Id, message.Name, message.Email, message.Cpf, message.Telefone, message.Password);
            var existingPatient = _patientRepository.GetByEmail(patient.user.Email);

            if (existingPatient != null)
            {
                if (!existingPatient.Equals(patient))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "Email do paciente já foi utilizado."));
                    return;
                }
            }

            _patientRepository.Update(patient);

            if (Commit()) Bus.RaiseEvent(new PatientUpdatedEvent(patient.Id, patient.user.Name, patient.user.Email, patient.Cpf, patient.user.PhoneNumber));

        }

        public void Handle(RemovePatientCommand message)
        {
            this.Validation(message);

            _patientRepository.Remove(message.Id);

            if (Commit()) Bus.RaiseEvent(new PatientRemovedEvent(message.Id));

        }



        public void Dispose()
        {
            _patientRepository.Dispose();
        }
    }
}
