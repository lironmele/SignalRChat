using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatTest
{
    public partial class Main : UserControl
    {
        HubConnection hubConnection;
        public readonly string user;
        public string currentChat;
        List<ChatInfoControl> chatList;
        CreateChatControl createChatControl;
        public Main(string user)
        {
            this.user = user;
            InitializeComponent();
            chatList = new List<ChatInfoControl>();
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
                            newChat.Top = panelChats.Top + 1;
                        }
                        newChat.Left = Left + 5;
                        chatList.Add(newChat);
                        Controls.Add(newChat);
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
                createChatControl = new CreateChatControl(hubConnection, this);
                Controls.Add(createChatControl);
                createChatControl.BringToFront();
            }
            else
            {
                panelChats.Visible = true;
                btnCreateChat.Text = "Create Chat";
                if (createChatControl.users != null && createChatControl.users.Any(u => u.Checked == true))
                {
                    List<string> users = new List<string>();
                    users.Add(user);
                    foreach (CheckBox user in createChatControl.users.Where(u => u.Checked == true))
                        users.Add(user.Text);

                    hubConnection.InvokeAsync("CreateChat", createChatControl.txtChatName.Text, users);
                }
                Controls.Remove(createChatControl);
                createChatControl.Dispose();
            }
        }
    }
}
