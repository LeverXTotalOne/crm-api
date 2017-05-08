using System.Configuration;
using Infrastructure.Core.Interfaces;

namespace SoftwareLicenses.Console
{
    public class ContextServiceForConsole : IContextService
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }
    }
}
