﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Docway.Domain.Interfaces;
using Docway.Infra.Data.Context;

using System.Data.Entity;

namespace Docway.Infra.Data.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected DocwayContext Db;
		protected DbSet<TEntity> DbSet;

		public Repository(DocwayContext context)
		{
			Db = context;
			DbSet = Db.Set<TEntity>();
		}

		public virtual void Add(TEntity obj)
		{
			DbSet.Add(obj);
		}

		public virtual TEntity GetById(Guid id)
		{
			return DbSet.Find(id);
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return DbSet.ToList();
		}

		public virtual void Update(TEntity obj)
		{
			DbSet.Attach(obj);
		}

		public virtual void Remove(Guid id)
		{
			DbSet.Remove(DbSet.Find(id));
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return DbSet.AsNoTracking().Where(predicate);
		}

		public int SaveChanges()
		{
			return Db.SaveChanges();
		}

		public void Dispose()
		{
			Db.Dispose();
			GC.SuppressFinalize(this);
		}

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }
    }
}
