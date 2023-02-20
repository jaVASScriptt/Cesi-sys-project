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

namespace app_locale
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnClickCreer(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("WPF/creer_travail.xaml", UriKind.Relative));
        }

        private void BtnClickModifier(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("WPF/modifier sauvegarde.xaml", UriKind.Relative));
        }

        private void BtnClickSupprimerUnTravail(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("WPF/supprimer_1_travail.xaml", UriKind.Relative));
        }

        private void BtnClickSupprimerToutTravaux(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("WPF/supprimer_tout_travaux.xaml", UriKind.Relative));
        }

        private void BtnClickEffectuer(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("WPF/Do_save.xaml", UriKind.Relative));
        }

        private void BtnClickAjoutEmplacement(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("WPF/add_save_slot.xaml", UriKind.Relative));
        }

        private void BtnClickRetirer(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("WPF/suppr_save_slot.xaml", UriKind.Relative));
        }
    }
}
