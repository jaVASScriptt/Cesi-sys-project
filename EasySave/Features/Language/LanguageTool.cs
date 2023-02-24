using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp2.Features.utils;
using System.Text.Json;

namespace EasySave.Features.Language;

static class LanguageTool
{
    static List<object>? _strings;

    public static void SetLanguage(int language)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "../../../Features/Language/Data/";
        switch (language)
            {
                case 1:
                    _strings = UtilsTool.getJson(path + "fr.json");
                    return;
                case 2:
                    _strings = UtilsTool.getJson(path + "en.json");
                    return;
            }
    }

    public static string Get(string key)
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

}