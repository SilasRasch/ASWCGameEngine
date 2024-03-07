namespace ASWCGameEngine;

public abstract class WorldObject
{
    /// <summary>
    /// Object name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Is item able to be picked-up by creatures
    /// </summary>
    public bool Lootable { get; set; }
    
    /// <summary>
    /// Is item able to be removed or is it static?
    /// </summary>
    public bool Removable { get; set; }

    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="name">Object name</param>
    /// <param name="lootable">Is item able to be picked-up</param>
    /// <param name="removable">Is item able to be removed</param>
    public WorldObject(string name, bool lootable, bool removable)
    {
        Name = name;
        Lootable = lootable;
        Removable = removable;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public WorldObject() { }
}
