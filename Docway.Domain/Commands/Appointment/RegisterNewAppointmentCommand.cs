using Docway.Domain.Enum;
using Docway.Domain.Validations.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Doctor
{
    public class RegisterNewAppointmentCommand : AppointmentCommand
    {



        public RegisterNewAppointmentCommand(
         string name ,

         string email ,

         string cpf ,

         string telefone ,

         string userName ,

         string password ,

         DateTime? dateOfBirth ,

         decimal Weight ,

         decimal Height ,

         string HealthProblems ,

         string AllergiesAndReactions ,

         string Medicines ,

         string BloodType ,

         string Crm ,

         string CrmUF ,

         string Bio ,

         Gender Gender ,

         decimal AppointmentPrice ,

         int AppointmentRadius ,

         string Street ,

         string Number ,

         string Complement ,

         string Neighborhood ,

         string Cep ,

         string City ,

         string State ,

         string Landmark ,

         double? Latitude ,

         double? Longitude )
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Cpf = cpf;
            UserName = userName;
            Telefone = telefone;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewAppointmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
