using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace RevopointScanAutomation
{
    internal class GRBLPortScanner
    {
        public delegate void PortsCheckedHandler(List<string> arduinoPorts);
        public event PortsCheckedHandler PortsChecked;
        public delegate void ErrorHandler(Exception ex);
        public event ErrorHandler ErrorOccurred;

        private List<string> _arduinoPorts = new List<string>();
        private int _defaultBaudRate = BaudRateData.GetDefaulBaudRate();

        public GRBLPortScanner()
        {
        }

        public SerialPort OpenPort(string portName, int baudRate)
        {
            try
            {
                SerialPort _port;
                _port = new SerialPort(portName, baudRate);
                _port.Open();
                _port.DataReceived += PortToCheck_DataReceived;
                return _port;
            }
            catch (Exception ex)
            {
                // Raise the error event
                ErrorOccurred?.Invoke(ex);
                return null;
            }
        }

        public void ClosePort(SerialPort portToClose)
        {
            if (portToClose != null && portToClose.IsOpen)
            {
                try
                {
                    portToClose.Close();
                }
                catch (Exception ex)
                {
                    ErrorOccurred?.Invoke(ex);
                }
            }
        }

        private void PortToCheck_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort receivingPort = (SerialPort)sender;
                string data = receivingPort.ReadExisting();
                Debug.Print(data);
                if (data.Contains("[VER:"))
                {
                    _arduinoPorts.Add(receivingPort.PortName);
                }
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(ex);
            }
        }

        internal void GetAvailableGRBLPorts()
        {

            _arduinoPorts.Clear();

            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (var port in ports)
                {
                    SerialPort portToCheck = OpenPort(port, _defaultBaudRate);

                    if (portToCheck != null)
                    {
                        Thread.Sleep(1000);
                        CheckIfArduinoGRBL(portToCheck);
                        Thread.Sleep(1000);
                        ClosePort(portToCheck);
                    }
                    
                }

                // Raise the event after all ports are checked
                PortsChecked?.Invoke(_arduinoPorts);
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(ex);
            }
        }

        public void CheckIfArduinoGRBL(SerialPort portToCheck)
        {
            if (portToCheck != null && portToCheck.IsOpen)
            {
                try
                {
                    string buildInfoSystemCommand = EnumHelper.GetEnumDescription(GrblSystemCommand.BuildInfo);
                    portToCheck.WriteLine(buildInfoSystemCommand); // Send command to get version info
                }
                catch (Exception ex)
                {
                    ErrorOccurred?.Invoke(ex);
                }
            }
        }
    }
}
