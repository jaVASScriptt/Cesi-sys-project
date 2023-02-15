using Prog.Sys___Workshop_1_v2.ViewModel;
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

namespace Prog.Sys___Workshop_1_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UpperModelView modelView = new UpperModelView();

        public MainWindow()
        {
            //UpperModelView modelView = new UpperModelView(); -> à ne pas mettre ici car les autres méthodes ont besoin de cette variable
            InitializeComponent();
            DataContext = modelView;
        }

        private void validation_text_Click(object sender, RoutedEventArgs e)
        {
            string str = modelView.flexSomeUppercase(input_text.Text);
            //string str = modelView.flexSomeUppercase(result_label_mvvm.Content.ToString());
            result_label.Content = str;
        }

        private void info_button_Click(object sender, RoutedEventArgs e)
        {
            info_label.Content = modelView.messageServer();
        }

        private void validation_text_Drop(object sender, DragEventArgs e)
        {

        }
    }
}
