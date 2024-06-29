using ClassLibrary.Services;

namespace LibraryManagement.EmailWorker;

public class TimedHostedService(ILogger<TimedHostedService> logger) : IHostedService, IDisposable
{
    private Timer? _timer = null;
    private int _executionCount = 0;
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        var count = Interlocked.Increment(ref _executionCount);

        logger.LogInformation(
            "Timed Hosted Service is working. Count: {Count}", count);
    }


    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();

    }
}

