using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KeyLockIndicatorDeskBand
{
	public class frmSetting : Form
	{
		private Label lbNum;

		private Label lbCaps;

		private Label lbScroll;

		private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);

		private IContainer components;

		private Button btScroll;

		private Button btNum;

		private Button btCaps;

		private Button button1;

		private CheckBox cbNum;

		private CheckBox cbScroll;

		private CheckBox cbCaps;

		public frmSetting(Label lbNum, Label lbCaps, Label lbScroll)
		{
			InitializeComponent();
			this.lbCaps = lbCaps;
			btCaps.BackColor = lbCaps.ForeColor;
			cbCaps.Checked = (btCaps.Visible = lbCaps.Visible);
			this.lbNum = lbNum;
			btNum.BackColor = lbNum.ForeColor;
			cbNum.Checked = (btNum.Visible = lbNum.Visible);
			this.lbScroll = lbScroll;
			btScroll.BackColor = lbScroll.ForeColor;
			cbScroll.Checked = (btScroll.Visible = lbScroll.Visible);
		}

		private void frmSetting_Load(object sender, EventArgs e)
		{
			
		}

		private void btNum_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				btNum.BackColor = colorDialog.Color;
				lbNum.ForeColor = colorDialog.Color;
			}
		}

		private void btCaps_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				btCaps.BackColor = colorDialog.Color;
				lbCaps.ForeColor = colorDialog.Color;
			}
		}

		private void btScroll_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				btScroll.BackColor = colorDialog.Color;
				lbScroll.ForeColor = colorDialog.Color;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine("KeyLockIndicatorDeskBand", "settings.setting"));
			string[] contents = new string[6]
			{
				ColorTranslator.ToHtml(btNum.BackColor),
				ColorTranslator.ToHtml(btCaps.BackColor),
				ColorTranslator.ToHtml(btScroll.BackColor),
				cbNum.Checked.ToString(),
				cbCaps.Checked.ToString(),
				cbScroll.Checked.ToString()
			};
			Directory.CreateDirectory(Path.GetDirectoryName(path));
			File.WriteAllLines(path, contents);
			
			Close();
		}

		private void cbNum_CheckedChanged(object sender, EventArgs e)
		{
			Label label = lbNum;
			bool visible = (btNum.Visible = cbNum.Checked);
			label.Visible = visible;
		}

		private void cbCaps_CheckedChanged(object sender, EventArgs e)
		{
			Label label = lbCaps;
			bool visible = (btCaps.Visible = cbCaps.Checked);
			label.Visible = visible;
		}

		private void cbScroll_CheckedChanged(object sender, EventArgs e)
		{
			Label label = lbScroll;
			bool visible = (btScroll.Visible = cbScroll.Checked);
			label.Visible = visible;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.btScroll = new System.Windows.Forms.Button();
            this.btNum = new System.Windows.Forms.Button();
            this.btCaps = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbNum = new System.Windows.Forms.CheckBox();
            this.cbScroll = new System.Windows.Forms.CheckBox();
            this.cbCaps = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btScroll
            // 
            this.btScroll.Location = new System.Drawing.Point(12, 93);
            this.btScroll.Name = "btScroll";
            this.btScroll.Size = new System.Drawing.Size(96, 23);
            this.btScroll.TabIndex = 1;
            this.btScroll.Text = "Scroll lock Color";
            this.btScroll.UseVisualStyleBackColor = true;
            this.btScroll.Click += new System.EventHandler(this.btScroll_Click);
            // 
            // btNum
            // 
            this.btNum.Location = new System.Drawing.Point(13, 34);
            this.btNum.Name = "btNum";
            this.btNum.Size = new System.Drawing.Size(96, 23);
            this.btNum.TabIndex = 1;
            this.btNum.Text = "Num lock Color";
            this.btNum.UseVisualStyleBackColor = true;
            this.btNum.Click += new System.EventHandler(this.btNum_Click);
            // 
            // btCaps
            // 
            this.btCaps.Location = new System.Drawing.Point(12, 64);
            this.btCaps.Name = "btCaps";
            this.btCaps.Size = new System.Drawing.Size(96, 23);
            this.btCaps.TabIndex = 1;
            this.btCaps.Text = "Caps lock Color";
            this.btCaps.UseVisualStyleBackColor = true;
            this.btCaps.Click += new System.EventHandler(this.btCaps_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbNum
            // 
            this.cbNum.AutoSize = true;
            this.cbNum.Checked = true;
            this.cbNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNum.Location = new System.Drawing.Point(111, 38);
            this.cbNum.Name = "cbNum";
            this.cbNum.Size = new System.Drawing.Size(101, 17);
            this.cbNum.TabIndex = 3;
            this.cbNum.Text = "Show Num lock";
            this.cbNum.UseVisualStyleBackColor = true;
            this.cbNum.CheckedChanged += new System.EventHandler(this.cbNum_CheckedChanged);
            // 
            // cbScroll
            // 
            this.cbScroll.AutoSize = true;
            this.cbScroll.Checked = true;
            this.cbScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbScroll.Location = new System.Drawing.Point(111, 97);
            this.cbScroll.Name = "cbScroll";
            this.cbScroll.Size = new System.Drawing.Size(105, 17);
            this.cbScroll.TabIndex = 4;
            this.cbScroll.Text = "Show Scroll lock";
            this.cbScroll.UseVisualStyleBackColor = true;
            this.cbScroll.CheckedChanged += new System.EventHandler(this.cbScroll_CheckedChanged);
            // 
            // cbCaps
            // 
            this.cbCaps.AutoSize = true;
            this.cbCaps.Checked = true;
            this.cbCaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCaps.Location = new System.Drawing.Point(111, 68);
            this.cbCaps.Name = "cbCaps";
            this.cbCaps.Size = new System.Drawing.Size(103, 17);
            this.cbCaps.TabIndex = 5;
            this.cbCaps.Text = "Show Caps lock";
            this.cbCaps.UseVisualStyleBackColor = true;
            this.cbCaps.CheckedChanged += new System.EventHandler(this.cbCaps_CheckedChanged);
            // 
            // frmSetting
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 118);
            this.Controls.Add(this.cbCaps);
            this.Controls.Add(this.cbScroll);
            this.Controls.Add(this.cbNum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btCaps);
            this.Controls.Add(this.btNum);
            this.Controls.Add(this.btScroll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSetting";
            this.ShowInTaskbar = false;
            this.Text = "Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetting_FormClosing);
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.Combine("KeyLockIndicatorDeskBand", "settings.setting"));
			string[] contents = new string[6]
			{
				ColorTranslator.ToHtml(btNum.BackColor),
				ColorTranslator.ToHtml(btCaps.BackColor),
				ColorTranslator.ToHtml(btScroll.BackColor),
				cbNum.Checked.ToString(),
				cbCaps.Checked.ToString(),
				cbScroll.Checked.ToString()
			};
			Directory.CreateDirectory(Path.GetDirectoryName(path));
			File.WriteAllLines(path, contents);
		}
    }
}
