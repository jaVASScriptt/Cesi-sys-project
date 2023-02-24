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

namespace EasySave
{
    /// <summary>
    /// Logique d'interaction pour settings.xaml
    /// </summary>
    public partial class SaveSettings : Page
    {
        
        public SaveSettings()
        {
            InitializeComponent();
            SettingsTitle.Text = LanguageTool.get("SettingsTitle");
            Log_JobPath.Text = LanguageTool.get("Log_JobPath");
            ChooseSoftBusiness.Text = LanguageTool.get("ChooseSoftBusiness");
            ExtensionPriority.Text = LanguageTool.get("ExtensionPriority");
            MaxSize.Text = LanguageTool.get("MaxSize");
            EncryptExtension.Text = LanguageTool.get("EncryptExtension");
            Cryptosoftpath.Text = LanguageTool.get("Cryptosoftpath");
            EncryptKey.Text = LanguageTool.get("EncryptKey");
            ApplyChanges_button.Content = LanguageTool.get("ApplyChanges_button");
            search.Content = LanguageTool.get("search");
            search1.Content = LanguageTool.get("search");
            
            
            ExtensionPEncryptList.Items.Add(".txt");
            
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
        }

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

        public String[] GetListBoxItems()
        {
            List<string> items = new List<string>();

            foreach (string item in ExtensionPEncryptList.Items)
            {
                items.Add(item);
            }

            return items.ToArray();
        }
        
        private void ApplyAllChangeClick(object sender, RoutedEventArgs e)
        {
            //EXTENSION PRIORITY
            string fileTypesText = ExtensionPriorityList.Text;
            if (!string.IsNullOrWhiteSpace(fileTypesText))
            {
                List<string> fileTypesList = fileTypesText.Split(',').Select(s => s.Trim()).ToList();
                foreach (string fileType in fileTypesList)
                {
                    ExtensionPEncryptList.Items.Add(fileType);
                }
                //ExtensionPriorityList.Clear();
            }

            //BUSINESS SOFTWARE 
            string softwareName = Choicesoftbox.SelectedItem.ToString(); // Récupérer le nom du processus depuis la combobox

                while (true)
                {
                    Process[] processes = Process.GetProcessesByName(softwareName);

                    if (processes.Length > 0)
                    {
                        Console.WriteLine("Le logiciel est en cours d'exécution. La sauvegarde suivante est mise en pause.");
                        // Ajouter ici le code pour mettre en pause la sauvegarde suivante

                        foreach (Process process in processes)
                        {
                            process.WaitForExit();
                        }

                        Console.WriteLine("Le logiciel s'est terminé. La sauvegarde suivante peut être reprise.");
                        // Ajouter ici le code pour reprendre la sauvegarde suivante
                    }
                    //temps d'attente avant nouvelle vérification d'exécution du processus
                    System.Threading.Thread.Sleep(5000);
                }
            
        }
        
    }   
}
