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
using System.Diagnostics;

namespace ModernSteward
{
	public partial class RecordCodes : Form
	{
		SerialPort arduino;

		public string ON;
		public string OFF;
		public string CHup;
		public string CHdown;
		public string VOLup;
		public string VOLdown;
		public string MUTE;
		public string COMPort;
		public bool WhiteNoiseOnVolume = false;
		public string AirON;
		public string AirOFF;
		public string AirTempUp;
		public string AirTempDown;


		public bool InitializedSuccessfully = true;

		public RecordCodes()
		{
			InitializeComponent();

			groupBoxRecording.Enabled = false;
			buttonClose.Enabled = false;

			for (int i = 0; i < 40; i++)
			{
				comboBoxCOMNames.Items.Add(i + 1);
			}
		}

		string receivedIRCode;

		void arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			this.Invoke(new MethodInvoker(delegate
			{
				ReadCode(sender, e);
			}));
		}

		void ReadCode(object sender, SerialDataReceivedEventArgs e)
		{
			SerialPort sp = (SerialPort)sender;
			//string irCode = sp.ReadExisting();

				// Create new buffer
				byte[] ReadBuffer = new byte[sp.BytesToRead];

				// Read bytes from buffer
				sp.Read(ReadBuffer, 0, ReadBuffer.Length);

				// Encode to string
				string irCode = new String(Encoding.UTF8.GetChars(ReadBuffer));

			receivedIRCode = irCode;
			// Have to make some changes to the template to make the SENDIR working
			if(irCode.Contains("UNKNOWN")){ //.StartsWith also possible but currently I don't have any remote control with unknown codes, so I use
				//.Constains just to make sure it'll work.
				string[] elements = irCode.Split(' ');
				receivedIRCode = "UNKNOWN " + (elements.Length - 2).ToString(); 
				//little hack. The received code is UNKNOWN <time_to_warm_up> <code>;
				//we don't need the time to warm up so we record only the code.
				for (int i = 2; i < elements.Length; i++)
				{
					receivedIRCode += ' ' + Math.Abs(int.Parse(elements[i])).ToString();
				}
			}
			
			textBoxReceivedIRCode.Text = receivedIRCode;
			buttonRecord.Enabled = true;
		}

		private void buttonRecord_Click(object sender, EventArgs e)
		{
			arduino.Write("RECORDIR");
			buttonRecord.Enabled = false;
		}

		private void RecordCodes_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (buttonClose.Enabled)
			{
				ON = on.Text;
				OFF = off.Text;
				CHup = chup.Text;
				CHdown = chdown.Text;
				VOLup = volup.Text;
				VOLdown = voldown.Text;
				MUTE = mute.Text;
				AirON = textBoxAirOn.Text;
				AirOFF = textBoxAirOff.Text;
				AirTempUp = textBoxAirTempUP.Text;
				AirTempDown = textBoxAirTempDown.Text;

				try //The user could just load the codes and hit close button
				{
					arduino.Close();
				}
				catch { }
			}
			else
			{
				e.Cancel = true;
			}
		}

		private void buttonOpenSelectedPort_Click(object sender, EventArgs e)
		{
			if (comboBoxCOMNames.SelectedIndex != null)
			{
				try
				{
					COMPort = "COM" + (comboBoxCOMNames.SelectedIndex + 1).ToString();
					arduino = new SerialPort(COMPort, 9600);

					arduino.DtrEnable = true;
					arduino.DataReceived += new SerialDataReceivedEventHandler(arduino_DataReceived);

					if (!arduino.IsOpen)
					{
						arduino.Open();
						groupBoxRecording.Enabled = true;
						buttonClose.Enabled = true;

						comboBoxCOMNames.Enabled = false;
						buttonOpenSelectedPort.Enabled = false;
						labelCOM.Enabled = false;
					}
					else
					{
						MessageBox.Show("The port is being used by another program! Cannot open it.");
						InitializedSuccessfully = false;
						this.Close();
					}
				}
				catch
				{
					MessageBox.Show("Error occurt. Check once again the port and try again.");
				}
			}
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();

			Stream writingStream;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				if ((writingStream = saveFileDialog.OpenFile()) != null)
				{
					using (StreamWriter writer = new StreamWriter(writingStream))
					{
						writer.WriteLine(on.Text);
						writer.WriteLine(off.Text);
						writer.WriteLine(chup.Text);
						writer.WriteLine(chdown.Text);
						writer.WriteLine(volup.Text);
						writer.WriteLine(voldown.Text);
						writer.WriteLine(mute.Text);
						writer.WriteLine(textBoxAirOn.Text);
						writer.WriteLine(textBoxAirOff.Text);
						writer.WriteLine(textBoxAirTempUP.Text);
						writer.WriteLine(textBoxAirTempDown.Text);
					}
					writingStream.Close();
				}
			}
		}

		private void buttonLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = false;

			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				using (StreamReader readingStream = new StreamReader(openFileDialog.OpenFile()))
				{
					string currentLine = null;
					int lineNum = 0;
					while ((currentLine = readingStream.ReadLine()) != null)
					{
						switch (lineNum)
						{
							case 0:
								on.Text = currentLine; break;
							case 1:
								off.Text = currentLine; break;
							case 2:
								chup.Text = currentLine; break;
							case 3:
								chdown.Text = currentLine; break;
							case 4:
								volup.Text = currentLine; break;
							case 5:
								voldown.Text = currentLine; break;
							case 6:
								mute.Text = currentLine; break;
							case 7:
								AirON = currentLine; break;
							case 8:
								AirOFF = currentLine; break;
							case 9:
								AirTempUp = currentLine; break;
							case 10:
								AirTempDown = currentLine; break;
						}
						lineNum++;
					}
					readingStream.Close();
				}
			}
		}

		private void checkBoxHasWhiteNoise_CheckedChanged(object sender, EventArgs e)
		{
			WhiteNoiseOnVolume = checkBoxHasWhiteNoise.Checked;
		}

		private void groupBoxRecording_Enter(object sender, EventArgs e)
		{

		}

		private void RecordCodes_Load(object sender, EventArgs e)
		{

		}
	}
}


