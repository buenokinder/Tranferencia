using Docway.Domain.Core.Events;
using Docway.Domain.Events.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.EventHandlers
{
    public class DoctorEventHandler :
        IHandler<DoctorRegisteredEvent>,
        IHandler<DoctorUpdatedEvent>,
        IHandler<DoctorRemovedEvent>
    {
        public void Handle(DoctorRegisteredEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(DoctorUpdatedEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(DoctorRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}
