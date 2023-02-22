using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EasySave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public static class Server
    {
        static Socket client;
        static Socket newsock;

        public static void ServerStart()
        {
            //Création du point de communication avec adresse IP locale et un numéro de port

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1050);

            // Création du socket d'écoute

            newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // relier le socket au point de communication
            newsock.Bind(ipep);

            //créer un nouveau thread qui écoute le réseau et accepte les demandes du client
            Thread t = new Thread(new ThreadStart(ecouterReseau));
            t.Start();


        }

        // Méthode qui initialise la barre de progression 
        static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 101; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);

                Thread.Sleep(200);

            }
        }

        static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            /*
            //initialisation de la barre de progression avec le pourcentage de progression
            pbstatus1.Value = e.ProgressPercentage;

            //Affichage de la progression sur un label
            lb_etat_prog_server.Content = pbstatus1.Value.ToString() + "%";
            */

            //envoi au client du pourcentage de progression
            try
            {

                client.Send(Encoding.UTF8.GetBytes("Bonjour client"));
            }
            catch (SocketException exp)
            {
                Console.WriteLine(exp.Message);

            }


        }


        // lancer la barre de progression en créant un objet de type BackgroundWorker
        //BackgroundWorker :
        private static void Button_Click()
        {
            //création, initialisation et mise à jour de l'objet BackgroundWorker
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        // méthode ecouter réseau appelé par le thread, permet d'écouter le réseau et accepter les demandes de connexion émises par le client.
        private static void ecouterReseau()
        {
            newsock.Listen(1);
            client = newsock.Accept();
            if (client != null) Button_Click();


        }

        private static void Window_Closing(object sender, CancelEventArgs e)
        {
            client.Shutdown(SocketShutdown.Both);

            client.Close();
        }


    }
}
