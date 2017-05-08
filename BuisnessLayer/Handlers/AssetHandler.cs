using System.Collections.Generic;
using AutoMapper;
using SoftwareLicenses.DataAccess.Contracts.Interfaces;
using SoftwareLicenses.Service.Contracts.Interfaces;
using ServiceEntities = SoftwareLicenses.Service.Contracts.Entities;
using DataAccessEntities = SoftwareLicenses.DataAccess.Contracts.Entities;
using Infrastructure.Core.DataContracts.Interfaces;

namespace SoftwareLicenses.Service.Implementation.Handlers
{
	public class AssetHandler : BaseHandler<ServiceEntities.Asset, DataAccessEntities.Asset>, IAssetHandler
	{
		private readonly IAssetRepository _assetRepository;

		public AssetHandler(IAssetRepository assetRepository, IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
		{
			_assetRepository = assetRepository;
		}
		
		public IEnumerable<ServiceEntities.Asset> GetAllEntities()
		{
			return Mapper.Map<IEnumerable<DataAccessEntities.Asset>, IEnumerable<ServiceEntities.Asset>>(_assetRepository.GetAllEntities());
		}
        
		public ServiceEntities.Asset EntityById(ServiceEntities.Asset entity)
		{
			var newItem = InvokeAction<DataAccessEntities.Asset>(entity, _assetRepository.EntityById);

			return Mapper.Map<DataAccessEntities.Asset, ServiceEntities.Asset>(newItem);
		}

		public ServiceEntities.Asset Create(ServiceEntities.Asset entity)
		{
			var newItem = InvokeAction<DataAccessEntities.Asset>(entity, _assetRepository.Create);

			return Mapper.Map<DataAccessEntities.Asset, ServiceEntities.Asset>(newItem);
		}

		public bool Update(ServiceEntities.Asset entity)
		{
			return InvokeAction(entity, _assetRepository.Update);
		}

		public bool Delete(ServiceEntities.Asset entity)
		{
			return InvokeAction(entity, _assetRepository.Delete);
		}
	}
}
