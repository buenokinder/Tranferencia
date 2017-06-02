using Docway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Interfaces.Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient GetByEmail(string email);
        Patient GetByIdWithUser(string email);
    }
}
