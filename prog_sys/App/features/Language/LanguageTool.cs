using ConsoleApp2.Features.utils;
using System.Text.Json;

static class LanguageTool
{
    static List<object> strings;

    public static void setLanguage(string inputLanguage)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "../../../Features/Language/Data/";
        if (inputLanguage == "2")
            strings = utils.getJson(path + "en.json");
        else
            strings = utils.getJson(path + "fr.json");
    }

    public static string get(string key)
    {
        var item = (JsonElement)strings[0];
        return item.GetProperty(key).GetString();
    }
    
    public static string[] getChoice(string key)
    {
        var item = (JsonElement)strings[0];
        var array = item.GetProperty(key).EnumerateArray().Select(jv => jv.GetString()).ToArray();
        return array;
    }

    public static string print(string key = "", string entry = "")
    {
        Console.WriteLine("");
        Console.WriteLine(key == "" ? entry : get(key) );
        Console.WriteLine("");
        return Console.ReadLine();
    }

    public static int printInt(string key = "", string entry = "")
    {
        Console.WriteLine("");
        Console.WriteLine(key == "" ? entry : get(key));
        Console.WriteLine("");
        return Errors.NumberEntry();
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

        return Errors.NumberEntry();
    }
    
}