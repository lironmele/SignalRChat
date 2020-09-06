using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using System.Configuration;

namespace ChatTest
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl(ConfigurationManager.AppSettings["URL"] + "/chatHub")
                .Build();

            hubConnection.StartAsync();

            hubConnection.InvokeAsync("AttemptLogin", txtLName.Text, txtLPassword.Text);

            hubConnection.StopAsync();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl(ConfigurationManager.AppSettings["URL"] + "/chatHub")
                .Build();

            hubConnection.StartAsync();

            hubConnection.InvokeAsync("AttemptRegister", txtRName.Text, txtRPassword.Text);

            hubConnection.StopAsync();
        }

        private void Login(string user)
        {
            // Open the main user control with the current user
        }
    }
}
