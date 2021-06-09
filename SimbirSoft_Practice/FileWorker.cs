using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Simbirsoft_Practice
{
    public class FileWorker
    {     
        private string[] CheckUrl(string[] checkurl)
        {
            List<string> tempReadTextCheck = new List<string>();
            string pattern = @"^(http|http(s)?://)+([\w-]+\.)+(\[\?%&=]*)?";
            for (int i = 0; i < checkurl.Length; i++)
            {
                if (Regex.IsMatch(checkurl[i], pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("URL верен. Успешно.");
                    tempReadTextCheck.Add(checkurl[i]);
                }
                else
                {
                    Console.WriteLine("URL некорректен. Ошибка.");
                    Console.WriteLine("Строка {0}", checkurl[i]);
                }
            }
            return tempReadTextCheck.ToArray();
        }
    }
}
