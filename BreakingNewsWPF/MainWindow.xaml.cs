using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BreakingNewsWPF.BLL;
using BreakingNewsWPF.DAL;

namespace BreakingNewsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string keyword { get; set; }
        public string site { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            resultBox.Text = "Please Wait..";
            if (keyword != null && site != null)
            {
                WebCollector wc = new WebCollector();
            WebCalculator wb = new WebCalculator();

            //Ascync!
            await wc.GetHTMLFromUrl(site);

            var tempSite = wc.HtmlCode;
            int result = wb.CalculateNumberOfHits(wc, keyword);

            resultBox.Text = result.ToString();
            }

            else
            {
                MessageBox.Show("Choose Keyword And Site");
            }
        }

        private void KeywordRadio_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            keyword = button.Content.ToString().ToLowerInvariant();
        }

        private void SiteRadio_Checked(object sender, RoutedEventArgs e)
        {
            string tempSite;
            var button = sender as RadioButton;

            tempSite = button.Content.ToString();
            try
            {
                switch (tempSite)
                {
                    case "Aftonbladet":
                        site = "https://www.aftonbladet.se/";
                        break;
                    case "Expressen":
                        site = "https://www.expressen.se/";
                        break;
                    case "Dagens Nyheter":
                        site = "https://www.dn.se/";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }

    }
}
