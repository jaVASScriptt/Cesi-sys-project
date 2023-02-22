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
using Controler;

namespace Easysave
{
    /// <summary>
    /// Logique d'interaction pour save_rapide.xaml
    /// </summary>
    public partial class FastSave : Page
    {
        string TypeSave = "Complete";
        public FastSave()
        {
            InitializeComponent();
            CompleteButton.BorderBrush = Brushes.White;
        }
        
        private void BtnClickSave(object sender, RoutedEventArgs e)
        {
            FactorySave.GetSave(NameSave.Text, SourcePath.Text, TargetPath.Text, TypeSave)?.saveData();
        }

        private void Complete(object sender, RoutedEventArgs e)
        {
            TypeSave = "Complete";
            CompleteButton.BorderBrush = Brushes.White;
            DifferentialButton.BorderBrush = null;
        }
        
        private void Differential(object sender, RoutedEventArgs e)
        {
            TypeSave = "Differential";
            DifferentialButton.BorderBrush = Brushes.White;
            CompleteButton.BorderBrush = null;
        }
    }
}
