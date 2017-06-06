using Docway.Domain.Commands.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Validations.Patient
{
  

    public class AddDependentPatientCommandValidantion : PatientValidation<AddDependentCommand>
    {
        public AddDependentPatientCommandValidantion()
        {
            ValidateName();
            ValidateEmail();
            ValidateCpf();
        }
    }
}
