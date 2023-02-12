using Controler;

namespace EasySafe;

public class LogAndStateConsole
{
    public LogAndStateConsole(LogAndStateTool f)
    {

        LogAndStateTool logAndStateTool = f;


        int choice = 0;

        while (choice != 8)
        {
            logAndStateTool.showTasks();
            Console.WriteLine(Language.get("featureMenu"));
            choice = Convert.ToInt32(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine(Language.get("numberSaveWork"));
                    int index = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(Language.get("saveNameMessage"));
                    string name = Console.ReadLine();

                    Console.WriteLine(Language.get("originPathMessage"));
                    string sourcePath = Console.ReadLine();

                    Console.WriteLine(Language.get("targetPathMessage"));
                    string targetPath = Console.ReadLine();

                    Console.WriteLine(Language.get("saveType"));
                    int type = Convert.ToInt32(Console.ReadLine());

                    logAndStateTool.addNewTask(index, name, sourcePath, targetPath, 0, 0, 0, 0, type == 1 ? "complete" : type == 2 ? "differential" : "bad type");

                    break;

                case 2:
                    Console.WriteLine(Language.get("numberSaveWork"));
                    int indexToModify = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(Language.get("saveNameMessage") + Language.get("editSaveWork"));
                    string newName = Console.ReadLine();

                    Console.WriteLine(Language.get("originPathMessage") + Language.get("editSaveWork"));
                    string newSourcePath = Console.ReadLine();

                    Console.WriteLine(Language.get("targetPathMessage") + Language.get("editSaveWork"));
                    string newTargetPath = Console.ReadLine();

                    Console.WriteLine(Language.get("saveType") + Language.get("editSaveWork"));
                    int newType = Convert.ToInt32(Console.ReadLine());

                    TaskData task = logAndStateTool.getTask(indexToModify);

                    logAndStateTool.addNewTask(indexToModify,
                        Name: newName == "" ? task.Name : newName,
                        SourceFilePath: newSourcePath == "" ? task.SourceFilePath : newSourcePath,
                        TargetFilePath: newTargetPath == "" ? task.TargetFilePath : newTargetPath,
                        task.TotalFilesToCopy, task.TotalFilesSize, task.NbFilesLeftToDo, task.Progression,
                        Type: newType == 1 ? "complete" : newType == 2 ? "differential" : task.Type);
                    break;

                case 3:
                    Console.WriteLine(Language.get("deleteSaveWork"));
                    int indexToDelete = Convert.ToInt32(Console.ReadLine());

                    logAndStateTool.factoryFillOneState(indexToDelete);
                    break;

                case 4:
                    Console.WriteLine(Language.get("deleteAllSaveWork"));
                    int confirm = Convert.ToInt32(Console.ReadLine());

                    if (confirm == 1)
                    {
                        logAndStateTool.factoryFillState();
                    }
                    break;
                case 5:
                    Console.WriteLine("Quel travail de sauvegarde souhaitez-vous effectuer ?");

                    int ind = Convert.ToInt32(Console.ReadLine());
                    TaskData t = logAndStateTool.getTask(ind);

                    string[] fileNames = Directory.GetFiles(t.SourceFilePath);
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        fileNames[i] = Path.GetFileName(fileNames[i]);
                    };

                    if (t.Type == "complete")
                    {
                        CompleteSave saveC = new CompleteSave(t.Name, t.SourceFilePath, t.TargetFilePath);
                        saveC.CopyFileComplete(fileNames);
                    }
                    else
                    {
                        DifferentialSave saveD = new DifferentialSave(t.Name, t.SourceFilePath, t.TargetFilePath);
                        saveD.CopyFileDifferential(fileNames);
                    }

                    logAndStateTool.addLog(ind, "success");

                    Console.WriteLine("All files have been copied successfully.");
                    Console.ReadLine();

                    break;
                
                case 6:
                    logAndStateTool.addLocation();
                    break;
                case 7:
                    Console.WriteLine("Quel Emplacement souhaitez-vous supprimer ? (ne rien entrer ou entrer un numéro incorrecte supprime le dernier ");
                    logAndStateTool.deleteLocation(Convert.ToInt32(Console.ReadLine()));
                    break;
            }
            Console.Clear();

        }


    }

}