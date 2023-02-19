using System;
using System.IO;
using System.Text.RegularExpressions;
using EasySafe;

namespace ConsoleApp2.Features.utils;

public class Errors
{
    public static Boolean outOfRange(int index, TaskData[] t)
    {
        if (index >= 0 && index < t.Length)
            return false;
        LanguageTool.print("outOfRange");
        return true;
    }
    
    public static Boolean emptyEntry(String? entry)
    {
        if (entry != "")
            return false;
        LanguageTool.print("EmptyEntry");
        return true;
    }
    
    public static Boolean isGoodType(String type)
    {
        if (type == "complete" || type == "differential")
            return false;
        LanguageTool.print("isGoodType");
        return true;
    }
    
    public static Boolean fileOrDirectoryNotExist(String path)
    {
        if (File.Exists(path) || Directory.Exists(path))
            return false;
        LanguageTool.print("fileOrDirectoryNotExist");
        return true;
    }
    
    public static Boolean sourceIsTarget(String source, String target)
    {
        if (source != target)
            return false;
        LanguageTool.print("sourceIsTarget");
        return true;
    }
    
    public static int numberEntry()
    {
        string? number = Console.ReadLine();
        while (true)
        {
            try
            {
                return Convert.ToInt32(number);
            }
            catch (Exception e)
            {
                number = LanguageTool.print("NumberEntry");
            }
        }
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
            Console.WriteLine(
                "Le nom de fichier contient des caractères non valides. Veuillez entrer un nom de fichier valide. (appuyez sur une touche pour continuer)");
            return false;
        }
        return true;
    }

}