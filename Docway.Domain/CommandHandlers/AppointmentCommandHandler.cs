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
    public class AppointmentCommandHandler : CommandHandler,
        IHandler<RegisterNewAppointmentCommand>

    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IServiceProviderRepository _serviceProviderRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IBus Bus;

        public AppointmentCommandHandler(IAppointmentRepository appointmentRepository,
            IPatientRepository patientRepository,
            IAddressRepository addressRepository,
            IServiceProviderRepository serviceProviderRepository,
                                      IUnitOfWork uow,
                                      IBus bus,
                                      IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this._serviceProviderRepository = serviceProviderRepository;
            this._appointmentRepository = appointmentRepository;
            this._patientRepository = patientRepository;
            this._addressRepository = addressRepository;
            this.Bus = bus;
        }


        public ServiceProvider GetServiceProvider(RegisterNewAppointmentCommand message)
        {
            if (message.Type == Enum.AppointmentType.Consult)
                return _serviceProviderRepository.GetByDoctorId(new Guid(message.SellerId));

            return _serviceProviderRepository.GetByClinicId(new Guid(message.SellerId));

        }



        public void Handle(RegisterNewAppointmentCommand message)
        {
            this.Validation(message);

            var pacient = _patientRepository.GetById(new Guid(message.BuyerId));
            var address = _addressRepository.GetById(message.AddressId);

            var appointment = new Appointment(message.DateAppointment, message.Price, pacient, this.GetServiceProvider(message), message.Type, address );



            _appointmentRepository.Add(appointment);

            if (Commit()) Bus.RaiseEvent(new AppointmentRegisteredEvent(appointment.Id));
        }
    }
}
