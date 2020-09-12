using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatTest
{
    public partial class CreateChatControl : UserControl
    {
        HubConnection hubConnection;
        List<string> users;
        string currentUser;
        public CreateChatControl(HubConnection hubConnection, string currentUser)
        {
            this.hubConnection = hubConnection;
            this.currentUser = currentUser;
            InitializeComponent();
        }

        private void CreateChatControl_Load(object sender, EventArgs e)
        {
            hubConnection.On<string>("RecieveUsername", (name) =>
            {
                if (name != currentUser)
                    users.Add(name);
            });
        }
    }
}
