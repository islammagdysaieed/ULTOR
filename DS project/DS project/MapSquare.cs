using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DS_project
{
    [Serializable]
    public class MapSquare
    {
        #region Declarations
        public int TileIndx;
        public string CodeValue = "";
        public bool Passable = true;
        #endregion

        #region Constructor
        public MapSquare(int TileIndx,string code, bool passable)
        {
            this.TileIndx = TileIndx;
            CodeValue = code;
            Passable = passable;
        }
        #endregion

        #region Public Methods
        public void TogglePassable()
        {
            Passable = !Passable;
        }
        #endregion

    }
}
