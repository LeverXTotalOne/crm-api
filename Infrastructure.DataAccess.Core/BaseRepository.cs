using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.Core.DataContracts.Interfaces;
using System.Linq.Dynamic;

namespace Infrastructure.Core.DataAccess
{
	public abstract class BaseRepository<TEntity> where TEntity : class
	{
		protected IDbContextFactory DbContextFactory;

		protected TotalOneContext Context => (TotalOneContext)DbContextFactory.GetDbContextManager();

		protected BaseRepository(IDbContextFactory dbContextFactory)
		{
			DbContextFactory = dbContextFactory;
		}

		protected virtual DbSet<TEntity> DbSet => Context.Set<TEntity>();

		protected virtual DbSet<T> GetDbSet<T>() where T : class 
		{
			return Context.Set<T>();
		}

		protected virtual DbQuery<TEntity> DbSetAsNoTracking => Context.Set<TEntity>().AsNoTracking();
		
		public virtual IEnumerable<TEntity> GetAllEntities(Expression<Func<TEntity, bool>> where = null)
		{
			return where == null ? DbSetAsNoTracking.ToList() : DbSetAsNoTracking.Where(where).ToList();
		}

		public virtual bool Delete(TEntity entity)
		{
			var existingItem = EntityById(entity);

			DbSet.Remove(existingItem);

			return true;
		}

		public virtual TEntity EntityById(TEntity entity)
		{
			return GetById(entity);
		}

		private T GetById<T>(T entity) where T : class
		{
			if (entity == null)
				throw new ObjectNotFoundException($"{nameof(entity)} can not be null");

			var objectContext = ((IObjectContextAdapter)Context).ObjectContext;
			var set = objectContext.CreateObjectSet<T>();
			var keyName = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).FirstOrDefault();

			if (string.IsNullOrEmpty(keyName))
				throw new ObjectNotFoundException("Key was not found");
			
			var keyValueObj = entity.GetType().GetProperty(keyName).GetValue(entity, null).ToString();

			long keyValue;

			if (long.TryParse(keyValueObj, out keyValue) && keyValue > 0)
			{
				return GetDbSet<T>().Where(keyName + "=" + keyValueObj).FirstOrDefault();
			}

			Guid guidKey;

			if (Guid.TryParse(keyValueObj, out guidKey) && guidKey != Guid.Empty)
			{
				return GetDbSet<T>().Where(keyName+".Equals(@0)", guidKey).FirstOrDefault();
			}

			return null;
		}

		protected T SafeAttach<T>(T entity, bool update = true) where T : class
		{
			var result = GetById(entity);

			if (result != null)
			{
				if (update)
				{
					Context.Entry(result).CurrentValues.SetValues(entity);
				}
			}
			else
			{
				result = GetDbSet<T>().Add(entity);
			}

			return result;
		}
	}
}