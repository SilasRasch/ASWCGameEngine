using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models.States
{
    public class HealthStateHurt : HealthState
    {
        public HealthStateHurt(HealthState state) : base(state)
        {
            upperLimit = 34;
            lowerLimit = 1;
            movementSpeedMultiplier = 0.8;
            damageMultiplier = 0.8;
        }

        //public override void StateChangeCheck()
        //{
        //    if (Health > 35)
        //    {
        //        Creature.HealthState = new HealthStateNormal(this);
        //        Creature.HealthState.StateChangeCheck();
        //    }
        //    else if (Health <= 0)
        //    {
        //        Creature.HealthState = new HealthStateDead(this);
        //        Creature.HealthState.StateChangeCheck();
        //    }
        //}
    }
}
