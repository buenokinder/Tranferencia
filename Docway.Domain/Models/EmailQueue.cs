using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class EmailQueue
    {
        public int Id { get; set; }
        [Required]
        public string TemplateName { get; set; }
        public bool WasSent { get; set; }
        public DateTime? DateSent { get; set; }
        public string Destinations { get; set; }

        // reference to object
        public int ReferenceId { get; set; }

        // reference to user
        public string UserReferenceId { get; set; }
    }
}
