using Microsoft.AspNetCore.SignalR;

namespace SignalR.API
{
    public sealed class ChatHub : Hub<IChatClient>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId} has joined");
        }

        public async Task SendMessage(string message) // websocket isteği ile "target:SendMessage" diyebiliriz
        {
            //await Clients.All.SendAsync("ReceiveMessage",$"{Context.ConnectionId}: {message}"); // bu şekilde de kullanabiliriz, interface oluşturarak da
            await Clients.All.ReceiveMessage($"{Context.ConnectionId}: {message}");
        }
    }

    public interface IChatClient
    {
        Task ReceiveMessage(string message);
    }
}
