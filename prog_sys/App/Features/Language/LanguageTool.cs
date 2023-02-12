using ConsoleApp2.Features.utils;
using System.Text.Json;

static class Language
{
    static List<object> strings;
    static string selectedLanguage = "";

    public static void setLanguage(string inputLanguage)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "../../../Features/Language/Data/";
        if (inputLanguage == "2")
            strings = utils.getJson(path + "en.json");
        else
            strings = utils.getJson(path + "fr.json");
        
        Console.WriteLine(get("defaultMessage"));
    }

    public static string get(string key)
    {
        var item = (JsonElement)strings[0];
        return item.GetProperty(key).GetString();
    }
}