using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (comboBox1.Text == "Concrete")
            {
                pnl.BackColor = SystemColors.Control;
                int cond = pnl.Width + pnl.Height;

                for (int i = 10; i < cond; i += 10)
                {
                    g.DrawLine(Pens.Black, new Point(0, i), new Point(i, 0));
                }
            }
            else if (comboBox1.Text == "Region")
            {
                GraphicsPath mypath = new GraphicsPath();
                Rectangle ell = new Rectangle(20,20,100,100);
                mypath.AddEllipse(ell);

                SolidBrush myb = new SolidBrush(Color.Blue);
                e.Graphics.FillPath(myb, mypath);

                Region myreg = new Region(new Rectangle(20,20,50,100));
                RectangleF bounds = myreg.GetBounds(e.Graphics);
                e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(bounds));
            }
            else if (comboBox1.Text == "Louver")
            {
                pnl.BackColor = Color.Black;
                int fpnl_sashW = pnl.Width - 20,
                    fpnl_sashH = pnl.Height - 20;

                Point sashPoint = new Point(pnl.ClientRectangle.X + 8, pnl.ClientRectangle.Y + 8);
                Rectangle sashRect = new Rectangle(sashPoint,
                                     new Size(fpnl_sashW, fpnl_sashH));
                g.DrawRectangle(Pens.Black, sashRect);
                g.FillRectangle(new SolidBrush(Color.DarkGray), sashRect);

                Rectangle gallery1 = new Rectangle(sashPoint,
                                     new Size(10, fpnl_sashH));
                Pen blkpen = new Pen(Color.Black, 2);
                g.DrawRectangle(blkpen, gallery1);


                Rectangle gallery2 = new Rectangle(new Point(sashPoint.X + (fpnl_sashW - 10),sashPoint.Y),
                                     new Size(10, fpnl_sashH));
                g.DrawRectangle(blkpen, gallery2);

                int bladesheight = fpnl_sashH / 6;
                //Point[] blades = new Point[6*2];
                //int bladecnt = 0;
                //int bladecnt = blades.Count() / 2;

                for (int i = 0; i < 6; i++)
                {
                    //bladecnt++;
                    //Point pnt1 = new Point(sashPoint.X + 10, bladesheight * i);
                    //Point pnt2 = new Point(sashPoint.X + (fpnl_sashW - 10), bladesheight * i);
                    //g.DrawLine(blkpen,pnt1,pnt2);

                    Rectangle blades = new Rectangle(new Point(sashPoint.X + 10, sashPoint.Y + (bladesheight * i)), new Size(fpnl_sashW - 20, bladesheight * i));
                    g.DrawRectangle(blkpen,blades);
                }

            }
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}
