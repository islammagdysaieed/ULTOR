using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DS_project
{
    public class enemy
    {
        Texture2D enemyimage;
        Vector2 enemypos;
        float movespeed = 100f;
        SpriteEffects SE;
        bool flipped = false;
        Animation enemyAnimation;
        public void initialize()
        {
            enemypos=new Vector2 (1000,200);
        }
        public void LoadContent(ContentManager content)
        {
            enemyimage = content.Load<Texture2D>("sprites/enemy-run2");
            enemyAnimation = new Animation(enemyimage,26);
            enemyAnimation.AnimationImage = enemyimage;
            enemyAnimation.Initialize();
        }
        public void Update(GameTime gametime)
        {
            enemyAnimation.Active = true;
            enemypos .X-= movespeed * (float)gametime.ElapsedGameTime.TotalSeconds;
            enemyAnimation.Update(gametime);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            if (this.flipped)
                SE = SpriteEffects.FlipHorizontally;
            else
                SE = SpriteEffects.None;
            spritebatch.Draw(enemyAnimation.image, enemypos, enemyAnimation.SourceRectangle, Color.White, 0, Vector2.Zero, 1.7f, SE, 1);
        }
    }
}
