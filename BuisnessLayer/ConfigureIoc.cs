using LightInject;
using SoftwareLicenses.Service.Contracts.Interfaces;
using SoftwareLicenses.Service.Implementation.Handlers;

namespace SoftwareLicenses.Service.Implementation
{
	public static class ConfigureIoc
	{
		public static void Configure(ServiceContainer container)
		{
			container.Register<IAssetHandler, AssetHandler>();
		}
	}
}
