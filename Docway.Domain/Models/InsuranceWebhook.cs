using Docway.Domain.Core.Models;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class InsuranceWebhook : Entity
    {

        public Insurance Insurance { get; set; }
        public int InsuranceId { get; set; }
        public string Uri { get; set; }
        public List<WebhookAction> WebhookActions { get; set; }

    }
}
