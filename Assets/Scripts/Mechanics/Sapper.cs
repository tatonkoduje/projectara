using System;
using System.Security.Cryptography;
using Utils;

namespace Mechanics
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
            var result = 0;
            // TODO: info ze obok nie ma pokoju ?
            if(BombExists(coords.GetXNext())) result++;
            if(BombExists(coords.GetYPrevious())) result++;
            if(BombExists(coords.GetYNext())) result++;
            if(BombExists(coords.GetYPrevious())) result++;

            return result > 0 ? result : _area[coords.X, coords.Y];
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

        public bool In2DArrayBounds(Coords coords)
        {
            return coords.X >= _area.GetLowerBound(0) &&
                   coords.X <= _area.GetUpperBound(0) &&
                   coords.Y >= _area.GetLowerBound(1) &&
                   coords.Y <= _area.GetUpperBound(1);
        }
    }
}