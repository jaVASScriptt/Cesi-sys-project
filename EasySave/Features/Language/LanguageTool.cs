using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp2.Features.utils;
using System.Text.Json;

static class LanguageTool
{
    static List<object>? _strings;

    public static void setLanguage(int Language)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "../../../Features/Language/Data/";
        switch (Language)
            {
                case 1:
                    _strings = UtilsTool.getJson(path + "fr.json");
                    return;
                case 2:
                    _strings = UtilsTool.getJson(path + "en.json");
                    return;
            }
    }

    public static string get(string key)
    {
        try
        {
            var item = (JsonElement)_strings[0];
            return item.GetProperty(key).GetString();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    public static string?[] getChoice(string key)
    {
        var item = (JsonElement)_strings[0];
        var array = item.GetProperty(key).EnumerateArray().Select(jv => jv.GetString()).ToArray();
        return array;
    }

    public static string print(string key = "", string entry = "")
    {
        Console.WriteLine("");
        Console.WriteLine(key == "" ? entry : get(key) );
        Console.WriteLine("");
        return key == "" ? entry : Console.ReadLine();
    }

    public static int printInt(string key = "", string entry = "")
    {
        Console.WriteLine("");
        Console.WriteLine(key == "" ? entry : get(key));
        Console.WriteLine("");
        return 0;
    }
    
    public static int printAndRescueChoice(string key)
    {
        Console.WriteLine("");
        var array = getChoice(key);
        var columnWidth = 20;
        
        int longueurMax = 0;
        string motLePlusLong = "";

        foreach (string mot in array)
        {
            if (mot.Length > longueurMax)
            {
                longueurMax = mot.Length;
                motLePlusLong = mot;
            }
        }
        
        var separatorRow = string.Join("", Enumerable.Repeat("_", motLePlusLong.Length + 25));
        var question = string.Join("", Enumerable.Repeat(" ", (motLePlusLong.Length + 25 - get("defaultMessage").Length)/2)) + get("defaultMessage");
        Console.WriteLine(separatorRow);
        Console.WriteLine(question);
        Console.WriteLine(separatorRow);
        
        for (int i = 0; i < array.Length; i++)
        {
            var index = (i + 1).ToString().PadLeft(7);
            var value = array[i].PadRight(columnWidth);
            var job = $"| {index} || {value} ";
            while (job.Length < separatorRow.Length - 1)
                job += " "; 
            Console.WriteLine(job + "|");
        }

        Console.WriteLine(separatorRow);
        Console.WriteLine("");

        return 0;
    }
    
}