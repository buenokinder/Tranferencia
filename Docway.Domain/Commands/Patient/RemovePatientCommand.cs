using Docway.Domain.Validations.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Patient
{


    public class RemovePatientCommand : PatientCommand
    {
        public RemovePatientCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePatientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
