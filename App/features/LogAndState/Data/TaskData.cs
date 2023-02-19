namespace EasySafe;

public class TaskData
{
    public string Name { get; set; }
    public string SourceFilePath { get; set; }
    public string TargetFilePath { get; set; }
    public string State { get; set; }
    public int TotalFilesToCopy { get; set; }
    public long TotalFilesSize { get; set; }
    public int NbFilesLeftToDo { get; set; }
    public int Progression { get; set; }
    public string Type { get; set; }
    public string LastUsed { get; set; }
    
    public TaskData()
    {
        Name = "";
        SourceFilePath = "";
        TargetFilePath = "";
        State = "END";
        TotalFilesToCopy = 0;
        TotalFilesSize = 0;
        NbFilesLeftToDo = 0;
        Progression = 0;
        Type = "complete";
        LastUsed = "";
    }
}