namespace KMDIWinDoorsCS
{
    partial class frmMain
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
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.c70ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.premilineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.pnlProperties = new System.Windows.Forms.Panel();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cbxWindowType = new System.Windows.Forms.ComboBox();
            this.rdDoor = new System.Windows.Forms.RadioButton();
            this.rdWindow = new System.Windows.Forms.RadioButton();
            this.Label3 = new System.Windows.Forms.Label();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.mnsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            this.pnlProperties.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.mnsMain.Size = new System.Drawing.Size(956, 25);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c70ToolStripMenuItem,
            this.premilineToolStripMenuItem});
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // c70ToolStripMenuItem
            // 
            this.c70ToolStripMenuItem.Name = "c70ToolStripMenuItem";
            this.c70ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.c70ToolStripMenuItem.Text = "C70";
            // 
            // premilineToolStripMenuItem
            // 
            this.premilineToolStripMenuItem.Name = "premilineToolStripMenuItem";
            this.premilineToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.premilineToolStripMenuItem.Text = "Premiline";
            // 
            // splMain
            // 
            this.splMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(0, 25);
            this.splMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splMain.Name = "splMain";
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.pnlProperties);
            this.splMain.Panel1MinSize = 133;
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.pnlEditor);
            this.splMain.Size = new System.Drawing.Size(956, 420);
            this.splMain.SplitterDistance = 160;
            this.splMain.SplitterWidth = 5;
            this.splMain.TabIndex = 1;
            // 
            // pnlProperties
            // 
            this.pnlProperties.Controls.Add(this.pnlFields);
            this.pnlProperties.Controls.Add(this.Label3);
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProperties.Location = new System.Drawing.Point(0, 0);
            this.pnlProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.Size = new System.Drawing.Size(158, 418);
            this.pnlProperties.TabIndex = 1;
            // 
            // pnlFields
            // 
            this.pnlFields.AutoScroll = true;
            this.pnlFields.Controls.Add(this.flowLayoutPanel1);
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFields.Location = new System.Drawing.Point(0, 29);
            this.pnlFields.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(158, 389);
            this.pnlFields.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(158, 229);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Frame 1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numHeight);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numWidth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.cbxWindowType);
            this.panel1.Controls.Add(this.rdDoor);
            this.panel1.Controls.Add(this.rdWindow);
            this.panel1.Location = new System.Drawing.Point(3, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 189);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Panel 1";
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(7, 152);
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(126, 22);
            this.numHeight.TabIndex = 11;
            this.numHeight.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Height";
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(7, 111);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(125, 22);
            this.numWidth.TabIndex = 10;
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Width";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(7, 53);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(77, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Window Type";
            // 
            // cbxWindowType
            // 
            this.cbxWindowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWindowType.FormattingEnabled = true;
            this.cbxWindowType.Items.AddRange(new object[] {
            "Fixed",
            "Awning",
            "Casement"});
            this.cbxWindowType.Location = new System.Drawing.Point(7, 70);
            this.cbxWindowType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxWindowType.Name = "cbxWindowType";
            this.cbxWindowType.Size = new System.Drawing.Size(125, 21);
            this.cbxWindowType.TabIndex = 2;
            this.cbxWindowType.SelectedIndexChanged += new System.EventHandler(this.cbxWindowType_SelectedIndexChanged);
            // 
            // rdDoor
            // 
            this.rdDoor.AutoSize = true;
            this.rdDoor.Location = new System.Drawing.Point(82, 33);
            this.rdDoor.Name = "rdDoor";
            this.rdDoor.Size = new System.Drawing.Size(51, 17);
            this.rdDoor.TabIndex = 7;
            this.rdDoor.Text = "Door";
            this.rdDoor.UseVisualStyleBackColor = true;
            this.rdDoor.CheckedChanged += new System.EventHandler(this.rdType_CheckedChanged);
            // 
            // rdWindow
            // 
            this.rdWindow.AutoSize = true;
            this.rdWindow.Checked = true;
            this.rdWindow.Location = new System.Drawing.Point(7, 33);
            this.rdWindow.Name = "rdWindow";
            this.rdWindow.Size = new System.Drawing.Size(69, 17);
            this.rdWindow.TabIndex = 8;
            this.rdWindow.TabStop = true;
            this.rdWindow.Text = "Window";
            this.rdWindow.UseVisualStyleBackColor = true;
            this.rdWindow.CheckedChanged += new System.EventHandler(this.rdType_CheckedChanged);
            // 
            // Label3
            // 
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(158, 29);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Properties";
            // 
            // pnlEditor
            // 
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditor.Location = new System.Drawing.Point(0, 0);
            this.pnlEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(789, 418);
            this.pnlEditor.TabIndex = 0;
            this.pnlEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEditor_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 445);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.mnsMain);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mnsMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.pnlProperties.ResumeLayout(false);
            this.pnlFields.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem c70ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem premilineToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Panel pnlProperties;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbxWindowType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdDoor;
        private System.Windows.Forms.RadioButton rdWindow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

