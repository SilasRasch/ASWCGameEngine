using System.Diagnostics;
using System.Xml;

namespace ASWCGameEngine;

public class Configuration
{
    // Singleton instances
    private static Configuration _instance = new Configuration();
    private static readonly object padlock = new object();
    
    /// <summary>
    /// Singleton instance
    /// </summary>
    public static Configuration Instance { get { lock (padlock) { return _instance; }}}
    
    /// <summary>
    /// Max size of the game world on the X-axis
    /// </summary>
    public int MaxWorldSizeX { get; set; }
    
    /// <summary>
    /// Max size of the game world on the Y-axis
    /// </summary>
    public int MaxWorldSizeY { get; set; }
    
    /// <summary>
    /// The name of the game world (in order to differentiate between them)
    /// </summary>
    public string WorldName { get; set; }
    
    /// <summary>
    /// Everything will be logged to an XML file
    /// </summary>
    public bool LogXML { get; set; }
    
    /// <summary>
    /// Everything will be logged to the console window
    /// </summary>
    public bool LogConsole { get; set; }
    
    /// <summary>
    /// Everything will be logged to a TXT file
    /// </summary>
    public bool LogTXT { get; set; }

    /// <summary>
    /// Standard constructor: 
    /// Applies some standard values to the configuration...
    /// </summary>
    private Configuration() 
    {
        MaxWorldSizeX = 1000;
        MaxWorldSizeY = 1000;
        WorldName = "new world";
        LogXML = false;
        LogConsole = false;
        LogTXT = true;
    }

    /// <summary>
    /// Loads the desired configuration file
    /// </summary>
    /// <param name="configFilePath">The relative file path of the file</param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException">Thrown if file is not found</exception>
    public static Configuration LoadConfig(string configFilePath) 
    {
        if (!File.Exists(configFilePath)) 
        {
            throw new FileNotFoundException(configFilePath);
        }

        XmlDocument config = new XmlDocument();
        config.Load(configFilePath);

        XmlNode? worldSizeXNode = config.DocumentElement.SelectSingleNode("MaxWorldSizeX");
        if (worldSizeXNode != null) 
        {
            _instance.MaxWorldSizeX = Convert.ToInt32(worldSizeXNode.InnerText.Trim());
        }
        
        XmlNode? worldSizeYNode = config.DocumentElement.SelectSingleNode("MaxWorldSizeY");
        if (worldSizeYNode != null) 
        {
            _instance.MaxWorldSizeY = Convert.ToInt32(worldSizeYNode.InnerText.Trim());
        }

        XmlNode? worldNameNode = config.DocumentElement.SelectSingleNode("WorldName");
        if (worldNameNode != null) 
        {
            _instance.WorldName = worldNameNode.InnerText.Trim();
        }

        XmlNode? logXmlNode = config.DocumentElement.SelectSingleNode("LogXML");
        if (logXmlNode != null) 
        {
            _instance.LogXML = Convert.ToBoolean(logXmlNode.InnerText.Trim());
        }
        
        XmlNode? logConsoleNode = config.DocumentElement.SelectSingleNode("LogConsole");
        if (logConsoleNode != null) 
        {
            _instance.LogConsole = Convert.ToBoolean(logConsoleNode.InnerText.Trim());
        }
        
        XmlNode? logTxtNode = config.DocumentElement.SelectSingleNode("LogTXT");
        if (logTxtNode != null) 
        {
            _instance.LogTXT = Convert.ToBoolean(logTxtNode.InnerText.Trim());
        }

        GameLogger.LogEvent(TraceEventType.Warning, 0, $"New configuration loaded : @{configFilePath}");

        return _instance;
    }
}
