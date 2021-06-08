using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Simbirsoft_Practice
{
    public class HTMLWorker
    {
        /// <summary>
        /// Save site to local folder
        /// </summary>
        public string[] site { get; private set; }

        public HTMLWorker(string[] sites)
        {
            site = sites;
        }

        public void SaveHTMLPages()
        {
            for (int i = 0; i < site.Length; i++)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string directory = Directory.GetCurrentDirectory();
                        Console.WriteLine(site[i].ToString());
                        string html = client.DownloadString(site[i].ToString());
                        File.WriteAllText(directory + @"\" + i + ".html", html);
                        Console.WriteLine("Файл успешно сохранён.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.ToString());
                }
            }
        }
    }
}
