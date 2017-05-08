using System;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Core
{
    public static class ExtensionHelper
    {
	    public static Guid ToGuid(this string value)
	    {
			Guid guid;

		    using (var md5 = MD5.Create())
		    {
			    guid = new Guid(md5.ComputeHash(Encoding.UTF8.GetBytes(value)));
		    }

		    return guid;
	    }
    }
}
