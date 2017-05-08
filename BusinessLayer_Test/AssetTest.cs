using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LightInject;
using NUnit.Framework;
using SoftwareLicenses.Service.Contracts.Entities;
using SoftwareLicenses.Service.Contracts.Interfaces;

namespace SoftwareLicenses.Service.Implementation.Test
{
    [TestFixture]
    class AssetTest
    {
        private IAssetHandler _assetHandler;

        [OneTimeSetUp]
        public void Init()
        {
            var container = new ServiceContainer();
            DiConfigure.Configure(container);
            Mapper.Initialize(ConfigureAutoMapper.Configure);

            _assetHandler = container.GetInstance<IAssetHandler>();
        }

        [Test]
        public void IsCreateAssetIsWorkingTest()
        {
            var entity = new Asset {Name = "Test Asset"};

            var createdAsset =  _assetHandler.Create(entity);

            Assert.IsTrue(createdAsset.AssetId > 0);
        }

        [Test]
        public void IsGetAssetIsWorkingTest()
        {
            var allEntities = _assetHandler.GetAllEntities();

            Assert.IsTrue(allEntities.Any());
        }

        [Test]
        public void IsUpdateAssetIsWorkingTest()
        {
            var diffName = Guid.NewGuid().ToString("N");

            var allEntities = _assetHandler.GetAllEntities().ToList();

            var entityForUpdate = allEntities.First();

            var prevName = entityForUpdate.Name;

            entityForUpdate.Name = diffName;

            var isUpdated = _assetHandler.Update(entityForUpdate);

            Assert.IsTrue(isUpdated);
        }
    }
}
