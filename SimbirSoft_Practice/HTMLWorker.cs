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
    }
}
