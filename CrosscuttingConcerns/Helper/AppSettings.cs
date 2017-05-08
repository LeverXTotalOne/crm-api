using System.Configuration;

namespace Infrastructure.Core.Helper
{
	public static class AppSettings
	{
		public static string DomainName => ConfigurationManager.AppSettings["domainName"];
        
	}
}
