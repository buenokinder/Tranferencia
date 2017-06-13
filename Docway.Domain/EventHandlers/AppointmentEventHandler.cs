using Docway.Domain.Core.Events;
using Docway.Domain.Events.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.EventHandlers
{
    public class AppointmentEventHandler :
        IHandler<AppointmentRegisteredEvent>,
        IHandler<AppointmentUpdatedEvent>,
        IHandler<AppointmentRemovedEvent>
    {
        public void Handle(AppointmentRegisteredEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(AppointmentUpdatedEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(AppointmentRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}
