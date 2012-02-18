using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;

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

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			Login();
		}

		private void Login()
		{
			if (textBoxPassword.Text != String.Empty && textBoxUsername.Text != String.Empty)
			{
				this.mGmailUsername = this.textBoxUsername.Text;
				this.mGmailPassword = this.textBoxPassword.Text;
				this.Close();
			}
			else
			{
				RadMessageBox.Show("Моля, въведете коректни данни!");
			}
		}

		private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Login();
			}
		}
    }
}
