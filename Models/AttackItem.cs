namespace ASWCGameEngine;

public abstract class AttackItem : Item
{
    /// <summary>
    /// Item's damage
    /// </summary>
    public int Damage { get; set; }
    
    /// <summary>
    /// Item's range
    /// </summary>
    public int Range { get; set; }

    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="name">Item name</param>
    /// <param name="damage">Item damage</param>
    /// <param name="range">Item range</param>
    public AttackItem(string name, int damage, int range) : base(name)
    {
        Damage = damage;
        Range = range;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public AttackItem() : base() { }
}
