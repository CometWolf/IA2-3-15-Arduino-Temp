using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace CabinTempArduino
{
        /*
        * Written by: Pauline Mittag Sandersen
        * 
        * This class receives, sends and retrieves information. 
        */
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
                port.DataReceived += new SerialDataReceivedEventHandler(DataReceived); //sends information to the method DataReceived
        }

        public string Received() //Return information when you ask for it. 
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

        private void DataReceived(object sender, SerialDataReceivedEventArgs e) //Received data and stored it in indata.
        {
            SerialPort sp = (SerialPort)sender;
            indata = sp.ReadLine();
            receivedData = true;
        }

        public void Send(string text) //Sending information.
        {
            try
            {
                port.WriteLine(text);
            }
            catch(Exception)
            {
                throw new System.IO.IOException("Forbindelsen mellom PC og arduino er brutt.");
            }
        }
    }
}
