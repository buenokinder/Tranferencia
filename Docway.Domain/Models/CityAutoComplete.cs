﻿using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class CityAutoComplete : Entity
    {
        
        public string Name { get; set; }
        [Index]
        public StateAutoComplete State { get; set; }
    }
}
