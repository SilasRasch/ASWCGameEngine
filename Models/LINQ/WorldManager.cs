using ASWCGameEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models.LINQ
{
    public static class WorldManager
    {
        /// <summary>
        /// Reduce game object to only id and position vector.
        /// </summary>
        /// <param name="gameObjects">The game object list to iterate through</param>
        /// <param name="condition">Nullable conditional statement if only a select amount of game objects are wanted</param>
        /// <returns></returns>
        public static List<GameObjectTransformed> GameObjectToPositionTransformer(List<IGameObject>? gameObjects = null, Func<IGameObject, bool>? condition = null)
        {
            IEnumerable<IGameObject> objects = new List<IGameObject>();
            
            if (gameObjects != null)
            {
                objects = gameObjects;
            }
            else
            {
                objects = Configuration.Instance.CurrentWorld.GameObjects;
            }
            
            
            if (condition != null)
            {
                objects = objects.Where(condition);
            }
                
            return objects.Select(obj => new GameObjectTransformed(obj.Id, obj.Position)).ToList();
        }
    }
}
