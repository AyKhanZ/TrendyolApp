using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace TrendyolApp.Services.Classes
{
    public static class SerialiazibleService<T> where T : class
    {
        public static string Serialization(T item) {

            var json = JsonSerializer.Serialize<T>(item);

            return json;
        }
        public static T? Deserialization(string? item)
        {
            if (item != null)
            {
                return JsonSerializer.Deserialize<T>(item);
            }
            else return null;
        }


    }
}
