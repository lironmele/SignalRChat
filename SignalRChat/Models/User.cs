using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Models
{
    public class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Chats = new HashSet<Chat>();
        }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
    }
}
