using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace srdceZeZeleza;

public class divisionDesigner
{
    private Texture2D textura;
    
    public int SupportSize {get; private set;}
    public int CombatBoxSizeX {get; private set;}
    public int CombatBoxSizeY {get; private set;}
    
    public string[] SupportColumn { get; private set; } //{ "+", "+", "+", "+", "+" };
    public string[][] CombatBox { get; private set; }

    public void Draw(GraphicsDeviceManager graphics, GraphicsDevice device, Color barva)
    {
        
    }
}