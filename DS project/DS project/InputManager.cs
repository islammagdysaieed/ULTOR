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
    public static class InputManager
    {
        private static KeyboardState ks;
        // updating the Manager - for Game1 class
        public static void Update()
        {
            ks = Keyboard.GetState();
        }
        public static bool IsUpPressed()
        {
            return (ks.IsKeyDown(Keys.Up));
        }
        public static bool IsDownPressed()
        {
            return (ks.IsKeyDown(Keys.Down));
        }

        public static bool IsRightPressed()
        {
            return (ks.IsKeyDown(Keys.Right));
        }
        public static bool IsLeftPressed()
        {
            return (ks.IsKeyDown(Keys.Left));
        }
        public static bool IsEnterPressed()
        {
            return (ks.IsKeyDown(Keys.Enter));
        }
        public static bool IsSpacePressed()
        {
            return (ks.IsKeyDown(Keys.Space));
        }
        public static bool IsEscapePressed()
        {
            return (ks.IsKeyDown(Keys.Escape));
        }
    }
}
