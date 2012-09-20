using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;
using System.Speech.Recognition;
using System.Reflection;
using System.IO;

namespace ModernSteward
{
    public class CustomPlugin : PluginFunctionality
    {
        public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
        {
			RequestGrammarUpdate.Invoke(this, new GrammarUpdateRequestEventArgs());
			AppSwitcher switcher = new AppSwitcher();
			if(semanticsToDict[0].Key == "switch to"){
				if(semanticsToDict[1].Key == "first application"){
                    switcher.SwitchToApp(1);
				}
				if(semanticsToDict[1].Key == "second application"){
                    switcher.SwitchToApp(2);
				}
				if(semanticsToDict[1].Key == "third application"){
                    switcher.SwitchToApp(3);
				}
				if(semanticsToDict[1].Key == "fourth application"){
                    switcher.SwitchToApp(4);
				}
				if(semanticsToDict[1].Key == "fifth application"){
                    switcher.SwitchToApp(5);
				}
				if(semanticsToDict[1].Key == "sixth application"){
                    switcher.SwitchToApp(6);
				}
				if(semanticsToDict[1].Key == "seventh application"){
                    switcher.SwitchToApp(7);
				}
				if(semanticsToDict[1].Key == "eighth application"){
                    switcher.SwitchToApp(8);
				}
				if(semanticsToDict[1].Key == "nineth application"){
                    switcher.SwitchToApp(9);
				}
			}
			if(semanticsToDict[0].Key == "next application"){
                switcher.SwitchAhead(1);
			}
        }

        public override GrammarBuilder GetGrammarBuilder()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ModernSteward.CustomPluginGrammar.xml");
            return ModernSteward.TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(stream);
        }

        public override bool Initialize()
        {
            //Custom initialization for your plugin
            return true;
        }

		public override bool Deinitialize()
		{
			return true;
		}

		public override event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;

		public override event EventHandler<EmulateCommandEventArgs> TryToEmulateCommand;
    }
}
