using System.Data.Entity;
using Infrastructure.Core.DataContracts.Interfaces;

namespace Infrastructure.Core.DataAccess.Implementation
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DbContext _dbContextManager;

		public UnitOfWork(IDbContextFactory dbContextFactory)
		{
			_dbContextManager = (DbContext)dbContextFactory.GetDbContextManager();
		}

		public int Commit()
		{
			return _dbContextManager.SaveChanges();
		}

		~UnitOfWork()
		{
			Dispose();
		}

		public void Dispose()
		{

		}
	}
}
