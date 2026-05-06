using System.IO;
using System.Text.Json;

namespace srdceZeZeleza;

public class Division
{
    public string Name;
    
    public string[] SupportColumn = new string[5];
    public string[][] CombatBlock = new string[5][];
    
    public Statistics Stats { get; set; } = new Statistics();
    public Requirements Req { get; set; } = new Requirements();

    public Statistics CalculateDivisionStatistics()
    {
        
    }
    
    public Requirements CalculateDivisionRequirements()
    {
        
    }

    public Division(string name)
    {
        Name = name;
        Stats = CalculateDivisionStatistics();
        Req = CalculateDivisionRequirements();
    }
}