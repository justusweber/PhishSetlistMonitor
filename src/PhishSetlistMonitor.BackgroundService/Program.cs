using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhishSetlistMonitor.BackgroundService;
using PhishSetlistMonitor.Infrastructure.Notifications.Email.Mailjet.Settings;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<MailjetSettings>(context.Configuration.GetSection(nameof(MailjetSettings)));

        services.AddHostedService<PhishSetlistPollingService>();
    })
    .ConfigureAppConfiguration(configuration =>
    {
        configuration.AddJsonFile("appsettings.Development.json", true, false);
    })
    .Build();

await host.RunAsync();
