using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models
{
    public class Position
    {
        /// <summary>
        /// X-position coordinate
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// Y-position coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Standard constructor
        /// </summary>
        /// <param name="x">X-coordinate</param>
        /// <param name="y">Y-coordinate</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Converts position to string (X, Y)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        /// <summary>
        /// Additive operator
        /// </summary>
        /// <param name="a">Position to add to</param>
        /// <param name="b">Position to add with</param>
        /// <returns></returns>
        public static Position operator +(Position a, Position b)
        {
            a.X += b.X;
            a.Y += b.Y;
            return a;
        }
        
        /// <summary>
        /// Subtractive operator
        /// </summary>
        /// <param name="a">Position to subtract from</param>
        /// <param name="b">Position to subtract with</param>
        /// <returns></returns>
        public static Position operator -(Position a, Position b)
        {
            a.X -= b.X;
            a.Y -= b.Y;
            return a;
        }

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }

        /// <summary>
        /// Get Hashcode
        /// </summary>
        /// <returns>The hashcode for the given position</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
