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
    public static class ScoreWindow
    {
        // For Texture for the Background 
        private static Texture2D ScoreBG;
        private static Vector2 ScoreBGPosition;
        // For The player Score // for the gameLevel Class
        private static int PlayScore;
        // For The font of the score
        private static SpriteFont ScoreFont;
        private static Vector2 ScoreFontPos;
        private static string Score;
        // Current Game State Class - shared with the Main Interface
        public static GameState GS;
        // A function to change the score from the game interface
        public static void ChangeScore(int ScoreChangeScale)
        {
            // The Amount of Score Change 
            PlayScore += ScoreChangeScale;
        }
        // Intializes the class data
        public static void Intialize()
        {
            GS = GameState.GameOver;
            PlayScore = 10;
            Score = PlayScore.ToString();
            ScoreBGPosition = new Vector2(0, 0);
            ScoreFontPos = new Vector2(500,280);
        }

        // Load the Class Data
        public static void Load(ContentManager content)
        {
            ScoreBG = content.Load<Texture2D>("Backgrounds/ScoreBG");
            ScoreFont = content.Load<SpriteFont>("Fonts/ScoreFont");
        }

        // Updates the Class Data
        public static void Update()
        {
            if (InputManager.IsEscapePressed())
            {
                GS = GameState.MainMenu;
            }
        }
        // Draws the Score Panel Background , Score Amount
        public static void Draw(SpriteBatch spritepatch)
        {
            spritepatch.Draw(ScoreBG, ScoreBGPosition, Color.White);
            spritepatch.DrawString(ScoreFont, Score, ScoreFontPos, Color.BlanchedAlmond);
        }
    }
}
