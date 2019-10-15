using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace ConestogaVirtualGameStore.Helpers
{
    /// <summary>
    /// Session helper that allows storing of complex objects using JsonConvert
    /// and BitConverter to convert/serialize the specified object.
    /// </summary>
    public static class SessionHelper
    {
        /// <summary>
        /// Sets a complex session object
        /// </summary>
        /// <typeparam name="T">The type of object</typeparam>
        /// <param name="session">The session</param>
        /// <param name="key">The name for the object/value being set</param>
        /// <param name="value">The object/value being set</param>
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Gets a complex session object.
        /// </summary>
        /// <typeparam name="T">The type of object</typeparam>
        /// <param name="session">The session</param>
        /// <param name="key">The name for the object/value being retrieved</param>
        /// <returns>The deserialized object</returns>
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default :
                JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Sets a session boolean.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="key">The name for the object/value being set</param>
        /// <param name="value">The object/value being set</param>
        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Gets a session boolean
        /// </summary>
        /// <param name="session"The session></param>
        /// <param name="key">The name for the object/value being retrieved</param>
        /// <returns>The deserialized boolean</returns>
        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);

            if (data == null) return null;

            return BitConverter.ToBoolean(data, 0);
        }

        /// <summary>
        /// Sets a session double.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="key">The name for the object/value being set</param>
        /// <param name="value">The object/value being set</param>
        public static void SetDouble(this ISession session, string key, double value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Gets a session double.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="key">The name for the object/value being retrieved</param>
        /// <returns>The deserialized double</returns>
        public static double? GetDouble(this ISession session, string key)
        {
            var data = session.Get(key);

            if (data == null) return null;

            return BitConverter.ToDouble(data, 0);
        }
    }
}
