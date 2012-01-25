using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ModernSteward
{
    public class AppSwitcher
    {
        public void SwitchAhead(int number)
        {
            KeyboardSend.KeyDown(Keys.Alt);
            for (int i = 0; i < number; ++i)
            {
                KeyboardSend.KeyDown(Keys.Tab);
                KeyboardSend.KeyUp(Keys.Tab);
            }
            KeyboardSend.KeyUp(Keys.Alt);
        }
        public void SwitchToApp(int number)
        {
            try
            {
                KeyboardSend.KeyDown(Keys.LWin);
                KeyboardSend.KeyDown(NumToKey(number));
                KeyboardSend.KeyUp(Keys.LWin);
                KeyboardSend.KeyUp(NumToKey(number));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException("AppSwitcher.SwitchToApp() method was invoked with invalid argument", ex);
            }
        }
        private Keys NumToKey(int number)
        {
            switch (number)
            {
                case 1: return Keys.D1;
                case 2: return Keys.D2;
                case 3: return Keys.D3;
                case 4: return Keys.D4;
                case 5: return Keys.D5;
                case 6: return Keys.D6;
                case 7: return Keys.D7;
                case 8: return Keys.D8;
                case 9: return Keys.D9;
                default:
                    throw new ArgumentOutOfRangeException("AppSwitcher.NumToKey() method was invoked with invalid argument");
            }
        }
    }
}
