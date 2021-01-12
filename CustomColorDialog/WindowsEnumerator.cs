using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CustomDialog
{
    public class WindowsEnumerator
    {
        private delegate int EnumCallBackDelegate(IntPtr hwnd, int lParam);

        [DllImport("user32")]
        private static extern int EnumWindows(EnumCallBackDelegate lpEnumFunc, int lParam);

        [DllImport("user32")]
        private static extern int EnumChildWindows(IntPtr hWndParent, EnumCallBackDelegate lpEnumFunc, int lParam);

        [DllImport("user32")]
        private static extern int GetClassName(IntPtr hwnd, System.Text.StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32")]
        private static extern bool IsWindowVisible(IntPtr hwnd);

        [DllImport("user32")]
        private static extern int GetParent(IntPtr hwnd);

        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, System.Text.StringBuilder lParam);

        private List<ApiWindow> _listChildren = new List<ApiWindow>();
        private List<ApiWindow> _listTopLevel = new List<ApiWindow>();

        private string _topLevelClass = string.Empty;
        private string _childClass = string.Empty;

        public ApiWindow[] GetTopLevelWindows()
        {
            EnumWindows(EnumWindowProc, 0x0);
            return _listTopLevel.ToArray();
        }

        public ApiWindow[] GetTopLevelWindows(string className)
        {
            _topLevelClass = className;
            return this.GetTopLevelWindows();
        }

        public ApiWindow[] GetChildWindows(IntPtr hwnd)
        {
            _listChildren.Clear();
            EnumChildWindows(hwnd, EnumChildWindowProc, 0x0);
            return _listChildren.ToArray();
        }

        public ApiWindow[] GetChildWindows(IntPtr hwnd, string childClass)
        {
            _childClass = childClass;
            return this.GetChildWindows(hwnd);
        }

        private Int32 EnumWindowProc(IntPtr hwnd, Int32 lParam)
        {
            if (GetParent(hwnd) == 0 && IsWindowVisible(hwnd))
            {
                ApiWindow window = GetWindowIdentification(hwnd);
                if (_topLevelClass.Length == 0 || window.ClassName.ToLower() == _topLevelClass.ToLower())
                    _listTopLevel.Add(window);
            }
            return 1;
        }

        private Int32 EnumChildWindowProc(IntPtr hwnd, Int32 lParam)
        {
            ApiWindow window = GetWindowIdentification(hwnd);
            if (_childClass.Length == 0 || window.ClassName.ToLower() == _childClass.ToLower())
                _listChildren.Add(window);
            return 1;
        }

        private ApiWindow GetWindowIdentification(IntPtr hwnd)
        {
            System.Text.StringBuilder classBuilder = new System.Text.StringBuilder(64);
            GetClassName(hwnd, classBuilder, 64);

            ApiWindow window = new ApiWindow();
            window.ClassName = classBuilder.ToString();
            window.MainWindowTitle = WindowText(hwnd);
            window.hWnd = hwnd;
            return window;
        }

        public static string WindowText(IntPtr hwnd)
        {
            const int W_GETTEXT = 0xD;
            const int W_GETTEXTLENGTH = 0xE;

            System.Text.StringBuilder SB = new System.Text.StringBuilder();
            int length = SendMessage(hwnd, W_GETTEXTLENGTH, 0, 0);
            if (length > 0)
            {
                SB = new System.Text.StringBuilder(length + 1);
                SendMessage(hwnd, W_GETTEXT, SB.Capacity, SB);
            }
            return SB.ToString();
        }
    }

}
