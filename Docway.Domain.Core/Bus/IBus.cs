using System;
using Docway.Domain.Core.Commands;
using Docway.Domain.Core.Events;

namespace Docway.Domain.Core.Bus
{
	public interface IBus
	{
		void SendCommand<T>(T theCommand) where T : Command;
		void RaiseEvent<T>(T theEvent) where T : Event;
	}
}
