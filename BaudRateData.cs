using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevopointScanAutomation
{
    internal static class BaudRateData
    {

        public static int GetDefaulBaudRate()
        {
            return 115200;
        }

        public static List<BaudRateItem> GetBaudRates()
        {
            List<BaudRateItem> baudRates = new List<BaudRateItem>
            {
                new BaudRateItem("9600", 9600),
                new BaudRateItem("19200", 19200),
                new BaudRateItem("38400", 38400),
                new BaudRateItem("57600", 57600),
                new BaudRateItem("115200", 115200)
                // Add more items as needed
            };

            return baudRates;
        }
    }
}
