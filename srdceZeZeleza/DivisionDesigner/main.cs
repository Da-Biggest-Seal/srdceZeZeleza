using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace srdceZeZeleza;

public class main : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Data battalionData;

    Country ger;
    
    bool lmb;
    bool rmb;

    bool prevLmb = false;
    bool prevRmb = false;

    public main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        battalionData = new Data("Jsons/battalion.json");

        ger = new Country("German Reich", "Countries/Country1");
        
        Division inf = ger.DivisionStats["Infantry"];
        
        Console.WriteLine($"{inf.Name}:\n    Soft={inf.Stats.Soft}");
        foreach (var (eqName, amount) in inf.Req.Equipment)
            Console.WriteLine($"    {eqName}={amount}");
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        lmb = Mouse.GetState().LeftButton == ButtonState.Pressed;
        rmb = Mouse.GetState().RightButton == ButtonState.Pressed;

        if (lmb && !prevLmb) ger.NewDivision("TempDiv", "temp");
        if (rmb && !prevRmb) ger.DeleteDivision("temp");

        if (ger.DivisionStats.ContainsKey("temp"))
        {
            Console.WriteLine($"{ger.DivisionStats["temp"].Name}:\n    Soft={ger.DivisionStats["temp"].Stats.Soft}");
            foreach (var (eqName, amount) in ger.DivisionStats["temp"].Req.Equipment)
                Console.WriteLine($"    {eqName}={amount}");
        }
        
        prevLmb = lmb;
        prevRmb = rmb;
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}