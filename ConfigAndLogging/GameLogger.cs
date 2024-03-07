using System.Diagnostics;

namespace ASWCGameEngine;

public class GameLogger
{
    // Singleton instances
    private static GameLogger _instance = new GameLogger();
    private static readonly object padlock = new object();
    
    /// <summary>
    /// Singleton instance
    /// </summary>
    public static GameLogger Instance { get { lock (padlock) { return _instance; }}}
    
    /// <summary>
    /// The trace source
    /// </summary>
    private TraceSource _traceSource;

    /// <summary>
    /// Singleton constructor:
    /// Loads configuration from the Configuration-class
    /// </summary>
    private GameLogger() 
    {
        _traceSource = new TraceSource(Configuration.Instance.WorldName, SourceLevels.All);
        _traceSource.Switch = new SourceSwitch(Configuration.Instance.WorldName, SourceLevels.All.ToString());

        if (Configuration.Instance.LogTXT)
            _traceSource.Listeners.Add(new TextWriterTraceListener("GameLog.txt"));
            
        if (Configuration.Instance.LogXML)
            _traceSource.Listeners.Add(new XmlWriterTraceListener("GameLog.xml"));

        if (Configuration.Instance.LogConsole)
            _traceSource.Listeners.Add(new ConsoleTraceListener());
    }

    /// <summary>
    /// Method for reloading the loggers configuration in case the configuration has changed
    /// </summary>
    public static void Reload()
    {
        _instance._traceSource = new TraceSource(Configuration.Instance.WorldName, SourceLevels.All);
        _instance._traceSource.Switch = new SourceSwitch(Configuration.Instance.WorldName, SourceLevels.All.ToString());

        if (Configuration.Instance.LogTXT)
            _instance._traceSource.Listeners.Add(new TextWriterTraceListener("GameLog.txt"));
            
        if (Configuration.Instance.LogXML)
            _instance._traceSource.Listeners.Add(new XmlWriterTraceListener("GameLog.xml"));

        if (Configuration.Instance.LogConsole)
            _instance._traceSource.Listeners.Add(new ConsoleTraceListener());
    }

    /// <summary>
    /// Log an event
    /// </summary>
    /// <param name="eventType">Event type of the class TraceEventType</param>
    /// <param name="traceId">ID of the trace</param>
    /// <param name="text">Text to output in the log</param>
    public static void LogEvent(TraceEventType eventType, int traceId, string text) 
    {
        _instance._traceSource.TraceEvent(eventType, traceId, text);
    }

    /// <summary>
    /// Log an informational event
    /// </summary>
    /// <param name="traceId">ID of the trace</param>
    /// <param name="text">Text to output in the log</param>
    public static void LogInformation(int traceId, string text) 
    {
        _instance._traceSource.TraceEvent(TraceEventType.Information, traceId, text);
    }
}
