namespace KMDIWinDoorsCS
{
    partial class frmAutoCreateSliding
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPnlNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numFixed = new System.Windows.Forms.NumericUpDown();
            this.numSliding = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.btnF = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFixed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSliding)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. of Panels:";
            // 
            // txtPnlNo
            // 
            this.txtPnlNo.Enabled = false;
            this.txtPnlNo.Location = new System.Drawing.Point(148, 51);
            this.txtPnlNo.Name = "txtPnlNo";
            this.txtPnlNo.Size = new System.Drawing.Size(36, 25);
            this.txtPnlNo.TabIndex = 1;
            this.txtPnlNo.Text = "00";
            this.txtPnlNo.TextChanged += new System.EventHandler(this.txtPnlNo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. of Fixed Panel:";
            // 
            // numFixed
            // 
            this.numFixed.Location = new System.Drawing.Point(148, 79);
            this.numFixed.Name = "numFixed";
            this.numFixed.Size = new System.Drawing.Size(36, 25);
            this.numFixed.TabIndex = 2;
            // 
            // numSliding
            // 
            this.numSliding.Location = new System.Drawing.Point(148, 110);
            this.numSliding.Name = "numSliding";
            this.numSliding.Size = new System.Drawing.Size(36, 25);
            this.numSliding.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "No. of Sliding Panel:";
            // 
            // txtPattern
            // 
            this.txtPattern.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPattern.Location = new System.Drawing.Point(91, 22);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(97, 25);
            this.txtPattern.TabIndex = 1;
            // 
            // btnF
            // 
            this.btnF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF.Location = new System.Drawing.Point(20, 20);
            this.btnF.Name = "btnF";
            this.btnF.Size = new System.Drawing.Size(31, 28);
            this.btnF.TabIndex = 7;
            this.btnF.Text = "F";
            this.btnF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnF.UseVisualStyleBackColor = true;
            // 
            // btnS
            // 
            this.btnS.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnS.Location = new System.Drawing.Point(54, 20);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(31, 28);
            this.btnS.TabIndex = 8;
            this.btnS.Text = "S";
            this.btnS.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnS.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(28, 141);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(109, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAutoCreateSliding
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(198, 181);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnF);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.numSliding);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numFixed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPnlNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutoCreateSliding";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Create Sliding";
            ((System.ComponentModel.ISupportInitialize)(this.numFixed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSliding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numFixed;
        private System.Windows.Forms.NumericUpDown numSliding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Button btnF;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtPnlNo;
    }
}