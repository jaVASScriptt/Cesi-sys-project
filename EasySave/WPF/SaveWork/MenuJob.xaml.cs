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
        
        private void doSave(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid grid = FindParentGrid(btn);
            TextBlock saveAnnouncement = (TextBlock)grid.FindName("SaveAnnouncement");
            ProgressBar progressBar = (ProgressBar)grid.FindName("SaveProgress");
            TextBlock saveProgress = (TextBlock)grid.FindName("Percent");
            int index = GetIndexFromButton(btn);
            TaskData task = LogAndStateTool.getTask(index);
            FactorySave.GetSave(task.Name, 
                task.SourceFilePath, 
                task.TargetFilePath, 
                task.Type == "complete"? "Complete" : "Differential")?.saveData(index);
        }

        private Grid FindParentGrid(FrameworkElement element)
        {
            FrameworkElement parent = element.Parent as FrameworkElement;
            while (parent != null && !(parent is Grid))
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent as Grid;
        }
        
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            LogAndStateTool.deleteLocation(GetIndexFromButton(btn));
            Refresh();
        }

        private void Add_job_button_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new AddWork();
        }

        private void editSave(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new EditWork(GetIndexFromButton(sender as Button));
        }

        private void setAddTool(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.ToolTip = LanguageTool.get("AddJobTooltip");
        }
        
        private void setEditTool(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.ToolTip = LanguageTool.get("EditJobTooltip");
        }
        
        private void setDelTool(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.ToolTip = LanguageTool.get("DelJobTooltip");
        }
        
    }

    public class Group
    {
        public string Name { get; set; }
        public List<Test> Tests { get; set; }
    }
    
    public class Progress
    {
        public TextBlock Announcement { get; set; }
        public ProgressBar Progression { get; set; }
        public TextBlock ProgressionText { get; set; }
    }

    public class Test
    {
        public string Name { get; set; }
        public string Value { get; set; }
        
    }

}
