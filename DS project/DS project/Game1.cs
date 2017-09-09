using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DS_project
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
       
        GameState CurrentGameState = GameState.MainMenu;
        Menu GameMenu = new Menu();
        SoundEffectInstance s;
        const int offset = 50;
        //addition
        enemy enemy = new enemy();
        Coin coin = new Coin(new Vector2(250, 250));
        Bullet bullet;
        hero hero = new hero();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;

            // just for testing 

        }
        protected override void LoadContent()
        {
            bullet = new Bullet(new Vector2(200+64,200+30), Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;
            GameMenu.Load(Content);
            enemy.LoadContent(Content);
            SoundManager.Load(Content);
            ScoreWindow.Load(Content);
            s = Content.Load<SoundEffect>("Tracks/GameSoundTrack").CreateInstance();
            MediaPlayer.Play(Content.Load<Song>("Tracks/Menuloop"));
            MediaPlayer.IsRepeating = true;
            enemy.LoadContent(Content);
            hero.LoadContent(Content);
            coin.LoadContent(Content);
        }

        protected override void Initialize()
        {

            Camera.Position = new Vector2(0, 0);
            Camera.WorldRectangle = new Rectangle(0, 0, TileMap.Tilescale * 3390, TileMap.Tilescale * 200);
            Camera.ViewportWidth = 800;
            Camera.ViewportHight = 600;
            TileMap.Load(Content.Load<Texture2D>("map/MapSheet"));
            enemy.initialize();
            hero.initialize();
            GameMenu.Intialize();
            ScoreWindow.Intialize();   
            base.Initialize();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            
            IsMouseVisible = false;
            // Just for Testing
            if (CurrentGameState == GameState.MainMenu && InputManager.IsRightPressed())
            {
                CurrentGameState = ScoreWindow.GS;
            }
            if (CurrentGameState == GameState.Playing)
            {
                // Game 1 class 
                MediaPlayer.Stop();
                s.Volume = 0.1f;
                s.Play();
                
                //////////////////
                
                    if (InputManager.IsSpacePressed())
                    {

                        SoundManager.PlayHeroShootSound();
                    }
            }
            ScoreWindow.Update();
            ///////////////////////////////
            InputManager.Update();
            GameMenu.Update(gameTime);
            if (GameMenu.GameExit == true) Exit();
            // Game Menu Stuff
            // Choosing the Game State (Getting the Game from the Menu)
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    CurrentGameState = GameMenu.gamestate;
                    break;
                case GameState.Playing:
                    CurrentGameState = GameMenu.gamestate;
                        enemy.Update(gameTime);
            hero.Update(gameTime);
            coin.Update(gameTime);
                    if(InputManager.IsSpacePressed())
            bullet.Update(gameTime);
                    break;
                case GameState.Options:
                    CurrentGameState = GameMenu.gamestate;
                    break;
                case GameState.GameOver:
                    CurrentGameState = ScoreWindow.GS;
                    break;
                case GameState.Instructions:
                    CurrentGameState = GameMenu.gamestate;
                    break;
                case GameState.Credits:
                    CurrentGameState = GameMenu.gamestate;
                    break;
            }

            if (InputManager.IsRightPressed())
                Camera.Move(new Vector2(offset/10, 0));
            else if (InputManager.IsLeftPressed())
                Camera.Move(new Vector2(-offset /10, 0));
            /*else if (InputManager.IsDownPressed())
                Camera.Move(new Vector2(0, offset));
            else if (InputManager.IsUpPressed())
                Camera.Move(new Vector2(0, -offset));*/
        
           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            // Game Menu Stuff
            // Choosing the Game State (Getting the Game from the Menu)

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    GameMenu.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    TileMap.Draw(spriteBatch);
                    enemy.Draw(spriteBatch);
                    hero.Draw(spriteBatch);
                    coin.Draw(spriteBatch);
                    if (InputManager.IsSpacePressed())
                        bullet.Draw(spriteBatch);
                  
                    break; 
                case GameState.Options:
                    GameMenu.Draw(spriteBatch);
                    break;
                case GameState.GameOver:
                    ScoreWindow.Draw(spriteBatch);
                    break;
                case GameState.Instructions:
                    GameMenu.Draw(spriteBatch);
                    break;
                case GameState.Credits:
                    GameMenu.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
