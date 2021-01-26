using SharpShell.Attributes;
using SharpShell.SharpDeskBand;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyLockIndicatorDeskBand
{
    [ComVisible(true)]
    [DisplayName("KeyLockIndicatorDeskBand")]
    public class DeskBandServer : SharpDeskBand
    {
        protected override UserControl CreateDeskBand()
        {
            return new MyDeskBand();
        }

        protected override BandOptions GetBandOptions()
        {
            return new BandOptions
            {
                HasVariableHeight = false,
                IsSunken = false,
                ShowTitle = false,
                Title = "",
                UseBackgroundColour = true,
                AlwaysShowGripper = true
            };
        }
    }
}
