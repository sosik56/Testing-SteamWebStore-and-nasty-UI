using System;
using System.Text.RegularExpressions;


namespace Task2.Utility
{
    public static class utilityClass
    {
        public static int getRidOfLettersAndSymbols(string str)
        {
            string pattern = @"\D";
            string target = "";
            Regex regex = new Regex(pattern);
            string strWithoutLetters = regex.Replace(str, target);
            int answer = Convert.ToInt32(strWithoutLetters);
            return answer;
        }
    }
}
