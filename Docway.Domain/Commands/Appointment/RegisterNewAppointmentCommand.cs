using Docway.Domain.Enum;
using Docway.Domain.Validations.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Doctor
{
    public class RegisterNewAppointmentCommand : AppointmentCommand
    {
        public RegisterNewAppointmentCommand(string buyerId,
         string sellerId ,
         int addressId,
         int? creditCardId,
         AppointmentType type,
         string promotionalCode,
         decimal price ,
         bool hasHealthInsurance ,
         bool isUrgency,
         DateTime dateAppointment )
        {
            //this.Id = Guid.NewGuid();
            this.SellerId = sellerId;
            this.AddressId = addressId;
            this.CreditCardId = creditCardId;
            this.Type = type;
            this.PromotionalCode = promotionalCode;
            this.Price = price;
            this.HasHealthInsurance = hasHealthInsurance;
            this.IsUrgency = isUrgency;
            this.DateAppointment = dateAppointment;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewAppointmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
