using System.Diagnostics;

public static class MLog
{
    private static ILog _log = new HLog();
    public static LogLevel LogLevel = LogLevel.Debug;


    [Conditional("DEBUG_DEBUG")]
    public static void Debug(object msg, params object[] args)
    {
#if DEBUG_DYNAMIC
            if (LogLevel > LogLevel.Debug)
                return;
#endif
        _log.Debug(msg, args);
    }

    [Conditional("DEBUG_DEBUG")]
    [Conditional("DEBUG_INFO")]
    public static void Info(object msg, params object[] args)
    {
#if DEBUG_DYNAMIC
            if (LogLevel > LogLevel.Info)
                return;
#endif

        _log.Info(msg, args);
    }

    [Conditional("DEBUG_DEBUG")]
    [Conditional("DEBUG_INFO")]
    [Conditional("DEBUG_WARNING")]
    public static void Warning(object msg, params object[] args)
    {
#if DEBUG_DYNAMIC
            if (LogLevel > LogLevel.Warning)
                return;
#endif

        _log.Warning(msg, args);
    }

    [Conditional("DEBUG_DEBUG")]
    [Conditional("DEBUG_INFO")]
    [Conditional("DEBUG_WARNING")]
    [Conditional("DEBUG_ERROR")]
    public static void Error(object msg, params object[] args)
    {
#if DEBUG_DYNAMIC
            if (LogLevel > LogLevel.Error)
                return;
#endif

        _log.Error(msg, args);
    }

    [Conditional("DEBUG_DEBUG")]
    [Conditional("DEBUG_INFO")]
    [Conditional("DEBUG_WARNING")]
    [Conditional("DEBUG_ERROR")]
    [Conditional("DEBUG_CRITICAL")]
    public static void Critical(object msg, params object[] args)
    {
#if DEBUG_DYNAMIC
            if (LogLevel > LogLevel.Critical)
                return;
#endif

        _log.Critical(msg, args);
    }
}