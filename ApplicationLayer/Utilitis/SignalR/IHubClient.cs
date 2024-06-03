
namespace ApplicationLayer.Utilitis.SignalR
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
