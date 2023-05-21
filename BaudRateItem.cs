using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevopointScanAutomation
{
    internal class BaudRateItem
    {
        public string DisplayText { get; set; }
        public int Value { get; set; }

        public BaudRateItem(string displayText, int value)
        {
            DisplayText = displayText;
            Value = value;
        }
    }
}
