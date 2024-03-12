using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models.States
{
    public class HealthStateHealthy : HealthState
    {
        public HealthStateHealthy(HealthState state) : base(state)
        {
            lowerLimit = 80;
            upperLimit = 100;
            movementSpeedMultiplier = 1.2;
            damageMultiplier = 1.15;
        }
    }
}
