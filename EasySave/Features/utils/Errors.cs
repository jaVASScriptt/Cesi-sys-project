using System;
using System.IO;
using System.Text.RegularExpressions;
using EasySafe;
using EasySave.Features.LogAndState.Data;

namespace ConsoleApp2.Features.utils;

public class Errors
{
    public static Boolean outOfRange(int index, TaskData[] t)
    {
        if (index >= 0 && index < t.Length)
            return false;
        return true;
    }
    
    public static Boolean emptyEntry(String? entry)
    {
        if (entry != "")
            return false;
        return true;
    }
    
    public static Boolean isGoodType(String type)
    {
        if (type == "complete" || type == "differential")
            return false;
        return true;
    }
    
    public static Boolean fileOrDirectoryNotExist(String path)
    {
        if (File.Exists(path) || Directory.Exists(path))
            return false;
        return true;
    }
    
    public static Boolean sourceIsTarget(String source, String target)
    {
        if (source != target)
            return false;
        return true;
    }


    public static bool isValidFileName(string fileName)
    {
        string pattern = @"^[\w\d\s]+$";
        return Regex.IsMatch(fileName, pattern);
    }

    public static bool validateFileName(string fileName)
    {
        if (!isValidFileName(fileName))
        {
            return false;
        }
        return true;
    }

}