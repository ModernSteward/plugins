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
        ElectricityManager elManager = new ElectricityManager();

        public override void Trigger(List<KeyValuePair<string, string>> semanticsToDict)
        {

            try
            {
                if (semanticsToDict[0].Key == "turn the lights")
                {
                    try
                    {
                        if (semanticsToDict[1].Key == "on")
                        {
                            elManager.SendON(1);
                        }
                    }
                    catch (Exception e) { }

                    try
                    {
                        if (semanticsToDict[1].Key == "off")
                        {
                            elManager.SendOFF(1);
                        }
                    }
                    catch (Exception e) { }

                }
            }
            catch (Exception e) { }

            try
            {
                if (semanticsToDict[0].Key == "start heating the water")
                {
                    elManager.SendON(2);
                }
            }
            catch (Exception e) { }

            try
            {
                if (semanticsToDict[0].Key == "stop heating the water")
                {
                    elManager.SendOFF(2);
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
            var initForm = new InitializeForm();
            initForm.ShowDialog();
            try
            {
                elManager = new ElectricityManager(initForm.selectedCOM, true);
            }
            catch (Exception ex)
            {
                elManager.CloseThePort();
                return false;
            }
            return true;
        }
		
		public override event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;
    }
}
