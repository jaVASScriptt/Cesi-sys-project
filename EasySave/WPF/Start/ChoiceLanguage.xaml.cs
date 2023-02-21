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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasySave;

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour choix_langue.xaml
    /// </summary>
    public partial class ChoiceLanguage : Page
    {
        public ChoiceLanguage()
        {
            InitializeComponent();
            TitleLang.Text = LanguageTool.get("language");
        }

        private void French(object sender, RoutedEventArgs e)
        {
            LanguageTool.setLanguage(1);
            TitleLang.Text = LanguageTool.get("language");
        }

        private void English(object sender, RoutedEventArgs e)
        {
            LanguageTool.setLanguage(2);
            TitleLang.Text = LanguageTool.get("language");
        }
    }
}
