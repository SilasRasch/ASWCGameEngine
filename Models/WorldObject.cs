using ASWCGameEngine.Models;
using ASWCGameEngine.Models.Interfaces;
using System.Numerics;

namespace ASWCGameEngine;

public abstract class WorldObject : IGameObject
{
    /// <summary>
    /// GameObject global ID
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// GameObject position in the world 
    /// </summary>
    public Position Position { get; set; }

    /// <summary>
    /// Object name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Is item able to be picked-up by creatures
    /// </summary>
    // public bool Lootable { get; set; }
    
    /// <summary>
    /// Is item able to be removed or is it static?
    /// </summary>
    // public bool Removable { get; set; }

    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="name">Object name</param>
    /// <param name="lootable">Is item able to be picked-up</param>
    /// <param name="removable">Is item able to be removed</param>
    public WorldObject(int id, Position position, string name) //bool lootable, bool removable) -> overført til marker interfaces
    {
        Id = id;
        Position = position;
        Name = name;
        // Lootable = lootable;
        // Removable = removable;

        if (Configuration.Instance.CurrentWorld != null)
        {
            Configuration.Instance.CurrentWorld.GameObjects.Add(this);
        }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public WorldObject() { }
}
