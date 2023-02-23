using System.Windows;
using System.Windows.Controls;
using EasySafe;
using EasySave;

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
            SaveAddTitle.Text = LanguageTool.get("edit_save_title");
            ValidateButton.Content = LanguageTool.get("edit_save_button");
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
