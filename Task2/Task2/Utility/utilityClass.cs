using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Task2.ForData;

namespace Task2.Utility
{
    public static class UtilityClass
    {
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
