using DrinkOrderingSystem.Infrastructure.Realtime;

namespace DrinkOrderingSystem.API.Hubs;

public static class OrderHubReference
{
    public static Type HubType => typeof(OrderHub);
}
