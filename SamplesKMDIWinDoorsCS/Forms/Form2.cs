using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplesKMDIWinDoorsCS.Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public IEnumerable<Control> GetAll(Control control,Type type,string name)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type, name))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type)
                                      .Where(c => c.Name.Contains(name));
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            var c = GetAll(this, typeof(TextBox),"textBox");
            MessageBox.Show("Total Controls: " + c.Count());
        }
    }
}
