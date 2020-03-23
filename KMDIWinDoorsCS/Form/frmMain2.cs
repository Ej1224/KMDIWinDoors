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
    public partial class frmMain2 : Form
    {
        Pen blkPen = new Pen(Color.Black);
        public frmMain2()
        {
            InitializeComponent();
        }

        private Panel CreatePanels(string name)
        {
            Panel cr8newpnl = new Panel();
            cr8newpnl.Name = name;
            cr8newpnl.BackColor = Color.DarkGray;
            cr8newpnl.BorderStyle = BorderStyle.FixedSingle;
            cr8newpnl.Dock = DockStyle.Fill;
            cr8newpnl.Tag = "Fixed";
            cr8newpnl.Paint += new PaintEventHandler(pnl_Paint);
            cr8newpnl.MouseClick += new MouseEventHandler(pnl_MouseClick);

            return cr8newpnl;
        }

        Panel pnlSel;

        private void pnl_MouseClick(object sender, MouseEventArgs e)
        {
            pnlSel = (Panel)sender;
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
        }

        private Panel CreateFrame(string name)
        {
            Panel frame = new Panel();

            return frame;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvControls.Rows.Add(Properties.Resources.SinglePanel, "Single Panel");
            dgvControls.Rows.Add(Properties.Resources.MultiplePanel, "Multiple Panel");
            dgvControls.Rows.Add(Properties.Resources.Mullion, "Mullion");
            dgvControls.Rows.Add(Properties.Resources.Transom, "Transom");
            dgvControls.ClearSelection();
            splitContainer1.SplitterDistance = 133;
            
        }

        private void Editors_SizeChanged(object sender, EventArgs e)
        {
            int cX, cY;
            cX = (pnlMain.Width - flpMain.Width) / 2;
            cY = (pnlMain.Height - flpMain.Height) / 2;
            if (cX <= 0 || cY <= 0)
            {
                flpMain.Location = new Point(100, 100);
            }
            else
            {
                flpMain.Location = new Point(cX, cY);
            }
        }

        private void c70ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flpMain.Visible = true;
            flpMain.Size = new Size(400 + 2, 400 + 2); //Always add 2px to make the UI borderStyle thick
        }
        
        private void pnl_inner_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            Panel pnl = (Panel)sender;
            if (c != null)
            {
                pnlCntr++;
                c.Name += pnlCntr;
                pnl_inner.Controls.Add(c);
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
        }

        int pnlCntr = 0;
        private void dgvControls_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string ctrltype = dgvControls.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (ctrltype == "Single Panel")
                {
                    Control ctrl = new Control();
                    ctrl = CreatePanels("Panel_");
                    dgvControls.DoDragDrop(ctrl, DragDropEffects.Move);
                }
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

        private void rdDoor_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rdWindow_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
