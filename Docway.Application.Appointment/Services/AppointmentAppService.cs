using AutoMapper;
using Docway.Application.Appointment.Interfaces;
using Docway.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docway.Application.Appointment.ViewModels;
using Docway.Infra.Data.Repository.EventSourcing;
using Docway.Domain.Core.Bus;

namespace Docway.Application.Appointment.Services
{
    public class AppointmentAppService : IAppointmentAppService
    {


        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IBus Bus;

        public AppointmentAppService(IMapper mapper,
                                  IAppointmentRepository appointmentRepository,
                                  IBus bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AppointmentViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<AppointmentViewModel>>(_appointmentRepository.GetAll());
        }

        public AppointmentViewModel GetById(Guid id)
        {
            return _mapper.Map<AppointmentViewModel>(_appointmentRepository.GetById(id));
        }

        public IEnumerable<AppointmentViewModel> GetPacientAppointmentsByFilter(Guid Id, DateTime? dataInicial, DateTime? dataFinal)
        {
            return _mapper.Map<IEnumerable<AppointmentViewModel>>(_appointmentRepository.FindByPatientId(Id, dataInicial, dataFinal));   
        }

        public void Register(AppointmentViewModel patientViewModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(AppointmentViewModel customerViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
