namespace EasySafe;

public class consoleFeature
{
    public consoleFeature(Feature f)
    {

        Feature feature = f;

        Console.WriteLine("Bienvenue dans le management des travaux sauvegarde !");
        Console.WriteLine("");

        int choice = 0;
        
        while ( choice != 5)
        {
            feature.showTasks();

            Console.WriteLine("");

            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("1 - Créer un nouveau travail de sauvegarde");
            Console.WriteLine("2 - Modifier un travail de sauvegarde");
            Console.WriteLine("3 - Supprimer un travail de sauvegarde");
            Console.WriteLine("4 - Supprimer tout les travaux de sauvegarde");
            Console.WriteLine("5 - quitter le management des travaux sauvegarde");
            Console.WriteLine("");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("veuillez indiquer quelle travail de sauvegarde vous souhaitez créer : ");
                    int index = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("veuillez indiquer le nom de la sauvegarde : ");
                    string name = Console.ReadLine();

                    Console.WriteLine("veuillez indiquer le chemin d'accès du dossier source : ");
                    string sourcePath = Console.ReadLine();

                    Console.WriteLine("veuillez indiquer le chemin d'accès du dossier cible : ");
                    string targetPath = Console.ReadLine();
                    
                    Console.WriteLine("Quel sera le type de sauvegarde ? (1: complete, 2: differential)");
                    int type = Convert.ToInt32(Console.ReadLine());

                    feature.addNewTask(index, name, sourcePath, targetPath, 0, 0, 0, 0, type == 1? "complete" : type == 2 ? "differential" : "bad type");

                    break;
                
                case 2 :
                    Console.WriteLine("Quel travail de sauvegarde souhaitez-vous modifier ?");
                    int indexToModify = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Quel est le nouveau nom de la sauvegarde ? (laisser vide pour ne pas modifier)");
                    string newName = Console.ReadLine();
                    
                    Console.WriteLine("Quel est le nouveau chemin d'accès du dossier source ? (laisser vide pour ne pas modifier)");
                    string newSourcePath = Console.ReadLine();
                    
                    Console.WriteLine("Quel est le nouveau chemin d'accès du dossier cible ? (laisser vide pour ne pas modifier)");
                    string newTargetPath = Console.ReadLine();
                    
                    Console.WriteLine("Quel est le nouveau type de sauvegarde (1: complete, 2: differential) ? (laisser vide pour ne pas modifier)");
                    int newType = Convert.ToInt32(Console.ReadLine());
                    
                    TaskData task = feature.getTask(indexToModify);
                    
                    feature.addNewTask(indexToModify, 
                        Name: newName == "" ? task.Name : newName, 
                        SourceFilePath: newSourcePath == "" ? task.SourceFilePath : newSourcePath, 
                        TargetFilePath: newTargetPath == "" ? task.TargetFilePath : newTargetPath,
                        task.TotalFilesToCopy, task.TotalFilesSize, task.NbFilesLeftToDo, task.Progression,
                        Type: newType == 1 ? "complete" : newType == 2 ? "differential" : task.Type);
                break;
                
                case 3 :
                    Console.WriteLine("Quel travail de sauvegarde souhaitez-vous supprimer ?");
                    int indexToDelete = Convert.ToInt32(Console.ReadLine());

                    feature.factoryFillOneState(indexToDelete);
                break;
                
                case 4 :
                    Console.WriteLine("Etes-vous sûr de vouloir supprimer tout les travaux de sauvegarde ? (1: oui, 2: non)");
                    int confirm = Convert.ToInt32(Console.ReadLine());
                    
                    if (confirm == 1)
                    {
                        feature.factoryFillState();
                    }
                    break;

            }
            
            Console.WriteLine("");

        }


    }
    
}