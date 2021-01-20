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
        private const string FOLDER_NAME = "KeyLockIndicator";
        private const string FILE_NAME = "settings.setting";
        UserActivityHook userActivityHook = new UserActivityHook();
        bool isNum, isCaps, isScroll;
        Size size = new Size();
        public MyDeskBand()
        {
            InitializeComponent();
            userActivityHook.KeyDown += new KeyEventHandler(userActivityHook_KeyDown);
            isNum = isCaps = isScroll = true;
            size = this.Size;
        }

        private void userActivityHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumLock)
            {
                if (!Control.IsKeyLocked(Keys.NumLock) && isNum)
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
                if (!Control.IsKeyLocked(Keys.Capital) && isCaps)
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
        private void lbNum_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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
        }

        private void lbCaps_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CustomColorDialog customColorDialog1 = new CustomColorDialog();
                Color oldColor = customColorDialog1.Color = lbCaps.BackColor;
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
        }

        private void lbScroll_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CustomColorDialog customColorDialog1 = new CustomColorDialog();
                Color oldColor = customColorDialog1.Color = lbScroll.BackColor;
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
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine(FOLDER_NAME, FILE_NAME));
            if (!File.Exists(path))
            {
                string[] contents = new string[3]
                {
                    ColorTranslator.ToHtml(lbNum.BackColor),
                    ColorTranslator.ToHtml(lbCaps.BackColor),
                    ColorTranslator.ToHtml(lbScroll.BackColor)
                };
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllLines(path, contents);
            }
            string[] array = File.ReadAllLines(path);
            if (array.Length == 6)
            {
                Color backColor1 = ColorTranslator.FromHtml(array[0]);
                Color backColor2 = ColorTranslator.FromHtml(array[1]);
                Color backColor3 = ColorTranslator.FromHtml(array[2]);

                lbNum.BackColor = backColor1;
                isNum = lbNum.Visible = bool.Parse(array[3]);
                lbCaps.BackColor = backColor2;
                isCaps = lbCaps.Visible = bool.Parse(array[4]);
                lbScroll.BackColor = backColor3;
                isScroll = lbScroll.Visible = bool.Parse(array[5]);
            }
            lbNum.Visible = IsKeyLocked(Keys.NumLock) && isNum;
            lbCaps.Visible = IsKeyLocked(Keys.Capital) && isCaps;
            lbScroll.Visible = IsKeyLocked(Keys.Scroll) && isScroll;
        }


        private void MyDeskBand_SizeChanged(object sender, EventArgs e)
        {
            if (this.Size != size)
                this.Size = size;
        }

        private void showNumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showNumToolStripMenuItem.Checked = !showNumToolStripMenuItem.Checked;
            isNum = lbNum.Visible = showNumToolStripMenuItem.Checked;
            if (!Control.IsKeyLocked(Keys.NumLock) && isNum)
            {
                lbNum.Visible = true;
            }
            SaveSettings();
        }

        private void showCapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showCapsToolStripMenuItem.Checked = !showCapsToolStripMenuItem.Checked;
            isCaps = lbCaps.Visible = showCapsToolStripMenuItem.Checked;
            if (!Control.IsKeyLocked(Keys.CapsLock) && isCaps)
            {
                lbCaps.Visible = true;
            }
            SaveSettings();
        }

        private void showScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showScrollToolStripMenuItem.Checked = !showScrollToolStripMenuItem.Checked;
            isScroll = lbScroll.Visible = showScrollToolStripMenuItem.Checked;
            if (!Control.IsKeyLocked(Keys.Scroll) && isScroll)
            {
                lbScroll.Visible = true;
            }
            SaveSettings();
        }
        private void SaveSettings()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine(FOLDER_NAME, FILE_NAME));
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
