using ASWCGameEngine.Models.Interfaces;
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
    public List<IGameObject> GameObjects { get; set; }
    
    /// <summary>
    /// Standard constructor for new world
    /// </summary>
    /// <param name="maxWorldSizeX">The max world size on the X-axis</param>
    /// <param name="maxWorldSizeY">The max world size on the Y-axis</param>
    public World(int maxWorldSizeX, int maxWorldSizeY)
    {
        MaxWorldSizeX = maxWorldSizeX;
        MaxWorldSizeY = maxWorldSizeY;
        GameObjects = new List<IGameObject>();

        GameLogger.LogInformation(0, $"World was created : ({MaxWorldSizeX}, {MaxWorldSizeY}) : {GameObjects.Count} objects");
    }


    public World(int maxWorldSizeX, int maxWorldSizeY, List<IGameObject> gameObjects)
    {
        MaxWorldSizeX = maxWorldSizeX;
        MaxWorldSizeY = maxWorldSizeY;
        GameObjects = gameObjects;

        GameLogger.LogInformation(0, $"World was created : ({MaxWorldSizeX}, {MaxWorldSizeY}) : {GameObjects.Count} objects");
    }

    /// <summary>
    /// Load from config file
    /// </summary>
    /// <param name="configFilePath">The full path of the file</param>
    /// <exception cref="FileNotFoundException">Thrown if the file does not exist</exception>
    public World(string configFilePath, string? gameObjFilePath = null)
    {
        Configuration.LoadConfig(configFilePath);
        Configuration conf = Configuration.Instance;

        if (gameObjFilePath != null) {
            XmlSerializer gameObjSerializer = new XmlSerializer(typeof(Creature));

            using (Stream reader = new FileStream(gameObjFilePath, FileMode.Open)) 
            {
                GameObjects = (List<IGameObject>)gameObjSerializer.Deserialize(reader)!;
            }
        }
        else { GameObjects = new List<IGameObject>(); }

        MaxWorldSizeX = conf.MaxWorldSizeX;
        MaxWorldSizeY = conf.MaxWorldSizeY;

        GameLogger.LogInformation(0, $"World was created : ({MaxWorldSizeX}, {MaxWorldSizeY}) : {GameObjects.Count} objects");
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public World() { }
}
