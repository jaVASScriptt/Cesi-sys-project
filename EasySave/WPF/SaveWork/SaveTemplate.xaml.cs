using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour save_rapide.xaml
    /// </summary>
    public partial class SaveTemplate : Page
    {
        public string TypeSave = "Complete";
        
        public SaveTemplate()
        {
            InitializeComponent();
            
            SaveName.Text = LanguageTool.get("save_name");
            SourcePath.Text = LanguageTool.get("source_path");
            TargetPath.Text = LanguageTool.get("destination_path");
            SaveType.Text = LanguageTool.get("save_type");
            Complete.Content = LanguageTool.get("complete");
            Differential.Content = LanguageTool.get("differential");
           

            Complete.BorderBrush = Brushes.White;
        }
        
        private void CompleteSelect(object sender, RoutedEventArgs e)
        {
            TypeSave = "Complete";
            Complete.BorderBrush = Brushes.White;
            Differential.BorderBrush = null;
        }
        
        private void DifferentialSelect(object sender, RoutedEventArgs e)
        {
            TypeSave = "Differential";
            Differential.BorderBrush = Brushes.White;
            Complete.BorderBrush = null;
        }
    }
}
