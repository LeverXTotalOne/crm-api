using System.Collections.Generic;

namespace SoftwareLicenses.DataAccess.Contracts.Entities
{
	public class Asset
	{
		public int AssetId { get; set; }
		public string Name { get; set; }
	    public bool IsDeleted { get; set; }
	}
}
