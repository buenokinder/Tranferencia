﻿using Docway.Domain.Core.Events;
using Docway.Domain.Interfaces;
using Docway.Infra.Data.Repository.EventSourcing;
using Newtonsoft.Json;

namespace Docway.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
       // private readonly IUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
          //  _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "Carlos");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}