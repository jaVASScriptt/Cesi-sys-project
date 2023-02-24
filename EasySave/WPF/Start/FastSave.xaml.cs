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
using EasySave.Features.Language;

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour save_rapide.xaml
    /// </summary>
    public partial class FastSave : Page
    {
        private SaveTemplate s = new SaveTemplate();
        public FastSave()
        {
            InitializeComponent();
            
            SaveInfo.Content = s;
            SaveFastTitle.Text = LanguageTool.Get("save_fast_title");
            ValidateButton.Content = LanguageTool.Get("validate_button");
        }
        
        private void BtnClickSave(object sender, RoutedEventArgs e)
        {
            FactorySave.GetSave(s.SaveNameEntry.Text, s.SourcePathEntry.Text, s.TargetPathEntry.Text, s.TypeSave)?.saveData();
        }
        
    }
}
