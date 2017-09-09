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
    public class GameObject
    {

        protected Vector2 position;
        protected Vector2 velocity;
        protected Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
        protected string currentanimation;
        protected List<Bullet> bulletlist = new List<Bullet>(); //za5era
        protected Rectangle object_rectangle;
        protected bool alive;
        protected bool flipped;
        const int scalevalue = 2;
        public bool Alive
        {
            get { return alive;}
            set { alive=value;}
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Rectangle Object_Rectangle
        {
            get { return object_rectangle; }
            set { object_rectangle = new Rectangle((int)Position.X, (int)Position.Y,
                scalevalue * animations[currentanimation].SourceRectangle.Width, scalevalue * animations[currentanimation].SourceRectangle.Height);
            }

        }
        public GameObject()
        {
            alive = true;
            flipped = false;

        }

        public void Draw(SpriteBatch spritebatch)
        { 

            SpriteEffects spriteeffect = SpriteEffects.None;
            if(flipped)
                spriteeffect = SpriteEffects.FlipHorizontally;

            spritebatch.Draw(animations[currentanimation].AnimationImage,this.Object_Rectangle,animations[currentanimation].SourceRectangle,Color.White,0f,Vector2.Zero,spriteeffect,1f);
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
            bool GoDown = (TileMap.GetMapSquareAtCell((int)DownPosition.X, (int)DownPosition.Y).Passable);
            return !GoDown;
        }



        public Rectangle GetNextRectangle(Vector2 NextPosition)
        {
            return new Rectangle((int)NextPosition.X, (int)NextPosition.Y, scalevalue * animations[currentanimation].SourceRectangle.Width, scalevalue * animations[currentanimation].SourceRectangle.Width);
        }
       


       


    }
}
