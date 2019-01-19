using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TaskWebAPI.Methods
{
    public class Mocky : IMocky
    {
        public string GetMocky(string url)
        {
           using (WebClient wc = new WebClient())
           {
               byte[] raw = wc.DownloadData(url);
               string webData = System.Text.Encoding.UTF8.GetString(raw);
               return webData;
           } 
        }
    }
}
