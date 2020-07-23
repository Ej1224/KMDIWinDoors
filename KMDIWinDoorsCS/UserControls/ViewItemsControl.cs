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

        public string ItemName, ItemDesc;
        public decimal ItemPrice, ItemNetPrice, ItemDiscount;
        public int ItemQuantity;
        public Image ItemImage;

        private void ViewItemsControl_Load(object sender, EventArgs e)
        {
            //lbl_itemname.Text = ItemName;
            //lbl_desc.Text = ItemDesc;
            lbl_Price.Text = ItemPrice.ToString();
            lbl_NetPrice.Text = ItemNetPrice.ToString();
            lbl_Discount.Text = ItemDiscount.ToString();
            //lbl_Qty.Text = ItemQuantity.ToString();
            pbox_image.Image = ItemImage;
        }

    }
}
