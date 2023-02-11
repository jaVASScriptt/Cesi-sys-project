using System.Xml.Linq;
using ConsoleApp2.Features.utils;

namespace EasySafe;

public class LogTool
{
    
    private string _logPath;
    private string _logXmlPath;
    private StateTool stateTool;
    
    public LogTool(string path, StateTool stateTool)
    {
        if (string.IsNullOrEmpty(path))
            path = AppDomain.CurrentDomain.BaseDirectory + "../../../Features/LogAndState/Data/Files";
        
        _logPath = path + "/log.json";
        _logXmlPath = path + "/log.xml";
        this.stateTool = stateTool;
        
        if (!File.Exists(_logPath))
            factoryFillLogs();

        if (!File.Exists(_logXmlPath))
            factoryFillXmlLogs();
    }
    
    public void factoryFillLogs()
    {
        using (StreamWriter writer = new StreamWriter(_logPath))  
        {  
            writer.WriteLine("[");  
            writer.WriteLine("]");
        }  
    }
    
    public void factoryFillXmlLogs()
    {
        using (StreamWriter writer = new StreamWriter(_logXmlPath))  
        {  
            writer.WriteLine("<logs>");  
            writer.WriteLine("</logs>");
        }  
    }
    
    public List<object> getLogs() { return utils.getJson(_logPath); }

    public void addLog(int task = 0,
        string name = "",
        string SourceFilePath = "",
        string TargetFilePath = "",
        string success = "",
        int FileTransferTime = 0)
    {
        List<object> logs = getLogs();
        TaskData[] tasks = stateTool.getTasks();

        LogData logData = new LogData
        {
            Name = name == ""? tasks[task].Name : name,
            SourceFilePath = SourceFilePath == ""? tasks[task].SourceFilePath : SourceFilePath,
            TargetFilePath = TargetFilePath == ""? tasks[task].TargetFilePath : TargetFilePath,
            success = success,
            FileSize = tasks[task].TotalFilesSize,
            FileTransferTime = FileTransferTime,
            Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        };
    
        logs.Add(logData);
        
        utils.modifyJson(logs, _logPath);

        XElement log = new XElement("log");
        log.Add(new XElement("Name", logData.Name));
        log.Add(new XElement("SourceFilePath", logData.SourceFilePath));
        log.Add(new XElement("TargetFilePath", logData.TargetFilePath));
        log.Add(new XElement("Success", logData.success));
        log.Add(new XElement("FileSize", logData.FileSize.ToString()));
        log.Add(new XElement("FileTransferTime", logData.FileTransferTime.ToString()));
        log.Add(new XElement("Time", logData.Time));
        
        XDocument doc = XDocument.Load(_logXmlPath);
        doc.Element("logs").Add(log);
        doc.Save(_logXmlPath);

        stateTool.setTask(task, LastUsed: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
    }
    
}