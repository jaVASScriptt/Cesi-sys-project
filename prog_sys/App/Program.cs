using System;
using System.Data;
using System.Globalization;

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
        Language selectedLanguage = new Language(readCommand(Language.selectLanguage()));
        Console.Clear();

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
                    string numberOfFilesToCopy = readCommand(selectedLanguage.numberOfFilesToSaveMessage());
                    int.TryParse(numberOfFilesToCopy, out int filesNumber);
                    for (int file = 0; file < filesNumber; file++)
                    {
                        string fileName = readCommand(selectedLanguage.fileNameMessage());
                        //lancer une sauvegarde
                        //paramètres dispo : saveName, originPath, targetPath, fileName
                    }
                    break;
                case "language":
                    selectedLanguage = new Language(readCommand(Language.selectLanguage()));
                    break;
                case "clear":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("unknown command");
                    break;
            }
            Console.Clear();
        }
    }
}