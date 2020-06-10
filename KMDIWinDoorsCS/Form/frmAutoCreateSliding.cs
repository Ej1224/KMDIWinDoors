using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KMDIWinDoorsCS
{
    public partial class frmAutoCreateSliding : Form
    {
        public frmAutoCreateSliding()
        {
            InitializeComponent();
        }

        private void txtPnlNo_TextChanged(object sender, EventArgs e)
        {
            int pnlCount = Convert.ToInt32(txtPnlNo.Text),
                totalCount = 0,
                numFxd = 0,
                numSld = 0;

            numFixed.Maximum = pnlCount;
            numSliding.Maximum = pnlCount;

            numFxd = pnlCount / 2;
            numSld = pnlCount / 2;

            totalCount = Convert.ToInt32(numFxd + numSld);
            numSld += (pnlCount - totalCount);

            for (int i = 0; i < numFxd; i++)
            {
                txtPattern.Text += "F";
            }
            for (int i = 0; i < numSld; i++)
            {
                txtPattern.Text += "S";
            }

            txtPattern.MaxLength = pnlCount;
        }
        
        private void txtPattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 'F' || e.KeyChar == 'f') || (e.KeyChar == 'S' || e.KeyChar == 's') || 
                 e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        
        private void btnFS_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (txtPattern.MaxLength > txtPattern.TextLength)
            {
                if (btn == btnF)
                {
                    txtPattern.Text += "F";
                }
                else if (btn == btnS)
                {
                    txtPattern.Text += "S";
                }
            }
        }

        private void txtPattern_TextChanged(object sender, EventArgs e)
        {
                int countF = Regex.Matches(txtPattern.Text, "F").Count;
                int countS = Regex.Matches(txtPattern.Text, "S").Count;

                numFixed.Value = countF;
                numSliding.Value = countS;
        }
    }
}
