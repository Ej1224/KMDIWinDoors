﻿using System;
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
        /*
         * [0] = Item Name
         * [1] = Item Dimension
         * [2] = Item Description
         * [3] = Item Image
         * [4] = Item ID
         * [5] = Item Qty
         * [6] = Item Price
         * [7] = Item Discount
         */

        private void frmItems_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, List<object>> items in dict_items)
            {
                ViewItemsControl itmctrl = new ViewItemsControl();
                itmctrl.ItemName = (string)items.Value[0];
                itmctrl.ItemDimension = (string)items.Value[1];
                itmctrl.ItemDesc = (string)items.Value[2];
                itmctrl.ItemImage = (Image)items.Value[3];
                itmctrl.ItemID = (string)items.Value[4];
                itmctrl.ItemQuantity = (int)items.Value[5];
                itmctrl.ItemPrice = (decimal)items.Value[6];
                itmctrl.ItemDiscount = (decimal)items.Value[7];

                itmctrl.Dock = DockStyle.Top;
                pnlFill.Controls.Add(itmctrl);
            }
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            frmMain2 frm = new frmMain2();
            dict_items.Clear();

            int i = 0;
            foreach (var row in GetRow())
            {
                List<object> item_info = new List<object>();
                item_info.Add(row.rowItemName);
                item_info.Add(row.rowItemDimension);
                item_info.Add(row.rowItemDesc);
                item_info.Add(row.rowItemImage);
                item_info.Add(row.rowItemID);
                item_info.Add(row.rowItemQty);
                item_info.Add(row.rowItemPrice);
                item_info.Add(row.rowItemDiscount);

                dict_items.Add(i, item_info);
                i++;
            }

            frm.dict_items = dict_items;
        }

        public IEnumerable<ViewItemsControl.ItemRow> GetRow()
        {
            foreach (var item in pnlFill.Controls.OfType<ViewItemsControl>())
            {
                yield return item.GetFilledRow();
            }
        }
    }
}