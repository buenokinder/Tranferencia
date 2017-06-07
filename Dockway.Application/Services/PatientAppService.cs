using AutoMapper;
using Dockway.Application.EventSourcedNormalizers.Patient;
using Dockway.Application.Interfaces;
using Dockway.Application.ViewModels;
using Docway.Domain.Commands.Patient;
using Docway.Domain.Core.Bus;
using Docway.Domain.Interfaces.Repository;
using Docway.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.Services
{
    

    public class PatientAppService : IPatientAppService
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IBus Bus;

        public PatientAppService(IMapper mapper,
                                  IPatientRepository patientRepository,
                                  IBus bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<PatientViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<PatientViewModel>>(_patientRepository.GetAll());
        }

        public PatientViewModel GetById(Guid id)
        {
    
            return _mapper.Map<PatientViewModel>(_patientRepository.GetByIdWithAggregate(id));
        }

        public void Register(PatientViewModel patientViewModel)
        {
            Bus.SendCommand(_mapper.Map<RegisterNewPatientCommand>(patientViewModel));
        }

        public void Update(PatientViewModel patientViewModel)
        {
            Bus.SendCommand(_mapper.Map<UpdatePatientCommand>(patientViewModel));
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemovePatientCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<PatientHistoryData> GetAllHistory(Guid id)
        {
            return PatientHistory.ToJavaScriptPatientHistory(_eventStoreRepository.All(id));
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void AddDependent(PatientViewModel patientViewModel)
        {
            Bus.SendCommand(_mapper.Map<AddDependentCommand>(patientViewModel));
        }
    }
}
