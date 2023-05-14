using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RevopointScanAutomation
{
    internal class WindowManager
    {
        private const int SW_RESTORE = 9;
        private const uint SWP_SHOWWINDOW = 0x0040;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private bool IsWindowTitleMatch(string windowTitle)
        {
            string pattern = @"RevoScan\d+$"; // Regex pattern for "RevoScan" with a trailing digit
            return Regex.IsMatch(windowTitle, pattern);
        }

        public int PopulateWindowList(ComboBox comboBox)
        {
            var windows = GetRunningRevoScanWindows();
            comboBox.Items.Clear();
            comboBox.Items.AddRange(windows.ToArray());
            return windows.Count;
        }

        private List<string> GetRunningRevoScanWindows()
        {
            var windows = new List<string>();
            NativeImports.EnumWindows((hWnd, lParam) =>
            {
                if (NativeImports.IsWindowVisible(hWnd))
                {
                    var buffer = new StringBuilder(256);
                    NativeImports.GetWindowText(hWnd, buffer, buffer.Capacity);
                    string windowTitle = buffer.ToString();
                    if (IsWindowTitleMatch(windowTitle))
                    {
                        windows.Add(windowTitle);
                    }
                }
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        public static void BringWindowToFront(IntPtr hWnd)
        {
            if (NativeImports.IsIconic(hWnd))
            {
                NativeImports.ShowWindowAsync(hWnd, SW_RESTORE);
            }

            NativeImports.SetForegroundWindow(hWnd);
        }

        public static void ResizeWindow(IntPtr hWnd, int width, int height)
        {
            NativeImports.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, width, height, SWP_SHOWWINDOW);
        }

        public static void MoveWindow(IntPtr hWnd, int x, int y)
        {
            NativeImports.SetWindowPos(hWnd, IntPtr.Zero, x, y, 0, 0, SWP_SHOWWINDOW | 0x0001 | 0x0002);
        }

        public static void MoveMouseToWindowCoordinates(IntPtr hWnd, int x, int y)
        {
            RECT windowRect;
            NativeImports.GetWindowRect(hWnd, out windowRect);

            int absoluteX = windowRect.Left + x;
            int absoluteY = windowRect.Top + y;

            NativeImports.SetCursorPos(absoluteX, absoluteY);
        }
    }
}