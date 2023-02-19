using Controler;
using EasySafe;

public class Program
{
    static void Main(string[] args)
    {
        LanguageTool.setLanguage();

        int command;
        
        while ((command = LanguageTool.printAndRescueChoice("starterChoice")) != 5)
        {
            Console.Clear();
            switch (command)
            {
                case 1:
                    new LogAndStateConsole();
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
                    FactorySave.GetSave(saveName, originPath, targetPath, saveType == 1 ? "Complete" : saveType == 2 ? "Differential" : "Complete")?.saveData();
                    LanguageTool.print("AllFilesCopy");

                    //paramètres dispo : saveName, originPath, targetPath, fileName

                    break;
                case 3:
                    LanguageTool.setLanguage();
                    break;
                case 4:
                    string path = LanguageTool.print("pathMessage");
                    if (Directory.Exists(path) || path == "")
                        LogAndStateTool.changePath(path);
                    else
                        LanguageTool.print("pathEntryError");
                    break;
                default:
                    LanguageTool.print("invalidChoice");
                    break;
            }
            Console.Clear();
        }
    }
}