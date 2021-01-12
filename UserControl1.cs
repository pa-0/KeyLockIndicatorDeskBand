using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLockIndicatorDeskBand
{
    public partial class UserControl1: UserControl
    {
        UserActivityHook userActivityHook = new UserActivityHook();
        public UserControl1()
        {
            InitializeComponent();
            userActivityHook.KeyDown += new KeyEventHandler(userActivityHook_KeyDown);
        }

        private void userActivityHook_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.NumLock)
			{
				if (!Control.IsKeyLocked(Keys.NumLock))
				{
					lbNum.Font = new Font(lbNum.Font, FontStyle.Bold);
				}
				else
				{
					lbNum.Font = new Font(lbNum.Font, FontStyle.Regular);
				}
			}
			if (e.KeyCode == Keys.Capital)
			{
				if (!Control.IsKeyLocked(Keys.Capital))
				{
					lbCaps.Font = new Font(lbCaps.Font, FontStyle.Bold);
				}
				else
				{
					lbCaps.Font = new Font(lbCaps.Font, FontStyle.Regular);
				}
			}
			if (e.KeyCode == Keys.Scroll)
			{
				if (!Control.IsKeyLocked(Keys.Scroll))
				{
					lbScroll.Font = new Font(lbScroll.Font, FontStyle.Bold);
				}
				else
				{
					lbScroll.Font = new Font(lbScroll.Font, FontStyle.Regular);
				}
			}
		}

        private void lbNum_Click(object sender, EventArgs e)
        {

        }

        private void lbCaps_Click(object sender, EventArgs e)
        {

        }

        private void lbScroll_Click(object sender, EventArgs e)
        {

        }
        
    }
}
