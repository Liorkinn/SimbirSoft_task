using HtmlAgilityPack;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simbirsoft_Practice
{

    class WordWorker
    {

        MySqlConnection connections;
        dbworker a = new dbworker("127.0.0.1", "root", "", "simbirsoft");
        public string[] site { get; private set; }

        public WordWorker(string[] htmlsites)
        {
            site = htmlsites;
        }

        public void Work()
        {
            for (int i = 0; i < site.Length; i++)
            {
                Console.WriteLine("---->Текущий сайт: " + site[i]); Console.WriteLine("\n");
                string text = ReadTextFromSite(site[i]);
                a.download_site(site[i].ToString());
                if (text == null)
                {
                    Console.WriteLine("---->Плохая связь с сайтом. Возможны ошибки.");
                    break;
                }
                var result = Calc(text);
                result.Remove("");
                foreach (var pair in result)
                {
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                    a.download_words(pair.Key.ToString(), pair.Value.ToString());
                    a.download_sites_and_words(site[i], pair.Key, pair.Value);
                }
                Console.WriteLine("\n\n");
            }


        }

        static Dictionary<string, int> Calc(string site)
        {
            var res = new Dictionary<string, int>();

            foreach (var word in site.Split
                (' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t').Skip(1))
            {
                var count = 0;
                res.TryGetValue(word, out count);
                res[word] = count + 1;
            }

            return res;
        }


        public string ReadTextFromSite(string site)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            try
            {
                HtmlDocument document = htmlWeb.Load(site);
                return document.DocumentNode.InnerText;
            }
            catch (Exception e)
            {
                Console.WriteLine("---->Ошибка : " + e.ToString());
                return null;
            }
        }
    }
}
