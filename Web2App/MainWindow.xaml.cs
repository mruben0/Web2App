using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Web2App.Framework.ViewModels;

namespace Web2App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                vm.Initialize();
            }
        }

    }
}
