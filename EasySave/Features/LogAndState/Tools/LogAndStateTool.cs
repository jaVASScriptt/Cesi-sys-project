using System;
using System.IO;

namespace EasySafe;

public sealed class LogAndStateTool
{

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
        logTool.addLog(task, name, SourceFilePath, TargetFilePath, success, FileSize, FileTransferTime);
    }
    
    public static void showTasks(int task = 0) { stateTool.showTasks(); }
    
    public static void addNewTask(int task, string Name, string SourceFilePath, string TargetFilePath, int TotalFilesToCopy, long TotalFilesSize, int NbFilesLeftToDo, int Progression, string Type)
    {
        stateTool.addNewTask(task, Name, SourceFilePath, TargetFilePath, TotalFilesToCopy, TotalFilesSize, NbFilesLeftToDo, Progression, Type);
    }
    
    public static TaskData getTask(int task = 0, string name = "") { return stateTool.getTask(task, name); }
    
    public static void factoryFillOneState(int index) { stateTool.factoryFillOneState(index); }
    
    public static void factoryFillState() { stateTool.factoryFillState(); }
    
    public static void addLocation() { stateTool.addLocation(); }
    
    public static void deleteLocation(int index) { stateTool.deleteLocation(index); }
    public static void setTask(int index, string Name = "", string SourceFilePath = "", string TargetFilePath = "", string State = "", int TotalFilesToCopy = 0, long TotalFilesSize = 0, int NbFilesLeftToDo = 0, int Progression = 0, string Type = "", string LastUsed = "")
    {
        stateTool.setTask(index, Name, SourceFilePath, TargetFilePath, State, TotalFilesToCopy, TotalFilesSize, NbFilesLeftToDo, Progression, Type, LastUsed);
    }

    public static void changeState(int index = 0, String name = "") { stateTool.changeState(index,name); }

    public static int getTaskIndex(String name) { return stateTool.getTaskIndex(name); }
    
    public static TaskData[]? getTasks() { return stateTool.getTasks();}

}