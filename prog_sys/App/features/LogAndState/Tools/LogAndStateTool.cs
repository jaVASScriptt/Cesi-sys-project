namespace EasySafe;

public class LogAndStateTool
{

    private LogTool logTool;
    private StateTool stateTool;
    public LogAndStateTool(string path = "")
    {
        stateTool = new StateTool(path);
        logTool = new LogTool(path, stateTool);
    }
    
    public void addLog(int task = 0, string name = "", string SourceFilePath = "", string TargetFilePath = "", string success = "", long FileSize = 0, double FileTransferTime = 0)
    {
        logTool.addLog(task, name, SourceFilePath, TargetFilePath, success, FileSize, FileTransferTime);
    }
    
    public void showTasks(int task = 0) { stateTool.showTasks(); }
    
    public void addNewTask(int task, string Name, string SourceFilePath, string TargetFilePath, int TotalFilesToCopy, int TotalFilesSize, int NbFilesLeftToDo, int Progression, string Type)
    {
        stateTool.addNewTask(task, Name, SourceFilePath, TargetFilePath, TotalFilesToCopy, TotalFilesSize, NbFilesLeftToDo, Progression, Type);
    }
    
    public TaskData getTask(int task = 0, string name = "") { return stateTool.getTask(task, name); }
    
    public void factoryFillOneState(int index) { stateTool.factoryFillOneState(index); }
    
    public void factoryFillState() { stateTool.factoryFillState(); }
    
    public void addLocation() { stateTool.addLocation(); }
    
    public void deleteLocation(int index) { stateTool.deleteLocation(index); }

}