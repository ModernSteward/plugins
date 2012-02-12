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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.UsernameBox = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.LoginButton = new Telerik.WinControls.UI.RadButton();
            this.PasswordBox = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(24, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(87, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "GMail username";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(24, 37);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(161, 20);
            this.UsernameBox.TabIndex = 0;
            this.UsernameBox.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(207, 13);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(86, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "GMail password";
            // 
            // LoginButton
            // 
            this.LoginButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LoginButton.Location = new System.Drawing.Point(207, 63);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(161, 24);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(207, 37);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(161, 20);
            this.PasswordBox.TabIndex = 1;
            this.PasswordBox.TabStop = false;
            // 
            // CredentialsAsk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 101);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.radLabel1);
            this.Name = "CredentialsAsk";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CredentialsAsk";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox UsernameBox;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton LoginButton;
        private Telerik.WinControls.UI.RadTextBox PasswordBox;
    }
}