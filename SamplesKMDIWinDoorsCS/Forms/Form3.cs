using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplesKMDIWinDoorsCS.Forms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Graphics g = e.Graphics;

            int cond = pnl.Width + pnl.Height;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //if (pnl.Width > pnl.Height)
            //{
            //    cond = pnl.Width;
            //}
            //else if (pnl.Height > pnl.Width)
            //{
            //    cond = pnl.Height;
            //}
            //if (pnl.Width == pnl.Height)
            //{
            //    cond = pnl.Width;
            //}

            for (int i = 10; i < cond; i+=10)
            {
                g.DrawLine(Pens.Black, new Point(0, i), new Point(i, 0));
            }
            //for (int i = ht; i < 0; i += 10)
            //{
            //    g.DrawLine(Pens.Black, new Point(0, i), new Point(i, 0));
            //}
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}
