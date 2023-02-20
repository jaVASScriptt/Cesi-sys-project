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
using EasySave;

namespace app_locale
{
    /// <summary>
    /// Logique d'interaction pour menu_general.xam
    public partial class menu_general : Page
    {
        public menu_general()
        {
            InitializeComponent();
        }
        
        private void BtnAccueil(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnClickLanguage(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new choix_langue();
        }

        private void BtnClickMenu(object sender, RoutedEventArgs e)
        {
           
        }
        
        private void BtnClickExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
