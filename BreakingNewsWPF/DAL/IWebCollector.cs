using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingNewsWPF.BLL
{
    public interface IWebCollector
    {
        /// <summary>
        /// Html code from last search
        /// </summary>
        string HtmlCode { get; set; }
        /// <summary>
        /// Pooulate the HtmlCode-property with html code from given URL.
        /// Sets the HtmlCode-property to string.Empty if url is NULL, empty or
        /// not containing "http".
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task GetHTMLFromUrl(string url);
    }
}
