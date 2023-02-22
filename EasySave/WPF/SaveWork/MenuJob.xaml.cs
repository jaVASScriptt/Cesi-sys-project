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

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour creer_travail.xaml
    /// </summary>
    public partial class MenuJob : Page
    {
        public MenuJob()
        {
            InitializeComponent();
            title_job_menu.Text = LanguageTool.get("title_job_menu");
            add_job_button.Content = LanguageTool.get("add_job_button");
            del_job_button.Content = LanguageTool.get("del_job_button");

            List<Group> GroupList = new List<Group>();
            TaskData[] l = LogAndStateTool.getTasks();

            for (int i = 0; i<l.Length; i++)
            {
                GroupList.Add(new Group
                 {
                     Name = LanguageTool.get("job_number") + i,
                     Tests = new List<Test>
                     {
                         new Test { Name = LanguageTool.get("job_name"), Value = l[i].Name, Symbole = "" },
                         new Test { Name = LanguageTool.get("source_path_job"), Value = l[i].SourceFilePath, Symbole = "" },
                         new Test { Name = LanguageTool.get("target_path_job"), Value = l[i].TargetFilePath, Symbole = "" },
                         new Test { Name = LanguageTool.get("state"), Value = l[i].State, Symbole = "" },
                         new Test { Name = LanguageTool.get("total_file"), Value = l[i].TotalFilesToCopy.ToString(), Symbole = "" },
                         new Test { Name = LanguageTool.get("file_size"), Value = l[i].TotalFilesSize.ToString(), Symbole = "o" },
                         new Test { Name = LanguageTool.get("nb_file_left"), Value = l[i].NbFilesLeftToDo.ToString(), Symbole = "" },
                         new Test { Name = LanguageTool.get("progression"), Value = l[i].Progression.ToString(), Symbole = "%" }
                     }
                 });
            }

            DataContext = GroupList;
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
