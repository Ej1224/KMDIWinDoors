using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMDIWinDoorsCS
{
    public partial class CustomLbl : UserControl
    {
        public CustomLbl()
        {
            InitializeComponent();
        }

        private void CustomLbl_Load(object sender, EventArgs e)
        {
            num_CustomNum.Maximum = decimal.MaxValue;
        }

        private void lbl_customLbl_DoubleClick(object sender, EventArgs e)
        {
            num_CustomNum.BringToFront();
            lbl_customLbl.SendToBack();
        }

        private void num_CustomNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lbl_customLbl.BringToFront();
                num_CustomNum.SendToBack();
            }
        }
    }
}
