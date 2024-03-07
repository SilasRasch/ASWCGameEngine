namespace ASWCGameEngine;

public abstract class Item : WorldObject
{
    // TODO: Make template design pattern : https://www.dofactory.com/net/template-method-design-pattern
    // Idea: -
    
    // TODO: Make decorator design pattern : https://www.dofactory.com/net/decorator-design-pattern 
    // Idea: items can have powers.
    
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
