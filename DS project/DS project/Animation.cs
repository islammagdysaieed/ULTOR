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
   public class Animation
    {
      
       int FrameCounter,amountofframes;
       int switchframe;
       int currentFrame;
       public Texture2D image;
       Rectangle sourceRect;
       bool active;
       int framewidth, framehight, SourceRectX;

       public Animation(Texture2D image, int framewidth)
       {
           this.image = image;
           this.framewidth = framewidth;
           this.amountofframes = image.Width/framewidth ;
           framehight = image.Height;
           this.SourceRectX = 0;
           this.currentFrame = 1;
          
       }
       public Rectangle SourceRectangle
       { get { return sourceRect; } }
       public bool Active
       {
           get { return active; }
           set { active = value; }
       }
   
       public int CurrentFrame
       {
           get { return currentFrame; }
           set { currentFrame = value; }
       }
       
       public Texture2D AnimationImage
       {
           get { return this.image; }
           set { image = value; }
       }
       public int FrameWidth
       {
           get
           {
               return framewidth;
           }
       }

       public int Frameheight
       {
           get { return image.Height; }
       }


       public void Initialize()
       {
           active = false;
           switchframe = 50;
          
         //  amountofframes = Frames;
           
       }
       public void Update(GameTime gametime)
       {

           if (active)
               FrameCounter += (int)gametime.ElapsedGameTime.TotalMilliseconds;
           else
               FrameCounter = 0;

          
               if (FrameCounter >= switchframe)
               {
                   FrameCounter = 0;

                   SourceRectX += FrameWidth;
                   currentFrame++;
                   if (currentFrame >= amountofframes)
                   { 
                      currentFrame =0 ;
                      SourceRectX = 0;
                   }
               }

               sourceRect = new Rectangle(SourceRectX, 0, FrameWidth, Frameheight);

       }
   
    }
}
