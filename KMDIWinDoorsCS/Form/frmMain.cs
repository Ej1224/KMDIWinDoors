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
            numWidth2.Maximum = decimal.MaxValue;
            numHeight.Maximum = decimal.MaxValue;
            numHeight2.Maximum = decimal.MaxValue;
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

        /*public static DataTable CreateDT(Panel pnlfield)
        {
            using (DataTable dtbl = new DataTable())
            {
                dtbl.Columns.Add("frameID", typeof(int));
                dtbl.Columns.Add("pnlID", typeof(int));
                dtbl.Columns.Add("pnlDvdr", typeof(string));
                dtbl.Columns.Add("WindowDoor", typeof(string));
                dtbl.Columns.Add("WdrType", typeof(string));
                dtbl.Columns.Add("WdrOrient", typeof(string));
                dtbl.Columns.Add("Width", typeof(int));
                dtbl.Columns.Add("Height", typeof(int));

                foreach (var frame in pnlfield.Controls.OfType<FlowLayoutPanel>())
                {
                    string wndr = "";
                    foreach (var rd in frame.Controls.OfType<RadioButton>())
                    {
                        if (rd.Checked == true)
                        {
                            wndr = rd.Name;
                        }
                    }

                    foreach (var pnl in frame.Controls.OfType<Panel>().OrderBy(ee => ee.Tag))
                    {
                        string wndrType = "", wndrDivider = "", wndrOrient = "";
                        int wndrWidth = 0, wndrHeight = 0;
                        foreach (var properties in pnl.Controls.OfType<Control>().OrderBy(ee => ee.TabIndex))
                        {
                            string prop = properties.Name;
                            if (prop.Contains("cbxWindowType"))
                            {
                                ComboBox cbxprop = (ComboBox)properties;
                                wndrType = cbxprop.Text;
                            }
                            else if (prop.Contains("cbxDivider"))
                            {
                                ComboBox cbxprop = (ComboBox)properties;
                                wndrDivider = cbxprop.Text;
                            }
                            else if (prop.Contains("chk"))
                            {
                                CheckBox chkprop = (CheckBox)properties;
                                wndrOrient = chkprop.Text;
                            }
                            else if (prop.Contains("num"))
                            {
                                NumericUpDown numprop = (NumericUpDown)properties;
                                if (prop.Contains("Width"))
                                {
                                    wndrWidth = Convert.ToInt32(numprop.Value);
                                }
                                else if (prop.Contains("Height"))
                                {
                                    wndrHeight = Convert.ToInt32(numprop.Value);
                                }
                            }
                        }
                        dtbl.Rows.Add(frame.Tag, pnl.Tag, wndrDivider, wndr, wndrType, wndrOrient, wndrWidth, wndrHeight);
                    }
                }
                return dtbl;
            }
        }*/

        Dataset.dsWindoor ds = new Dataset.dsWindoor();
        private void dsWindoorFill(Panel pnlfield)
        {
            ds.Clear();
            foreach (var frame in pnlfield.Controls.OfType<FlowLayoutPanel>())
            {
                int totalWidth = 0, totalHeight = 0, wndr = 0;
                foreach (var rd in frame.Controls.OfType<RadioButton>())
                {
                    if (rd.Checked == true)
                    {
                        wndr = Convert.ToInt32(rd.Tag);
                    }
                }
                foreach (var pnl in frame.Controls.OfType<Panel>().OrderBy(ee => ee.Tag))
                {
                    string wndrType = "", wndrDivider = "", wndrOrient = "";
                    int wndrWidth = 0, wndrHeight = 0;
                    foreach (var properties in pnl.Controls.OfType<Control>().OrderBy(ee => ee.TabIndex))
                    {
                        string prop = properties.Name;
                        if (prop.Contains("cbxWindowType"))
                        {
                            ComboBox cbxprop = (ComboBox)properties;
                            wndrType = cbxprop.Text;
                        }
                        else if (prop.Contains("cbxDivider"))
                        {
                            ComboBox cbxprop = (ComboBox)properties;
                            wndrDivider = cbxprop.Text;
                        }
                        else if (prop.Contains("chk"))
                        {
                            CheckBox chkprop = (CheckBox)properties;
                            wndrOrient = chkprop.Text;
                        }
                        else if (prop.Contains("num"))
                        {
                            NumericUpDown numprop = (NumericUpDown)properties;
                            if (prop.Contains("Width"))
                            {
                                wndrWidth = Convert.ToInt32(numprop.Value);
                                totalWidth += wndrWidth;
                            }
                            else if (prop.Contains("Height"))
                            {
                                wndrHeight = Convert.ToInt32(numprop.Value);
                                totalHeight += wndrHeight;
                            }
                        }
                    }
                    ds.dtPanel.Rows.Add(pnl.Tag,
                                        frame.Tag,
                                        wndrDivider,
                                        wndrType,
                                        wndrOrient,
                                        wndrWidth,
                                        wndrHeight);
                }
                ds.dtFrame.Rows.Add(frame.Tag,
                                    wndr,
                                    totalWidth,
                                    totalHeight);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] prop_panels = new string[] {"frameID",
                                                 "pnlID",
                                                 "pnlDvdr",
                                                 "WindowDoor",
                                                 "WdrType",
                                                 "WdrOrient",
                                                 "Width",
                                                 "Height" };

            DataTable tbl = new DataTable();
            tbl.Columns.Add("frameID", typeof(int));
            tbl.Columns.Add("pnlID", typeof(int));
            tbl.Columns.Add("pnlDvdr", typeof(string));
            tbl.Columns.Add("WindowDoor", typeof(string));
            tbl.Columns.Add("WdrType", typeof(string));
            tbl.Columns.Add("WdrOrient", typeof(string));
            tbl.Columns.Add("Width", typeof(int));
            tbl.Columns.Add("Height", typeof(int));
            
            foreach (var frame in pnlFields.Controls.OfType<FlowLayoutPanel>())
            {
                //Console.WriteLine("FrameID: " + frame.Tag);
                foreach (var pnl in frame.Controls.OfType<Panel>().OrderBy(ee => ee.Tag))
                {
                    //Console.WriteLine("PanelID: " + pnl.Tag);
                    string wndr = "",wndrType = "", wndrDivider = "",wndrOrient = "";
                    int wndrWidth = 0, wndrHeight = 0;
                    foreach (var properties in pnl.Controls.OfType<Control>().OrderBy(ee => ee.TabIndex))
                    {
                        string prop = properties.Name;
                        if (prop.Contains("rd"))
                        {
                            RadioButton rdprop = (RadioButton)properties;
                            if (rdprop.Checked == true)
                            {
                                //Console.WriteLine("Windoor: " + prop);
                                wndr = prop;
                            }
                        }
                        else if (prop.Contains("cbxWindowType"))
                        {
                            ComboBox cbxprop = (ComboBox)properties;
                            wndrType = cbxprop.Text;
                            //Console.WriteLine("WindorType: " + cbxprop.Text);
                        }
                        else if (prop.Contains("cbxDivider"))
                        {
                            ComboBox cbxprop = (ComboBox)properties;
                            wndrDivider = cbxprop.Text;
                            //Console.WriteLine("Divider: " + cbxprop.Text);
                        }
                        else if (prop.Contains("chk"))
                        {
                            CheckBox chkprop = (CheckBox)properties;
                            wndrOrient = chkprop.Text;
                            //Console.WriteLine("Orientation: " + chkprop.Text);
                        }
                        else if (prop.Contains("num"))
                        {
                            NumericUpDown numprop = (NumericUpDown)properties;
                            if (prop.Contains("Width"))
                            {
                                wndrWidth = Convert.ToInt32(numprop.Value);
                                //Console.WriteLine("Width: " + numprop.Value);
                            }
                            else if (prop.Contains("Height"))
                            {
                                wndrHeight = Convert.ToInt32(numprop.Value);
                                //Console.WriteLine("Height: " + numprop.Value);
                            }
                        }
                    }
                    tbl.Rows.Add(frame.Tag,pnl.Tag, wndrDivider, wndr, wndrType, wndrOrient,wndrWidth,wndrHeight);
                }
            }
            foreach (DataRow row in tbl.Rows)
            {
                Console.WriteLine("frameID: " + row["frameID"].ToString());
                Console.WriteLine("pnlID: " + row["pnlID"].ToString());
                Console.WriteLine("pnlDvdr: " + row["pnlDvdr"].ToString());
                Console.WriteLine("WindowDoor: " + row["WindowDoor"].ToString());
                Console.WriteLine("WdrType: " + row["WdrType"].ToString());
                Console.WriteLine("WdrOrient: " + row["WdrOrient"].ToString());
                Console.WriteLine("Width: " + row["Width"].ToString());
                Console.WriteLine("Height: " + row["Height"].ToString() + "\r\n");
            }

            //foreach (var item in flowLayoutPanel1.Controls.OfType<Control>().OrderBy(ee => ee.Tag))
            //{
            //    Console.WriteLine(item.Name);
            //}

            //Bitmap bmp = new Bitmap(pbxEditor.Width, pbxEditor.Height);
            //pbxEditor.DrawToBitmap(bmp, new Rectangle(0, 0, pbxEditor.Width, pbxEditor.Height));
            //bmp.Save("Test1.png", System.Drawing.Imaging.ImageFormat.Png);
            //bmp = new Bitmap(pbxEditor.Width, pbxEditor.Height);
            //pbxEditor.Invalidate();
            //pbxEditor.ImageLocation = "Test1.png";
        }

        private void cbxWindowType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkWdrOrientation2.Checked = false;
            if (cbxWindowType2.Text == "Casement" || cbxWindowType2.Text == "Sliding")
            {
                chkWdrOrientation2.Enabled = true;
                chkWdrOrientation2.Text = "R";
            }
            else if (cbxWindowType2.Text == "Awning")
            {
                chkWdrOrientation2.Enabled = true;
                chkWdrOrientation2.Text = "Norm";
            }
            else if (cbxWindowType2.Text == "Fixed")
            {
                chkWdrOrientation2.Enabled = false;
                chkWdrOrientation2.Text = "";
            }
        }

        private void chkWdrOrientation2_CheckedChanged(object sender, EventArgs e)
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
                else if (cbx.Text == "Invrt")
                {
                    cbx.Text = "Norm";
                }
            }
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
                else if (cbx.Text == "Invrt")
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
            pnlFields.Controls.Add(flowLayoutPanel1);
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
            int count_frm = pnlFields.Controls.Count;
            if (count_frm != 0)
            {
                dsWindoorFill(pnlFields);
                //foreach (DataRow row in ds.dtFrame.Rows)
                //{
                //    Console.WriteLine("frameID: " + row["fid"].ToString() + "\r\n" +
                //                      "WindowDoor: " + row["wndr"].ToString() + "\r\n" +
                //                      "Total Width: " + row["tWidth"].ToString() + "\r\n" +
                //                      "Total Height: " + row["tHeight"].ToString() + "\r\n");
                //}

                //foreach (DataRow row in ds.dtPanel.Rows)
                //{
                //    Console.WriteLine("pnlID: " + row["pid"].ToString() + "\r\n" +
                //                      "frameID_ref: " + row["fid_ref"].ToString() + "\r\n" +
                //                      "pnlDvdr: " + row["wndrDivider"].ToString() + "\r\n" +
                //                      "WdrType: " + row["wndrType"].ToString() + "\r\n" +
                //                      "WdrOrient: " + row["wndrOrient"].ToString() + "\r\n" +
                //                      "Width: " + row["wndrWidth"].ToString() + "\r\n" +
                //                      "Height: " + row["wndrHeight"].ToString() + "\r\n");
                //}

                Graphics g = e.Graphics;
                g.ScaleTransform(zoom, zoom);

                //int innrfW = fwidth - ftype,
                //    innrfH = fheight - ftype;
                //int sashW = innrfW - 20,
                //    sashH = innrfH - 20;

                g.SmoothingMode = SmoothingMode.AntiAlias;
                //Point fcntr = new Point((pnlMain.Width - fwidth) / 2, (pnlMain.Height - fheight) / 2);
                //Point fcntr = new Point(0, 0);
                //Point innrfCntr = new Point((fwidth - innrfW) / 2 + fcntr.X, (fheight - innrfH) / 2 + fcntr.Y);

                //Rectangle[] frames = new[] //DRAWING for frame
                //{
                //new Rectangle(fcntr,new Size(fwidth,fheight)),
                //new Rectangle(innrfCntr,new Size(innrfW,innrfH))
                //};
                
                Rectangle[] aFrames = new Rectangle[ds.dtFrame.Rows.Count];
                Rectangle[] aPanels = new Rectangle[ds.dtPanel.Rows.Count];

                DataTable Fdt = ds.dtFrame;
                DataTable Pdt = ds.dtPanel;
                for (int i = 0; i < Fdt.Rows.Count; i++)
                {
                    int fid = Convert.ToInt32(Fdt.Rows[i]["fid"].ToString()),
                        wndr = Convert.ToInt32(Pdt.Rows[i]["wndr"].ToString()),
                        tWidth = Convert.ToInt32(Fdt.Rows[i]["tWidth"].ToString()),
                        tHeight = Convert.ToInt32(Fdt.Rows[i]["tHeight"].ToString()),
                        fpnl_tWidth = tWidth - wndr,
                        fpnl_tHeight = tHeight - wndr,
                        fpnl_sashW = fpnl_tWidth - 20,
                        fpnl_sashH = fpnl_tHeight - 20;
                    if (i+1 == 1)
                    {
                        int tsWidth = Convert.ToInt32(Fdt.Rows[i]["tWidth"]),
                            tsHeight = Convert.ToInt32(Fdt.Rows[i]["tHeight"]);
                        aFrames[i] = new Rectangle(new Point(0,0),new Size(tsWidth,tsHeight));
                    }
                    Point fpnl_cntrP = new Point((tWidth - (tWidth - wndr)) / 2 + aFrames[i].X,
                                                 (tHeight - (tHeight - wndr)) / 2 + aFrames[i].Y);

                    for (int j = 0; j < Pdt.Rows.Count; j++)
                    {
                        int fid_ref = Convert.ToInt32(Pdt.Rows[j]["fid_ref"].ToString()),
                            wndrWidth = Convert.ToInt32(Pdt.Rows[j]["wndrWidth"].ToString()),
                            wndrHeight = Convert.ToInt32(Pdt.Rows[j]["wndrHeight"].ToString());
                        string PwdrType = Pdt.Rows[j]["wdrType"].ToString();
                        if (fid_ref == fid)
                        {
                            int Wpnl = wndrWidth - wndr,
                                Hpnl = wndrHeight - wndr;
                            Point pnl_point = new Point((tWidth - Wpnl) / 2 + aFrames[i].X,
                                                        (tHeight - Hpnl) / 2 + aFrames[i].Y);
                            aPanels[j] = new Rectangle(pnl_point,new Size(Wpnl,Hpnl));

                            if (PwdrType == "Fixed")
                            {
                                Font drawFont = new Font("Segoe UI", 12);
                                StringFormat drawFormat = new StringFormat();
                                drawFormat.Alignment = StringAlignment.Center;
                                drawFormat.LineAlignment = StringAlignment.Center;
                                g.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), aPanels[j], drawFormat);
                            }
                            else
                            {
                                Point sashPoint = new Point(aPanels[j].X + 10, aPanels[j].Y + 10);
                                Rectangle sashRect = new Rectangle(sashPoint,
                                                                   new Size(fpnl_sashW, fpnl_sashH));
                                Pen dgrayPen = new Pen(Color.DimGray);
                                {
                                    var dgPen = dgrayPen;
                                    dgPen.DashStyle = DashStyle.Dash;
                                    dgPen.Width = 3;
                                }
                                g.DrawRectangle(blkPen, sashRect);

                                if (PwdrType == "Casement")
                                {
                                    //g.DrawLine(dgrayPen, new Point(innrfCntr.X + innrfW, innrfCntr.Y),
                                    //                     new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))));
                                    //g.DrawLine(dgrayPen, new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))),
                                    //                     new Point(innrfCntr.X + innrfW, innrfH + innrfCntr.Y));
                                    if (wdrOrient == "R")
                                    {
                                        g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                                             new Point(sashPoint.X + fpnl_sashW, (sashPoint.Y + (fpnl_sashH / 2))));
                                        g.DrawLine(dgrayPen, new Point(sashPoint.X + fpnl_sashW, (sashPoint.Y + (fpnl_sashH / 2))),
                                                             new Point(sashPoint.X, fpnl_sashH + sashPoint.Y));
                                    }
                                    else if (wdrOrient == "L")
                                    {
                                        g.DrawLine(dgrayPen, new Point(sashPoint.X + fpnl_sashW, sashPoint.Y),
                                                             new Point(sashPoint.X, (sashPoint.Y + (fpnl_sashH / 2))));
                                        g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (fpnl_sashH / 2))),
                                                             new Point(sashPoint.X + fpnl_sashW, fpnl_sashH + sashPoint.Y));
                                    }
                                }
                                else if (wdrType == "Awning")
                                {
                                    if (wdrOrient == "Norm")
                                    {
                                        g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y + fpnl_sashH),
                                                             new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y));
                                        g.DrawLine(dgrayPen, new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y),
                                                             new Point(sashPoint.X + fpnl_sashW, fpnl_sashH + sashPoint.Y));
                                    }
                                    else if (wdrOrient == "Invrt")
                                    {
                                        g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                                                             new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y + fpnl_sashH));
                                        g.DrawLine(dgrayPen, new Point(sashPoint.X + (fpnl_sashW / 2), sashPoint.Y + fpnl_sashH),
                                                             new Point(sashPoint.X + fpnl_sashW, sashPoint.Y));
                                    }
                                }
                                else if (wdrType == "Sliding")
                                {
                                    float arwStart_x1 = sashPoint.X + (fpnl_sashW / 10),
                                              center_y1 = sashPoint.Y + (fpnl_sashH / 2),
                                              arwEnd_x2 = ((sashPoint.X + fpnl_sashW) - arwStart_x1) + (fpnl_sashW / 10),
                                              arwHeadUp_x3,
                                              arwHeadUp_y3 = center_y1 - (center_y1 / 4),
                                              arwHeadUp_x4,
                                              arwHeadUp_y4 = center_y1 + (center_y1 / 4);

                                    if (wdrOrient == "R")
                                    {
                                        arwHeadUp_x3 = (sashPoint.X + fpnl_sashW) - arwStart_x1;
                                        arwHeadUp_x4 = (sashPoint.X + fpnl_sashW) - arwStart_x1;

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
                        }
                    }

                    Point[] fcrnr_pnts = new[] //DRAWING for frame cornerlines
                    {
                        new Point(aFrames[i].X,aFrames[i].Y),
                        new Point(fpnl_cntrP.X,fpnl_cntrP.Y),
                        new Point(aFrames[i].X +tWidth,aFrames[i].Y),
                        new Point(fpnl_cntrP.X +fpnl_tWidth,fpnl_cntrP.Y),
                        new Point(aFrames[i].X,aFrames[i].Y + tHeight),
                        new Point(fpnl_cntrP.X,fpnl_cntrP.Y + fpnl_tHeight),
                        new Point(aFrames[i].X + tWidth,aFrames[i].Y + tHeight),
                        new Point(fpnl_cntrP.X + fpnl_tWidth,fpnl_cntrP.Y + fpnl_tHeight)
                    };

                    for (int k = 0; k < fcrnr_pnts.Length - 1; k += 2)
                    {
                        g.DrawLine(blkPen, fcrnr_pnts[k], fcrnr_pnts[k + 1]);
                    }

                }

                //Point[] corner_points = new[] //DRAWING for frame cornerlines
                //{
                //new Point(fcntr.X,fcntr.Y),
                //new Point(innrfCntr.X,innrfCntr.Y),
                //new Point(fcntr.X +fwidth,fcntr.Y),
                //new Point(innrfCntr.X +innrfW,innrfCntr.Y),
                //new Point(fcntr.X,fcntr.Y + fheight),
                //new Point(innrfCntr.X,innrfCntr.Y + innrfH),
                //new Point(fcntr.X + fwidth,fcntr.Y + fheight),
                //new Point(innrfCntr.X + innrfW,innrfCntr.Y + innrfH)
                //};

                //for (int i = 0; i < corner_points.Length - 1; i += 2)
                //{
                //    g.DrawLine(blkPen, corner_points[i], corner_points[i + 1]);
                //}

                //g.FillRectangle(new SolidBrush(Color.Gray), frames[1]);
                //g.DrawRectangles(blkPen, frames);

                foreach (Rectangle pnls in aPanels)
                {
                    g.FillRectangle(new SolidBrush(Color.Gray), pnls);
                }
                g.DrawRectangles(blkPen, aFrames);

                //if (wdrType == "Fixed")
                //{
                //    Font drawFont = new Font("Segoe UI", 12);
                //    StringFormat drawFormat = new StringFormat();
                //    drawFormat.Alignment = StringAlignment.Center;
                //    drawFormat.LineAlignment = StringAlignment.Center;
                //    g.DrawString("Fixed", drawFont, new SolidBrush(Color.Black), frames[1], drawFormat);
                //}
                //else
                //{
                //    Point sashPoint = new Point(innrfCntr.X + 10, innrfCntr.Y + 10);
                //    Rectangle sashRect = new Rectangle(sashPoint,
                //                                       new Size(sashW, sashH));
                //    Pen dgrayPen = new Pen(Color.DimGray);
                //    {
                //        var dgPen = dgrayPen;
                //        dgPen.DashStyle = DashStyle.Dash;
                //        dgPen.Width = 3;
                //    }
                //    g.DrawRectangle(blkPen, sashRect);

                //    if (wdrType == "Casement")
                //    {
                //        //g.DrawLine(dgrayPen, new Point(innrfCntr.X + innrfW, innrfCntr.Y),
                //        //                     new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))));
                //        //g.DrawLine(dgrayPen, new Point(innrfCntr.X, (innrfCntr.Y + (innrfH / 2))),
                //        //                     new Point(innrfCntr.X + innrfW, innrfH + innrfCntr.Y));
                //        if (wdrOrient == "R")
                //        {
                //            g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                //                                 new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))));
                //            g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, (sashPoint.Y + (sashH / 2))),
                //                                 new Point(sashPoint.X, sashH + sashPoint.Y));
                //        }
                //        else if (wdrOrient == "L")
                //        {
                //            g.DrawLine(dgrayPen, new Point(sashPoint.X + sashW, sashPoint.Y),
                //                                 new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))));
                //            g.DrawLine(dgrayPen, new Point(sashPoint.X, (sashPoint.Y + (sashH / 2))),
                //                                 new Point(sashPoint.X + sashW, sashH + sashPoint.Y));
                //        }
                //    }
                //    else if (wdrType == "Awning")
                //    {
                //        if (wdrOrient == "Norm")
                //        {
                //            g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y + sashH),
                //                                 new Point(sashPoint.X + (sashW / 2), sashPoint.Y));
                //            g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y),
                //                                 new Point(sashPoint.X + sashW, sashH + sashPoint.Y));
                //        }
                //        else if (wdrOrient == "Invrt")
                //        {
                //            g.DrawLine(dgrayPen, new Point(sashPoint.X, sashPoint.Y),
                //                                 new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH));
                //            g.DrawLine(dgrayPen, new Point(sashPoint.X + (sashW / 2), sashPoint.Y + sashH),
                //                                 new Point(sashPoint.X + sashW, sashPoint.Y));
                //        }
                //    }
                //    else if (wdrType == "Sliding")
                //    {
                //        float arwStart_x1 = sashPoint.X + (sashW / 10),
                //                  center_y1 = sashPoint.Y + (sashH / 2),
                //                  arwEnd_x2 = ((sashPoint.X + sashW) - arwStart_x1) + (sashW / 10),
                //                  arwHeadUp_x3,
                //                  arwHeadUp_y3 = center_y1 - (center_y1 / 4),
                //                  arwHeadUp_x4,
                //                  arwHeadUp_y4 = center_y1 + (center_y1 / 4);

                //        if (wdrOrient == "R")
                //        {
                //            arwHeadUp_x3 = (sashPoint.X + sashW) - arwStart_x1;
                //            arwHeadUp_x4 = (sashPoint.X + sashW) - arwStart_x1;

                //            g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                //                                             new PointF(arwEnd_x2, center_y1));
                //            g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                //                                             new PointF(arwEnd_x2, center_y1));
                //        }
                //        else if (wdrOrient == "L")
                //        {
                //            arwHeadUp_x3 = sashPoint.X + arwStart_x1;
                //            arwHeadUp_x4 = sashPoint.X + arwStart_x1;

                //            g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x3, arwHeadUp_y3),
                //                                             new PointF(arwStart_x1, center_y1));
                //            g.DrawLine(new Pen(Color.Black), new PointF(arwHeadUp_x4, arwHeadUp_y4),
                //                                             new PointF(arwStart_x1, center_y1));
                //        }
                //        g.DrawLine(new Pen(Color.Black), new PointF(arwStart_x1, center_y1),
                //                                         new PointF(arwEnd_x2, center_y1));
                //    }
                //}

                int w = borderStyle;
                int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
                g.DrawRectangle(new Pen(Color.Black, w), new Rectangle(0,
                                                                       0,
                                                                       fwidth - w,
                                                                       fheight - w));
            }
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
