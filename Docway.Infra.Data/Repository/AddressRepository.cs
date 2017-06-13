using Docway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Infra.Data.Repository
{
    
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private DocwayContext _context;
        public PatientRepository(DocwayContext context)
            : base(context)
        {
            _context = context;
        }

        public Patient GetByEmail(string email)
        {
            return Find(c => c.User.Email == email).FirstOrDefault();
        }

        public Patient GetByIdWithAggregate(Guid id)
        {
            return _context.Patients.Where(x => x.Id.Equals(id)).Include(x => x.Parent).Include(x => x.User).Include(x => x.Dependents).SingleOrDefault();

        }
    }
}
