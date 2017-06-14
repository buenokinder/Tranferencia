using Docway.Domain.Core.Commands;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Commands.Doctor
{
   
    public abstract class AppointmentCommand : Command
    {
        public int Id { get; set; }

        public string BuyerId { get; set; }
     
        public string SellerId { get; set; }

        public int AddressId { get; set; }

        public int? CreditCardId { get; set; }

        public AppointmentType Type { get; set; }

        public string PromotionalCode { get; set; }
  
        public decimal Price { get; set; }
     
        public bool HasHealthInsurance { get; set; }
   
        public bool IsUrgency { get; set; }
  
        public DateTime DateAppointment { get; set; }

    }
}
