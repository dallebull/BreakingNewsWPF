using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BreakingNewsWPF.BLL;

namespace BreakingNewsWPF.DAL
{
    public class WebCollector:IWebCollector
    {
        public string HtmlCode { get; set; }
        /// <summary>
        /// Returns html code for given string
        /// </summary>
        /// <param name="url"></param>
        /// 
        public async Task GetHTMLFromUrl(string url)
        {
            if (url != null) { 
            try
            {
                using (WebClient client = new WebClient())
                {
                   client.Encoding = Encoding.UTF8;
                   HtmlCode = await client.DownloadStringTaskAsync(url);                   
                }
            }
            catch
            {
                    HtmlCode = string.Empty;
            }
            }
            else
            {
                    HtmlCode = string.Empty;
            }
        }
    }
}
