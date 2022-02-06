//using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Task2.ForData
{

    static class SerializeJson
    {
        public static System.Text.Unicode.UnicodeRange All { get; }

        //public static ConfigClass serializeConfigClass(string file_Name)
        //{
        //    var ConfigClass = new ConfigClass();
        //    JsonTextReader reader = new JsonTextReader(new StreamReader(file_Name));
        //    reader.SupportMultipleContent = true;
        //    while (true)
        //    {
        //        if (!reader.Read())
        //        {
        //            break;
        //        }
        //        JsonSerializer serializer = new JsonSerializer();
        //        ConfigClass = serializer.Deserialize<ConfigClass>(reader);
        //    }
        //    return ConfigClass;
        //}

        //public static DataClass serializeConfigClass(string file_Name, int val)
        //{
        //    var dataClass = new DataClass();
        //    JsonTextReader reader = new JsonTextReader(new StreamReader(file_Name, UTF8Encoding.Default));
        //    reader.SupportMultipleContent = true;
        //    while (true)
        //    {
        //        if (!reader.Read())
        //        {
        //            break;
        //        }
        //        JsonSerializer serializer = new JsonSerializer();
        //        dataClass = serializer.Deserialize<DataClass>(reader);
        //    }
        //    return dataClass;
        //}


        public static void serializeConfigClass(string file_Name, out ConfigClass configClass)
        {          
            string fileName = file_Name;
            string jsonString = File.ReadAllText(fileName, Encoding.UTF8);
            configClass = JsonSerializer.Deserialize<ConfigClass>(jsonString);
        }

        public static void serializeConfigClass(string file_Name, out DataClass dataClass)
        {
            string fileName = file_Name;    
            string jsonString = File.ReadAllText(fileName, Encoding.Default);
            dataClass = JsonSerializer.Deserialize<DataClass>(jsonString);
        }
    }
}
