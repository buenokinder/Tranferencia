using Docway.Domain.Validations.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Doctor
{
   

    public class RemoveAppointmentCommand : DoctorCommand
    {
        public RemoveAppointmentCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDoctorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
