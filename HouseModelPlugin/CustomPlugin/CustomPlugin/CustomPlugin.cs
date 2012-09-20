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
        private void SendCommand(string command)
        {
            arduino.Write(command);
        }

        public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
        {

            string room = "";
            string status = "";

            try
            {
                if (semanticsToDict[0].Key == "Turn the lights")
                {
                    try
                    {
                        if (semanticsToDict[1].Key == "in the")
                        {
                            try
                            {
                                if (semanticsToDict[2].Key == "kitchen")
                                {
                                    room = "K";
                                    try
                                    {
                                        if (semanticsToDict[3].Key == "on")
                                        {
                                            status = "ON";
                                        }
                                    }
                                    catch (Exception e) { }
                                    try
                                    {
                                        if (semanticsToDict[3].Key == "off")
                                        {
                                            status = "OFF";
                                        }
                                    }
                                    catch (Exception e) { }
                                }
                            }
                            catch (Exception e) { }

                            try
                            {
                                if (semanticsToDict[2].Key == "bathroom")
                                {
                                    room = "B";
                                    try
                                    {
                                        if (semanticsToDict[3].Key == "on")
                                        {
                                            status = "ON";
                                        }
                                    }
                                    catch (Exception e) { }

                                    try
                                    {
                                        if (semanticsToDict[3].Key == "off")
                                        {
                                            status = "OFF";
                                        }
                                    }
                                    catch (Exception e) { }

                                }
                            }
                            catch (Exception e) { }

                            try
                            {
                                if (semanticsToDict[2].Key == "ceiling")
                                {
                                    room = "C";
                                    try
                                    {
                                        if (semanticsToDict[3].Key == "on")
                                        {
                                            status = "ON";
                                        }
                                    }
                                    catch (Exception e) { }

                                    try
                                    {
                                        if (semanticsToDict[3].Key == "off")
                                        {
                                            status = "OFF";
                                        }
                                    }
                                    catch (Exception e) { }

                                }
                            }
                            catch (Exception e) { }

                            try
                            {

                                if (semanticsToDict[2].Key == "living room")
                                {
                                    room = "L";
                                    try
                                    {
                                        if (semanticsToDict[3].Key == "on")
                                        {
                                            status = "ON";
                                        }
                                    }
                                    catch (Exception e) { }

                                    try
                                    {
                                        if (semanticsToDict[3].Key == "off")
                                        {
                                            status = "OFF";
                                        }
                                    }
                                    catch (Exception e) { }
                                }
                            }
                            catch (Exception e) { }
                        }

                        SendCommand("L" + status + " " + room);

                    }
                    catch (Exception e) { }
                }

            }
            catch (Exception e) { }

            try
            {
                if (semanticsToDict[0].Key == "Turn the porchlights")
                {
                    room = "P";
                    try
                    {
                        if (semanticsToDict[1].Key == "on")
                        {
                            status = "ON";
                        }
                    }
                    catch (Exception e) { }

                    try
                    {
                        if (semanticsToDict[1].Key == "off")
                        {
                            status = "OFF";
                        }
                    }
                    catch (Exception e) { }

                    SendCommand("L" + status + " " + room);
                }
            }
            catch (Exception e) { }

            try
            {
                if (semanticsToDict[0].Key == "Show me the disco")
                {
                    SendCommand("DISCO");
                }
            }
            catch (Exception e) { }
        }

        public event EventHandler<RFIDReceivedEventArgs> RFIDReceived;

        public override GrammarBuilder GetGrammarBuilder()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ModernSteward.CustomPluginGrammar.xml");
            return ModernSteward.TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(stream);
        }

        SerialPort arduino;

        public override bool Initialize()
        {
            InitializeForm init = new InitializeForm(this);
            init.ShowDialog();
            RFIDCards = init.RFIDCards;

            arduino = new SerialPort(init.COMPort, 9600);

            if (!arduino.IsOpen)
            {
                try
                {
                    arduino.Open();
                    arduino.DataReceived += new SerialDataReceivedEventHandler(arduino_DataReceived);
                }
                catch { }
            }

            return true;
        }

		public override bool Deinitialize()
		{
			if(arduino.IsOpen){
				try
				{
					arduino.Close();
				}
				catch
				{
					return true;
				}
			}
			return true;
		}

        public override event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;

        public override event EventHandler<EmulateCommandEventArgs> TryToEmulateCommand;

        void arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string command = arduino.ReadLine();

            if (command.StartsWith("RFID")) //RFID reading
            {
                string cardName = command.Substring(5);

                var waCards = from c in RFIDCards
                              where c.Code == cardName
                              select c;

                foreach (var card in waCards)
                {
					Console.WriteLine(card.Code);
                    foreach (var c in card.Commands)
                    {
                        TryToEmulateCommand.Invoke(this, new EmulateCommandEventArgs(c));
                    }
                }
            }
        }

        public List<RFIDCard> RFIDCards { get; set; }

        public ArduinoModes mode { get; set; }
    }
}
