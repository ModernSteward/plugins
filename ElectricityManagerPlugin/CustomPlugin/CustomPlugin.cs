using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;
using System.Speech.Recognition;
using System.Reflection;
using System.IO;
using System.IO.Ports;
using ElectricityManager;
using System.Windows.Forms;

namespace ModernSteward
{
    public class CustomPlugin : PluginFunctionality
    {
        public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
        {
			if (semanticsToDict[0].Key == "Turn the") {
				if (semanticsToDict[1].Key == "lights") {
					if (semanticsToDict[2].Key == "on") {
                        try
                        {
                            electricityManager.SendON("A");
                        }
                        catch
                        {
                            MessageBox.Show("Could not turn the lights on");
                        }
					}
					if (semanticsToDict[2].Key == "off") {
                        try
                        {
                            electricityManager.SendOFF("A");
                        }
                        catch 
                        {
                            MessageBox.Show("Could not turn the lights off");
                        }
					}
				}
				if (semanticsToDict[1].Key == "dryer") {
					if (semanticsToDict[2].Key == "on") {
                        try
                        {
                            electricityManager.SendON("B");
                        }
                        catch
                        {
                            MessageBox.Show("Could not turn the dryer on");
                        }
					}
					if (semanticsToDict[2].Key == "off") {
                        try
                        {
                            electricityManager.SendOFF("B");
                        }
                        catch
                        {
                            MessageBox.Show("Could not turn the dryer off");
                        }
					}
				}
			}

        }

        public override GrammarBuilder GetGrammarBuilder()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ModernSteward.CustomPluginGrammar.xml");
            return ModernSteward.TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(stream);
        }

        ElectricityManager.ElectricityManager electricityManager = new ElectricityManager.ElectricityManager();

        public override void Initialize()
        {
            InitializeForm initializeForm = new InitializeForm(electricityManager);
        }
    }
}
