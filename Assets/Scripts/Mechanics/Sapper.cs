using System;
using System.Drawing;
using System.Security.Cryptography;
using UnityEngine;

namespace Mechanics
{
    public class Sapper
    {
        private int _dimension;
        private int _dangerCount;
        private int[,] _level;
        
        public Sapper(int dimension, int dangerCount)
        {
            _dimension = dimension;
            _dangerCount = dangerCount;
            _level = new int[_dimension, _dimension];

            PopulateDefault();
            PopulateDanger();
        }

        public int GetInfo(Tuple<int, int> coords)
        {
            var result = 0;

            var t = Tuple.Create(coords.Item1 + 1, coords.Item2);
            
            if(BombExists(coords.Item1 + 1, coords.Item2)) result++;
            if(BombExists(coords.Item1 - 1, coords.Item2)) result++;
            if(BombExists(coords.Item1, coords.Item2 + 1)) result++;
            if(BombExists(coords.Item1, coords.Item2 - 1)) result++;

            if (result > 0)
            {
                return result;
            }
            else
            {
                return _level[coords.Item1, coords.Item2];
            }
        }

        private void PopulateDanger()
        {
            var coords = GetRandomCoords();
            
            for (var i = 0; i < _dangerCount; i++)
            {
                while (BombExists(coords.Item1, coords.Item2))
                {
                    _level[coords.Item1, coords.Item2] = -1;
                }
            }
        }

        
        private bool BombExists(int x, int y)
        {
            return _level[x, y] == -1;
        }

        
        private void PopulateDefault()
        {
            for (var i = 0; i < _level.GetLength(0); i++)
            {
                for (var j = 0; j < _level.GetLength(1); j++)
                {
                    _level[i, j] = 0;
                }
            }
        }

        
        private Tuple<int, int> GetRandomCoords()
        {
            var rnX = RandomNumberGenerator.GetInt32(0,_level.GetLength(0));
            var rnY = RandomNumberGenerator.GetInt32(0,_level.GetLength(1));
            Debug.Log("Draw random coords: " + rnX + ", " + rnY);

            return new Tuple<int, int>(rnX, rnY);
        }
    }
}