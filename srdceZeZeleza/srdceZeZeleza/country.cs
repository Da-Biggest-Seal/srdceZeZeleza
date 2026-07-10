using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace srdceZeZeleza;

public class Country
{
    public string Name { get; private set; }
    public string CountryFolderPath { get; private set; }
    public string CountryDivisionPath { get; private set; }
    public static string TemplateDataPath = "Jsons/template.json";
    public Data BattalionLibrary { get; private set; }
    public Dictionary<string, DivisionData> CountryDivisionLibrary { get; private set; }
    public Dictionary<string, Division> DivisionStats { get; set; } = new();
    public static Dictionary<string, DivisionData> TemplateData { get; private set; } = new();
    
    public Country(string name, string folderPath)
    {
        Name = name;
        CountryFolderPath = folderPath;
        
        BattalionLibrary = new Data("Jsons/battalion.json");
        CountryDivisionPath = CountryFolderPath + "/division.json";
        
        //deserialize
        string jsonDivData = File.ReadAllText(CountryDivisionPath);
        CountryDivisionLibrary = JsonSerializer.Deserialize<Dictionary<string, DivisionData>>(jsonDivData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        string jsonDiv = File.ReadAllText(TemplateDataPath);
        TemplateData = JsonSerializer.Deserialize<Dictionary<string, DivisionData>>(jsonDiv, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        DivisionStats = SyncDivisionsWithDivData(CountryDivisionLibrary);
    }

    private Dictionary<string, Division> SyncDivisionsWithDivData(Dictionary<string, DivisionData> divData)
    {
        Dictionary<string, Division> Divisions = new();
        
        foreach ((string codename, DivisionData data) in divData)
        {
            Divisions.Add(codename, new Division(divData[codename]));
        }
        
        return Divisions;
    }
    
    public void NewDivision(string name, string codeName)
    {
        //will add a new entry to the json - from template.json where will all templates stored
        CountryDivisionLibrary.Add(codeName, TemplateData["division"]);
        CountryDivisionLibrary[codeName].Name = name;
    }

    public void DeleteDivision(string codeName)
    {
        //will delete a division that has the same codeName as inputed, would be better if it looked for the normal Name
        CountryDivisionLibrary.Remove(codeName);
    }
}