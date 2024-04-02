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
        /// <returns>A vector (coordinate) formatted string</returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        /// <summary>
        /// Additive operator
        /// </summary>
        /// <param name="a">Position to add to</param>
        /// <param name="b">Position to add with</param>
        /// <returns>The additive product of the two operators</returns>
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
        /// <returns>The subtracted product of the two positions</returns>
        public static Position operator -(Position a, Position b)
        {
            a.X -= b.X;
            a.Y -= b.Y;
            return a;
        }

        /// <summary>
        /// Multiply two position vectors
        /// </summary>
        /// <param name="a">Position A</param>
        /// <param name="b">Position B</param>
        /// <returns>The multiplical product of the two vectors</returns>
        public static Position operator *(Position a, Position b)
        {
            a.X *= b.X;
            a.Y *= b.Y;
            return a;
        }

        /// <summary>
        /// Check if two positions are equal
        /// </summary>
        /// <param name="a">Position A</param>
        /// <param name="b">Position B</param>
        /// <returns>True if equal</returns>
        public static bool operator ==(Position a, Position b)
        {
            return a.Equals(b);
        }
        
        /// <summary>
        /// Check if two positions are NOT equal
        /// </summary>
        /// <param name="a">Position A</param>
        /// <param name="b">Position B</param>
        /// <returns>True if not equal</returns>
        public static bool operator !=(Position a, Position b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Check if Position A is larger than or equal to Position B
        /// </summary>
        /// <param name="a">Position A</param>
        /// <param name="b">Position B</param>
        /// <returns>True if A is larger than or equal to B</returns>
        public static bool operator >=(Position a, Position b)
        {
            return (a.X + a.Y) >= (b.X + b.Y);
        }

        /// <summary>
        /// Check if Position B is larger than or equal to Position A
        /// </summary>
        /// <param name="a">Position A</param>
        /// <param name="b">Position B</param>
        /// <returns>True if B is larger than or equal to B</returns>
        public static bool operator <=(Position a, Position b)
        {
            return (a.X + a.Y) <= (b.X + b.Y);
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
