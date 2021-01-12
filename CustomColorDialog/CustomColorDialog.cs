using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace CustomDialog
{
    public class CustomColorDialog : ColorDialog
    {
        public event ColorChangedEventHandler ColorChanged;

        public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs e);

        private const int GA_ROOT = 2;
        private const int WM_CTLCOLOREDIT = 0x133;
        [DllImport("user32.dll")]
        public static extern IntPtr GetAncestor(IntPtr hWnd, int gaFlags);
        private List<ApiWindow> EditWindows = null;

        public CustomColorDialog()
        {
            FullOpen = true;
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WM_CTLCOLOREDIT:
                    {
                        if (EditWindows == null)
                        {
                            IntPtr mainWindow = GetAncestor(hWnd, GA_ROOT);
                            if (!mainWindow.Equals(IntPtr.Zero))
                                EditWindows = new List<ApiWindow>((new WindowsEnumerator()).GetChildWindows(mainWindow, "Edit"));
                        }

                        if (EditWindows != null && EditWindows.Count == 6)
                        {
                            string strRed = WindowsEnumerator.WindowText(EditWindows[3].hWnd);
                            string strGreen = WindowsEnumerator.WindowText(EditWindows[4].hWnd);
                            string strBlue = WindowsEnumerator.WindowText(EditWindows[5].hWnd);

                            int Red, Green, Blue;
                            if (int.TryParse(strRed, out Red))
                            {
                                if (int.TryParse(strGreen, out Green))
                                {
                                    if (int.TryParse(strBlue, out Blue))
                                        ColorChanged?.Invoke(this, new ColorChangedEventArgs(Color.FromArgb(Red, Green, Blue)));
                                }
                            }
                        }

                        break;
                    }
            }
            return base.HookProc(hWnd, msg, wParam, lParam);
        }

    }
}
