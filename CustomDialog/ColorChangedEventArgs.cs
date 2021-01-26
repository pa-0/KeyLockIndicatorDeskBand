using System;
using System.Drawing;

namespace CustomDialog
{
    public class ColorChangedEventArgs : EventArgs
    {
        public ColorChangedEventArgs(Color currentColor)
        {
            CurrentColor = currentColor;
        }

        public Color CurrentColor { get; set; }
    }
}
