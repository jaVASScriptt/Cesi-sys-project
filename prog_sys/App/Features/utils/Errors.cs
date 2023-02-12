namespace ConsoleApp2.Features.utils;

public class Errors
{
    public static Boolean outOfRange(int index, List<object> l)
    {
        if (index > 0 && index < l.Count - 1)
            return false;
        Console.WriteLine("Indice cesi en dehors de la liste");
        return true;
    }
    
}