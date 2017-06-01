
using System;
using Docway.Domain.Core.Commands;

namespace Docway.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		CommandResponse Commit();
	}
}
