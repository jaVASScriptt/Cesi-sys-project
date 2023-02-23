using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Controler;
using EasySafe;
using EasySave;

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour creer_travail.xaml
    /// </summary>
    public partial class MenuJob : Page
    {
        private List<Group> GroupList;
        public MenuJob()
        {
            InitializeComponent();
            title_job_menu.Text = LanguageTool.get("title_job_menu");
            add_job_button.Content = LanguageTool.get("add_job_button");
            del_job_button.Content = LanguageTool.get("del_job_button");

            GroupList = new List<Group>();

            GroupList = new List<Group>();
            TaskData[] l = LogAndStateTool.getTasks();

            for (int i = 0; i < l.Length; i++)
            {
                GroupList.Add(new Group
                 {
                     Name = LanguageTool.get("job_number") + i,
                     Tests = new List<Test>
                     {
                         new Test { Name = LanguageTool.get("job_name"), Value = l[i].Name},
                         new Test { Name = LanguageTool.get("source_path_job"), Value = l[i].SourceFilePath },
                         new Test { Name = LanguageTool.get("target_path_job"), Value = l[i].TargetFilePath },
                         new Test { Name = LanguageTool.get("type_job"), Value = l[i].Type },
                         new Test { Name = LanguageTool.get("state"), Value = l[i].State },
                         new Test { Name = LanguageTool.get("total_file"), Value = l[i].TotalFilesToCopy.ToString() },
                         new Test { Name = LanguageTool.get("file_size"), Value = l[i].TotalFilesSize.ToString() },
                         new Test { Name = LanguageTool.get("nb_file_left"), Value = l[i].NbFilesLeftToDo.ToString() },
                     }
                 });
            }

            DataContext = GroupList;
        }

        private void Refresh()
        {
            MainWindow.MainFrame.Content = new MenuJob();
        }

        private void DeleteAllJobs(object sender, RoutedEventArgs e)
        {
            LogAndStateTool.delAllSave();
            Refresh();
        }
        
        private int GetIndexFromButton(Button btn)
        {
            Test test = btn.CommandParameter as Test;
            Group group = btn.DataContext as Group;
            return GroupList.IndexOf(group);
        }
        
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            LogAndStateTool.deleteLocation(GetIndexFromButton(btn));
            Refresh();
        }

        private void doSave(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int buttonId = GetIndexFromButton(btn);
            TaskData task = LogAndStateTool.getTask(buttonId);
            ISave sauvegarde = FactorySave.GetSave(task.Name, task.SourceFilePath, task.TargetFilePath, (task.Type == "Complete") ? "Complete" : "Differential");
            Thread ezSave = new Thread(() => sauvegarde.saveData(buttonId));
            ezSave.Start();
            //t.Join();
            
        }

        /*
          public void PauseThread()
            {
                resetEvent.Reset();
            }

            public void ResumeThread()
            {
                resetEvent.Set();
            }
         */

        private void Add_job_button_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new AddWork();
        }

        private void editSave(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new EditWork(GetIndexFromButton(sender as Button));
        }
    }

    public class Group
    {
        public string Name { get; set; }
        public List<Test> Tests { get; set; }
    }

    public class Test
    {
        public string Name { get; set; }
        public string Value { get; set; }
        
    }

}
