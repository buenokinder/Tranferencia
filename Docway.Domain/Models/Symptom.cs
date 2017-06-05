using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Symptom : Entity
    {
        public string Name { get; set; }
        public List<Appointment> Appointments { get; set; }
        
    }
}
