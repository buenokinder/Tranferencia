﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class CityAutoComplete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StateAutoComplete State { get; set; }
    }
}
