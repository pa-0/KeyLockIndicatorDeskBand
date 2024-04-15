using CustomDialog;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KeyLockIndicatorDeskBand
{
    public partial class MyDeskBand : UserControl
    {
        private const string FOLDER_NAME = "KeyLockIndicator";
        private const string FILE_NAME = "settings.setting";
        //UserActivityHook userActivityHook = new UserActivityHook();
        bool isNum, isCaps, isScroll;
        Size size = new Size();
        Color lbNumBackColor, lbCapsBackColor, lbScrollBackColor;
        public MyDeskBand()
        {
            InitializeComponent();
            //userActivityHook.KeyDown += new KeyEventHandler(userActivityHook_KeyDown);
            isNum = isCaps = isScroll = true;
            size = this.Size;
        }

        //private void userActivityHook_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.NumLock)
        //    {
        //        if (!Control.IsKeyLocked(Keys.NumLock) && isNum)
        //        {
        //            lbNum.Visible = true;
        //        }
        //        else
        //        {
        //            lbNum.Visible = false;
        //        }
        //    }
        //    if (e.KeyCode == Keys.CapsLock)
        //    {
        //        if (!Control.IsKeyLocked(Keys.CapsLock) && isCaps)
        //        {
        //            lbCaps.Visible = true;
        //        }
        //        else
        //        {
        //            lbCaps.Visible = false;
        //        }
        //    }
        //    if (e.KeyCode == Keys.Scroll)
        //    {
        //        if (!Control.IsKeyLocked(Keys.Scroll) && isScroll)
        //        {
        //            lbScroll.Visible = true;
        //        }
        //        else
        //        {
        //            lbScroll.Visible = false;
        //        }
        //    }
        //}
        private void lbNum_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                CustomColorDialog customColorDialog1 = new CustomColorDialog();
                Color oldColor = customColorDialog1.Color = lbNum.BackColor;
                customColorDialog1.ColorChanged += (o, ev) =>
                {
                    lbNumBackColor = lbNum.BackColor = ev.CurrentColor;
                };
                if (customColorDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveSettings();
                }
                else
                {
                    lbNum.BackColor = oldColor;
                }
                lbNumBackColor = lbNum.BackColor;
                timer1.Start();
            }
        }

        private void lbCaps_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                CustomColorDialog customColorDialog1 = new CustomColorDialog();
                Color oldColor = customColorDialog1.Color = lbCaps.BackColor;
                customColorDialog1.ColorChanged += (o, ev) =>
                {
                    lbCapsBackColor = lbCaps.BackColor = ev.CurrentColor;
                };
                if (customColorDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveSettings();
                }
                else
                {
                    lbCaps.BackColor = oldColor;
                }
                lbCapsBackColor = lbCaps.BackColor;
                timer1.Start();
            }
        }

        private void lbScroll_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                CustomColorDialog customColorDialog1 = new CustomColorDialog();
                Color oldColor = customColorDialog1.Color = lbScroll.BackColor;
                customColorDialog1.ColorChanged += (o, ev) =>
                {
                    lbScrollBackColor = lbScroll.BackColor = ev.CurrentColor;
                };
                if (customColorDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveSettings();
                }
                else
                {
                    lbScroll.BackColor = oldColor;
                }
                lbScrollBackColor = lbScroll.BackColor;
                timer1.Start();
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine(FOLDER_NAME, FILE_NAME));
            if (!File.Exists(path))
            {
                string[] contents = new string[]
                {
                    ColorTranslator.ToHtml(lbNumBackColor = lbNum.BackColor),
                    ColorTranslator.ToHtml(lbCapsBackColor = lbCaps.BackColor),
                    ColorTranslator.ToHtml(lbScrollBackColor = lbScroll.BackColor),
                    ColorTranslator.ToHtml(label1.BackColor),
                    lbNum.Visible.ToString(),
                    lbCaps.Visible.ToString(),
                    lbScroll.Visible.ToString(),
                };
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllLines(path, contents);
            }
            string[] array = File.ReadAllLines(path);
            if (array.Length == 7)
            {
                Color backColor1 = ColorTranslator.FromHtml(array[0]);
                Color backColor2 = ColorTranslator.FromHtml(array[1]);
                Color backColor3 = ColorTranslator.FromHtml(array[2]);
                Color backColor4 = ColorTranslator.FromHtml(array[3]);
                label1.BackColor = backColor4;
                lbNumBackColor = lbNum.BackColor = backColor1;
                isNum = lbNum.Visible = bool.Parse(array[4]);
                lbCapsBackColor = lbCaps.BackColor = backColor2;
                isCaps = lbCaps.Visible = bool.Parse(array[5]);
                lbScrollBackColor = lbScroll.BackColor = backColor3;
                isScroll = lbScroll.Visible = bool.Parse(array[6]);
            }
            lbNum.Visible = IsKeyLocked(Keys.NumLock) && isNum;
            lbCaps.Visible = IsKeyLocked(Keys.CapsLock) && isCaps;
            lbScroll.Visible = IsKeyLocked(Keys.Scroll) && isScroll;
            timer1.Start();
        }


        private void MyDeskBand_SizeChanged(object sender, EventArgs e)
        {
            if (this.Size != size)
                this.Size = size;
        }

        private void showNumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showNumToolStripMenuItem.Checked = !showNumToolStripMenuItem.Checked;
            isNum = showNumToolStripMenuItem.Checked;
            if (Control.IsKeyLocked(Keys.NumLock) && isNum)
            {
                lbNum.Visible = true;
            }
            else
            {
                lbNum.Visible = false;
            }
            SaveSettings();
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                CustomColorDialog customColorDialog1 = new CustomColorDialog();
                Color oldColor = customColorDialog1.Color = label1.BackColor;
                customColorDialog1.ColorChanged += (o, ev) =>
                {
                    label1.BackColor = ev.CurrentColor;
                    if (isScroll)
                        lbScroll.BackColor = Control.IsKeyLocked(Keys.Scroll) ? lbScrollBackColor : label1.BackColor;
                    if (isCaps)
                        lbCaps.BackColor = Control.IsKeyLocked(Keys.CapsLock) ? lbCapsBackColor : label1.BackColor;
                    if (isNum)
                        lbNum.BackColor = Control.IsKeyLocked(Keys.NumLock) ? lbNumBackColor : label1.BackColor;
                };
                if (customColorDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveSettings();
                }
                else
                {
                    label1.BackColor = oldColor;
                }
                //lbScrollBackColor = label1.BackColor;
                timer1.Start();
            }
        }

        private void showCapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showCapsToolStripMenuItem.Checked = !showCapsToolStripMenuItem.Checked;
            isCaps = showCapsToolStripMenuItem.Checked;
            if (Control.IsKeyLocked(Keys.CapsLock) && isCaps)
            {
                lbCaps.Visible = true;
            }
            else
            {
                lbCaps.Visible = false;
            }
            SaveSettings();
        }


        private void showScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showScrollToolStripMenuItem.Checked = !showScrollToolStripMenuItem.Checked;
            isScroll = showScrollToolStripMenuItem.Checked;
            if (Control.IsKeyLocked(Keys.Scroll) && isScroll)
            {
                lbScroll.Visible = true;
            }
            else
            {
                lbScroll.Visible = false;
            }
            SaveSettings();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbScroll.Visible = isScroll;
            lbCaps.Visible = isCaps;
            lbNum.Visible = isNum;
            if (isScroll)
                lbScroll.BackColor = Control.IsKeyLocked(Keys.Scroll) ? lbScrollBackColor : label1.BackColor;
            if (isCaps)
                lbCaps.BackColor = Control.IsKeyLocked(Keys.CapsLock) ? lbCapsBackColor : label1.BackColor;
            if (isNum)
                lbNum.BackColor = Control.IsKeyLocked(Keys.NumLock) ? lbNumBackColor : label1.BackColor;
        }

        private void SaveSettings()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine(FOLDER_NAME, FILE_NAME));
            string[] contents = new string[]
            {
                 ColorTranslator.ToHtml(lbNumBackColor),
                 ColorTranslator.ToHtml(lbCapsBackColor),
                 ColorTranslator.ToHtml(lbScrollBackColor),
                 ColorTranslator.ToHtml(label1.BackColor),
                 showNumToolStripMenuItem.Checked.ToString(),
                 showCapsToolStripMenuItem.Checked.ToString(),
                 showScrollToolStripMenuItem.Checked.ToString()
            };
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllLines(path, contents);
        }
    }
}
