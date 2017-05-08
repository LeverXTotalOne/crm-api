using System.Linq;
using Infrastructure.Core.DataAccess;
using Infrastructure.Core.DataContracts.Interfaces;
using SoftwareLicenses.DataAccess.Contracts.Entities;
using SoftwareLicenses.DataAccess.Contracts.Interfaces;

namespace SoftwareLicenses.DataAccess.Implementation.Repositories
{
	public class AssetRepository : BaseRepository<Asset>, IAssetRepository
	{
		public AssetRepository(IDbContextFactory dbContextFactory)
			: base(dbContextFactory)
		{
			
		}

	    public override Asset EntityById(Asset entity)
	    {
	        return DbSet.FirstOrDefault(t => t.AssetId == entity.AssetId && !t.IsDeleted);
	    }

	    public Asset Create(Asset item)
		{
			var newAsset = new Asset
			{
				Name = item.Name
			};

			return DbSet.Add(newAsset);
		}

		public bool Update(Asset item)
		{
			var existingAsset = EntityById(item);

			existingAsset.Name = item.Name;

			return true;
		}
	}

	
}
