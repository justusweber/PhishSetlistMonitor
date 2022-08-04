﻿using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PhishSetlistMonitor.Application.Common.Interfaces;
using PhishSetlistMonitor.Infrastructure.Notifications.Email.Mailjet.Settings;

namespace PhishSetlistMonitor.Infrastructure.Notifications.Email.Mailjet;
public class PhishSetlistEmailSender : INotificationSender
{
    private readonly ILogger<PhishSetlistEmailSender> _logger;
    private readonly IMailjetClient _mailjetClient;

    public PhishSetlistEmailSender(ILogger<PhishSetlistEmailSender> logger,
        IMailjetClient mailjetClient)
    {
        _logger = logger;
        _mailjetClient = mailjetClient;
    }

    public async Task SendPhishSetlistNotificationAsync()
    {
        var request = new MailjetRequest { Resource = Send.Resource, };
    }
}