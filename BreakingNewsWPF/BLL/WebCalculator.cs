using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BreakingNewsWPF.BLL
{
   public class WebCalculator :IWebCalculator
   {

        public int CalculateNumberOfHits(IWebCollector webColl, string keyword)
        {
            if (keyword != null && webColl != null && webColl.HtmlCode != string.Empty) {
                try
                {
                    var text = webColl.HtmlCode;
                    var query = keyword;
                    int result = Regex.Matches(text, keyword).Count;

                    return result;
                }
                catch (Exception )
                {
                    return -1;
                }
          
            }
            else
            {
                return -1;
            }
        }
        
    }
}
