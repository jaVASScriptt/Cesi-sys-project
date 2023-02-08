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

        Feature f = new Feature();
        
        Language selectedLanguage = new Language(readCommand("Français : 1 , English : 2"));

        string command;

        while ((command = readCommand(selectedLanguage.defaultMessage())) != "exit")
        {
            switch (command)
            {
                case "save":
                    string saveName = readCommand(selectedLanguage.saveNameMessage());
                    string originPath = readCommand(selectedLanguage.originPathMessage());
                    string targetPath = readCommand(selectedLanguage.targetPathMessage());
                    string numberOfFilesToCopy = readCommand(selectedLanguage.numberOfFilesToSaveMessage());
                    int.TryParse(numberOfFilesToCopy, out int filesNumber);
                    for (int file = 0; file < filesNumber; file++)
                    {
                        string fileName = readCommand(selectedLanguage.fileNameMessage());
                        //lancer une sauvegarde
                        
                        //Avec les valeurs qu'il a rentré on crée un save
                        
                        Save save = new Save(fileName, originPath, targetPath);
                        Console.WriteLine("All files have been copied successfully.");
                        
                        //paramètres dispo : saveName, originPath, targetPath, fileName
                    }
                    break;
                case "language":
                    selectedLanguage = new Language(readCommand("Français : 1 , English : 2"));
                    break;
                default:
                    Console.WriteLine("unknown command");
                    break;
            }
        }
    }
}