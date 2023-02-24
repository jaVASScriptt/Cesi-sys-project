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
using EasySave.Features.Language;
using EasySave.Features.LogAndState.Data;
using EasySave.Features.LogAndState.Tools;

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour Do_save.xaml
    /// </summary>
    public partial class EditWork : Page
    {
        private SaveTemplate s = new SaveTemplate();
        private int index;
        
        public EditWork(int i)
        {
            InitializeComponent();
            SaveInfo.Content = s;
            index = i;
            TaskData t = LogAndStateTool.getTask(i);
            SaveAddTitle.Text = LanguageTool.Get("edit_save_title");
            ValidateButton.Content = LanguageTool.Get("edit_save_button");
            s.SaveNameEntry.Text = t.Name;
            s.SourcePathEntry.Text = t.SourceFilePath;
            s.TargetPathEntry.Text = t.TargetFilePath;
            s.TypeSave = t.Type;
        }
        
        private void BtnClickAddSave(object sender, RoutedEventArgs e)
        {
            LogAndStateTool.setTask(index, s.SaveNameEntry.Text, s.SourcePathEntry.Text, s.TargetPathEntry.Text, Type: s.TypeSave);
            MainWindow.MainFrame.Content = new MenuJob();
        }
        
        private void BtnClickMenu(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new MenuJob();
        }
        
    }
}
