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
			this.groupBoxAuth = new Telerik.WinControls.UI.RadGroupBox();
			((System.ComponentModel.ISupportInitialize)(this.labelUsername)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxUsername)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.labelPassword)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonLogin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxPassword)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBoxAuth)).BeginInit();
			this.groupBoxAuth.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// labelUsername
			// 
			this.labelUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelUsername.Location = new System.Drawing.Point(7, 21);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(31, 18);
			this.labelUsername.TabIndex = 0;
			this.labelUsername.Text = "Име:";
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUsername.Location = new System.Drawing.Point(7, 45);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(146, 20);
			this.textBoxUsername.TabIndex = 1;
			this.textBoxUsername.TabStop = false;
			// 
			// labelPassword
			// 
			this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelPassword.Location = new System.Drawing.Point(173, 21);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(47, 18);
			this.labelPassword.TabIndex = 2;
			this.labelPassword.Text = "Парола:";
			// 
			// buttonLogin
			// 
			this.buttonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonLogin.Location = new System.Drawing.Point(174, 71);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(146, 24);
			this.buttonLogin.TabIndex = 4;
			this.buttonLogin.Text = "Влез";
			this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPassword.Location = new System.Drawing.Point(174, 45);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(146, 20);
			this.textBoxPassword.TabIndex = 3;
			this.textBoxPassword.TabStop = false;
			this.textBoxPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyUp);
			// 
			// groupBoxAuth
			// 
			this.groupBoxAuth.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this.groupBoxAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxAuth.Controls.Add(this.buttonLogin);
			this.groupBoxAuth.Controls.Add(this.textBoxPassword);
			this.groupBoxAuth.Controls.Add(this.labelUsername);
			this.groupBoxAuth.Controls.Add(this.textBoxUsername);
			this.groupBoxAuth.Controls.Add(this.labelPassword);
			this.groupBoxAuth.FooterImageIndex = -1;
			this.groupBoxAuth.FooterImageKey = "";
			this.groupBoxAuth.HeaderImageIndex = -1;
			this.groupBoxAuth.HeaderImageKey = "";
			this.groupBoxAuth.HeaderMargin = new System.Windows.Forms.Padding(0);
			this.groupBoxAuth.HeaderText = "Оторизация";
			this.groupBoxAuth.Location = new System.Drawing.Point(12, 2);
			this.groupBoxAuth.Name = "groupBoxAuth";
			this.groupBoxAuth.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
			// 
			// 
			// 
			this.groupBoxAuth.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
			this.groupBoxAuth.Size = new System.Drawing.Size(325, 104);
			this.groupBoxAuth.TabIndex = 0;
			this.groupBoxAuth.Text = "Оторизация";
			// 
			// CredentialsAsk
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 111);
			this.Controls.Add(this.groupBoxAuth);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
			((System.ComponentModel.ISupportInitialize)(this.groupBoxAuth)).EndInit();
			this.groupBoxAuth.ResumeLayout(false);
			this.groupBoxAuth.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel labelUsername;
        private Telerik.WinControls.UI.RadTextBox textBoxUsername;
        private Telerik.WinControls.UI.RadLabel labelPassword;
        private Telerik.WinControls.UI.RadButton buttonLogin;
        private Telerik.WinControls.UI.RadTextBox textBoxPassword;
		private Telerik.WinControls.UI.RadGroupBox groupBoxAuth;
    }
}