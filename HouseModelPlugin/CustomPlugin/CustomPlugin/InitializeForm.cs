using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ModernSteward
{
	public partial class InitializeForm : Form
	{
		public InitializeForm(CustomPlugin owner)
		{
			InitializeComponent();

			for (int i = 30; i >= 1; i--)
			{
				domainUpDownComPort.Items.Add("COM" + i.ToString());
			}
			domainUpDownComPort.SelectedIndex = 29;
		}

		private void buttonEditCard_Click(object sender, EventArgs e)
		{
			if (listBoxCards.SelectedItem != null)
			{
				RFIDCardCommandsEditor commandsEditor = new RFIDCardCommandsEditor((listBoxCards.SelectedItem as RFIDCard));
				commandsEditor.ShowDialog();
				if (commandsEditor.Commands != null)
				{
					(listBoxCards.SelectedItem as RFIDCard).Commands = commandsEditor.Commands;
				}
			}
		}



		private void textBoxCOM_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonOpenPort_Click(this, null);
			}
		}

		public List<RFIDCard> RFIDCards = new List<RFIDCard>();

		SerialPort arduino;
		public string COMPort;

		private void buttonOpenPort_Click(object sender, EventArgs e)
		{
			arduino = new SerialPort(COMPort, 9600);

			if (!arduino.IsOpen)
			{
				try
				{
					arduino.Open();
					MessageBox.Show("Port opened successfully");
					buttonEditCard.Enabled = true;
				}
				catch
				{
					MessageBox.Show("Could not open the port");
				}
			}
			else
			{
				MessageBox.Show("Could not open the port");
			}

			arduino.DataReceived += new SerialDataReceivedEventHandler(arduino_DataReceived);
		}

		private delegate void stringDelegate(object s);

		private void AddRFIDCard(object s)
		{
			if (listBoxCards.InvokeRequired)
			{
				stringDelegate sd = new stringDelegate(AddRFIDCard);
				this.Invoke(sd, new object[] { s });
			}
			else
			{
				listBoxCards.Items.Add(s);
			}
		}

		void arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			bool existing = false;
			var line = arduino.ReadLine();
			if (line.StartsWith("RFID"))
			{
				string cardCode = line.Substring(5);

				foreach (var item in listBoxCards.Items)
				{
					if ((item as RFIDCard).Code == cardCode)
					{
						existing = true;
					}
				}

				if (existing)
				{
					return;
				}
				else
				{
					AddRFIDCard(new RFIDCard(cardCode));
				}
			}
		}

		private void listBoxCardsToList()
		{
			RFIDCards.Clear();
			foreach (var item in listBoxCards.Items)
			{
				RFIDCards.Add((item as RFIDCard));
			}
		}

		private void domainUpDownComPort_SelectedItemChanged(object sender, EventArgs e)
		{
			COMPort = domainUpDownComPort.SelectedItem.ToString();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			string fileName = @"";

			SaveFileDialog saveFile = new SaveFileDialog();
			if (saveFile.ShowDialog() == DialogResult.OK)
			{
				fileName = saveFile.FileName;
			}

			listBoxCardsToList();

			Stream stream = null;
			try
			{
				IFormatter formatter = new BinaryFormatter();
				stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
				formatter.Serialize(stream, RFIDCards);
			}
			catch
			{
				// do nothing, just ignore any possible errors
			}
			finally
			{
				if (null != stream)
					stream.Close();
			}
		}

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			string fileName = @"";

			OpenFileDialog openFile = new OpenFileDialog();
			if (openFile.ShowDialog() == DialogResult.OK)
			{
				fileName = openFile.FileName;
			}

			Stream stream = null;
			try
			{
				IFormatter formatter = new BinaryFormatter();
				stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
				stream.Position = 0;
				RFIDCards = (List<RFIDCard>)formatter.Deserialize(stream);

				listBoxCards.Items.Clear();
				foreach (var card in RFIDCards)
				{
					AddRFIDCard(card);
				}
			}
			catch
			{
				// do nothing, just ignore any possible errors
			}
			finally
			{
				if (null != stream)
					stream.Close();
			}
		}

		private void InitializeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			listBoxCardsToList();
		}
	}
}
