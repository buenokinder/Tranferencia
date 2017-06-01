using Docway.Domain.Validations.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Patient
{
    public class UpdatePatientCommand : PatientCommand
    {



        public UpdatePatientCommand(string name, string email, string cpf, string telefone, string password)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            Password = password;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdatePatientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }



}
