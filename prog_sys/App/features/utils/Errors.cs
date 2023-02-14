using System.Text.RegularExpressions;
using EasySafe;

namespace ConsoleApp2.Features.utils;

public class Errors
{
    public static Boolean outOfRange(int index, TaskData[] t)
    {
        if (index > 0 && index < t.Length - 1)
            return false;
        Console.WriteLine("Indice cesi en dehors de la liste");
        return true;
    }
    
    public static Boolean EmptyEntry(String entry)
    {
        if (entry != "")
            return false;
        Console.WriteLine("Champ vide");
        return true;
    }
    
    public static Boolean isGoodType(String type)
    {
        if (type == "complete" || type == "differential")
            return false;
        Console.WriteLine("Type incorrect");
        return true;
    }
    
    public static Boolean fileOrDirectoryNotExist(String path)
    {
        if (File.Exists(path) || Directory.Exists(path))
            return false;
        Console.WriteLine("Le chemin n'existe pas");
        return true;
    }
    
    public static Boolean sourceIsTarget(String source, String target)
    {
        if (source != target)
            return false;
        Console.WriteLine("Le chemin source et cible sont identiques");
        return true;
    }
    
    public static int NumberEntry()
    {
        string number = Console.ReadLine();
        while (true)
        {
            try
            {
                return Convert.ToInt32(number);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ce n'est pas un nombre! veuillez réessayer!");
                number = Console.ReadLine();
            }
        }
    }
    

    public static bool IsValidFileName(string fileName)
    {
        string pattern = @"^[\w\d\s]+$";
        return Regex.IsMatch(fileName, pattern);
    }

    public static bool ValidateFileName(string fileName)
    {
        if (!IsValidFileName(fileName))
        {
            Console.WriteLine("Le nom de fichier contient des caractères non valides. Veuillez entrer un nom de fichier valide.");
            return false;
        }
        return true;
    }
    
    
    
}