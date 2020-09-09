using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using System.Configuration;

namespace ChatTest
{
    public partial class LoginForm : Form
    {
        HubConnection hubConnection;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(ConfigurationManager.AppSettings["URL"] + "/chatHub")
                .Build();

            hubConnection.StartAsync();
            hubConnection.On<string, bool>("Login", (user, success) =>
            {
                if (success)
                {
                    hubConnection.Remove("Login");
                    hubConnection.StopAsync();
                    Login(user);
                }
                else
                    MessageBox.Show("Action Failed");
            });
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            hubConnection.InvokeAsync("AttemptLogin", txtLName.Text, txtLPassword.Text);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            hubConnection.InvokeAsync("AttemptRegister", txtRName.Text, txtRPassword.Text);
        }

        private void Login(string user)
        {
            Main main = new Main(user);
            Controls.Add(main);
            main.BringToFront();
        }

    }
}
