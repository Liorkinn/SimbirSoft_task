using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Simbirsoft_Practice
{
    //Создаётся файл list.txt, в которые записываются ссылки на сайты. Именно из них идёт считывание слов. На их основе формируется статистика в БД. 
    //Без настроенной БД приложение не будет работать корректно(будут высвечиваться exception из dbworker, т.к. соединения не будет.)
    //Для настройки приложения необходимо загрузить xampp(mysql), а также любую СУБД(в приоритете - HeidiSQL). Скачиваем sql скрипт из моего github, и загружаем БД. Необходимо убедиться, не слетели ли ключи primary key, unique.
    public class FileWorker
    {
        public string[] ReadFile()
        {
            string[] readerText;
            string[] tempText;
            string directory = Directory.GetCurrentDirectory();
            string site = "list.txt";
            string path = directory + @"\" + site;
            if (!File.Exists(path))
            {
                Console.WriteLine("---->Файловые сайты не существуют, ");
                string[] createText = { "https://www.vk.com/", "https://www.simbirsoft.com/", "https://www.google.com/" };
                File.WriteAllLines(path, createText);
            }

            tempText = File.ReadAllLines(path);
            readerText = CheckUrl(tempText);
            if (readerText == null)
            {
                System.Environment.Exit(-1);
            }
            return readerText;
        }

        private string[] CheckUrl(string[] urlcheck)
        {
            List<string> Check = new List<string>();
            string pattern = @"^(http|http(s)?://)+([\w-]+\.)+(\[\?%&=]*)?";
            for (int i = 0; i < urlcheck.Length; i++)
            {
                if (Regex.IsMatch(urlcheck[i], pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("URL верен. Успешно.");
                    Check.Add(urlcheck[i]);
                }
                else
                {
                    Console.WriteLine("URL некорректен. Ошибка.");
                    Console.WriteLine("Строка {0}", urlcheck[i]);
                }
            }
            return Check.ToArray();
        }
    }
}
