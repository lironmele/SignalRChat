using System;
using System.Collections.Generic;
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
        List<ChatInfoControl> chatList;
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

            hubConnection.On<string, List<string>>("RecieveChat", (chatName, chatUsers) =>
                {
                    if (chatUsers.Contains(user))
                    {
                        ChatInfoControl newChat = new ChatInfoControl(chatName, this);
                        if (chatList.Count > 0)
                        {
                            newChat.Top = chatList[chatList.Count - 1].Bottom + 1;
                        }
                        else
                        {
                            newChat.Top = panelChats.Bottom + 1;
                        }
                        chatList.Add(newChat);
                    }
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

        public async void SelectChat(string chat)
        {
            richTxtChat.Clear();
            currentChat = chat;
            await hubConnection.SendAsync("RecieveChatHistory", currentChat);
        }

        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            if (panelChats.Visible)
            {
                panelChats.Visible = false;
                btnCreateChat.Text = "Back To Chat List";
                //Get list of users
                //Create control to create chat
            }
            else
            {
                panelChats.Visible = true;
                btnCreateChat.Text = "Create Chat";
                //Create chat
                //Close control
            }
        }
    }
}
