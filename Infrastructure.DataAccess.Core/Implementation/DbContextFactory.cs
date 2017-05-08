using System.Data.Entity;
using Infrastructure.Core.DataContracts.Interfaces;

namespace Infrastructure.Core.DataAccess.Implementation
{
	public class DbContextFactory : IDbContextFactory
	{
		private readonly IConnectionStringHelper _connectionHelper;

		private readonly string _connectionString;

		public DbContextFactory(IConnectionStringHelper connectionHelper)
		{
			_connectionHelper = connectionHelper;
		}

		public DbContextFactory(string connectionString)
		{
			_connectionString = connectionString;
		}

		public string CurrentConnectionString => string.IsNullOrEmpty(_connectionString)
			? _connectionHelper.GetCurrentConnectionString()
			: _connectionString;

		public object GetDbContextManager()
		{
			return string.IsNullOrEmpty(_connectionString)
				? new DbContextManager(_connectionHelper.GetCurrentConnectionString()).DbContext
				: new DbContextManager(_connectionString).DbContext;
		}
	}
}