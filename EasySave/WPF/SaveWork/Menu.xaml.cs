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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CreateJob(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new CreateJob();
        }


        private void ModifySave(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new ModifySave();
        }

        private void DelOneJob(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new DelOneJob();
        }

        private void DelAllJob(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new DelAllJob();
        }


        private void DoSave(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new DoSave();
        }

        private void AddOrRemoveSlot(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new EditSaveSlot();
        }
    }
}
