using System.Collections;
using System.Text.Json;

namespace EasySafe;

public class Feature
{
    private string _logPath;
    private string _statePath;

    public Feature(string path = "")
    {
        if (string.IsNullOrEmpty(path))
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "/../../../features/files";
        }
        
        _logPath = path + "/log.json";
        _statePath = path + "/state.json";

        try
        {
            if (!File.Exists(_logPath))
                factoryFillLogs();

            if (!File.Exists(_statePath))
                factoryFillState();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors de la création des fichiers log et state : " + ex.Message);
        }
    }
    
    public void factoryFillState()
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
                 Type = "complete",
                 LastUsed = "17/12/2020 17:06:49"
             };
         }
 
         string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
         File.WriteAllText(_statePath, json);
     }

    public void factoryFillOneState(int index)
    {
        
        TaskData[] tasks = getTasks();
        
        if (index > 4 || index < 0)
        {
            Console.WriteLine("l'index doit être compris entre 0 et 4");
        }
        else if(tasks[index].Name == "")
        {
            Console.WriteLine("la tâche n'existe pas");
        }
        else
        {
            tasks[index] = new TaskData
            {
                Name = "",
                SourceFilePath = "",
                TargetFilePath = "",
                State = "END",
                TotalFilesToCopy = 0,
                TotalFilesSize = 0,
                NbFilesLeftToDo = 0,
                Progression = 0,
                Type = "complete",
                LastUsed = "17/12/2020 17:06:49"
            };
        
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_statePath, json);
        
            Console.WriteLine("tâche supprimée");
        }

    }
    
    public void factoryFillLogs()
    {
        using (StreamWriter writer = new StreamWriter(_logPath))  
        {  
            writer.WriteLine("[");  
            writer.WriteLine("]");
        }  
    }

    public TaskData[] getTasks()
    {
        
        string json = File.ReadAllText(_statePath);
        TaskData[] tasks = JsonSerializer.Deserialize<TaskData[]>(json);
        return tasks;
        
    }

    public void showTasks()
    {
        TaskData[] tasks = getTasks();

        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i].Name != "")
                Console.WriteLine(i + "] Nom : " + tasks[i].Name + " --- fichier source: " + tasks[i].SourceFilePath +
                                  " / fichier target: " + tasks[i].TargetFilePath + " / type : " + tasks[i].Type + " / etat: " + tasks[i].State);
            else
                Console.WriteLine(i + "] [vide]");
        }
    }

    public void changeState(int index = 0, String name = "")
    {
        TaskData task = getTask(index, name);
        TaskData[] tasks = getTasks();

        foreach (var i in tasks)
        {
            if (name == i.Name && name != "")
            {
                index = Array.IndexOf(tasks, i);
            }
        }

        setTask(index, State : task.State == "END" ? "RUNNING" : "END");
    }
    
    public TaskData getTask(int task = 0, String name = "") 
    {
        TaskData[] tasks = getTasks();
        
        if (name != "")
        {
            for (int i = 0; i < 5; i++)
            {
                if (tasks[i].Name == name)
                    return tasks[i];
            }
        }
        return tasks[task];
        
    }

    public void addNewTask(int task,
        string Name,
        string SourceFilePath,
        string TargetFilePath,
        int TotalFilesToCopy,
        int TotalFilesSize,
        int NbFilesLeftToDo,
        int Progression,
        string Type)
    {
        TaskData[] tasks = getTasks();
        bool okToAdd = true;
        String error = "";

        if (task < 0 || task > 4)
        {
            okToAdd = false;
            error = "Le numéro de tâche doit être compris entre 0 et 4";
        }
        else if (Name == "")
        {
            okToAdd = false;
            error = "Le nom de la tâche ne peut pas être vide";
        }
        else if (SourceFilePath == "")
        {
            okToAdd = false;
            error = "Le chemin source ne peut pas être vide";
        }
        else if (!File.Exists(SourceFilePath) && !Directory.Exists(SourceFilePath))
        {
            okToAdd = false;
            error = "Le fichier ou dossier source n'existe pas";
        }
        else if (TargetFilePath == "")
        {
            okToAdd = false;
            error = "Le chemin cible ne peut pas être vide";
        }
        else if (!File.Exists(TargetFilePath) && !Directory.Exists(TargetFilePath))
        {
            okToAdd = false;
            error = "Le fichier ou dossier cible n'existe pas";
        }
        else if (SourceFilePath == TargetFilePath)
        {
            okToAdd = false;
            error = "Les deux chemins ne peuvent pas être identiques";
        }
        else if (Type != "complete" && Type != "incremental")
        {
            okToAdd = false;
            error = "Le type de tâche doit être 'complete' ou 'incremental'";
        }

        if (okToAdd)
        {
            if (getTask(task).Name != "")
            {
                Console.WriteLine("voulez vous écraser la tâche ? (y/n)");
                if (Console.ReadLine() == "y")
                    setTask(task, Name, SourceFilePath, TargetFilePath, State:  "END", TotalFilesToCopy, TotalFilesSize,
                        NbFilesLeftToDo, Progression);
            }
            else
            {
                setTask(task, Name, SourceFilePath, TargetFilePath, State:  "END", TotalFilesToCopy, TotalFilesSize,
                    NbFilesLeftToDo, Progression);
            }
            Console.WriteLine("Tâche ajoutée");
        }
        else
        {
            Console.WriteLine("Impossible d'ajouter la tache! : " + error);
        }
        
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
        string Type = "complete",
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
            Type = Type == "" ? tasks[task].Type : Type,
            LastUsed = LastUsed == "" ? tasks[task].LastUsed : LastUsed
        };
        
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(_statePath, json);
    }
    
    public List<object> getLogs()
    {
        string json = File.ReadAllText(_logPath);
        List<object> logs = JsonSerializer.Deserialize<List<object>>(json);
        return logs;
    }

    public void addLog(int task = 0,
        string success = "",
        int FileTransferTime = 0)
    {
        List<object> logs = getLogs();
        TaskData[] tasks = getTasks();

        logs.Add(new LogData
        {
            Name = tasks[task].Name,
            SourceFilePath = tasks[task].SourceFilePath,
            TargetFilePath = tasks[task].TargetFilePath,
            success = success,
            FileSize = tasks[task].TotalFilesSize,
            FileTransferTime = FileTransferTime,
            Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        });
        
        string json = JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true });
        setTask(task, LastUsed: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        File.WriteAllText(_logPath, json);
    }
    
}