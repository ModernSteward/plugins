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
        private VlcRemote vlc;
        public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
        {
            
			try {
				if (semanticsToDict[0].Key == "play some music"){
                    string path = File.ReadAllText(@"C:\MusicPath.txt");
                    vlc.Enqueue(path);
                    vlc.Play();
			    }
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "stop the music"){
                    vlc.Stop();
				}
			}
			catch (Exception e) { }


        }

        public override GrammarBuilder GetGrammarBuilder()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ModernSteward.CustomPluginGrammar.xml");
            return ModernSteward.TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(stream);
        }

        public override bool Initialize()
        {
            //Returns true if the initialization of the plugin was successful
            this.vlc = new VlcRemote();
            return true;
        }

		public override bool Deinitialize()
		{
			//Returns true if the deinitalization of the plugin was successful
			//Here you should dispose all disposable classes, close any ports in use, etc.
            vlc.Quit();
			return true;
		}
		
		public override event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;

		public override event EventHandler<EmulateCommandEventArgs> TryToEmulateCommand;
    }
}
