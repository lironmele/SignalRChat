using SignalRChat.Models;
using System.Data.Entity;

namespace SignalRChat
{
    public class ChatContext : DbContext
    {
        public ChatContext() : base()
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
