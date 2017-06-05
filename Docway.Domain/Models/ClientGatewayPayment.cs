using Docway.Domain.Core.Models;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class ClientGatewayPayment : Entity
    {
        public string ClientId { get; set; }
        [Index]
        public int GatewayPaymentId { get; set; }
        public PaymentProvider GatewayPayment { get; set; }
    }
}
