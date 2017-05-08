using System.Collections.Generic;
using AutoMapper;
using LightInject;
using SoftwareLicenses.Service.Contracts.Entities;
using SoftwareLicenses.Service.Contracts.Interfaces;
using SoftwareLicenses.Service.Implementation;
using ConfigureLicenses = SoftwareLicenses.Service.Implementation.ConfigureIoc;
using ConfigureDataAccess = SoftwareLicenses.DataAccess.Implementation.ConfigureIoc;
using Infrastructure.Core.Interfaces;

namespace SoftwareLicenses.Console
{
    class Program
    {
        private static IAssetHandler _assetHandler;

        static void Main(string[] args)
        {
            var container = new ServiceContainer();

            container.Register<IContextService, ContextServiceForConsole>();

            ConfigureLicenses.Configure(container);
            ConfigureDataAccess.Configure(container);

            Mapper.Initialize(ConfigureAutoMapper.Configure);
            
            _assetHandler = container.GetInstance<IAssetHandler>();

            // create some asset
            Asset newAsset = CreateAsset(new Asset { Name = "Test Asset" });
            
            var assets = GetAllAssets();

            newAsset.Name = "New Name";

            UpdateAsset(newAsset);

            DeleteAsset(newAsset.AssetId);
        }

        public static Asset CreateAsset(Asset asset)
        {
            var createdAsset = _assetHandler.Create(asset);

            return createdAsset;
        }

        public static IEnumerable<Asset> GetAllAssets()
        {
            var allEntities = _assetHandler.GetAllEntities();

            return allEntities;
        }

        public static void UpdateAsset(Asset asset)
        {
            var isUpdated = _assetHandler.Update(asset);
        }

        public static void DeleteAsset(int assetId)
        {
            var isDeleted = _assetHandler.Delete(new Asset {AssetId = assetId });
        }

    }
}
