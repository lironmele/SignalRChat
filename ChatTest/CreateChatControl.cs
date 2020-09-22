using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatTest
{
    public partial class CreateChatControl : UserControl
    {
        HubConnection hubConnection;
        public List<CheckBox> users;
        Main parent;
        public TextBox chatName;
        public CreateChatControl(HubConnection hubConnection, Main parent)
        {
            this.hubConnection = hubConnection;
            this.parent = parent;
            users = new List<CheckBox>();
            InitializeComponent();
        }

        private void CheckChange(object sender, EventArgs e)
        {
            if (users.All(u => u.Checked == false))
                parent.btnCreateChat.Text = "Back To Chat List";
            else
                parent.btnCreateChat.Text = "Create Chat";
        }

        private void CreateChatControl_Load(object sender, EventArgs e)
        {
            hubConnection.On<string>("RecieveUsername", (name) =>
            {
                if (name != parent.user)
                {
                    users.Add(new CheckBox());
                    users.Last().CheckedChanged += CheckChange;
                    users.Last().Top = Controls[Controls.Count - 1].Bottom + 5;
                    Controls.Add(users.Last());
                }
            });
            hubConnection.InvokeAsync("RecieveUserList");
        }
    }
}
