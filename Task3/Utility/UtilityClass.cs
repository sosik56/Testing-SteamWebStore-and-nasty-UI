using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Task3.ForData;

namespace Task3.Utility
{
    public static class UtilityClass
    {
        private static string _configPath = "Task3.Resourses.configJSON.json";      

        public static ConfigClass ConfigData = DeSerializeJSON.DeSerializeFileReflection<ConfigClass>(_configPath);      


        public static int GetRidOfLettersAndSymbols(string str)
        {
            string pattern = @"\D";
            string target = "";
            Regex regex = new Regex(pattern);
            string strWithoutLetters = regex.Replace(str, target);
            int answer = Convert.ToInt32(strWithoutLetters);
            return answer;
        }

        public static string ReturnValue(string fileName, string key)
        {
            Dictionary<string, string> keyValuePairs = DeSerializeJSON.DeSerializeFile<Dictionary<string, string>>(fileName);
            return keyValuePairs[key];
        }
    }
}
