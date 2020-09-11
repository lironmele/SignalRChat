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

        public virtual User User { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
