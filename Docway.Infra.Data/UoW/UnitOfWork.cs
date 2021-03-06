﻿using System;
using Docway.Domain.Core.Commands;
using Docway.Domain.Interfaces;
using Docway.Infra.Data.Context;

namespace Docway.Infra.Data.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DocwayContext _context;

		public UnitOfWork(DocwayContext context)
		{
			_context = context;
		}

		public CommandResponse Commit()
		{
			var rowsAffected = _context.SaveChanges();
			return new CommandResponse(rowsAffected > 0);
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
