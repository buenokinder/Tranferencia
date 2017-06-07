using Docway.Domain.Commands.Doctor;
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
    public class DoctorCommandHandler : CommandHandler,
        IHandler<RegisterNewDoctorCommand>
        
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IBus Bus;

        public DoctorCommandHandler(IDoctorRepository doctorRepository,
                                      IUnitOfWork uow,
                                      IBus bus,
                                      IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _doctorRepository = doctorRepository;
            Bus = bus;
        }

        public void Handle(RegisterNewDoctorCommand message)
        {
            this.Validation(message);

            var doctor = new Doctor(new UserBase(message.Name, message.Email, message.UserName, message.Telefone, message.Password), 
                                    new Address(message.Street, message.Number, message.Cep, message.State, message.City, true), 
                                    message.Cpf, message.Speciality, message.DateOfBirth.Value, message.Crm, message.CrmUF, message.Gender, message.AppointmentPrice, message.AppointmentRadius);

            if (_doctorRepository.GetByEmail(doctor.User.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Não é possível realizar o cadastro com o mesmo email de médico."));
                return;
            }

            _doctorRepository.Add(doctor);

            if (Commit()) Bus.RaiseEvent(new DoctorRegisteredEvent(doctor.Id, doctor.User.Name, doctor.User.Email, doctor.Cpf, doctor.User.PhoneNumber));
        }
    }
}
