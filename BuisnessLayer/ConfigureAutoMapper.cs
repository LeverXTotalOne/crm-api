using AutoMapper;
using ServiceEntities = SoftwareLicenses.Service.Contracts.Entities;
using DataAccessEntities = SoftwareLicenses.DataAccess.Contracts.Entities;

namespace SoftwareLicenses.Service.Implementation
{
	public static class ConfigureAutoMapper
	{
		public static void Configure(IMapperConfigurationExpression config)
		{
			config.CreateMap<ServiceEntities.Asset, DataAccessEntities.Asset>();
			
			config.CreateMap<DataAccessEntities.Asset, ServiceEntities.Asset>();
		}
	}
}
