using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;
using System.Speech.Recognition;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace ModernSteward
{
    public class CustomPlugin : PluginFunctionality
    {
        private CredentialsAsk CredentialForm;
        private GMailIntegration mail;

        public string GmailUsername = string.Empty;
        public string GmailPassword = string.Empty;
        public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
        {
			try
			{
				if (semanticsToDict[0].Key == "check for new mail")
				{
                    mail.GetFeed();
                    ShowMessages messagesForm = new ShowMessages(mail.Entries);
                    messagesForm.ShowDialog();
				}
			}
			catch { }
        }

        public override GrammarBuilder GetGrammarBuilder()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ModernSteward.CustomPluginGrammar.xml");
            return ModernSteward.TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(stream);
        }

        public override bool Initialize()
        {
            //Custom initialization for your plugin
            CredentialForm = new CredentialsAsk();
			CredentialForm.ShowDialog();
            this.GmailUsername = CredentialForm.GmailUsername;
            this.GmailPassword = CredentialForm.GmailPassword;

            mail = new GMailIntegration(GmailUsername, GmailPassword);
            return mail.GetFeed();
        }

		public override bool Deinitialize()
		{
			return true;
		}
		
		public override event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;

		public override event EventHandler<EmulateCommandEventArgs> TryToEmulateCommand;
    }
}
