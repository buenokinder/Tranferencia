﻿using System;
using System.Linq;
using System.Collections.Generic;
using Docway.Domain.Core.Events;
using Docway.Infra.Data.Context;

namespace Docway.Infra.Data.Repository.EventSourcing
{
	//public class EventStoreSQLRepository : IEventStoreRepository
	//{
	//	private readonly EventStoreSQLContext _context;

	//	public EventStoreSQLRepository(EventStoreSQLContext context)
	//	{
	//		_context = context;
	//	}

	//	public IList<StoredEvent> All(Guid aggregateId)
	//	{
	//		return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
	//	}

	//	public void Store(StoredEvent theEvent)
	//	{
	//		_context.StoredEvent.Add(theEvent);
	//		_context.SaveChanges();
	//	}

	//	public void Dispose()
	//	{
	//		_context.Dispose();
	//	}
	//}
}
