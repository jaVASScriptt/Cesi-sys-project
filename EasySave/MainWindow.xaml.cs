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
using app_locale;

namespace EasySave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void BtnAccueil(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }

        private void BtnClickLanguage(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new Uri("WPF/choix_langue.xaml", UriKind.Relative));
        }

        private void BtnClickMenu(object sender, RoutedEventArgs e)
        {
            Main.Content = new choix_save();
        }
        
        private void BtnClickExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}