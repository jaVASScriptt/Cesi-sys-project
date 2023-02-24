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
            Search.Content = LanguageTool.get("search");
            Search2.Content = LanguageTool.get("search");
           

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
        
        private void searchClick1(object sender, RoutedEventArgs e)
        {
            SearchMethod(1);
        }
        
        private void searchClick2(object sender, RoutedEventArgs e)
        {
            SearchMethod(2);
        }

        private void SearchMethod(int i)
        {
            // Créer une instance de la boîte de dialogue pour parcourir les fichiers et les dossiers
            var dialog = new Microsoft.Win32.OpenFileDialog();

            // Définir les options de la boîte de dialogue
            dialog.Title = "Sélectionnez un fichier ou un dossier";
            dialog.Multiselect = false;
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;

            // Afficher la boîte de dialogue
            bool? result = dialog.ShowDialog();

            // Si l'utilisateur a sélectionné un fichier ou un dossier, récupérer le chemin et l'afficher dans la zone de texte appropriée
            if (result == true)
            {
                string path = dialog.FileName;
                if (i == 1)
                    SourcePathEntry.Text = path;
                else
                    TargetPathEntry.Text = path;
            }
        }

    }
}
