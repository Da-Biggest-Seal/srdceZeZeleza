using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace srdceZeZeleza;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Data data;
    Division division_0;
    Division division_1;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        data = new Data("Jsons/battalion.json");
        division_0 = new Division("Countries/Country1/division.json", "Infantry");
        division_1 = new Division("Countries/Country1/division.json", "Infantry_6");
        
        Console.WriteLine(division_0.Name);
        Console.WriteLine($"S={division_0.Stats.Soft}, H={division_0.Stats.Hard}, A={division_0.Stats.Air}, HP={division_0.Stats.Hp}, O={division_0.Stats.Org}, SP={division_0.Stats.Speed}");
        
        Console.WriteLine($"Manpower={division_0.Req.Manpower}");
            
        foreach ((string eqName, int amount) in division_0.Req.Equipment)
        {
            Console.WriteLine($"    Equipment: {eqName}={amount}");
        }
        
        Console.WriteLine(division_1.Name);
        Console.WriteLine($"S={division_1.Stats.Soft}, H={division_1.Stats.Hard}, A={division_1.Stats.Air}, HP={division_1.Stats.Hp}, O={division_1.Stats.Org}, SP={division_1.Stats.Speed}");
        
        Console.WriteLine($"Manpower={division_1.Req.Manpower}");
            
        foreach ((string eqName, int amount) in division_1.Req.Equipment)
        {
            Console.WriteLine($"    Equipment: {eqName}={amount}");
        }
        
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
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}