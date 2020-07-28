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
    public partial class ViewItemsControl : UserControl
    {
        public ViewItemsControl()
        {
            InitializeComponent();
        }

        public class ItemRow
        {
            public string rowItemID { get; set; }
            public string rowItemName { get; set; }
            public string rowItemDesc { get; set; }
            public int rowItemQty { get; set; }
            public decimal rowItemPrice { get; set; }
            public decimal rowItemDiscount { get; set; }
        }

        public string ItemName, ItemDesc, ItemID;
        public decimal ItemPrice, ItemDiscount;
        public int ItemQuantity;
        public Image ItemImage;

        private void cstm_numValueChanged(object sender, EventArgs e)
        {
            ItemQuantity = (int)cstm_qty.Value;
            ItemPrice = cstm_Price.Value;
            ItemDiscount = cstm_Discount.Value / 100;

            decimal DiscountPrice = (ItemPrice * ItemQuantity) * ItemDiscount;

            lbl_NetPrice.Text = ((ItemPrice * ItemQuantity) - DiscountPrice).ToString("N2");
        }

        private void ViewItemsControl_Load(object sender, EventArgs e)
        {
            tbox_lblname.Text = ItemName;
            rtbox_desc.Text = ItemDesc;
            cstm_Price.Value = ItemPrice;
            cstm_Discount.Value = ItemDiscount;
            cstm_qty.Value = ItemQuantity;
            pbox_image.Image = ItemImage;
        }

        public ItemRow GetFilledRow()
        {
            return new ItemRow()
            {
                rowItemID = ItemID,
                rowItemName = tbox_lblname.Text,
                rowItemDesc = rtbox_desc.Text,
                rowItemPrice = cstm_Price.Value,
                rowItemDiscount = cstm_Discount.Value,
                rowItemQty = (int)cstm_qty.Value
            };
        }
    }
}
