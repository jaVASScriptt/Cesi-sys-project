using Controler;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;

public class program
{
	static void Main(string[] args)
	{
        Console.WriteLine("donner un nom pour la sauvegarde");
        String nameSave = Console.ReadLine();

        Console.WriteLine("combien de fichiers à sauvegarder ?");
        int numFiles = int.Parse(Console.ReadLine());

        Console.WriteLine("donnez le chemin d'acces des fichiers a copier");
        string sourcePath = Console.ReadLine();

        Console.WriteLine("donnez le chemin d'acces ou les fichiers vont se copier");
        string targetPath = Console.ReadLine();

        string[] fileNames = new string[numFiles];
        //string[] fileNames = Directory.GetFiles(sourcePath);

        
        for (int i = 0; i < numFiles; i++)
        {
            Console.WriteLine("Enter file name " + (i + 1) + ": ");
            fileNames[i] = Console.ReadLine();
        }
        

        //Avec les valeurs qu'il a rentré on crée un save
        foreach (string fileName in fileNames)
        {
            Save save = new Save(fileName, sourcePath, targetPath);
            save.checkType();
        }

        Console.WriteLine("All files have been copied successfully.");
        Console.ReadLine();
    }
}