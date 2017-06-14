using Docway.Domain.Commands.Doctor;
using Docway.Domain.Validations.Customs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Validations.Doctor
{
  

    public abstract class AppointmentValidation<T> : AbstractValidator<T> where T : AppointmentCommand
    {
        
    }
}
