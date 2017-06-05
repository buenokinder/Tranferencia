﻿using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class EmailQueue : Entity
    {
        
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
