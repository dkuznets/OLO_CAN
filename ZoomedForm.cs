using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OLO_CAN
{
    public partial class ZoomedForm : Form
    {
        public double m_sumX = 0, m_sumY = 0;
        public long m_sumCount = 0;
        public ZoomedForm()
        {
            InitializeComponent();
        }

        public void ClearView()
        {
            if (pictureBox1.Image != null)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    SolidBrush sbr = new SolidBrush(Color.Black);
                    g.FillRectangle(sbr, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height));
                }
                pictureBox1.Refresh();
            }
        }

        private void ZoomedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
