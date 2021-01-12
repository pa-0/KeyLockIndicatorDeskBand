using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CustomDialog;

namespace KeyLockIndicatorDeskBand
{
    public partial class MyDeskBand: UserControl
    {
		UserActivityHook userActivityHook = new UserActivityHook();
		public MyDeskBand()
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
					lbNum.Visible = true;
				}
				else
				{
					lbNum.Visible = false;
				}
			}
			if (e.KeyCode == Keys.Capital)
			{
				if (!Control.IsKeyLocked(Keys.Capital))
				{
					lbCaps.Visible = true;
				}
				else
				{
					lbCaps.Visible = false;
				}
			}
			if (e.KeyCode == Keys.Scroll)
			{
				if (!Control.IsKeyLocked(Keys.Scroll))
				{
					lbScroll.Visible = true;
				}
				else
				{
					lbScroll.Visible = false;
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

        private void UserControl1_Load(object sender, EventArgs e)
        {
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine("KeyLockIndicator", "settings.setting"));
			if (!File.Exists(path))
			{
				string[] contents = new string[3]
				{
					ColorTranslator.ToHtml(lbNum.ForeColor),
					ColorTranslator.ToHtml(lbCaps.ForeColor),
					ColorTranslator.ToHtml(lbScroll.ForeColor)
				};
				Directory.CreateDirectory(Path.GetDirectoryName(path));
				File.WriteAllLines(path, contents);
			}
			string[] array = File.ReadAllLines(path);
			if (array.Length == 6)
			{
				Color foreColor1 = ColorTranslator.FromHtml(array[0]);
				Color foreColor2 = ColorTranslator.FromHtml(array[1]);
				Color foreColor3 = ColorTranslator.FromHtml(array[2]);
				
				lbNum.ForeColor = foreColor1;
				lbNum.Visible = bool.Parse(array[3]);
				lbCaps.ForeColor = foreColor2;
				lbCaps.Visible = bool.Parse(array[4]);
				lbScroll.ForeColor = foreColor3;
				lbScroll.Visible = bool.Parse(array[5]);
			}
			if (Control.IsKeyLocked(Keys.NumLock))
			{
				lbNum.Font = new Font(lbNum.Font, FontStyle.Bold);
			}
			if (Control.IsKeyLocked(Keys.Capital))
			{
				lbCaps.Font = new Font(lbCaps.Font, FontStyle.Bold);
			}
			if (Control.IsKeyLocked(Keys.Scroll))
			{
				lbScroll.Font = new Font(lbScroll.Font, FontStyle.Bold);
			}
		}
    }
}
