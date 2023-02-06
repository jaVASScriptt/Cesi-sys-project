namespace EasySafe;

public class feature
{
    public void CreateLog(String logPath)
    {
        logPath += "/log.json";
        try
        {
            if (!File.Exists(logPath))
                File.Create(logPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors de la création du fichier log : " + ex.Message);
        }
    }
    
    public void CreateState(String statePath)
    {
        statePath += "/state.json";
        try
        {
            if (!File.Exists(statePath))
                File.Create(statePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors de la création du fichier state : " + ex.Message);
        }
    }

}