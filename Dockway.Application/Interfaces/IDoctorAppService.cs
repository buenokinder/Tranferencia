using Dockway.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.Interfaces
{
    
    public interface IDoctorAppService : IDisposable
    {
        void Register(DoctorViewModel patientViewModel);
        IEnumerable<PatientViewModel> id AddDependent(PatientViewModel patientViewModel);
        IEnumerable<PatientViewModel> GetAll();
        PatientViewModel GetById(Guid id);
        void Update(PatientViewModel customerViewModel);
        void Remove(Guid id);
        IList<PatientHistoryData> GetAllHistory(Guid id);
    }
}
