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

        /// <summary>
        /// Is called to check whether or not a creature should change its health state depending on its current health
        /// </summary>
        /// <param name="creature">The creature of which the health state is to be changed</param>
        /// <param name="health">The current health of the creature</param>
        public static void StateChangeCheck(Creature creature)
        {
            Type initialState = creature.HealthState.GetType();

            foreach (HealthState state in healthStates)
            {
                if (creature.Health >= state.lowerLimit && creature.Health <= state.upperLimit)
                {
                    Type type = state.GetType();
                    ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(HealthState) });
                    creature.HealthState = (HealthState) ctor.Invoke(new Object[] { creature.HealthState });

                    if (type != initialState) // Only log when there is an actual change
                        GameLogger.LogInformation(1, $"{creature.Name} changed health state to {creature.HealthState.GetType()}");
                }
            }
        }
    }
}
