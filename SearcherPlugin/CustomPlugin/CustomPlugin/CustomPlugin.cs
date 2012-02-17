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
            
			if (semanticsToDict[0].Key == "search in") {

				if (semanticsToDict[1].Key == "google for") {
					if (semanticsToDict[2].Key == "Keywords") {
						string dictationForKeywords = semanticsToDict[2].Value;
                        System.Diagnostics.Process.Start("http://www.google.com/#q=" + dictationForKeywords);
					}
				}
				if (semanticsToDict[1].Key == "wikipedia for") {
					if (semanticsToDict[2].Key == "Keywords") {
						string dictationForKeywords = semanticsToDict[2].Value;
                        System.Diagnostics.Process.Start("http://en.wikipedia.com/wiki/index.php?title=Special%3ASearch&button=&search=" + dictationForKeywords);
					}
				}
				if (semanticsToDict[1].Key == "movie database for") {
					if (semanticsToDict[2].Key == "Keywords") {
						string dictationForKeywords = semanticsToDict[2].Value;
                        System.Diagnostics.Process.Start("http://www.imdb.com/find?s=all&q=" + dictationForKeywords);
					}
				}
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
    }
}
