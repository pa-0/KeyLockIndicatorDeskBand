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
    public partial class MyDeskBand : UserControl
    {
        UserActivityHook userActivityHook = new UserActivityHook();
        bool isNum, isCaps, isScroll;
        public MyDeskBand()
        {
            InitializeComponent();
            userActivityHook.KeyDown += new KeyEventHandler(userActivityHook_KeyDown);
            isNum = isCaps = isScroll = true;
        }

        private void userActivityHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumLock)
            {
                if (!Control.IsKeyLocked(Keys.NumLock)&& isNum)
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
                if (!Control.IsKeyLocked(Keys.Capital)&&isCaps)
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
                if (!Control.IsKeyLocked(Keys.Scroll) && isScroll)
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
            CustomColorDialog customColorDialog1 = new CustomColorDialog();
            Color oldColor = customColorDialog1.Color = lbNum.BackColor;
            customColorDialog1.ColorChanged += (o, ev) =>
            {
                lbNum.BackColor = ev.CurrentColor;
            };
            if (customColorDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveSettings();
            }
            else
            {
                lbNum.BackColor = oldColor;
            }
        }

        private void lbCaps_Click(object sender, EventArgs e)
        {
            CustomColorDialog customColorDialog1 = new CustomColorDialog();
            Color oldColor = customColorDialog1.Color = lbNum.BackColor;
            customColorDialog1.ColorChanged += (o, ev) =>
            {
                lbCaps.BackColor = ev.CurrentColor;
            };
            if (customColorDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveSettings();
            }
            else
            {
                lbCaps.BackColor = oldColor;
            }
        }

        private void lbScroll_Click(object sender, EventArgs e)
        {
            CustomColorDialog customColorDialog1 = new CustomColorDialog();
            Color oldColor = customColorDialog1.Color = lbNum.BackColor;
            customColorDialog1.ColorChanged += (o, ev) =>
            {
                lbScroll.BackColor = ev.CurrentColor;
            };
            if (customColorDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveSettings();
            }
            else
            {
                lbScroll.BackColor = oldColor;
            }
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
                isNum = lbNum.Visible = bool.Parse(array[3]);
                lbCaps.ForeColor = foreColor2;
                isCaps =lbCaps.Visible = bool.Parse(array[4]);
                lbScroll.ForeColor = foreColor3;
                isScroll = lbScroll.Visible = bool.Parse(array[5]);
            }
            if (Control.IsKeyLocked(Keys.NumLock) && isNum)
            {
                lbNum.Visible = true;
            }
            if (Control.IsKeyLocked(Keys.Capital) && isCaps)
            {
                lbCaps.Visible = true;
            }
            if (Control.IsKeyLocked(Keys.Scroll) && isScroll)
            {
                lbScroll.Visible = true;
            }
        }

        private void showNumToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            isNum = lbNum.Visible = showNumToolStripMenuItem.Checked;
            SaveSettings();
        }

        

        private void showCapsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            isCaps = lbCaps.Visible = showCapsToolStripMenuItem.Checked;
            SaveSettings();
        }

        private void showScrollToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            isScroll = lbScroll.Visible = showScrollToolStripMenuItem.Checked;
            SaveSettings();
        }
        private void SaveSettings()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine("KeyLockIndicator", "settings.setting"));
            string[] contents = new string[6]
            {
                 ColorTranslator.ToHtml(lbNum.BackColor),
                 ColorTranslator.ToHtml(lbCaps.BackColor),
                 ColorTranslator.ToHtml(lbScroll.BackColor),
                 showNumToolStripMenuItem.Checked.ToString(),
                 showCapsToolStripMenuItem.Checked.ToString(),
                 showScrollToolStripMenuItem.Checked.ToString()
            };
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllLines(path, contents);
        }
    }
}
