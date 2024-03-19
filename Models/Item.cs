using ASWCGameEngine.Models;
using ASWCGameEngine.Models.Interfaces;
using System.Numerics;

namespace ASWCGameEngine;

public abstract class Item : WorldObject, ILootable, IRemovable
{
    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="name">Item name</param>
    public Item(int id, Position position, string name) : base(id, position, name)
    {
        // More to come
        // Maybe level required to use?
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public Item() : base() { }
}
