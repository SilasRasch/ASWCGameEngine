using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models.LINQ
{
    /// <summary>
    /// Purpose of this class is to use LINQ to reduce the larger IGameObject derived classes to only ID and Position.
    /// This can in turn be used for rendering a map or saving the map for later...
    /// </summary>
    public class GameObjectTransformed
    {
        /// <summary>
        /// Game object identification
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Positional data for game object
        /// </summary>
        public Position Position { get; set; }

        public GameObjectTransformed(int id, Position position)
        {
            Id = id;
            Position = position;
        }
    }
}
