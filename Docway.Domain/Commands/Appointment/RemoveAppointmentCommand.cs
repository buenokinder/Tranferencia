using Docway.Domain.Validations.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Doctor
{
   

    public class RemoveAppointmentCommand : AppointmentCommand
    {
        public RemoveAppointmentCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveAppointmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
