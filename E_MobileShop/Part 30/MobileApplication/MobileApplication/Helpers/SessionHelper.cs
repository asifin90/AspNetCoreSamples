using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Helpers
{
    public static class SessionHelper
    {
        public static void SetSerializeSessionData(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetDeserializeSessionData<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value ==  null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
