using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace srdceZeZeleza;

public class Data
{
    public static Dictionary<string, Battalion> BattalionLibrary { get; set; } = new();

    public static void LoadData()
    {
        string json = File.ReadAllText("battalion.json");
        BattalionLibrary = JsonSerializer.Deserialize<Dictionary<string, Battalion>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}