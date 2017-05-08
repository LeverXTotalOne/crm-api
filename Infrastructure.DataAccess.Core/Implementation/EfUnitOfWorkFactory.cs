using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Infrastructure.Core.DataContracts.Interfaces;

namespace Infrastructure.Core.DataAccess.Implementation
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly IDbContextFactory _dbContextFactory;

		public UnitOfWorkFactory(IDbContextFactory dbContextFactory)
		{
			this._dbContextFactory = dbContextFactory;
		}

		public IUnitOfWork Create()
		{
			return new UnitOfWork(_dbContextFactory);
		}

		public void Rollback()
		{
			var dbContext = (DbContext)_dbContextFactory.GetDbContextManager();
			foreach (var dbEntityEntry in dbContext.ChangeTracker.Entries())
			{
				((IObjectContextAdapter) dbContext).ObjectContext.Detach(dbEntityEntry.Entity);
			}
		}
	}
}