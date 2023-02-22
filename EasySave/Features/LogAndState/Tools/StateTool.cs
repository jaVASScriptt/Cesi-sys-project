using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ConsoleApp2.Features.utils;

namespace EasySafe;

public class StateTool
{
    private string _statePath;

    public StateTool(string path)
    {
        if (string.IsNullOrEmpty(path))
            path = AppDomain.CurrentDomain.BaseDirectory + "../../../Features/LogAndState/Data/Files/State";
        else
            path += "/State";

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        _statePath = path + "/state.json";

        if (!File.Exists(_statePath))
            factoryFillState();
    }

    public void factoryFillState()
    {
        List<TaskData> tasks = new List<TaskData>();
        for (int i = 0; i < 5; i++)
            tasks.Add(new TaskData());

        UtilsTool.modifyJson(tasks.Cast<object>().ToList(), _statePath);
    }

    public void delAllSave()
    {
        using (StreamWriter writer = new StreamWriter(_statePath))
        {
            writer.WriteLine("[");
            writer.WriteLine("]");
        }
    }

    public void factoryFillOneState(int index)
    {

        TaskData[]? tasks = getTasks();

        if (!Errors.emptyEntry(tasks[index].Name)
           && !Errors.outOfRange(index, tasks))
        {
            tasks[index] = new TaskData();

            UtilsTool.modifyJson(tasks.Cast<object>().ToList(), _statePath);
            LanguageTool.print("saveDeleted");
        }

    }

    public TaskData[]? getTasks()
    {
        string json = File.ReadAllText(_statePath);
        TaskData[] tasks = JsonSerializer.Deserialize<TaskData[]>(json);
        return tasks;
    }

    public void showTasks()
    {
        Console.WriteLine("");
        Console.WriteLine(LanguageTool.get("taskConfig"));
        TaskData[] tasks = getTasks();

        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i].Name != "")
                Console.WriteLine(i + "] Name : " + tasks[i].Name + " --- origin: " + tasks[i].SourceFilePath +
                                  " / target: " + tasks[i].TargetFilePath + " / type : " + tasks[i].Type + " / state: " + tasks[i].State);
            else
                Console.WriteLine(i + LanguageTool.get("noTask"));
        }
        Console.WriteLine("");
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

        setTask(index, State: task.State == "END" ? "RUNNING" : "END");
    }

    public TaskData? getTask(int task = 0, String name = "")
    {

        TaskData[] tasks = getTasks();

        if (name != "")
        {
            foreach (var t in tasks)
            {
                if (t.Name == name)
                    return t;
            }
        }

        if (task >= 0 && task < tasks.Length)
            return tasks[task];
        return null;
    }

    public int getTaskIndex(String name)
    {
        TaskData[] tasks = getTasks();
        int index = 0;
        foreach (var t in tasks)
        {
            if (t.Name == name)
                return index;
            index++;
        }
        return -1;
    }

    public void addNewTask(
        string Name,
        string SourceFilePath,
        string TargetFilePath,
        string Type)
    {
        
        addLocation();
        TaskData[] tasks = getTasks();

        
            
            
            //Count all the files in the directory and its subdirectories
            int filesCountCase1 = 0;

            //Measurement of the file size
            long filesSizeCase1 = 0;

            foreach (string filePath in Directory.GetFiles(SourceFilePath, "*.*", SearchOption.AllDirectories))
            {
                filesCountCase1++;

                //Get the file size and add it to the total size
                FileInfo fileInfo = new FileInfo(filePath);
                filesSizeCase1 += fileInfo.Length;
            }
            
            setTask(tasks.Length-1, Name, SourceFilePath, TargetFilePath, State: "END", filesCountCase1, filesSizeCase1,
                filesCountCase1, 0, Type);
        

    }

    public void setTask(int task = 0,
        string Name = "",
        string SourceFilePath = "",
        string TargetFilePath = "",
        string State = "",
        int TotalFilesToCopy = 0,
        long TotalFilesSize = 0,
        int NbFilesLeftToDo = 0,
        int Progression = 0,
        string type = "",
        string LastUsed = "")
    {
        List<TaskData> tasks = getTasks().ToList();

        tasks[task] = new TaskData
        {
            Name = Name == "" ? tasks[task].Name : Name,
            SourceFilePath = SourceFilePath == "" ? tasks[task].SourceFilePath : SourceFilePath,
            TargetFilePath = TargetFilePath == "" ? tasks[task].TargetFilePath : TargetFilePath,
            State = State == "" ? tasks[task].State : State,
            TotalFilesToCopy = TotalFilesToCopy == 0 ? tasks[task].TotalFilesToCopy : TotalFilesToCopy,
            TotalFilesSize = TotalFilesSize == 0 ? tasks[task].TotalFilesSize : TotalFilesSize,
            NbFilesLeftToDo = NbFilesLeftToDo == 0 ? tasks[task].NbFilesLeftToDo : NbFilesLeftToDo,
            Progression = Progression == 0 ? tasks[task].Progression : Progression,
            Type = type == "" ? tasks[task].Type : type,
            LastUsed = LastUsed == "" ? tasks[task].LastUsed : LastUsed
        };

        UtilsTool.modifyJson(tasks.Cast<object>().ToList(), _statePath);
    }

    public void addLocation()
    {
        List<TaskData> tasks = getTasks().ToList();
        tasks.Add(new TaskData());
        UtilsTool.modifyJson(tasks.Cast<object>().ToList(), _statePath);
    }

    public void deleteLocation(int task)
    {
        List<TaskData> tasks = getTasks().ToList();
        if (Errors.outOfRange(task, getTasks()))
            task = tasks.Count - 1;
        tasks.RemoveAt(task);
        UtilsTool.modifyJson(tasks.Cast<object>().ToList(), _statePath);
    }

}