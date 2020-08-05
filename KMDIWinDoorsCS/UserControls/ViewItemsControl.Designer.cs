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
            this.tbox_lblname = new System.Windows.Forms.TextBox();
            this.pbox_image = new System.Windows.Forms.PictureBox();
            this.lbl_NetPrice = new System.Windows.Forms.Label();
            this.cstm_qty = new KMDIWinDoorsCS.CustomLbl();
            this.cstm_Price = new KMDIWinDoorsCS.CustomLbl();
            this.cstm_Discount = new KMDIWinDoorsCS.CustomLbl();
            this.tbox_Dimension = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbox_desc = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_image)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbox_lblname
            // 
            this.tbox_lblname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbox_lblname.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbox_lblname.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbox_lblname.Location = new System.Drawing.Point(0, 0);
            this.tbox_lblname.Name = "tbox_lblname";
            this.tbox_lblname.Size = new System.Drawing.Size(281, 25);
            this.tbox_lblname.TabIndex = 8;
            this.tbox_lblname.Text = "1. Living Rm Dining";
            this.tbox_lblname.TextChanged += new System.EventHandler(this.ctrl_ValueChanged);
            // 
            // pbox_image
            // 
            this.pbox_image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbox_image.Image = ((System.Drawing.Image)(resources.GetObject("pbox_image.Image")));
            this.pbox_image.Location = new System.Drawing.Point(0, 25);
            this.pbox_image.Name = "pbox_image";
            this.pbox_image.Size = new System.Drawing.Size(281, 140);
            this.pbox_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_image.TabIndex = 6;
            this.pbox_image.TabStop = false;
            // 
            // lbl_NetPrice
            // 
            this.lbl_NetPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_NetPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NetPrice.Location = new System.Drawing.Point(761, 0);
            this.lbl_NetPrice.Name = "lbl_NetPrice";
            this.lbl_NetPrice.Size = new System.Drawing.Size(119, 165);
            this.lbl_NetPrice.TabIndex = 14;
            this.lbl_NetPrice.Text = "0";
            this.lbl_NetPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cstm_qty
            // 
            this.cstm_qty.Dock = System.Windows.Forms.DockStyle.Right;
            this.cstm_qty.Location = new System.Drawing.Point(484, 0);
            this.cstm_qty.Name = "cstm_qty";
            this.cstm_qty.Size = new System.Drawing.Size(75, 165);
            this.cstm_qty.TabIndex = 10;
            this.cstm_qty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cstm_qty.numValueChanged += new System.EventHandler(this.cstm_numValueChanged);
            // 
            // cstm_Price
            // 
            this.cstm_Price.contains_decimal = true;
            this.cstm_Price.Dock = System.Windows.Forms.DockStyle.Right;
            this.cstm_Price.Location = new System.Drawing.Point(559, 0);
            this.cstm_Price.Name = "cstm_Price";
            this.cstm_Price.Size = new System.Drawing.Size(119, 165);
            this.cstm_Price.TabIndex = 13;
            this.cstm_Price.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cstm_Price.numValueChanged += new System.EventHandler(this.cstm_numValueChanged);
            // 
            // cstm_Discount
            // 
            this.cstm_Discount.contains_decimal = true;
            this.cstm_Discount.Dock = System.Windows.Forms.DockStyle.Right;
            this.cstm_Discount.Location = new System.Drawing.Point(678, 0);
            this.cstm_Discount.Name = "cstm_Discount";
            this.cstm_Discount.Size = new System.Drawing.Size(83, 165);
            this.cstm_Discount.TabIndex = 12;
            this.cstm_Discount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cstm_Discount.numValueChanged += new System.EventHandler(this.cstm_numValueChanged);
            // 
            // tbox_Dimension
            // 
            this.tbox_Dimension.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbox_Dimension.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_Dimension.Location = new System.Drawing.Point(0, 0);
            this.tbox_Dimension.Name = "tbox_Dimension";
            this.tbox_Dimension.ReadOnly = true;
            this.tbox_Dimension.Size = new System.Drawing.Size(203, 25);
            this.tbox_Dimension.TabIndex = 16;
            this.tbox_Dimension.Text = "3000w x 3200h";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtbox_desc);
            this.panel1.Controls.Add(this.tbox_Dimension);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(281, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 165);
            this.panel1.TabIndex = 17;
            // 
            // rtbox_desc
            // 
            this.rtbox_desc.AcceptsTab = true;
            this.rtbox_desc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbox_desc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbox_desc.Location = new System.Drawing.Point(0, 25);
            this.rtbox_desc.Name = "rtbox_desc";
            this.rtbox_desc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbox_desc.Size = new System.Drawing.Size(203, 140);
            this.rtbox_desc.TabIndex = 17;
            this.rtbox_desc.Text = "SD1\nHD DS-DM Sliding Door 1F/1S\nw/ Aluminum Pull Handle\n10mm Temp. Clear";
            this.rtbox_desc.TextChanged += new System.EventHandler(this.ctrl_ValueChanged);
            // 
            // ViewItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pbox_image);
            this.Controls.Add(this.tbox_lblname);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cstm_qty);
            this.Controls.Add(this.cstm_Price);
            this.Controls.Add(this.cstm_Discount);
            this.Controls.Add(this.lbl_NetPrice);
            this.Name = "ViewItemsControl";
            this.Size = new System.Drawing.Size(880, 165);
            this.Load += new System.EventHandler(this.ViewItemsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_image)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbox_image;
        private System.Windows.Forms.TextBox tbox_lblname;
        private CustomLbl cstm_qty;
        private CustomLbl cstm_Discount;
        private CustomLbl cstm_Price;
        private System.Windows.Forms.Label lbl_NetPrice;
        private System.Windows.Forms.TextBox tbox_Dimension;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbox_desc;
    }
}
