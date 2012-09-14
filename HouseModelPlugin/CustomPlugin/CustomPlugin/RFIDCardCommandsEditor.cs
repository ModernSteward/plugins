using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernSteward
{
	public partial class RFIDCardCommandsEditor : Form
	{
		public List<string> Commands = new List<string>();
		private RFIDCard RFIDCard;

		public RFIDCardCommandsEditor(RFIDCard aRFIDCard)
		{
			InitializeComponent();

			RFIDCard = aRFIDCard;
			Commands = RFIDCard.Commands;

			foreach (var command in RFIDCard.Commands)
			{
				dataGridView.Rows.Add(command);
			}

			dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			Commands.Clear();
			foreach (var row in dataGridView.Rows)
			{
				foreach (var cell in (row as DataGridViewRow).Cells)
				{
					if ((cell as DataGridViewCell).Value != null)
					{
						Commands.Add((cell as DataGridViewCell).Value.ToString());
					}
				}
			}
			this.Close();
		}
	}
}
