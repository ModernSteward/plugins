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
	public partial class InitializationForm : Form
	{
		public string PresentationFilePath;

		public InitializationForm()
		{
			InitializeComponent();
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "PowerPoint Presentation|*.ppt|PowerPoint Presentation|*.pptx";

			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				PresentationFilePath = openFileDialog.FileName;
				textBoxFilePath.Text = PresentationFilePath;
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
