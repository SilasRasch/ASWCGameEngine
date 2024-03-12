namespace ASWCGameEngine;

public abstract class HealthState
{
    /// <summary>
    /// The current amount of health points
    /// </summary>
    public int Health { get; set; }
    
    /// <summary>
    /// The creature in which this state is located
    /// </summary>
    public Creature Creature { get; set; }
    
    /// <summary>
    /// Lower health limit of the state
    /// </summary>
    protected int lowerLimit;
    
    /// <summary>
    /// Upper health limit of the state
    /// </summary>
    protected int upperLimit;
    
    /// <summary>
    /// Multiplier where movement speed buff/debuff is located
    /// </summary>
    protected double movementSpeedMultiplier;
    
    /// <summary>
    /// Multiplier where damage buff/debuff is located
    /// </summary>
    protected double damageMultiplier;

    /// <summary>
    /// Constructor for changing between health states with a state change check
    /// </summary>
    /// <param name="state">The current/old state</param>
    public HealthState(HealthState state)
    {
        Health = state.Health;
        Creature = state.Creature;
    }

    /// <summary>
    /// Constructor for initializing the health state
    /// </summary>
    /// <param name="health">Initial health points</param>
    /// <param name="creature">Creature in which state is located</param>
    public HealthState(int health, Creature creature) 
    {
        Health = health;
        Creature = creature;
    }
    
    /// <summary>
    /// Method for changing between states
    /// </summary>
    protected abstract void StateChangeCheck();

    /// <summary>
    /// Subtracts damage from health pool and does a state change check
    /// </summary>
    /// <param name="damage">Damage amount</param>
    public void TakeDamage(int damage) 
    {
        Health -= damage;
        StateChangeCheck();
    }

    /// <summary>
    /// Adds health to the health pool
    /// </summary>
    /// <param name="healthToHeal">Amount of health to heal</param>
    public void Heal(int healthToHeal) 
    {
        Health += healthToHeal;
        StateChangeCheck();
        // TODO: Heal to max health
    }
}