using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.Win32;
using System.Diagnostics;

namespace ModernSteward
{
	public partial class ShowMessages : Telerik.WinControls.UI.RadForm
	{
		public ShowMessages(bool anyNewMessages)
		{
			InitializeComponent();

			if (anyNewMessages == false)
			{
				gridViewMessages.Visible = false;
				labelNoNewMessages.Visible = true;
			}
		}

		public ShowMessages(RC.Gmail.GmailAtomFeed.AtomFeedEntryCollection aGMailFeed)
		{
			InitializeComponent();

			gridViewMessages.MultiSelect = false;
			gridViewMessages.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect;

			gridViewMessages.EnableCustomGrouping = false;
			gridViewMessages.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

			gridViewMessages.AllowAutoSizeColumns = true;


			try
			{
				for (int i = 0; i < aGMailFeed.Count; i++)
				{
					gridViewMessages.Rows.Add(i + 1, aGMailFeed[i].Subject, aGMailFeed[i].FromEmail);
					gridViewMessages.Rows[gridViewMessages.Rows.Count - 1].Tag = aGMailFeed[i].Link;
				}
				labelNoNewMessages.Visible = false;
			}
			catch
			{
				gridViewMessages.Visible = false;
				labelNoNewMessages.Visible = true;
			}
		}

		private void gridViewMessages_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{
			try
			{
				string messageURL = e.Row.Tag.ToString();
				System.Diagnostics.Process.Start(messageURL);
			}
			catch { }
		}
	}
}
