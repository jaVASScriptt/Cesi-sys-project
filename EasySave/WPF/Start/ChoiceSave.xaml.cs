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
using EasySave.Features.Language;

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour choix_save.xaml
    /// </summary>
    public partial class ChoiceSave : Page
    {
        public ChoiceSave()
        {
            InitializeComponent();
            save_choice.Text = LanguageTool.Get("save_choice");
            fast_save_button.Content = LanguageTool.Get("fast_save_button");
            job_save_button.Content = LanguageTool.Get("job_save_button");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FastSave(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new FastSave();
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new MenuJob();
        }
    }
}
