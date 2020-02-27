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
        //string wdrType = "Fixed";
        Pen blkPen = new Pen(Color.Black);
        Graphics g;
        public void CreatePanels(string wdrtype)
        {
            g = Graphics.FromHwnd(pbxEditor.Handle);
            int innrfW = fwidth - ftype,
                innrfH = fheight - ftype;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Point fcntr = new Point(0, 0);
            Point innrfCntr = new Point((fwidth - innrfW) / 2 + fcntr.X, (fheight - innrfH) / 2 + fcntr.Y);

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

            for (int i = 0; i < corner_points.Length - 1; i += 2)
            {
                g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
            }

            {
                var a = g;
                a.FillRectangle(new SolidBrush(Color.Gray), frames[1]);
                a.DrawRectangles(blkPen, frames);
            }
            g.FillRectangle(new SolidBrush(Color.Gray), frames[1]);
            g.DrawRectangles(blkPen, frames);

            if (wdrtype == "Fixed")
            {
                Font drawFont = new Font("Segoe UI", 12);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), frames[1], drawFormat);
            }
            else if (wdrtype == "Casement")
            {
                Pen dgrayPen = new Pen(Color.DimGray);
                {
                    var dgPen = dgrayPen;
                    dgPen.DashStyle = DashStyle.Dash;
                    dgPen.Width = 3;
                }
                g.DrawLine(dgrayPen, new Point(innrfCntr.X + innrfW, innrfCntr.Y), new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))));
                g.DrawLine(dgrayPen, new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))), new Point(innrfCntr.X + innrfW, innrfH + innrfCntr.Y));
            }

            int w = 2;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   fwidth - w,
                                                                   fheight - w));
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            numWidth.Maximum = decimal.MaxValue;
            numHeight.Maximum = decimal.MaxValue;
            pbxEditor.Width = fwidth;
            pbxEditor.Height = fheight;
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
            //pbxEditor.Invalidate();
            CreatePanels("Fixed");
        }

        private void cbxWindowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //wdrType = cbxWindowType.Text;
            //pbxEditor.Invalidate();
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
            pbxEditor.Width = fwidth;
            pbxEditor.Height = fheight;
            //pbxEditor.Invalidate();
            CreatePanels("Fixed");
        }
        float zoom = 1f;

        private void pnlMain_SizeChanged(object sender, EventArgs e)
        {
            int cX, cY;
            cX = (pnlMain.Width - fwidth) / 2;
            cY = (pnlMain.Height - fheight) / 2;
            if (cX <= 0 || cY <= 0)
            {
                pbxEditor.Location = new Point(100, 100);
            }
            else
            {
                pbxEditor.Location = new Point(cX, cY);
            }
            CreatePanels("Fixed");
        }

        private void pbxEditor_SizeChanged(object sender, EventArgs e)
        {
            int cX, cY;
            cX = (pnlMain.Width - fwidth) / 2;
            cY = (pnlMain.Height - fheight) / 2;
            if (cX <= 0 || cY <= 0)
            {
                pbxEditor.Location = new Point(100, 100);
            }
            else
            {
                pbxEditor.Location = new Point(cX, cY);
            }
            CreatePanels("Fixed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap(pbxEditor.Width, pbxEditor.Height);
            //pbxEditor.DrawToBitmap(bmp, new Rectangle(0, 0, pbxEditor.Width, pbxEditor.Height));
            //bmp.Save("Test1.png", System.Drawing.Imaging.ImageFormat.Png);
            //bmp = new Bitmap(pbxEditor.Width, pbxEditor.Height);
            //pbxEditor.Invalidate();
            //pbxEditor.ImageLocation = "Test1.png";
        }

        private void c70ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePanels("Fixed");
        }

        private void trkbrZoom_ValueChanged(object sender, EventArgs e)
        {
            //zoom = trkbrZoom.Value / 100f;
            //lblZoom.Text = trkbrZoom.Value.ToString() + "%";
            //float new_fwidth, new_fheight;
            //new_fwidth = fwidth * zoom;
            //new_fheight = fheight * zoom;

            ////fwidth = Convert.ToInt32(fwidth * zoom);
            ////fheight = Convert.ToInt32(fheight * zoom);

            //pbxEditor.Size = new Size(Convert.ToInt32(new_fwidth), Convert.ToInt32(new_fheight));
            //pbxEditor.Invalidate();
        }

        private void pbxEditor_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //g.ScaleTransform(zoom, zoom);

            ////pbxEditor.Width = fwidth;
            ////pbxEditor.Height = fheight;

            //int innrfW = fwidth - ftype,
            //    innrfH = fheight - ftype;

            //g.SmoothingMode = SmoothingMode.AntiAlias;
            ////Point fcntr = new Point((pnlMain.Width - fwidth) / 2, (pnlMain.Height - fheight) / 2);
            //Point fcntr = new Point(0, 0);
            //Point innrfCntr = new Point((fwidth - innrfW) / 2 + fcntr.X, (fheight - innrfH) / 2 + fcntr.Y);

            //Rectangle[] frames = new[]
            //{
            //    new Rectangle(fcntr,new Size(fwidth,fheight)),
            //    new Rectangle(innrfCntr,new Size(innrfW,innrfH))
            //};

            //Point[] corner_points = new[]
            //{
            //    new Point(fcntr.X,fcntr.Y),
            //    new Point(innrfCntr.X,innrfCntr.Y),
            //    new Point(fcntr.X +fwidth,fcntr.Y),
            //    new Point(innrfCntr.X +innrfW,innrfCntr.Y),
            //    new Point(fcntr.X,fcntr.Y + fheight),
            //    new Point(innrfCntr.X,innrfCntr.Y + innrfH),
            //    new Point(fcntr.X + fwidth,fcntr.Y + fheight),
            //    new Point(innrfCntr.X + innrfW,innrfCntr.Y + innrfH)
            //};

            //for (int i = 0; i < corner_points.Length - 1; i += 2)
            //{
            //    g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
            //}

            //{
            //    var a = g;
            //    a.FillRectangle(new SolidBrush(Color.Gray), frames[1]);
            //    a.DrawRectangles(blkPen, frames);
            //}
            //g.FillRectangle(new SolidBrush(Color.Gray), frames[1]);
            //g.DrawRectangles(blkPen, frames);

            //if (wdrType == "Fixed")
            //{
            //    Font drawFont = new Font("Segoe UI", 12);
            //    StringFormat drawFormat = new StringFormat();
            //    drawFormat.Alignment = StringAlignment.Center;
            //    drawFormat.LineAlignment = StringAlignment.Center;
            //    g.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), frames[1], drawFormat);
            //}
            //else if (wdrType == "Casement")
            //{
            //    Pen dgrayPen = new Pen(Color.DimGray);
            //    {
            //        var dgPen = dgrayPen;
            //        dgPen.DashStyle = DashStyle.Dash;
            //        dgPen.Width = 3;
            //    }
            //    g.DrawLine(dgrayPen, new Point(innrfCntr.X + innrfW, innrfCntr.Y), new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))));
            //    g.DrawLine(dgrayPen, new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))), new Point(innrfCntr.X + innrfW, innrfH + innrfCntr.Y));
            //}

            //int w = 2;
            //int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            //g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
            //                                                       0,
            //                                                       fwidth - w,
            //                                                       fheight - w));

        }

        /*private void pnlEditor_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(zoom, zoom);

            int innrfW = fwidth - ftype,
                innrfH = fheight - ftype;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Point fcntr = new Point((pnlMain.Width - fwidth) / 2, (pnlMain.Height - fheight) / 2);
            Point innrfCntr = new Point((fwidth - innrfW) / 2 + fcntr.X, (fheight - innrfH) / 2 + fcntr.Y);

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

            for (int i = 0; i < corner_points.Length - 1; i += 2)
            {
                g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
            }

            {
                var a = g;
                a.FillRectangle(new SolidBrush(Color.Gray), frames[1]);
                a.DrawRectangles(blkPen, frames);
            }
            g.FillRectangle(new SolidBrush(Color.Gray), frames[1]);
            g.DrawRectangles(blkPen, frames);

            if (wdrType == "Fixed")
            {
                Font drawFont = new Font("Segoe UI", 12);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), frames[1], drawFormat);
            }
            else if (wdrType == "Casement")
            {
                Pen dgrayPen = new Pen(Color.DimGray);
                {
                    var dgPen = dgrayPen;
                    dgPen.DashStyle = DashStyle.Dash;
                    dgPen.Width = 3;
                }
                g.DrawLine(dgrayPen, new Point(innrfCntr.X + innrfW, innrfCntr.Y), new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))));
                g.DrawLine(dgrayPen, new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))), new Point(innrfCntr.X + innrfW, innrfH + innrfCntr.Y));
            }
       }*/
    }
}
