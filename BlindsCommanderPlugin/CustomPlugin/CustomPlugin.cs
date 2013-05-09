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
		public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
		{

			try
			{
				if (semanticsToDict[0].Key == "open the blinds")
				{
					port.Write("O");
				}
			}
			catch (Exception e) { }

			try
			{
				if (semanticsToDict[0].Key == "close the blinds")
				{
					port.Write("C");
				}
			}
			catch (Exception e) { }


		}

		public override GrammarBuilder GetGrammarBuilder()
		{
			Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ModernSteward.CustomPluginGrammar.xml");
			return ModernSteward.TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(stream);
		}

		private SerialPort port;

		public override bool Initialize()
		{

			try
			{
				string[] lines = System.IO.File.ReadAllLines(@"C:\BlindsCOMPort.txt");

				try
				{
					port = new SerialPort(lines[0]);

					port.BaudRate = 9600;
					port.DataBits = 8;
					port.StopBits = StopBits.One;
					port.Parity = Parity.None;
				}
				catch (Exception ex)
				{
					//System.Windows.Forms.MessageBox.Show("wrong com port! or " + ex.Message);
					throw new Exception("Wrong COM port!");
				}


				if (!port.IsOpen)
				{
					try
					{
						port.Open();
					}
					catch (Exception e)
					{
						throw new Exception("Could not open the port! " + e.Message);
					}
				}
			}
			catch
			{
				return false;
			}

			return true;
		}

		public override bool Deinitialize()
		{
			if (port.IsOpen)
			{
				port.Close();
			}
			return true;
		}

		public override event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;

		public override event EventHandler<EmulateCommandEventArgs> TryToEmulateCommand;
	}
}
