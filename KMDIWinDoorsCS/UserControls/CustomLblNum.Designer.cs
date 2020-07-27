namespace KMDIWinDoorsCS
{
    partial class CustomLbl
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
            this.lbl_customLbl = new System.Windows.Forms.Label();
            this.num_CustomNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_CustomNum)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_customLbl
            // 
            this.lbl_customLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_customLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_customLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_customLbl.Location = new System.Drawing.Point(0, 0);
            this.lbl_customLbl.Name = "lbl_customLbl";
            this.lbl_customLbl.Size = new System.Drawing.Size(150, 150);
            this.lbl_customLbl.TabIndex = 0;
            this.lbl_customLbl.Text = "0";
            this.lbl_customLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_customLbl.DoubleClick += new System.EventHandler(this.lbl_customLbl_DoubleClick);
            // 
            // num_CustomNum
            // 
            this.num_CustomNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.num_CustomNum.DecimalPlaces = 2;
            this.num_CustomNum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.num_CustomNum.Location = new System.Drawing.Point(0, 0);
            this.num_CustomNum.Name = "num_CustomNum";
            this.num_CustomNum.Size = new System.Drawing.Size(150, 25);
            this.num_CustomNum.TabIndex = 1;
            this.num_CustomNum.ThousandsSeparator = true;
            this.num_CustomNum.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            this.num_CustomNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_CustomNum_KeyDown);
            // 
            // CustomLbl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_customLbl);
            this.Controls.Add(this.num_CustomNum);
            this.Name = "CustomLbl";
            this.Load += new System.EventHandler(this.CustomLbl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_CustomNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_customLbl;
        private System.Windows.Forms.NumericUpDown num_CustomNum;
    }
}
