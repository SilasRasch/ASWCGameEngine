using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASWCGameEngine.Models.States
{
    public class ChangeHealthState
    {
        private static HealthStateNormal normal = new HealthStateNormal();
        private static List<HealthState> healthStates = new List<HealthState>()
        {
            normal,
            new HealthStateHealthy(normal),
            new HealthStateHurt(normal),
            new HealthStateDead(normal)
        };

        public static void StateChangeCheck(Creature creature, int health)
        {
            foreach (HealthState state in healthStates)
            {
                if (health >= state.lowerLimit && health <= state.upperLimit)
                {
                    Type type = state.GetType();
                    ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(HealthState) });
                    creature.HealthState = (HealthState) ctor.Invoke(new Object[] { creature.HealthState });
                }
            }
        }
    }
}
