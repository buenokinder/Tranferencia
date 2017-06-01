using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Calendar
    {
        public int Id { get; set; }

        public Doctor Owner { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public int Hour { get; set; }

        public DateTime? Date { get; set; }

        public bool IsDisponible { get; set; }

        public Appointment Appointment { get; set; }
    }
}
