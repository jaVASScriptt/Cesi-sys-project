﻿using Controler;
using EasySafe;

public class Program
{
    public static string readCommand(string message)
    {
        Console.WriteLine(message);
        string userInput = Console.ReadLine();
        return userInput;
    }

    static void Main(string[] args)
    {

        LogAndStateTool t = new LogAndStateTool();
        Language.setLanguage(readCommand("Français : 1 , English : 2"));

        string command;

        while ((command = readCommand(Language.get("defaultMessage"))) != "exit")
        {
            Console.Clear();
            switch (command)
            {
                case "menu":
                    LogAndStateConsole cf = new LogAndStateConsole(t);
                    break;
                case "save":
                    string saveName = readCommand(Language.get("saveNameMessage"));
                    string originPath = readCommand(Language.get("originPathMessage"));
                    string targetPath = readCommand(Language.get("targetPathMessage"));

                    //créer un tableau de fileName
                    string[] fileNames = Directory.GetFiles(originPath);
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        fileNames[i] = Path.GetFileName(fileNames[i]);
                    };

                    //lancer une sauvegarde
                    Save save = new Save(saveName, originPath, targetPath);
                    save.checkType(fileNames);

                    t.addLog(name: saveName, SourceFilePath: originPath, TargetFilePath: targetPath, success: "success");

                    Console.WriteLine("All files have been copied successfully.");
                    Console.ReadLine();

                    //paramètres dispo : saveName, originPath, targetPath, fileName

                    break;
                case "language":
                    Language.setLanguage(readCommand("Français : 1 , English : 2"));
                    break;
                default:
                    Console.WriteLine("unknown command");
                    break;
            }
            Console.Clear();
        }
    }
}