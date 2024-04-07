/// <summary>
/// 日志等级
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// 调试日志
    /// </summary>
    Debug = 0,

    /// <summary>
    /// 信息日志
    /// </summary>
    Info = 1,

    /// <summary>
    /// 警告日志
    /// </summary>
    Warning = 2,

    /// <summary>
    /// 错误日志
    /// </summary>
    Error = 3,

    /// <summary>
    /// 崩溃日志
    /// </summary>
    Critical = 4,

    /// <summary>
    /// 无
    /// </summary>
    None = 5,
}

public class HLog : ILog
{
    public void Debug(object msg, params object[] args)
    {
        if (args == null || args.Length == 0)
        {
            UnityEngine.Debug.Log($"<color=grey><b>[D]\t>>></b></color>\t{msg}");
        }
        else
        {
            UnityEngine.Debug.LogFormat(msg.ToString(), args);
        }
    }

    public void Info(object msg, params object[] args)
    {
        if (args == null || args.Length == 0)
        {
            UnityEngine.Debug.Log($"<color=white><b>[I]\t>>></b></color>\t{msg}");
        }
        else
        {
            UnityEngine.Debug.LogFormat(msg.ToString(), args);
        }
    }

    public void Warning(object msg, params object[] args)
    {
        if (args == null || args.Length == 0)
        {
            UnityEngine.Debug.LogWarning($"<color=yellow><b>[W]\t>>></b></color>\t{msg}");
        }
        else
        {
            UnityEngine.Debug.LogWarningFormat(msg.ToString(), args);
        }
    }

    public void Error(object msg, params object[] args)
    {
        if (args == null || args.Length == 0)
        {
            UnityEngine.Debug.LogError($"<color=#ff0000><b>[E]\t>>></b></color>\t{msg}");
        }
        else
        {
            UnityEngine.Debug.LogError(string.Format(msg.ToString(), args));
        }
    }

    public void Critical(object msg, params object[] args)
    {
        if (args == null || args.Length == 0)
        {
            UnityEngine.Debug.LogError($"<color=#ff0000><b>[C]\t>>></b></color>\t{msg}");
        }
        else
        {
            UnityEngine.Debug.LogError(string.Format(msg.ToString(), args));
        }
    }
}