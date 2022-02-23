using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Task3.Utility
{
    public static class DeSerializeJSON
    {
        public static T DeSerializeFile<T>(string filePath)
        {
            string jsonString = File.ReadAllText(filePath, Encoding.UTF8);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public static T DeSerializeFileReflection<T>(string path)
        {
            string text;
            var assembly = typeof(Tests).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(path);
            using (var reader = new StreamReader(stream))
            {                
                text = reader.ReadToEnd();
            }
            return JsonSerializer.Deserialize<T>(text);
        }        
    }
}
