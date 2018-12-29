using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TaskWebAPI.Repository
{
    public class MockyRepository : IMockyRepository
    {
        public string GetMocky()
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    byte[] raw = wc.DownloadData("http://www.mocky.io/v2/5c127054330000e133998f85");
                    string webData = System.Text.Encoding.UTF8.GetString(raw);
                    return webData;
                }
                catch (WebException webEx)
                {
                    return webEx.Status.ToString();
                }
            }
        }
    }
}
