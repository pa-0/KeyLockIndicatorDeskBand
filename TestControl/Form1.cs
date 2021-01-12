using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomDialog;

namespace TestControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            customColorDialog1.Color = BackColor;
        }

        private void customColorDialog1_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            BackColor = e.CurrentColor;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            customColorDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customColorDialog1 = new CustomColorDialog();
            Color oldColor = customColorDialog1.Color = BackColor;
            customColorDialog1.ColorChanged += (o, ev) =>
            {
                BackColor = ev.CurrentColor;
            };
            if (customColorDialog1.ShowDialog() != DialogResult.OK) 
            {
                BackColor = oldColor;
            };
        }
    }
}
