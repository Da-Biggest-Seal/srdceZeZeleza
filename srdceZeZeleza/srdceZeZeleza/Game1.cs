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
    Division division;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        data = new Data("Jsons/battalion.json");
        division = new Division("Countries/Country1/division.json");
        
        Console.WriteLine(division.Name);
        Console.WriteLine($"S={division.Stats.Soft}, H={division.Stats.Hard}, A={division.Stats.Air}, HP={division.Stats.Hp}, O={division.Stats.Org}, SP={division.Stats.Speed}");
        
        Console.WriteLine($"Manpower={division.Req.Manpower}");
            
        foreach ((string eqName, int amount) in division.Req.Equipment)
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