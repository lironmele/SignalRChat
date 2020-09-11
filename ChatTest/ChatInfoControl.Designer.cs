namespace ChatTest
{
    partial class ChatInfoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenChat
            // 
            this.btnOpenChat.Location = new System.Drawing.Point(0, 0);
            this.btnOpenChat.Name = "btnOpenChat";
            this.btnOpenChat.Size = new System.Drawing.Size(272, 78);
            this.btnOpenChat.TabIndex = 0;
            this.btnOpenChat.UseVisualStyleBackColor = true;
            this.btnOpenChat.Click += new System.EventHandler(this.btnOpenChat_Click);
            // 
            // ChatInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOpenChat);
            this.Name = "ChatInfoControl";
            this.Size = new System.Drawing.Size(272, 78);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenChat;
    }
}
