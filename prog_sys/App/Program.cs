using Controler;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;

public class program
{
	static void Main(string[] args)
	{
        Save save = new Save();
        save.GetValues();
        save.checkType();
        Console.ReadLine();
    }
}