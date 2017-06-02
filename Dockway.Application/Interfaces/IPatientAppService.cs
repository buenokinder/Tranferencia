using Dockway.Application.EventSourcedNormalizers.Patient;
using Dockway.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.Interfaces
{
   
    public interface IPatientAppService : IDisposable
    {
        void Register(PatientViewModel patientViewModel);
        IEnumerable<PatientViewModel> GetAll();
        PatientViewModel GetById(Guid id);
        void Update(PatientViewModel customerViewModel);
        void Remove(Guid id);
        IList<PatientHistoryData> GetAllHistory(Guid id);
    }
}
