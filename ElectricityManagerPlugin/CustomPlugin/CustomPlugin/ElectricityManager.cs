using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace ModernSteward
{
    class ElectricityManager
    {
        private SerialPort port;

        /// <summary>
        /// Initializes the ElectricityManager class
        /// </summary>
        /// <param name="comPort">The COM port in format "COM1"</param>
        /// <param name="toOpen">Sets if the port must be opened on the initializating</param>
        public ElectricityManager(string comPort, bool toOpen)
        {
            InitElectricityManager(comPort, toOpen);
        }

        /// <summary>
        /// Initializes the ElectricityManager class
        /// Default COM is COM4
        /// It does not opens the port
        /// </summary>
        public ElectricityManager()
        {
            string comPort = "COM4"; 
            bool toOpen = false;
            InitElectricityManager(comPort, toOpen);
        }

        private void InitElectricityManager(string comPort, bool toOpen){
            try
            {
                port = new SerialPort(comPort);
                
                port.BaudRate = 4800;
                port.DataBits = 8;
                port.StopBits = StopBits.One;
                port.Parity = Parity.None;
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("wrong com port! or " + ex.Message);
                throw new Exception("Wrong COM port!");
            }

            if (toOpen)
            {
                if (!port.IsOpen)
                {
                    try
                    {
                        port.Open();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Could not open the port! " + e.Message);
                    }
                }
            }
        }

        ~ElectricityManager()
        {
            CloseThePort();
        }

        public bool OpenThePort(){
            if (!port.IsOpen)
            {
                try
                {
                    port.Open();
                    return true;
                }
                catch
                {
                    throw new Exception("Could not open the port!");
                    return false;
                }
            }
            return false;
        }

        public bool CloseThePort()
        {
            try
            {
                if (port.IsOpen)
                {
                    try
                    {
                        port.Close();
                        return true;
                    }
                    catch
                    {
                        throw new Exception("Could not close the port!");
                        return false;
                    }
                }
            }
            catch { }
            return false;
        }

        public bool SendON(int number)
        {
            if (port.IsOpen)
            {
				switch (number)
				{
					case 1:
						port.Write(new byte[] { 0xFF, 0x01, 0x01 }, 0, 3);
						break;
					case 2:
						port.Write(new byte[] { 0xFF, 0x02, 0x01 }, 0, 3);
						break;
				}
                return true;
            }
            return false;
        }

        public bool SendOFF(int number)
        {
            if (port.IsOpen)
            {
				switch (number)
				{
					case 1:
						port.Write(new byte[] { 0xFF, 0x01, 0x00 }, 0, 3);
						break;
					case 2:
						port.Write(new byte[] { 0xFF, 0x02, 0x00 }, 0, 3);
						break;
				}
				return true;
            }
            return false;
        }
    }
}
