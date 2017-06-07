using Docway.Domain.Interfaces.Repository;
using Docway.Domain.Models;
using Docway.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Infra.Data.Repository
{

    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private DocwayContext _context;
        public DoctorRepository(DocwayContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> Find(DbGeography Location, DayOfWeek? dayOfWeek, int? Hour, DateTime? Date, int? specialtyId = default(int?), bool isSUSEnabled = false)
        {
            return _context.Doctors.Where(x => x.Address.Location.Distance(Location) > x.AppointmentRadius)
                                    .Where(d => d.Calendars.Any(s => s.Hour == Hour.Value && s.Date == Date.Value && s.DayOfWeek == dayOfWeek))
                                    .Where(d => d.Specialties.Any(s => s.Id == specialtyId.Value));
        }

        public Doctor GetByEmail(string email)
        {
            return Find(c => c.User.Email == email).FirstOrDefault();
        }

        public Doctor GetByIdWithAggregate(Guid id)
        {
           return   _context.Doctors.Where(x => x.Id.Equals(id)).Include(x=>x.Address).Include(x => x.User).Include(x=>x.Specialties).SingleOrDefault();
            
        }
        
    }
}
