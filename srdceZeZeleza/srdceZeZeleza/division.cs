using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace srdceZeZeleza;

public class DivisionData
{
    public string Name {get; set;}
    
    [JsonPropertyName("SupportColumn")]
    public string[] StringSupportColumn { get; set; }
    
    [JsonPropertyName("CombatBlock")]
    public string[][] StringCombatBlock { get; set; }
}

public class Division
{
    public static Dictionary<string, DivisionData> CountryDivisionLibrary { get; set; } = new();
    public string Name {get; set;}
    
    public Battalion[] SupportColumn = new Battalion[5];
    public Battalion[][] CombatBlock = new Battalion[5][];
    
    public Statistics Stats { get; set; } = new Statistics();
    public Requirements Req { get; set; } = new Requirements();
    
    public Division(string divisionCodeName)
    {
        Dictionary<Battalion, int> battalionCounter = new();

        //loop through the deserialized json
        DivisionData divData = CountryDivisionLibrary[divisionCodeName];
        {
            Name = divData.Name;
            
            for (int x = 0; x < divData.StringCombatBlock.Length; x++)
            {
                //create the second array in main array, size of the deserialized y-axis list
                CombatBlock[x] = new Battalion[divData.StringCombatBlock[x].Length];
                
                for (int y = 0; y < divData.StringCombatBlock[x].Length; y++)
                {
                    if (!(string.IsNullOrEmpty(divData.StringCombatBlock[x][y])))
                    {
                        //assign battalions to the array
                        CombatBlock[x][y] = Data.BattalionLibrary[divData.StringCombatBlock[x][y]];

                        //battalion counter
                        if (!(battalionCounter.ContainsKey(CombatBlock[x][y])))
                        {
                            battalionCounter.Add(CombatBlock[x][y], 1);
                        }
                        
                        else battalionCounter[CombatBlock[x][y]]++;
                    }
                }
            }

            //same for the support column
            for (int i = 0; i < divData.StringSupportColumn.Length; i++)
            {
                if (!(string.IsNullOrEmpty(divData.StringSupportColumn[i])))
                {
                    SupportColumn[i] = Data.BattalionLibrary[divData.StringSupportColumn[i]];
                    
                    if (!(battalionCounter.ContainsKey(SupportColumn[i])))
                    {
                        battalionCounter.Add(SupportColumn[i], 1);
                    }
                        
                    else battalionCounter[SupportColumn[i]]++;
                }
            }
        }

        Statistics stats = Stats;
        Requirements req = Req;
        int oldSpeed = 1024; //sorry for the magic number, but it has to be a big number, will get overwritten imminently
        
        foreach ((Battalion battalion, int count) in battalionCounter)
        {
            stats.Soft += count * battalion.Stats.Soft;
            stats.Hard += count * battalion.Stats.Hard;
            stats.Air += count * battalion.Stats.Air;
            stats.Hp += count * battalion.Stats.Hp;
            stats.Org += count * battalion.Stats.Org;

            if (battalion.Stats.Speed < oldSpeed && battalion.Type != "support") stats.Speed = battalion.Stats.Speed;
            
            req.Manpower += count * battalion.Req.Manpower;
            foreach ((string eqName, int amount) in battalion.Req.Equipment)
            {
                if (!req.Equipment.ContainsKey(eqName))
                    req.Equipment.Add(eqName, count * amount);
                else
                    req.Equipment[eqName] += count * amount;
            }
            
            oldSpeed = battalion.Stats.Speed;
        }
        
        Stats = stats;
        Req = req;
    }

    public void Testing(string countryDivisionJsonPath)
    {
        foreach (Battalion[] row in CombatBlock)
        {
            foreach (Battalion b in row)
            {
                if (b != null) Console.Write($"[{b.Name}]");
                else Console.Write("empty");
            }
        }
        
        foreach (Battalion support in SupportColumn) Console.WriteLine(support);
    }

    //-------------------------------------//
    // THIS HAS TO BE MOVED SOMEWHERE ELSE //
    //-------------------------------------//
    

    public void Change(string codeName, int x, int y, Battalion newBattalion)
    {
        //will change battalion on position x,y for a different one that can be put there
        CombatBlock[x][y] = newBattalion;
    }
}