using System;
using System.Collections.Generic;
using Docway.Domain.Core.Events;

namespace Docway.Infra.Data.Repository.EventSourcing
{
	public interface IEventStoreRepository : IDisposable
	{
		void Store(StoredEvent theEvent);
		IList<StoredEvent> All(Guid aggregateId);
	}
}