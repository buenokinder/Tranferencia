using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Doctor 
    {
        // informações profissionais
        public string Crm { get; set; }
        public string CrmUF { get; set; }

        // informações pessoais
        public string Bio { get; set; }

        // informações de consultas
        public decimal AppointmentPrice { get; set; }
        public int AppointmentRadius { get; set; }

        public bool IsActive { get; set; }
        public bool IsPaylevenActive { get; set; }
        public bool UrgencyEnable { get; set; }
        public bool IsIuguActive { get; set; }
        public Document Identification { get; set; }

        public List<Evaluation> Evaluations { get; set; }
        public List<Document> Degrees { get; set; }
        public List<Speciality> Specialties { get; set; }
        public List<Calendar> Calendar { get; set; }

        //public List<PreAppointment> PreAppointments { get; set; }

        public Doctor()
        {
            Evaluations = new List<Evaluation>();
            Degrees = new List<Document>();
            Specialties = new List<Speciality>();
            Calendar = new List<Calendar>();
        }
    }
}
