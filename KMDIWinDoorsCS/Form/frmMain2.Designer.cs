﻿namespace KMDIWinDoorsCS
{
    partial class frmMain2
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFrame = new System.Windows.Forms.Panel();
            this.pnl_inner = new System.Windows.Forms.Panel();
            this.pnlControlMain = new System.Windows.Forms.Panel();
            this.dgvControls = new System.Windows.Forms.DataGridView();
            this.ImageCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.DescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.mnsMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c70ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.premiLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmenuPanel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFixed = new System.Windows.Forms.ToolStripMenuItem();
            this.casementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCasementR = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCasementL = new System.Windows.Forms.ToolStripMenuItem();
            this.awningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAwningNorm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAwningInvrt = new System.Windows.Forms.ToolStripMenuItem();
            this.slidingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSlidingR = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSlidingL = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.flpMain.SuspendLayout();
            this.pnlFrame.SuspendLayout();
            this.pnlControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControls)).BeginInit();
            this.mnsMainMenu.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.cmenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlControlMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlMain);
            this.splitContainer1.Size = new System.Drawing.Size(860, 452);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.flpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(721, 450);
            this.pnlMain.TabIndex = 3;
            this.pnlMain.SizeChanged += new System.EventHandler(this.Editors_SizeChanged);
            // 
            // flpMain
            // 
            this.flpMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpMain.Controls.Add(this.pnlFrame);
            this.flpMain.Location = new System.Drawing.Point(159, 24);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(402, 402);
            this.flpMain.TabIndex = 1;
            this.flpMain.Visible = false;
            this.flpMain.SizeChanged += new System.EventHandler(this.Editors_SizeChanged);
            // 
            // pnlFrame
            // 
            this.pnlFrame.AllowDrop = true;
            this.pnlFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFrame.Controls.Add(this.pnl_inner);
            this.pnlFrame.Location = new System.Drawing.Point(0, 0);
            this.pnlFrame.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFrame.Name = "pnlFrame";
            this.pnlFrame.Padding = new System.Windows.Forms.Padding(26);
            this.pnlFrame.Size = new System.Drawing.Size(400, 400);
            this.pnlFrame.TabIndex = 0;
            this.pnlFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFrame_Paint);
            // 
            // pnl_inner
            // 
            this.pnl_inner.AllowDrop = true;
            this.pnl_inner.AutoScroll = true;
            this.pnl_inner.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_inner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_inner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_inner.Location = new System.Drawing.Point(26, 26);
            this.pnl_inner.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_inner.Name = "pnl_inner";
            this.pnl_inner.Size = new System.Drawing.Size(346, 346);
            this.pnl_inner.TabIndex = 0;
            this.pnl_inner.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnl_inner_DragDrop);
            this.pnl_inner.DragOver += new System.Windows.Forms.DragEventHandler(this.pnl_inner_DragOver);
            // 
            // pnlControlMain
            // 
            this.pnlControlMain.Controls.Add(this.dgvControls);
            this.pnlControlMain.Controls.Add(this.label1);
            this.pnlControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlControlMain.Name = "pnlControlMain";
            this.pnlControlMain.Size = new System.Drawing.Size(131, 450);
            this.pnlControlMain.TabIndex = 5;
            // 
            // dgvControls
            // 
            this.dgvControls.AllowUserToAddRows = false;
            this.dgvControls.AllowUserToDeleteRows = false;
            this.dgvControls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvControls.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvControls.ColumnHeadersVisible = false;
            this.dgvControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageCol,
            this.DescCol});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvControls.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvControls.Location = new System.Drawing.Point(0, 29);
            this.dgvControls.MultiSelect = false;
            this.dgvControls.Name = "dgvControls";
            this.dgvControls.ReadOnly = true;
            this.dgvControls.RowHeadersVisible = false;
            this.dgvControls.RowTemplate.Height = 55;
            this.dgvControls.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvControls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvControls.Size = new System.Drawing.Size(131, 421);
            this.dgvControls.TabIndex = 5;
            this.dgvControls.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvControls_CellMouseDown);
            // 
            // ImageCol
            // 
            this.ImageCol.HeaderText = "Image";
            this.ImageCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ImageCol.Name = "ImageCol";
            this.ImageCol.ReadOnly = true;
            this.ImageCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImageCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ImageCol.Width = 5;
            // 
            // DescCol
            // 
            this.DescCol.HeaderText = "Description";
            this.DescCol.Name = "DescCol";
            this.DescCol.ReadOnly = true;
            this.DescCol.Width = 5;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Controls";
            // 
            // mnsMainMenu
            // 
            this.mnsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMainMenu.Name = "mnsMainMenu";
            this.mnsMainMenu.Size = new System.Drawing.Size(967, 24);
            this.mnsMainMenu.TabIndex = 1;
            this.mnsMainMenu.Text = "msMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c70ToolStripMenuItem,
            this.premiLineToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // c70ToolStripMenuItem
            // 
            this.c70ToolStripMenuItem.Name = "c70ToolStripMenuItem";
            this.c70ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.c70ToolStripMenuItem.Text = "C70";
            this.c70ToolStripMenuItem.Click += new System.EventHandler(this.c70ToolStripMenuItem_Click);
            // 
            // premiLineToolStripMenuItem
            // 
            this.premiLineToolStripMenuItem.Name = "premiLineToolStripMenuItem";
            this.premiLineToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.premiLineToolStripMenuItem.Text = "PremiLine";
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.pnlItems);
            this.pnlRight.Controls.Add(this.label6);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(860, 24);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(107, 452);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlItems
            // 
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 29);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(105, 421);
            this.pnlItems.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Items";
            // 
            // cmenuPanel
            // 
            this.cmenuPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeToolStripMenuItem});
            this.cmenuPanel.Name = "cmenuPanel";
            this.cmenuPanel.Size = new System.Drawing.Size(99, 26);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFixed,
            this.casementToolStripMenuItem,
            this.awningToolStripMenuItem,
            this.slidingToolStripMenuItem});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // tsmFixed
            // 
            this.tsmFixed.Name = "tsmFixed";
            this.tsmFixed.Size = new System.Drawing.Size(127, 22);
            this.tsmFixed.Text = "Fixed";
            this.tsmFixed.Click += new System.EventHandler(this.tsm_Click);
            // 
            // casementToolStripMenuItem
            // 
            this.casementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCasementR,
            this.tsmCasementL});
            this.casementToolStripMenuItem.Name = "casementToolStripMenuItem";
            this.casementToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.casementToolStripMenuItem.Text = "Casement";
            // 
            // tsmCasementR
            // 
            this.tsmCasementR.Name = "tsmCasementR";
            this.tsmCasementR.Size = new System.Drawing.Size(81, 22);
            this.tsmCasementR.Text = "R";
            this.tsmCasementR.Click += new System.EventHandler(this.tsm_Click);
            // 
            // tsmCasementL
            // 
            this.tsmCasementL.Name = "tsmCasementL";
            this.tsmCasementL.Size = new System.Drawing.Size(81, 22);
            this.tsmCasementL.Text = "L";
            this.tsmCasementL.Click += new System.EventHandler(this.tsm_Click);
            // 
            // awningToolStripMenuItem
            // 
            this.awningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAwningNorm,
            this.tsmAwningInvrt});
            this.awningToolStripMenuItem.Name = "awningToolStripMenuItem";
            this.awningToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.awningToolStripMenuItem.Text = "Awning";
            // 
            // tsmAwningNorm
            // 
            this.tsmAwningNorm.Name = "tsmAwningNorm";
            this.tsmAwningNorm.Size = new System.Drawing.Size(105, 22);
            this.tsmAwningNorm.Text = "Norm";
            this.tsmAwningNorm.Click += new System.EventHandler(this.tsm_Click);
            // 
            // tsmAwningInvrt
            // 
            this.tsmAwningInvrt.Name = "tsmAwningInvrt";
            this.tsmAwningInvrt.Size = new System.Drawing.Size(105, 22);
            this.tsmAwningInvrt.Text = "Invrt";
            this.tsmAwningInvrt.Click += new System.EventHandler(this.tsm_Click);
            // 
            // slidingToolStripMenuItem
            // 
            this.slidingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSlidingR,
            this.tsmSlidingL});
            this.slidingToolStripMenuItem.Name = "slidingToolStripMenuItem";
            this.slidingToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.slidingToolStripMenuItem.Text = "Sliding";
            // 
            // tsmSlidingR
            // 
            this.tsmSlidingR.Name = "tsmSlidingR";
            this.tsmSlidingR.Size = new System.Drawing.Size(81, 22);
            this.tsmSlidingR.Text = "R";
            this.tsmSlidingR.Click += new System.EventHandler(this.tsm_Click);
            // 
            // tsmSlidingL
            // 
            this.tsmSlidingL.Name = "tsmSlidingL";
            this.tsmSlidingL.Size = new System.Drawing.Size(81, 22);
            this.tsmSlidingL.Text = "L";
            this.tsmSlidingL.Click += new System.EventHandler(this.tsm_Click);
            // 
            // frmMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 476);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.mnsMainMenu);
            this.MainMenuStrip = this.mnsMainMenu;
            this.Name = "frmMain2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.flpMain.ResumeLayout(false);
            this.pnlFrame.ResumeLayout(false);
            this.pnlControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvControls)).EndInit();
            this.mnsMainMenu.ResumeLayout(false);
            this.mnsMainMenu.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.cmenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlFrame;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.MenuStrip mnsMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c70ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem premiLineToolStripMenuItem;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlItems;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlControlMain;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvControls;
        private System.Windows.Forms.DataGridViewImageColumn ImageCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCol;
        private System.Windows.Forms.Panel pnl_inner;
        private System.Windows.Forms.ContextMenuStrip cmenuPanel;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmFixed;
        private System.Windows.Forms.ToolStripMenuItem casementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmCasementR;
        private System.Windows.Forms.ToolStripMenuItem tsmCasementL;
        private System.Windows.Forms.ToolStripMenuItem awningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAwningNorm;
        private System.Windows.Forms.ToolStripMenuItem tsmAwningInvrt;
        private System.Windows.Forms.ToolStripMenuItem slidingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSlidingR;
        private System.Windows.Forms.ToolStripMenuItem tsmSlidingL;
    }
}

