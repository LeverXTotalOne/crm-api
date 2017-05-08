using System.Data.Entity;
using SoftwareLicenses.DataAccess.Contracts.Entities;

namespace Infrastructure.Core.DataAccess
{
    public class TotalOneContext : DbContext
    {
		public TotalOneContext() : base("name=totalonedb")
		{

		}

		public TotalOneContext(string connectionString) : base(connectionString)
	    {
		    
	    }
        
        public DbSet<Asset> Assets { get; set; }
	}
}
