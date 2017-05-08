using LightInject;
using SoftwareLicenses.DataAccess.Contracts.Interfaces;
using SoftwareLicenses.DataAccess.Implementation.Repositories;
using ConfigureCoreDb = Infrastructure.Core.DataAccess.ConfigureIoc;

namespace SoftwareLicenses.DataAccess.Implementation
{
	public static class ConfigureIoc
	{
		public static void Configure(ServiceContainer container)
		{
			container.Register<IAssetRepository, AssetRepository>();

		    ConfigureCoreDb.Configure(container);
        }
		
	}
}
