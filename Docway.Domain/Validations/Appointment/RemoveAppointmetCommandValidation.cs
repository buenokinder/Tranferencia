using Docway.Domain.Commands.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Validations.Doctor
{



    public class RemoveAppointmentCommandValidation : AppointmentValidation<RemoveAppointmentCommand>
    {
        public RemoveAppointmentCommandValidation()
        {
            
        }
    }
}
