using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Remote
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static Socket SeConnecter(string adresseServeur, int port)
        {
            IPAddress? adresseIP;
            if (!IPAddress.TryParse(adresseServeur, out adresseIP))
            {
                // La chaîne passée en paramètre n'est pas une adresse IP valide, on tente de la résoudre en nom de domaine
                IPHostEntry hostEntry = Dns.GetHostEntry(adresseServeur);
                if (hostEntry.AddressList.Length == 0)
                {
                    throw new ArgumentException("Impossible de résoudre l'adresse spécifiée en nom de domaine ou adresse IP.");
                }
                adresseIP = hostEntry.AddressList[0];
            }

            // On crée un socket pour la connexion cliente
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // On se connecte au serveur
            socket.Connect(new IPEndPoint(adresseIP, port));

            return socket;
        }

        private static void EcouterReseau(Socket client)
        {
            // Buffer pour recevoir les données du serveur
            byte[] buffer = new byte[1024];
            int bytesLus;

            while (true)
            {
                // On lit les données envoyées par le serveur
                bytesLus = client.Receive(buffer);
                string donnees = Encoding.UTF8.GetString(buffer, 0, bytesLus);

                // On affiche les données reçues dans la console
                Console.WriteLine("Données reçues : " + donnees);

                if (donnees.Equals("FIN"))
                {
                    // Si le serveur envoie la chaîne "FIN", on arrête la boucle
                    break;
                }

                // On lit les données à envoyer au serveur depuis la console
                Console.Write("Données à envoyer : ");
                string? message;
                while ((message = Console.ReadLine()) == "") ;
                if (message == null) message = "";

                // On envoie les données au serveur
                client.Send(Encoding.UTF8.GetBytes(message));

                if (message.Equals("FIN"))
                {
                    // Si l'utilisateur envoie la chaîne "FIN", on arrête la boucle
                    break;
                }
            }
        }
        private static void Deconnecter(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        static void Main(string[] args)
        {
            // Adresse IP et port du serveur
            string adresseServeur = "127.0.0.1";
            int port = 12345;

            // Connexion au serveur
            Socket client = SeConnecter(adresseServeur, port);

            // Ecoute des données du serveur
            EcouterReseau(client);

            // Déconnexion du serveur
            Deconnecter(client);

            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }

    }

}
