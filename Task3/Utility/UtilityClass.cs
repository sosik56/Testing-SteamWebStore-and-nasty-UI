using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Task3.ForData;
using Task3.Models;
using System.IO;

namespace Task3.Utility
{
    public static class UtilityClass
    {
        private static string _configPath = "Task3.Resourses.configJSON.json"; 
        private static string _dataPath = "Task3.Resourses.UsersData.json";
        public static string data = "Task3.Resourses.data.json";

        public static ConfigClass ConfigData = DeSerializeJSON.DeSerializeFileReflection<ConfigClass>(_configPath);
        public static User UsersData = DeSerializeJSON.DeSerializeFileReflection<User>(_dataPath);        

        public static int GetRidOfLettersAndSymbols(string str)
        {
            string pattern = @"\D";
            string target = "";
            Regex regex = new Regex(pattern);
            string strWithoutLetters = regex.Replace(str, target);
            int answer = Convert.ToInt32(strWithoutLetters);
            return answer;
        } 
        
        public static string GetRidOfNumbers(string str)
        {
            string pattern = @"[^\p{L}]";
            string target = "";
            Regex regex = new Regex(pattern);
            string strWithoutNumbers = regex.Replace(str, target);
            return strWithoutNumbers;
        }

        public static string ReturnValue(string fileName, string key)
        {
            Dictionary<string, string> keyValuePairs = DeSerializeJSON.DeSerializeFileReflection<Dictionary<string, string>>(fileName);
            return keyValuePairs[key];
        }
        
        public static int GetRandomInt(int minBound , int maxBound)
        {
            Random rnd = new Random();
            int value = rnd.Next(minBound, maxBound);
            return value;
        }

        public static string GetRandomGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static DateTime GetDateTimeNow()
        {            
            return DateTime.Now;            
        }

        public static void DeletFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
