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

namespace KMDIWinDoorsCS
{
    public partial class frmMain : Form
    {
        int fwidth = 400, fheight = 400, ftype = 53;
        string wdrType = "Fixed";
        Pen blkPen = new Pen(Color.Black);

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            numWidth.Maximum = decimal.MaxValue;
            numHeight.Maximum = decimal.MaxValue;
        }

        private void rdType_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rdWindow)
            {
                ftype = 53;
            }
            else if (sender == rdDoor)
            {
                ftype = 67;
            }
            RadioButton rd = (RadioButton)sender;
            lblType.Text = rd.Text + " Type";
            pnlEditor.Invalidate();
        }

        private void cbxWindowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            wdrType = cbxWindowType.Text;
            pnlEditor.Invalidate();
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            if (sender == numWidth)
            {
                fwidth = decimal.ToInt32(num.Value);
            }
            else if (sender == numHeight)
            {
                fheight = decimal.ToInt32(num.Value);
            }
            pnlEditor.Invalidate();
        }

        private void pnlEditor_Paint(object sender, PaintEventArgs e)
        {
            int innrfW = fwidth - ftype,
                innrfH = fheight - ftype;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Point fcntr = new Point((pnlEditor.Width - fwidth)/2, (pnlEditor.Height - fheight) / 2);
            Point innrfCntr = new Point((fwidth - innrfW)/2 + fcntr.X, (fheight - innrfH) / 2 + fcntr.Y);

            Rectangle[] frames = new[]
            {
                new Rectangle(fcntr,new Size(fwidth,fheight)),
                new Rectangle(innrfCntr,new Size(innrfW,innrfH))
            };

            Point[] corner_points = new[]
            {
                new Point(fcntr.X,fcntr.Y),
                new Point(innrfCntr.X,innrfCntr.Y),
                new Point(fcntr.X +fwidth,fcntr.Y),
                new Point(innrfCntr.X +innrfW,innrfCntr.Y),
                new Point(fcntr.X,fcntr.Y + fheight),
                new Point(innrfCntr.X,innrfCntr.Y + innrfH),
                new Point(fcntr.X + fwidth,fcntr.Y + fheight),
                new Point(innrfCntr.X + innrfW,innrfCntr.Y + innrfH)
            };

            for (int i = 0; i < corner_points.Length - 1; i+=2)
            {
                e.Graphics.DrawLine(blkPen, corner_points[i], corner_points[i+1]);
            }

                {
                    var a = e.Graphics;
                    a.FillRectangle(new SolidBrush(Color.Gray), frames[1]);
                    a.DrawRectangles(blkPen, frames);
                }
            //e.Graphics.FillRectangle(new SolidBrush(Color.Gray), frames[1]);
            //e.Graphics.DrawRectangles(blkPen, frames);

            if (wdrType == "Fixed")
            {
                Font drawFont = new Font("Segoe UI", 12);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), frames[1], drawFormat);
            }
            else if (wdrType == "Casement")
            {
                Pen dgrayPen = new Pen(Color.DimGray);
                {
                    var dgPen = dgrayPen;
                    dgPen.DashStyle = DashStyle.Dash;
                    dgPen.Width = 3;
                }
                e.Graphics.DrawLine(dgrayPen, new Point(innrfCntr.X + innrfW, innrfCntr.Y), new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))));
                e.Graphics.DrawLine(dgrayPen, new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))), new Point(innrfCntr.X + innrfW, innrfH + innrfCntr.Y));
            }
        }
    }
}
