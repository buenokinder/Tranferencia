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
        IEnumerable<DoctorViewModel> GetAll();
        IEnumerable<DoctorViewModel> Find(double latitude, double longitude, DayOfWeek? DayOfWeek, int? Hour, DateTime? Date, int? specialtyId = null , bool isSUSEnabled = false);
        PatientViewModel GetById(Guid id);
        void Update(DoctorViewModel customerViewModel);
        void Remove(Guid id);
        
    }
}
