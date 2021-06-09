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

        public WordWorker(string[] sites)
        {
            site = sites;
        }
        } 
    }
}
