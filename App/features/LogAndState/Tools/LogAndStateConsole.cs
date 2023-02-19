using ConsoleApp2.Features.utils;
using Controler;

namespace EasySafe;

public class LogAndStateConsole
{
    public LogAndStateConsole()
    {

        int choice = 0;

        while (choice != 8)
        {
            LogAndStateTool.showTasks();
            choice = LanguageTool.printAndRescueChoice("featureMenu");

            switch (choice)
            {
                case 1:
                    int index = LanguageTool.printInt("numberSaveWork");
                    string name = LanguageTool.print("saveNameMessage");
                    string sourcePath = LanguageTool.print("originPathMessage");
                    string targetPath = LanguageTool.print("targetPathMessage");
                    int type = LanguageTool.printAndRescueChoice("saveType");

                    //Count all the files in the directory and its subdirectories
                    int filesCountCase1 = 0;

                    //Measurement of the file size
                    long filesSizeCase1 = 0;

                    foreach (string filePath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                    {
                        filesCountCase1++;

                        //Get the file size and add it to the total size
                        FileInfo fileInfo = new FileInfo(filePath);
                        filesSizeCase1 += fileInfo.Length;
                    }

                    LogAndStateTool.addNewTask(index, name, sourcePath, targetPath, filesCountCase1, filesSizeCase1, filesCountCase1, 0, type == 1 ? "complete" : type == 2 ? "differential" : "bad type");

                    break;

                case 2:
                    int indexToModify = LanguageTool.printInt("numberSaveWork");
                    string newName = LanguageTool.print(entry:LanguageTool.get("saveNameMessage") + LanguageTool.get("editSaveWork"));
                    string newSourcePath = LanguageTool.print(entry:LanguageTool.get("originPathMessage") + LanguageTool.get("editSaveWork"));
                    string newTargetPath = LanguageTool.print(entry:LanguageTool.get("targetPathMessage") + LanguageTool.get("editSaveWork"));
                    int newType = LanguageTool.printAndRescueChoice("saveType");

                    TaskData task = LogAndStateTool.getTask(indexToModify);

                    //Count all the files in the directory and its subdirectories
                    int filesCountCase2 = 0;

                    //Measurement of the file size
                    long filesSizeCase2 = 0;

                    if (newSourcePath == "")
                    {
                        foreach (string filePath in Directory.GetFiles(task.SourceFilePath, "*.*", SearchOption.AllDirectories))
                        {
                            filesCountCase2++;

                            //Get the file size and add it to the total size
                            FileInfo fileInfo = new FileInfo(filePath);
                            filesSizeCase2 += fileInfo.Length;
                        }
                    }
                    else
                    {
                        foreach (string filePath in Directory.GetFiles(newSourcePath, "*.*", SearchOption.AllDirectories))
                        {
                            filesCountCase2++;

                            //Get the file size and add it to the total size
                            FileInfo fileInfo = new FileInfo(filePath);
                            filesSizeCase2 += fileInfo.Length;
                        }
                    }

                    int filesLeftTodo = filesCountCase2;

                    LogAndStateTool.addNewTask(LogAndStateTool.getTaskIndex(task.Name),
                        Name: newName == "" ? task.Name : newName,
                        SourceFilePath: newSourcePath == "" ? task.SourceFilePath : newSourcePath,
                        TargetFilePath: newTargetPath == "" ? task.TargetFilePath : newTargetPath,
                        TotalFilesToCopy: filesCountCase2 == 0 ? task.NbFilesLeftToDo : filesCountCase2,
                        TotalFilesSize: filesSizeCase2 == 0 ? task.TotalFilesSize : filesSizeCase2,
                        NbFilesLeftToDo: filesLeftTodo == 0 ? task.NbFilesLeftToDo : filesLeftTodo,
                        task.Progression,
                        Type: newType == 1 ? "complete" : newType == 2 ? "differential" : task.Type);
                    break;

                case 3:
                    int indexToDelete = LanguageTool.printInt("deleteSaveWork");

                    LogAndStateTool.factoryFillOneState(indexToDelete);
                    break;

                case 4:
                    if (LanguageTool.printAndRescueChoice("deleteAllSaveWork") == 1)
                        LogAndStateTool.factoryFillState();
                    break;
                case 5:

                    int ind = LanguageTool.printInt("whatWork");
                    TaskData t = LogAndStateTool.getTask(ind);
                    
                    if (t == null)
                    {
                        LanguageTool.print("invalidChoice");
                        break;
                    }
                    else
                    {             
                        if (t.Type == "complete")
                        {
                            
                            ISave save = FactorySave.GetSave(t.Name, t.SourceFilePath, t.TargetFilePath, "Complete");
                            save.saveData(ind);
                        }
                        else
                        {
                            ISave save = FactorySave.GetSave(t.Name, t.SourceFilePath, t.TargetFilePath, "Differential");
                            save.saveData(ind);
                        }

                        LanguageTool.print("AllFilesCopy");
                        break;
                    }

                case 6:
                    LogAndStateTool.addLocation();
                    break;
                case 7:
                    LogAndStateTool.deleteLocation(LanguageTool.printInt("whatStateDelete"));
                    break;
                case 8 :
                    break;
                default:
                    LanguageTool.print("invalidChoice");
                    break;
            }
            
            Console.Clear();

        }


    }

}