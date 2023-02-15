using Controler;
using EasySafe;

public class Program
{
    static void Main(string[] args)
    {

        LogAndStateTool t = LogAndStateTool.Instance;
        LanguageTool.setLanguage(LanguageTool.print(entry:" Français(default) : 1 , English : 2"));

        int command;
        
        while ((command = LanguageTool.printAndRescueChoice("starterChoice")) != 4)
        {
            Console.Clear();
            switch (command)
            {
                case 1:
                    LogAndStateConsole cf = new LogAndStateConsole(t);
                    break;
                case 2:
                    string saveName = LanguageTool.print("saveNameMessage");
                    string originPath = LanguageTool.print("originPathMessage");
                    string targetPath = LanguageTool.print("targetPathMessage");
                    int saveType = LanguageTool.printAndRescueChoice("saveType");

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
                    ISave save = FactorySave.GetSave(saveName, originPath, targetPath, saveType == 1 ? "Complete" : saveType == 2 ? "Differential" : "Complete");
                    save.SaveData();
                    LanguageTool.print("AllFilesCopy");

                    //paramètres dispo : saveName, originPath, targetPath, fileName

                    break;
                case 3:
                    LanguageTool.setLanguage(LanguageTool.print(entry:" Français(default) : 1 , English : 2 "));
                    break;
                default:
                    LanguageTool.print("invalidChoice");
                    break;
            }
            Console.Clear();
        }
    }
}