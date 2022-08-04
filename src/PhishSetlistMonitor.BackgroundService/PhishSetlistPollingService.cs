using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhishSetlistMonitor.BackgroundService;

public class PhishSetlistPollingService : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly ILogger<PhishSetlistPollingService> _logger;

    public PhishSetlistPollingService(ILogger<PhishSetlistPollingService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
