using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Clinic : EntityGuid
    {
        
        public Guid ServiceProviderId { get; set; }

        public ServiceProvider ServiceProvider { get; set; }

        public List<Stock> Stocks { get; set; }
        
    }
}
