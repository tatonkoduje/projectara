using System;
using com.maapiid.projectara.Utils;


namespace GameData
{
    [Serializable]
    public class CoordsData
    {
        public int X;
        public int Y;
        
        public CoordsData(Coords coords)
        {
            X = coords.X;
            Y = coords.Y;
        }
    }
}