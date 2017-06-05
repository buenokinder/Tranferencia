using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Calendar : Entity
    {

        protected Calendar() { }

        public Calendar(Doctor owner, DayOfWeek dayOfWeek, int hour, DateTime? date)
        {

            this.Owner = owner;
            this.DayOfWeek = dayOfWeek;
            this.Hour = hour;
            this.Date = date;

        }

        public Calendar SetIsDIsponible(bool isDisponible)
        {
            this.IsDisponible = isDisponible;
            return this;
        }


        [Index]
        public Doctor Owner { get; set; }

        [Index]
        public DayOfWeek DayOfWeek { get; set; }

        public int Hour { get; set; }

        [Index]
        public DateTime? Date { get; set; }

        [Index]
        public bool IsDisponible { get; set; }

        public Appointment Appointment { get; set; }
    }
}
