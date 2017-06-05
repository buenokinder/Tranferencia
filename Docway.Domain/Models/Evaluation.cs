using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Evaluation : Entity
    {
        
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Doctor Doctor { get; set; }

        public Patient Owner { get; set; }
    }
}
