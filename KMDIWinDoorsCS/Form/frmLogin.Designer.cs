namespace KMDIWinDoorsCS
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnl_btnContainer = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_OffLogin = new System.Windows.Forms.Button();
            this.chk_Remember = new System.Windows.Forms.CheckBox();
            this.pnl_btnContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(10, 112);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(71, 19);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Username";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(90, 109);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(216, 25);
            this.txtUser.TabIndex = 1;
            this.txtUser.Enter += new System.EventHandler(this.txt_Enter);
            this.txtUser.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(90, 138);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(216, 25);
            this.txtPass.TabIndex = 3;
            this.txtPass.Enter += new System.EventHandler(this.txt_Enter);
            this.txtPass.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(10, 141);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(67, 19);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(97, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnl_btnContainer
            // 
            this.pnl_btnContainer.Controls.Add(this.btnLogin);
            this.pnl_btnContainer.Controls.Add(this.btnCancel);
            this.pnl_btnContainer.Location = new System.Drawing.Point(135, 193);
            this.pnl_btnContainer.Name = "pnl_btnContainer";
            this.pnl_btnContainer.Size = new System.Drawing.Size(178, 35);
            this.pnl_btnContainer.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(16, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::KMDIWinDoorsCS.Properties.Resources.loading2;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(302, 217);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KMDIWinDoorsCS.Properties.Resources.K_M_logo_official_2018_1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btn_OffLogin
            // 
            this.btn_OffLogin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_OffLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OffLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_OffLogin.FlatAppearance.BorderSize = 0;
            this.btn_OffLogin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_OffLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_OffLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OffLogin.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OffLogin.ForeColor = System.Drawing.Color.Blue;
            this.btn_OffLogin.Location = new System.Drawing.Point(7, 197);
            this.btn_OffLogin.Name = "btn_OffLogin";
            this.btn_OffLogin.Size = new System.Drawing.Size(137, 28);
            this.btn_OffLogin.TabIndex = 10;
            this.btn_OffLogin.Text = "No internet, Offline use";
            this.btn_OffLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OffLogin.UseVisualStyleBackColor = true;
            this.btn_OffLogin.Click += new System.EventHandler(this.btn_OffLogin_Click);
            // 
            // chk_Remember
            // 
            this.chk_Remember.AutoSize = true;
            this.chk_Remember.Location = new System.Drawing.Point(14, 171);
            this.chk_Remember.Name = "chk_Remember";
            this.chk_Remember.Size = new System.Drawing.Size(117, 23);
            this.chk_Remember.TabIndex = 11;
            this.chk_Remember.Text = "Remember me";
            this.chk_Remember.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(326, 241);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.chk_Remember);
            this.Controls.Add(this.btn_OffLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.pnl_btnContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Costing Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.pnl_btnContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_btnContainer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btn_OffLogin;
        private System.Windows.Forms.CheckBox chk_Remember;
    }
}