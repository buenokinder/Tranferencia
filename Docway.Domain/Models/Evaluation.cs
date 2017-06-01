using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Doctor Doctor { get; set; }

        public Patient Owner { get; set; }
    }
}
