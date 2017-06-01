using System;
using Docway.Domain.Core.Events;
using FluentValidation.Results;

namespace Docway.Domain.Core.Commands
{
	public abstract class Command : Message
	{
		public DateTime Timestamp { get; private set; }
		public ValidationResult ValidationResult { get; set; }

		protected Command()
		{
			Timestamp = DateTime.Now;
		}

		public abstract bool IsValid();
	}
}
