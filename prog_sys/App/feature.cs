using Newtonsoft.Json;

namespace EasySafe;

public class feature
{
    private string _logPath;
    private string _statePath;

    public feature(string path = "")
    {
        
        if (string.IsNullOrEmpty(path))
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "/../../../features";
        }
        
        _logPath = path + "/log.json";
        _statePath = path + "/state.json";

        try
        {
            if (!File.Exists(_logPath))
                File.Create(_logPath);

            if (!File.Exists(_statePath))
                factoryFillState(_statePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors de la création des fichiers log et state : " + ex.Message);
        }
    }
    
    public void factoryFillState(String filePath)
    {
        TaskData[] tasks = new TaskData[5];

        for (int i = 0; i < 5; i++)
        {
            tasks[i] = new TaskData
            {
                Name = "",
                SourceFilePath = "",
                TargetFilePath = "",
                State = "END",
                TotalFilesToCopy = 0,
                TotalFilesSize = 0,
                NbFilesLeftToDo = 0,
                Progression = 0,
                LastUsed = "17/12/2020 17:06:49"
            };
        }

        string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);

        File.WriteAllText(filePath, json);
    }

}

public class TaskData
{
    public string Name { get; set; }
    public string SourceFilePath { get; set; }
    public string TargetFilePath { get; set; }
    public string State { get; set; }
    public int TotalFilesToCopy { get; set; }
    public int TotalFilesSize { get; set; }
    public int NbFilesLeftToDo { get; set; }
    public int Progression { get; set; }
    public string LastUsed { get; set; }
}