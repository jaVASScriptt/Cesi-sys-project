using System.Text.Json;

namespace ConsoleApp2.Features.utils;

public class UtilsTool
{
    
    public static void modifyJson(List<object> list,  string Path)
    {
        string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(Path, json);
    }
    
    public static List<object>? getJson(string Path)
    {
        string json = File.ReadAllText(Path);
        return JsonSerializer.Deserialize<List<object>>(json);
    }

}