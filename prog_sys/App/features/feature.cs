using System.Collections;
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
                factoryFillLogs(_logPath);

            if (!File.Exists(_statePath))
                factoryFillState(_statePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors de la création des fichiers log et state : " + ex.Message);
        }
        
        addLog(3, "yes");
        
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
    
    public void factoryFillLogs(String filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))  
        {  
            writer.WriteLine("[");  
            writer.WriteLine("]");
        }  
    }
    
    
    
    public TaskData[] getTasks()
    {
        string json = File.ReadAllText(_statePath);
        TaskData[] tasks = JsonConvert.DeserializeObject<TaskData[]>(json);
        return tasks;
    }
    
    public void setTask(int task = 0, 
        string Name = "", 
        string SourceFilePath = "", 
        string TargetFilePath = "", 
        string State = "", 
        int TotalFilesToCopy = 0, 
        int TotalFilesSize = 0, 
        int NbFilesLeftToDo = 0, 
        int Progression = 0, 
        string LastUsed = "")
    {
        TaskData[] tasks = getTasks();
        
        tasks[task] = new TaskData
        {
            Name = Name == "" ? tasks[task].Name : Name ,
            SourceFilePath = SourceFilePath == "" ? tasks[task].SourceFilePath : SourceFilePath,
            TargetFilePath = TargetFilePath == "" ? tasks[task].TargetFilePath : TargetFilePath,
            State = State == "" ? tasks[task].State : State,
            TotalFilesToCopy = TotalFilesToCopy == 0 ? tasks[task].TotalFilesToCopy : TotalFilesToCopy,
            TotalFilesSize = TotalFilesSize == 0 ? tasks[task].TotalFilesSize : TotalFilesSize,
            NbFilesLeftToDo = NbFilesLeftToDo == 0 ? tasks[task].NbFilesLeftToDo : NbFilesLeftToDo,
            Progression = Progression == 0 ? tasks[task].Progression : Progression,
            LastUsed = LastUsed == "" ? tasks[task].LastUsed : LastUsed
        };
        
        string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);

        File.WriteAllText(_statePath, json);
    }
    
    public ArrayList getLogs()
    {
        string json = File.ReadAllText(_logPath);
        ArrayList logs = JsonConvert.DeserializeObject<ArrayList>(json);
        return logs;
    }
    
    public void addLog(int task = 0,
        string success = "",
        int FileTransferTime = 0)
    {
        ArrayList logs = getLogs();
        TaskData[] tasks = getTasks();

        logs.Add(new LogData
        {
            Name = tasks[task].Name,
            SourceFilePath = tasks[task].SourceFilePath,
            TargetFilePath = tasks[task].TargetFilePath,
            success = "success",
            FileSize = tasks[task].TotalFilesSize,
            FileTransferTime = FileTransferTime,
            Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        });
        
        string json = JsonConvert.SerializeObject(logs, Formatting.Indented);

        File.WriteAllText(_logPath, json);
    }
    
}