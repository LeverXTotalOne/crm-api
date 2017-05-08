using System.Configuration;
using Infrastructure.Core.Interfaces;

namespace SoftwareLicenses.Service.Implementation.Test.Service
{
	public class ContextServiceForTest : IContextService
	{
		public string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
		}
	}
}
