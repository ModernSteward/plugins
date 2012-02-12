using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace ElectricityManager
{
    public class ElectricityManager
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
            catch
            {
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
            return false;
        }

        public bool SendON(string sign)
        {
            if (port.IsOpen)
            {
                port.Write(sign + "ON" + '\r');
                return true;
            }
            return false;
        }

        public bool SendOFF(string sign)
        {
            if (port.IsOpen)
            {
                port.Write(sign + "OFF" + '\r');
                return true;
            }
            return false;
        }
    }
}
