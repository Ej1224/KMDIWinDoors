using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;

namespace KMDIWinDoorsCS
{
    public partial class frmMain2 : Form
    {
        Pen blkPen = new Pen(Color.Black);
        Class.csFunctions csfunc = new Class.csFunctions();
        public frmMain2()
        {
            InitializeComponent();
        }

        private Panel CreatePanels(string name,
                                   DockStyle dok = DockStyle.Fill,
                                   int Pwidth = 0,
                                   int Pheight = 0,
                                   string wndrtype = "")
        {
            Panel cr8newpnl = new Panel();
            cr8newpnl.Name = name;
            cr8newpnl.AllowDrop = false;
            cr8newpnl.AccessibleDescription = wndrtype;
            cr8newpnl.TabStop = false; //for panelname viewmode
            cr8newpnl.BackColor = Color.DarkGray;
            cr8newpnl.Dock = dok;
            cr8newpnl.Margin = new Padding(0);
            cr8newpnl.Padding = new Padding(0);
            cr8newpnl.Size = new Size(Pwidth, Pheight);
            cr8newpnl.Cursor = Cursors.Hand;
            cr8newpnl.BringToFront();
            cr8newpnl.Paint += new PaintEventHandler(pnl_Paint);
            cr8newpnl.MouseClick += new MouseEventHandler(pnl_MouseClick);

            return cr8newpnl;
        }

        Panel pnlSel, prev_pnlSel, pnlSel_parent, prev_pnlSel_parent;
        string pnlnameSel, prev_pnlnameSel;
        Type pnltypeSel, prev_pnltypeSel;

        private void pnl_MouseClick(object sender, MouseEventArgs e)
        {
            pnlSel = (Panel)sender;
            pnlSel_parent = (Panel)pnlSel.Parent;

            pnlnameSel = pnlSel.Name;
            pnltypeSel = pnlSel.GetType();

            var c = csfunc.GetAll(flpMain, prev_pnltypeSel, prev_pnlnameSel);
            foreach (var ctrl in c)
            {
                ctrl.AccessibleName = "Black";
                ctrl.Invalidate();
            }

            pnlSel.AccessibleName = "Blue";
            pnlSel.Invalidate();

            prev_pnlnameSel = pnlnameSel;
            prev_pnlSel = pnlSel;
            prev_pnlSel_parent = pnlSel_parent;
            prev_pnltypeSel = pnltypeSel;

            if (pnlSel.Name.Contains("Multi_"))
            {
                autoToolStripMenuItem.Visible = true;
                autoSlidingToolStripMenuItem.Visible = false;
            }
            else if (pnlSel.Name.Contains("Sliding"))
            {
                autoSlidingToolStripMenuItem.Visible = true;
                autoToolStripMenuItem.Visible = false;
            }
            else
            {
                autoSlidingToolStripMenuItem.Visible = false;
                autoToolStripMenuItem.Visible = false;
            }

            if (e.Button == MouseButtons.Right)
            {
                cmenuPanel.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void pnl_inner_MouseClick(object sender, MouseEventArgs e)
        {
            Panel pnlinner = (Panel)sender;
            pnlSel = (Panel)pnlinner.Parent;
            pnlSel_parent = flpMain;

            pnlnameSel = pnlSel.Name;
            pnltypeSel = pnlSel.GetType();

            var c = csfunc.GetAll(flpMain, prev_pnltypeSel, prev_pnlnameSel);
            foreach (var ctrl in c)
            {
                ctrl.AccessibleName = "Black";
                ctrl.Invalidate();
            }

            pnlSel.AccessibleName = "Blue";
            pnlSel.Invalidate();

            prev_pnlnameSel = pnlnameSel;
            prev_pnlSel = pnlSel;
            prev_pnlSel_parent = pnlSel_parent;
            prev_pnltypeSel = pnltypeSel;

            autoToolStripMenuItem.Visible = false;
            if (e.Button == MouseButtons.Right)
            {
                cmenuPanel.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void pnl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Panel pnl = (Panel)sender;
            Panel pnlParent = (Panel)pnl.Parent;
            int fpnl_sashW = pnl.Width - 20,
                fpnl_sashH = pnl.Height - 20;

            Point sashPoint = new Point(pnl.ClientRectangle.X + 8, pnl.ClientRectangle.Y + 8);
            
            string windowtype = pnl.AccessibleDescription;
            Rectangle sashRect = new Rectangle(sashPoint,
                                               new Size(fpnl_sashW, fpnl_sashH));

            if (windowtype.Contains("Fixed"))
            {
                pnl.BackColor = Color.DarkGray;
                if (windowtype == "FixeddSash")
                {
                    g.DrawRectangle(blkPen, sashRect);
                }
                Font drawFont = new Font("Segoe UI", 12);// * zoom);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), pnl.ClientRectangle, drawFormat);
            }
            else if (windowtype == "Concrete")
            {
                pnl.BackColor = Color.DarkGray;
                int cond = pnl.Width + pnl.Height;

                for (int i = 10; i < cond; i += 10)
                {
                    g.DrawLine(Pens.Black, new Point(0, i), new Point(i, 0));
                }
            }
            else
            {
                Pen dgrayPen = new Pen(Color.DimGray);
                    dgrayPen.DashStyle = DashStyle.Dash;
                    dgrayPen.Width = 3;
                g.DrawRectangle(blkPen, sashRect);

                if (windowtype == "CasementR")
                {
                    pnl.BackColor = Color.DarkGray;

                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + fpnl_sashW, (sashPoint.Y + (fpnl_sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + fpnl_sashW, (sashPoint.Y + (fpnl_sashH / 2))),
                                         new Point(sashPoint.X, fpnl_sashH + sashPoint.Y));
                }
                else if (windowtype == "CasementL")
                {
                    pnl.BackColor = Color.DarkGray;

                    g.DrawLine(dgrayPen, new Point(sashPoint.X + fpnl_sashW, sashPoint.Y),
                                         new Point(sashPoint.X, (sashPoint.Y + (fpnl_sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (fpnl_sashH / 2))),
                                         new Point(sashPoint.X + fpnl_sashW, fpnl_sashH + sashPoint.Y));
                }
                else if (windowtype == "AwningNorm")
                {
                    pnl.BackColor = Color.DarkGray;

                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y + fpnl_sashH),
                                         new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y),
                                         new Point(sashPoint.X + fpnl_sashW, fpnl_sashH + sashPoint.Y));
                }
                else if (windowtype == "AwningInvrt")
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y + fpnl_sashH));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y + fpnl_sashH),
                                         new Point(sashPoint.X + fpnl_sashW, sashPoint.Y));
                }
                else if (windowtype.Contains("Sliding"))
                {
                    pnl.BackColor = Color.DarkGray;

                    float arwStart_x1 = sashPoint.X + (fpnl_sashW / 20),
                          center_y1 = sashPoint.Y + (fpnl_sashH / 2),
                          arwEnd_x2 = ((sashPoint.X + fpnl_sashW) - arwStart_x1) + (fpnl_sashW / 20),
                          arwHeadUp_x3,
                          arwHeadUp_y3 = center_y1 - (center_y1 / 4),
                          arwHeadUp_x4,
                          arwHeadUp_y4 = center_y1 + (center_y1 / 4);
                    
                    if (windowtype == "SlidingR")
                    {
                        arwHeadUp_x3 = ((sashPoint.X + fpnl_sashW) - arwStart_x1) - (fpnl_sashW / 10);
                        arwHeadUp_x4 = ((sashPoint.X + fpnl_sashW) - arwStart_x1) - (fpnl_sashW / 10);

                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                         new PointF(arwEnd_x2, center_y1));
                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                         new PointF(arwEnd_x2, center_y1));
                    }
                    else if (windowtype == "SlidingL")
                    {
                        arwHeadUp_x3 = sashPoint.X + arwStart_x1 + (fpnl_sashW / 10);
                        arwHeadUp_x4 = sashPoint.X + arwStart_x1 + (fpnl_sashW / 10);

                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                         new PointF(arwStart_x1, center_y1));
                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                         new PointF(arwStart_x1, center_y1));
                    }
                    g.DrawLine(new Pen(Color.Black), new PointF(arwStart_x1, center_y1),
                                                     new PointF(arwEnd_x2, center_y1));
                }
                else if (windowtype.Contains("Tilt&Turn"))
                {
                    pnl.BackColor = Color.DarkGray;

                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y + fpnl_sashH));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y + fpnl_sashH),
                                         new Point(sashPoint.X + fpnl_sashW, sashPoint.Y));

                    if (windowtype.Contains("Norm"))
                    {
                        g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + fpnl_sashW, (sashPoint.Y + (fpnl_sashH / 2))));
                        g.DrawLine(dgrayPen, new Point(sashPoint.X + fpnl_sashW, (sashPoint.Y + (fpnl_sashH / 2))),
                                             new Point(sashPoint.X, fpnl_sashH + sashPoint.Y));
                    }
                    else if (windowtype.Contains("Invrt"))
                    {
                        g.DrawLine(dgrayPen, new Point(sashPoint.X + fpnl_sashW, sashPoint.Y),
                                         new Point(sashPoint.X, (sashPoint.Y + (fpnl_sashH / 2))));
                        g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (fpnl_sashH / 2))),
                                             new Point(sashPoint.X + fpnl_sashW, fpnl_sashH + sashPoint.Y));
                    }
                }
                else if (windowtype.Contains("Louver"))
                {
                    int numblades = Convert.ToInt32(windowtype.Replace("Louver",""));

                    pnl.BackColor = Color.Black;

                    g.DrawRectangle(Pens.Black, sashRect);
                    g.FillRectangle(new SolidBrush(Color.DarkGray), sashRect);

                    Rectangle gallery1 = new Rectangle(sashPoint,
                                         new Size(10, fpnl_sashH));
                    Pen blkpen = new Pen(Color.Black, 2);
                    g.DrawRectangle(blkpen, gallery1);


                    Rectangle gallery2 = new Rectangle(new Point(sashPoint.X + (fpnl_sashW - 10), sashPoint.Y),
                                         new Size(10, fpnl_sashH));
                    g.DrawRectangle(blkpen, gallery2);

                    int bladesheight = fpnl_sashH / numblades;

                    for (int i = 0; i < numblades; i++)
                    {
                        Rectangle blades = new Rectangle(new Point(sashPoint.X + 10, sashPoint.Y + (bladesheight * i)), new Size(fpnl_sashW - 20, bladesheight * i));
                        g.DrawRectangle(blkpen, blades);
                    }
                }
            }

            if (pnl.TabStop == true)
            {
                Font dmnsion_font = new Font("Segoe UI", 12);// * zoom);

                Size s = TextRenderer.MeasureText(pnl.Name, dmnsion_font);
                double mid = (pnl.Width) / 2;
                TextRenderer.DrawText(g,
                                      pnl.Name,
                                      dmnsion_font,
                                      new Point(sashPoint.X + Convert.ToInt32(3 * zoom), sashPoint.Y + Convert.ToInt32(3 * zoom)),
                                      Color.Blue);
            }

            string accname_col = pnl.AccessibleName;
            Color col = Color.Black;
            if (accname_col == "Black")
            {
                col = Color.Black;
            }
            else if (accname_col == "Blue")
            {
                col = Color.Blue;
            }

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                                   0,
                                                                   pnl.ClientRectangle.Width - w,
                                                                   pnl.ClientRectangle.Height - w));
        }

        private Panel CreateFrame(string name,
                                  int fwidth,
                                  int fheight,
                                  int wndr,
                                  int id)
        {
            Panel frame = new Panel();
            frame.Name = name + "_" + id;
            frame.AccessibleDescription = "viewmodeOff";
            frame.Margin = new Padding(0);
            frame.Padding = new Padding(wndr);
            frame.Size = new Size(fwidth, fheight);
            frame.Tag = wndr;
            frame.Cursor = Cursors.Hand;
            frame.TabIndex = id;
            frame.Paint += new PaintEventHandler(pnlFrame_Paint);
            frame.MouseClick += new MouseEventHandler(pnl_MouseClick);
            frame.PaddingChanged += new EventHandler(frame_PaddingChanged);


            Panel pnl_inner = new Panel();
            pnl_inner.Name = "pnl_inner" + id;
            pnl_inner.AllowDrop = true;
            pnl_inner.Dock = DockStyle.Fill;
            pnl_inner.Margin = new Padding(0);
            pnl_inner.Padding = new Padding(0);
            //pnl_inner.Tag = wndr;
            //pnl_inner.TabIndex = id;
            pnl_inner.Tag = frame.Name;
            pnl_inner.DragDrop += new DragEventHandler(pnl_inner_DragDrop);
            pnl_inner.DragOver += new DragEventHandler(pnl_inner_DragOver);
            pnl_inner.Paint += new PaintEventHandler(border_paint);
            pnl_inner.MouseClick += new MouseEventHandler(pnl_inner_MouseClick);

            frame.Controls.Add(pnl_inner);
            return frame;
        }

        private void frame_PaddingChanged(object sender, EventArgs e)
        {
            Panel pnlFrame = (Panel)sender;
            pnlFrame.Controls[0].Invalidate();
        }

        private FlowLayoutPanel CreateMultiPnl(string name,
                                               string div,
                                               int wndr,
                                               string numDiv)
        {
            FlowLayoutPanel multi = new FlowLayoutPanel();
            multi.Name = name;
            multi.AllowDrop = true;
            multi.AccessibleDescription = numDiv;
            multi.BackColor = SystemColors.ActiveCaption;
            multi.Dock = dok;
            multi.Padding = new Padding(0);
            multi.Margin = new Padding(0);
            multi.Tag = wndr;
            multi.Cursor = Cursors.Hand;

            if (div == "Mullion")
            {
                multi.FlowDirection = FlowDirection.LeftToRight;
            }
            else if (div == "Transom")
            {
                multi.FlowDirection = FlowDirection.TopDown;
            }
            multi.DragOver += new DragEventHandler(pnl_inner_DragOver);
            multi.DragDrop += new DragEventHandler(pnl_inner_DragDrop);
            multi.Paint += new PaintEventHandler(flp_paint);
            multi.MouseClick += new MouseEventHandler(pnl_MouseClick);

            return multi;
        }

        private void flp_paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Panel pnl = (Panel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Font drawFont = new Font("Segoe UI", 12 * zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            g.DrawString("Multi_Panel (" + pnl.AccessibleDescription + ")", drawFont, new SolidBrush(Color.Black), 0,0);
            
            string accname_col = pnl.AccessibleName;
            Color col = Color.Black;
            if (accname_col == "Black")
            {
                col = Color.Black;
            }
            else if (accname_col == "Blue")
            {
                col = Color.Blue;
            }

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                                   0,
                                                                   pnl.ClientRectangle.Width - w,
                                                                   pnl.ClientRectangle.Height - w));
        }

        private Panel CreateDiv(string name)
        {
            Panel div = new Panel();
            div.Name = name;
            div.BackColor = Color.CadetBlue;
            div.Margin = new Padding(0);
            div.Padding = new Padding(0);
            div.Tag = "Fixed";
            div.Cursor = Cursors.Hand;
            div.Paint += new PaintEventHandler(div_paint);
            div.MouseClick += new MouseEventHandler(pnl_MouseClick);

            return div;
        }

        private void div_paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Panel frame = (Panel)pnl.Parent;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            string accname_col = pnl.AccessibleName;
            Color col = Color.Black;
            if (accname_col == "Black")
            {
                col = Color.Black;
            }
            else if (accname_col == "Blue")
            {
                col = Color.Blue;
            }

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                                   0,
                                                                   pnl.ClientRectangle.Width - w,
                                                                   pnl.ClientRectangle.Height - w));
        }

        private void border_paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Panel frame = (Panel)pnl.Parent;
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (frame.Tag.ToString() == "0")
            {
                int cond = pnl.Width + pnl.Height;

                for (int i = 10; i < cond; i += 10)
                {
                    g.DrawLine(Pens.Black, new Point(0, i), new Point(i, 0));
                }
            }

            string accname_col = pnl.AccessibleName;
            Color col = Color.Black;
            if (accname_col == "Black")
            {
                col = Color.Black;
            }
            else if (accname_col == "Blue")
            {
                col = Color.Blue;
            }

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                           0,
                                                           pnl.ClientRectangle.Width - w,
                                                           pnl.ClientRectangle.Height - w));
        }

        private FlowLayoutPanel CreateFrameProperties(string name,
                                                      int count,
                                                      int fwidth,
                                                      int fheight,
                                                      int wndr)
        {
            bool bool_win = false, bool_door = false;
            if (wndr == 26)
            {
                bool_win = true;
            }
            else if (wndr == 33)
            {
                bool_door = true;
            }

            FlowLayoutPanel fprop;
            Label lbl;
            RadioButton rd;
            NumericUpDown num;

            fprop = new FlowLayoutPanel();
            fprop.Name = name + "_" + count;
            fprop.AutoSize = true;
            fprop.BorderStyle = BorderStyle.FixedSingle;
            fprop.Font = new Font("Segoe UI", 8.25f);
            fprop.Dock = DockStyle.Top;
            fprop.Padding = new Padding(0, 7, 0, 0);
            fprop.Margin = new Padding(3, 4, 3, 4);
            fprop.SizeChanged += new EventHandler(flpProp_SizeChanged);

            lbl = new Label();
            lbl.Text = name + " " + count;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            fprop.Controls.Add(lbl);

            rd = new RadioButton();
            rd.Name = "rdWindow_" + count;
            rd.AutoSize = false;
            rd.Checked = bool_win;
            rd.Margin = new Padding(3, 3, 3, 3);
            rd.Padding = new Padding(0);
            rd.Size = new Size(140, 23);
            rd.TabStop = true;
            rd.Tag = name + "_" + count;
            rd.Text = "Window";
            rd.CheckedChanged += new EventHandler(rd_CheckChanged);
            fprop.Controls.Add(rd);

            rd = new RadioButton();
            rd.Name = "rdDoor_" + count;
            rd.AutoSize = false;
            rd.Checked = bool_door;
            rd.Margin = new Padding(3, 3, 3, 3);
            rd.Padding = new Padding(0);
            rd.Size = new Size(140, 23);
            rd.TabStop = true;
            rd.Tag = name + "_" + count;
            rd.Text = "Door";
            rd.CheckedChanged += new EventHandler(rd_CheckChanged);
            fprop.Controls.Add(rd);

            rd = new RadioButton();
            rd.Name = "rdConcrete_" + count;
            rd.AutoSize = false;
            rd.Checked = false;
            rd.Margin = new Padding(3, 3, 3, 3);
            rd.Padding = new Padding(0);
            rd.Size = new Size(140, 23);
            rd.TabStop = true;
            rd.Tag = name + "_" + count;
            rd.Text = "Concrete";
            rd.CheckedChanged += new EventHandler(rd_CheckChanged);
            fprop.Controls.Add(rd);

            lbl = new Label();
            lbl.Text = "Width";
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 8.25f);
            lbl.Margin = new Padding(3, 0, 3, 0);
            fprop.Controls.Add(lbl);

            num = new NumericUpDown();
            num.Name = "numfWidth_" + count;
            num.AutoSize = false;
            num.Font = new Font("Segoe UI", 8.25f);
            num.Size = new Size(135, 26);
            num.Maximum = decimal.MaxValue;
            num.Margin = new Padding(3, 3, 3, 3);
            num.Value = fwidth;
            num.ValueChanged += new EventHandler(num_ValueChanged);
            fprop.Controls.Add(num);

            lbl = new Label();
            lbl.Text = "Height";
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 8.25f);
            lbl.Margin = new Padding(3, 0, 3, 0);
            fprop.Controls.Add(lbl);

            num = new NumericUpDown();
            num.Name = "numfHeight_" + count;
            num.AutoSize = false;
            num.Font = new Font("Segoe UI", 8.25f);
            num.Size = new Size(135, 26);
            num.Maximum = decimal.MaxValue;
            num.Margin = new Padding(3, 3, 3, 3);
            num.Value = fheight;
            num.ValueChanged += new EventHandler(num_ValueChanged);
            fprop.Controls.Add(num);

            return fprop;
        }

        private string UpdateLblDescription(string profiletype)
        {
            string desc = "";
            string wndrtype = "",
                   wndrcol = "",
                   str_wndr = "";
            //int loop_cntr = 0;

            var pnlcol = csfunc.GetAll(pnlPropertiesBody, typeof(Panel), "Panel");
            int cnt_pnlcol = pnlcol.Count();
            int bladecount = 0;

            if (pnlcol.Count() != 0)
            {
                foreach (Panel item in pnlcol)
                {
                    foreach (var ctrl in item.Controls)
                    {
                        if (ctrl.GetType() == typeof(ComboBox))
                        {
                            ComboBox cbx = (ComboBox)ctrl;
                            wndrcol += cbx.Text;
                        }
                        if (ctrl.GetType() == typeof(NumericUpDown))
                        {
                            NumericUpDown bnum = (NumericUpDown)ctrl;
                            if (bnum.Name.Contains("numBladeCount_"))
                            {
                                bladecount = Convert.ToInt32(bnum.Value);
                            }
                        }
                    }
                }
            }
            
            int countAwng = Regex.Matches(wndrcol, "Awning").Count;
            int countCasm = Regex.Matches(wndrcol, "Casement").Count;
            int countFixd = Regex.Matches(wndrcol, "Fixed").Count;
            int countLvr = Regex.Matches(wndrcol, "Louver").Count;
            int countSlid = Regex.Matches(wndrcol, "Sliding").Count;
            int countTntr = Regex.Matches(wndrcol, "Tilt&Turn").Count;

            if (countAwng > 0)
            {
                str_wndr += countAwng + " Awning";
            }
            if (countCasm > 0)
            {
                str_wndr += ", " + countCasm + " Casement";
            }
            if (countFixd > 0)
            {
                str_wndr += ", " + countFixd + " Fixed";
            }
            if (countLvr > 0)
            {
                str_wndr += ", " + countLvr + " Louver(" + bladecount + " blade)";
            }
            if (countSlid > 0)
            {
                str_wndr += ", " + countSlid + " Sliding";
            }
            if (countTntr > 0)
            {
                str_wndr += ", " + countTntr + " Tilt & Turn";
            }

            string wndrloop = "";
            var rdcol = csfunc.GetAll(pnlPropertiesBody, typeof(RadioButton));
            foreach (RadioButton item in rdcol)
            {
                if (item.Checked == true)
                {
                    wndrloop += item.Text;
                }
            }

            if (wndrloop.Contains("Window") && wndrloop.Contains("Door"))
            {
                wndrtype = "Window/Door";
            }
            else if (wndrloop.Contains("Window") && wndrloop.Contains("Door") == false)
            {
                wndrtype = "Window";
            }
            else if (wndrloop.Contains("Window") == false && wndrloop.Contains("Door"))
            {
                wndrtype = "Door";
            }

            desc = profiletype + "\n" + pnlcol.Count().ToString() + " Panel " + wndrtype + "\n(" + str_wndr.TrimStart(' ',',') + ")";

            return desc;
        }

        private void flpProp_SizeChanged(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = (FlowLayoutPanel)sender;
            Label lbl = new Label();
            lbl = itemsLblSearch("lbldesc_");
            lbl.Text = UpdateLblDescription(lbl.AccessibleDescription);
        }

        public void rd_CheckChanged(object sender, EventArgs e)
        {
            if (Text.Contains("*") == false)
            {
                Text += "*";
            }
            RadioButton rd = (RadioButton)sender;
            int wndr_padd = 0;
            Panel pnl = new Panel();
            Panel pnl2 = new Panel();

            if (rd.Checked == true)
            {
                if (rd.Name.Contains("rdWindow_"))
                {
                    wndr_padd = wndrtype = 26;
                }
                else if (rd.Name.Contains("rdDoor_"))
                {
                    wndr_padd = wndrtype = 33;
                }
                else if (rd.Name.Contains("rdConcrete_"))
                {
                    wndr_padd = wndrtype = 0;
                }
                flpMain2.Invalidate();


                Panel frame = new Panel();
                var c = csfunc.GetAll(flpMain, typeof(Panel), rd.Tag.ToString());//Searching for Frame
                foreach (Panel ctrl in c)
                {
                    ctrl.Padding = new Padding(Convert.ToInt32(wndr_padd * zoom));
                    ctrl.Tag = wndr_padd;
                    ctrl.Invalidate();
                    frame = ctrl;
                }


                Panel frame2 = new Panel();
                var c2 = csfunc.GetAll(flpMain2, typeof(Panel), rd.Tag.ToString());//Searching for Frame
                foreach (Panel ctrl in c2)
                {
                    ctrl.Padding = new Padding(Convert.ToInt32(wndr_padd));
                    ctrl.Tag = wndr_padd;
                    ctrl.Invalidate();
                    frame2 = ctrl;
                }

                var pnlcol = csfunc.GetAll(frame, typeof(Panel), "Panel");
                foreach (Panel ctrl in pnlcol)
                {
                    pnl = ctrl;
                }

                var pnlcol2 = csfunc.GetAll(frame2, typeof(Panel), "Panel");
                foreach (Panel ctrl in pnlcol2)
                {
                    pnl2 = ctrl;
                }
            }

            var numcol = csfunc.GetAll(rd.Parent, typeof(NumericUpDown), "pnum");
            foreach (NumericUpDown ctrl in numcol)
            {
                if (ctrl.Enabled == false)
                {
                    if (ctrl.Name.Contains("Width"))
                    {
                        ctrl.Value = pnl.Width;
                    }
                    else if (ctrl.Name.Contains("Height"))
                    {
                        ctrl.Value = pnl.Height;
                    }
                }
            }

            FlowLayoutPanel flp = (FlowLayoutPanel)rd.Parent;
            Label lbl = new Label();
            lbl = itemsLblSearch("lbldesc_");
            lbl.Text = UpdateLblDescription(lbl.AccessibleDescription);

            trackzoom = false;
            flpMain.Invalidate();
            flpMain2.Invalidate();
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (Text.Contains("*") == false)
            {
                Text += "*";
            }

            NumericUpDown num = (NumericUpDown)sender;
            string frameName = num.Parent.Name,
                   str_width = "",
                   str_height = "";
            int frameid = 0, wndr = 0;
            Panel snglPnl = new Panel();
            List<int> lstDimensions = new List<int>();

            var c = csfunc.GetAll(flpMain, typeof(Panel), frameName); // Searching for Frame
            foreach (var ctrl in c)
            {
                frameid = ctrl.TabIndex;
                wndr = Convert.ToInt32(ctrl.Tag);
                lstDimensions = dictFrameDimension[frameid];

                if (num.Name.Contains("numfWidth_"))
                {
                    lstDimensions[0] = Convert.ToInt32(num.Value);
                    ctrl.Width = Convert.ToInt32(Convert.ToInt32(num.Value) * zoom);
                }
                else if (num.Name.Contains("numfHeight_"))
                {
                    lstDimensions[1] = Convert.ToInt32(num.Value);
                    ctrl.Height = Convert.ToInt32(Convert.ToInt32(num.Value) * zoom);
                }
                dictFrameDimension[frameid] = lstDimensions;
                ctrl.Invalidate();

                var PnlCollect = csfunc.GetAll(ctrl, typeof(Panel));
                foreach (Panel pnl in PnlCollect)
                {
                    snglPnl = pnl;
                    pnl.Invalidate();
                }

                var FlpCollect = csfunc.GetAll(ctrl, typeof(FlowLayoutPanel));
                foreach (FlowLayoutPanel flp in FlpCollect)
                {
                    flp.Invalidate();
                }
            }


            var c2 = csfunc.GetAll(flpMain2, typeof(Panel), frameName); // Searching for Frame2
            foreach (var ctrl in c2)
            {
                if (num.Name.Contains("numfWidth_"))
                {
                    ctrl.Width = Convert.ToInt32(num.Value);
                }
                else if (num.Name.Contains("numfHeight_"))
                {
                    ctrl.Height = Convert.ToInt32(num.Value);
                }
                ctrl.Invalidate();

                var PnlCollect = csfunc.GetAll(ctrl, typeof(Panel));
                foreach (Panel pnl in PnlCollect)
                {
                    snglPnl = pnl;
                    pnl.Invalidate();
                }

                var FlpCollect = csfunc.GetAll(ctrl, typeof(FlowLayoutPanel));
                foreach (FlowLayoutPanel flp in FlpCollect)
                {
                    flp.Invalidate();
                }
            }

            var numcol = csfunc.GetAll(num.Parent, typeof(NumericUpDown)); //Searching for NumericUpDown of Single Panel
            foreach (NumericUpDown ctrl in numcol)
            {
                if (ctrl.Enabled == false)
                {
                    if (num.Name.Contains("numfWidth_"))
                    {
                        if (ctrl.Name.Contains("Width"))
                        {
                            //ctrl.Value = snglPnl.Width;
                            ctrl.Value = num.Value - (wndr * 2);
                        }
                    }
                    else if (num.Name.Contains("numfHeight_"))
                    {
                        if (ctrl.Name.Contains("Height"))
                        {
                            ctrl.Value = num.Value - (wndr * 2);
                            //ctrl.Value = snglPnl.Height;
                        }
                    }
                }
                
                if (ctrl.Name.Contains("numfWidth_"))
                {
                    str_width = ctrl.Value.ToString();
                }
                else if (ctrl.Name.Contains("numfHeight_"))
                {
                    str_height = ctrl.Value.ToString();
                }
            }

            trackzoom = false;
            flpMain.Invalidate();
        }

        private Panel CreatePanelProperties(string name,
                                            int count,
                                            int Pwidth,
                                            int Pheight,
                                            bool num_bool,
                                            string pnlwndrtype = "",
                                            int louv_blade_num = 2,
                                            bool bool_orientation = false,
                                            string chktext = "",
                                            bool chkVisible = true,
                                            bool numBladeVisible = false)
        {
            Panel Pprop;
            Label lbl;
            ComboBox cbx;
            CheckBox chk;
            NumericUpDown num;

            Pprop = new Panel();
            Pprop.Name = name;
            Pprop.BorderStyle = BorderStyle.FixedSingle;
            Pprop.AutoSize = true;
            Pprop.Margin = new Padding(3, 3, 3, 3);

            lbl = new Label();
            lbl.Name = name;
            lbl.Text = "Panel " + count;
            lbl.AutoSize = true;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Font = new Font("Segoe UI", 10,FontStyle.Italic);
            lbl.Location = new Point(7, 9);
            Pprop.Controls.Add(lbl);

            lbl = new Label();
            lbl.Text = "Type";
            lbl.AutoSize = true;
            lbl.Location = new Point(7, 36);
            Pprop.Controls.Add(lbl);

            chk = new CheckBox();
            chk.Name = "chkWdrOrientation_" + count;
            chk.Appearance = Appearance.Button;
            chk.BackColor = SystemColors.ControlDark;
            chk.FlatAppearance.BorderSize = 0;
            chk.FlatAppearance.CheckedBackColor = Color.SteelBlue;
            chk.FlatStyle = FlatStyle.Flat;
            chk.Font = new Font("Segoe UI", 8.25f);
            chk.Size = new Size(50, 21);
            chk.TextAlign = ContentAlignment.MiddleCenter;
            chk.Location = new Point(90, 50);
            chk.Visible = chkVisible;
            chk.Checked = bool_orientation;
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            Pprop.Controls.Add(chk);
            if (chktext != "")
            {
                chk.Text = chktext;
            }

            num = new NumericUpDown();
            num.Name = "numBladeCount_" + count;
            num.BackColor = SystemColors.ControlDark;
            num.Font = new Font("Segoe UI", 8.25f);
            num.Size = new Size(50, 21);
            num.Maximum = decimal.MaxValue;
            num.Value = 1;
            num.Location = new Point(90, 50);
            num.Visible = numBladeVisible;
            num.Minimum = 2;
            num.ValueChanged += new EventHandler(BladeNum_ValueChanged);
            Pprop.Controls.Add(num);
            num.Value = louv_blade_num;

            cbx = new ComboBox();
            cbx.Name = "cbxWindowType_" + count;
            cbx.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx.Margin = new Padding(3, 4, 3, 4);
            cbx.Size = new Size(77, 27);
            cbx.Items.Add("Fixed");
            cbx.Items.Add("Awning");
            cbx.Items.Add("Casement");
            cbx.Items.Add("Sliding");
            cbx.Items.Add("Tilt&Turn");
            cbx.Items.Add("Louver");
            cbx.Items.Add("Concrete");
            cbx.Location = new Point(7, 50);
            if (chktext != "")
            {
                cbx.Text = pnlwndrtype;
            }
            cbx.SelectedIndexChanged += new EventHandler(cbx_SelectedIndexChanged);
            Pprop.Controls.Add(cbx);
            if (chktext == "")
            {
                cbx.Text = pnlwndrtype;
            }

            lbl = new Label();
            lbl.Text = "Width";
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 8.25f);
            lbl.Margin = new Padding(3, 0, 3, 0);
            lbl.Location = new Point(7, 80);
            Pprop.Controls.Add(lbl);

            num = new NumericUpDown();
            num.Name = "pnumWidth_" + count;
            num.AutoSize = false;
            num.Font = new Font("Segoe UI", 8.25f);
            num.Size = new Size(135, 26);
            num.Maximum = decimal.MaxValue;
            num.Margin = new Padding(3, 3, 3, 3);
            num.Value = Pwidth;
            num.Location = new Point(7, 100);
            num.Enabled = num_bool;
            num.ValueChanged += new EventHandler(Pnum_ValueChanged);
            Pprop.Controls.Add(num);

            lbl = new Label();
            lbl.Text = "Height";
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 8.25f);
            lbl.Margin = new Padding(3, 0, 3, 0);
            lbl.Location = new Point(7, 130);
            Pprop.Controls.Add(lbl);

            num = new NumericUpDown();
            num.Name = "pnumHeight_" + count;
            num.AutoSize = false;
            num.Font = new Font("Segoe UI", 8.25f);
            num.Size = new Size(135, 26);
            num.Maximum = decimal.MaxValue;
            num.Margin = new Padding(3, 3, 3, 3);
            num.Value = Pheight;
            num.ValueChanged += new EventHandler(Pnum_ValueChanged);
            num.Location = new Point(7, 150);
            num.Enabled = num_bool;
            Pprop.Controls.Add(num);

            return Pprop;
        }

        private void BladeNum_ValueChanged(object sender, EventArgs e)
        {
            if (Text.Contains("*") == false)
            {
                Text += "*";
            }

            string accdesc = "";
            NumericUpDown bnum = (NumericUpDown)sender;
            accdesc = "Louver" + bnum.Value;

            var pnlcol = csfunc.GetAll(flpMain, typeof(Panel), bnum.Parent.Name);
            foreach (Panel ctrl in pnlcol)
            {
                ctrl.AccessibleDescription = accdesc;
                ctrl.Invalidate();
            }

            var pnlcol2 = csfunc.GetAll(flpMain2, typeof(Panel), bnum.Parent.Name);
            foreach (Panel ctrl in pnlcol2)
            {
                ctrl.AccessibleDescription = accdesc;
                ctrl.Invalidate();
            }

            FlowLayoutPanel flp = (FlowLayoutPanel)bnum.Parent.Parent;
            Label lbl = new Label();
            lbl = itemsLblSearch("lbldesc_");
            lbl.Text = UpdateLblDescription(lbl.AccessibleDescription);

            trackzoom = false;
            flpMain.Invalidate();
            flpMain2.Invalidate();
        }

        private void Pnum_ValueChanged(object sender, EventArgs e)
        {
            if (Text.Contains("*") == false)
            {
                Text += "*";
            }

            int pnlid = 0;
            List<int> lstDimensions = new List<int>();

            NumericUpDown pnum = (NumericUpDown)sender;
            Panel pnl = new Panel();
            var c = csfunc.GetAll(flpMain, typeof(Panel), pnum.Parent.Name);
            foreach (Panel ctrl in c)
            {
                pnl = ctrl;
            }

            Panel pnl2 = new Panel();
            var col2 = csfunc.GetAll(flpMain2, typeof(Panel), pnum.Parent.Name);
            foreach (Panel ctrl in col2)
            {
                pnl2 = ctrl;
            }

            pnlid = pnl.TabIndex;
            lstDimensions = dictPanelDimension[pnlid];

            if (pnum.Name.Contains("Width"))
            {
                lstDimensions[0] = Convert.ToInt32(pnum.Value);
                pnl.Width = Convert.ToInt32(Convert.ToInt32(pnum.Value) * zoom);
                pnl2.Width = Convert.ToInt32(pnum.Value);
            }
            else if (pnum.Name.Contains("Height"))
            {
                lstDimensions[1] = Convert.ToInt32(pnum.Value);
                pnl.Height = Convert.ToInt32(Convert.ToInt32(pnum.Value) * zoom);
                pnl2.Height = Convert.ToInt32(pnum.Value);
            }
            dictPanelDimension[pnlid] = lstDimensions;
            pnl.Invalidate();

            trackzoom = false;
            flpMain.Invalidate();

            pnl2.Invalidate();
            flpMain2.Invalidate();
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (Text.Contains("*") == false)
            {
                Text += "*";
            }

            CheckBox chk = (CheckBox)sender;
            if (chk.Checked == true)
            {
                if (chk.Text == "R")
                {
                    chk.Text = "L";
                }
                else if (chk.Text == "Norm")
                {
                    chk.Text = "Invrt";
                }
                else if (chk.Text == "None")
                {
                    chk.Text = "dSash";
                }
            }
            else if (chk.Checked == false)
            {
                if (chk.Text == "L")
                {
                    chk.Text = "R";
                }
                else if (chk.Text == "Invrt")
                {
                    chk.Text = "Norm";
                }
                else if (chk.Text == "dSash")
                {
                    chk.Text = "None";
                }
            }

            ComboBox cbx = new ComboBox();
            var cbxcol = csfunc.GetAll(chk.Parent, typeof(ComboBox));
            foreach (ComboBox ctrl in cbxcol)
            {
                cbx = ctrl;
            }

            var pnlcol = csfunc.GetAll(flpMain, typeof(Panel), chk.Parent.Name);
            foreach (Panel ctrl in pnlcol)
            {
                ctrl.AccessibleDescription = cbx.Text + chk.Text;
                ctrl.Invalidate();
            }

            var pnlcol2 = csfunc.GetAll(flpMain2, typeof(Panel), chk.Parent.Name);
            foreach (Panel ctrl in pnlcol2)
            {
                ctrl.AccessibleDescription = cbx.Text + chk.Text;
                ctrl.Invalidate();
            }

            trackzoom = false;
            flpMain.Invalidate();
            flpMain2.Invalidate();
        }

        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Text.Contains("*") == false)
            {
                Text += "*";
            }

            ComboBox cbx = (ComboBox)sender;

            CheckBox chk = new CheckBox();
            var chkcol = csfunc.GetAll(cbx.Parent, typeof(CheckBox));
            foreach (CheckBox ctrl in chkcol)
            {
                chk = ctrl;
            }

            NumericUpDown num = new NumericUpDown();
            var numcol = csfunc.GetAll(cbx.Parent, typeof(NumericUpDown), "numBladeCount_");
            foreach (NumericUpDown ctrl in numcol)
            {
                num = ctrl;
            }

            chk.Checked = false;
            chk.Visible = true;
            num.Visible = false;
            if (cbx.Text == "Casement" || cbx.Text == "Sliding")
            {
                chk.Enabled = true;
                chk.Text = "R";
            }
            else if (cbx.Text == "Awning" || cbx.Text == "Tilt&Turn")
            {
                chk.Enabled = true;
                chk.Text = "Norm";
            }
            else if (cbx.Text == "Fixed")
            {
                chk.Enabled = true;
                chk.Text = "None";
            }
            else if (cbx.Text == "Concrete")
            {
                chk.Enabled = false;
                chk.Text = "";
            }
            else if (cbx.Text == "Louver")
            {
                chk.Visible = false;
                num.Visible = true;
            }

            string accdesc = "";
            if (cbx.Text == "Louver")
            {
                accdesc = cbx.Text + num.Value;
            }
            else
            {
                accdesc = cbx.Text + chk.Text;
            }

            var pnlcol = csfunc.GetAll(flpMain, typeof(Panel),cbx.Parent.Name);
            foreach (Panel ctrl in pnlcol)
            {
                ctrl.AccessibleDescription = accdesc;
                ctrl.Invalidate();
            }

            var pnlcol2 = csfunc.GetAll(flpMain2, typeof(Panel), cbx.Parent.Name);
            foreach (Panel ctrl in pnlcol2)
            {
                ctrl.AccessibleDescription = accdesc;
                ctrl.Invalidate();
            }

            FlowLayoutPanel flp = (FlowLayoutPanel)cbx.Parent.Parent;
            Label lbl = new Label();
            lbl = itemsLblSearch("lbldesc_");
            lbl.Text = UpdateLblDescription(lbl.AccessibleDescription);

            trackzoom = false;
            flpMain.Invalidate();
            flpMain2.Invalidate();

            SelectNextControl(cbx, true,false,true,true);
        }

        private Panel CreateNewItem(string name,
                                    int count,
                                    string dimension,
                                    string description)
        {
            Panel itmpnl,pnl;
            Label lbl;
            PictureBox pbox;

            itmpnl = new Panel();
            itmpnl.Name = name + "_" + count;
            itmpnl.BorderStyle = BorderStyle.FixedSingle;
            itmpnl.Dock = DockStyle.Top;
            itmpnl.Height = 373;
            itmpnl.AccessibleDefaultActionDescription = dimension;
            itmpnl.AccessibleDescription = description;

            lbl = new Label();
            lbl.Name = "lbl_item" + count;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Dock = DockStyle.Top;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbl.Height = 20;
            lbl.Margin = new Padding(4, 0, 4, 0);
            lbl.Text = name + " " + count;
            lbl.Cursor = Cursors.Hand;
            lbl.ForeColor = Color.Blue;
            lbl.Tag = itmpnl.Name;
            lbl.AccessibleDescription = dimension;

            if (itemselected != null)
            {
                itemselected.ForeColor = Color.Black;
            }
            itemselected = lbl;

            lbl.MouseDoubleClick += new MouseEventHandler(lbl_MouseDoubleClick);
            itmpnl.Controls.Add(lbl);

            pbox = new PictureBox();
            pbox.Name = itmpnl.Name;
            pbox.BorderStyle = BorderStyle.FixedSingle;
            pbox.Dock = DockStyle.Fill;
            pbox.Size = new Size(220, 220);
            pbox.SizeMode = PictureBoxSizeMode.Zoom;
            itmpnl.Controls.Add(pbox);
            pbox.BringToFront();

            pnl = new Panel();
            pnl.Name = "pnl_itmbot_" + count;
            pnl.Dock = DockStyle.Bottom;
            pnl.Padding = new Padding(2);
            pnl.Height = 116;
            itmpnl.Controls.Add(pnl);

            lbl = new Label();
            lbl.Name = "lbldimension_" + count;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Dock = DockStyle.Top;
            lbl.Height = 23;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.Text = dimension;
            lbl.Tag = itmpnl.Name;
            pnl.Controls.Add(lbl);

            lbl = new Label();
            lbl.Name = "lbldesc_" + count;
            lbl.AutoEllipsis = true;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Dock = DockStyle.Fill;
            lbl.Font = new Font("Segoe UI", 8.25f);
            lbl.UseMnemonic = false;
            lbl.Text = description;
            lbl.AccessibleDescription = description;
            lbl.Tag = itmpnl.Name;

            pnl.Controls.Add(lbl);
            lbl.BringToFront();

            return itmpnl;
        }

        Label itemselected = null;

        private void lbl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool save = false;
            Label lbl = (Label)sender;
            //int loc_framecntr = 0,
            //    loc_cpnlcount = 0,
            //    loc_mulcount = 0,
            //    loc_trnscount = 0;

            trkZoom.Value = 100;

            if (Text.Contains("*") == true)
            {
                if (MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    save = true;
                    UppdateDictionaries();
                    Text = quotation_ref_no + " >> " + lbl.Text;
                }
            }
            else
            {
                save = true;
            }

            if (save == true)
            {
                trackzoom = false;
                itemselected.ForeColor = Color.Black;

                string lblname = lbl.Name;
                //int indxOf_lblname = lblname.IndexOf("m");
                string getnum_lblname = lblname.Substring(8, lbl.Name.Length - 8);
                int item_id = Convert.ToInt32(getnum_lblname);
               
                string WxH = lbl.AccessibleDescription.Replace(" ", "");
                string[] dimension = WxH.Split('x');

                static_wd = Convert.ToInt32(dimension[0]);
                static_ht = Convert.ToInt32(dimension[1]);

                flpMain.Size = new Size(Convert.ToInt32(dimension[0]), Convert.ToInt32(dimension[1]));
                flpMain.Tag = "Item_" + item_id;
                flpMain.Controls.Clear();

                flpMain2.Size = new Size(Convert.ToInt32(dimension[0]), Convert.ToInt32(dimension[1]));
                flpMain2.Tag = "Item_" + item_id;
                flpMain2.Controls.Clear();

                foreach (Panel item in itemslist[item_id])
                {
                    flpMain.Controls.Add(item);
                }

                foreach (Panel item2 in itemslist2[item_id])
                {
                    flpMain2.Controls.Add(item2);
                }
                //flpMain.Controls.Add(itemslist[item_id]);

                pnlPropertiesBody.Controls.Clear();
                foreach (Panel item in propertieslist[item_id])
                {
                    pnlPropertiesBody.Controls.Add(item);
                }
                //pnlPropertiesBody.Controls.Add(propertieslist[item_id]);

                lbl.ForeColor = Color.Blue;
                itemselected = lbl;

                UppdateDictionaries();
                Text = quotation_ref_no + " >> " + lbl.Text;

                Label lbl2 = new Label();
                lbl2 = itemsLblSearch("lbldesc_");
                lbl2.Text = UpdateLblDescription(lbl2.AccessibleDescription);
            }
        }

        private Label itemsLblSearch(string searchstr)
        {
            Label lbl = new Label();

            var lblcoll = csfunc.GetAll(pnlItems, typeof(Label), searchstr);
            foreach (Label ctrl in lblcoll)
            {
                if (ctrl.Tag.ToString() == flpMain.Tag.ToString())
                {
                    lbl = ctrl;
                }
            }
            return lbl;
        }

        private void UppdateDictionaries()
        {
            if (flpMain.Tag != null)
            {
                string getnum_str = flpMain.Tag.ToString().Substring(5, flpMain.Tag.ToString().Length - 5);
                int item_id = Convert.ToInt32(getnum_str);

                if (itemslist.ContainsKey(item_id) == true)
                {
                    List<Panel> pnlist = new List<Panel>();
                    foreach (Panel item in flpMain.Controls)
                    {
                        pnlist.Add(item);
                    }
                    itemslist[item_id] = pnlist;

                    List<Panel> pnlist2 = new List<Panel>();
                    foreach (Panel item2 in flpMain2.Controls)
                    {
                        pnlist2.Add(item2);
                    }
                    itemslist2[item_id] = pnlist2;

                    List<Panel> itemlist = new List<Panel>();
                    foreach (Panel item in pnlPropertiesBody.Controls)
                    {
                        itemlist.Add(item);
                    }
                    propertieslist[item_id] = itemlist;
                }
                else if (itemslist.ContainsKey(item_id) == false)
                {
                    List<Panel> pnlist = new List<Panel>();
                    foreach (Panel item in flpMain.Controls)
                    {
                        pnlist.Add(item);
                    }
                    itemslist.Add(item_id, pnlist);

                    List<Panel> pnlist2 = new List<Panel>();
                    foreach (Panel item2 in flpMain2.Controls)
                    {
                        pnlist2.Add(item2);
                    }
                    itemslist2.Add(item_id, pnlist2);

                    List<Panel> itemlist = new List<Panel>();
                    foreach (Panel item in pnlPropertiesBody.Controls)
                    {
                        itemlist.Add(item);
                    }
                    propertieslist.Add(item_id, itemlist);
                }
            }
        }

        private void AutoCreate(string wndrtype,
                                int wndrCount,
                                int wndr,
                                FlowLayoutPanel fprop)
        {
            FlowLayoutPanel multipnl = (FlowLayoutPanel)pnlSel;
            string[] real_dimensions = pnlSel.AccessibleDefaultActionDescription.Split('x');
            int wd = 0, ht = 0, div = 0,
                divWD = 0, divHT = 0,
                real_Pwidth = Convert.ToInt32(real_dimensions[0]),
                real_Pheight = Convert.ToInt32(real_dimensions[1]);
            string divtype = "",
                   copy_wndrtype = wndrtype;

            if (wndr == 26)
            {
                div = 10;
            }
            else if (wndr == 33)
            {
                div = 20;
            }

            if (multipnl.Name.Contains("Sliding"))
            {
                wndrCount = wndrtype.Length;

                if (multipnl.FlowDirection == FlowDirection.LeftToRight)
                {
                    wd = real_Pwidth / wndrCount;
                    ht = real_Pheight;

                }
                else if (multipnl.FlowDirection == FlowDirection.TopDown)
                {
                    wd = real_Pwidth;
                    ht = real_Pheight / wndrCount;

                }
            }
            else
            {
                if (multipnl.FlowDirection == FlowDirection.LeftToRight)
                {
                    wd = (real_Pwidth - (div * (wndrCount - 1))) / wndrCount;
                    ht = real_Pheight;

                    divWD = div;
                    divHT = real_Pheight;

                    divtype = "Transom";
                }
                else if (multipnl.FlowDirection == FlowDirection.TopDown)
                {
                    wd = real_Pwidth;
                    ht = (real_Pheight - (div * (wndrCount - 1))) / wndrCount;

                    divWD = real_Pwidth;
                    divHT = div;

                    divtype = "Mullion";
                }
            }


            var cpnl = csfunc.GetAll(flpMain, typeof(Panel), "Panel");

            for (int i = 0; i < wndrCount; i++)
            {
                cpnlcount++;
                Panel pnl = new Panel();
                
                if (multipnl.Name.Contains("Sliding"))
                {
                    string pattern_char = copy_wndrtype.Substring(i, 1),
                           windoortype = "";

                    if (pattern_char == "F")
                    {
                        windoortype = "Fixed";
                    }
                    else if (pattern_char == "S")
                    {
                        windoortype = "Sliding";
                    }

                    pnl = CreatePanels("Panel_" + cpnlcount,
                                        DockStyle.None,
                                        Convert.ToInt32(wd * zoom),
                                        Convert.ToInt32(ht * zoom),
                                        windoortype);

                    wndrtype = windoortype;
                }
                else
                {
                    pnl = CreatePanels("Panel_" + cpnlcount,
                                        DockStyle.None,
                                        Convert.ToInt32(wd * zoom),
                                        Convert.ToInt32(ht * zoom),
                                        wndrtype);
                }

                pnl.Tag = multipnl.Tag;
                pnl.TabIndex = cpnlcount;

                List<int> lstDimensions = new List<int>();

                lstDimensions.Add(wd);
                lstDimensions.Add(ht);

                if (dictPanelDimension.ContainsKey(cpnlcount))
                {
                    dictPanelDimension[cpnlcount] = lstDimensions;
                }
                else
                {
                    dictPanelDimension.Add(cpnlcount, lstDimensions);
                }

                CreateObjectClone("Panel",
                                  "Panel_",
                                  cpnlcount,
                                  wd,
                                  ht,
                                  multipnl.Tag,
                                  multipnl.GetType(),
                                  multipnl.Name,
                                  DockStyle.None);

                multipnl.Controls.Add(pnl);

                Panel Pprop = CreatePanelProperties(pnl.Name, cpnlcount, wd, ht, true, wndrtype);
                fprop.Controls.Add(Pprop);

                lstDragOrder.Add(pnl.Name);

                if (i != wndrCount - 1 && !multipnl.Name.Contains("Sliding"))
                {
                    Panel divMT = new Panel();
                    //pnl = new Panel();
                    divMT = CreateDiv(divtype + "_");
                    divMT.Size = new Size(Convert.ToInt32(divWD * zoom), Convert.ToInt32(divHT * zoom));
                    List<int> lstDivDimensions = new List<int>();

                    lstDivDimensions.Add(divWD);
                    lstDivDimensions.Add(divHT);

                    if (divtype == "Mullion")
                    {
                        mulcount++;

                        divMT.Name += mulcount;
                        if (dictMullionDimension.ContainsKey(mulcount))
                        {
                            dictMullionDimension[mulcount] = lstDivDimensions;
                        }
                        else
                        {
                            dictMullionDimension.Add(mulcount, lstDivDimensions);
                        }

                        divMT.TabIndex = mulcount;

                    }
                    else if (divtype == "Transom")
                    {
                        trnscount++;

                        divMT.Name += trnscount;
                        if (dictTransomDimension.ContainsKey(trnscount))
                        {
                            dictTransomDimension[trnscount] = lstDivDimensions;
                        }
                        else
                        {
                            dictTransomDimension.Add(trnscount, lstDivDimensions);
                        }

                        divMT.TabIndex = trnscount;

                    }

                    CreateObjectClone(divtype,
                                      divtype + "_" + i,
                                      divMT.TabIndex,
                                      divWD,
                                      divHT,
                                      multipnl.Tag,
                                      multipnl.GetType(),
                                      multipnl.Name,
                                      DockStyle.None);

                    multipnl.Controls.Add(divMT);
                    lstDragOrder.Add(divMT.Name);
                }
            }
        }

        private void AutoCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmSel = (ToolStripMenuItem)sender;
            int numdiv = Convert.ToInt32(pnlSel.AccessibleDescription),
                wndr = 0;

            var framecol = csfunc.GetAll(flpMain, typeof(Panel), pnlSel.Tag.ToString()); //pnl.Tag = FrameName
            foreach (var ctrl in framecol)
            {
                wndr = Convert.ToInt32(ctrl.Tag.ToString());
            }

            FlowLayoutPanel fprop = new FlowLayoutPanel();
            var fpropcol = csfunc.GetAll(pnlPropertiesBody, typeof(FlowLayoutPanel), pnlSel.Tag.ToString()); //pnl.Tag = FrameName
            foreach (FlowLayoutPanel ctrl in fpropcol)
            {
                fprop = ctrl;
            }

            AutoCreate(tsmSel.Text, numdiv + 1, wndr, fprop);
        }

        BackgroundWorker bgw = new BackgroundWorker();

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvControls.Rows.Add(Properties.Resources.SinglePanel, "Single Panel");
            dgvControls.Rows.Add(Properties.Resources.MultiplePanel_Mul, "Multiple Panel(1)");
            dgvControls.Rows.Add(Properties.Resources.Mullion, "Mullion");
            dgvControls.Rows.Add(Properties.Resources.Transom, "Transom");
            dgvControls.Rows[1].Cells[0].Tag = "Mullion";
            dgvControls.Rows[1].Cells[1].Tag = 1;
            dgvControls.ClearSelection();
            splitContainer1.SplitterDistance = 150;

            flpMain.Size = new Size(0, 0);
            pnlProperties.Size = new Size(185, 629);

            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.DoWork += Bgw_DoWork;

        }

        private void ToggleMode(bool visibility, bool enabled)
        {
            tsLbl_Loading.Visible = visibility;
            tsprogress_Loading.Visible = visibility;

            mnsMainMenu.Enabled = enabled;
            splitContainer1.Enabled = enabled;
            pnlRight.Enabled = enabled;
            stsEditor.Enabled = enabled;
            tsMain.Enabled = enabled;
        }

        private void StartWorker(string todo)
        {
            if (bgw.IsBusy != true)
            {
                bgw.RunWorkerAsync(todo);
                tsLbl_Loading.Text = "Initializing";
                ToggleMode(true,false);
            }
            else
            {
                MessageBox.Show(this,"Please Wait!", "Loading",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        string[] file_lines;
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (e.Argument.ToString())
                {
                    case "Open_WndrFiles":
                        for (int i = 0; i < file_lines.Length; i++)
                        {
                            if (bgw.CancellationPending == true)
                            {
                                e.Cancel = true;
                            }
                            else
                            {
                                bgw.ReportProgress(i, e.Argument.ToString());
                            }
                        }
                        e.Result = e.Argument.ToString();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                switch (e.UserState.ToString())
                {
                    case "Open_WndrFiles":
                        Opening_dotwndr(e.ProgressPercentage);

                        tsprogress_Loading.Value = e.ProgressPercentage;
                        if (tsLbl_Loading.Text != "Initializing...")
                        {
                            tsLbl_Loading.Text += ".";
                        }
                        else
                        {
                            tsLbl_Loading.Text = "Initializing";
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                csfunc.LogToFile(ex.Message, ex.StackTrace);
            }
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null || e.Cancelled == true)
                {
                    tsLbl_Loading.Text = "Error";
                    ToggleMode(false, true);
                    tsLbl_Loading.Visible = true;
                }
                else
                {
                    switch (e.Result.ToString())
                    {
                        case "Open_WndrFiles":
                            tsLbl_Loading.Text = "Finished";
                            ToggleMode(false,true);
                            tsLbl_Loading.Visible = true;

                            break;
                        default:
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool inside_item, inside_frame, inside_panel, inside_multi, inside_divider;
        int fpwidth, fpheight, //for Profile
            frwidth, frheight, frwndr,
            pnlwidth, pnlheight, //for Frame
            multi_Tabindex, //for Multipanel 
            divd_width, divd_height, divd_TabIndex; //for Divider
        string framename = "", fptype = "", 
               pnlwndrtype = "", pnl_Parent = "", pnl_Orientation = "", pnl_OrientationText = "",
               multi_type = "", multi_Parent = "", multi_Size = "", multi_Name = "", multidivnum = "",
               divd_name = "", divd_Parent = "";
        DockStyle dok, multidok;

        private void AddPanel()
        {
            string selected_wndr = "";
            bool orient = false, chkvisible = false, numBladeVisible = false;
            int blade_num = 2;

            if (pnlwndrtype.Contains("Fixed"))
            {
                selected_wndr = "Fixed";
            }
            else if (pnlwndrtype.Contains("Awning"))
            {
                selected_wndr = "Awning";
            }
            else if (pnlwndrtype.Contains("Casement"))
            {
                selected_wndr = "Casement";
            }
            else if (pnlwndrtype.Contains("Sliding"))
            {
                selected_wndr = "Sliding";
            }
            else if (pnlwndrtype.Contains("Tilt&Turn"))
            {
                selected_wndr = "Tilt&Turn";
            }
            else if (pnlwndrtype.Contains("Louver"))
            {
                selected_wndr = "Louver";
            }
            else if (pnlwndrtype.Contains("Concrete"))
            {
                selected_wndr = "Concrete";
            }

            if (pnlwndrtype.Contains("Louver") == false)
            {
                orient = Convert.ToBoolean(pnl_Orientation);
                chkvisible = true;
                numBladeVisible = false;
            }
            else
            {
                blade_num = Convert.ToInt32(pnl_Orientation);
                chkvisible = false;
                numBladeVisible = true;
            }
            cpnlcount++;

            Panel pnl = CreatePanels("Panel_", dok, pnlwidth, pnlheight, pnlwndrtype);
            pnl.Name += cpnlcount;
            pnl.Width = Convert.ToInt32(pnlwidth * zoom);
            pnl.Height = Convert.ToInt32(pnlheight * zoom);
            pnl.TabIndex = cpnlcount;

            List<int> lstDimensions = new List<int>();
            lstDimensions.Add(pnlwidth);
            lstDimensions.Add(pnlheight);
            dictPanelDimension[cpnlcount] = lstDimensions;

            Panel pnl2 = CreatePanels("Panel_", dok, pnlwidth, pnlheight, pnlwndrtype);
            pnl2.Name += cpnlcount;

            FlowLayoutPanel fprop = new FlowLayoutPanel();
            
            bool num_bool = false;

            if (pnl_Parent.Contains("pnl_inner"))
            {
                num_bool = false;
            }
            else
            {
                num_bool = true;
            }

            Panel Pprop = CreatePanelProperties(pnl.Name,
                                                cpnlcount,
                                                pnlwidth,
                                                pnlheight,
                                                num_bool,
                                                selected_wndr,
                                                blade_num,
                                                orient,
                                                pnl_OrientationText,
                                                chkvisible,
                                                numBladeVisible);

            var fpropcol = csfunc.GetAll(pnlPropertiesBody, typeof(FlowLayoutPanel), framename);
            foreach (FlowLayoutPanel ctrl in fpropcol)
            {
                fprop = ctrl;
            }
            fprop.Controls.Add(Pprop);

            var c = csfunc.GetAll(flpMain, pnl_Parent);
            foreach (Panel ctrl in c)
            {
                pnl.Tag = ctrl.Tag;
                ctrl.Controls.Add(pnl);
            }

            var c2 = csfunc.GetAll(flpMain2, pnl_Parent);
            foreach (Panel ctrl2 in c2)
            {
                ctrl2.Controls.Add(pnl2);
            }

            lstDragOrder.Add(pnl.Name);
        }

        private void AddMultiPanel()
        {
            multicount++;

            List<int> lstMultiPDimensions = new List<int>();

            string[] real_dimensions = multi_Size.Split('x');
            int real_Pwidth = Convert.ToInt32(real_dimensions[0]),
                real_Pheight = Convert.ToInt32(real_dimensions[1]);

            FlowLayoutPanel multi = CreateMultiPnl(multi_Name, multi_type, 0, multidivnum);
            multi.AccessibleDefaultActionDescription = multi_Size;
            multi.Dock = multidok;
            multi.Size = new Size(real_Pwidth, real_Pheight);
            multi.TabIndex = multi_Tabindex;

            FlowLayoutPanel multi2 = CreateMultiPnl(multi_Name, multi_type, 0, multidivnum);
            multi2.AccessibleDefaultActionDescription = multi_Size;
            multi2.Dock = multidok;
            multi2.Size = new Size(real_Pwidth, real_Pheight);
            multi2.TabIndex = multi_Tabindex;

            lstMultiPDimensions.Add(real_Pwidth);
            lstMultiPDimensions.Add(real_Pheight);

            var c = csfunc.GetAll(flpMain, multi_Parent);
            foreach (Panel ctrl in c)
            {
                multi.Tag = ctrl.Tag;
                ctrl.Controls.Add(multi);
            }

            var c2 = csfunc.GetAll(flpMain2, multi_Parent);
            foreach (Panel ctrl2 in c2)
            {
                ctrl2.Controls.Add(multi2);
            }

            if (dictMultiPanelDimension.ContainsKey(multi_Tabindex))
            {
                dictMultiPanelDimension[multi_Tabindex] = lstMultiPDimensions;
            }
            else
            {
                dictMultiPanelDimension.Add(multi_Tabindex, lstMultiPDimensions);
            }

            lstDragOrder.Add(multi.Name);

        }

        private void AddDivider()
        {
            Panel div = CreateDiv(divd_name);
            div.Size = new Size(divd_width, divd_height);
            div.TabIndex = divd_TabIndex;

            Panel div2 = CreateDiv(divd_name);
            div2.Size = new Size(divd_width, divd_height);
            div2.TabIndex = divd_TabIndex;

            List<int> lstDvdrDimensions = new List<int>();

            lstDvdrDimensions.Add(divd_width);
            lstDvdrDimensions.Add(divd_height);

            if (divd_name.Contains("Transom"))
            {
                trnscount++;
                dictTransomDimension.Add(trnscount, lstDvdrDimensions);
            }
            else if (divd_name.Contains("Mullion"))
            {
                mulcount++;
                dictMullionDimension.Add(mulcount, lstDvdrDimensions);
            }

            
            var c = csfunc.GetAll(flpMain, divd_Parent);
            foreach (Panel ctrl in c)
            {
                div.Tag = ctrl.Tag;
                ctrl.Controls.Add(div);
            }

            var c2 = csfunc.GetAll(flpMain2, divd_Parent);
            foreach (Panel ctrl2 in c2)
            {
                ctrl2.Controls.Add(div2);
            }

        }

        private void Opening_dotwndr(int row)
        {
            string row_str = file_lines[row];

            if (row == 0)
            {
                quotation_ref_no = Text = file_lines[0];
            }

            if (row_str == "(")
            {
                flpMain.Controls.Clear();
                flpMain2.Controls.Clear();
                pnlPropertiesBody.Controls.Clear();
                inside_item = flpMain.Visible = true;
            }
            else if (row_str.Contains("FrameName"))
            {
                inside_frame = true;
            }
            else if (row_str.Contains("PanelName"))
            {
                inside_panel = true;
            }
            else if (row_str.Contains("MultiName"))
            {
                inside_multi = true;
            }
            else if (row_str.Contains("DivdName"))
            {
                inside_divider = true;
            }
            else if (row_str.Contains("DivdName"))
            {
                inside_divider = true;
            }
            else if (row_str == "\t}")
            {
                if (inside_frame)
                {
                    frwidth = 0;
                    frheight = 0;
                    frwndr = 0;
                    inside_frame = false;
                }
                else if (inside_panel)
                {
                    pnlwidth = 0;
                    pnlheight = 0;
                    pnlwndrtype = "";
                    pnl_Orientation = "";
                    pnl_Parent = "";
                    framename = "";
                    inside_panel = false;
                }
                else if (inside_multi)
                {
                    multi_Name = "";
                    multi_Size = "";
                    multidivnum = "";
                    multi_Tabindex = 0;
                    multi_type = "";
                    multi_Parent = "";
                    inside_multi = false;
                }
                else if (inside_divider)
                {
                    divd_name = "";
                    divd_width = 0;
                    divd_height = 0;
                    divd_TabIndex = 0;
                    divd_Parent = "";
                    inside_divider = false;
                }
            }
            else if (row_str == ")")
            {
                //Panel_Painter();

                UppdateDictionaries();
                fpwidth = 0;
                fpheight = 0;
                fptype = "";
            }

            switch (inside_item)
            {
                case true:
                    if (row_str.Contains("Item"))
                    {
                        Text = quotation_ref_no + " >> " + row_str.Replace("_"," ");
                    }
                    else if (row_str.Contains("FWidth"))
                    {
                        fpwidth = Convert.ToInt32(row_str.Remove(0, 8));
                    }
                    else if (row_str.Contains("FHeight"))
                    {
                        fpheight = Convert.ToInt32(row_str.Remove(0, 9));
                    }
                    else if (row_str.Contains("FProfile"))
                    {
                        fptype = row_str.Remove(0,10);
                    }

                    if (fpwidth != 0 && fpheight != 0 && fptype != "")
                    {
                        AddProfile(fpwidth, fpheight, pnlItems.Controls.Count + 1, fptype);
                        inside_item = false;
                    }

                    break;
                case false:
                    if (inside_frame)
                    {
                        if (row_str.Contains("FrWidth"))
                        {
                            frwidth = Convert.ToInt32(row_str.Trim().Remove(0, 9));
                        }
                        else if (row_str.Contains("FrHeight"))
                        {
                            frheight = Convert.ToInt32(row_str.Trim().Remove(0, 10));
                        }
                        else if (row_str.Contains("FrWndr"))
                        {
                            frwndr = Convert.ToInt32(row_str.Trim().Remove(0, 8));
                        }

                        if (frwidth != 0 && frheight != 0 && frwndr != 0)
                        {
                            AddFrame(frwidth, frheight, frwndr);
                        }
                    }

                    else if (inside_panel)
                    {
                        if (row_str.Contains("DockStyle"))
                        {
                            switch (row_str.Trim().Remove(0, 11))
                            {
                                case "Fill":
                                    dok = DockStyle.Fill;
                                    break;
                                case "None":
                                    dok = DockStyle.None;
                                    break;
                            }
                        }
                        else if (row_str.Contains("PWidth"))
                        {
                            pnlwidth = Convert.ToInt32(row_str.Trim().Remove(0, 8));
                        }
                        else if (row_str.Contains("PHeight"))
                        {
                            pnlheight = Convert.ToInt32(row_str.Trim().Remove(0, 9));
                        }
                        else if (row_str.Contains("WndrType"))
                        {
                            pnlwndrtype = row_str.Trim().Remove(0, 10);
                        }
                        else if (row_str.Contains("Orientation"))
                        {
                            pnl_Orientation = row_str.Trim().Remove(0, 13);
                        }
                        else if (row_str.Contains("ChkText"))
                        {
                            pnl_OrientationText = row_str.Trim().Remove(0, 9);
                        }
                        else if (row_str.Contains("Parent"))
                        {
                            pnl_Parent = row_str.Trim().Remove(0, 8);
                        }
                        else if (row_str.Contains("FrameGroup"))
                        {
                            framename = row_str.Trim().Remove(0, 12);
                        }

                        if (pnlwidth != 0 &&
                            pnlheight != 0 &&
                            pnlwndrtype != "" &&
                            pnl_Orientation != "" &&
                            pnl_OrientationText != "" &&
                            pnl_Parent != "" &&
                            framename != "")
                        {
                            AddPanel();
                        }
                    }

                    else if (inside_multi)
                    {
                        if (row_str.Contains("DockStyle"))
                        {
                            switch (row_str.Trim().Remove(0, 11))
                            {
                                case "Fill":
                                    multidok = DockStyle.Fill;
                                    break;
                                case "None":
                                    multidok = DockStyle.None;
                                    break;
                            }
                        }
                        else if (row_str.Contains("MultiName"))
                        {
                            multi_Name = row_str.Trim().Remove(0, 11);
                        }
                        else if (row_str.Contains("DivSize"))
                        {
                            multi_Size = row_str.Trim().Remove(0, 9);
                        }
                        else if (row_str.Contains("DivTabIndex"))
                        {
                            multi_Tabindex = Convert.ToInt32(row_str.Trim().Remove(0, 13));
                        }
                        else if (row_str.Contains("DivType"))
                        {
                            multi_type = row_str.Trim().Remove(0, 9);
                        }
                        else if (row_str.Contains("DivNum"))
                        {
                            multidivnum = row_str.Trim().Remove(0, 8);
                        }
                        else if (row_str.Contains("Parent"))
                        {
                            multi_Parent = row_str.Trim().Remove(0, 8);
                        }

                        if (multi_Name != "" && 
                            multi_Size != "" &&
                            multidivnum != "" &&
                            multi_Tabindex != 0 &&
                            multi_type != "" &&
                            multi_Parent != "")
                        {
                            AddMultiPanel();
                        }
                    }

                    else if (inside_divider)
                    {
                        if (row_str.Contains("DivdName"))
                        {
                            divd_name = row_str.Trim().Remove(0, 10);
                        }
                        else if (row_str.Contains("DivdWidth"))
                        {
                            divd_width = Convert.ToInt32(row_str.Trim().Remove(0, 11));
                        }
                        else if (row_str.Contains("DivdHeight"))
                        {
                            divd_height = Convert.ToInt32(row_str.Trim().Remove(0, 12));
                        }
                        else if (row_str.Contains("DivdTabIndex"))
                        {
                            divd_TabIndex = Convert.ToInt32(row_str.Trim().Remove(0, 14));
                        }
                        else if (row_str.Contains("Parent"))
                        {
                            divd_Parent = row_str.Trim().Remove(0, 8);
                        }

                        if (divd_name != "" &&
                            divd_width != 0 &&
                            divd_height != 0 &&
                            divd_TabIndex != 0 &&
                            divd_Parent != "")
                        {
                            AddDivider();
                        }
                    }
                    break;
            }
        }

        private void Editors_SizeChanged(object sender, EventArgs e)
        {
            int cX, cY;
            cX = (pnlMain.Width - flpMain.Width) / 2;
            cY = (pnlMain.Height - flpMain.Height) / 2;

            if (cX <= 30 && cY <= 30)
            {
                flpMain.Location = new Point(60, 60);
            }
            else if (cX <= 30)
            {
                flpMain.Location = new Point(60, cY);
            }
            else if (cY <= 30)
            {
                flpMain.Location = new Point(cX, 60);
            }
            else
            {
                flpMain.Location = new Point(cX, cY);
            }
            if (trackzoom == false)
            {
                tsSize.Text = flpMain.Width.ToString() + " x " + flpMain.Height.ToString();
            }
            //flpMain2.Location = new Point(pnlMain.Width + 10,pnlMain.Height + 10);
            //flpMain2.Invalidate();

            pnlMain.Invalidate();
            flpMain.Invalidate();
        }

        IDictionary<int, List<int>> dictPanelDimension = new Dictionary<int, List<int>>();
        IDictionary<int, List<int>> dictMultiPanelDimension = new Dictionary<int, List<int>>();
        IDictionary<int, List<int>> dictMullionDimension = new Dictionary<int, List<int>>();
        IDictionary<int, List<int>> dictTransomDimension = new Dictionary<int, List<int>>();

        List<string> lstDragOrder = new List<string>();
        int cpnlcount = 0,
            mulcount = 0,
            trnscount = 0,
            multicount = 0;// cpnl.Count() + 1;
        private void pnl_inner_DragDrop(object sender, DragEventArgs e)
        {
            //var Multi = csfunc.GetAll(flpMain, typeof(FlowLayoutPanel), "Multi");
            //var cpnl = csfunc.GetAll(flpMain, typeof(Panel), "Panel");

            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control; //Control na babagsak
            Control pnl = (Control)sender; //Control na babagsakan
            if (c != null)
            {
                List<int> lstDimensions = new List<int>();
                List<int> lstMultiPDimensions = new List<int>();
                List<int> lstMullionDimensions = new List<int>();
                List<int> lstTransomDimensions = new List<int>();

                int wndr = 0, div = 0;
                FlowLayoutPanel fprop = new FlowLayoutPanel();
                var framecol = csfunc.GetAll(flpMain, typeof(Panel), pnl.Tag.ToString()); //pnl.Tag = FrameName
                foreach (var ctrl in framecol)
                {
                    wndr = Convert.ToInt32(ctrl.Tag.ToString());
                }

                var fpropcol = csfunc.GetAll(pnlPropertiesBody, typeof(FlowLayoutPanel), pnl.Tag.ToString()); //pnl.Tag = FrameName
                foreach (FlowLayoutPanel ctrl in fpropcol)
                {
                    fprop = ctrl;
                }

                if (c.Name.Contains("Mullion"))
                {
                    mulcount++;
                    //var mul = csfunc.GetAll(flpMain, typeof(Panel), "Mullion");

                    string[] real_dimensions = pnl.AccessibleDefaultActionDescription.Split('x');
                    int Pwidth = 0,
                        real_Pwidth = Convert.ToInt32(real_dimensions[0]),
                        real_Pheight = Convert.ToInt32(real_dimensions[1]);

                    c.Name += mulcount;
                    if (wndr == 26)
                    {
                        Pwidth = 10;
                        //c.Width = 10;
                    }
                    else if (wndr == 33)
                    {
                        Pwidth = 20;
                        //c.Width = 20;
                    }
                    c.Width = Convert.ToInt32(Pwidth * zoom);
                    c.Height = Convert.ToInt32(real_Pheight * zoom);
                    c.TabIndex = mulcount;

                    lstMullionDimensions.Add(Pwidth);
                    lstMullionDimensions.Add(real_Pheight);

                    if (dictMullionDimension.ContainsKey(mulcount))
                    {
                        dictMullionDimension[mulcount] = lstMullionDimensions;
                    }
                    else
                    {
                        dictMullionDimension.Add(mulcount, lstMullionDimensions);
                    }

                    pnl.Controls.Add(c);

                    CreateObjectClone("Mullion",
                                      "Mullion_",
                                      mulcount,
                                      Pwidth,
                                      real_Pheight,
                                      pnl.Tag,
                                      pnl.GetType(),
                                      pnl.Name,
                                      DockStyle.None);
                }
                else if (c.Name.Contains("Transom"))
                {
                    trnscount++;
                    //var transom = csfunc.GetAll(flpMain, typeof(Panel), "Transom");

                    string[] real_dimensions = pnl.AccessibleDefaultActionDescription.Split('x');
                    int Pheight = 0,
                        real_Pwidth = Convert.ToInt32(real_dimensions[0]),
                        real_Pheight = Convert.ToInt32(real_dimensions[1]);

                    c.Name += trnscount;
                    if (wndr == 26)
                    {
                        Pheight = 10;
                        //c.Height = 10;
                    }
                    else if (wndr == 33)
                    {
                        Pheight = 20;
                        //c.Height = 20;
                    }

                    c.Width = Convert.ToInt32(real_Pwidth * zoom);
                    c.Height = Convert.ToInt32(Pheight * zoom);
                    c.TabIndex = trnscount;

                    lstTransomDimensions.Add(real_Pwidth);
                    lstTransomDimensions.Add(Pheight);

                    if (dictTransomDimension.ContainsKey(trnscount))
                    {
                        dictTransomDimension[trnscount] = lstTransomDimensions;
                    }
                    else
                    {
                        dictTransomDimension.Add(trnscount, lstTransomDimensions);
                    }

                    pnl.Controls.Add(c);

                    CreateObjectClone("Transom",
                                      "Transom_",
                                      trnscount,
                                      real_Pwidth,
                                      Pheight,
                                      pnl.Tag,
                                      pnl.GetType(),
                                      pnl.Name,
                                      DockStyle.None);
                }
                else
                {
                    if (pnl.Name.Contains("Multi"))
                    {
                        frmDimensions frm = new frmDimensions();
                        FlowLayoutPanel fpnl = (FlowLayoutPanel)pnl;
                        int numdiv = Convert.ToInt32(fpnl.AccessibleDescription);
                        string multiPnl_Tag = fpnl.Tag.ToString();
                        string[] real_dimensions = pnl.AccessibleDefaultActionDescription.Split('x');
                        int Pwidth = 0, 
                            Pheight = 0,
                            real_Pwidth = Convert.ToInt32(real_dimensions[0]),
                            real_Pheight = Convert.ToInt32(real_dimensions[1]);

                        if (wndr == 26)
                        {
                            div = 10;
                        }
                        else if (wndr == 33)
                        {
                            div = 20;
                        }

                        if (pnl.Name.Contains("MultiSliding_"))
                        {
                                Pwidth = real_Pwidth / (numdiv + 1);
                                Pheight = real_Pheight;
                        }
                        else
                        {
                            if (fpnl.FlowDirection == FlowDirection.LeftToRight)
                            {
                                Pwidth = (real_Pwidth - (div * numdiv)) / (numdiv + 1);
                                Pheight = real_Pheight;

                            }
                            else if (fpnl.FlowDirection == FlowDirection.TopDown)
                            {
                                Pwidth = real_Pwidth;
                                Pheight = (real_Pheight - (div * numdiv)) / (numdiv + 1);
                            }
                        }
                        frm.numWidth.Value = Pwidth;
                        frm.numHeight.Value = Pheight;

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            Pwidth = Convert.ToInt32(frm.numWidth.Value);
                            Pheight = Convert.ToInt32(frm.numHeight.Value);

                            c.Dock = DockStyle.None;
                            c.Size = new Size(Convert.ToInt32(Pwidth * zoom), Convert.ToInt32(Pheight * zoom));
                            c.Tag = pnl.Tag;
                            if (c.Name.Contains("Panel"))
                            {
                                cpnlcount++;
                                c.Name += cpnlcount;
                                //c.Name += (cpnl.Count() + 1);
                                Panel Pprop = CreatePanelProperties(c.Name, cpnlcount, Pwidth,Pheight,true);
                                fprop.Controls.Add(Pprop);

                                c.TabIndex = cpnlcount;

                                lstDimensions.Add(Pwidth);
                                lstDimensions.Add(Pheight);

                                if (dictPanelDimension.ContainsKey(cpnlcount))
                                {
                                    dictPanelDimension[cpnlcount] = lstDimensions;
                                }
                                else
                                {
                                    dictPanelDimension.Add(cpnlcount, lstDimensions);
                                }

                                CreateObjectClone("Panel",
                                                  "Panel_",
                                                  cpnlcount,
                                                  Pwidth,
                                                  Pheight,
                                                  pnl.Tag,
                                                  pnl.GetType(),
                                                  pnl.Name,
                                                  DockStyle.None);

                            }
                            else if (c.Name.Contains("Multi"))
                            {
                                multicount++;
                                string multiName = c.Name;

                                c.Name += multicount;
                                c.AccessibleDefaultActionDescription = Pwidth + "x" + Pheight;
                                c.TabIndex = multicount;

                                lstMultiPDimensions.Add(Pwidth);
                                lstMultiPDimensions.Add(Pheight);

                                if (dictMultiPanelDimension.ContainsKey(multicount))
                                {
                                    dictMultiPanelDimension[multicount] = lstMultiPDimensions;
                                }
                                else
                                {
                                    dictMultiPanelDimension.Add(multicount, lstMultiPDimensions);
                                }

                                CreateObjectClone("MultiPanel",
                                                  multiName,
                                                  multicount,
                                                  Pwidth,
                                                  Pheight,
                                                  pnl.Tag,
                                                  pnl.GetType(),
                                                  pnl.Name,
                                                  DockStyle.None);
                            }
                            pnl.Controls.Add(c);
                        }
                    }
                    else
                    {
                        int id = pnl.Parent.TabIndex;

                        List<int> lstFrameDimension = new List<int>();
                        lstFrameDimension = dictFrameDimension[id];
                        int orig_wd = lstFrameDimension[0] - (wndr * 2),
                            orig_ht = lstFrameDimension[1] - (wndr * 2);

                        lstDimensions.Add(orig_wd);
                        lstDimensions.Add(orig_ht);

                        if (c.Name.Contains("Panel"))
                        {
                            cpnlcount++;
                            c.Name += cpnlcount;
                            Panel Pprop = CreatePanelProperties(c.Name, cpnlcount, orig_wd, orig_ht,false);
                            //Panel Pprop = CreatePanelProperties(c.Name, (cpnl.Count() + 1), c.Width, c.Height,false);
                            //Panel Pprop = CreatePanelProperties(c.Name, (cpnl.Count() + 1), pnl.Parent.Width, pnl.Parent.Height,false);
                            fprop.Controls.Add(Pprop);

                            c.Width = Convert.ToInt32(orig_wd * zoom);
                            c.Height = Convert.ToInt32(orig_ht * zoom);
                            c.TabIndex = cpnlcount;

                            if (dictPanelDimension.ContainsKey(cpnlcount))
                            {
                                dictPanelDimension[cpnlcount] = lstDimensions;
                            }
                            else
                            {
                                dictPanelDimension.Add(cpnlcount, lstDimensions);
                            }

                            CreateObjectClone("Panel",
                                              "Panel_",
                                              cpnlcount,
                                              orig_wd,
                                              orig_wd,
                                              pnl.Tag,
                                              pnl.GetType(),
                                              pnl.Name,
                                              DockStyle.Fill);

                        }
                        else if (c.Name.Contains("Multi"))
                        {
                            multicount++;
                            string multiName = c.Name;

                            c.Name += multicount;
                            c.AccessibleDefaultActionDescription = orig_wd + "x" + orig_ht;
                            c.TabIndex = multicount;

                            lstMultiPDimensions.Add(orig_wd);
                            lstMultiPDimensions.Add(orig_ht);

                            if (dictMultiPanelDimension.ContainsKey(multicount))
                            {
                                dictMultiPanelDimension[multicount] = lstMultiPDimensions;
                            }
                            else
                            {
                                dictMultiPanelDimension.Add(multicount, lstMultiPDimensions);
                            }

                            CreateObjectClone("MultiPanel",
                                              multiName,
                                              multicount,
                                              orig_wd,
                                              orig_wd,
                                              pnl.Tag,
                                              pnl.GetType(),
                                              pnl.Name,
                                              DockStyle.Fill);
                        }

                        c.Tag = pnl.Tag;
                        c.Dock = DockStyle.Fill;
                        pnl.Controls.Add(c);

                        trackzoom = false;
                        flpMain.Invalidate();
                        
                    }
                }
            }
            lstDragOrder.Add(c.Name);
            pnlPropertiesBody.VerticalScroll.Value = pnlPropertiesBody.VerticalScroll.Maximum;
            pnlPropertiesBody.PerformLayout();
        }
        
        private void CreateObjectClone(string objToClone,
                                       string name,
                                       int count,
                                       int pwd,
                                       int pht,
                                       object objTag, 
                                       Type pnlgettype,
                                       string pnlName,
                                       DockStyle docking)                                            
        {
            Control ctrl2 = new Control();
            if (objToClone == "Panel")
            {
                ctrl2 = CreatePanels(name);
                ctrl2.Tag = Tag;
                ctrl2.Name += count;
            }
            else if (objToClone == "MultiPanel")
            {
                ctrl2 = CreateMultiPnl(name, Convert.ToString(dgvControls.Rows[1].Cells[0].Tag), 0,
                                             Convert.ToString(dgvControls.Rows[1].Cells[1].Tag));
                ctrl2.AccessibleDefaultActionDescription = pwd + "x" + pht;
                ctrl2.Name += count;
                //ctrl2.Tag = Tag;
            }
            else if (objToClone == "Mullion" || objToClone == "Transom")
            {
                ctrl2 = CreateDiv(name);
                ctrl2.Tag = "Fixed";
            }
            ctrl2.Dock = docking;
            ctrl2.TabIndex = count;
            ctrl2.Size = new Size(pwd, pht);

            var col = csfunc.GetAll(flpMain2, pnlgettype, pnlName);
            foreach (var ctrl in col)
            {
                ctrl.Controls.Add(ctrl2);
            }

            flpMain2.Invalidate();
        }

        private void pnl_inner_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnlFrame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.ScaleTransform(zoom, zoom);

            Panel pfr = (Panel)sender;
            Panel pnl_inner = (Panel)pfr.Controls[0];

            g.SmoothingMode = SmoothingMode.AntiAlias;


            if (pfr.AccessibleDescription == "viewmodeOn")
            {
                Font dmnsion_font = new Font("Segoe UI", 12 * zoom);

                Size s = TextRenderer.MeasureText(pfr.Name, dmnsion_font);
                double mid = (pfr.Width) / 2;
                TextRenderer.DrawText(g,
                                      pfr.Name,
                                      dmnsion_font,
                                      new Point((int)(mid - (s.Width / 2)),1),
                                      Color.Blue);
            }
            
            int pInnerX = pnl_inner.Location.X,
            pInnerY = pnl_inner.Location.Y,
            pInnerWd = pnl_inner.Width,
            pInnerHt = pnl_inner.Height;

            Point[] corner_points = new[]
            {
            new Point(0,0),
            new Point(pInnerX,pInnerY),
            new Point(pfr.ClientRectangle.Width,0),
            new Point(pInnerX + pInnerWd,pInnerY),
            new Point(0,pfr.ClientRectangle.Height),
            new Point(pInnerX,pInnerY + pInnerHt),
            new Point(pfr.ClientRectangle.Width,pfr.ClientRectangle.Height),
            new Point(pInnerX + pInnerWd,pInnerY + pInnerHt)
            };

            for (int i = 0; i < corner_points.Length - 1; i += 2)
            {
                g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
            }

            string accname_col = pfr.AccessibleName;
            Color col = Color.Black;
            if (accname_col == "Black")
            {
                col = Color.Black;
            }
            else if (accname_col == "Blue")
            {
                col = Color.Blue;
            }

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                                   0,
                                                                   pfr.ClientRectangle.Width - w,
                                                                   pfr.ClientRectangle.Height - w));
        }

        private void dgvControls_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string ctrltype = dgvControls.Rows[e.RowIndex].Cells[1].Value.ToString();
                Control ctrl = new Control();
                if (ctrltype == "Single Panel")
                {
                    ctrl = CreatePanels("Panel_");
                }
                else if (ctrltype.Contains("Multiple Panel"))
                {
                    string ctrlTag = dgvControls.Rows[e.RowIndex].Cells[0].Tag.ToString();
                    if (ctrlTag == "MullionSliding")
                    {
                        ctrl = CreateMultiPnl("MultiSliding_", Convert.ToString(dgvControls.Rows[1].Cells[0].Tag), 0,
                                                               Convert.ToString(dgvControls.Rows[1].Cells[1].Tag));
                    }
                    else
                    {
                        ctrl = CreateMultiPnl("Multi_", Convert.ToString(dgvControls.Rows[1].Cells[0].Tag), 0,
                                                        Convert.ToString(dgvControls.Rows[1].Cells[1].Tag));
                    }
                }
                else if (ctrltype == "Mullion")
                {
                    ctrl = CreateDiv("Mullion_");
                }
                else if (ctrltype == "Transom")
                {
                    ctrl = CreateDiv("Transom_");
                }
                dgvControls.DoDragDrop(ctrl, DragDropEffects.Move);
            }
        }
        static Size GetThumbnailSize(Image original)
        {
            // Maximum size of any dimension.
            //const int maxPixels = 40;
            const int maxPixels = 200;

            // Width and height.
            int originalWidth = original.Width;
            int originalHeight = original.Height;

            // Compute best factor to scale entire image based on larger dimension.
            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)maxPixels / originalWidth;
            }
            else
            {
                factor = (double)maxPixels / originalHeight;
            }

            // Return thumbnail size.
            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }

        private void refreshToolStripButton1_Click(object sender, EventArgs e)
        {
            Panel_Painter();
        }
        
        private void tsSize_DoubleClick(object sender, EventArgs e)
        {
            if (Text.Contains("*") == false)
            {
                Text += "*";
            }

            frmDimensions frm = new frmDimensions();
            frm.numWidth.Value = static_wd;
            frm.numHeight.Value = static_ht;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                trkZoom.Value = 100;
                trackzoom = false;

                flpMain.Width = Convert.ToInt32(frm.numWidth.Value);
                flpMain.Height = Convert.ToInt32(frm.numHeight.Value);

                flpMain2.Width = Convert.ToInt32(frm.numWidth.Value);
                flpMain2.Height = Convert.ToInt32(frm.numHeight.Value);

                static_wd = flpMain.Width;
                static_ht = flpMain.Height;

                if (flpMain.Tag != null)
                {
                    string flptag = flpMain.Tag.ToString();
                    string lastnum = flptag.Substring(flptag.Length - 1);
                    Label lbl = new Label();
                    lbl = itemsLblSearch("lbldimension_" + lastnum);
                    lbl.Text = flpMain.Width.ToString() + " x " + flpMain.Height.ToString();

                    Label lblitm = new Label();
                    lblitm = itemsLblSearch("lbl_item" + lastnum);
                    lblitm.AccessibleDescription = flpMain.Width.ToString() + " x " + flpMain.Height.ToString();

                    flpMain.Invalidate();
                    flpMain2.Invalidate();
                    pnlMain.Invalidate();
                }
            }
        }

        private void flpMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   fpnl.ClientRectangle.Width - w,
                                                                   fpnl.ClientRectangle.Height - w));
            //THIS CODE IS TO SAVE IMAGE from PnlMain
            /*try
            {
                if (trackzoom == false)
                {
                    Bitmap bm = new Bitmap(flpMain.Size.Width, flpMain.Size.Height);
                    flpMain.DrawToBitmap(bm, new Rectangle(0, 0,
                                                           flpMain.Size.Width, flpMain.Size.Height));

                    if (flpMain.Tag != null)
                    {
                        var pbxcoll = csfunc.GetAll(pnlItems, typeof(PictureBox), flpMain.Tag.ToString());
                        foreach (PictureBox ctrl in pbxcoll)
                        {
                            ctrl.Image = bm;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }*/
        }

        private void flpMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsSize_DoubleClick(sender, e);
            /*frmDimensions frm = new frmDimensions();
            frm.numWidth.Value = flpMain.Width;
            frm.numHeight.Value = flpMain.Height;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                flpMain.Width = Convert.ToInt32(frm.numWidth.Value);
                flpMain.Height = Convert.ToInt32(frm.numHeight.Value);

                if (flpMain.Tag != null)
                {
                    string flptag = flpMain.Tag.ToString();
                    string lastnum = flptag.Substring(flptag.Length - 1);
                    Label lbl = new Label();
                    lbl = itemsLblSearch("lbldimension_" + lastnum);
                    lbl.Text = flpMain.Width.ToString() + " x " + flpMain.Height.ToString();

                    Label lblitm = new Label();
                    lblitm = itemsLblSearch("lbl_item" + lastnum);
                    lblitm.AccessibleDescription = flpMain.Width.ToString() + " x " + flpMain.Height.ToString();

                    flpMain.Invalidate();
                    pnlMain.Invalidate();
                }
            }*/
        }

        private void chkView_CheckedChanged(object sender, EventArgs e)
        {
            string accdesc = "";
            if (chkView.Checked == true)
            {
                accdesc = "viewmodeOn";
            }
            else
            {
                accdesc = "viewmodeOff";
            }

            var frcol = csfunc.GetAll(pnlPropertiesBody, typeof(FlowLayoutPanel), "Frame");
            foreach (Panel ctrl in frcol)
            {
                var frcol2 = csfunc.GetAll(flpMain, typeof(Panel), ctrl.Name);
                foreach (Panel ctrl2 in frcol2)
                {
                    ctrl2.AccessibleDescription = accdesc;
                    ctrl2.Invalidate();
                }
            }

            var pnlcol = csfunc.GetAll(pnlPropertiesBody, typeof(Panel), "Panel");
            foreach (Panel ctrl in pnlcol)
            {
                var pnlcol2 = csfunc.GetAll(flpMain, typeof(Panel), ctrl.Name);
                foreach (Panel ctrl2 in pnlcol2)
                {
                    ctrl2.TabStop = chkView.Checked;
                    ctrl2.Invalidate();
                }
            }
        }

        float zoom = 1f;
        int static_wd = 0, static_ht = 0;
        bool trackzoom;

        private void trkZoom_ValueChanged(object sender, EventArgs e)
        {
            trackzoom = true;

            zoom = trkZoom.Value / 100f;
            lblZoom.Text = trkZoom.Value.ToString() + " %";

            float wd = static_wd * zoom,
                  ht = static_ht * zoom;

            flpMain.Width = Convert.ToInt32(wd);
            flpMain.Height = Convert.ToInt32(ht);

            foreach (Panel pnl in flpMain.Controls)
            {
                int id = pnl.TabIndex;
                int wndr = Convert.ToInt32(pnl.Tag);

                List<int> lstDimensions = new List<int>();
                lstDimensions = dictFrameDimension[id];

                float fwd = lstDimensions[0] * zoom,
                      fht = lstDimensions[1] * zoom;

                pnl.Padding = new Padding(Convert.ToInt32(wndr * zoom));
                pnl.Size = new Size(Convert.ToInt32(fwd), Convert.ToInt32(fht));
            }

            var MultiCol = csfunc.GetAll(flpMain, typeof(FlowLayoutPanel), "Multi");
            foreach (FlowLayoutPanel multi in MultiCol)
            {
                int id = multi.TabIndex;
                List<int> lstDimensions = new List<int>();
                lstDimensions = dictMultiPanelDimension[id];

                float multiPwd = lstDimensions[0] * zoom,
                      multiPht = lstDimensions[1] * zoom;
                multi.Size = new Size(Convert.ToInt32(multiPwd), Convert.ToInt32(multiPht));
            }

            var MullionCol = csfunc.GetAll(flpMain, typeof(Panel), "Mullion_");
            foreach (Panel mul in MullionCol)
            {
                int id = mul.TabIndex;
                List<int> lstDimensions = new List<int>();
                lstDimensions = dictMullionDimension[id];

                float mulwd = lstDimensions[0] * zoom,
                      mulht = lstDimensions[1] * zoom;
                mul.Size = new Size(Convert.ToInt32(mulwd), Convert.ToInt32(mulht));
            }

            var TransomCol = csfunc.GetAll(flpMain, typeof(Panel), "Transom_");
            foreach (Panel trns in TransomCol)
            {
                int id = trns.TabIndex;
                List<int> lstDimensions = new List<int>();
                lstDimensions = dictTransomDimension[id];

                float trnswd = lstDimensions[0] * zoom,
                      trnsht = lstDimensions[1] * zoom;
                trns.Size = new Size(Convert.ToInt32(trnswd), Convert.ToInt32(trnsht));
            }

            var PanelCol = csfunc.GetAll(flpMain, typeof(Panel), "Panel_");
            foreach (Panel pnl in PanelCol)
            {
                int id = pnl.TabIndex;
                List<int> lstDimensions = new List<int>();
                lstDimensions = dictPanelDimension[id];

                float pnlwd = lstDimensions[0] * zoom,
                      pnlht = lstDimensions[1] * zoom;
                pnl.Size = new Size(Convert.ToInt32(pnlwd), Convert.ToInt32(pnlht));
            }
        }

        bool paint_pnlMain = false;

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            if (paint_pnlMain == true)
            {
                Graphics g = e.Graphics;
                //g.ScaleTransform(zoom, zoom);

                g.SmoothingMode = SmoothingMode.AntiAlias;

                int flp_X = flpMain.Location.X,
                    flp_Y = flpMain.Location.Y,
                    flp_Width = flpMain.Width,
                    flp_Height = flpMain.Height;

                //string dmnsion_w = flpMain.Width.ToString();
                string dmnsion_w = static_wd.ToString();
                Point dmnsion_w_startP = new Point(flp_X, flp_Y - 15);
                Point dmnsion_w_endP = new Point(flp_X + flp_Width, flp_Y - 15);
                Font dmnsion_font = new Font("Segoe UI", 12);

                Size s = TextRenderer.MeasureText(dmnsion_w, dmnsion_font);
                double mid = (dmnsion_w_startP.X + dmnsion_w_endP.X) / 2;

                //arrow for WIDTH
                Point[] arrwhd_pnts_W1 =
                {
                new Point(dmnsion_w_startP.X + 10,dmnsion_w_startP.Y - 10),
                dmnsion_w_startP,
                new Point(dmnsion_w_startP.X + 10,dmnsion_w_startP.Y + 10),
                };

                Point[] arrwhd_pnts_W2 =
                {
                new Point(dmnsion_w_endP.X - 10, dmnsion_w_endP.Y - 10),
                dmnsion_w_endP,
                new Point(dmnsion_w_endP.X - 10, dmnsion_w_endP.Y + 10)
                };

                g.DrawLines(Pens.Red, arrwhd_pnts_W1);
                g.DrawLine(Pens.Red, dmnsion_w_startP, dmnsion_w_endP);
                g.DrawLines(Pens.Red, arrwhd_pnts_W2);
                TextRenderer.DrawText(g,
                                      dmnsion_w,
                                      dmnsion_font,
                                      new Point((int)(mid - (s.Width / 2)),
                                      dmnsion_w_startP.Y - s.Height),
                                      Color.Black);
                //arrow for WIDTH


                //arrow for HEIGHT
                //string dmnsion_h = flpMain.Height.ToString();
                string dmnsion_h = static_ht.ToString();
                Point dmnsion_h_startP = new Point(flp_X - 15, flp_Y);
                Point dmnsion_h_endP = new Point(flp_X - 15, flp_Y + flp_Height);

                Size s2 = TextRenderer.MeasureText(dmnsion_h, dmnsion_font);
                double mid2 = (dmnsion_h_startP.Y + dmnsion_h_endP.Y) / 2;

                Point[] arrwhd_pnts_H1 =
                {
                new Point(dmnsion_h_startP.X - 10,dmnsion_h_startP.Y + 10),
                dmnsion_h_startP,
                new Point(dmnsion_h_startP.X + 10,dmnsion_h_startP.Y + 10),
                };

                Point[] arrwhd_pnts_H2 =
                {
                new Point(dmnsion_h_endP.X - 10, dmnsion_h_endP.Y - 10),
                dmnsion_h_endP,
                new Point(dmnsion_h_endP.X + 10, dmnsion_h_endP.Y - 10)
                };

                g.DrawLines(Pens.Red, arrwhd_pnts_H1);
                g.DrawLine(Pens.Red, dmnsion_h_startP, dmnsion_h_endP);
                g.DrawLines(Pens.Red, arrwhd_pnts_H2);
                TextRenderer.DrawText(g,
                                      dmnsion_h,
                                      dmnsion_font,
                                      new Point(dmnsion_h_startP.X - s2.Width, (int)(mid2 - (s2.Height / 2))),
                                      Color.Black);
                //arrow for HEIGHT
            }
        }
        
        private void AddProfile(int Fwidth,
                                int Fheight,
                                int pnl_cntr,
                                string profiletype)
        {
            trkZoom.Value = 100;
            trackzoom = false;

            paint_pnlMain = true;
            tsMain.Enabled = true;
            stsEditor.Enabled = true;
            btnAddZoom.Enabled = true;
            trkZoom.Enabled = true;
            btnSubtractZoom.Enabled = true;

            flpMain.AccessibleDescription = profiletype;
            flpMain.Size = new Size(Fwidth, Fheight);
            //flpMain2.Size = new Size(Fwidth, Fheight);


            if (Fwidth > 500 || Fheight > 500)
            {
                if (Fwidth > Fheight)
                {
                    if ((Fwidth - Fheight) > 100)
                    {
                        flpMain2.Size = new Size(700, 500);
                    }
                }
                else if (Fheight > Fwidth)
                {
                    if ((Fheight - Fwidth) > 100)
                    {
                        flpMain2.Size = new Size(500, 700);
                    }
                }
                else
                {
                    flpMain2.Size = new Size(500, 500);
                }
            }
            else
            {
                flpMain2.Size = new Size(Fwidth, Fheight);
            }


            static_wd = flpMain.Width;
            static_ht = flpMain.Height;

            flpMain.Visible = true;
            flpMain.Controls.Clear();
            flpMain2.Controls.Clear();
            pnlMain.Invalidate();

            Panel pnl = new Panel();
            pnl = CreateNewItem("Item", pnl_cntr, flpMain.Width + " x " + flpMain.Height, profiletype);
            pnlItems.Controls.Add(pnl);
            pnl.BringToFront();
            pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Maximum;
            pnlItems.PerformLayout();

            flpMain.Tag = "Item_" + pnl_cntr;
            flpMain2.Tag = "Item_" + pnl_cntr;

            lstDragOrder.Add(" >> Item_" + pnl_cntr);
            pnlPropertiesBody.Controls.Clear();

        }

        private void ProfileTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string profiletype = "";

            if (menu == C70ToolStripMenuItem)
            {
                profiletype = "C70 Profile";
            }
            else if (menu == PremiLineToolStripMenuItem)
            {
                profiletype = "PremiLine Profile";
            }

            bool save = false;

            int defwidth = 400,
                defheight = 400,
                pnl_cntr = pnlItems.Controls.Count + 1;//,
                //loc_framecntr = 0,
                //loc_cpnlcount = 0,
                //loc_mulcount = 0,
                //loc_trnscount = 0;

            frmDimensions frm = new frmDimensions();
            frm.numWidth.Value = defwidth;
            frm.numHeight.Value = defheight;

            if (Text.Contains("*") == true)
            {
                if (MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    save = true;
                }
            }
            else
            {
                save = true;
            }

            if (save == true)
            {
                UppdateDictionaries();
                Text = Text.Replace("*","");

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    defwidth = Convert.ToInt32(frm.numWidth.Value);
                    defheight = Convert.ToInt32(frm.numHeight.Value);

                    AddProfile(defwidth, defheight, pnl_cntr, profiletype);
                    Text = quotation_ref_no + " >> Item " + pnl_cntr + "*";
                }
            }
        }

        IDictionary<int, List<Panel>> itemslist = new Dictionary<int, List<Panel>>();
        IDictionary<int, List<Panel>> itemslist2 = new Dictionary<int, List<Panel>>();
        IDictionary<int, List<Panel>> propertieslist = new Dictionary<int, List<Panel>>();

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            UppdateDictionaries();
            Text = Text.Replace("*", "");
            if (wndrfile != "")
            {
                File.WriteAllLines(wndrfile, Saving_dotwndr());
            }
            MessageBox.Show("Saved");
        }
        
        private void frmMain2_TextChanged(object sender, EventArgs e)
        {
            if (Text.Contains("*"))
            {
                saveToolStripButton.Enabled = true;
            }
            else
            {
                saveToolStripButton.Enabled = false;
            }

            if (Text != "")
            {
                ItemToolStripMenuItem.Enabled = true;
            }
            else if (Text == "")
            {
                ItemToolStripMenuItem.Enabled = false;
            }

            if (Text.Contains(">>"))
            {
                saveAsToolStripMenuItem.Enabled = true;
                tsBtnNdoor.Enabled = true;
                tsBtnNwin.Enabled = true;
            }
            else
            {
                saveAsToolStripMenuItem.Enabled = false;
                tsBtnNdoor.Enabled = false;
                tsBtnNwin.Enabled = false;
            }
        }

        private void Panel_Painter()
        {
            Bitmap bm = new Bitmap(flpMain2.Size.Width, flpMain2.Size.Height);
            flpMain2.DrawToBitmap(bm, new Rectangle(0, 0, flpMain2.Size.Width, flpMain2.Size.Height));

            //Size thumbnailSize = GetThumbnailSize(bm);

            //// Get thumbnail.
            //Image thumbnail = bm.GetThumbnailImage(thumbnailSize.Width,
            //      thumbnailSize.Height, null, IntPtr.Zero);

            if (flpMain2.Tag != null)
            {
                var pbxcoll = csfunc.GetAll(pnlItems, typeof(PictureBox), flpMain2.Tag.ToString());
                foreach (PictureBox ctrl in pbxcoll)
                {
                    //ctrl.Image = thumbnail;
                    ctrl.Image = bm;
                }
            }
        }

        int wndrtype;

        private void flpMain2_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                //g.ScaleTransform(zoom, zoom);

                Panel pfr = (Panel)sender;
                //Panel pnl_inner = (Panel)pfr.Controls[0];

                g.SmoothingMode = SmoothingMode.AntiAlias;

                Color col = Color.Black;

                if (wndrtype != 0)
                {
                    //pfr.BackColor = SystemColors.Control;

                    int pInnerX = wndrtype,
                    pInnerY = wndrtype,
                    pInnerWd = pfr.Width - (wndrtype * 2),
                    pInnerHt = pfr.Height - (wndrtype * 2);

                    Point[] corner_points = new[]
                    {
                        new Point(0,0),
                        new Point(pInnerX,pInnerY),
                        new Point(pfr.ClientRectangle.Width,0),
                        new Point(pInnerX + pInnerWd,pInnerY),
                        new Point(0,pfr.ClientRectangle.Height),
                        new Point(pInnerX,pInnerY + pInnerHt),
                        new Point(pfr.ClientRectangle.Width,pfr.ClientRectangle.Height),
                        new Point(pInnerX + pInnerWd,pInnerY + pInnerHt)
                    };

                    for (int i = 0; i < corner_points.Length - 1; i += 2)
                    {
                        g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
                    }

                    string accname_col = pfr.AccessibleName;

                    int wd = 1;
                    int wd2 = Convert.ToInt32(Math.Floor(wd / (double)2));
                    g.DrawRectangle(new Pen(col, wd), new Rectangle(wndrtype,
                                                                    wndrtype,
                                                                    (pfr.ClientRectangle.Width - (wndrtype * 2)) - wd,
                                                                    (pfr.ClientRectangle.Height - (wndrtype * 2)) - wd));
                }
                else
                {
                    //pfr.BackColor = Color.DarkGray;
                    int cond = pfr.Width + pfr.Height;

                    for (int i = 10; i < cond; i += 10)
                    {
                        g.DrawLine(Pens.Black, new Point(0, i), new Point(i, 0));
                    }
                }


                int w = 1;
                int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
                g.DrawRectangle(new Pen(col, w), new Rectangle(0,
                                                               0,
                                                               pfr.ClientRectangle.Width - w,
                                                               pfr.ClientRectangle.Height - w));

                Panel_Painter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void autoSlidingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAutoCreateSliding frm = new frmAutoCreateSliding();
            frm.txtPnlNo.Text =  (Convert.ToInt32(pnlSel.AccessibleDescription) + 1).ToString();

            FlowLayoutPanel fprop = new FlowLayoutPanel();
            var fpropcol = csfunc.GetAll(pnlPropertiesBody, typeof(FlowLayoutPanel), pnlSel.Tag.ToString()); //pnl.Tag = FrameName
            foreach (FlowLayoutPanel ctrl in fpropcol)
            {
                fprop = ctrl;
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                AutoCreate(frm.txtPattern.Text, 0, 0, fprop);
            }
        }

        private List<string> Saving_dotwndr()
        {
            List<string> wndr_content = new List<string>();

            wndr_content.Add(quotation_ref_no);
            bool inside_item = false;

            for (int i = 0; i < lstDragOrder.Count; i++)
            {
                string curr_item = lstDragOrder[i];
                if (inside_item)
                {
                    if (curr_item.Contains("Frame"))
                    {
                        string frame_tag = "";
                        foreach (KeyValuePair<int, List<Panel>> items in itemslist)
                        {
                            foreach (Panel frame in items.Value)
                            {
                                if (frame.Name == lstDragOrder[i])
                                {
                                    frame_tag = frame.Tag.ToString();
                                }
                            }
                        }

                        int frame_id = Convert.ToInt32(curr_item.Replace("Frame_", ""));

                        wndr_content.Add("\t{");
                        wndr_content.Add("\tFrameName: " + curr_item); //Frames
                        wndr_content.Add("\tFrWidth: " + dictFrameDimension[frame_id][0]);
                        wndr_content.Add("\tFrHeight: " + dictFrameDimension[frame_id][1]);
                        wndr_content.Add("\tFrWndr: " + frame_tag);
                        wndr_content.Add("\t}");

                    }
                    else if (curr_item.Contains("Panel"))
                    {
                        foreach (KeyValuePair<int, List<Panel>> items in itemslist)
                        {
                            foreach (Panel frame in items.Value)
                            {
                                var c = csfunc.GetAll(frame, typeof(Panel), lstDragOrder[i]);
                                foreach (Panel ctrl in c)
                                {
                                    if (lstDragOrder[i] == ctrl.Name)
                                    {
                                        string pnl_id = ctrl.Name.Replace("Panel_", ""), 
                                               Orientation = "",
                                               chktxt = "Louver";

                                        foreach (KeyValuePair<int, List<Panel>> prop in propertieslist)
                                        {
                                            foreach (Panel property in prop.Value)
                                            {
                                                var chk_col = csfunc.GetAll(property, typeof(CheckBox), "chkWdrOrientation_" + pnl_id);
                                                foreach (CheckBox chk in chk_col)
                                                {
                                                    if (chk.Visible == true)
                                                    {
                                                        Orientation = chk.Checked.ToString();
                                                        chktxt = chk.Text;
                                                    }
                                                }

                                                var num_col = csfunc.GetAll(property, typeof(NumericUpDown), "numBladeCount_" + pnl_id);
                                                foreach (NumericUpDown num in num_col)
                                                {
                                                    if (num.Visible == true)
                                                    {
                                                        Orientation = num.Value.ToString();
                                                    }
                                                }
                                            }
                                        }

                                        wndr_content.Add("\t{");
                                        wndr_content.Add("\tPanelName: " + ctrl.Name);//Panels
                                        wndr_content.Add("\tDockStyle: " + ctrl.Dock.ToString());
                                        wndr_content.Add("\tPWidth: " + dictPanelDimension[ Convert.ToInt32(pnl_id)][0]);
                                        wndr_content.Add("\tPHeight: " + dictPanelDimension[Convert.ToInt32(pnl_id)][1]);
                                        wndr_content.Add("\tWndrType: " + ctrl.AccessibleDescription);
                                        wndr_content.Add("\tOrientation: " + Orientation);
                                        wndr_content.Add("\tChkText: " + chktxt);
                                        wndr_content.Add("\tParent: " + ctrl.Parent.Name);
                                        wndr_content.Add("\tFrameGroup: " + ctrl.Parent.Tag);
                                        wndr_content.Add("\t}");
                                    }
                                }
                            }
                        }
                    }
                    else if (curr_item.Contains("Multi"))
                    {
                        foreach (KeyValuePair<int, List<Panel>> items in itemslist)
                        {
                            foreach (Panel frame in items.Value)
                            {
                                var c = csfunc.GetAll(frame, typeof(FlowLayoutPanel), lstDragOrder[i]);
                                foreach (FlowLayoutPanel ctrl in c)
                                {
                                    if (lstDragOrder[i] == ctrl.Name)
                                    {
                                        string div = "";
                                        if (ctrl.FlowDirection == FlowDirection.LeftToRight)
                                        {
                                            div = "Mullion";
                                        }
                                        else if (ctrl.FlowDirection == FlowDirection.TopDown)
                                        {
                                            div = "Transom";
                                        }
                                        
                                        //int 

                                        //dictMultiPanelDimension[]

                                        wndr_content.Add("\t{");
                                        wndr_content.Add("\tMultiName: " + ctrl.Name); //Multipanel
                                        wndr_content.Add("\tDockStyle: " + ctrl.Dock.ToString());
                                        wndr_content.Add("\tDivSize: " + ctrl.AccessibleDefaultActionDescription);
                                        wndr_content.Add("\tDivType: " + div);
                                        wndr_content.Add("\tDivTabIndex: " + ctrl.TabIndex);
                                        wndr_content.Add("\tDivTag: " + ctrl.Tag);
                                        wndr_content.Add("\tDivNum: " + ctrl.AccessibleDescription);
                                        wndr_content.Add("\tParent: " + ctrl.Parent.Name);
                                        //wndr_content.Add("\tFrameGroup: " + ctrl.Parent.Tag);
                                        wndr_content.Add("\t}");
                                    }
                                }
                            }
                        }
                    }
                    else if (curr_item.Contains("Transom") || curr_item.Contains("Mullion"))
                    {
                        foreach (KeyValuePair<int, List<Panel>> items in itemslist)
                        {
                            foreach (Panel frame in items.Value)
                            {
                                var c = csfunc.GetAll(frame, typeof(Panel), lstDragOrder[i]);
                                foreach (Panel ctrl in c)
                                {
                                    if (lstDragOrder[i] == ctrl.Name)
                                    {
                                        int wd = 0, ht = 0;

                                        if (ctrl.Name.Contains("Mullion"))
                                        {
                                            wd = dictMullionDimension[ctrl.TabIndex][0];
                                            ht = dictMullionDimension[ctrl.TabIndex][1];
                                        }
                                        else if (ctrl.Name.Contains("Transom"))
                                        {
                                            wd = dictTransomDimension[ctrl.TabIndex][0];
                                            ht = dictTransomDimension[ctrl.TabIndex][1];
                                        }

                                        wndr_content.Add("\t{");
                                        wndr_content.Add("\tDivdName: " + ctrl.Name); //Transom & Mullion
                                        wndr_content.Add("\tDivdWidth: " + wd);
                                        wndr_content.Add("\tDivdHeight: " + ht);
                                        wndr_content.Add("\tDivdTabIndex: " + ctrl.TabIndex);
                                        wndr_content.Add("\tParent: " + ctrl.Parent.Name);
                                        wndr_content.Add("\t}");
                                    }
                                }
                            }
                        }
                    }
                }

                if (curr_item.Contains(">>"))
                {
                    if (inside_item)
                    {
                        wndr_content.Add(")");

                    }
                    else
                    {
                        inside_item = true;
                    }

                    string itemname = lstDragOrder[i].Replace(" >> ", "");
                    var c = csfunc.GetAll(pnlItems, typeof(Panel), itemname);
                    foreach (Panel ctrl in c)
                    {
                        if (itemname == ctrl.Name)
                        {
                            string WxH = ctrl.AccessibleDefaultActionDescription.Replace(" ", "");
                            string[] dimension = WxH.Split('x');

                            wndr_content.Add("(");
                            wndr_content.Add(ctrl.Name);
                            wndr_content.Add("FWidth: " + dimension[0]);
                            wndr_content.Add("FHeight: " + dimension[1]);
                            wndr_content.Add("FProfile: " + ctrl.AccessibleDescription);
                        }
                    }

                }
                else if (i == lstDragOrder.Count - 1)
                {
                    wndr_content.Add(")");
                    inside_item = false;
                }
            }

            return wndr_content;
        }

        string wndrfile = "";
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = quotation_ref_no;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                wndrfile = saveFileDialog1.FileName;
                File.WriteAllLines(saveFileDialog1.FileName, Saving_dotwndr());
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dictFrameDimension.Clear();
                dictPanelDimension.Clear();
                dictMultiPanelDimension.Clear();
                dictMullionDimension.Clear();
                dictTransomDimension.Clear();
                itemslist.Clear();
                itemslist2.Clear();
                propertieslist.Clear();

                flpMain.Controls.Clear();
                flpMain2.Controls.Clear();
                pnlPropertiesBody.Controls.Clear();
                pnlItems.Controls.Clear();

                cpnlcount = mulcount = trnscount = multicount = framecntr = 0;

                wndrfile = openFileDialog1.FileName;

                file_lines = File.ReadAllLines(openFileDialog1.FileName);
                tsprogress_Loading.Maximum = file_lines.Length;

                lstDragOrder.Clear();
                StartWorker("Open_WndrFiles");
            }
        }

        string quotation_ref_no;
        private void QuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Quotation Reference No.", "Windoor Maker", "");
            if (input != "" && input != "0")
            {
                quotation_ref_no = input.ToUpper();
                Text = quotation_ref_no;
            }
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == btnAddZoom)
            {
                if (trkZoom.Value < trkZoom.Maximum)
                {
                    trkZoom.Value += 10;
                }
            }
            else if (btn == btnSubtractZoom)
            {
                int trkval = trkZoom.Value;
                trkval -= 10;
                if (trkval > trkZoom.Minimum)
                {
                    trkZoom.Value = trkval;
                }
                else
                {
                    trkZoom.Value = trkZoom.Minimum;
                }
            }
        }

        private void dgvControls_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex == 1)
            {
                cmenuMultiP.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void tsmMultiP_Clicked(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
            if (tsm == MullionNonSlidingToolStripMenuItem)
            {
                dgvControls.Rows[1].Cells[0].Value = Properties.Resources.MultiplePanel_Mul;
                dgvControls.Rows[1].Cells[0].Tag = "Mullion";
            }
            else if (tsm == MullionSlidingToolStripMenuItem)
            {
                dgvControls.Rows[1].Cells[0].Value = Properties.Resources.MultiplePanelSliding;
                dgvControls.Rows[1].Cells[0].Tag = "MullionSliding";
            }
            else if (tsm == transomToolStripMenuItem)
            {
                dgvControls.Rows[1].Cells[0].Value = Properties.Resources.MultiplePanel_Trans;
                dgvControls.Rows[1].Cells[0].Tag = "Transom";
            }
            else if (tsm == divCountToolStripMenuItem)
            {
                string input = Interaction.InputBox("Input no. of division", "WinDoor Maker", "1");
                if (input != "" && input != "0")
                {
                    dgvControls.Rows[1].Cells[1].Tag = input;
                    dgvControls.Rows[1].Cells[1].Value = "Multiple Panel(" + input + ")";
                }
            }
        }

        IDictionary<int, List<int>> dictFrameDimension = new Dictionary<int, List<int>>();
        int framecntr = 0;

        private void AddFrame(int fwidth,
                              int fheight,
                              int fwndr)
        {
            framecntr++;
            //Panel frame2 = CreateFrame("Frame", fwidth, fheight, fwndr, framecntr);
            //flpMain2.Controls.Add(frame2);
            //flpMain2.Invalidate();

            Panel frame = CreateFrame("Frame", fwidth, fheight, fwndr, framecntr);
            frame.Padding = new Padding(Convert.ToInt32(fwndr * zoom));
            frame.Size = new Size(Convert.ToInt32(fwidth * zoom), Convert.ToInt32(fheight * zoom));
            lstDragOrder.Add(frame.Name);

            flpMain.Controls.Add(frame);
            trackzoom = false;
            flpMain.Invalidate();

            FlowLayoutPanel prop = CreateFrameProperties("Frame",
                                                         framecntr,
                                                         fwidth,
                                                         fheight,
                                                         fwndr);
            pnlPropertiesBody.Controls.Add(prop);
            prop.BringToFront();

            List<int> lstDimensions = new List<int>();
            lstDimensions.Add(fwidth);
            lstDimensions.Add(fheight);

            if (dictFrameDimension.ContainsKey(framecntr))
            {
                dictFrameDimension[framecntr] = lstDimensions;
            }
            else
            {
                dictFrameDimension.Add(framecntr, lstDimensions);
            }
        }

        private void tsBtnNewWindoor(object sender, EventArgs e)
        {
            int defwidth = static_wd,
                defheight = static_ht,
                defwndr = 0; //if window 52/2 = 26; elseif door 67/2 = 33
                //flp_cntr = flpMain.Controls.Count + 1;

            frmDimensions frm = new frmDimensions();
            frm.numWidth.Value = defwidth;
            frm.numHeight.Value = defheight;

            if (sender == tsBtnNwin)
            {
                frm.Text = "Window dimension";
                defwndr = 26;
            }
            else if (sender == tsBtnNdoor)
            {
                frm.Text = "Door dimension";
                defwndr = 33;
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                defwidth = Convert.ToInt32(frm.numWidth.Value);
                defheight = Convert.ToInt32(frm.numHeight.Value);

                AddFrame(defwidth, defheight, defwndr);

                wndrtype = defwndr;
                flpMain2.Invalidate();
            }
        }

        private void frmMain2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var c = csfunc.GetAll(flpMain, pnltypeSel, pnlnameSel);
                foreach (var ctrl in c)
                {
                    ctrl.AccessibleName = "Black";
                    ctrl.Invalidate();
                }
                pnlSel = null;
                pnltypeSel = null;
                pnlnameSel = null;
                pnlSel_parent = null;
            }
            else if (e.Control && e.KeyCode == Keys.W)
            {
                if (tsBtnNwin.Enabled == true)
                {
                    tsBtnNwin.PerformClick();
                }
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                if (tsBtnNdoor.Enabled == true)
                {
                    tsBtnNdoor.PerformClick();
                }
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                
                if (saveToolStripButton.Enabled == true)
                {
                    saveToolStripButton.PerformClick();
                }
            }
            else if (e.Alt && e.Shift && e.KeyCode == Keys.S)
            {
                if (saveAsToolStripMenuItem.Enabled == true)
                {
                    saveAsToolStripMenuItem.PerformClick();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnlSel.Name.Contains("Frame"))
            {
                var c = csfunc.GetAll(pnlPropertiesBody, typeof(FlowLayoutPanel), pnlSel.Name);
                foreach (var ctrl in c)
                {
                    pnlPropertiesBody.Controls.Remove(ctrl);
                }

                var c2 = csfunc.GetAll(flpMain2, typeof(Panel), pnlSel.Name);
                foreach (var ctrl in c2)
                {
                    flpMain2.Controls.Remove(ctrl);
                }

                var c3 = csfunc.GetAll(pnlSel, typeof(Panel)); //Gets all the Panels inside Frame
                foreach (var pnl in c3)
                {
                    if (lstDragOrder.Contains(pnl.Name)) //Searching for matches 
                    {
                        lstDragOrder.Remove(pnl.Name); //Removes into lstDragOrder
                    }
                }
                
                var c4 = csfunc.GetAll(pnlSel, typeof(FlowLayoutPanel)); //Gets all the MultiPanels inside Frame
                foreach (var flp in c4)
                {
                    if (lstDragOrder.Contains(flp.Name))
                    {
                        lstDragOrder.Remove(flp.Name);
                    }
                }
            }
            else if (pnlSel.Name.Contains("Panel"))
            {
                FlowLayoutPanel fprop = new FlowLayoutPanel();
                var flpcol = csfunc.GetAll(pnlPropertiesBody, typeof(FlowLayoutPanel), pnlSel.Tag.ToString());
                foreach (FlowLayoutPanel ctrl in flpcol)
                {
                    fprop = ctrl;
                }

                Panel pprop = new Panel();
                var pnlcol = csfunc.GetAll(pnlPropertiesBody, typeof(Panel), pnlSel.Name);
                foreach (Panel ctrl in pnlcol)
                {
                    pprop = ctrl;
                }

                fprop.Controls.Remove(pprop);

                var c2 = csfunc.GetAll(flpMain2, typeof(Panel), pnlSel.Name);
                foreach (var ctrl in c2)
                {
                    ctrl.Parent.Controls.Remove(ctrl);
                }

            }
            else if (pnlSel.Name.Contains("Multi"))
            {
                var pnlcol1 = csfunc.GetAll(pnlSel, typeof(Panel), "Panel");
                foreach (Panel ctrl1 in pnlcol1)
                {
                    lstDragOrder.Remove(ctrl1.Name);

                    FlowLayoutPanel fprop = new FlowLayoutPanel();
                    var flpcol = csfunc.GetAll(pnlPropertiesBody, typeof(FlowLayoutPanel), ctrl1.Tag.ToString());
                    foreach (FlowLayoutPanel ctrl2 in flpcol)
                    {
                        fprop = ctrl2;
                    }

                    Panel pprop = new Panel();
                    var pnlcol = csfunc.GetAll(pnlPropertiesBody, typeof(Panel), ctrl1.Name);
                    foreach (Panel ctrl3 in pnlcol)
                    {
                        pprop = ctrl3;
                    }

                    fprop.Controls.Remove(pprop);
                }

                var c2 = csfunc.GetAll(flpMain2, typeof(FlowLayoutPanel), pnlSel.Name);
                foreach (var ctrl in c2)
                {
                    ctrl.Parent.Controls.Remove(ctrl);
                }
            }
            else
            {
                var c2 = csfunc.GetAll(flpMain2, typeof(Panel), pnlSel.Name);
                foreach (var ctrl in c2)
                {
                    ctrl.Parent.Controls.Remove(ctrl);
                }
            }
            lstDragOrder.Remove(pnlSel.Name);

            pnlSel_parent.Controls.Remove(pnlSel);
            pnlSel_parent.Invalidate();

            trackzoom = false;
            flpMain.Invalidate();
            flpMain2.Invalidate();
        }

    }
}