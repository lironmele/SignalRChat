using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
        const string MainChatName = "MainChat";
        public ChatHub() : base()
        {
            context = new ChatContext();
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string chatName, string user, string message)
        {
            User Sender = context.Users.Where(u => u.UserName == user).FirstOrDefault();

            Chat chat;

            try
            {
                chat = context.Chats.Where(c => c.ChatName == chatName).First();
            }
            catch (System.ArgumentNullException ex)
            {
                chat = CreateMainChat();
                context.Chats.Add(chat);
            }

            Message newMessage = new Message() { User = Sender, MessageContent = message, Chat = chat };

            context.Messages.Add(newMessage);
            chat.Messages.Add(newMessage);

            await context.SaveChangesAsync();

            await Clients.All.SendAsync("RecieveMessage", chat, user, message);
        }
        public async Task RecieveChatList(string user)
        {
            foreach (Chat chat in context.Users.Where(u => u.UserName == user).FirstOrDefault().Chats)
            {
                await Clients.Caller.SendAsync("RecieveChat", chat.ChatName, chat.GetUsernames());
            }
        }
        public async Task RecieveChatHistory(string Chat)
        {
            if (context.Chats.Where(c => c.ChatName == Chat).FirstOrDefault().Messages == null)
                return;
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
                try
                {
                    _NewUser.Chats = context.Chats.Where(c => c.ChatName == MainChatName).ToList();
                }
                catch (System.ArgumentNullException ex)
                {
                    _NewUser.Chats = (ICollection<Chat>) CreateMainChat();
                }    
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

                List<string> userNames = newChat.Users.Select(u => u.UserName).ToList();
                await Clients.All.SendAsync("RecieveChat", newChat.ChatName, userNames);
            }
        }
        public async Task RecieveUserList()
        {
            foreach (User User in context.Users)
            {
                await Clients.Caller.SendAsync("RecieveUsername", User.UserName);
            }
        }
        private Chat CreateMainChat()
        {
            Chat mainChat = new Chat() { ChatName = MainChatName, Users = context.Users.ToList() };
            context.Chats.Add(mainChat);
            context.Users.ForEachAsync(u => u.Chats.Add(mainChat));
            context.SaveChanges();
            return mainChat;
        }
    }
}
