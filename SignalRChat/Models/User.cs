using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        
        public ICollection<Message> Messages { get; set; }
    }
}
