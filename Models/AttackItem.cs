﻿using ASWCGameEngine.Models;
using System.Numerics;

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
    public AttackItem(int id, Position position, string name, int damage, int range) : base(id, position, name)
    {
        Damage = damage;
        Range = range;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public AttackItem() : base() { }

    public override string ToString()
    {
        return $"{{{nameof(Damage)}={Damage.ToString()}, {nameof(Range)}={Range.ToString()}, {nameof(Id)}={Id.ToString()}, {nameof(Position)}={Position}, {nameof(Name)}={Name}}}";
    }
}
