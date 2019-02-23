
using BreakingNewsWPF.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreakingNewsWPF.DAL;
using Moq;
using NUnit.Framework;


namespace BreakingNewsWPF.BLL.Tests
{
    [TestFixture]
    public class WebCalculatorTests
    {
        [Test]
        public void CalculateNumberOfHitsTestwebCollNULL()
        {
            WebCalculator wc = new WebCalculator();
            int result = wc.CalculateNumberOfHits(null,"bostad");
            if (result != -1)
            {
                Assert.Fail();
            }
        }
        [Test]
        public  void CalculateNumberOfHitsTestHTTPNull()
        {
            var wb = new WebCollector();
             wb.GetHTMLFromUrl("");

            WebCalculator wc = new WebCalculator();
            if (wb.HtmlCode == null)
            {
                int result = wc.CalculateNumberOfHits(wb, "polis");
                if (result != -1)
                {
                    Assert.Fail();
                }
            }
         
        }

        [Test]
        public void CalculateNumberOfHitsTestHTTPEmpty()
        {
            var emtpyHttp = new Mock<IWebCollector>();
            emtpyHttp.Setup(m => m.HtmlCode).Returns(string.Empty);
                              
            WebCalculator wc = new WebCalculator();
            int result = wc.CalculateNumberOfHits(emtpyHttp.Object, "polis");
            if (result != -1)
            {
                Assert.Fail();
            }
        }

        [Test]
        public  void CalculateNumberOfHitsTestKeywordNull()
        {
            var wb = new WebCollector();
             wb.GetHTMLFromUrl("https://www.aftonbladet.se/");
     
            WebCalculator wc = new WebCalculator();
            int result = wc.CalculateNumberOfHits(wb, null);
            if (result != -1)
            {
               Assert.Fail();
            }
        }
        [Test]
        public  void CalculateNumberOfHitsTestKeywordEmpty()
        {
            var wb = new WebCollector();
             wb.GetHTMLFromUrl("https://www.aftonbladet.se/");

            WebCalculator wc = new WebCalculator();
            int result = wc.CalculateNumberOfHits(wb, string.Empty);
            if (result != -1)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CalculateNumberOfHitsValid()
        {

            var polismock = new Mock<IWebCollector>();
            polismock.Setup(m => m.HtmlCode).Returns("polispolispolis");

            WebCalculator wc = new WebCalculator();
            int result = wc.CalculateNumberOfHits(polismock.Object, "polis");
            Assert.AreEqual(3, result);
   
        }

    }
}