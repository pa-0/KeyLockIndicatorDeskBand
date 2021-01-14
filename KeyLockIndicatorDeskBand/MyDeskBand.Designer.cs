namespace KeyLockIndicatorDeskBand
{
    partial class MyDeskBand
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbNum = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showNumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showScrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbCaps = new System.Windows.Forms.Label();
            this.lbScroll = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNum
            // 
            this.lbNum.BackColor = System.Drawing.Color.Blue;
            this.lbNum.ContextMenuStrip = this.contextMenuStrip1;
            this.lbNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNum.ForeColor = System.Drawing.Color.White;
            this.lbNum.Location = new System.Drawing.Point(3, 6);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(23, 23);
            this.lbNum.TabIndex = 0;
            this.lbNum.Text = "N";
            this.lbNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lbNum, "Num Lock");
            this.lbNum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbNum_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showNumToolStripMenuItem,
            this.showCapsToolStripMenuItem,
            this.showScrollToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // showNumToolStripMenuItem
            // 
            this.showNumToolStripMenuItem.Checked = true;
            this.showNumToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showNumToolStripMenuItem.Name = "showNumToolStripMenuItem";
            this.showNumToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showNumToolStripMenuItem.Text = "Show NumLock";
            this.showNumToolStripMenuItem.Click += new System.EventHandler(this.showNumToolStripMenuItem_Click);
            // 
            // showCapsToolStripMenuItem
            // 
            this.showCapsToolStripMenuItem.Checked = true;
            this.showCapsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCapsToolStripMenuItem.Name = "showCapsToolStripMenuItem";
            this.showCapsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showCapsToolStripMenuItem.Text = "Show CapsLock";
            this.showCapsToolStripMenuItem.Click += new System.EventHandler(this.showCapsToolStripMenuItem_Click);
            // 
            // showScrollToolStripMenuItem
            // 
            this.showScrollToolStripMenuItem.Checked = true;
            this.showScrollToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showScrollToolStripMenuItem.Name = "showScrollToolStripMenuItem";
            this.showScrollToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showScrollToolStripMenuItem.Text = "Show ScrollLock";
            this.showScrollToolStripMenuItem.Click += new System.EventHandler(this.showScrollToolStripMenuItem_Click);
            // 
            // lbCaps
            // 
            this.lbCaps.BackColor = System.Drawing.Color.Red;
            this.lbCaps.ContextMenuStrip = this.contextMenuStrip1;
            this.lbCaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbCaps.ForeColor = System.Drawing.Color.White;
            this.lbCaps.Location = new System.Drawing.Point(32, 6);
            this.lbCaps.Name = "lbCaps";
            this.lbCaps.Size = new System.Drawing.Size(23, 23);
            this.lbCaps.TabIndex = 1;
            this.lbCaps.Text = "C";
            this.lbCaps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lbCaps, "Caps Lock");
            this.lbCaps.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbCaps_MouseClick);
            // 
            // lbScroll
            // 
            this.lbScroll.BackColor = System.Drawing.Color.Lime;
            this.lbScroll.ContextMenuStrip = this.contextMenuStrip1;
            this.lbScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbScroll.ForeColor = System.Drawing.Color.White;
            this.lbScroll.Location = new System.Drawing.Point(61, 6);
            this.lbScroll.Name = "lbScroll";
            this.lbScroll.Size = new System.Drawing.Size(23, 23);
            this.lbScroll.TabIndex = 1;
            this.lbScroll.Text = "S";
            this.lbScroll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lbScroll, "Srcoll Lock");
            this.lbScroll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbScroll_MouseClick);
            // 
            // MyDeskBand
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lbScroll);
            this.Controls.Add(this.lbCaps);
            this.Controls.Add(this.lbNum);
            this.Name = "MyDeskBand";
            this.Size = new System.Drawing.Size(88, 35);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.SizeChanged += new System.EventHandler(this.MyDeskBand_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbCaps;
        private System.Windows.Forms.Label lbScroll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showNumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showScrollToolStripMenuItem;
    }
}
