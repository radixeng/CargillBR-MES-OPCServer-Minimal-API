namespace MESOPCServerMinimalAPI.OPCServer

{
    public class CustomLog
    {
        private readonly string _logDirectory;

        public CustomLog(string logDirectory)
        {
            _logDirectory = logDirectory;

            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }
        }

        public void Log(string message, string infoTag = "")
        {
            string fileName = $"{DateTime.Now:yyyy-MM-dd}_log.txt";
            string filePath = Path.Combine(_logDirectory, fileName);

            using (StreamWriter writer = File.AppendText(filePath))
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
