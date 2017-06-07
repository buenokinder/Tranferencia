using Docway.Domain.Core.Models;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Doctor : EntityGuid
    {
        protected Doctor() { }
        public Doctor(UserBase _user, Address _address, string Cpf, string speciality, DateTime dateOfBirth, string crm, string crmUf, Gender gender, decimal appointmentPrice, int appointmentRadius)
        {
            this.User = _user;
            this.Address = _address;
            this.DateOfBirth = dateOfBirth;
            this.Crm = crm;
            this.CrmUF = crmUf;
            this.AppointmentRadius = appointmentRadius;
            this.AppointmentPrice = appointmentPrice;
            this.Evaluations = new List<Evaluation>();
            this.Degrees = new List<Document>();
            this.Specialties = new List<Speciality>();
            this.Calendars = new List<Calendar>();
        }



        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }

        // informações profissionais
        public string Crm { get; set; }
        public string CrmUF { get; set; }

        // informações pessoais
        public string Bio { get; set; }


        public string Cpf { get; set; }

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

        [Index]
        public List<Speciality> Specialties { get; set; }
        [Index]
        public List<Calendar> Calendars { get; set; }

        public Guid ServiceProviderId { get; set; }

        public ServiceProvider ServiceProvider { get; set; }


        public Guid UserBaseId { get; set; }

        public UserBase User { get; set; }



    }
}
