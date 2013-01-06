using System.Web;
using System.Web.Caching;
using System.Xml;

namespace SolucionesARWebsite2.Security
{
    /// <summary>
    /// From a XML, gets the user permitted actions according to the role.
    /// </summary>
    public static class RolesProvider
    {
        /// <summary>
        /// Required to build a key to find a role in the cache
        /// </summary>
        public const string ROLE_CACHE_KEY = "ROLE${0}";

        /// <summary>
        /// Gets the security role for the given parameters.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="request">The request.</param>
        /// <returns>Returns the security role for the given role name, with its permissions</returns>
        public static SecurityRol GetSecurityRole(string roleName, HttpRequestBase request)
        {
            var cacheKey = GetRoleCacheKey(roleName);
            var securityRole = HttpContext.Current.Cache[cacheKey] as SecurityRol;
            if (securityRole == null)
            {
                var strFilePath = request.MapPath("~/Security/Roles/" + roleName + ".xml");
                var xdoc = new XmlDocument();
                xdoc.Load(strFilePath);
                if (xdoc.DocumentElement != null)
                {
                    securityRole = new SecurityRol(roleName, xdoc.DocumentElement);
                    HttpContext.Current.Cache.Insert(cacheKey, securityRole, new CacheDependency(strFilePath));
                }
            }
            return securityRole;
        }

        /// <summary>
        /// Gets the role cache key.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>Returns the role key for the given roleName</returns>
        private static string GetRoleCacheKey(string roleName)
        {
            return string.Format(ROLE_CACHE_KEY, roleName.ToUpper().Replace(" ", "_"));
        }
    }
}