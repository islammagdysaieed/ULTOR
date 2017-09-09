using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DS_project
{
   public static class Camera
   {
       #region fields
       private static Vector2 position;
       private static Vector2 viewportsize;
       private static Rectangle worldRectangle;
       #endregion

       #region properties
       public static Vector2 Position 
       {
           get { return position; }
           set 
           {
               position = new Vector2(MathHelper.Clamp(value.X, worldRectangle.X, worldRectangle.Width - viewportsize.X),
                   MathHelper.Clamp(value.Y, worldRectangle.Y, worldRectangle.Height - viewportsize.Y));
           }
       }

       public static int ViewportHight 
       {
           get { return (int)viewportsize.Y; }
           set { viewportsize.Y = MathHelper.Min(worldRectangle.Height, value); }
       }

       public static int ViewportWidth
       {
           get { return (int)viewportsize.X; }
           set { viewportsize.X = MathHelper.Min(worldRectangle.Width, value); }
       }


       public static Rectangle WorldRectangle
       {
           get { return worldRectangle; }
           set { worldRectangle = value; }
       }

       public static Rectangle Viewport
       {
           get { return new Rectangle((int)position.X, (int)position.Y, ViewportWidth, ViewportHight); }
       }

#endregion

       #region methods

       public static void Move(Vector2 offset)
       {
          Position += offset;
       }

       public static bool isvisible(Rectangle Object)
       {
           return Viewport.Intersects(Object);
       }
       //public static bool isvisible(Texture2D Object)

       public static Rectangle WorldToScreen(Rectangle WorldRec)
       {
           return new Rectangle((int)(WorldRec.X - Position.X), (int)(WorldRec.Y - Position.Y), (int)WorldRec.Width, (int)WorldRec.Height);
       }

       public static Vector2 WorldToScreen(Vector2 Pos)
       {
           return Pos - position;
       }

       public static Rectangle ScreenToWorld(Rectangle ScreenRec)
       {
           return new Rectangle((int)(ScreenRec.X - Position.X), (int)(ScreenRec.Y - Position.Y), (int)ScreenRec.Width, (int)ScreenRec.Height);
       }
 

       #endregion

   }
}
