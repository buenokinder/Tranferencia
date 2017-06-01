using Docway.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Patient
{
 

    public abstract class PatientCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }

        public string Password { get; set; }

        public DateTime? DateOfBirth { get; set; }      

        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        
        public string HealthProblems { get; set; }
        public string AllergiesAndReactions { get; set; }
        public string Medicines { get; set; }
        public string BloodType { get; set; }

        //Convenio
   
       
    }
}
