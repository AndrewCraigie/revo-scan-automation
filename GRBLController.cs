using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;

namespace RevopointScanAutomation
{
    internal class GRBLController
    {
        private SerialPort serialPort;
        private string comPortName;
        private int comPortBaudRate;

        private Thread pollingThread;
        private bool isPolling;

        public event EventHandler<string> DataReceived;

        public delegate void ErrorHandler(Exception ex);
        public event ErrorHandler ErrorOccurred;

        public GRBLController(string portName, int baudRate)
        {
            comPortName = portName;
            comPortBaudRate = baudRate;
        }

        public SerialPort GetSerialPort()
        {
            return serialPort;
        }

        public bool GetSerialPortIsOpen()
        {
            return serialPort.IsOpen;
        }

        public bool OpenPort()
        {
            try
            {
                // Close the port if it is already open
                if (serialPort != null && serialPort.IsOpen)
                    serialPort.Close();

                // Create a new SerialPort instance
                serialPort = new SerialPort(comPortName, comPortBaudRate);

                // Open the port
                serialPort.Open();
                serialPort.DataReceived += SerialPort_DataReceived;

                // Return the opened SerialPort instance
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during port opening

                // You can display an error message or log the exception here

                // Return null to indicate an exception occurred
                return false;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort receivingPort = (SerialPort)sender;
            string data = receivingPort.ReadExisting();

            // TODO handle data to update various UI elements
            // use 'idle' as trigger for other events

            if (data.Contains("Idle"))
            {
                StopPolling();
            }


            DataReceived?.Invoke(this, data);
        }

        public bool ClosePort()
        {
            try
            {
                // Close the port if it is already open
                if (serialPort != null && serialPort.IsOpen)
                {
                    StopPolling();
                    serialPort.Close();
                }


                // Return the opened SerialPort instance
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SendCommand(string command)
        {

            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.WriteLine(command);
                    StartPolling();



                    return true;
                }
                catch (Exception ex)
                {

                    ErrorOccurred?.Invoke(ex);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        private void StartPolling()
        {
            if (!isPolling)
            {
                isPolling = true;
                pollingThread = new Thread(PollGRBL);
                pollingThread.Start();
            }
        }

        internal void StopPolling()
        {
            if (isPolling)
            {
                isPolling = false;
                pollingThread.Join(); // Wait for the polling thread to stop before closing the serial port
            }
        }

        private void PollGRBL()
        {
            while (isPolling)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.WriteLine("?");

                    // Adjust the delay according to your needs
                    Thread.Sleep(200); // Wait for the response

                    // You can perform additional operations with the received data here
                }
            }
        }


    }


}
