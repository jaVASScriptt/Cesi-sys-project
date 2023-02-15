using System.IO;

namespace EasySafe;

public sealed class LogAndStateTool
{

    private static readonly LogAndStateTool instance = new LogAndStateTool();
    private static readonly Object lockObject = new Object();

    private LogTool logTool;
    private StateTool stateTool;

    private LogAndStateTool(string path = "") {
        stateTool = new StateTool(path);
        logTool = new LogTool(path, stateTool);
    }
    public static LogAndStateTool Instance
    {
        get
        {
            lock(lockObject) 
            {
                return instance;
            }
        }
    }
    
    public void addLog(int task = 0, string name = "", string SourceFilePath = "", string TargetFilePath = "", string success = "", long FileSize = 0, double FileTransferTime = 0)
    {
        logTool.addLog(task, name, SourceFilePath, TargetFilePath, success, FileSize, FileTransferTime);
    }
    
    public void showTasks(int task = 0) { stateTool.showTasks(); }
    
    public void addNewTask(int task, string Name, string SourceFilePath, string TargetFilePath, int TotalFilesToCopy, long TotalFilesSize, int NbFilesLeftToDo, int Progression, string Type)
    {
        stateTool.addNewTask(task, Name, SourceFilePath, TargetFilePath, TotalFilesToCopy, TotalFilesSize, NbFilesLeftToDo, Progression, Type);
    }
    
    public TaskData getTask(int task = 0, string name = "") { return stateTool.getTask(task, name); }
    
    public void factoryFillOneState(int index) { stateTool.factoryFillOneState(index); }
    
    public void factoryFillState() { stateTool.factoryFillState(); }
    
    public void addLocation() { stateTool.addLocation(); }
    
    public void deleteLocation(int index) { stateTool.deleteLocation(index); }

<<<<<<< HEAD
    public void setTask(int index, string Name = "", string SourceFilePath = "", string TargetFilePath = "", string State = "", int TotalFilesToCopy = 0, long TotalFilesSize = 0, int NbFilesLeftToDo = 0, int Progression = 0, string Type = "", string LastUsed = "")
    {
        stateTool.setTask(index, Name, SourceFilePath, TargetFilePath, State, TotalFilesToCopy, TotalFilesSize, NbFilesLeftToDo, Progression, Type, LastUsed);
    }

    public void changeState(int index = 0, String name = "") { stateTool.changeState(index,name); }
=======
    public void setTask(int task = 0,
            string Name = "",
            string SourceFilePath = "",
            string TargetFilePath = "",
            string State = "",
            int TotalFilesToCopy = 0,
            long TotalFilesSize = 0,
            int NbFilesLeftToDo = 0,
            int Progression = 0,
            string Type = "complete",
            string LastUsed = "")
    {
        stateTool.setTask(task = 0,
            Name = "",
            SourceFilePath = "",
            TargetFilePath = "",
            State = "",
            TotalFilesToCopy = 0,
            TotalFilesSize = 0,
            NbFilesLeftToDo = 0,
            Progression = 0,
            Type = "complete",
            LastUsed = "");
    }
    
        public void changeState(int index = 0, String name = "") { stateTool.changeState(index,name); }
>>>>>>> cf27b5b7ecd5b00d6a5512425c084090ce669162
    
    public int getTaskIndex(String name) { return stateTool.getTaskIndex(name); }

}