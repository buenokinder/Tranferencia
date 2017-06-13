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
  

    public abstract class AppointmentValidation<T> : AbstractValidator<T> where T : DoctorCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Campo nome não pode ficar em branco.")
                .Length(2, 150).WithMessage("O nome deve conter entre 2 e 150 characteres");
        }


        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateCpf()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty()
                .CpfValidation();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }


    }
}
