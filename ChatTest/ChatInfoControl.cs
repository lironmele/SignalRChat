using System;
using System.Windows.Forms;

namespace ChatTest
{
    public partial class ChatInfoControl : UserControl
    {
        public string chatName { get; set; }
        private Main Parent { get; set; }
        public ChatInfoControl(string chatName, Main Parent)
        {
            this.chatName = chatName;
            btnOpenChat.Text = chatName;

            this.Parent = Parent;

            InitializeComponent();
        }

        private void btnOpenChat_Click(object sender, EventArgs e)
        {
            Parent.SelectChat(chatName);
        }
    }
}
