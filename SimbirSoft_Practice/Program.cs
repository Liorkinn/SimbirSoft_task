using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Simbirsoft_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---->Совершается загрузка файла и инициализация сайтов.");
            Program start = new Program();
            start.Start();
            Console.WriteLine("---->Нажмите любую кнопку для завершения...");
            Console.ReadKey();
        }

        public void Start()
        {
            FileWorker fileWorker = new FileWorker();
            HTMLWorker htmlWorker;
            WordWorker wordWorker;
            var urldata = fileWorker.ReadFile();
            Console.WriteLine(urldata);
            htmlWorker = new HTMLWorker(urldata);
            htmlWorker.SaveHTMLPages();
            wordWorker = new WordWorker(urldata);
            wordWorker.Work();
        }
    }
}
