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

			setGridViewStyle();

			if (anyNewMessages == false)
			{
				gridViewMessages.Visible = false;
				labelNoNewMessages.Visible = true;
			}

			labelNoNewMessages.Location = new Point(
				this.Width / 2 - labelNoNewMessages.Width / 2, 
				this.Height / 2 - labelNoNewMessages.Height / 2);

		}

		public ShowMessages(RC.Gmail.GmailAtomFeed.AtomFeedEntryCollection aGMailFeed)
		{
			InitializeComponent();

			setGridViewStyle();

			try
			{
				if (aGMailFeed.Count != 0)
				{
					for (int i = 0; i < aGMailFeed.Count; i++)
					{
						gridViewMessages.Rows.Add(i + 1, aGMailFeed[i].Subject, aGMailFeed[i].FromEmail);
						gridViewMessages.Rows[gridViewMessages.Rows.Count - 1].Tag = aGMailFeed[i].Link;
					}
					labelNoNewMessages.Visible = false;
				}
				else
				{
					gridViewMessages.Visible = false;
					labelNoNewMessages.Visible = true;
				}
			}
			catch { }
		}

		private void setGridViewStyle()
		{

			gridViewMessages.MultiSelect = false;
			gridViewMessages.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect;

			gridViewMessages.AllowAutoSizeColumns = true;
			gridViewMessages.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

			gridViewMessages.MasterTemplate.EnableGrouping = false;
			gridViewMessages.MasterTemplate.ShowRowHeaderColumn = false;
			gridViewMessages.ShowGroupPanel = false;
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
