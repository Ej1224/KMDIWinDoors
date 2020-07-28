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
    public partial class frmItems : Form
    {
        public frmItems()
        {
            InitializeComponent();
        }

        public IDictionary<int, List<object>> dict_items = new Dictionary<int, List<object>>();

        private void frmItems_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, List<object>> items in dict_items)
            {
                ViewItemsControl itmctrl = new ViewItemsControl();
                itmctrl.ItemName = (string)items.Value[0];
                itmctrl.ItemDesc = (string)items.Value[1] + "\n" + (string)items.Value[2];
                itmctrl.ItemImage = (Image)items.Value[3];
                itmctrl.ItemID = (string)items.Value[4];
                itmctrl.Dock = DockStyle.Top;
                pnlFill.Controls.Add(itmctrl);
            }
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            frmMain2 frm = new frmMain2();

            foreach (var item in frm.pnlItems.Controls.OfType<ItemControl>())
            {
                foreach (var row in GetRow())
                {
                    if (item.itmID == row.rowItemID)
                    {
                        item.itmName = row.rowItemName;
                        item.itmDesc = row.rowItemDesc;
                    }
                }
            }
        }

        public IEnumerable<ViewItemsControl.ItemRow> GetRow()
        {
            foreach (var item in pnlFill.Controls.OfType<ViewItemsControl>())
            {
                yield return item.GetFilledRow();
            }
        }

        public IEnumerable<ItemControl.Item> SetRow()
        {
            foreach (var item in pnlFill.Controls.OfType<ItemControl>())
            {
                item.SetValue.ItemDesc = "";
            }
        }
    }
}
