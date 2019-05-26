using System;
using System.IO;
using static System.IO.Directory;
using Newtonsoft.Json;

namespace ATMBotCore.Storage.Implementations
{
    public class JsonStorage : IDataStorage
    {
        public void StoreObject(string key, object obj)
        {
            string file = $"Resources/{key}.json";
            CreateDirectory(Path.GetDirectoryName(file));
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(file, json);
        }

        public T RestoreObject<T>(string key)
        {
            if (!File.Exists($"Resources/{key}.json"))
                throw new ArgumentException($"The provided file 'Resources/{key}.json' was not found.");
            string json = File.ReadAllText($"Resources/{key}.json");
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}