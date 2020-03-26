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
using Microsoft.VisualBasic;

namespace KMDIWinDoorsCS
{
    public partial class frmMain2 : Form
    {
        Pen blkPen = new Pen(Color.Black);
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
            cr8newpnl.BackColor = Color.DarkGray;
            cr8newpnl.Dock = dok;
            cr8newpnl.Margin = new Padding(0);
            cr8newpnl.Padding = new Padding(0);
            cr8newpnl.Size = new Size(Pwidth, Pheight);
            cr8newpnl.Tag = "Fixed";
            cr8newpnl.Paint += new PaintEventHandler(pnl_Paint);
            cr8newpnl.MouseClick += new MouseEventHandler(pnl_MouseClick);

            return cr8newpnl;
        }

        Panel pnlSel, pnlSel_parent;

        private void pnl_MouseClick(object sender, MouseEventArgs e)
        {
            pnlSel = (Panel)sender;
            pnlSel_parent = (Panel)pnlSel.Parent;
            if (pnlSel.Name.Contains("Panel"))
            {
                typeToolStripMenuItem.Visible = true;
            }
            else
            {
                typeToolStripMenuItem.Visible = false;
            }

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

            string windowtype = Convert.ToString(pnl.Tag);
            if (windowtype == "Fixed")
            {
                Font drawFont = new Font("Segoe UI", 12);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), e.ClipRectangle, drawFormat);
            }
            else
            {
                Point sashPoint = new Point(e.ClipRectangle.X + 8, e.ClipRectangle.Y + 8);
                Rectangle sashRect = new Rectangle(sashPoint,
                                                   new Size(fpnl_sashW, fpnl_sashH));
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
                        arwHeadUp_x3 = ((sashPoint.X + fpnl_sashW) - arwStart_x1) - 20;
                        arwHeadUp_x4 = ((sashPoint.X + fpnl_sashW) - arwStart_x1) - 20;

                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                         new PointF(arwEnd_x2, center_y1));
                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                         new PointF(arwEnd_x2, center_y1));
                    }
                    else if (windowtype == "SlidingL")
                    {
                        arwHeadUp_x3 = sashPoint.X + arwStart_x1 + 30;
                        arwHeadUp_x4 = sashPoint.X + arwStart_x1 + 30;

                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                                                         new PointF(arwStart_x1, center_y1));
                        g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                                                         new PointF(arwStart_x1, center_y1));
                    }
                    g.DrawLine(new Pen(Color.Black), new PointF(arwStart_x1, center_y1),
                                                     new PointF(arwEnd_x2, center_y1));
                }
            }
            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
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
            frame.Margin = new Padding(0);
            frame.Padding = new Padding(wndr);
            frame.Size = new Size(fwidth, fheight);
            frame.Tag = id;
            frame.Paint += new PaintEventHandler(pnlFrame_Paint);
            frame.MouseClick += new MouseEventHandler(pnl_MouseClick);

            Panel pnl_inner = new Panel();
            pnl_inner.Name = "pnl_inner" + id;
            pnl_inner.AllowDrop = true;
            pnl_inner.Dock = DockStyle.Fill;
            pnl_inner.Margin = new Padding(0);
            pnl_inner.Padding = new Padding(0);
            pnl_inner.Tag = wndr;
            pnl_inner.DragDrop += new DragEventHandler(pnl_inner_DragDrop);
            pnl_inner.DragOver += new DragEventHandler(pnl_inner_DragOver);
            pnl_inner.Paint += new PaintEventHandler(border_paint);

            frame.Controls.Add(pnl_inner);
            return frame;
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
            //g.DrawString("Multi_Panel", drawFont, new SolidBrush(Color.Black), e.ClipRectangle, drawFormat);


            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
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
            div.Paint += new PaintEventHandler(border_paint);
            div.MouseClick += new MouseEventHandler(pnl_MouseClick);

            return div;
        }

        private void border_paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Graphics g = e.Graphics;

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   pnl.ClientRectangle.Width - w,
                                                                   pnl.ClientRectangle.Height - w));
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
            tsSize.Text = (flpMain.Width - 2).ToString() + " x " + (flpMain.Height - 2).ToString();
        }

        private void pnl_inner_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control; //Control na babagsak
            Control pnl = (Control)sender; //Control na babagsakan
            if (c != null)
            {
                int wndr = Convert.ToInt32(pnl.Tag),
                    div = 0;
                if (c.Name.Contains("Mullion"))
                {
                    c.Name += pnlCntr;
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
                    c.Name += pnlCntr;
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

                            pnlCntr++;
                            c.Name += pnlCntr;
                            c.Dock = DockStyle.None;
                            c.Size = new Size(Pwidth, Pheight);
                            c.Tag = pnl.Tag;
                            pnl.Controls.Add(c);
                        }
                    }
                    else if (pnl.Name.Contains("Panel_"))
                    {
                        pnlCntr++;
                        c.Name += pnlCntr;
                        c.Tag = pnl.Tag;
                        pnl.Controls.Add(c);
                    }
                    else
                    {
                        pnlCntr++;
                        c.Name += pnlCntr;
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
            Panel pfr = (Panel)sender;
            Panel pnl_inner = (Panel)pfr.Controls[0];

            g.SmoothingMode = SmoothingMode.AntiAlias;

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

            int w = 1;
            int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                   0,
                                                                   pfr.ClientRectangle.Width - w,
                                                                   pfr.ClientRectangle.Height - w));

            //pnl_inner.Invalidate();
        }

        int pnlCntr = 0;
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
        
        private void tsm_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
            if (tsm == tsmFixed)
            {
                pnlSel.Tag = "Fixed";
            }
            else if (tsm == tsmCasementR)
            {
                pnlSel.Tag = "CasementR";
            }
            else if (tsm == tsmCasementL)
            {
                pnlSel.Tag = "CasementL";
            }
            else if (tsm == tsmAwningNorm)
            {
                pnlSel.Tag = "AwningNorm";
            }
            else if (tsm == tsmAwningInvrt)
            {
                pnlSel.Tag = "AwningInvrt";
            }
            else if (tsm == tsmSlidingR)
            {
                pnlSel.Tag = "SlidingR";
            }
            else if (tsm == tsmSlidingL)
            {
                pnlSel.Tag = "SlidingL";
            }
            pnlSel.Invalidate();
        }
        
        private void flpMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                frmDimensions frm = new frmDimensions();
                FlowLayoutPanel edt = (FlowLayoutPanel)sender;
                frm.numWidth.Value = edt.Width - 2;
                frm.numHeight.Value = edt.Height - 2;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    edt.Width = Convert.ToInt32(frm.numWidth.Value) + 2;
                    edt.Height = Convert.ToInt32(frm.numHeight.Value) + 2;
                }
            }
        }

        private void tsSize_DoubleClick(object sender, EventArgs e)
        {
            frmDimensions frm = new frmDimensions();
            frm.numWidth.Value = flpMain.Width - 2;
            frm.numHeight.Value = flpMain.Height - 2;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                flpMain.Width = Convert.ToInt32(frm.numWidth.Value) + 2;
                flpMain.Height = Convert.ToInt32(frm.numHeight.Value) + 2;
            }
        }

        private void pnlMain_Scroll(object sender, ScrollEventArgs e)
        {
            //foreach (Panel frame in flpMain.Controls)
            //{
            //    frame.Invalidate();
            //}
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
                defwndr = 26;
            }
            else if (sender == tsBtnNdoor)
            {
                defwndr = 33;
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                defwidth = Convert.ToInt32(frm.numWidth.Value);
                defheight = Convert.ToInt32(frm.numHeight.Value);

                Panel frame = CreateFrame("pnlFrame", defwidth, defheight, defwndr, flp_cntr);
                flpMain.Controls.Add(frame);
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlSel_parent.Controls.Remove(pnlSel);
            pnlSel_parent.Invalidate();
        }
    }
}
