using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Web2App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebAppDataService _dataService;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            _dataService = new WebAppDataService();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(UriBox.Text);
            var browserWindow = new Browser(uri,false);
            browserWindow.Show();
        }

        private void AddToSettings_Click(object sender, RoutedEventArgs e)
        {
            _dataService.Add(new WebAppData() { Url = new Uri(UriBox.Text) });
            Apps.ItemsSource = _dataService.Get();
        }

        private void Launch_Desktop(object sender, RoutedEventArgs e)
        {
            var uri = (sender as Button).Tag as Uri;
            var browserWindow = new Browser(uri, false);
            browserWindow.Show();
        }

        private void Launch_Mobile(object sender, RoutedEventArgs e)
        {
            var uri = (sender as Button).Tag as Uri;
            var browserWindow = new Browser(uri,true);
            browserWindow.Show();
        }

        private void Delete_Url(object sender, RoutedEventArgs e)
        {
            var uri = (sender as Button).Tag as Uri;
            _dataService.Remove(uri);
            UpdateDataService();
        }

        private void UpdateDataService()
        {
            Apps.ItemsSource = _dataService.Get();
        }

        private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }
    }
}
