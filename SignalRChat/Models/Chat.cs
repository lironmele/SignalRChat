using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Models
{
    public class Chat
    {
        public Chat()
        {
            Users = new HashSet<User>();
        }
        public int ChatID { get; set; }
        public string ChatName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
