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
    /// Logique d'interaction pour creer_travail.xaml
    /// </summary>
    public partial class MenuJob : Page
    {
        private List<Group> GroupList;
        public MenuJob()
        {
            InitializeComponent();

            GroupList = new List<Group>();
            TaskData[] l = LogAndStateTool.getTasks();

            for (int i = 0; i < l.Length; i++)
            {
                GroupList.Add(new Group
                {
                    Name = "Job n°" + (i+1),
                    Tests = new List<Test>
                    {
                        new Test { Name = "Name", Value = l[i].Name, Symbole = "" },
                        new Test { Name = "Source file path", Value = l[i].SourceFilePath, Symbole = "" },
                        new Test { Name = "Target file path", Value = l[i].TargetFilePath, Symbole = "" },
                        new Test { Name = "State", Value = l[i].State, Symbole = "" },
                        new Test { Name = "Total file to copy",Value = l[i].TotalFilesToCopy.ToString(), Symbole = "" },
                        new Test { Name = "Total file size",Value = l[i].TotalFilesSize.ToString(), Symbole = "o" },
                        new Test { Name = "Number Files left to do",Value = l[i].NbFilesLeftToDo.ToString(), Symbole = "" },
                        new Test { Name = "Progression", Value = l[i].Progression.ToString(), Symbole = "%" }
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
        
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            LogAndStateTool.deleteLocation(GetIndexFromButton(btn));
            Refresh();
        }
        

        private int GetIndexFromButton(Button btn)
        {
            Test test = btn.CommandParameter as Test;
            Group group = btn.DataContext as Group;
            return GroupList.IndexOf(group);
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
        public string Symbole { get; set; }
    }

}
