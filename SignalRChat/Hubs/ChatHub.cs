﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task SendMessage(string user, string message)
        {
            User Sender = context.Users.Where(u => u.UserName == user).FirstOrDefault();
            
            Message _NewMessage = new Message() { User = Sender, MessageContent = message };
            
            context.Messages.Add(_NewMessage);
            await context.SaveChangesAsync();

            List<Message> debug = await context.Messages.ToListAsync();

            await Clients.All.SendAsync("RecieveMessage", user, message);
        }
        public async Task RecieveHistory()
        {
            foreach (Message message in context.Messages)
            {
                try
                {
                    await Clients.Caller.SendAsync("RecieveMessage", message.User.UserName, message.MessageContent);
                }
                catch (System.Exception e) { }
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
    }
}
