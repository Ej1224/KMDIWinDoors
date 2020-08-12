using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KMDIWinDoorsCS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        BackgroundWorker bgw = new BackgroundWorker();

        string username, password,
               sqlConStr = "Data Source='121.58.229.248,49107';Network Library=DBMSSOCN;Initial Catalog='KMDIDATA';User ID='kmdiadmin';Password='kmdiadmin';";

        private void frmLogin_Load(object sender, EventArgs e)
        {
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.DoWork += Bgw_DoWork;
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

            }
            catch (SqlException ex)
            {
                if (ex.Number == -2)
                {
                    MessageBox.Show(this, "Request timed out", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (ex.Number == 1232)
                {
                    MessageBox.Show(this, "Please check internet connection", "Network Disconnected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 19)
                {
                    MessageBox.Show(this, "Server is down", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(this, ex2.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (bgw.IsBusy == false)
            {
                username = txtUser.Text.Trim();
                password = txtPass.Text.Trim();

                if (username == "")
                {
                    MessageBox.Show(this, "Username must not be empty.","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (password == "")
                {
                    MessageBox.Show(this, "Password must not be empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (username != "" && password != "")
                {
                    bgw.RunWorkerAsync();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            if (sender == txtUser)
            {
                lblUser.Font = new Font(lblUser.Font, FontStyle.Bold);
            }
            else if (sender == txtPass)
            {
                lblPass.Font = new Font(lblPass.Font, FontStyle.Bold);
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            if (sender == txtUser)
            {
                lblUser.Font = new Font(lblUser.Font, FontStyle.Regular);
            }
            else if (sender == txtPass)
            {
                lblPass.Font = new Font(lblPass.Font, FontStyle.Regular);
            }
        }
    }
}
