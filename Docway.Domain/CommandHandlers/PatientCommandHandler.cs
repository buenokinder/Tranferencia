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
        IHandler<RemovePatientCommand>,
        IHandler<AddDependentCommand>
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

            var patient = new Patient(Guid.NewGuid(),  message.Cpf, new UserBase(message.Name, message.Email, message.UserName, message.Telefone, message.Password));

            if (_patientRepository.GetByEmail(patient.User.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Não é possível realizar o cadastro com o mesmo email de médico."));
                return;
            }

            _patientRepository.Add(patient);

            if (Commit()) Bus.RaiseEvent(new PatientRegisteredEvent(patient.Id, patient.User.Name, patient.User.Email, patient.Cpf, patient.User.PhoneNumber));
        }

        public void Handle(UpdatePatientCommand message)
        {
            this.Validation(message);

            
            var existingPatient = _patientRepository.GetByEmail(message.Email);
            
            if (existingPatient != null)
            {
                if (existingPatient.Id == message.Id)
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "Email do paciente já foi utilizado."));
                    return;
                }
            }
            var patient = _patientRepository.GetByIdWithAggregate(message.Id);

            patient.Update(message.Cpf, message.HealthProblems, message.Height, message.Weight, message.DateOfBirth, message.AllergiesAndReactions, message.Medicines, message.BloodType);
            patient.User.Update(message.Name, message.Telefone);

            
            _patientRepository.Update(patient);

            if (Commit()) Bus.RaiseEvent(new PatientUpdatedEvent(patient.Id, patient.User.Name, patient.User.Email, patient.Cpf, patient.User.PhoneNumber));

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

        public void Handle(AddDependentCommand message)
        {

            this.Validation(message);



            var parentPacient = _patientRepository.GetById(message.ParentId);


            var patient = new Patient(Guid.NewGuid(), message.Cpf, new UserBase(message.Name, message.Email, message.UserName, message.Telefone, message.Password)); 


            if (_patientRepository.GetByEmail(patient.User.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Não é possível realizar o cadastro com o mesmo email de médico."));
                return;
            }
            
            patient.Parent = parentPacient;

            _patientRepository.Add(patient);

            if (Commit()) Bus.RaiseEvent(new PatientRegisteredEvent(patient.Id, patient.User.Name, patient.User.Email, patient.Cpf, patient.User.PhoneNumber));

         
            
        }
    }
}
