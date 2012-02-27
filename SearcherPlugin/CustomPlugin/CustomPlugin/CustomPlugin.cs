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
            
			try {
				if (semanticsToDict[0].Key == "search in"){

					try {
						if (semanticsToDict[2].Key == "movie database for"){

							try {
								if (semanticsToDict[4].Key == "Keywords"){
									string dictationForKeywords = semanticsToDict[4].Value;

                                    System.Diagnostics.Process.Start("http://www.imdb.com/find?s=all&q=" + dictationForKeywords);
								}
							}
							catch (Exception e) { }

						}
					}
					catch (Exception e) { }

					try {
						if (semanticsToDict[2].Key == "google for"){

							try {
								if (semanticsToDict[4].Key == "Keywords"){
									string dictationForKeywords = semanticsToDict[4].Value;
                                    System.Diagnostics.Process.Start("http://www.google.com/#q=" + dictationForKeywords);
								}
							}
							catch (Exception e) { }

						}
					}
					catch (Exception e) { }

					try {
						if (semanticsToDict[2].Key == "wikipedia for"){

							try {
								if (semanticsToDict[4].Key == "Keywords"){
									string dictationForKeywords = semanticsToDict[4].Value;

                                    System.Diagnostics.Process.Start("http://en.wikipedia.com/wiki/index.php?title=Special%3ASearch&button=&search=" + dictationForKeywords);
								}
							}
							catch (Exception e) { }

						}
					}
					catch (Exception e) { }

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
    }
}
