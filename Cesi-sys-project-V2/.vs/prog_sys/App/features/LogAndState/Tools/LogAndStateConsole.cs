using ConsoleApp2.Features.utils;
using Controler;

namespace EasySafe;

public class LogAndStateConsole
{
    public LogAndStateConsole()
    {

        LogAndStateTool logAndStateTool = LogAndStateTool.Instance;


        int choice = 0;

        while (choice != 8)
        {
            logAndStateTool.showTasks();
            Console.WriteLine(LanguageTool.get("featureMenu"));
            choice = Errors.NumberEntry();
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine(LanguageTool.get("numberSaveWork"));
                    int index = Errors.NumberEntry();

                    Console.WriteLine(LanguageTool.get("saveNameMessage"));
                    string name = Console.ReadLine();

                    Console.WriteLine(LanguageTool.get("originPathMessage"));
                    string sourcePath = Console.ReadLine();

                    Console.WriteLine(LanguageTool.get("targetPathMessage"));
                    string targetPath = Console.ReadLine();

                    Console.WriteLine(LanguageTool.get("saveType"));
                    int type = Errors.NumberEntry();

                    logAndStateTool.addNewTask(index, name, sourcePath, targetPath, 0, 0, 0, 0, type == 1 ? "complete" : type == 2 ? "differential" : "bad type");

                    break;

                case 2:
                    Console.WriteLine(LanguageTool.get("numberSaveWork"));
                    int indexToModify = Errors.NumberEntry();

                    Console.WriteLine(LanguageTool.get("saveNameMessage") + LanguageTool.get("editSaveWork"));
                    string newName = Console.ReadLine();

                    Console.WriteLine(LanguageTool.get("originPathMessage") + LanguageTool.get("editSaveWork"));
                    string newSourcePath = Console.ReadLine();

                    Console.WriteLine(LanguageTool.get("targetPathMessage") + LanguageTool.get("editSaveWork"));
                    string newTargetPath = Console.ReadLine();

                    Console.WriteLine(LanguageTool.get("saveType") + LanguageTool.get("editSaveWork"));
                    int newType = Errors.NumberEntry();

                    TaskData task = logAndStateTool.getTask(indexToModify);

                    logAndStateTool.addNewTask(indexToModify,
                        Name: newName == "" ? task.Name : newName,
                        SourceFilePath: newSourcePath == "" ? task.SourceFilePath : newSourcePath,
                        TargetFilePath: newTargetPath == "" ? task.TargetFilePath : newTargetPath,
                        task.TotalFilesToCopy, task.TotalFilesSize, task.NbFilesLeftToDo, task.Progression,
                        Type: newType == 1 ? "complete" : newType == 2 ? "differential" : task.Type);
                    break;

                case 3:
                    Console.WriteLine(LanguageTool.get("deleteSaveWork"));
                    int indexToDelete = Errors.NumberEntry();

                    logAndStateTool.factoryFillOneState(indexToDelete);
                    break;

                case 4:
                    Console.WriteLine(LanguageTool.get("deleteAllSaveWork"));
                    int confirm = Errors.NumberEntry();

                    if (confirm == 1)
                    {
                        logAndStateTool.factoryFillState();
                    }
                    break;
                case 5:
                    Console.WriteLine("Quel travail de sauvegarde souhaitez-vous effectuer ?");

                    int ind = Errors.NumberEntry();
                    TaskData t = logAndStateTool.getTask(ind);

                    string[] fileNames = Directory.GetFiles(t.SourceFilePath);
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        fileNames[i] = Path.GetFileName(fileNames[i]);
                    };

                    if (t.Type == "complete")
                    {
                        /*
                        CompleteSave saveC = new CompleteSave(t.Name, t.SourceFilePath, t.TargetFilePath);
                        saveC.CopyFileComplete(fileNames);*/
                        ISave save = FactorySave.GetSave(t.Name, t.SourceFilePath, t.TargetFilePath, "Complete");
                        save.SaveData();
                    }
                    else
                    {
                        /*
                        DifferentialSave saveD = new DifferentialSave(t.Name, t.SourceFilePath, t.TargetFilePath);
                        saveD.CopyFileDifferential(fileNames);*/
                        ISave save = FactorySave.GetSave(t.Name, t.SourceFilePath, t.TargetFilePath, "Differential");
                        save.SaveData();
                    }

                    Console.WriteLine("All files have been copied successfully.");
                    Console.ReadLine();

                    break;
                
                case 6:
                    logAndStateTool.addLocation();
                    break;
                case 7:
                    Console.WriteLine("Quel Emplacement souhaitez-vous supprimer ? (entrer un numéro incorrecte supprime le dernier) ");
                    logAndStateTool.deleteLocation(Errors.NumberEntry());
                    break;
                default:
                    Console.WriteLine("Veuillez entrer un nombre valide");
                    break;
            }
            

        }


    }

}