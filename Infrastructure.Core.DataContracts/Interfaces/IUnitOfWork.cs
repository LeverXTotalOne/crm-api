using System;

namespace Infrastructure.Core.DataContracts.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		int Commit();
	}
}