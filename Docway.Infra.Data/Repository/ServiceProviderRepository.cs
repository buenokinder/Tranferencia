using Docway.Domain.Interfaces.Repository;
using Docway.Domain.Models;
using Docway.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docway.Domain.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Docway.Infra.Data.Repository
{

    public class ServiceProviderRepository : Repository<ServiceProvider>, IServiceProviderRepository
    {
        private DocwayContext _context;
        public ServiceProviderRepository(DocwayContext context)
            : base(context)
        {
            _context = context;
        }

        
        public ServiceProvider GetByClinicId(Guid id)
        {
            return _context.Clinics.Where(d => d.Id == id).Include(x => x.ServiceProvider).SingleOrDefault().ServiceProvider;
        }

        public ServiceProvider GetByDoctorId(Guid id)
        {
            return _context.Doctors.Where(d => d.Id == id).Include(x => x.ServiceProvider).SingleOrDefault().ServiceProvider;
        }
    }
}
