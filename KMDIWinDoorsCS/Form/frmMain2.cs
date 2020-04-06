﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
                                   int Pheight = 0)
        {
            Panel cr8newpnl = new Panel();
            cr8newpnl.Name = name;
            cr8newpnl.AllowDrop = false;
            cr8newpnl.AccessibleDescription = "";
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

            if (e.Button == MouseButtons.Right)
            {
                cmenuPanel.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void pnl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(zoom, zoom);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Panel pnl = (Panel)sender;
            Panel pnlParent = (Panel)pnl.Parent;
            int fpnl_sashW = pnl.Width - 20,
                fpnl_sashH = pnl.Height - 20;

            Point sashPoint = new Point(pnl.ClientRectangle.X + 8, pnl.ClientRectangle.Y + 8);

            if (pnl.TabStop == true)
            {
                Font dmnsion_font = new Font("Segoe UI", 12);

                Size s = TextRenderer.MeasureText(pnl.Name, dmnsion_font);
                double mid = (pnl.Width) / 2;
                TextRenderer.DrawText(g,
                                      pnl.Name,
                                      dmnsion_font,
                                      new Point(sashPoint.X + 3, sashPoint.Y + 3),
                                      Color.Blue);
            }

            string windowtype = pnl.AccessibleDescription;
            Rectangle sashRect = new Rectangle(sashPoint,
                                               new Size(fpnl_sashW, fpnl_sashH));

            if (windowtype.Contains("Fixed"))
            {
                if (windowtype == "FixeddSash")
                {
                    g.DrawRectangle(blkPen, sashRect);
                }
                Font drawFont = new Font("Segoe UI", 12);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), pnl.ClientRectangle, drawFormat);
            }
            else
            {
                Pen dgrayPen = new Pen(Color.DimGray);
                    dgrayPen.DashStyle = DashStyle.Dash;
                    dgrayPen.Width = 3;
                g.DrawRectangle(blkPen, sashRect);

                if (windowtype == "CasementR")
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                         new Point(sashPoint.X + fpnl_sashW, (sashPoint.Y + (fpnl_sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + fpnl_sashW, (sashPoint.Y + (fpnl_sashH / 2))),
                                         new Point(sashPoint.X, fpnl_sashH + sashPoint.Y));
                }
                else if (windowtype == "CasementL")
                {
                    g.DrawLine(dgrayPen, new Point(sashPoint.X + fpnl_sashW, sashPoint.Y),
                                         new Point(sashPoint.X, (sashPoint.Y + (fpnl_sashH / 2))));
                    g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (fpnl_sashH / 2))),
                                         new Point(sashPoint.X + fpnl_sashW, fpnl_sashH + sashPoint.Y));
                }
                else if (windowtype == "AwningNorm")
                {
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
            pnl_inner.Tag = frame.Name;
            pnl_inner.DragDrop += new DragEventHandler(pnl_inner_DragDrop);
            pnl_inner.DragOver += new DragEventHandler(pnl_inner_DragOver);
            pnl_inner.Paint += new PaintEventHandler(border_paint);

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
            multi.Dock = DockStyle.Fill;
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

            Font drawFont = new Font("Segoe UI", 12);
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

        private Panel CreateDiv(string name,
                                string divtype)
        {
            Panel div = new Panel();
            div.Name = name;
            div.BackColor = Color.CadetBlue;
            div.Margin = new Padding(0);
            div.Padding = new Padding(0);
            div.Tag = "Fixed";
            div.Cursor = Cursors.Hand;
            div.Paint += new PaintEventHandler(border_paint);
            div.MouseClick += new MouseEventHandler(pnl_MouseClick);

            return div;
        }

        private void border_paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Graphics g = e.Graphics;

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

        public void rd_CheckChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            int wndr_padd = 0;
            Panel pnl = new Panel();

            if (rd.Checked == true)
            {
                if (rd.Name.Contains("rdWindow_"))
                {
                    wndr_padd = 26;
                }
                else if (rd.Name.Contains("rdDoor_"))
                {
                    wndr_padd = 33;
                }

                Panel frame = new Panel();
                var c = csfunc.GetAll(flpMain, typeof(Panel), rd.Tag.ToString());//Searching for Frame
                foreach (Panel ctrl in c)
                {
                    ctrl.Padding = new Padding(wndr_padd);
                    ctrl.Tag = wndr_padd;
                    ctrl.Invalidate();
                    frame = ctrl;
                }

                var pnlcol = csfunc.GetAll(frame, typeof(Panel), "Panel");
                foreach (Panel ctrl in pnlcol)
                {
                    pnl = ctrl;
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
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            string frameName = num.Parent.Name;
            Panel snglPnl = new Panel();

            var c = csfunc.GetAll(flpMain, typeof(Panel), frameName); // Searching for Frame
            foreach (var ctrl in c)
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
                            ctrl.Value = snglPnl.Width;
                        }
                    }
                    else if (num.Name.Contains("numfHeight_"))
                    {
                        if (ctrl.Name.Contains("Height"))
                        {
                            ctrl.Value = snglPnl.Height;
                        }
                    }
                }
            }
        }

        private Panel CreatePanelProperties(string name,
                                            int count,
                                            int Pwidth,
                                            int Pheight,
                                            bool num_bool)
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
            cbx.Location = new Point(7, 50);
            cbx.SelectedIndexChanged += new EventHandler(cbx_SelectedIndexChanged);
            Pprop.Controls.Add(cbx);

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
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            Pprop.Controls.Add(chk);

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

        private void Pnum_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown pnum = (NumericUpDown)sender;
            Panel pnl = new Panel();
            var c = csfunc.GetAll(flpMain, typeof(Panel), pnum.Parent.Name);
            foreach (Panel ctrl in c)
            {
                pnl = ctrl;
            }

            if (pnum.Name.Contains("Width"))
            {
                pnl.Width = Convert.ToInt32(pnum.Value);
            }
            else if (pnum.Name.Contains("Height"))
            {
                pnl.Height = Convert.ToInt32(pnum.Value);
            }
            pnl.Invalidate();

        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
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
        }

        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;

            CheckBox chk = new CheckBox();
            var chkcol = csfunc.GetAll(cbx.Parent, typeof(CheckBox));
            foreach (CheckBox ctrl in chkcol)
            {
                chk = ctrl;
            }

            chk.Checked = false;
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

            var pnlcol = csfunc.GetAll(flpMain, typeof(Panel),cbx.Parent.Name);
            foreach (Panel ctrl in pnlcol)
            {
                ctrl.AccessibleDescription = cbx.Text + chk.Text;
                ctrl.Invalidate();
            }
        }

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

            //pnlDraw.Size = new Size(600, 600);
            flpMain.Size = new Size(400, 400);
            pnlProperties.Size = new Size(185, 629);

            //pnlMain.Size = new Size(924, 800);
        }

        private void Editors_SizeChanged(object sender, EventArgs e)
        {
            int cX, cY;
            cX = (pnlMain.Width - flpMain.Width) / 2;
            cY = (pnlMain.Height - flpMain.Height) / 2;
            if (cX <= 0 && cY <= 0)
            {
                flpMain.Location = new Point(50, 50);
            }
            else if (cX <= 0)
            {
                flpMain.Location = new Point(50, cY);
            }
            else if (cY <= 0)
            {
                flpMain.Location = new Point(cX, 50);
            }
            else
            {
                flpMain.Location = new Point(cX, cY);
            }
            tsSize.Text = flpMain.Width.ToString() + " x " + flpMain.Height.ToString();

            flpMain.Invalidate();
            pnlMain.Invalidate();
        }

        private void pnl_inner_DragDrop(object sender, DragEventArgs e)
        {
            var Multi = csfunc.GetAll(flpMain, typeof(FlowLayoutPanel), "Multi");
            var cpnl = csfunc.GetAll(flpMain, typeof(Panel), "Panel");

            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control; //Control na babagsak
            Control pnl = (Control)sender; //Control na babagsakan
            if (c != null)
            {
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
                    var mul = csfunc.GetAll(flpMain, typeof(Panel), "Mullion");

                    c.Name += (mul.Count() + 1);
                    if (wndr == 26)
                    {
                        c.Width = 10;
                    }
                    else if (wndr == 33)
                    {
                        c.Width = 20;
                    }
                    c.Height = pnl.Height;
                    pnl.Controls.Add(c);
                }
                else if (c.Name.Contains("Transom"))
                {
                    var transom = csfunc.GetAll(flpMain, typeof(Panel), "Transom");

                    c.Name += (transom.Count() + 1);
                    if (wndr == 26)
                    {
                        c.Height = 10;
                    }
                    else if (wndr == 33)
                    {
                        c.Height = 20;
                    }
                    c.Width = pnl.Width;
                    pnl.Controls.Add(c);
                }
                else
                {
                    if (pnl.Name.Contains("Multi"))
                    {
                        frmDimensions frm = new frmDimensions();
                        FlowLayoutPanel fpnl = (FlowLayoutPanel)pnl;
                        int access_desc = Convert.ToInt32(fpnl.AccessibleDescription);
                        int Pwidth = 0, Pheight = 0;

                        if (wndr == 26)
                        {
                            div = 10;
                        }
                        else if (wndr == 33)
                        {
                            div = 20;
                        }

                        if (fpnl.FlowDirection == FlowDirection.LeftToRight)
                        {
                            Pwidth = (pnl.Width - (div * access_desc)) / (access_desc + 1);
                            Pheight = pnl.Height;
                            
                        }
                        else if (fpnl.FlowDirection == FlowDirection.TopDown)
                        {
                            Pwidth = pnl.Width;
                            Pheight = (pnl.Height - (div * access_desc)) / (access_desc + 1);

                        }

                        frm.numWidth.Value = Pwidth;
                        frm.numHeight.Value = Pheight;

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            Pwidth = Convert.ToInt32(frm.numWidth.Value);
                            Pheight = Convert.ToInt32(frm.numHeight.Value);

                            c.Dock = DockStyle.None;
                            c.Size = new Size(Pwidth, Pheight);
                            c.Tag = pnl.Tag;
                            if (c.Name.Contains("Panel"))
                            {
                                c.Name += (cpnl.Count() + 1);
                                Panel Pprop = CreatePanelProperties(c.Name, (cpnl.Count() + 1),Pwidth,Pheight,true);
                                fprop.Controls.Add(Pprop);
                            }
                            else if (c.Name.Contains("Multi"))
                            {
                                c.Name += (Multi.Count() + 1);
                            }
                            pnl.Controls.Add(c);
                        }
                    }
                    else if (pnl.Name.Contains("Panel_"))
                    {
                        if (c.Name.Contains("Panel"))
                        {
                            c.Name += (cpnl.Count() + 1);
                            Panel Pprop = CreatePanelProperties(c.Name, (cpnl.Count() + 1), pnl.Width, pnl.Height,false);
                            //Panel Pprop = CreatePanelProperties(c.Name, (cpnl.Count() + 1), pnl.Parent.Width, pnl.Parent.Height,false);
                            fprop.Controls.Add(Pprop);
                        }
                        else if (c.Name.Contains("Multi"))
                        {
                            c.Name += (Multi.Count() + 1);
                        }
                        c.Tag = pnl.Tag;
                        pnl.Controls.Add(c);
                    }
                    else
                    {
                        if (c.Name.Contains("Panel"))
                        {
                            c.Name += (cpnl.Count() + 1);
                            Panel Pprop = CreatePanelProperties(c.Name, (cpnl.Count() + 1), pnl.Width, pnl.Height,false);
                            //Panel Pprop = CreatePanelProperties(c.Name, (cpnl.Count() + 1), pnl.Parent.Width, pnl.Parent.Height,false);
                            fprop.Controls.Add(Pprop);
                        }
                        else if (c.Name.Contains("Multi"))
                        {
                            c.Name += (Multi.Count() + 1);
                        }
                        c.Tag = pnl.Tag;
                        pnl.Controls.Add(c);
                    }
                }
                
            }
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
                Font dmnsion_font = new Font("Segoe UI", 12);

                Size s = TextRenderer.MeasureText(pfr.Name, dmnsion_font);
                double mid = (pfr.Width) / 2;
                TextRenderer.DrawText(g,
                                      pfr.Name,
                                      dmnsion_font,
                                      new Point((int)(mid - (s.Width / 2)),3),
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
                    ctrl = CreateMultiPnl("Multi_", Convert.ToString(dgvControls.Rows[1].Cells[0].Tag),0, 
                                                    Convert.ToString(dgvControls.Rows[1].Cells[1].Tag));
                }
                else if (ctrltype == "Mullion")
                {
                    ctrl = CreateDiv("Mullion_",ctrltype);
                }
                else if (ctrltype == "Transom")
                {
                    ctrl = CreateDiv("Transom_", ctrltype);
                }
                dgvControls.DoDragDrop(ctrl, DragDropEffects.Move);
            }
        }
        
        private void tsSize_DoubleClick(object sender, EventArgs e)
        {
            frmDimensions frm = new frmDimensions();
            frm.numWidth.Value = flpMain.Width;
            frm.numHeight.Value = flpMain.Height;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                flpMain.Width = Convert.ToInt32(frm.numWidth.Value);
                flpMain.Height = Convert.ToInt32(frm.numHeight.Value);
            }
        }
        
        private void flpMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.ScaleTransform(zoom, zoom);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   fpnl.ClientRectangle.Width - w,
                                                                   fpnl.ClientRectangle.Height - w));
        }

        private void flpMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmDimensions frm = new frmDimensions();
            frm.numWidth.Value = flpMain.Width;
            frm.numHeight.Value = flpMain.Height;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                flpMain.Width = Convert.ToInt32(frm.numWidth.Value);
                flpMain.Height = Convert.ToInt32(frm.numHeight.Value);
            }
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

        private void trkZoom_ValueChanged(object sender, EventArgs e)
        {
            zoom = trkZoom.Value / 100f;
            lblZoom.Text = trkZoom.Value.ToString() + " %";

            float wd = flpMain.Width * zoom,
                  ht = flpMain.Height * zoom;

            flpMain.Width = Convert.ToInt32(wd);
            flpMain.Height = Convert.ToInt32(ht);

            pnlMain.Invalidate();
            flpMain.Invalidate();

            var c = csfunc.GetAll(flpMain, typeof(Panel));
            foreach (var ctrl in c)
            {
                ctrl.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //THIS CODE IS TO SAVE IMAGE IN PnlMain
            try
            {
                Bitmap bm = new Bitmap(flpMain.Size.Width, flpMain.Size.Height);
                flpMain.DrawToBitmap(bm, new Rectangle(0,0,
                                                       flpMain.Size.Width, flpMain.Size.Height));

                bm.Save(@"D:\TestDrawToBitmap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                pbox1.Image = bm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.ScaleTransform(zoom, zoom);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int flp_X = flpMain.Location.X,
                flp_Y = flpMain.Location.Y,
                flp_Width = flpMain.Width,
                flp_Height = flpMain.Height;

            string dmnsion_w = flpMain.Width.ToString();
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
            string dmnsion_h = flpMain.Height.ToString();
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
            if (tsm == mullionToolStripMenuItem)
            {
                dgvControls.Rows[1].Cells[0].Value = Properties.Resources.MultiplePanel_Mul;
                dgvControls.Rows[1].Cells[0].Tag = "Mullion";
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

        private void tsBtnNewWindoor(object sender, EventArgs e)
        {
            int defwidth = 400,
                defheight = 400,
                defwndr = 0, //if window 52/2 = 26; elseif door 67/2 = 33
                flp_cntr = flpMain.Controls.Count + 1;

            frmDimensions frm = new frmDimensions();
            frm.numWidth.Value = defwidth;
            frm.numHeight.Value = defwidth;

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

                Panel frame = CreateFrame("Frame", defwidth, defheight, defwndr, flp_cntr);
                flpMain.Controls.Add(frame);
                FlowLayoutPanel prop = CreateFrameProperties("Frame", 
                                                             flpMain.Controls.Count, 
                                                             defwidth,
                                                             defheight,
                                                             defwndr);
                pnlPropertiesBody.Controls.Add(prop);
                prop.BringToFront();
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
            }
            else if (pnlSel.Name.Contains("Multi"))
            {
                var pnlcol1 = csfunc.GetAll(pnlSel, typeof(Panel), "Panel");
                foreach (Panel ctrl1 in pnlcol1)
                {
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
            }
            pnlSel_parent.Controls.Remove(pnlSel);
            pnlSel_parent.Invalidate();
        }

    }
}