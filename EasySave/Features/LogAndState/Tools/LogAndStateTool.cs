using System;
using System.IO;

namespace EasySafe;

public sealed class LogAndStateTool
{
    private static object lockObject2 = new object();
    private static readonly LogAndStateTool instance = new LogAndStateTool();
    private static readonly Object lockObject = new Object();

    private static StateTool stateTool = new StateTool("");
    private static LogTool logTool = new LogTool("", stateTool);
    
    public static void changePath(string path)
    {
        stateTool = new StateTool(path);
        logTool = new LogTool(path, stateTool);
        LanguageTool.print("logPathChanged");
    }

    public static void addLog(int task = 0, string name = "", string SourceFilePath = "", string TargetFilePath = "", string success = "", long FileSize = 0, double FileTransferTime = 0)
    {
        lock (lockObject2)
        {
            logTool.addLog(task, name, SourceFilePath, TargetFilePath, success, FileSize, FileTransferTime);
        }
    }
    
    public static void showTasks(int task = 0) 
    {
        lock (lockObject2)
        {
            stateTool.showTasks();
        }
    }
    
    public static void addNewTask(string Name, string SourceFilePath, string TargetFilePath, string Type)
    {
        lock (lockObject2)
        {
            stateTool.addNewTask(Name, SourceFilePath, TargetFilePath, Type);
        }
    }

    public static TaskData getTask(int task = 0, string name = "")
    {
        TaskData taskDatum;
        lock (lockObject2)
        {
            taskDatum = stateTool.getTask(task, name);
        }
        return taskDatum;
    }

    public static void factoryFillOneState(int index)
    {
        lock (lockObject2)
        {
            stateTool.factoryFillOneState(index);
        }
    }

    public static void factoryFillState()
    {
        lock (lockObject2)
        {
            stateTool.factoryFillState();
        }
    }

    public static void addLocation()
    {
        lock (lockObject2)
        {
            stateTool.addLocation();
        }
    }

    public static void deleteLocation(int index)
    {
        lock (lockObject2)
        {
            stateTool.deleteLocation(index);
        }
    }
    public static void setTask(int index, string Name = "", string SourceFilePath = "", string TargetFilePath = "", string State = "", int TotalFilesToCopy = 0, long TotalFilesSize = 0, int NbFilesLeftToDo = 0, int Progression = 0, string Type = "", string LastUsed = "")
    {
        lock (lockObject2)
        {
            stateTool.setTask(index, Name, SourceFilePath, TargetFilePath, State, TotalFilesToCopy, TotalFilesSize, NbFilesLeftToDo, Progression, Type, LastUsed);
        }
    }

    public static void changeState(int index = 0, String name = "")
    {
        lock (lockObject2)
        {
            stateTool.changeState(index, name);
        }
    }

    public static int getTaskIndex(String name)
    {
        lock (lockObject2)
        {
            return stateTool.getTaskIndex(name);
        }
    }
    
    public static TaskData[]? getTasks() {
        TaskData[] tasks;
        lock (lockObject2)
        { 
            tasks = stateTool.getTasks();
        }
        return tasks;
    }

    public static void delAllSave()
    {
        lock (lockObject2)
        {
            stateTool.delAllSave();
        }
    }

}