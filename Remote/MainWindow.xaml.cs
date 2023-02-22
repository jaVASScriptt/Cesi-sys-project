using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace Remote
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Socket server;

        // connexion au moment du lancement de la page
        public MainWindow()
        {
            InitializeComponent();

            //Création du point de communication avec adresse IP locale et un numéro de port
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1050);

            // Création du socket pour se connecter au serveur
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Demande de connexion au serveur
            server.Connect(ipep);

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lb_titre.Content = "Progression de la fabrication :";
            // Création d'un timer pour l'actualisation automatique
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            //Déclaration d'un buffer de type byte pour enregistrer les données reçues
            byte[] data = new byte[128];

            //appel de la méthode receive qui reçoit les données envoyées par le serveur et les stocker 
            //dans le tableau data, elle renvoie le nombre d'octet reçus
            try
            {
                int recv = server.Receive(data);
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception.Message);
            }


            //transcodage de data en string
            String mg = (Encoding.UTF8.GetString(data));
            lb_etat_prog_client.Content = mg;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            server.Shutdown(SocketShutdown.Both);

            server.Close();
        }
    }

}
