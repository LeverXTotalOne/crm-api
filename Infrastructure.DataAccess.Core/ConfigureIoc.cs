using Infrastructure.Core.DataAccess.Implementation;
using Infrastructure.Core.DataContracts.Interfaces;
using LightInject;

namespace Infrastructure.Core.DataAccess
{
    public static class ConfigureIoc
    {
        public static void Configure(ServiceContainer container)
        {
            container.Register<IConnectionStringHelper, ConnectionStringHelper>();
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>();
            container.Register<IDbContextFactory, DbContextFactory>();
        }
        
    }
}
