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
    
    public static Boolean fileNotExist(String path)
    {
        if (File.Exists(path))
            return false;
        Console.WriteLine("Le chemin n'existe pas");
        return true;
    }
    
}