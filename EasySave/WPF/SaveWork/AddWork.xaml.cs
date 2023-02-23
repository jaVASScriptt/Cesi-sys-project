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
using EasySafe;
using EasySave;

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour Do_save.xaml
    /// </summary>
    public partial class AddWork : Page
    {
        private SaveTemplate s = new SaveTemplate();
        public AddWork()
        {
            InitializeComponent();
            SaveInfo.Content = s;
            SaveAddTitle.Text = LanguageTool.get("add_save_title");
            ValidateButton.Content = LanguageTool.get("add_save_button");
        }
        
        private void BtnClickAddSave(object sender, RoutedEventArgs e)
        {
            LogAndStateTool.addNewTask(s.SaveNameEntry.Text, s.SourcePathEntry.Text, s.TargetPathEntry.Text, s.TypeSave);
            MainWindow.MainFrame.Content = new MenuJob();
        }
        
        private void BtnClickMenu(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new MenuJob();
        }
        
    }
}
