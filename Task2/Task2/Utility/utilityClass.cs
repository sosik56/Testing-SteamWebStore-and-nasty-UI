using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Task2.ForData;

namespace Task2.Utility
{
    public static class UtilityClass
    {       
        private static string  _configPath = "Task2.Resourses.configJSON.json";
        private static string _dataCase2 = "Task2.Resourses.data.json";
        private static string _advancedSearchData = "Task2.Resourses.jsonForAdvancedSearch.json";

        public static ConfigClass ConfigData = SerializeJson.DeSerializationDataFromFileReflection<ConfigClass>(_configPath);
        public static DataClass DataTestCase2 = SerializeJson.DeSerializationDataFromFileReflection<DataClass>(_dataCase2);
        public static MarketAdvencedSearch DataAdvancedSearch =
            SerializeJson.DeSerializationDataFromFileReflection<MarketAdvencedSearch>(_advancedSearchData);

        public static int GetRidOfLettersAndSymbols(string str)
        {
            string pattern = @"\D";
            string target = "";
            Regex regex = new Regex(pattern);
            string strWithoutLetters = regex.Replace(str, target);
            int answer = Convert.ToInt32(strWithoutLetters);
            return answer;
        }

        public static string ReturnValue(string fileName,string key)
        {
            Dictionary<string, string> keyValuePairs = SerializeJson.DeSerializationDataFromFile<Dictionary<string, string>>(fileName);
            return keyValuePairs[key];
        }
    }
}
