using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

static class Server
{

    private static Socket SeConnecter()
    {
        // Création du socket serveur
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Association du socket à une adresse IP et un port
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        socket.Bind(endPoint);

        // Mise à l'écoute des connexions clientes
        socket.Listen(10);

        // Renvoi du socket créé
        return socket;
    }

    private static Socket AccepterConnexion(Socket socketServeur)
    {
        // Accepter une connexion cliente et créer un nouveau socket pour le client
        Socket socketClient = socketServeur.Accept();

        // Renvoyer le socket créé pour communiquer avec le client
        return socketClient;
    }

    private static void EcouterReseau(Socket client)
    {
        string? input; int recv;
        string welcome = "Bienvenue sur le serveur ...";

        byte[] data = new byte[1024];

        data = Encoding.UTF8.GetBytes(welcome);

        client.Send(data, data.Length, SocketFlags.None);


        while (true)
        {
            try
            {
                recv = client.Receive(data);

                if (Encoding.UTF8.GetString(data, 0, recv) == "exit")

                    break;

                Console.WriteLine("Client: " + Encoding.UTF8.GetString(data, 0, recv));

                Console.WriteLine("Reponse au client : ");
                while ((input = Console.ReadLine()) == "") ;

                Console.WriteLine("Server : " + input);

                client.Send(Encoding.UTF8.GetBytes(input));
            }
            catch (Exception e)
            {
                Console.WriteLine("Le client est HS.");
                Console.WriteLine(e.ToString());
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }

    private static void Deconnecter(Socket socket)
    {
        if (socket != null)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }



    public static void startServer()
    {
        // Appel de SeConnecter() pour obtenir le socket
        Socket socketServeur = SeConnecter();

        // Appel de AccepterConnexion() pour accepter une connexion cliente
        Socket socketClient = AccepterConnexion(socketServeur);

        // Gérer l'échange de données entre le serveur et le client
        EcouterReseau(socketClient);

        // Fermeture de la connexion
        Deconnecter(socketServeur);
    }

}
