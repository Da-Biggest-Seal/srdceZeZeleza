using System.IO;
using System.Text.Json;

namespace srdceZeZeleza;

public class Division
{
    public string Name;
    
    public string[] SupportColumn = new string[5];
    public string[,] CombatBlock = new string[5, 5];
    
    public Statistics Stats { get; set; } = new Statistics();
    public Requirements Req { get; set; } = new Requirements();
    
    string jsonString = File.ReadAllText("battalion.json");
    

    public Division()
    {
        //initialize the arrays
        for (int i = 0; i < SupportColumn.Length; i++) SupportColumn[i] = "";

        for (int i = 0; i < CombatBlock.GetLength(0); i++)
        {
            for (int j = 0; j < CombatBlock.GetLength(1); j++)
            {
                CombatBlock[i, j] = "";
            }
        }
    }
}