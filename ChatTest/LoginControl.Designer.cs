﻿namespace ChatTest
{
    partial class LoginControl
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLPassword = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.lblOr = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.Label();
            this.txtRName = new System.Windows.Forms.TextBox();
            this.txtRPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(65, 318);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(219, 81);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // txtLPassword
            // 
            this.txtLPassword.Location = new System.Drawing.Point(65, 218);
            this.txtLPassword.Name = "txtLPassword";
            this.txtLPassword.Size = new System.Drawing.Size(219, 26);
            this.txtLPassword.TabIndex = 2;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(65, 141);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(219, 26);
            this.txtLName.TabIndex = 3;
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(374, 185);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(33, 20);
            this.lblOr.TabIndex = 4;
            this.lblOr.Text = "OR";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(54, 46);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(170, 64);
            this.lblLogin.TabIndex = 5;
            this.lblLogin.Text = "Login";
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegister.Location = new System.Drawing.Point(483, 48);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(245, 64);
            this.lblRegister.TabIndex = 9;
            this.lblRegister.Text = "Register";
            // 
            // txtRName
            // 
            this.txtRName.Location = new System.Drawing.Point(494, 141);
            this.txtRName.Name = "txtRName";
            this.txtRName.Size = new System.Drawing.Size(219, 26);
            this.txtRName.TabIndex = 8;
            // 
            // txtRPassword
            // 
            this.txtRPassword.Location = new System.Drawing.Point(494, 218);
            this.txtRPassword.Name = "txtRPassword";
            this.txtRPassword.Size = new System.Drawing.Size(219, 26);
            this.txtRPassword.TabIndex = 7;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(494, 318);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(219, 81);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.txtRName);
            this.Controls.Add(this.txtRPassword);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtLPassword);
            this.Controls.Add(this.btnLogin);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(822, 484);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLPassword;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.TextBox txtRName;
        private System.Windows.Forms.TextBox txtRPassword;
        private System.Windows.Forms.Button btnRegister;
    }
}
