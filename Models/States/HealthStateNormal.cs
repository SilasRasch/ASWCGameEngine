using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models.States
{
    public class HealthStateNormal : HealthState
    {   
        public HealthStateNormal(HealthState state) : base(state)
        {
            upperLimit = 79;
            lowerLimit = 35;
            movementSpeedMultiplier = 1.2;
            damageMultiplier = 1.15;
        }

        public HealthStateNormal(int health, Creature creature) : base(health, creature) 
        {
            upperLimit = 79;
            lowerLimit = 35;
            movementSpeedMultiplier = 1.2;
            damageMultiplier = 1.15;
        }

        /// <summary>
        /// Default constructor only for "ChangeHealthState.cs"
        /// </summary>
        public HealthStateNormal() : base()
        {
            upperLimit = 79;
            lowerLimit = 35;
            movementSpeedMultiplier = 1.2;
            damageMultiplier = 1.15;
        }
    }
}
