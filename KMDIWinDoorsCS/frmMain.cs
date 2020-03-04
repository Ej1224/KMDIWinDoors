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
        int fwidth = 0, fheight = 0, ftype = 0, borderStyle = 0;
        string wdrType,wdrOrient;
        Pen blkPen = new Pen(Color.Black);

        /*public void CreatePanels(string wdrtype)
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
        }*/

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
            pbxEditor.Invalidate();
            //CreatePanels("Fixed");
        }

        private void cbxWindowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            wdrType = cbxWindowType.Text;
            chkWdrOrientation.Checked = false;
            if (wdrType == "Casement" || wdrType == "Sliding")
            {
                chkWdrOrientation.Enabled = true;
                chkWdrOrientation.Text = "R";
            }
            else if (wdrType == "Awning")
            {
                chkWdrOrientation.Enabled = true;
                chkWdrOrientation.Text = "Norm";
            }
            else if (wdrType == "Fixed")
            {
                chkWdrOrientation.Enabled = false;
                chkWdrOrientation.Text = "";
            }
            wdrOrient = chkWdrOrientation.Text;
            pbxEditor.Invalidate();
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
            pbxEditor.Invalidate();
            //CreatePanels("Fixed");
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
            //CreatePanels("Fixed");
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
            //CreatePanels("Fixed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //foreach (Control item in pnlFields.Controls)
            //{
            //    MessageBox.Show(item.Name);
            //}
            foreach (var item in flowLayoutPanel1.Controls.OfType<Control>().OrderBy(ee => ee.Tag))
            {
                MessageBox.Show(item.Name);
            }

            //Bitmap bmp = new Bitmap(pbxEditor.Width, pbxEditor.Height);
            //pbxEditor.DrawToBitmap(bmp, new Rectangle(0, 0, pbxEditor.Width, pbxEditor.Height));
            //bmp.Save("Test1.png", System.Drawing.Imaging.ImageFormat.Png);
            //bmp = new Bitmap(pbxEditor.Width, pbxEditor.Height);
            //pbxEditor.Invalidate();
            //pbxEditor.ImageLocation = "Test1.png";
        }
        
        private void chkWdrOrientation_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            if (cbx.Checked == true)
            {
                if (cbx.Text == "R")
                {
                    cbx.Text = "L";
                }
                else if (cbx.Text == "Norm")
                {
                    cbx.Text = "Invrt";
                }
            }
            else if (cbx.Checked == false)
            {
                if (cbx.Text == "L")
                {
                    cbx.Text = "R";
                }
                else if (cbx.Text == "Inv")
                {
                    cbx.Text = "Norm";
                }
            }
            wdrOrient = cbx.Text;
            pbxEditor.Invalidate();
        }

        private void c70ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numWidth.Value = fwidth = 400;
            numHeight.Value = fheight = 400;
            ftype = 53;
            borderStyle = 2;
            pbxEditor.Size = new Size(fwidth,fheight);
            cbxWindowType.Text =  wdrType = "Fixed";
            pbxEditor.Invalidate();
            //CreatePanels("Fixed");
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
            Graphics g = e.Graphics;
            g.ScaleTransform(zoom, zoom);
            
            int innrfW = fwidth - ftype,
                innrfH = fheight - ftype;
            int sashW = innrfW - 20,
                sashH = innrfH - 20;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            //Point fcntr = new Point((pnlMain.Width - fwidth) / 2, (pnlMain.Height - fheight) / 2);
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

            if (wdrType == "Fixed")
            {
                Font drawFont = new Font("Segoe UI", 12);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), frames[1], drawFormat);
            }
            else
            {
                Point sashPoint = new Point(innrfCntr.X + 10, innrfCntr.Y + 10);
                Rectangle sashRect = new Rectangle(sashPoint,
                                                   new Size(sashW, sashH));
                Pen dgrayPen = new Pen(Color.DimGray);
                {
                    var dgPen = dgrayPen;
                    dgPen.DashStyle = DashStyle.Dash;
                    dgPen.Width = 3;
                }
                g.DrawRectangle(blkPen, sashRect);

                if (wdrType == "Casement")
                {
                    //g.DrawLine(dgrayPen, new Point(innrfCntr.X + innrfW, innrfCntr.Y),
                    //                     new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))));
                    //g.DrawLine(dgrayPen, new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))),
                    //                     new Point(innrfCntr.X + innrfW, innrfH + innrfCntr.Y));
                    if (wdrOrient == "R")
                    {
                        g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                             new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))));
                        g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))),
                                             new Point(sashPoint.X, sashH + sashPoint.Y));
                    }
                    else if (wdrOrient == "L")
                    {
                        g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, sashPoint.Y),
                                             new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))));
                        g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))),
                                             new Point(sashPoint.X + sashW, sashH + sashPoint.Y));
                    }
                }
                else if (wdrType == "Awning")
                {
                    if (wdrOrient == "Norm")
                    {
                        g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y + sashH),
                                             new Point(sashPoint.X + (sashW / 2), sashPoint.Y));
                        g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y),
                                             new Point(sashPoint.X + sashW, sashH + sashPoint.Y));
                    }
                    else if (wdrOrient == "Invrt")
                    {
                        g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                             new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH));
                        g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH),
                                             new Point(sashPoint.X + sashW, sashPoint.Y));
                    }
                }
                else if (wdrType == "Sliding")
                {
                    float arwStart_x1 = sashPoint.X + (sashW / 10),
                              center_y1 = sashPoint.Y + (sashH / 2),
                              arwEnd_x2 = ((sashPoint.X + sashW) - arwStart_x1) + (sashW / 10),
                              arwHeadUp_x3,
                              arwHeadUp_y3 = center_y1 - (center_y1 / 4),
                              arwHeadUp_x4,
                              arwHeadUp_y4 = center_y1 + (center_y1 / 4);

                    if (wdrOrient == "R")
                    {
                        arwHeadUp_x3 = (sashPoint.X + sashW) - arwStart_x1;
                        arwHeadUp_x4 = (sashPoint.X + sashW) - arwStart_x1;

                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                         new PointF(arwEnd_x2, center_y1));
                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                         new PointF(arwEnd_x2, center_y1));
                    }
                    else if (wdrOrient == "L")
                    {
                        arwHeadUp_x3 = sashPoint.X + arwStart_x1;
                        arwHeadUp_x4 = sashPoint.X + arwStart_x1;

                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                         new PointF(arwStart_x1, center_y1));
                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                         new PointF(arwStart_x1, center_y1));
                    }
                    g.DrawLine(new Pen(Color.Black), new PointF(arwStart_x1, center_y1),
                                                     new PointF(arwEnd_x2, center_y1));
                }
            }

            int w = borderStyle;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   fwidth - w,
                                                                   fheight - w));

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
