using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docway.Domain.Models;
using Docway.Application.Appointment.ViewModels;

namespace Docway.Application.Appointment.Interfaces
{
  
    public interface IAppointmentAppService 
    {
        IEnumerable<AppointmentViewModel> GetPacientAppointmentsByFilter(Guid Id, DateTime? dataInicial, DateTime? dataFinal);
        void Register(AppointmentViewModel appointmentViewModel);
        IEnumerable<AppointmentViewModel> GetAll();
        AppointmentViewModel GetById(Guid id);
        void Update(AppointmentViewModel appointmentViewModel);
        void Remove(Guid id);
    }
}
