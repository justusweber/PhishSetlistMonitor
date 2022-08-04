using Mailjet.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhishSetlistMonitor.Application.Common.Interfaces;
using PhishSetlistMonitor.Infrastructure.HttpClients.PhishNet;
using PhishSetlistMonitor.Infrastructure.HttpClients.PhishNet.PhishNetApi;
using PhishSetlistMonitor.Infrastructure.Notifications.Email.Mailjet.Settings;
using Polly;

namespace PhishSetlistMonitor.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<MailjetSettings>(configuration.GetSection(nameof(MailjetSettings)));
        var mailjetApiKey = configuration.GetSection($"{nameof(MailjetSettings)}:ApiKey")?.Value;
        var mailjetApiSecret = configuration.GetSection($"{nameof(MailjetSettings)}:ApiSecret")?.Value;
        services.AddHttpClient<IMailjetClient, MailjetClient>(client =>
            {
                //set BaseAddress, MediaType, UserAgent
                client.SetDefaultSettings();

                client.UseBasicAuthentication(mailjetApiKey, mailjetApiSecret);
            })

            // get polly wired up to do retry on fail
            .AddTransientHttpErrorPolicy(p => p.RetryAsync(2));


        services.Configure<PhishNetApiHttpClientSettings>(configuration.GetSection(nameof(PhishNetApiHttpClientSettings)));
        services.Configure<PhishNetApiHttpClientSettingsEndpoints>(configuration.GetSection(nameof(PhishNetApiHttpClientSettingsEndpoints)));
        services.AddTransient<IRemoteSetlistClient, PhishNetClient>();
        var phishNetApiBaseUrl = configuration.GetSection("PhishNetApiHttpClientSettings:PhishNetApiBaseUrl")?.Value;
        services.AddHttpClient<PhishNetApiHttpClient>(client => client.BaseAddress = new Uri(phishNetApiBaseUrl!))
            // get polly wired up to do retry on fail
            .AddTransientHttpErrorPolicy(p => p.RetryAsync(2));

        return services;
    }
}
