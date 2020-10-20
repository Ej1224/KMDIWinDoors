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
        csQueries csq = new csQueries();
        string[] files;
        public string autonum;
        bool success = true;
        string cloud_directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Cloud server\";

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
                    object[] userstate = new object[2];
                    bool ret_val = false;
                    userstate[0] = files[i];

                    var objds = csq.CostingQuery_ReturnDS("GetFile", autonum + @"\" + Path.GetFileName(files[i]), Convert.ToInt32(autonum));
                    DataSet ds = objds.Item2;
                    if (objds.Item1 == "Committed")
                    {
                        if (ds.Tables["GetFile"].Rows.Count == 0)
                        {
                            ret_val = csq.CostingQuery_ReturnBool("AddFile", autonum + @"\" + Path.GetFileName(files[i]), "", null, Convert.ToInt32(autonum));
                        }
                        else if (ds.Tables["GetFile"].Rows.Count == 1)
                        {
                            ret_val = true;
                        }
                        else if (ds.Tables["GetFile"].Rows.Count > 1)
                        {
                            success = false;
                        }
                    }
                    else
                    {
                        success = false;
                    }
                    userstate[1] = ret_val;
                    bgw.ReportProgress(i, userstate);
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
                object[] userstate = (object[])e.UserState;
                progressBar1.Value = e.ProgressPercentage + 1;
                lbl_files.Text = Path.GetFileName(userstate[0].ToString());
                
                if ((bool)userstate[1])
                {
                    Directory.CreateDirectory(cloud_directory + autonum);
                    File.Copy(userstate[0].ToString(), cloud_directory + autonum + @"\" + lbl_files.Text, true);
                }
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
                    if (success)
                    {
                        lbl_files.Text = "Finished";
                    }
                    else
                    {
                        lbl_files.Text = "Error occured, please retry.";
                    }
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
