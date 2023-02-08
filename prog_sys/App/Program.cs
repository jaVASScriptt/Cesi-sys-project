using Controler;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;

public class program
{
	static void Main(string[] args)
	{
        Console.WriteLine("Donnez un nom pour la sauvegarde");
        String name = Console.ReadLine();

        Console.WriteLine("Donnez le chemin d'acces des fichiers a copier");
        string sourcePath = Console.ReadLine();

        Console.WriteLine("Donnez le chemin d'acces ou les fichiers vont se copier");
        string targetPath = Console.ReadLine();

        string[] fileNames = Directory.GetFiles(sourcePath);
        for (int i = 0; i < fileNames.Length; i++)
        {
            fileNames[i] = Path.GetFileName(fileNames[i]);
        }
        //string[] fileNames = Directory.GetFiles(sourcePath);


        /*for (int i = 0; i < numFiles; i++)
        {
            Console.WriteLine("Enter file name " + (i + 1) + ": ");
            fileNames[i] = Console.ReadLine();
        }*/
        

        //Avec les valeurs qu'il a rentré on crée un save
        Save save = new Save(name, sourcePath, targetPath);
        save.checkType(fileNames);

        Console.WriteLine("All files have been copied successfully.");
        Console.ReadLine();
    }
}