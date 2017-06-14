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
    
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private DocwayContext _context;
        public AddressRepository(DocwayContext context)
            : base(context)
        {
            _context = context;
        }

      
    }
}
