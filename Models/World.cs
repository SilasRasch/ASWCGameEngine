namespace ASWCGameEngine;

public abstract class World
{
    /// <summary>
    /// The max world size on the X-axis
    /// </summary>
    public int MaxWorldSizeX { get; set; }
    
    /// <summary>
    /// The max world size on the Y-axis
    /// </summary>
    public int MaxWorldSizeY { get; set; }
    
    /// <summary>
    /// The world's list of world objects
    /// </summary>
    public List<WorldObject> WorldObjects { get; set; }
    
    /// <summary>
    /// The world's list of creatures
    /// </summary>
    public List<Creature> Creatures { get; set; }
    
    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="maxWorldSizeX">The max world size on the X-axis</param>
    /// <param name="maxWorldSizeY">The max world size on the Y-axis</param>
    public World(int maxWorldSizeX, int maxWorldSizeY)
    {
        MaxWorldSizeX = maxWorldSizeX;
        MaxWorldSizeY = maxWorldSizeY;
        WorldObjects = new List<WorldObject>();
        Creatures = new List<Creature>();
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public World() { }
}
