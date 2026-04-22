using Newtonsoft.Json;

namespace EView360.Common
{
    public static class SessionExtensions
    {
        public static void SetValue<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T? GetValue<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
