using System;
using System.Windows.Forms;

namespace ChatTest
{
    public partial class ChatInfoControl : UserControl
    {
        public string chatName { get; set; }
        public ChatInfoControl(string chatName)
        {
            this.chatName = chatName;
            InitializeComponent();
        }

        private void btnOpenChat_Click(object sender, EventArgs e)
        {

        }
    }
}
