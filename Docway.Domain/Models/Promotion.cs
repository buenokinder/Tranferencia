using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Promotion : Entity
    {
        public string Code { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountValue { get; set; }
        public int UsageLimit { get; set; }

        public List<UserBase> Users { get; set; }
    }
}
