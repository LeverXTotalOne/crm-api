using System;
using AutoMapper;
using Infrastructure.Core.DataContracts.Interfaces;

namespace SoftwareLicenses.Service.Implementation.Handlers
{
	public abstract class BaseHandler<TBlEntity, TDalEntity>
	{
		protected readonly IUnitOfWorkFactory UnitOfWorkFactory;
		
		protected BaseHandler(IUnitOfWorkFactory unitOfWorkFactory)
		{
			UnitOfWorkFactory = unitOfWorkFactory;
		}

		public virtual bool InvokeAction(TBlEntity blEntity, Func<TDalEntity, bool> action)
		{
			return InvokeAction<bool>(blEntity, action);
		}

		public virtual TResult InvokeAction<TResult>(TBlEntity blEntity, Func<TDalEntity, TResult> action)
		{
			var newEntity = Mapper.Map<TBlEntity, TDalEntity>(blEntity);

			TResult result;
			
			using (var tran = UnitOfWorkFactory.Create())
			{
				result = action(newEntity);

				tran.Commit();
			}

			return result;
		}
	}
}