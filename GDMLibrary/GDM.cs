using System.IO.Ports;
using System.Text;


/// <summary>
/// This code has been written by Piette Dylan, @Kamigoro on Github
/// Feel free to use it, make comments, contact me or anything.
/// dylan-piette@hotmail.fr
/// </summary>


namespace GDMLibrary
{
    public class GDM
    {

        public SerialPort SerialPort { get; set; }

        public GDM(string comPort, int baudRate)
        {
            SerialPort = new SerialPort(comPort);
            if (SerialPort.IsOpen)
            {
                SerialPort.Close();
            }
            SerialPort.BaudRate = baudRate;
            SerialPort.Parity = Parity.None;
            SerialPort.StopBits = StopBits.One;
            SerialPort.DataBits = 8;
            SerialPort.Open();
        }

        /// <summary>
        /// Close the current connection to the GDM if there is one existing.
        /// </summary>
        public void CloseConnection()
        {
            if (SerialPort.IsOpen)
            {
                SerialPort.Close();
            }
        }

        /// <summary>
        /// Write the command specified on the serial port.
        /// </summary>
        /// <param name="command"></param>
        public void WriteCommand(string command)
        {
            SerialPort.Write(command);
        }

        /// <summary>
        /// Put the DMM into a reset mode.
        /// </summary>
        public void Reset()
        {
            SerialPort.Write("*RST\r\n");
        }

        /// <summary>
        /// Configure the detector rate.
        /// </summary>
        /// <param name="rate">Slow, Medium or Fast</param>
        public void ConfigureDetectorRate(string rate)
        {
            SerialPort.Write("sens:det:rate " + rate + "\r\n");
        }

        /// <summary>
        /// Configure the first display with 3 parameters.
        /// </summary>
        /// <param name="signalType">Current, Voltage, Temperature, Resistance...</param>
        /// <param name="function">AC, DC, or DCAC</param>
        /// <param name="range">See GDM-8351 User Manual page 111 https://www.gwinstek.com/en-global/products/downloadSeriesDownNew/9496/658 </param>
        public void ConfigureFirstDisplay(string signalType, string function, string range)
        {
            SerialPort.Write("conf:" + signalType + ":" + function + " " + range + "\r\n");
        }

        /// <summary>
        /// Configure the first display with 2 parameters.
        /// </summary>
        /// <param name="signalType">Current, Voltage, Temperature, Resistance...</param>
        /// <param name="range">See GDM-8351 User Manual page 111 https://www.gwinstek.com/en-global/products/downloadSeriesDownNew/9496/658 </param>
        public void ConfigureFirstDisplay(string signalType, string range)
        {
            SerialPort.Write("conf:" + signalType + ": " + range + "\r\n");
        }

        /// <summary>
        /// Specify the number of samples wanted
        /// </summary>
        /// <param name="sampleCount"></param>
        public void SetSampleCount(int sampleCount)
        {
            SerialPort.Write("samp:count " + sampleCount + "\r\n");
        }

        /// <summary>
        /// Query the values of the first display.Return the number of samples previously specified. Return one value if the number of samples has not been previously specified.
        /// </summary>
        public void QueryFirstDisplay()
        {
            SerialPort.Write("val1?\r\n");
        }

        /// <summary>
        /// Query the values of the second display.Return the number of samples previously specified. Return one value if the number of samples has not been previously specified.
        /// </summary>
        public void QuerySecondDisplay()
        {
            SerialPort.Write("val2?\r\n");
        }

        /// <summary>
        /// Query the values of all displays.Return the number of samples previously specified. Return one value if the number of samples has not been previously specified.
        /// </summary>
        public void QueryAllDisplay()
        {
            SerialPort.Write("read?\r\n");
        }

        /// <summary>
        /// Reads the data held in the buffer and returns it in string
        /// </summary>
        /// <returns></returns>
        public string ReadDataInBuffer(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            SerialPort.Read(buffer, 0, bufferSize);
            return Encoding.ASCII.GetString(buffer, 0, buffer.Length);
        }
    }
}