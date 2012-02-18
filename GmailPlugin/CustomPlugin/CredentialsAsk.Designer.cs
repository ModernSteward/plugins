namespace ModernSteward
{
    partial class CredentialsAsk
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
			this.labelUsername = new Telerik.WinControls.UI.RadLabel();
			this.textBoxUsername = new Telerik.WinControls.UI.RadTextBox();
			this.labelPassword = new Telerik.WinControls.UI.RadLabel();
			this.buttonLogin = new Telerik.WinControls.UI.RadButton();
			this.textBoxPassword = new Telerik.WinControls.UI.RadTextBox();
			this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
			((System.ComponentModel.ISupportInitialize)(this.labelUsername)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxUsername)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.labelPassword)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonLogin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxPassword)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
			this.radGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// labelUsername
			// 
			this.labelUsername.Location = new System.Drawing.Point(7, 21);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(31, 18);
			this.labelUsername.TabIndex = 0;
			this.labelUsername.Text = "Име:";
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(7, 45);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(161, 20);
			this.textBoxUsername.TabIndex = 1;
			this.textBoxUsername.TabStop = false;
			// 
			// labelPassword
			// 
			this.labelPassword.Location = new System.Drawing.Point(174, 21);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(45, 18);
			this.labelPassword.TabIndex = 2;
			this.labelPassword.Text = "Парола";
			// 
			// buttonLogin
			// 
			this.buttonLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonLogin.Location = new System.Drawing.Point(174, 71);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(161, 24);
			this.buttonLogin.TabIndex = 4;
			this.buttonLogin.Text = "Влез";
			this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(174, 45);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(161, 20);
			this.textBoxPassword.TabIndex = 3;
			this.textBoxPassword.TabStop = false;
			// 
			// radGroupBox1
			// 
			this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this.radGroupBox1.Controls.Add(this.buttonLogin);
			this.radGroupBox1.Controls.Add(this.textBoxPassword);
			this.radGroupBox1.Controls.Add(this.labelUsername);
			this.radGroupBox1.Controls.Add(this.textBoxUsername);
			this.radGroupBox1.Controls.Add(this.labelPassword);
			this.radGroupBox1.FooterImageIndex = -1;
			this.radGroupBox1.FooterImageKey = "";
			this.radGroupBox1.HeaderImageIndex = -1;
			this.radGroupBox1.HeaderImageKey = "";
			this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
			this.radGroupBox1.HeaderText = "Оторизация";
			this.radGroupBox1.Location = new System.Drawing.Point(12, 2);
			this.radGroupBox1.Name = "radGroupBox1";
			this.radGroupBox1.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
			// 
			// 
			// 
			this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
			this.radGroupBox1.Size = new System.Drawing.Size(340, 104);
			this.radGroupBox1.TabIndex = 0;
			this.radGroupBox1.Text = "Оторизация";
			// 
			// CredentialsAsk
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 111);
			this.Controls.Add(this.radGroupBox1);
			this.Name = "CredentialsAsk";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.Text = "Оторизация";
			this.ThemeName = "ControlDefault";
			((System.ComponentModel.ISupportInitialize)(this.labelUsername)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxUsername)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.labelPassword)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonLogin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxPassword)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
			this.radGroupBox1.ResumeLayout(false);
			this.radGroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel labelUsername;
        private Telerik.WinControls.UI.RadTextBox textBoxUsername;
        private Telerik.WinControls.UI.RadLabel labelPassword;
        private Telerik.WinControls.UI.RadButton buttonLogin;
        private Telerik.WinControls.UI.RadTextBox textBoxPassword;
		private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}