using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DS_project
{
    public class Menu
    {
        // For Sound Enable/Unable String //
        private SpriteFont MenuFont;
        private Vector2 FontPosition;
        public bool EnableGameSound = true;
        private string Enable = "Yes", Unable = "No";
        // Menu Background //
        private Texture2D MenuBG;
        private Vector2 MenuBGPos;
        // Menu Buttons //
        private Texture2D Button1, Button2, Button3, Button4,Button5;
        private Vector2 Btn1Pos, Btn2Pos, Btn3Pos, Btn4Pos,Btn5Pos;
        private Color BTN1col, BTN2col, BTN3col, BTN4col,BTN5col;
        // Options Menu
        private Texture2D OptionsMenuBG;
        private Vector2 OptionsMenuBGPosition;
        // Instructions Menu
        private Texture2D InstructionsBG;
        private Vector2 InstructionsPanelPosition;
        // Credits Panel
        private Texture2D CreditsPanelBG;
        private Vector2 CreditsPanelPosition;
        // Current Game State (A small Enum Shares the Big Enum that in the Game1) //
        public GameState gamestate;
        // Important! .. For Delaying the Game Time (For Menu Buttons , Sound Enable/Disable Colored String) // 
        private const float pressdelay = 120;
        private float timer = 0;
        // For The Game Exit Function in the Game1 //  
        public bool GameExit = false;
        // Menu SoundEffects 
        public SoundEffect Menuentry;
        public SoundEffect ButtonPoint;
        // Main Menu Load Function - For the Game1 class  
        public void Load(ContentManager content)
        {
            // loading the  The Main Menu Background
            MenuBG = content.Load<Texture2D>("Backgrounds/main");
            // loading the  The Main Menu Buttons 
            Button1 = content.Load<Texture2D>("Buttons/PlayGame");
            Button2 = content.Load<Texture2D>("Buttons/Options");
            Button3 = content.Load<Texture2D>("Buttons/Instructions");
            Button4 = content.Load<Texture2D>("Buttons/Credits");
            Button5 = content.Load<Texture2D>("Buttons/Quit");
            // loading the  Options Menu BG
            OptionsMenuBG = content.Load<Texture2D>("Backgrounds/options-menu");
            // loading the  Instructions panel BG
            InstructionsBG = content.Load<Texture2D>("Backgrounds/Instructions");
            // loading the Credits Panel BG
            CreditsPanelBG = content.Load<Texture2D>("Backgrounds/Credits");
            // loading the Menu Font (Orena)
            MenuFont = content.Load<SpriteFont>("Fonts/MenuFont");
            // loading the Menu Sounds
            Menuentry = content.Load<SoundEffect>("Tracks/Reload");
            ButtonPoint = content.Load<SoundEffect>("Tracks/BulletLoad");
        }
        // Important - For Identifying which Button that I Stopped at
        int PointCounter = 1;
        // Updating the Menu Items According to GameState - For The Game1 class
        public void Update(GameTime gametime)
        {
            // Very Important - For Delaying the game time - for the Menu Buttons , enable/disable Sound colorable String
            timer += (float)gametime.ElapsedGameTime.TotalMilliseconds;
            if (gamestate == GameState.MainMenu)
            {
                if (timer >= pressdelay)
                {   //For every pressdelay in milliseconds , the menu will let the user to choose a choise
                    timer = 0;
                    if (InputManager.IsDownPressed())
                    {
                        PointCounter++;
                        ButtonPoint.Play();
                        // Moving in a cycle - Presenting the menu buttons (looping the choises) 
                        if (PointCounter == 6) PointCounter = 1;
                    }
                    if (InputManager.IsUpPressed())
                    {
                        ButtonPoint.Play();
                        PointCounter--;
                        // Moving in a cycle - Presenting the menu buttons (looping the choises)
                        if (PointCounter == 0) PointCounter = 5;
                    }
                }
                switch (PointCounter)
                {
                    // Identifying the Current choosen button
                    case 1:
                        BTN2col = Color.White;
                        BTN1col = Color.BurlyWood;
                        BTN3col = Color.White;
                        BTN4col = Color.White;
                        BTN5col = Color.White;
                        break;
                    case 2:
                        BTN1col = Color.White;
                        BTN2col = Color.BurlyWood;
                        BTN3col = Color.White;
                        BTN4col = Color.White;
                        BTN5col = Color.White;
                        break;
                    case 3:
                        BTN1col = Color.White;
                        BTN2col = Color.White;
                        BTN3col = Color.BurlyWood;
                        BTN4col = Color.White;
                        BTN5col = Color.White;
                        break;
                    case 4:
                        BTN1col = Color.White;
                        BTN2col = Color.White;
                        BTN3col = Color.White;
                        BTN4col = Color.BurlyWood;
                        BTN5col = Color.White;
                        break;
                    case 5:
                        BTN1col = Color.White;
                        BTN2col = Color.White;
                        BTN3col = Color.White;
                        BTN4col = Color.White;
                        BTN5col = Color.BurlyWood;
                        break;
                }
                if (InputManager.IsEnterPressed())
                {
                    switch (PointCounter)
                    {
                        // Directing the user to the prefered game state - According to his choise 
                        case 1:
                            {
                                gamestate = GameState.Playing;
                                Menuentry.Play();
                                break;
                            }
                        case 2:
                            {
                                gamestate = GameState.Options;
                                Menuentry.Play();
                                break;
                            }
                        case 3:
                            {
                                gamestate = GameState.Instructions;
                                Menuentry.Play();
                                break;
                            }
                        case 4:
                            {
                                gamestate = GameState.Credits;
                                Menuentry.Play();
                                break;
                            }
                        case 5:
                            {
                                GameExit = true;
                                Menuentry.Play();
                                break;
                            }
                    }
                }
            }
            if (gamestate == GameState.Credits)
            {
                if (InputManager.IsEscapePressed())
                {
                    Menuentry.Play();
                    gamestate = GameState.MainMenu;
                }
            }

            if (gamestate == GameState.Instructions)
            {
                if (InputManager.IsEscapePressed())
                {
                    Menuentry.Play();
                    gamestate = GameState.MainMenu;
                }
            }
            if (gamestate == GameState.Options)
            {   // Changing the Sound State
                if (InputManager.IsRightPressed())
                {
                    EnableGameSound = false;
                    MediaPlayer.Pause();

                }

                if (InputManager.IsLeftPressed())
                {
                    EnableGameSound = true;
                    MediaPlayer.Resume();
                }
                // returning to the Main Menu
                if (InputManager.IsEscapePressed())
                {
                    gamestate = GameState.MainMenu;
                    Menuentry.Play();
                }
                
            }
        }

        // Intializing the Menu Items (Vectors , GameState)
        public void Intialize()
        {
            gamestate = GameState.MainMenu;
            MenuBGPos = new Vector2(0, 0);
            Btn1Pos = new Vector2(25, 200);
            Btn2Pos = new Vector2(25, 275);
            Btn3Pos = new Vector2(25, 350);
            Btn4Pos = new Vector2(25, 425);
            Btn5Pos = new Vector2(25, 500);
            BTN1col = Color.White;
            BTN2col = Color.White;
            BTN3col = Color.White;
            BTN4col = Color.White;
            BTN5col = Color.White;
            OptionsMenuBGPosition = new Vector2(0, 0);
            InstructionsPanelPosition = new Vector2(0, 0);
            CreditsPanelPosition = new Vector2(0, 0);
            FontPosition = new Vector2(510, 185);
        }
        // Drawing Function - for Game1 class
        public void Draw(SpriteBatch spritebatch)
        {
            if (gamestate == GameState.MainMenu)
            {
                spritebatch.Draw(MenuBG, MenuBGPos, Color.White);
                spritebatch.Draw(Button1, Btn1Pos, BTN1col);
                spritebatch.Draw(Button2, Btn2Pos, BTN2col);
                spritebatch.Draw(Button3, Btn3Pos, BTN3col);
                spritebatch.Draw(Button4, Btn4Pos, BTN4col);
                spritebatch.Draw(Button5, Btn5Pos, BTN5col);
            }

            else if (gamestate == GameState.Options)
            {
                spritebatch.Draw(OptionsMenuBG, OptionsMenuBGPosition, Color.White);
                if (EnableGameSound)
                    spritebatch.DrawString(MenuFont, Enable, FontPosition, Color.Green);
                else
                    spritebatch.DrawString(MenuFont, Unable, FontPosition, Color.Tomato);
            }
            else if (gamestate == GameState.Instructions)
            {
                spritebatch.Draw(InstructionsBG, InstructionsPanelPosition, Color.White);
            }
            else if (gamestate == GameState.Credits)
            {
                spritebatch.Draw(CreditsPanelBG, CreditsPanelPosition, Color.White);
            }
        }
    }
}
