using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Symptom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Appointment> Appointments { get; set; }

        //public List<PreAppointment> PreAppointments { get; set; }
    }
}
