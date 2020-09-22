namespace ChatTest
{
    partial class CreateChatControl
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
            this.txtChatName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtChatName
            // 
            this.txtChatName.Location = new System.Drawing.Point(3, 3);
            this.txtChatName.Name = "txtChatName";
            this.txtChatName.Size = new System.Drawing.Size(266, 26);
            this.txtChatName.TabIndex = 1;
            this.txtChatName.Text = "Enter the chat name";
            // 
            // CreateChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.txtChatName);
            this.Name = "CreateChatControl";
            this.Size = new System.Drawing.Size(272, 355);
            this.Load += new System.EventHandler(this.CreateChatControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtChatName;
    }
}
