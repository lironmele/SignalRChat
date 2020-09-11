using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatTest
{
    public partial class Main : UserControl
    {
        HubConnection hubConnection;
        readonly string user;
        public string currentChat;
        public Main(string user)
        {
            this.user = user;
            InitializeComponent();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(ConfigurationManager.AppSettings["URL"] + "/chatHub")
                .Build();

            await Connect();

            hubConnection.On<string, string, string>("RecieveMessage", (chat, user, message) =>
            {
                if (currentChat == chat)
                    richTxtChat.Text += $"<{user}> {message}\n";
            });

            await hubConnection.InvokeAsync("RecieveChatList", user);
        }

        private async void Main_FormClosing(object sender, EventArgs e)
        {
            await Disconnect();
        }

        async Task Connect()
        {
            await hubConnection.StartAsync();
        }

        async Task Disconnect()
        {
            await hubConnection.StopAsync();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            await hubConnection.InvokeAsync("SendMessage", currentChat, user, txtMessage.Text);

            txtMessage.Clear();
        }
        private async void SelectChat(string chat)
        {
            richTxtChat.Clear();
            currentChat = chat;
            await hubConnection.SendAsync("RecieveChatHistory", currentChat);
        }
    }
}
