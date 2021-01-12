namespace KeyLockIndicatorDeskBand
{
    partial class UserControl1
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
            this.lbCaps = new System.Windows.Forms.Label();
            this.lbScroll = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lbNum
            // 
            this.lbNum.BackColor = System.Drawing.Color.Blue;
            this.lbNum.Location = new System.Drawing.Point(3, 0);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(100, 23);
            this.lbNum.TabIndex = 0;
            this.lbNum.Text = "label1";
            this.toolTip1.SetToolTip(this.lbNum, "Num Lock");
            this.lbNum.Click += new System.EventHandler(this.lbNum_Click);
            // 
            // lbCaps
            // 
            this.lbCaps.BackColor = System.Drawing.Color.Red;
            this.lbCaps.Location = new System.Drawing.Point(109, 0);
            this.lbCaps.Name = "lbCaps";
            this.lbCaps.Size = new System.Drawing.Size(100, 23);
            this.lbCaps.TabIndex = 1;
            this.lbCaps.Text = "label2";
            this.toolTip1.SetToolTip(this.lbCaps, "Caps Lock");
            this.lbCaps.Click += new System.EventHandler(this.lbCaps_Click);
            // 
            // lbScroll
            // 
            this.lbScroll.BackColor = System.Drawing.Color.Lime;
            this.lbScroll.Location = new System.Drawing.Point(215, 0);
            this.lbScroll.Name = "lbScroll";
            this.lbScroll.Size = new System.Drawing.Size(100, 23);
            this.lbScroll.TabIndex = 1;
            this.lbScroll.Text = "label3";
            this.toolTip1.SetToolTip(this.lbScroll, "Srcoll Lock");
            this.lbScroll.Click += new System.EventHandler(this.lbScroll_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbScroll);
            this.Controls.Add(this.lbCaps);
            this.Controls.Add(this.lbNum);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(318, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbCaps;
        private System.Windows.Forms.Label lbScroll;
    }
}
