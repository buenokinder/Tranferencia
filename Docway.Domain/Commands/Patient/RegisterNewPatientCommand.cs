using Docway.Domain.Validations.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Patient
{

     public class RegisterNewPatientCommand : PatientCommand
    {

        

        public RegisterNewPatientCommand(string name, string email, string cpf, string telefone, string password, string userName)
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
            ValidationResult = new RegisterNewPatientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
