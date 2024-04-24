namespace MESOPCServerMinimalAPI.OPCServer
{
public class CustomLog
{
    private readonly string _logFilePath;

    public CustomLog(string logFilePath)
    {
        _logFilePath = logFilePath;

        string logDirectory = Path.GetDirectoryName(logFilePath);
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
    }

    public void Log(string message, string infoTag = "")
    {
        using (StreamWriter writer = File.AppendText(_logFilePath))
        {
            if (!string.IsNullOrEmpty(infoTag))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd-HH:mm:ss} - {message} - {infoTag}");
            }
            else
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd-HH:mm:ss} - {message}");
            }
        }
    }
}
}
