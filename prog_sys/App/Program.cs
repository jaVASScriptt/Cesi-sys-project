using System;
using System.Data;
using System.Globalization;

public class Program
{

    public static string readCommand(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    static void Main(string[] args)
    {
        Language selectedLanguage = new Language(readCommand("Français : 1 , English : 2"));

        string command = readCommand(selectedLanguage.defaultMessage());

        while (command != "exit")
        {
            switch (command)
            {
                case "save":
                    string saveName = readCommand(selectedLanguage.saveNameMessage());
                    string originPath = readCommand(selectedLanguage.originPathMessage());
                    string targetPath = readCommand(selectedLanguage.targetPathMessage());
                    int numberOfFilesToCopy = Int32.Parse(readCommand(selectedLanguage.numberOfFilesToSaveMessage()));
                    for (int i = 0; i < numberOfFilesToCopy; i++)
                    {
                        string fileName = readCommand(selectedLanguage.fileNameMessage());
                        //lancer une sauvegarde
                    }
                    break;
                case "language":
                    selectedLanguage = new Language(readCommand("Français : 1 , English : 2"));
                    break;
                default:
                    Console.WriteLine("unknown command");
                    break;
            }
            command = readCommand(selectedLanguage.defaultMessage());
        }
    }
}