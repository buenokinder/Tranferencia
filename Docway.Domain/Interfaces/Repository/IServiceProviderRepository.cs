using Docway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Interfaces.Repository
{


    public interface IServiceProviderRepository : IRepository<ServiceProvider>
    {
        ServiceProvider GetByDoctorId(Guid id);
        ServiceProvider GetByClinicId(Guid id);
    }
}
