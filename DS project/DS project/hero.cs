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
     public class hero
    {
        
        Texture2D heroimage;
        Vector2 velocity,heropos;
        //Rectangle sourceRect;
        const float gravity = 30f;
        float jumpspeed = 500f;
        bool OnLand = true;
        float movespeed=10f;
        KeyboardState key;
        Animation heroAnimation ;
        SpriteEffects SE;
        bool flipped = false;
        public void initialize()
        {
            heropos= velocity = new Vector2(180, 0);
        }
        public void LoadContent(ContentManager content)
        {
            heroimage = content.Load<Texture2D>("test/running");
           
            //  FrameWidth
           
           heroAnimation = new Animation(heroimage, 83);
            heroAnimation.Initialize();
            
        }
        public void Update(GameTime gametime)
        {

            heroAnimation.Active = true;
            key = Keyboard.GetState();
            heroAnimation.Active = true;

            if (key.IsKeyDown(Keys.Down))
            {
                //velocity.Y = movespeed * (float)gametime.ElapsedGameTime.TotalSeconds;
                
            }
            /*else if (key.IsKeyDown(Keys.Up))
            {
                velocity.Y = movespeed * (float)gametime.ElapsedGameTime.TotalSeconds;
          
            }*/
             if (key.IsKeyDown(Keys.Left))
            {
                velocity.X = -movespeed * (float)gametime.ElapsedGameTime.TotalSeconds;
                flipped = true; 
            }
            else if (key.IsKeyDown(Keys.Right))
            {

                velocity.X = movespeed * (float)gametime.ElapsedGameTime.TotalSeconds;
                flipped = false;
            }

            else
            {
                heroAnimation.Active = false;
                velocity.X = 0;   
    
            }
             if (key.IsKeyDown(Keys.Up) && OnLand)
                 {
                     velocity.Y = -jumpspeed * (float)gametime.ElapsedGameTime.TotalSeconds;
                     OnLand = false;
                     
                 }
             if (!OnLand)
                 velocity.Y += gravity * (float)gametime.ElapsedGameTime.TotalSeconds;
             else
                 velocity.Y = 0;

            if(CanMoveHorizontal( heropos +velocity))
             heropos += velocity;
           else if (CanMoveVertical(heropos + velocity))
                heropos+= velocity;
            OnLand = heropos.Y >= 200;

            if (OnLand)
                heropos.Y = 200;
          
       
           
            heroAnimation.Update(gametime);
           
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if(this.flipped)
                SE = SpriteEffects.FlipHorizontally;
            else
                SE = SpriteEffects.None;
             
            spritebatch.Draw(heroAnimation.image, heropos, heroAnimation.SourceRectangle, Color.White,0,Vector2.Zero,1.5f,SE,1);
        }









        public bool CanMoveHorizontal(Vector2 CurrentPosition)
        {
            //rectangle of object
            Rectangle NextPositionRectangle = GetNextRectangle(CurrentPosition);
            Vector2 LeftPosition = CurrentPosition;
            Vector2 RightPosition = new Vector2(NextPositionRectangle.Right, CurrentPosition.Y);

            Vector2 NextPositionLeftCell = TileMap.GetCellByPixel(LeftPosition);
            Vector2 NextPositionRightCell = TileMap.GetCellByPixel(RightPosition);
            bool GoFromLeft = TileMap.GetMapSquareAtCell((int)NextPositionLeftCell.X, (int)NextPositionLeftCell.Y).Passable;
            bool GoFromRight = TileMap.GetMapSquareAtCell((int)NextPositionRightCell.X, (int)NextPositionRightCell.Y).Passable;
            return (GoFromLeft && GoFromRight);
        }





        public bool CanMoveVertical(Vector2 CurrentPosition)
        {
            //rectangle of object
            Rectangle NextPositionRectangle = GetNextRectangle(CurrentPosition);
            Vector2 DownPosition = new Vector2(CurrentPosition.X, NextPositionRectangle.Bottom);
            Vector2 NextDownPositionCell = TileMap.GetCellByPixel(DownPosition);
            bool GoDown = (TileMap.GetMapSquareAtCell((int)NextDownPositionCell.X, (int)NextDownPositionCell.Y).Passable);
            return !GoDown;
        }



        public Rectangle GetNextRectangle(Vector2 NextPosition)
        {
            return new Rectangle((int)NextPosition.X, (int)NextPosition.Y, heroAnimation.SourceRectangle.Width, heroAnimation.SourceRectangle.Width);
        }
       












    }
}
