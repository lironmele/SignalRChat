using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("RecieveMessage", "Admin", "Welcome to the chat!");
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", user, message);
        }
    }
}
