using Docway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Interfaces.Repository
{
    

    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> FindByPatientId(Guid patientId, DateTime? startDate, DateTime? endDate, int initial = 0, int limit = 5);
    }
}
