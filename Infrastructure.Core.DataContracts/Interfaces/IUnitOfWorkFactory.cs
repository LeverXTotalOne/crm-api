namespace Infrastructure.Core.DataContracts.Interfaces
{
	public interface IUnitOfWorkFactory
	{
		IUnitOfWork Create();
		void Rollback();
	}
}