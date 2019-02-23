using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingNewsWPF.BLL
{
    public interface IWebCalculator
    {
        /// <summary>
        /// Calculates the number of occurences for given keyword in html code.
        /// Takes a IWebCollector as a parameter
        /// Returns -1 if param webcoll is NULL or Webcoll.Htmlcode property is
        /// NULL/empty or if the keyword is NULL/empty
        /// </summary>
        int CalculateNumberOfHits(IWebCollector webColl, string keyword);
    }
}
