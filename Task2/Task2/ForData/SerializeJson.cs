using System.IO;
using System.Text;
using System.Text.Json;

namespace Task2.ForData
{
    public static class SerializeJson
    { 
        public static T DeSerializationDataFromFile<T>(string filePath)
        {
            string jsonString = File.ReadAllText(filePath, Encoding.UTF8);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
