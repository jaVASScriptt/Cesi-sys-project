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
using EasySave.Features.Language;
using EasySave.Features.LogAndState.Data;
using EasySave.Features.LogAndState.Tools;

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
            title_job_menu.Text = LanguageTool.Get("title_job_menu");
            add_job_button.Content = LanguageTool.Get("add_job_button");
            del_job_button.Content = LanguageTool.Get("del_job_button");

            GroupList = new List<Group>();

            GroupList = new List<Group>();
            TaskData[] l = LogAndStateTool.getTasks();

            for (int i = 0; i < l.Length; i++)
            {
                GroupList.Add(new Group
                 {
                     Name = LanguageTool.Get("job_number") + i,
                     Tests = new List<Test>
                     {
                         new Test { Name = LanguageTool.Get("job_name"), Value = l[i].Name},
                         new Test { Name = LanguageTool.Get("source_path_job"), Value = l[i].SourceFilePath },
                         new Test { Name = LanguageTool.Get("target_path_job"), Value = l[i].TargetFilePath },
                         new Test { Name = LanguageTool.Get("type_job"), Value = l[i].Type },
                         new Test { Name = LanguageTool.Get("state"), Value = l[i].State },
                         new Test { Name = LanguageTool.Get("total_file"), Value = l[i].TotalFilesToCopy.ToString() },
                         new Test { Name = LanguageTool.Get("file_size"), Value = l[i].TotalFilesSize.ToString() },
                         new Test { Name = LanguageTool.Get("nb_file_left"), Value = l[i].NbFilesLeftToDo.ToString() },
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
            int buttonId = GetIndexFromButton(btn);
            Grid grid = FindParentGrid(btn);
            TextBlock saveAnnouncement = (TextBlock)grid.FindName("SaveAnnouncement");
            ProgressBar progressBar = (ProgressBar)grid.FindName("SaveProgress");
            TextBlock saveProgress = (TextBlock)grid.FindName("Percent");
            Image Button2Image = (Image)grid.FindName("Button2img");
            Image Button3Image = (Image)grid.FindName("Button3img");
            
            saveAnnouncement.Visibility = Visibility.Visible;
            saveAnnouncement.Text = LanguageTool.Get("saveAnnouncement");
            progressBar.Visibility = Visibility.Visible;
            saveProgress.Visibility = Visibility.Visible;
            
            Button2Image.Source = new BitmapImage(new Uri("../Images/pause.png", UriKind.Relative));
            Button3Image.Source = new BitmapImage(new Uri("../Images/carre_rouge.png", UriKind.Relative));

            TaskData task = LogAndStateTool.getTask(buttonId);
            ISave sauvegarde = FactorySave.GetSave(task.Name, task.SourceFilePath, task.TargetFilePath, (task.Type == "Complete") ? "Complete" : "Differential");
            Thread ezSave = new Thread(() => sauvegarde.saveData(buttonId));
            ezSave.Start();
            do
            {
                task = LogAndStateTool.getTask(buttonId);
                progressBar.Value = task.Progression;
                saveProgress.Text = task.Progression + "%";
            } while (task.State == "RUNNING");

            Task.Delay(3000);
            progressBar.Value = 100;
            saveProgress.Text = 100 + "%";
            saveAnnouncement.Text = LanguageTool.Get("saveAnnouncementEnd");
            
            Button2Image.Source = new BitmapImage(new Uri("../Images/edit.png", UriKind.Relative));
            Button3Image.Source = new BitmapImage(new Uri("../Images/del.png", UriKind.Relative));
            
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
            btn.ToolTip = LanguageTool.Get("AddJobTooltip");
        }
        
        private void setEditTool(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.ToolTip = LanguageTool.Get("EditJobTooltip");
        }
        
        private void setDelTool(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.ToolTip = LanguageTool.Get("DelJobTooltip");
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