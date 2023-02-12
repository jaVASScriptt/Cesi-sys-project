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
    
}