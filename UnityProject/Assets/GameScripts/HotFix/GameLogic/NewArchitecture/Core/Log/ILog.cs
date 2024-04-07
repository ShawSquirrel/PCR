public interface ILog
{
    void Debug(object msg, params object[] args);
    void Info(object msg, params object[] args);
    void Warning(object msg, params object[] args);
    void Error(object msg, params object[] args);
    void Critical(object msg, params object[] args);
}