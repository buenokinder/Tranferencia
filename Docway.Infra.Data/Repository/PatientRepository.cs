using Docway.Domain.Interfaces.Repository;
using Docway.Domain.Models;
using Docway.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Infra.Data.Repository
{

    public class PatientRepository : Repository<Patient>, IPatientRepository
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

        public Patient GetByIdWithUser(string email)
        {
            return null;
        }
    }
}
