using Docway.Domain.Core.Commands;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Doctor
{
   
    public abstract class DoctorCommand : Command
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime? DateOfBirth { get; set; }

       

        public string Crm { get; set; }
     
        public string CrmUF { get; set; }

        public string Bio { get; set; }
  
        public Gender Gender { get; set; }

        public decimal AppointmentPrice { get; set; }

        public int AppointmentRadius { get; set; }

        public string Speciality { get; set; }

        public string Street { get; set; }
        
        public string Number { get; set; }
        
        public string Complement { get; set; }
        
        public string Neighborhood { get; set; }
        
        public string Cep { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Landmark { get; set; }
        
        public double? Latitude { get; set; }
        
        public double? Longitude { get; set; }

    }
}
