namespace EasySafe;

public class LogData
{
    public string? Name { get; set; }
    public string? SourceFilePath { get; set; }
    public string? TargetFilePath { get; set; }
    public string? success { get; set; }
    public long FileSize { get; set; }
    public double FileTransferTime { get; set; }
    public string? Time { get; set; }
}