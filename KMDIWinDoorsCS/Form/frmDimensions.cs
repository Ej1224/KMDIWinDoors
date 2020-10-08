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
    public partial class frmDimensions : Form
    {
        public frmDimensions()
        {
            InitializeComponent();
        }

        private void numWidth_Enter(object sender, EventArgs e)
        {
            numWidth.Select(0, numWidth.Text.Length);
        }

        private void numHeight_Enter(object sender, EventArgs e)
        {
            numHeight.Select(0, numHeight.Text.Length);
        }
    }
}
