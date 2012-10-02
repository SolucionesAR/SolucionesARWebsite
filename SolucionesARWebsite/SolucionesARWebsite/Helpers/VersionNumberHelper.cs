using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Web;

namespace SolucionesARWebsite.Helpers
{
    public static class VersionNumberHelper
    {
        private static string _version;

        public static string RenderVersionNumber(this HttpContextBase httpContextBase)
        {
            if (httpContextBase == null)
            {
                throw new ArgumentNullException();
            }

            return _version ?? (_version = GetVersionNumber(Assembly.GetExecutingAssembly()));
        }

        #region Private Methods

        /// <summary>
        /// Gets the version number of the <paramref name="assembly"/> as an string with the format: x.x.xxxxxx
        /// <para>
        /// The last number is conformed by the days that have passed since the version start (a date given by the 
        /// <t cref="AssemblyConfigurationAttribute"/> of the assembly) and the revision of the assembly.
        /// </para>
        /// <para>
        /// Assumes that the assembly has declared the AssemblyConfigurationAttribute and its value is a DateTime with
        /// the format "yyyyMMdd" and that the AssemblyVersion revision is set to default
        /// </para>
        /// </summary>
        /// <param name="assembly"></param>
        /// <exception cref="ArgumentNullException">assembly is null</exception>
        /// <returns>An string with the version of the <paramref name="assembly"/></returns>
        private static string GetVersionNumber(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            var version = assembly.GetName().Version;
            var versionStarted = new DateTime(2000, 1, 1);
            var attributes = assembly.GetCustomAttributes(typeof (AssemblyConfigurationAttribute), false);
            
            if (attributes.Length != 0)
            {
                var attrValue = (AssemblyConfigurationAttribute)attributes[0];
                versionStarted = DateTime.ParseExact(attrValue.Configuration, "yyyyMMdd", CultureInfo.CurrentCulture);
            }

            var buildDate = GetBuildDateTime(assembly);
            var days = buildDate.ToUniversalTime().Subtract(versionStarted.ToUniversalTime()).Days;

            return string.Format("{0}.{1}{2:00000}", version.ToString(3), days, version.Revision);
        }

        private static DateTime GetBuildDateTime(Assembly assembly)
        {
            const int peHeaderOffset = 60;
            const int linkerTimestampOffset = 8;
            const int bufferSize = 2048;
            
            var filePath = assembly.Location;
            var buffer = new byte[bufferSize];
            
            using(var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                stream.Read(buffer, 0, bufferSize);
            }

            var i = BitConverter.ToInt32(buffer, peHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, i + linkerTimestampOffset);
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
            dateTime = dateTime.AddSeconds(secondsSince1970);
            dateTime = dateTime.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dateTime).Hours);
            
            return dateTime;
        }

        #endregion
    }
}