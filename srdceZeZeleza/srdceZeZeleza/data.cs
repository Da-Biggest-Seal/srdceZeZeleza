using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace srdceZeZeleza;

public class Data
{
    public static Dictionary<string, Battalion> BattalionLibrary { get; set; } = new();
    public string JsonPath{ get; private set; }
    
    public Data(string jsonPath)
    {
        JsonPath = jsonPath;
        
        string json = File.ReadAllText(JsonPath);
        BattalionLibrary = JsonSerializer.Deserialize<Dictionary<string, Battalion>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public void Testing()
    {
        Console.WriteLine(File.ReadAllText(JsonPath));

        foreach ((string entry, Battalion battalion) in BattalionLibrary)
        {
            Console.WriteLine($"Name: {entry}");
            Console.WriteLine($"  Stats: Soft={battalion.Stats.Soft}, Hard={battalion.Stats.Hard}, HP={battalion.Stats.Hp}, Org={battalion.Stats.Org}");
            Console.WriteLine($"  Req: Manpower={battalion.Req.Manpower}");
            foreach ((string eqName, int amount) in battalion.Req.Equipment)
            {
                Console.WriteLine($"    Equipment: {eqName}={amount}");
            }
        }
    }
}