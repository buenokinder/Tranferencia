using Docway.Domain.Core.Models;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class ProductScheduler : Entity
    {
        public ProductScheduleType Type { get; set; }
        public string Name { get; set; }
        
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public List<Patient> Patients { get; set; }
    }
}
