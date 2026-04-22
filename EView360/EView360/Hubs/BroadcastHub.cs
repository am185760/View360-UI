using Microsoft.AspNetCore.SignalR;

namespace EView360.Hubs
{
    public class BroadcastHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
