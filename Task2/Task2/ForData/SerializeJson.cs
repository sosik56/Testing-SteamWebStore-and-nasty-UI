using System.IO;
using System.Reflection;
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

        public static T DeSerializationDataFromFileReflection<T>(string path)
        {
            string text;
            var assembly = typeof(Task2.Tests).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(path);
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return JsonSerializer.Deserialize<T>(text);
        }
    }
}
