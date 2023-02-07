namespace EasySafe
{
    class Program
    {
        // double tableau contenant l'ensemble des phrases utilisées dans un tableau comme ceci : [[français, anglais] , [français, anglais] , ...]

        private static string[][] sentences = 
        {
            new string[] { "Création du travail de sauvegarde n°", "Creating Backup Job n°" },
            new string[] { "Entrez l'appellation :", "Enter the name:" },
            new string[] { "Entrez le répertoire source :", "Enter the source directory:" },
            new string[] { "Entrez le répertoire cible :", "Enter the target directory:" },
            new string[] { "Entrez le type de sauvegarde (complet ou différentiel) :", "Enter the backup type (full or differential):" },
            new string[]
            {
                "Choisissez un travail de sauvegarde à exécuter (1 à 5) ou tapez 6 pour exécuter tous les travaux de sauvegarde :", 
                "Choose a backup job to run (1-5) or type 6 to run all backup jobs:"
            },
            new string[] { "Exécution du travail de sauvegarde n°", "Running backup job n°" },
            new string[] { "Exécution de tous les travaux de sauvegarde", "Running all backup jobs" },
            new string[] { "Choix incorrect", "Incorrect choice" },
            new string[] { "Exécution de ", "Running " },
            new string[] { "Le répertoire source n'existe pas, veuillez réessayer :", "The source directory does not exist, please try again:" },
            new string[] { "Le nom du travail de sauvegarde existe déjà, veuillez réessayer :", "The backup job name already exists, please try again:" },
            new string[] { 
            "Une sauvegarde avec les mêmes répertoires source et cible existe déjà, veuillez réessayer :", 
            "A backup with the same source and target directories already exists, please try again:" 
            }
        };

        private static int Language; 
        
        static void Main(string[] args)
        {
            Feature f = new Feature();

            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            
            Console.WriteLine("Bienvenue dans EasySafe 1.0");
            Console.WriteLine("Welcome in EasySafe 1.0");
            
            Console.WriteLine("");
            
            Console.WriteLine("Premièrement, sélectionnez votre langue : 1. Français 2. Anglais");
            Console.WriteLine("First select your language: 1. French 2. English");
            
            Language = Convert.ToInt32(Console.ReadLine()) - 1;
            
            
            // création des jobs de sauvegarde

            BackupJob[] jobs = new BackupJob[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(sentences[0][Language] + (i + 1));

                Console.WriteLine(sentences[1][Language]);
                string name = Console.ReadLine();

                while (jobs.Any(job => job != null && job.Name == name))
                {
                    Console.WriteLine(sentences[11][Language]);
                    name = Console.ReadLine();
                }

                Console.WriteLine(sentences[2][Language]);
                string source = Console.ReadLine();
                
                while (!IsDirectoryValid(source))
                {
                    Console.WriteLine(sentences[10][Language]);
                    source = Console.ReadLine();
                }

                Console.WriteLine(sentences[3][Language]);
                string destination = Console.ReadLine();
                
                while (!IsDirectoryValid(destination))
                {
                    Console.WriteLine(sentences[10][Language]);
                    destination = Console.ReadLine();
                }
                
                //vérifie si aucune sauvegarde n'a déja les mêmes répertoires source et cible
                
                while (jobs.Any(job => job != null && job.Source == source && job.Destination == destination))
                {
                    Console.WriteLine(sentences[12][Language]);
                    
                    Console.WriteLine(sentences[2][Language]);
                    source = Console.ReadLine();
                
                    while (!IsDirectoryValid(source))
                    {
                        Console.WriteLine(sentences[10][Language]);
                        source = Console.ReadLine();
                    }

                    Console.WriteLine(sentences[3][Language]);
                    destination = Console.ReadLine();
                
                    while (!IsDirectoryValid(destination))
                    {
                        Console.WriteLine(sentences[10][Language]);
                        destination = Console.ReadLine();
                    }
                }

                Console.WriteLine(sentences[4][Language]);
                string type = Console.ReadLine();

                jobs[i] = new BackupJob(name, source, destination, type);
            }
            
            // exécution des jobs de sauvegarde

            Console.WriteLine(sentences[5][Language]);
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice >= 1 && choice <= 5)
            {
                Console.WriteLine(sentences[6][Language] + choice);
                ExecuteBackup(jobs[choice - 1]);
            }
            else if (choice == 6)
            {
                Console.WriteLine(sentences[7][Language]);
                foreach (BackupJob job in jobs)
                {
                    ExecuteBackup(job);
                }
            }
            else
            {
                Console.WriteLine(sentences[8][Language]);
            }
        }

        static void ExecuteBackup(BackupJob job)
        {
            Console.WriteLine(sentences[9][Language] + job.Name + " :");

            // Copie les fichiers depuis le répertoire source vers le répertoire cible
            // Affiche le temps de transfert et la taille des fichiers
        }
        
        static bool IsDirectoryValid(string path)
        {
            return Directory.Exists(path);
        }

    }

    class BackupJob
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Type { get; set; }

        public BackupJob(string name, string source, string destination, string type)
        {
            Name = name;
            Source = source;
            Destination = destination;
            Type = type;
        }
    }
}