namespace Infrastructure.Core.DataContracts.Interfaces
{
	public interface IDbContextFactory
	{
		object GetDbContextManager();
		string CurrentConnectionString { get; }
	}
}