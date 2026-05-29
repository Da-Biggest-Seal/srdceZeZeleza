using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace srdceZeZeleza;

public class Country
{
    public string Name { get; private set; }
    public string CountryFolderPath { get; private set; }
    public string CountryDivisionPath { get; private set; }
    public Data BattalionLibrary { get; private set; }
    
    public Country(string name, string folderPath)
    {
        Name = name;
        CountryFolderPath = folderPath;
        
        BattalionLibrary = Data.BattalionLibrary("Jsons/battalion.json");
        CountryDivisionPath = CountryFolderPath + "/division.json";
    }
    
    public void NewDivision(string divJsonPath, string name, string codeName)
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