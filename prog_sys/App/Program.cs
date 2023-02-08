using Controler;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data;
using System.Globalization;
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

        Language selectedLanguage = new Language(readCommand("Français : 1 , English : 2"));

        string command;

        while ((command = readCommand(selectedLanguage.defaultMessage())) != "exit")
        {
            Console.Clear();
            switch (command)
            {
                case "save":
                    string saveName = readCommand(selectedLanguage.saveNameMessage());
                    string originPath = readCommand(selectedLanguage.originPathMessage());
                    string targetPath = readCommand(selectedLanguage.targetPathMessage());

                    //créer un tableau de fileName
                    string[] fileNames = Directory.GetFiles(originPath);
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        fileNames[i] = Path.GetFileName(fileNames[i]);
                    };

                    //lancer une sauvegarde
                    Save save = new Save(saveName, originPath, targetPath);
                    save.checkType(fileNames);

                    Console.WriteLine("All files have been copied successfully.");
                    Console.ReadLine();

                    //paramètres dispo : saveName, originPath, targetPath, fileName

                    break;
                case "language":
                    selectedLanguage = new Language(readCommand("Français : 1 , English : 2"));
                    break;
                default:
                    Console.WriteLine("unknown command");
                    break;
            }
            Console.Clear();
        }
    }
}