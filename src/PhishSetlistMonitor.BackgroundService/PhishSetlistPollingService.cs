using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PhishSetlistMonitor.Application.PollSetlists.Queries;
using PhishSetlistMonitor.BackgroundService.AppSettings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhishSetlistMonitor.BackgroundService;

public class PhishSetlistPollingService : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly ILogger<PhishSetlistPollingService> _logger;
    private readonly IMediator _mediator;
    private readonly PhishSetlistPollingServiceSettings _phishSetlistPollingServiceSettings;

    public PhishSetlistPollingService(ILogger<PhishSetlistPollingService> logger,
        IMediator mediator,
        IOptions<PhishSetlistPollingServiceSettings> phishSetlistPollingServiceSettingsAccessor)
    {
        _logger = logger;
        _mediator = mediator;
        _phishSetlistPollingServiceSettings = phishSetlistPollingServiceSettingsAccessor.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _logger.LogInformation($"{nameof(PhishSetlistPollingService)} has STARTED working.");

            var timer = new PeriodicTimer(TimeSpan.FromMinutes(_phishSetlistPollingServiceSettings.PollFrequencyMinutes));
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                // get the current setlists data
                var setlists = await _mediator.Send(new GetSetlistsQuery(), stoppingToken);
            }
        }
        catch (Exception ex) when (stoppingToken.IsCancellationRequested)
        {
            _logger.LogCritical(ex, "{ServiceName} Hosted Service is STOPPING.", nameof(PhishSetlistPollingService));
        }
        catch (Exception ex) when (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogCritical(ex, "{ServiceName} Hosted Service had an ERROR.", nameof(PhishSetlistPollingService));
        }
    }
}
