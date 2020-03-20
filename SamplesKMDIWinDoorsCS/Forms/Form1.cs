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

namespace SamplesKMDIWinDoorsCS
{
    public partial class Form1 : Form
    {
        Pen blkPen = new Pen(Color.Black);
        public Form1()
        {
            InitializeComponent();
        }

        private void Editors_SizeChanged(object sender, EventArgs e)
        {
            int cX, cY;
            //cX = (pnlMain.Width - fwidth) / 2;
            //cY = (pnlMain.Height - fheight) / 2;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvControls.Rows.Add(Properties.Resources.SinglePanel, "Single Panel");
            dgvControls.Rows.Add(Properties.Resources.MultiplePanel, "Multiple Panel");
            dgvControls.Rows.Add(Properties.Resources.Mullion, "Mullion");
            dgvControls.Rows.Add(Properties.Resources.Transom, "Transom");
            dgvControls.ClearSelection();
            splitContainer1.SplitterDistance = 154;
        }

        private void c70ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flpMain.Visible = true;
            flpMain.Size = new Size(400 + 2, 400 + 2); //Always add 2px to make the UI borderStyle thick
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            c.DoDragDrop(c, DragDropEffects.Move);
            //panel1.DoDragDrop(panel1, DragDropEffects.Move);
        }

        //private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;
        //}

        private void pnl_inner_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            Panel pnl = (Panel)sender;
            if (c != null)
            {
                c.Dock = DockStyle.Fill;
                pnl_inner.Controls.Add(c);

                //Forms.frmDimensions frm = new Forms.frmDimensions();
                //frm.numWidth.Value = pnl.Width;
                //frm.numHeight.Value = pnl.Height;
                //frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //{
                //    int pnlWidth = Convert.ToInt32(frm.numWidth.Value),
                //        pnlHeight = Convert.ToInt32(frm.numHeight.Value);
                //    c.Location = pnl_inner.PointToClient(new Point(e.X, e.Y));
                //    c.Size = new Size(pnlWidth, pnlHeight);
                //}
            }
            //((Panel)e.Data.GetData(typeof(Panel))).Parent = (FlowLayoutPanel)sender;
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

        private void dgvControls_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dgvControls.DoDragDrop(dgvControls.Rows[e.RowIndex].Cells[0].Value, DragDropEffects.Move);
            }
        }
    }
}
