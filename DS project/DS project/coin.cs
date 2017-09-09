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
    public class Coin
    {
        Texture2D coin;
        Vector2 position;
        Animation CoinAnimation;
        
        public Coin(Vector2 Position)
        {
            this.position = Position;
        }
        public void LoadContent(ContentManager content)
        {
            coin = content.Load<Texture2D>("sprites/Coin");
            CoinAnimation = new Animation(coin, 44);
            CoinAnimation.Initialize();
        }
        public void Update(GameTime gametime)
        {
            CoinAnimation.Active = true;
            CoinAnimation.Update(gametime);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(coin, position, CoinAnimation.SourceRectangle, Color.White,0.0f,Vector2.Zero,0.7f,SpriteEffects.None,1);
        }
    }
}
