﻿using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatTest
{
    public partial class Main : UserControl
    {
        HubConnection hubConnection;
        public Main()
        {
            InitializeComponent();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            string hi = ConfigurationManager.AppSettings["URL"];
            hubConnection = new HubConnectionBuilder()
                .WithUrl(ConfigurationManager.AppSettings["URL"] + "/chatHub")
                .Build();

            await Connect();

            hubConnection.On<string, string>("RecieveMessage", (user, message) =>
            {
                richTxtChat.Text += $"<{user}> {message}\n";
            });
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
            if (txtUser.ReadOnly == false)
            {
                if (txtUser.Text == "")
                    txtUser.Text = "Anonymous";
                txtUser.ReadOnly = true;
            }
            await hubConnection.InvokeAsync("SendMessage", txtUser.Text, txtMessage.Text);

            txtMessage.Clear();
        }
    }
}