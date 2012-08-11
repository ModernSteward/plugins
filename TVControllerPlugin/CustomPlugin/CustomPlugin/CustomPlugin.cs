using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;
using System.Speech.Recognition;
using System.Reflection;
using System.IO;
using System.IO.Ports;

namespace ModernSteward
{
    public class CustomPlugin : PluginFunctionality
    {
		private const int VOLUMESTEP = 3;

        public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
        {
            
			try {
				if (semanticsToDict[0].Key == "Turn the TV on"){
					SendIRCommand(ON);
				}
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "Turn the TV off"){
					SendIRCommand(OFF);
				}
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "Next channel"){
					SendIRCommand(CHup);
				}
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "Previous channel"){
					SendIRCommand(CHdown);
				}
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "Volume up the TV") {
					if (WhiteNoiseOnVolume)
					{
						SendIRCommand(VOLup);
						for (int i = 0; i < VOLUMESTEP; i++)
						{
							SendIRCommand("NEC FFFFFFFF 0");
						}
					}
					else
					{
						for (int i = 0; i < VOLUMESTEP; i++)
						{
							SendIRCommand(VOLup);
						}
					}
				}
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "Volume down the TV"){
					if (WhiteNoiseOnVolume)
					{
						SendIRCommand(VOLdown);
						for (int i = 0; i < VOLUMESTEP; i++)
						{
							SendIRCommand("NEC FFFFFFFF 0");
						}
					}
					else
					{
						for (int i = 0; i < VOLUMESTEP; i++)
						{
							SendIRCommand(VOLdown);
						}
					}
				}
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "Mute the TV"){
					SendIRCommand(MUTE);
				}
			}
			catch (Exception e) { }
			try
			{
				if (semanticsToDict[0].Key == "Turn up the temperature")
				{
					SendIRCommand(AirTempUp);
				}
			}
			catch (Exception e) { }
			try
			{
				if (semanticsToDict[0].Key == "Turn down the temperature")
				{
					SendIRCommand(AirTempDown);
				}
			}
			catch (Exception e) { }
			try
			{
				if (semanticsToDict[0].Key == "Turn the aircondition on")
				{
					SendIRCommand(AirOn);
				}
			}
			catch (Exception e) { }
			try
			{
				if (semanticsToDict[0].Key == "Turn the aircondition off")
				{
					SendIRCommand(AirOff);
				}
			}
			catch (Exception e) { }
        }

		void SendIRCommand(string command)
		{
			arduino.Write("SENDIR " + command);
		}

        public override GrammarBuilder GetGrammarBuilder()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ModernSteward.CustomPluginGrammar.xml");
            return ModernSteward.TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(stream);
        }

		private string ON;
		private string OFF;
		private string CHup;
		private string CHdown;
		private string VOLup;
		private string VOLdown;
		private string MUTE;
		private string AirOn;
		private string AirOff;
		private string AirTempUp;
		private string AirTempDown;
		private bool WhiteNoiseOnVolume = false;

		SerialPort arduino;

        public override bool Initialize()
        {
			RecordCodes recordCodesForm = new RecordCodes();

			recordCodesForm.ShowDialog();

			if (recordCodesForm.InitializedSuccessfully)
			{
				ON = recordCodesForm.ON;
				OFF = recordCodesForm.OFF;
				CHup = recordCodesForm.CHup;
				CHdown = recordCodesForm.CHdown;
				VOLup = recordCodesForm.VOLup;
				VOLdown = recordCodesForm.VOLdown;
				MUTE = recordCodesForm.MUTE;
				AirOn = recordCodesForm.AirON;
				AirOff = recordCodesForm.AirOFF;
				AirTempUp = recordCodesForm.AirTempUp;
				AirTempDown = recordCodesForm.AirTempDown;
				WhiteNoiseOnVolume = true;

				arduino = new SerialPort(recordCodesForm.COMPort, 9600);
				arduino.DtrEnable = true;


				if (!arduino.IsOpen)
				{
					arduino.Open();
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("The port is being used by another program. Cannot initialize the plugin");
					return false;
				}

				return true;
			}

			else
			{
				return false;
			}
        }

		public override event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;
    }
}
