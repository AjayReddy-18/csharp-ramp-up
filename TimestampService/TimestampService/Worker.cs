public class Worker : BackgroundService
{
    private readonly string filePath;

    public Worker()
    {
        filePath = Path.Combine(AppContext.BaseDirectory, "TimestampLog.txt");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Service running";
            await File.AppendAllTextAsync(filePath, log + Environment.NewLine);
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
