using Docway.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docway.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        public bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        public BadRequestObjectResult BadRequestValidations()
        {
            ModelState.AddModelError("Validate", _notifications.GetNotifications().FirstOrDefault().Value);
            return BadRequest(ModelState);
        }
    }
}
