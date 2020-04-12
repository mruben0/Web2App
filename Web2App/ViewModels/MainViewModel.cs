using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Web2App.Framework.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _newUri;
        private readonly WebAppDataService webAppDataService;
        private bool cancelled;
        public MainViewModel(WebAppDataService webAppDataService)
        {
            WebSites = new ObservableCollection<WebAppData>();

            this.webAppDataService = webAppDataService ?? throw new ArgumentNullException(nameof(webAppDataService));
        }

        public void Initialize()
        {
            var data = webAppDataService.Get();
            WebSites = new ObservableCollection<WebAppData>(data);
            RaisePropertyChanged(nameof(WebSites));
        }

        public ObservableCollection<WebAppData> WebSites { get; set; }

        public string NewUri
        {
            get { return _newUri; }
            set
            {
                _newUri = value;
                RaisePropertyChanged(nameof(NewUri));
            }
        }


        public ICommand CancelCommand => new RelayCommand(() =>
        {
            cancelled = true;
        });       
        
        public ICommand AddCommand => new RelayCommand(() =>
        {
            if (!cancelled && !string.IsNullOrEmpty(NewUri))
            {
                WebSites.Add(new WebAppData(NewUri));
                webAppDataService.Add(new WebAppData(NewUri));
            }
            NewUri = string.Empty;
            cancelled = false;
        });

        public ICommand BrowseCommand => new RelayCommand<Uri>((uri) =>
        {
            var browserWindow = new Browser(uri, false);
            browserWindow.Show();
        });
        public ICommand BrowseAsMobileCommand => new RelayCommand<Uri>((uri) =>
        {
            var browserWindow = new Browser(uri, true);
            browserWindow.Show();
        });

        public ICommand RemoveUrlCommand => new RelayCommand<Uri>((uri) =>
        {
            webAppDataService.Remove(uri);
            WebSites.Remove(WebSites.First(e => e.Url == uri));
        });
    }
}