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
            lowerLimit = 80;
            movementSpeedMultiplier = 1.2;
            damageMultiplier = 1.15;
        }

        public HealthStateNormal(int health, Creature creature) : base(health, creature) { }

        protected override void StateChangeCheck()
        {
            if (Health > 80)
            {
                Creature.HealthState = new HealthStateHealthy(this);
            }
            else if (Health < 35)
            {
                Creature.HealthState = new HealthStateHurt(this);
            }
        }
    }
}
