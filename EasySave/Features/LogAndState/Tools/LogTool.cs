using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using ConsoleApp2.Features.utils;

namespace EasySafe;

public class LogTool
{
    
    private string? _logPath;
    private string? _logXmlPath;
    private string? _dayPathJson;
    private string? _dayPathXml;
    private string? generalPath;
    private StateTool? stateTool;
    
    public LogTool(string path, StateTool stateTool)
    {
        if (string.IsNullOrEmpty(path))
            path = AppDomain.CurrentDomain.BaseDirectory + "../../../Features/LogAndState/Data/Files/Log";
        else
        {
            path += "/Log";
            generalPath = path;
        }
        
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
        
        _logPath = path + "/log.json";
        _logXmlPath = path + "/log.xml";
        this.stateTool = stateTool;
        
        if (!File.Exists(_logPath))
            factoryFillLogs(_logPath);

        if (!File.Exists(_logXmlPath))
            factoryFillXmlLogs(_logXmlPath);
    }
    
    public void factoryFillLogs(string path)
    {
        using (StreamWriter writer = new StreamWriter(path))  
        {  
            writer.WriteLine("[");  
            writer.WriteLine("]");
        }  
    }
    
    public void factoryFillXmlLogs(string path)
    {
        using (StreamWriter writer = new StreamWriter(path))  
        {  
            writer.WriteLine("<logs>");  
            writer.WriteLine("</logs>");
        }  
    }
    
    public List<object> getLogs() { return UtilsTool.getJson(_logPath); }
    public List<object> getDailyLogs() { return UtilsTool.getJson(_dayPathJson); }

    public void addLog(int task = 0,
        string name = "",
        string SourceFilePath = "",
        string TargetFilePath = "",
        string success = "",
        long FileSize = 0,
        double FileTransferTime = 0)
    {
        addClassicLog(task , name, SourceFilePath, TargetFilePath, success, FileTransferTime);
        checkAndCreateDayFolder();
        addClassicLog(task , name, SourceFilePath, TargetFilePath, success, FileTransferTime, FileSize, true);
    }
    public void addClassicLog(int task = 0,
        string name = "",
        string SourceFilePath = "",
        string TargetFilePath = "",
        string success = "",
        double FileTransferTime = 0,
        long FileSize = 0,
        bool daily = false)
    {
        List<object> logs = daily ? getDailyLogs() : getLogs();
        TaskData[] tasks = stateTool.getTasks();

        LogData logData = new LogData
        {
            Name = name == ""? tasks[task].Name : name,
            SourceFilePath = SourceFilePath == ""? tasks[task].SourceFilePath : SourceFilePath,
            TargetFilePath = TargetFilePath == ""? tasks[task].TargetFilePath : TargetFilePath,
            success = success,
            FileSize = FileSize,
            FileTransferTime = FileTransferTime,
            Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        };
    
        logs.Add(logData);
        
        UtilsTool.modifyJson(logs, daily ? _dayPathJson : _logPath);

        XElement log = new XElement("log");
        log.Add(new XElement("Name", logData.Name));
        log.Add(new XElement("SourceFilePath", logData.SourceFilePath));
        log.Add(new XElement("TargetFilePath", logData.TargetFilePath));
        log.Add(new XElement("Success", logData.success));
        log.Add(new XElement("FileSize", logData.FileSize.ToString()));
        log.Add(new XElement("FileTransferTime", logData.FileTransferTime.ToString()));
        log.Add(new XElement("Time", logData.Time));
        
        XDocument doc = XDocument.Load(daily? _dayPathXml : _logXmlPath);
        doc.Element("logs").Add(log);
        doc.Save(daily? _dayPathXml : _logXmlPath);

        stateTool.setTask(task, LastUsed: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
    }
    
    public void checkAndCreateDayFolder()
    {
        string day = DateTime.Now.ToString("dd-MM-yyyy");
        string path;
        
        if (generalPath == null) 
            path = AppDomain.CurrentDomain.BaseDirectory + "../../../Features/LogAndState/Data/Files/Log/DailyLogs";
        else
            path = generalPath + "/DailyLogs";

        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);

        _dayPathJson = path + "/Json/";
        if(!Directory.Exists(_dayPathJson))
            Directory.CreateDirectory(_dayPathJson);
        _dayPathJson += day + "-log.json";
        
        _dayPathXml = path + "/XML/";
        if (!Directory.Exists(_dayPathXml))
            Directory.CreateDirectory(_dayPathXml);
        _dayPathXml += day + "-log.xml";
        
        if (!File.Exists(_dayPathJson))
            factoryFillLogs(_dayPathJson);

        if (!File.Exists(_dayPathXml))
            factoryFillXmlLogs(_dayPathXml);
    }

}