using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models
{
    public abstract class AbstractObjectFactory
    {
        /// <summary>
        /// Should create a world object
        /// </summary>
        /// <returns>A finished WorldObject</returns>
        public abstract WorldObject CreateWorldObject();

        /// <summary>
        /// Should create an item
        /// </summary>
        /// <returns>A finished Item</returns>
        public abstract Item CreateItem();

        /// <summary>
        /// Should create an AttackItem
        /// </summary>
        /// <returns>A finished AttackItem</returns>
        public abstract AttackItem CreateAttackItem();
        
        /// <summary>
        /// Should create a DefenceItem
        /// </summary>
        /// <returns>A finished DefenceItem</returns>
        public abstract DefenceItem CreateDefenceItem();

        /// <summary>
        /// Should create a Creature
        /// </summary>
        /// <returns>A finished Creature</returns>
        public abstract Creature CreateCreature();
    }
}
