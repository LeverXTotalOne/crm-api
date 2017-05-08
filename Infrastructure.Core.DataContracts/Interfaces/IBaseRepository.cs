using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infrastructure.Core.DataContracts.Interfaces
{
	public interface IBaseRepository<TEntity>
	{
		IEnumerable<TEntity> GetAllEntities(Expression<Func<TEntity, bool>> where = null);
		TEntity EntityById(TEntity entity);
		TEntity Create(TEntity item);
		bool Update(TEntity item);
		bool Delete(TEntity item);
	}
}