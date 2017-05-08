using System;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Infrastructure.Core.DataAccess.Implementation
{
	public class DbContextManager : IDisposable
	{
		private const string ContextKey = "SoftwareLicenses_CONTEXTKEY";

		private static bool IsInWebContext => HttpContext.Current != null;
        
		public DbContextManager(string connectionString)
		{
			if (DbContext == null)
			{
				DbContext = new TotalOneContext(connectionString);
			}
		}

		public int SaveChanges()
		{
			return DbContext.SaveChanges();
		}

		~DbContextManager()
		{
			Dispose();
		}

		public void Dispose()
		{
			try
			{
				var s = DbContext;
				if (s == null) return;
				DbContext = null;

				s.Dispose();
			}
			finally
			{
				GC.SuppressFinalize(this);
			}
		}

		public TotalOneContext DbContext
		{
			get
			{
				if (IsInWebContext)
				{
					return (TotalOneContext)HttpContext.Current.Items[ContextKey];
				}
				return (TotalOneContext)CallContext.GetData(ContextKey);
			}
			private set
			{
				if (IsInWebContext)
				{
					HttpContext.Current.Items[ContextKey] = value;
				}
				else
				{
					CallContext.SetData(ContextKey, value);
				}
			}
		}
	}
}