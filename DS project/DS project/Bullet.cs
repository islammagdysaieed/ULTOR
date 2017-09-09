using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace DS_project
{
    public class Bullet
    {
        private Texture2D Bullet_texture;
        private Vector2 postion;
        private Vector2 speed=new Vector2(150,150);
        private const float vaildtime = 10;
        private float currenttime;
        private bool vaild;

        public bool Vaild { get { return vaild; } set { vaild = value; } }

        public Bullet(Vector2 postion, ContentManager Content)
        {
            vaild = true;
            currenttime = 0.0f;
            this.postion = postion;
            Bullet_texture = Content.Load<Texture2D>("test/bulllet");
        }

        public void Update(GameTime gametime)
        {
            currenttime += gametime.ElapsedGameTime.Seconds;
            if (currenttime >= vaildtime)
                Vaild = false;
            postion.X += speed.X * (float)gametime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Bullet_texture,postion,Color.White);
        }
    }
}
