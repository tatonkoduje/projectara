using System.Data.SqlTypes;
using Unity.VisualScripting;

namespace Utils
{
    public struct Coords : INullable
    {
        public readonly int X;
        public readonly int Y;
        
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
            IsNull = false;
        }

        public Coords GetYPrevious()
        {
            return new Coords(X, Y - 1);
        }

        public Coords GetYNext()
        {
            return new Coords(X, Y + 1);
        }

        public Coords GetXPrevious()
        {
            return new Coords(X - 1, Y);
        }

        public Coords GetXNext()
        {
            return new Coords(X + 1, Y);
        }

        public static Coords Empty()
        {
            return new Coords
            {
                IsNull = true
            };
        }
        
        public bool IsNull { get; private set; }
    }
}