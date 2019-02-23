using BreakingNewsWPF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BreakingNewsWPF.DAL.Tests
{
    [TestFixture]
    public class WebCollectorTests
    {
        [Test]
        public  async Task GetHTMLFromUrlTestWithNull()
        {           
          var wc = new WebCollector();
          await wc.GetHTMLFromUrl(null);
          var result = wc.HtmlCode;

            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetHTMLFromUrlTestWithEmptyString()
        {           
          var wc = new WebCollector();
          await wc.GetHTMLFromUrl(string.Empty);
          var result = wc.HtmlCode;

            Assert.IsEmpty(result); ;
        }

        [Test]
        public async Task GetHTMLFromUrlTestWithNoHTTP()
        {           
          var wc = new WebCollector();
          await wc.GetHTMLFromUrl("www.aftonbladet.se");
          var result = wc.HtmlCode;

            Assert.IsEmpty(result);
        }

        [Test]
        public  async Task GetHTMLFromUrlTestValidURL()
        {           
          var wc = new WebCollector();
          await wc.GetHTMLFromUrl("https://www.aftonbladet.se/");
          var result = wc.HtmlCode;

          Assert.IsNotEmpty(result);
  
        }
    }
}