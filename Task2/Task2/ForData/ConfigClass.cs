
using System.Collections.Generic;

namespace Task2.ForData
{
    public class ConfigClass
    {
        public  string BrowserType { get; set; }
        public  string Host { get; set; }        
        public  List<string> Arguments { get; set; }   
        public int waitingTime { get; set; }
        public ConfigClass() { }

        public ConfigClass(string browserType , string host, List<string> arguments)
        {
            BrowserType = browserType;
            Host = host;
            Arguments = arguments;
        }
    }
}
