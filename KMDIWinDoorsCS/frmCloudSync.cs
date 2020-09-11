using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMDIWinDoorsCS
{
    public partial class frmCloudSync : Form
    {
        public frmCloudSync()
        {
            InitializeComponent();
        }

        BackgroundWorker bgw = new BackgroundWorker();
        Class.csFunctions csfunc = new Class.csFunctions();
        string[] files;
        private void frmCloudSync_Load(object sender, EventArgs e)
        {
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.DoWork += Bgw_DoWork;

            files = Directory.GetFiles(Properties.Settings.Default.WndrDir, "*.wndr");
            progressBar1.Maximum = files.Length;

            bgw.RunWorkerAsync();
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    bgw.ReportProgress(i,files[i]);
                    System.Threading.Thread.Sleep(100);
                }
               
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = e.ProgressPercentage + 1;
                lbl_files.Text = Path.GetFileName(e.UserState.ToString());
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null || e.Cancelled == true)
                {
                    //tsp_Sync.Text = "Error";
                }
                else
                {
                    lbl_files.Text = "Finished";
                }
            }
            catch (Exception ex)
            {
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
