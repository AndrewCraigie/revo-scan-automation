using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RevopointScanAutomation
{
    internal static class WindowFinder
    {
        public static IntPtr FindWindowByCaption(string windowCaption)
        {
            IntPtr foundHwnd = IntPtr.Zero;
            NativeImports.EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                int length = NativeImports.GetWindowTextLength(hWnd);
                if (length == 0) return true;

                var stringBuilder = new System.Text.StringBuilder(length);
                NativeImports.GetWindowText(hWnd, stringBuilder, length + 1);
                var windowText = stringBuilder.ToString();

                if (windowText.Equals(windowCaption))
                {
                    foundHwnd = hWnd;
                    return false;
                }

                return true;

            }, IntPtr.Zero);

            return foundHwnd;
        }

    }
}
