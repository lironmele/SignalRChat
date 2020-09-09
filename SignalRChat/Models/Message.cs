using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string MessageContent { get; set; }

        public User User { get; set; }
    }
}
