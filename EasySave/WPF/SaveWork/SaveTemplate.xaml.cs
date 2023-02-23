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
using System.Windows.Forms;

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
        private void BrowserClickSource(object sender, RoutedEventArgs e)
        {
            // Créez une instance de la boîte de dialogue de sélection de dossiers
            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            // Définissez les propriétés de la boîte de dialogue
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = @"C:\";
            folderBrowserDialog.Description = "Sélectionnez un dossier";

            // Affichez la boîte de dialogue et récupérez le résultat
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) // Si l'utilisateur a sélectionné un dossier
            {
                string selectedFolderPath = folderBrowserDialog.SelectedPath; // Chemin du dossier sélectionné
                                                                              // Faites quelque chose avec le dossier sélectionné
                                                                              // Par exemple, affichez le chemin du dossier dans une zone de texte
                SourcePathEntry.Text = selectedFolderPath;
            }
        }

        private void BrowserClickTarget(object sender, RoutedEventArgs e)
        {
            // Créez une instance de la boîte de dialogue de sélection de dossiers
            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            // Définissez les propriétés de la boîte de dialogue
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = @"C:\";
            folderBrowserDialog.Description = "Sélectionnez un dossier";

            // Affichez la boîte de dialogue et récupérez le résultat
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) // Si l'utilisateur a sélectionné un dossier
            {
                string selectedFolderPath = folderBrowserDialog.SelectedPath; // Chemin du dossier sélectionné
                                                                              // Faites quelque chose avec le dossier sélectionné
                                                                              // Par exemple, affichez le chemin du dossier dans une zone de texte
                TargetPathEntry.Text = selectedFolderPath;
            }
        }

        private void SourcePathEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TargetPathEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
