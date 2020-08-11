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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
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
