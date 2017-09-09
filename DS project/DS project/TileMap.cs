﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DS_project
{
    public static class TileMap
    {
        #region Declarations
        public const int Tilescale = 3;
        public const int CellWidth = 32;
        public const int CellHeight = 16;
        public const int MapWidth = 106;
        public const int MapHeight = 13;
        public const int TileWidth = CellWidth * Tilescale;
        public const int TileHeight = CellHeight * Tilescale;
        
        //public const int MapLayers = 3;
        private const int Default = 2;

        static private MapSquare[,] mapCells =
            new MapSquare[MapWidth, MapHeight];

//        public static bool EditorMode = false;

        public static SpriteFont spriteFont;
        static private Texture2D tileSheet;
        #endregion

        #region Initialization
        static public void Load(Texture2D tileTexture)
        {
            tileSheet = tileTexture;

            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                        mapCells[x, y] = new MapSquare(GetTileIndex(x,y), "", true);
                    
                }
            }
            LoadMapFormFile();
        }

        private static void LoadMapFormFile()
        {
            FileStream FS = new FileStream(@"E:\Study & Learn\Programming\TOP\My solution & projects\projects\DS\ULTOR\DS project\DS projectContent\map\mapfile.txt", FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS);
            String[] filecopy = new String[MapHeight];
            int cnt = 0;
            while (SR.Peek() != -1)
            {
                filecopy[cnt++] = RemoveSpaces(SR.ReadLine());
            }
            SR.Close();
            FS.Close();
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    mapCells[x, y].Passable = (filecopy[y][x] == '0') ? true : false;
                }
            }


        }
        private static String RemoveSpaces(String tmp)
        {
            String ret ="";
            for (int i = 0; i < tmp.Length; i++)
                if (tmp[i] != ' ')
                    ret += tmp[i];
            return ret;
        }
        
        #endregion

        #region Tile and Tile Sheet Handling
        public static int TilesPerRow
        {
            get { return tileSheet.Width /CellWidth; }
        }

        public static Rectangle TileSourceRectangle(int tileIndex)
        {
            return new Rectangle(
                (tileIndex % TilesPerRow) * CellWidth,
                (tileIndex / TilesPerRow) * CellHeight,
                CellWidth,
                CellHeight);
        }
        public static int GetTileIndex(int CellX, int CellY)
        {
            return CellY * MapWidth + CellX;
        }
        #endregion

        #region Information about Map Cells
        static public int GetCellByPixelX(int pixelX)
        {
            return pixelX / TileWidth;
        }

        static public int GetCellByPixelY(int pixelY)
        {
            return pixelY / TileHeight;
        }

        static public Vector2 GetCellByPixel(Vector2 pixelLocation)
        {
            return new Vector2(
                GetCellByPixelX((int)pixelLocation.X),
                GetCellByPixelY((int)pixelLocation.Y));
        }

        static public Vector2 GetCellCenter(int cellX, int cellY)
        {
            return new Vector2(
                (cellX * TileWidth) + (TileWidth / 2),
                (cellY * TileHeight) + (TileHeight / 2));
        }

        static public Vector2 GetCellCenter(Vector2 cell)
        {
            return GetCellCenter(
                (int)cell.X,
                (int)cell.Y);
        }

        static public Rectangle CellWorldRectangle(int cellX, int cellY)
        {
            return new Rectangle(
                cellX * TileWidth,
                cellY * TileHeight,
                TileWidth,
                TileHeight);
        }

        static public Rectangle CellWorldRectangle(Vector2 cell)
        {
            return CellWorldRectangle(
                (int)cell.X,
                (int)cell.Y);
        }

        static public Rectangle CellScreenRectangle(int cellX, int cellY)
        {
            return Camera.WorldToScreen(CellWorldRectangle(cellX, cellY));
        }

        static public Rectangle CellSreenRectangle(Vector2 cell)
        {
            return CellScreenRectangle((int)cell.X, (int)cell.Y);
        }

        static public bool CellIsPassable(int cellX, int cellY)
        {
            MapSquare square = GetMapSquareAtCell(cellX, cellY);

            if (square == null)
                return false;
            else
                return square.Passable;
        }

        static public bool CellIsPassable(Vector2 cell)
        {
            return CellIsPassable((int)cell.X, (int)cell.Y);
        }

        static public bool CellIsPassableByPixel(Vector2 pixelLocation)
        {
            return CellIsPassable(
                GetCellByPixelX((int)pixelLocation.X),
                GetCellByPixelY((int)pixelLocation.Y));
        }

        static public string CellCodeValue(int cellX, int cellY)
        {
            MapSquare square = GetMapSquareAtCell(cellX, cellY);

            if (square == null)
                return "";
            else
                return square.CodeValue;
        }

        static public string CellCodeValue(Vector2 cell)
        {
            return CellCodeValue((int)cell.X, (int)cell.Y);
        }
        #endregion

        #region Information about MapSquare objects
        static public MapSquare GetMapSquareAtCell(int tileX, int tileY)
        {
            if ((tileX >= 0) && (tileX < MapWidth) &&
                (tileY >= 0) && (tileY < MapHeight))
            {
                return mapCells[tileX, tileY];
            }
            else
            {
                return null;
            }
        }

        static public void SetMapSquareAtCell(
            int tileX,
            int tileY,
            MapSquare tile)
        {
            if ((tileX >= 0) && (tileX < MapWidth) &&
                (tileY >= 0) && (tileY < MapHeight))
            {
                mapCells[tileX, tileY] = tile;
            }
        }

        static public void SetTileAtCell(int tileX,int tileY,int TileIndex)
        {
            if ((tileX >= 0) && (tileX < MapWidth) &&
                (tileY >= 0) && (tileY < MapHeight))
            {
                mapCells[tileX, tileY].TileIndx = TileIndex;
            }
        }

        static public MapSquare GetMapSquareAtPixel(int pixelX, int pixelY)
        {
            return GetMapSquareAtCell(
                GetCellByPixelX(pixelX),
                GetCellByPixelY(pixelY));
        }

        static public MapSquare GetMapSquareAtPixel(Vector2 pixelLocation)
        {
            return GetMapSquareAtPixel(
                (int)pixelLocation.X,
                (int)pixelLocation.Y);
        }

        #endregion

        //#region Loading and Saving Maps
        //public static void SaveMap(FileStream fileStream)
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    formatter.Serialize(fileStream, mapCells);
        //    fileStream.Close();
        //}

        //public static void LoadMap(FileStream fileStream)
        //{
        //    try
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        mapCells = (MapSquare[,])formatter.Deserialize(fileStream);
        //        fileStream.Close();
        //    }
        //    catch
        //    {
        //        ClearMap();
        //    }
        //}

        //public static void ClearMap()
        //{
        //    for (int x = 0; x < MapWidth; x++)
        //        for (int y = 0; y < MapHeight; y++)
        //                mapCells[x, y] = new MapSquare(Default, "", true);
                   
        //}

        //#endregion

        #region Drawing
        static public void Draw(SpriteBatch spriteBatch)
        {
            int startX = GetCellByPixelX((int)Camera.Position.X);
            int endX = GetCellByPixelX((int)Camera.Position.X +
                  Camera.ViewportWidth);

            int startY = GetCellByPixelY((int)Camera.Position.Y);
            int endY = GetCellByPixelY((int)Camera.Position.Y +
                      Camera.ViewportHight);     

            for (int x = startX; x <= endX; x++)
                for (int y = startY; y <= endY; y++)
                {
                    
                        if ((x >= 0) && (y >= 0) &&(x < MapWidth) && (y < MapHeight))
                        {
                            Color CL = Color.White;
                            if(!mapCells[x,y].Passable)
                                CL = Color.White; 
                            spriteBatch.Draw(
                              tileSheet,
                              CellScreenRectangle(x, y),
                              TileSourceRectangle(mapCells[x, y].TileIndx),
                              CL);
                        }

                /* 
                 if (EditorMode)
                    {
                        DrawEditModeItems(spriteBatch, x, y);
                    }
                 
                */
                }
        }

        /* public static void DrawEditModeItems(
            SpriteBatch spriteBatch,
            int x,
            int y)
        {
            if ((x < 0) || (x >= MapWidth) ||
                (y < 0) || (y >= MapHeight))
                return;

            if (!CellIsPassable(x, y))
            {
                spriteBatch.Draw(
                                tileSheet,
                                CellScreenRectangle(x, y),
                                TileSourceRectangle(1),
                                new Color(255, 0, 0, 80),
                                0.0f,
                                Vector2.Zero,
                                SpriteEffects.None,
                                0.0f);
            }

            if (mapCells[x, y].CodeValue != "")
            {
                Rectangle screenRect = CellScreenRectangle(x, y);

                spriteBatch.DrawString(
                    spriteFont,
                    mapCells[x, y].CodeValue,
                    new Vector2(screenRect.X, screenRect.Y),
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
            }
        }*/
        #endregion

    }
}
