using Docway.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Events.Patient
{
    

    public class AppointmentRegisteredEvent : Event
    {
        public AppointmentRegisteredEvent(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        
    }
}
