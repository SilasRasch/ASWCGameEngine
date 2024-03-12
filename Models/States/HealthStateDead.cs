using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models.States
{
    public class HealthStateDead : HealthState
    {
        public HealthStateDead(HealthState state) : base(state)
        {
            lowerLimit = 0;
            upperLimit = 0;
            movementSpeedMultiplier = 0;
            damageMultiplier = 0;
        }

        //public override void StateChangeCheck()
        //{
        //    if (Health >= lowerLimit && Health <= upperLimit)
        //    {
        //        Creature.HealthState = new HealthStateHurt(this);
        //        Creature.HealthState.StateChangeCheck();
        //    }
        //}
    }
}
