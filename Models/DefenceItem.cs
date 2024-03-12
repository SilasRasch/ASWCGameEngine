using ASWCGameEngine.Models;
using System.Numerics;

namespace ASWCGameEngine;

public abstract class DefenceItem : Item
{
    /// <summary>
    /// Item damage reduction on creature
    /// </summary>
    public int ReduceDamage { get; set; }

    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="name">Item name</param>
    /// <param name="reduceDamage">Item damage reduction</param>
    public DefenceItem(int id, Position position, string name, int reduceDamage) : base(id, position, name)
    {
        ReduceDamage = reduceDamage;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public DefenceItem() : base() { }
}
