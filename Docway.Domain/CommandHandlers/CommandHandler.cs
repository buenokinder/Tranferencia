using Docway.Domain.Core.Bus;
using Docway.Domain.Core.Commands;
using Docway.Domain.Core.Notifications;
using Docway.Domain.Interfaces;

namespace Docway.Domain.CommandHandlers
{
   public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            
            _uow = uow;
            _notifications = notifications;
            _bus = bus;
        }


        public void Validation(Command message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
