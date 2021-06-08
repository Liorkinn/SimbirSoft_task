using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Simbirsoft_Practice
{
    public class HTMLWorker
    {

        public string[] site { get; private set; }

        public HTMLWorker(string[] sites)
        {
            site = sites;
        }

        public void SaveHTMLPages()
        {
            Console.WriteLine("---->Файл успешно сохранён.");
            for (int i = 0; i < site.Length; i++)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string directory = Directory.GetCurrentDirectory();
                        Console.WriteLine("Используемый сайт: " + site[i].ToString());
                        string htmlsites = client.DownloadString(site[i].ToString());
                        File.WriteAllText(directory + @"\" + i + ".html", htmlsites);
                        Console.WriteLine("---->Сайт успешно записан. Для продолжения нажмите любую кнопку.");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("---->Ошибка: " + e.ToString());
                }
            }
        }
    }
}
