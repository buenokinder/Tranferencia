using Docway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Interfaces.Repository
{
    

    public interface IDoctorRepository : IRepository<Doctor>
    {
        Doctor GetByEmail(string email);
        Doctor GetByIdWithAggregate(Guid id);
        IEnumerable<Doctor> Find(DbGeography Location, DayOfWeek? DayOfWeek, int? Hour, DateTime? Date, int? specialtyId = null, bool isSUSEnabled = false);
    }
}
