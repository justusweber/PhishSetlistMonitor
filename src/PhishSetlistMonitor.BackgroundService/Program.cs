using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhishSetlistMonitor.Application;
using PhishSetlistMonitor.BackgroundService;
using PhishSetlistMonitor.BackgroundService.AppSettings;
using PhishSetlistMonitor.Infrastructure;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<PhishSetlistPollingServiceSettings>(context.Configuration.GetSection(nameof(PhishSetlistPollingServiceSettings)));

        services.AddHostedService<PhishSetlistPollingService>();

        services.AddApplication(context.Configuration);
        services.AddInfrastructure(context.Configuration);
    })
    .ConfigureAppConfiguration(configuration =>
    {
        configuration.AddJsonFile("appsettings.Development.json", true, false);
    })
    .Build();

await host.RunAsync();
