namespace ChatTest
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.richTxtChat = new System.Windows.Forms.RichTextBox();
            this.panelChats = new System.Windows.Forms.Panel();
            this.btnCreateChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(631, 374);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(241, 42);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(282, 382);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(343, 26);
            this.txtMessage.TabIndex = 1;
            // 
            // richTxtChat
            // 
            this.richTxtChat.BackColor = System.Drawing.SystemColors.Window;
            this.richTxtChat.Location = new System.Drawing.Point(282, 13);
            this.richTxtChat.Name = "richTxtChat";
            this.richTxtChat.ReadOnly = true;
            this.richTxtChat.Size = new System.Drawing.Size(590, 355);
            this.richTxtChat.TabIndex = 2;
            this.richTxtChat.TabStop = false;
            this.richTxtChat.Text = "";
            // 
            // panelChats
            // 
            this.panelChats.AutoScroll = true;
            this.panelChats.Location = new System.Drawing.Point(4, 13);
            this.panelChats.Name = "panelChats";
            this.panelChats.Size = new System.Drawing.Size(272, 355);
            this.panelChats.TabIndex = 3;
            // 
            // btnCreateChat
            // 
            this.btnCreateChat.Location = new System.Drawing.Point(4, 374);
            this.btnCreateChat.Name = "btnCreateChat";
            this.btnCreateChat.Size = new System.Drawing.Size(272, 42);
            this.btnCreateChat.TabIndex = 4;
            this.btnCreateChat.Text = "Create Chat";
            this.btnCreateChat.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCreateChat);
            this.Controls.Add(this.panelChats);
            this.Controls.Add(this.richTxtChat);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSendMessage);
            this.Name = "Main";
            this.Size = new System.Drawing.Size(875, 428);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Disposed += new System.EventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.RichTextBox richTxtChat;
        private System.Windows.Forms.Panel panelChats;
        private System.Windows.Forms.Button btnCreateChat;
    }
}

