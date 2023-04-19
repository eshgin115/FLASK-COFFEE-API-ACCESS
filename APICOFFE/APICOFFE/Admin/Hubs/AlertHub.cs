using APICOFFE.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace APICOFFE.Admin.Hubs;

[Authorize(Roles = RoleNames.ADMIN)]
public class AlertHub : Hub
{
    private readonly ILogger<AlertHub> _logger;
    public AlertHub(ILogger<AlertHub> logger)
    {
        _logger = logger;
    }
    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"New conenction established {Context.ConnectionId}");

        return base.OnConnectedAsync();
    }


    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"Connection disconnected {Context.ConnectionId}");

        return base.OnDisconnectedAsync(exception);
    }
}
