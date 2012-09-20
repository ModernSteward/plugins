using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;
using System.Speech.Recognition;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using White.Core.UIItems.WindowItems;



namespace ModernSteward
{
    public class CustomPlugin : PluginFunctionality
    {

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

        public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
        {    
			try {
				if (semanticsToDict[0].Key == "minimize window"){
					var currentWindow = White.Core.Desktop.Instance.Windows().Find(obj => obj.IsCurrentlyActive);
					currentWindow.DisplayState = DisplayState.Minimized;
				}
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "maximize window"){
					var currentWindow = White.Core.Desktop.Instance.Windows().Find(obj => obj.IsCurrentlyActive);
					currentWindow.DisplayState = DisplayState.Maximized;
				}
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "close window"){
					var currentWindow = White.Core.Desktop.Instance.Windows().Find(obj => obj.IsCurrentlyActive);
					currentWindow.Close();
				}
			}
			catch (Exception e) { }

			try {
				if (semanticsToDict[0].Key == "restore window"){
					var currentWindow = White.Core.Desktop.Instance.Windows().Find(obj => obj.IsCurrentlyActive);
					currentWindow.DisplayState = DisplayState.Restored;
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
            //Returns true if the initialization of the plugin was successfull
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
