using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModernSteward;

namespace Tester
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CustomPlugin cp = new CustomPlugin();
            cp.Initialize();

            GMailIntegration mail = new GMailIntegration(cp.GmailUsername, cp.GmailPassword);
			Console.WriteLine("New mails: {0}", mail.NewMessagesCount);

			for (int i = 0; i < mail.Entries.Count; ++i)
			{
				Console.WriteLine("{0} {1} {2}", mail.Entries[i].FromEmail, mail.Entries[i].Id, mail.Entries[i].Link);
			}

			try
			{
				ShowMessages showMessagesForm = new ShowMessages(mail.Entries);
				showMessagesForm.Show();
			}
			catch 
			{
				ShowMessages showMessagesForm = new ShowMessages(false);
				showMessagesForm.Show();
			}

            Console.ReadLine();
        }
    }
}