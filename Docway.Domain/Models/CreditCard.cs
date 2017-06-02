using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CardHolder { get; set; }
        public string Brand { get; set; }
        public string Token { get; set; }
        public string FinalNumber { get; set; }
        public bool IsPrimary { get; set; }
        public Patient Owner { get; set; }
        //public PaymentProvider Provider { get; set; }
        public string PaymentMethodId { get; set; }
    }
}
