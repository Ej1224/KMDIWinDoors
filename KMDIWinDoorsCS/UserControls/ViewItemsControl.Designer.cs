namespace KMDIWinDoorsCS
{
    partial class ViewItemsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewItemsControl));
            this.lbl_NetPrice = new System.Windows.Forms.Label();
            this.lbl_Discount = new System.Windows.Forms.Label();
            this.lbl_Price = new System.Windows.Forms.Label();
            this.lbl_Qty = new System.Windows.Forms.Label();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.lbl_itemname = new System.Windows.Forms.Label();
            this.pbox_image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_image)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_NetPrice
            // 
            this.lbl_NetPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_NetPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_NetPrice.Location = new System.Drawing.Point(761, 0);
            this.lbl_NetPrice.Name = "lbl_NetPrice";
            this.lbl_NetPrice.Size = new System.Drawing.Size(119, 165);
            this.lbl_NetPrice.TabIndex = 1;
            this.lbl_NetPrice.Text = "563,187.42";
            this.lbl_NetPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Discount
            // 
            this.lbl_Discount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Discount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Discount.Location = new System.Drawing.Point(678, 0);
            this.lbl_Discount.Name = "lbl_Discount";
            this.lbl_Discount.Size = new System.Drawing.Size(83, 165);
            this.lbl_Discount.TabIndex = 2;
            this.lbl_Discount.Text = "30.00";
            this.lbl_Discount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Price
            // 
            this.lbl_Price.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Price.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Price.Location = new System.Drawing.Point(559, 0);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.Size = new System.Drawing.Size(119, 165);
            this.lbl_Price.TabIndex = 3;
            this.lbl_Price.Text = "268,184.49";
            this.lbl_Price.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Qty
            // 
            this.lbl_Qty.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Qty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Qty.Location = new System.Drawing.Point(484, 0);
            this.lbl_Qty.Name = "lbl_Qty";
            this.lbl_Qty.Size = new System.Drawing.Size(75, 165);
            this.lbl_Qty.TabIndex = 4;
            this.lbl_Qty.Text = "3";
            this.lbl_Qty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_desc
            // 
            this.lbl_desc.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_desc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_desc.Location = new System.Drawing.Point(281, 0);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(203, 165);
            this.lbl_desc.TabIndex = 5;
            this.lbl_desc.Text = "SD1\r\n3000w x 3200h\r\nHD DS-DM Sliding Door 1F/1S\r\nw/ Aluminum Pull Handle\r\n10mm Te" +
    "mp. Clear";
            // 
            // lbl_itemname
            // 
            this.lbl_itemname.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_itemname.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_itemname.Location = new System.Drawing.Point(0, 0);
            this.lbl_itemname.Name = "lbl_itemname";
            this.lbl_itemname.Size = new System.Drawing.Size(281, 20);
            this.lbl_itemname.TabIndex = 7;
            this.lbl_itemname.Text = "1. Living Rm Dining";
            // 
            // pbox_image
            // 
            this.pbox_image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbox_image.Image = ((System.Drawing.Image)(resources.GetObject("pbox_image.Image")));
            this.pbox_image.Location = new System.Drawing.Point(0, 20);
            this.pbox_image.Name = "pbox_image";
            this.pbox_image.Size = new System.Drawing.Size(281, 145);
            this.pbox_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_image.TabIndex = 6;
            this.pbox_image.TabStop = false;
            // 
            // ViewItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pbox_image);
            this.Controls.Add(this.lbl_itemname);
            this.Controls.Add(this.lbl_desc);
            this.Controls.Add(this.lbl_Qty);
            this.Controls.Add(this.lbl_Price);
            this.Controls.Add(this.lbl_Discount);
            this.Controls.Add(this.lbl_NetPrice);
            this.Name = "ViewItemsControl";
            this.Size = new System.Drawing.Size(880, 165);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_NetPrice;
        private System.Windows.Forms.Label lbl_Discount;
        private System.Windows.Forms.Label lbl_Price;
        private System.Windows.Forms.Label lbl_Qty;
        private System.Windows.Forms.Label lbl_desc;
        public System.Windows.Forms.PictureBox pbox_image;
        public System.Windows.Forms.Label lbl_itemname;
    }
}
