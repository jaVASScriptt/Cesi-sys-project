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

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour menu_general.xam
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void BtnClickLanguage(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new ChoiceLanguage();
        }
        
        private void BtnClickLogsAndState(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new ChoiceLog();
        }

        private void BtnClickSave(object sender, RoutedEventArgs e)
        {
           MainWindow.MainFrame.Content = new ChoiceSave();
        }
        
    }
}
