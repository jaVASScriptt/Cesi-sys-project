using Controler;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;

public class program
{
	static void Main(string[] args)
	{
 
        Console.WriteLine("Enter file name: ");
        String name = Console.ReadLine();

        Console.WriteLine("Enter source path: ");
        String sourcePath = Console.ReadLine();

        Console.WriteLine("Enter target path: ");
        String targetPath = Console.ReadLine();

        Save save = new Save(name, sourcePath, targetPath);
        save.checkType(save);
        Console.ReadLine();
    }
}