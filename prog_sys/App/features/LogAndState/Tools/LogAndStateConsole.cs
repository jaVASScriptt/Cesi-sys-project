﻿using ConsoleApp2.Features.utils;
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
            choice = LanguageTool.printAndRescueChoice("featureMenu");

            switch (choice)
            {
                case 1:
                    int index = LanguageTool.printInt("numberSaveWork");
                    string name = LanguageTool.print("saveNameMessage");
                    string sourcePath = LanguageTool.print("originPathMessage");
                    string targetPath = LanguageTool.print("targetPathMessage");
                    LanguageTool.printAndRescueChoice("saveType");
                    int type = Errors.NumberEntry();
                    
                    logAndStateTool.addNewTask(index, name, sourcePath, targetPath, 0, 0, 0, 0, type == 1 ? "complete" : type == 2 ? "differential" : "bad type");

                    break;

                case 2:
                    int indexToModify = LanguageTool.printInt("numberSaveWork");
                    string newName = LanguageTool.print(entry:LanguageTool.get("saveNameMessage") + LanguageTool.get("editSaveWork"));
                    string newSourcePath = LanguageTool.print(entry:LanguageTool.get("originPathMessage") + LanguageTool.get("editSaveWork"));
                    string newTargetPath = LanguageTool.print(entry:LanguageTool.get("targetPathMessage") + LanguageTool.get("editSaveWork"));
                    LanguageTool.printAndRescueChoice("saveType");
                    int newType = LanguageTool.printInt("editSaveWork");

                    TaskData task = logAndStateTool.getTask(indexToModify);

                    logAndStateTool.addNewTask(indexToModify,
                        Name: newName == "" ? task.Name : newName,
                        SourceFilePath: newSourcePath == "" ? task.SourceFilePath : newSourcePath,
                        TargetFilePath: newTargetPath == "" ? task.TargetFilePath : newTargetPath,
                        task.TotalFilesToCopy, task.TotalFilesSize, task.NbFilesLeftToDo, task.Progression,
                        Type: newType == 1 ? "complete" : newType == 2 ? "differential" : task.Type);
                    break;

                case 3:
                    int indexToDelete = LanguageTool.printInt("deleteSaveWork");

                    logAndStateTool.factoryFillOneState(indexToDelete);
                    break;

                case 4:
                    LanguageTool.printAndRescueChoice("deleteAllSaveWork");
                    int confirm = Errors.NumberEntry();

                    if (confirm == 1)
                        logAndStateTool.factoryFillState();
                    break;
                case 5:

                    int ind = LanguageTool.printInt("whatWork");
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

                    LanguageTool.print("AllFilesCopy");

                    break;
                
                case 6:
                    logAndStateTool.addLocation();
                    break;
                case 7:
                    logAndStateTool.deleteLocation(LanguageTool.printInt("whatStateDelete"));
                    break;
                default:
                    LanguageTool.print("invalidChoice");
                    break;
            }
            
            Console.Clear();

        }


    }

}