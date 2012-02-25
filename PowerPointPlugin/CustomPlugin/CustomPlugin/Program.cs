using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSteward
{
    class Program
    {
        public static void Main() {
            SlideshowManager slideshow = new SlideshowManager(@"C:\Users\ico\Desktop\Test.pptx");
            slideshow.NextSlide();
            slideshow.NextSlide();
            slideshow.ClosePresentation();
        }
    }
}