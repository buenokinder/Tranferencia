using System;
using System.Collections.Generic;
using Docway.Domain.Core.Events;

namespace Docway.Domain.Core.Notifications
{
	public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
	{
		bool HasNotifications();
		List<T> GetNotifications();
	}
}
