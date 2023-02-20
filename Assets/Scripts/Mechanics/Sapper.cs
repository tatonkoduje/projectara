using System;
using System.Security.Cryptography;
using com.maapiid.projectara.Utils;

namespace com.maapiid.projectara.Mechanics
{
    public class Sapper
    {
        private int Dimension { get; }
        private int DangerCount { get; }
        
        private readonly int[,] _area;
        
        public Sapper(int dimension, int dangerCount)
        {
            if (dangerCount > dimension * dimension)
            {
                throw new Exception("DangerCount cant be bigger than 2D area size");
            }
            
            Dimension = dimension;
            DangerCount = dangerCount;
            _area = new int[Dimension, Dimension];

            PopulateDefault();
            PopulateDanger();
        }

        public int GetInfo(Coords coords)
        {
            if (_area[coords.X, coords.Y] == -1)
            {
                return _area[coords.X, coords.Y];
            }

            var bombsFound = 0;
            if(BombExists(coords.GetXNext())) bombsFound++;
            if(BombExists(coords.GetXPrevious())) bombsFound++;
            if(BombExists(coords.GetYNext())) bombsFound++;
            if(BombExists(coords.GetYPrevious())) bombsFound++;
            return bombsFound;
        }

        public Coords GetRandomCoordsWithoutBomb()
        {
            var coords = GetRandomCoords();
            while (BombExists(coords))
            {
                coords = GetRandomCoords();
            }

            return coords;
        }
        
        public bool In2DArrayBounds(Coords coords)
        {
            return coords.X >= _area.GetLowerBound(0) &&
                   coords.X <= _area.GetUpperBound(0) &&
                   coords.Y >= _area.GetLowerBound(1) &&
                   coords.Y <= _area.GetUpperBound(1);
        }
        
        
        private void PopulateDanger()
        {
            for (var i = 0; i < DangerCount; i++)
            {
                var coords = GetRandomCoordsWithoutBomb();
                _area[coords.X, coords.Y] = -1;
            }
        }
        
        private bool BombExists(Coords coords)
        {
            return In2DArrayBounds(coords) && _area[coords.X, coords.Y] == -1;
        }
        
        private void PopulateDefault()
        {
            for (var i = 0; i < _area.GetLength(0); i++)
            {
                for (var j = 0; j < _area.GetLength(1); j++)
                {
                    _area[i, j] = 0;
                }
            }
        }
        
        private Coords GetRandomCoords()
        {
            var rnX = RandomNumberGenerator.GetInt32(0,_area.GetLength(0));
            var rnY = RandomNumberGenerator.GetInt32(0,_area.GetLength(1));

            return new Coords(rnX, rnY);
        }
    }
}