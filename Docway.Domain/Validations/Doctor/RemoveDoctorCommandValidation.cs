using Docway.Domain.Commands.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Validations.Doctor
{



    public class RemoveDoctorCommandValidation : DoctorValidation<RemoveDoctorCommand>
    {
        public RemoveDoctorCommandValidation()
        {
            ValidateId();
        }
    }
}
