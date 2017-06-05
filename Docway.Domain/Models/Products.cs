using Docway.Domain.Core.Models;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
    }
}
