using Docway.Domain.Core.Events;
using Docway.Domain.Events.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.EventHandlers
{
    public class PatientEventHandler :
        IHandler<PatientRegisteredEvent>,
        IHandler<PatientUpdatedEvent>,
        IHandler<PatientRemovedEvent>
    {
        public void Handle(PatientRegisteredEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(PatientUpdatedEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(PatientRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}
