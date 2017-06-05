using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Stock : Entity
    {
        
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
