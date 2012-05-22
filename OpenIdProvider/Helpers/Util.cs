using System;
using System.Diagnostics;
using System.Web;

namespace OpenIdProvider.Helpers
{
    internal static class Util
    {
        internal static Uri GetAppPathRootedUri(string value)
        {
            Debug.Assert(HttpContext.Current.Request.ApplicationPath != null, "HttpContext.Current.Request.ApplicationPath != null");

            string appPath = HttpContext.Current.Request.ApplicationPath.ToLowerInvariant();
            if (!appPath.EndsWith("/"))
            {
                appPath += "/";
            }

            return new Uri(HttpContext.Current.Request.Url, appPath + value);
        }
    }
}