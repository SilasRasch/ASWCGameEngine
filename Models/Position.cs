using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static Position operator +(Position a, Position b)
        {
            a.X += b.X;
            a.Y += b.Y;
            return a;
        }
        
        public static Position operator -(Position a, Position b)
        {
            a.X -= b.X;
            a.Y -= b.Y;
            return a;
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
