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
    public Dictionary<> Divisions { get; set; }
    public static Dictionary<string, DivisionData> TemplateData { get; private set; } = new();
    
    public Country(string name, string folderPath)
    {
        Name = name;
        CountryFolderPath = folderPath;
        
        BattalionLibrary = new Data("Jsons/battalion.json");
        CountryDivisionPath = CountryFolderPath + "/division.json";
        
        //deserialize
        string json = File.ReadAllText(CountryDivisionPath);
        CountryDivisionLibrary = JsonSerializer.Deserialize<Dictionary<string, DivisionData>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        TemplateData = JsonSerializer.Deserialize<Dictionary<string, DivisionData>>(TemplateDataPath, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        //get the divisions into a dict
        
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