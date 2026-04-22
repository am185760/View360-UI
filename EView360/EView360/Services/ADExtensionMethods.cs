using System.DirectoryServices;

namespace EView360.Services
{
    public static class ADExtensionMethods
    {
        public static string GetPropertyValue(this SearchResult sr, string propertyName)
        {
            string ret = string.Empty;

            if (sr.Properties[propertyName].Count > 0)
                ret = sr.Properties[propertyName][0].ToString();

            return ret;
        }
    }
}
