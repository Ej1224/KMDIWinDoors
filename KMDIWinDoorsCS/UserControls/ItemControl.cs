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
    public partial class ItemControl : UserControl
    {
        public ItemControl()
        {
            InitializeComponent();
        }

        public string itmName, itmDesc, itmProfile, itmDimension, itmID;
        public decimal itmPrice, itmDiscount;
        public float itmZoom;
        public int itmQuantity;
        public bool itmVisible;

        private void ItemControl_Load(object sender, EventArgs e)
        {
            this.Visible = itmVisible;
            this.Dock = DockStyle.Top;
            lbl_dimension.Text = itmDimension;
            lbl_desc.Text = itmDesc;
        }

        public class Item
        {
            public string ItemName { get; set; }
            public string ItemDimension { get; set; }
            public string ItemDesc { get; set; }
            public string ItemProfile { get; set; }
            public string ItemID { get; set; }
            public Image ItemImage { get; set; }
            public bool ItemVisibility { get; set; }
            public int ItemQty { get; set; }
            public decimal ItemPrice { get; set; }
            public decimal ItemDiscount { get; set; }
            public float ItemZoom { get; set; }
        }

        public Item GetFillItem()
        {
            return new Item()
            {
                ItemName = lbl_item.Text,
                ItemDimension = lbl_dimension.Text,
                ItemDesc = lbl_desc.Text,
                ItemImage = pbox_itemImage.Image,
                ItemVisibility = itmVisible,
                ItemProfile = itmProfile,
                ItemID = itmID,
                ItemQty = itmQuantity,
                ItemPrice = itmPrice,
                ItemDiscount = itmDiscount,
                ItemZoom = itmZoom
            };
        }
    }
}
