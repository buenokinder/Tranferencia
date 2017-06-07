using Dockway.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dockway.Application.EventSourcedNormalizers.Patient;
using Dockway.Application.ViewModels;
using AutoMapper;
using Docway.Domain.Interfaces.Repository;
using Docway.Infra.Data.Repository.EventSourcing;
using Docway.Domain.Core.Bus;
using Docway.Domain.Commands.Doctor;
using Docway.Domain;


namespace Dockway.Application.Services
{
    public class DoctorAppService : IDoctorAppService
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IBus Bus;

        public DoctorAppService(IMapper mapper,
                                  IDoctorRepository doctorRepository,
                                  IBus bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<DoctorViewModel> Find(double latitude, double longitude, DayOfWeek? dayOfWeek, int? hour, DateTime? date, int? specialtyId = default(int?), bool isSUSEnabled = false)
        {
            return _mapper.Map<IEnumerable<DoctorViewModel>>(_doctorRepository.Find(DBHelper.GetDbGeographyFromLattitude(latitude, longitude), dayOfWeek, hour, date, specialtyId, isSUSEnabled));          
        }

        public IEnumerable<PatientViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PatientViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(DoctorViewModel patientViewModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveDoctorCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(PatientViewModel customerViewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(DoctorViewModel customerViewModel)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DoctorViewModel> IDoctorAppService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
