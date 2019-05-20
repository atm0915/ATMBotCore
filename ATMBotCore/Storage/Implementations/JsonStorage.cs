using System.IO;
using static System.IO.Directory;
using Newtonsoft.Json;

namespace ATMBotCore.Storage.Implementations
{
    public class JsonStorage : IDataStorage
    {
        public void StoreObject(string key, object obj)
        {
            string file = $"{key}.json";
            CreateDirectory(Path.GetDirectoryName(file));
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(file, json);
        }

        public T RestoreObject<T>(string key)
        {
            string json = File.ReadAllText($"{key}.json");
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}