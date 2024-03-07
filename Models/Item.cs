namespace ASWCGameEngine;

public abstract class Item : WorldObject
{
    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="name">Item name</param>
    public Item(string name) : base(name, true, true)
    {
        // More to come
        // Maybe level required to use?
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public Item() : base() { }
}
