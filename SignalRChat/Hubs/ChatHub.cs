using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Models;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        ChatContext context;
        public ChatHub() : base()
        {
            context = new ChatContext();
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string chat, string user, string message)
        {
            User Sender = context.Users.Where(u => u.UserName == user).FirstOrDefault();

            context.Messages.Add(new Message() { User = Sender, MessageContent = message });
            await context.SaveChangesAsync();

            await Clients.All.SendAsync("RecieveMessage", chat, user, message);
        }
        public async Task RecieveChatList(string user)
        {
            foreach (Chat chat in context.Users.Where(u => u.UserName == user).FirstOrDefault().Chats)
            {
                await Clients.Caller.SendAsync("RecieveChat", chat.ChatName);
            }
        }
        public async Task RecieveChatHistory(string Chat)
        {
            foreach (Message message in context.Chats.Where(c => c.ChatName == Chat).FirstOrDefault().Messages)
            {
                await Clients.Caller.SendAsync("RecieveMessage", Chat, message.User.UserName, message.MessageContent);
            }
        }
        public async Task AttemptRegister(string Name, string Password)
        {
            if (!context.Users.Where(u => u.UserName == Name).Any())
            {
                User _NewUser = new User() { UserName = Name, UserPassword = Password };
                context.Users.Add(_NewUser);
                await context.SaveChangesAsync();

                await Clients.Caller.SendAsync("Login", _NewUser.UserName, true);

                await Clients.All.SendAsync("RecieveUsername", _NewUser.UserName);
            }
            else
            {
                await Clients.Caller.SendAsync("Login", Name, false);
            }
        }
        public async Task AttemptLogin(string Name, string Password)
        {
            if (context.Users.Where(u => u.UserName == Name && u.UserPassword == Password).Any())
                await Clients.Caller.SendAsync("Login", Name, true);
            else
                await Clients.Caller.SendAsync("Login", Name, false);
        }
        public async Task CreateChat(string chatName, List<string> users)
        {
            if (await context.Chats.AllAsync(c => c.ChatName != chatName))
            {
                Chat newChat = new Chat() { ChatName = chatName };
                foreach (User user in context.Users.Where(u => users.Contains(u.UserName)).ToList())
                {
                    user.Chats.Add(newChat);
                    newChat.Users.Add(user);
                }
                context.Chats.Add(newChat);
                await context.SaveChangesAsync();
            }
        }
        public async Task RecieveUserList()
        {
            foreach (User User in context.Users)
            {
                await Clients.Caller.SendAsync("RecieveUsername", User.UserName);
            }
        }
    }
}
