using System.Collections.Generic;

namespace Task3.ForData
{
    public class ConfigClass
    {
        public string BrowserType { get; set; }
        public string Host { get; set; }
        public List<string> Arguments { get; set; }
        public int WaitingTime { get; set; }
    }
}
