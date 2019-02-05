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
using CefSharp;
using CefSharp.Wpf;

namespace BigFramework.ThickClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChromiumWebBrowser _browser;

        public MainWindow()
        {
            InitializeComponent();
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            _browser = new ChromiumWebBrowser();
            _browser.BrowserSettings.WebSecurity = CefState.Disabled;
            _browser.Address = "http://localhost:4200/";
            WebBrowserContainer.Content = _browser;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            firstname.Clear();
            LastName.Clear();
        }
    }
}
