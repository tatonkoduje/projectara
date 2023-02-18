using System;
using System.Security.Cryptography;

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

        public int GetInfo(Tuple<int, int> coords)
        {
            var result = 0;
            
            if(BombExists(coords.Item1 + 1, coords.Item2)) result++;
            if(BombExists(coords.Item1 - 1, coords.Item2)) result++;
            if(BombExists(coords.Item1, coords.Item2 + 1)) result++;
            if(BombExists(coords.Item1, coords.Item2 - 1)) result++;

            return result > 0 ? result : _area[coords.Item1, coords.Item2];
        }

        
        private void PopulateDanger()
        {
            for (var i = 0; i < DangerCount; i++)
            {
                var coords = GetRandomCoords();
                while (BombExists(coords.Item1, coords.Item2))
                {
                    coords = GetRandomCoords();
                }
                _area[coords.Item1, coords.Item2] = -1;
            }
        }
        
        private bool BombExists(int x, int y)
        {
            return In2DArrayBounds(x, y) && _area[x, y] == -1;
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
        
        private Tuple<int, int> GetRandomCoords()
        {
            var rnX = RandomNumberGenerator.GetInt32(0,_area.GetLength(0));
            var rnY = RandomNumberGenerator.GetInt32(0,_area.GetLength(1));

            return new Tuple<int, int>(rnX, rnY);
        }
        
        private bool In2DArrayBounds(int x, int y)
        {
            return x >= _area.GetLowerBound(0) &&
                   x <= _area.GetUpperBound(0) &&
                   y >= _area.GetLowerBound(1) &&
                   y <= _area.GetUpperBound(1);
        }
    }
}