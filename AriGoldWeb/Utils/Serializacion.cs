using System;
using System.Web.Script.Serialization;

namespace AriGoldWeb.Utils
{
    class Serializacion<T>
    {
        public static T Deserializar(String obj)
        {
            var ser = new JavaScriptSerializer();
            var objres = ser.Deserialize<T>(obj);
            return objres;
        }

        public static String Serializar(T obj)
        {
            var ser = new JavaScriptSerializer();
            var objres = ser.Serialize(obj);
            return objres;
        }
    }
}
