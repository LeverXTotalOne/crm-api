using Infrastructure.Core.DataContracts.Interfaces;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Core.DataAccess.Implementation
{
	public class ConnectionStringHelper : IConnectionStringHelper
	{
		private readonly IContextService _contextService;

		public ConnectionStringHelper(IContextService contextService)
		{
			_contextService = contextService;
		}

		public string GetCurrentConnectionString()
		{
			return _contextService.GetConnectionString();
		}
	}
}
