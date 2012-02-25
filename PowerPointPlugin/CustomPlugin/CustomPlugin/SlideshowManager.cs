using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace ModernSteward
{
    class SlideshowManager
    {
        private PowerPoint.Application PowerPointApp;
        private PowerPoint.Presentation Presentation;

        public SlideshowManager(string presentationFile)
        {
            this.PresentationFile = presentationFile;
            this.PowerPointApp = new PowerPoint.Application();
            this.PowerPointApp.Activate();
            Presentation = this.PowerPointApp.Presentations.Open(presentationFile);
            Presentation.SlideShowSettings.Run();
        }

        public void NextSlide()
        {
            Presentation.SlideShowWindow.View.Next();
        }

        public void PreviousSlide()
        {
            Presentation.SlideShowWindow.View.Previous();
        }

        public void ClosePresentation()
        {
            Presentation.Close();
            PowerPointApp.Quit();
        }

        public string PresentationFile
        {
            get;
            private set;
        }
    }
}
