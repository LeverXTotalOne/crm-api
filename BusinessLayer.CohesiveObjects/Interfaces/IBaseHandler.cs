using System.Collections.Generic;

namespace SoftwareLicenses.Service.Contracts.Interfaces
{
	public interface ICrudHandler<TEntity>
	{
		IEnumerable<TEntity> GetAllEntities();
		TEntity EntityById(TEntity entity);
		TEntity Create(TEntity entity);
		bool Update(TEntity entity);
		bool Delete(TEntity entity);
	}
}