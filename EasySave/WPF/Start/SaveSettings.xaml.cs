using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using EasySave.Features.Language;
using EasySave.Features.LogAndState.Tools;

namespace EasySave
{

    

    public partial class SaveSettings : Page
    {
        
        public SaveSettings()
        {
            InitializeComponent();
            SettingsTitle.Text = LanguageTool.Get("SettingsTitle");
            Log_JobPath.Text = LanguageTool.Get("Log_JobPath");
            ChooseSoftBusiness.Text = LanguageTool.Get("ChooseSoftBusiness");
            ExtensionPriority.Text = LanguageTool.Get("ExtensionPriority");
            MaxSize.Text = LanguageTool.Get("MaxSize");
            EncryptExtension.Text = LanguageTool.Get("EncryptExtension");
            //Cryptosoftpath.Text = LanguageTool.get("Cryptosoftpath");
            EncryptKey.Text = LanguageTool.Get("EncryptKey");
            ApplyChanges_button.Content = LanguageTool.Get("ApplyChanges_button");
            search.Content = LanguageTool.Get("search");
            //search1.Content = LanguageTool.get("search");

            EncryptKeyInput.Text = SaveTool.getKey();
            foreach (var x in SaveTool.getFilesToCrypt())
            {
                ExtensionPEncryptList.Items.Add(x);
            }

        }

        private void BrowserLogJobPathClick(object sender, RoutedEventArgs e)
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
                Log_JobInputPath.Text = selectedFolderPath;
            }

        }
        /*
        private void BrowserLogJobPathClick1(object sender, RoutedEventArgs e)
        {
            //instance de la boîte de dialogue de sélection de dossiers
            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            //propriétés de la boîte de dialogue
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = @"C:\";
            folderBrowserDialog.Description = "Sélectionnez un dossier";

            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) // Si l'utilisateur a sélectionné un dossier
            {
                string selectedFolderPath = folderBrowserDialog.SelectedPath; // Chemin du dossier sélectionné

                CryptosoftpathInput.Text = selectedFolderPath;
            }
        }*/

        private void AddExtensionButton_Click(object sender, RoutedEventArgs e)
        {
            string newExtension = NewExtensionTextBox.Text;
            ExtensionPEncryptList.Items.Add(newExtension);
        }

        private void DeleteExtensionButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string extension = (string)button.DataContext;
            ExtensionPEncryptList.Items.Remove(extension);
        }

        public void updateList()
        {
            List<string> items = new List<string>();

            foreach (string item in ExtensionPEncryptList.Items)
            {
                items.Add(item);
            }

            SaveTool.setFilesToCrypt(items.ToArray());
        }
        
        private void setLogAndStatePath()
        {
            string NewPath = Log_JobInputPath.Text;
            LogAndStateTool.changePath(NewPath);
        }

        private void ApplyAllChangeClick(object sender, RoutedEventArgs e)
        {
            updateList();
            setLogAndStatePath();
            SaveTool.setKey(EncryptKeyInput.Text);
        }

    }
}