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
        public List<string> GetUsernames()
        {
            List<string> usernames = new List<string>();
            foreach (User user in Users)
                usernames.Add(user.UserName);
            return usernames;
        }
        public int ChatID { get; set; }
        public string ChatName { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
