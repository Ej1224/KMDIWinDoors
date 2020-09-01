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
        Class.csFunctions csfunc = new Class.csFunctions();
        csQueries csqr = new csQueries();

        BackgroundWorker bgw = new BackgroundWorker();

        string username, password;
        public List<object> info = new List<object>();
        bool expt = false;
        public string mode;

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
                info = csqr.Login(username, password);
            }
            catch (SqlException ex)
            {
                expt = true;
                csfunc.LogToFile(ex.Message, ex.StackTrace);
                if (ex.Number == -2)
                {
                    MessageBox.Show("Request timed out", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (ex.Number == 1232)
                {
                    MessageBox.Show("Please check internet connection", "Network Disconnected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 19)
                {
                    MessageBox.Show("Server is down", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex2)
            {
                expt = true;
                csfunc.LogToFile(ex2.Message, ex2.StackTrace);
                MessageBox.Show(ex2.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(this, "Error occured", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (e.Cancelled == true)
                {
                    pnl_btnContainer.Visible = txtUser.Enabled = txtPass.Enabled = true;
                    pictureBox2.Visible = false;
                }
                else
                {
                    pnl_btnContainer.Visible = txtUser.Enabled = txtPass.Enabled = true;
                    pictureBox2.Visible = false;

                    if (info.Count() > 0)
                    {
                        if (info[3].ToString() == "Costing" || info[3].ToString() == "Admin")
                        {
                            if (mode == "Cloud sync")
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Hide();
                            }
                            else
                            {
                                this.Hide();
                                frmMain2 frm = new frmMain2();
                                frm.info = info;
                                frm.online_login = true;
                                frm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Restricted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (info.Count() == 0 && expt == false)
                    {
                        MessageBox.Show("Incorrect username/password", "Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                expt = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (bgw.IsBusy == false)
            {
                username = txtUser.Text.Trim();
                password = txtPass.Text.Trim();

                if (username == "")
                {
                    MessageBox.Show("Username must not be empty.","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (password == "")
                {
                    MessageBox.Show("Password must not be empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (username != "" && password != "")
                {

                    pnl_btnContainer.Visible = txtUser.Enabled = txtPass.Enabled = false;
                    pictureBox2.Visible = true;
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

        private void btn_OffLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain2 frm = new frmMain2();
            info.Add("");
            info.Add("");
            info.Add("Offline user");
            frm.info = info;
            frm.online_login = false;
            frm.Show();
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
