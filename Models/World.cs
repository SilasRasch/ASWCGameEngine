using System.Xml;
using System.Xml.Serialization;

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
    /// Standard constructor for new world
    /// </summary>
    /// <param name="maxWorldSizeX">The max world size on the X-axis</param>
    /// <param name="maxWorldSizeY">The max world size on the Y-axis</param>
    public World(int maxWorldSizeX, int maxWorldSizeY)
    {
        MaxWorldSizeX = maxWorldSizeX;
        MaxWorldSizeY = maxWorldSizeY;
        WorldObjects = new List<WorldObject>();
        Creatures = new List<Creature>();

        GameLogger.LogInformation(0, $"World was created : ({MaxWorldSizeX}, {MaxWorldSizeY}) : {Creatures.Count} Creatures - {WorldObjects.Count} World Objects");
    }


    public World(int maxWorldSizeX, int maxWorldSizeY, List<WorldObject> worldObjects, List<Creature> creatures)
    {
        MaxWorldSizeX = maxWorldSizeX;
        MaxWorldSizeY = maxWorldSizeY;
        WorldObjects = worldObjects;
        Creatures = creatures;

        GameLogger.LogInformation(0, $"World was created : ({MaxWorldSizeX}, {MaxWorldSizeY}) : {Creatures.Count} Creatures - {WorldObjects.Count} World Objects");
    }

    /// <summary>
    /// Load from config file
    /// </summary>
    /// <param name="configFilePath">The full path of the file</param>
    /// <exception cref="FileNotFoundException">Thrown if the file does not exist</exception>
    public World(string configFilePath, string? creatureFilePath = null, string? worldObjectFilePath = null)
    {
        Configuration.LoadConfig(configFilePath);
        Configuration conf = Configuration.Instance;

        if (creatureFilePath != null) {
            XmlSerializer creatureSerializer = new XmlSerializer(typeof(Creature));

            using (Stream reader = new FileStream(creatureFilePath, FileMode.Open)) 
            {
                Creatures = (List<Creature>) creatureSerializer.Deserialize(reader);
            }
        }
        else { Creatures = new List<Creature>(); }

        if (worldObjectFilePath != null) {
            XmlSerializer worldObjectSerializer = new XmlSerializer(typeof(Creature));

            using (Stream reader = new FileStream(worldObjectFilePath, FileMode.Open)) 
            {
                Creatures = (List<Creature>) worldObjectSerializer.Deserialize(reader);
            }
        }
        else { WorldObjects = new List<WorldObject>(); }

        MaxWorldSizeX = conf.MaxWorldSizeX;
        MaxWorldSizeY = conf.MaxWorldSizeY;

        GameLogger.LogInformation(0, $"World was created : ({MaxWorldSizeX}, {MaxWorldSizeY}) : {Creatures.Count} Creatures - {WorldObjects.Count} World Objects");
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public World() { }
}
