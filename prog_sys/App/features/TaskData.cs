namespace EasySafe;

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
    public string Type { get; set; }
    public string LastUsed { get; set; }
}