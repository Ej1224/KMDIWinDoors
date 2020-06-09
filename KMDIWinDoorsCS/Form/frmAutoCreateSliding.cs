using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMDIWinDoorsCS
{
    public partial class frmAutoCreateSliding : Form
    {
        public frmAutoCreateSliding()
        {
            InitializeComponent();
        }
        //private void AutoCreateSliding(string wndrtype,
        //                               int wndrCount,
        //                               int wndr,
        //                               FlowLayoutPanel fprop)
        //{
        //    FlowLayoutPanel multipnl = (FlowLayoutPanel)pnlSel;
        //    string[] real_dimensions = pnlSel.AccessibleDefaultActionDescription.Split('x');
        //    int wd = 0, ht = 0, div = 0,
        //        divWD = 0, divHT = 0,
        //        real_Pwidth = Convert.ToInt32(real_dimensions[0]),
        //        real_Pheight = Convert.ToInt32(real_dimensions[1]);
        //    string divtype = "";

        //    if (wndr == 26)
        //    {
        //        div = 10;
        //    }
        //    else if (wndr == 33)
        //    {
        //        div = 20;
        //    }

        //    if (multipnl.FlowDirection == FlowDirection.LeftToRight)
        //    {
        //        wd = (real_Pwidth - (div * wndrCount)) / (wndrCount + 1);
        //        //wd = (multipnl.Width - (div * wndrCount)) / (wndrCount + 1);
        //        ht = real_Pheight;
        //        //ht = multipnl.Height;

        //        divWD = div;
        //        divHT = real_Pheight;
        //        //divHT = multipnl.Height;

        //        divtype = "Transom";
        //    }
        //    else if (multipnl.FlowDirection == FlowDirection.TopDown)
        //    {
        //        wd = real_Pwidth;
        //        //wd = multipnl.Width;
        //        ht = (real_Pheight - (div * wndrCount)) / (wndrCount + 1);
        //        //ht = (multipnl.Height - (div * wndrCount)) / (wndrCount + 1);

        //        divWD = real_Pwidth;
        //        //divWD = multipnl.Width;
        //        divHT = div;

        //        divtype = "Mullion";
        //    }

        //    var cpnl = csfunc.GetAll(flpMain, typeof(Panel), "Panel");
        //    //int pnlcount = cpnl.Count();

        //    for (int i = 1; i <= wndrCount + 1; i++)
        //    {
        //        //pnlcount++;
        //        cpnlcount++;
        //        Panel pnl = new Panel();
        //        pnl = CreatePanels("Panel_" + cpnlcount,
        //                           DockStyle.None,
        //                           Convert.ToInt32(wd * zoom),
        //                           Convert.ToInt32(ht * zoom),
        //                           wndrtype);

        //        pnl.Tag = multipnl.Tag;
        //        pnl.TabIndex = cpnlcount;

        //        List<int> lstDimensions = new List<int>();

        //        lstDimensions.Add(wd);
        //        lstDimensions.Add(ht);

        //        if (dictPanelDimension.ContainsKey(cpnlcount))
        //        {
        //            dictPanelDimension[cpnlcount] = lstDimensions;
        //        }
        //        else
        //        {
        //            dictPanelDimension.Add(cpnlcount, lstDimensions);
        //        }

        //        multipnl.Controls.Add(pnl);

        //        Panel Pprop = CreatePanelProperties(pnl.Name, cpnlcount, wd, ht, true, wndrtype);
        //        fprop.Controls.Add(Pprop);

        //        if (i != wndrCount + 1)
        //        {
        //            Panel divMT = new Panel();
        //            //pnl = new Panel();
        //            divMT = CreateDiv(divtype + "_" + i, divtype);
        //            divMT.Size = new Size(Convert.ToInt32(divWD * zoom), Convert.ToInt32(divHT * zoom));
        //            List<int> lstDivDimensions = new List<int>();

        //            lstDivDimensions.Add(divWD);
        //            lstDivDimensions.Add(divHT);

        //            if (divtype == "Mullion")
        //            {
        //                mulcount++;

        //                if (dictMullionDimension.ContainsKey(mulcount))
        //                {
        //                    dictMullionDimension[mulcount] = lstDivDimensions;
        //                }
        //                else
        //                {
        //                    dictMullionDimension.Add(mulcount, lstDivDimensions);
        //                }

        //                divMT.TabIndex = mulcount;

        //            }
        //            else if (divtype == "Transom")
        //            {
        //                trnscount++;

        //                if (dictTransomDimension.ContainsKey(trnscount))
        //                {
        //                    dictTransomDimension[trnscount] = lstDivDimensions;
        //                }
        //                else
        //                {
        //                    dictTransomDimension.Add(trnscount, lstDivDimensions);
        //                }

        //                divMT.TabIndex = trnscount;

        //            }
        //            multipnl.Controls.Add(divMT);
        //        }
        //    }
        //}

        private void txtPnlNo_TextChanged(object sender, EventArgs e)
        {
            int pnlCount = Convert.ToInt32(txtPnlNo.Text),
                totalCount = 0;

            numFixed.Maximum = pnlCount;
            numSliding.Maximum = pnlCount;

            numFixed.Value = pnlCount / 2;
            numSliding.Value = pnlCount / 2;

            totalCount = Convert.ToInt32(numFixed.Value + numSliding.Value);
            numSliding.Value += (pnlCount - totalCount);

            for (int i = 0; i < numFixed.Value; i++)
            {
                txtPattern.Text += "F";
            }
            for (int i = 0; i < numSliding.Value; i++)
            {
                txtPattern.Text += "S";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
