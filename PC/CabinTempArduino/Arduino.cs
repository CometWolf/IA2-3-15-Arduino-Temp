using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace CabinTempArduino
{
    public class Arduino
    {
        int baudrate;
        SerialPort port;
        public static string indata;
        public static bool receivedData = false;

        public Arduino(int baudrate, string portname)
        {
                this.baudrate = baudrate;
                port = new SerialPort(portname, baudrate);
                if (!port.IsOpen)
                {
                    port.Open();
                }
                port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        public string Received()
        {
            try
            {
                string received = "";
                if (receivedData)
                {

                    receivedData = false;
                    received = indata;
                }
                return received;
            }
            catch(System.IO.IOException ex)
            {
                throw ex;
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            indata = sp.ReadLine();
            receivedData = true;
        }

        public void Send(string text)
        {
            try
            {
                port.WriteLine(text);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
