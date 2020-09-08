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
            public int rowTagID { get; set; }
            public string rowItemID { get; set; }
            public string rowItemName { get; set; }
            public string rowItemDesc { get; set; }
            public string rowItemDimension { get; set; }
            public int rowItemQty { get; set; }
            public decimal rowItemPrice { get; set; }
            public decimal rowItemDiscount { get; set; }
            public Image rowItemImage { get; set; }
        }

        public string ItemName, ItemDesc, ItemID, ItemDimension;
        public decimal ItemPrice, ItemDiscount;
        public int ItemQuantity;
        public Image ItemImage;

        private void cstm_numValueChanged(object sender, EventArgs e)
        {
            CustomLbl lbl = (CustomLbl)sender;
            if (lbl == cstm_qty)
            {
                ItemQuantity = (int)cstm_qty.Value;
            }
            else if (lbl == cstm_Price)
            {
                ItemPrice = cstm_Price.Value;
            }
            else if (lbl == cstm_Discount)
            {
                ItemDiscount = cstm_Discount.Value / 100;
            }

            decimal DiscountPrice = (ItemPrice * ItemQuantity) * ItemDiscount;

            lbl_NetPrice.Text = ((ItemPrice * ItemQuantity) - DiscountPrice).ToString("N2");

            if (this.ctrlValueChanged != null)
            {
                ctrlValueChanged?.Invoke(this, e);
            }
        }

        private void ViewItemsControl_Load(object sender, EventArgs e)
        {
            string WxH = ItemDimension.Replace(" ", "");
            string[] dimension = WxH.Split('x');

            tbox_Dimension.Text = dimension[0] + "w x " + dimension[1] + "h";

            tbox_lblname.Text = ItemName;
            rtbox_desc.Text = ItemDesc;

            cstm_Price.Value = ItemPrice;
            cstm_Price.Text = ItemPrice.ToString("N2");

            cstm_Discount.Value = ItemDiscount;
            cstm_Discount.Text = cstm_Discount.Value.ToString("N2");

            cstm_qty.Value = ItemQuantity;
            cstm_qty.Text = ItemQuantity.ToString();
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
                rowItemQty = (int)cstm_qty.Value,
                rowItemDimension = ItemDimension,
                rowItemImage = ItemImage,
                rowTagID = (int)this.Tag
            };
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user changes value")]
        public event EventHandler ctrlValueChanged;

        protected void ctrl_ValueChanged(object sender, EventArgs e)
        {
            if (this.ctrlValueChanged != null)
            {
                ctrlValueChanged?.Invoke(this, e);
            }
        }
    }
}
