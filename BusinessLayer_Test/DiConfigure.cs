using Infrastructure.Core.Interfaces;
using LightInject;
using SoftwareLicenses.Service.Implementation.Test.Service;
using ConfigureLicenses = SoftwareLicenses.Service.Implementation.ConfigureIoc;
using ConfigureDataAccess = SoftwareLicenses.DataAccess.Implementation.ConfigureIoc;

namespace SoftwareLicenses.Service.Implementation.Test
{
	public static class DiConfigure
	{
		public static void Configure(ServiceContainer container)
		{
			container.Register<IContextService, ContextServiceForTest>();

		    ConfigureLicenses.Configure(container);
		    ConfigureDataAccess.Configure(container);
        }
	}
}
