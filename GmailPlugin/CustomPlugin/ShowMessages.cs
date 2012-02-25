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
		/// <summary>
		/// Reads path of default browser from registry
		/// </summary>
		/// <returns></returns>
		private static string GetDefaultBrowserPath()
		{
			string key = @"htmlfile\shell\open\command";
			RegistryKey registryKey =
			Registry.ClassesRoot.OpenSubKey(key, false);
			// get default browser path
			return ((string)registryKey.GetValue(null, null)).Split('"')[1];
		}

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

			try
			{
				for (int i = 0; i < aGMailFeed.Count - 1; i++)
				{
					gridViewMessages.Rows.Add(i, aGMailFeed[i].Subject, aGMailFeed[i].FromEmail);
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
				Process.Start(GetDefaultBrowserPath(), messageURL);
			}
			catch { }
		}
	}
}
