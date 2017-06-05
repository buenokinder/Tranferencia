using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class MedicalRecord : Entity
    {
       
        public string Diagnostic { get; set; }
        public string Prescription { get; set; }
        public string Opinion { get; set; }
        public string Medicines { get; set; }

        // nested object
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
