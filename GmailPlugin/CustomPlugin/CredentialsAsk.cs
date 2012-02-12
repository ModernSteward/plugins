using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ModernSteward
{
    public partial class CredentialsAsk : RadForm
    {
        private string mGmailUsername = string.Empty;
        private string mGmailPassword = string.Empty;

        public CredentialsAsk()
        {
            InitializeComponent();
        }

        public string GmailUsername
        {
            get
            {
                return this.mGmailUsername;
            }
        }

        public string GmailPassword
        {
            get
            {
                return this.mGmailPassword;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.mGmailUsername = this.UsernameBox.Text;
            this.mGmailPassword = this.PasswordBox.Text;
            this.Close();
        }
    }
}
