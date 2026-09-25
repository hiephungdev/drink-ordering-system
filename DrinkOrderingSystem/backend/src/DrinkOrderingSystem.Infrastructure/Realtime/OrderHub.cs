using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace DrinkOrderingSystem.Infrastructure.Realtime;

[Authorize]
public sealed class OrderHub : Hub
{
    public Task NotifyNewOrder() => Task.CompletedTask;

    public Task NotifyOrderStatusChanged() => Task.CompletedTask;

    public Task JoinKitchenGroup() => Task.CompletedTask;
}
