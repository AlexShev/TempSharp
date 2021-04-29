using System;
using System.Collections.Generic;
using System.Linq;

namespace TempSharp
{
    public class StandartView
    {
        public static string[] ToStringArray(string str, char separator = ' ')
            => str.Split(new char[] { separator, ' ' }, StringSplitOptions.RemoveEmptyEntries);

        public static bool IsAWord(string word)
        {
            if (word.Length < 1 || word.Length > 100)
            {
                return false;
            }

            if (word[0] < 'A' || word[0] > 'Z')
            {
                return false;
            } 

            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] < 'a' || word[i] > 'z')
                {
                    return false;
                }
            }

            return true;
        }

        public static string WordEr(string word)
        {
            if (!IsAWord(word))
            {
                throw new System.Exception($"ошибка в {word} это вырожение не имеет смысла");
            }
            else
            {
                return word;
            }
        }

        static public string IsPhoneNumber(string phoneNumber)
        {
            string temp = new System.Text.RegularExpressions.Regex(@"\D").Replace(phoneNumber, string.Empty);

            temp = Convert.ToInt64(temp).ToString("#(###)###-##-##");

            if (phoneNumber == temp)
            {
                return phoneNumber;
            }
            else
            {
                throw new System.Exception($"{phoneNumber} не номер телефона");
            }
        }

        public static DateTime ConverteStringToDate(string str)
        {
            var strArr = ToStringArray(str, '.');

            return new DateTime(int.Parse(strArr[2]), int.Parse(strArr[1]), int.Parse(strArr[0]));
        }
    }
}