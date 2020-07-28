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

        bool has_decimal;

        [DefaultValue(false)]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool contains_decimal
        {
            get { return has_decimal; }
            set { has_decimal = value; }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Value
        {
            get { return num_CustomNum.Value; }
            set { num_CustomNum.Value = value; }
        }

        private void CustomLbl_Load(object sender, EventArgs e)
        {
            num_CustomNum.Maximum = decimal.MaxValue;
            if (has_decimal == true)
            {
                num_CustomNum.DecimalPlaces = 2;
            }
            else
            {
                num_CustomNum.DecimalPlaces = 0;
            }
        }

        private void lbl_customLbl_DoubleClick(object sender, EventArgs e)
        {
            num_CustomNum.BringToFront();
            lbl_customLbl.SendToBack();
            num_CustomNum.Focus();

            num_CustomNum.Value = Convert.ToDecimal(lbl_customLbl.Text);
            num_CustomNum.Select(0, num_CustomNum.Text.Length);
        }

        private void num_CustomNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lbl_customLbl.BringToFront();
                num_CustomNum.SendToBack();

                if (has_decimal == true)
                {
                    lbl_customLbl.Text = num_CustomNum.Value.ToString("N2");
                }
                else
                {
                    lbl_customLbl.Text = num_CustomNum.Value.ToString();
                }
            }
        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user changes value")]
        public event EventHandler numValueChanged;

        protected void num_ValueChanged(object sender, EventArgs e)
        {
            if (this.numValueChanged != null)
            {
                numValueChanged?.Invoke(this, e);
            }
        }
    }
}
