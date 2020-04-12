using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Web2App
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    public partial class Browser : Window
    {
        private Uri _uri;
        private readonly bool isMobileView;

        public Browser(Uri uri, bool isMobileView)
        {
            InitializeComponent();
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));
            this.isMobileView = isMobileView;
            Loaded += Browser_Loaded;
        }

        private void Browser_Loaded(object sender, RoutedEventArgs e)
        {
            if (isMobileView)
            {
                Width = 500;
                bro.Navigate(_uri, new HttpMethod("GET"), string.Empty, new Dictionary<string, string> { { "User-Agent", "Mozilla/5.0 (Linux; Android 7.0; SM-G930V Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.125 Mobile Safari/537.36" } });
            }
            else
            {
                bro.Navigate(_uri);
            }
        }
    }
}
