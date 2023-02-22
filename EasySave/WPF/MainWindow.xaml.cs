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
using Easysave;

namespace EasySave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MainFrame { get; set; }
        public static Button saveButtonAccess { get; set; }
        public static Button LanguageButtonAccess { get; set; }
        public static Button SettingButtonAccess { get; set; }

        public MainWindow()
        {
            LanguageTool.setLanguage(2);
            InitializeComponent();
            MainFrame = Main;
            saveButtonAccess = SaveButton;
            LanguageButtonAccess = LangageButton;
            SettingButtonAccess = settingButton;

            Main.Content = new Home();
        }

        private void BtnClickExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void BtnClickHome(object sender, RoutedEventArgs e)
        {
            Main.Content = new Home();
        }
        
        private void BtnClickLanguage(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new ChoiceLanguage();
        }
        
        private void BtnClickLogsAndState(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new ChoiceLog();
        }

        private void BtnClickSave(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Content = new ChoiceSave();
        }
    }
}