using MediatR;
using Microsoft.Extensions.Logging;
using PhishSetlistMonitor.Application.Common.Interfaces;

namespace PhishSetlistMonitor.Application.PollSetlists.Commands;

public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand, bool>
{
    private readonly ILogger<SendNotificationCommandHandler> _logger;
    private readonly INotificationSender _notificationSender;

    public SendNotificationCommandHandler(ILogger<SendNotificationCommandHandler> logger
        , INotificationSender notificationSender)
    {
        _logger = logger;
        _notificationSender = notificationSender;
    }

    public async Task<bool> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var notificationSendResult = await _notificationSender.SendPhishSetlistNotificationAsync(request.MailjetEmail, cancellationToken);
            return notificationSendResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {HandlerName}", nameof(SendNotificationCommandHandler));
            return false;
        }
    }
}
