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

namespace EasySave
{
    /// <summary>
    /// Logique d'interaction pour release_note.xaml
    /// </summary>
    public partial class ReleaseNote : Page
    {
        public ReleaseNote()
        {
            InitializeComponent();
            ReleaseTitle.Text = LanguageTool.get("ReleaseTitle");
            V1Text.Text = LanguageTool.get("V1Text");
            V1_1Text.Text = LanguageTool.get("V1_1Text");
            V2Text.Text = LanguageTool.get("V2Text");
            V3Text.Text = LanguageTool.get("V3Text");
        }
    }
}
