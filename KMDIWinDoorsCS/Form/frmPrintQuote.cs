using Microsoft.Reporting.WinForms;
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
    public partial class frmPrintQuote : Form
    {
        public frmPrintQuote()
        {
            InitializeComponent();
        }

        Class.csFunctions csfunc = new Class.csFunctions();
        private void frmPrintQuote_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDataSource QuoteDS = new ReportDataSource();
                QuoteDS.Name = "DataSet1";
                QuoteDS.Value = QuoteBS;
                reportViewer1.LocalReport.DataSources.Add(QuoteDS);

                reportViewer1.LocalReport.ReportEmbeddedResource = "KMDIWinDoorsCS.Reports.rptQuotation.rdlc";
                //reportViewer1.LocalReport.ReportEmbeddedResource = "KMDIWinDoorsCS.Reports.Report1.rdlc";

                ReportParameter[] param = new ReportParameter[7];
                param[0] = new ReportParameter("JO", txt_JO.Text);
                param[1] = new ReportParameter("CustRef", txt_CustRef.Text);
                param[2] = new ReportParameter("QuoteNo", txt_QuoteNo.Text);
                param[3] = new ReportParameter("date", dtp_Date.Value.ToString("MM/dd/yyyy"));
                param[4] = new ReportParameter("Address", rtbox_Address.Text);
                param[5] = new ReportParameter("Salutation", rtbox_Salutation.Text);
                param[6] = new ReportParameter("Body", rtbox_Body.Text);
                reportViewer1.LocalReport.SetParameters(param);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 75;

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
