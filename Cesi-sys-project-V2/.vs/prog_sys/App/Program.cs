using Controler;
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

        LogAndStateTool t = LogAndStateTool.Instance;
        LanguageTool.setLanguage(readCommand("Français : 1 , English : 2"));

        string command;

        while ((command = readCommand(LanguageTool.get("defaultMessage"))) != "exit")
        {
            Console.Clear();
            switch (command)
            {
                case "menu":
                    new LogAndStateConsole();
                    break;
                case "save":
                    string saveName = readCommand(LanguageTool.get("saveNameMessage"));
                    string originPath = readCommand(LanguageTool.get("originPathMessage"));
                    string targetPath = readCommand(LanguageTool.get("targetPathMessage"));
                    string saveType = readCommand("'Complete' or 'Differential'");

                    //créer un tableau de fileName
                    string[] fileNames = Directory.GetFiles(originPath);
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        fileNames[i] = Path.GetFileName(fileNames[i]);
                    };

                    //lancer une sauvegarde
                    /*
                    Save save = new Save(saveName, originPath, targetPath);
                    save.checkType(fileNames);
                    */
                    ISave save = FactorySave.GetSave(saveName, originPath, targetPath, saveType);
                    save.SaveData();

                    Console.WriteLine("All files have been copied successfully.");
                    Console.ReadLine();

                    //paramètres dispo : saveName, originPath, targetPath, fileName

                    break;
                case "language":
                    LanguageTool.setLanguage(readCommand("Français : 1 , English : 2"));
                    break;
                default:
                    Console.WriteLine("unknown command");
                    break;
            }
            Console.Clear();
        }
    }
}