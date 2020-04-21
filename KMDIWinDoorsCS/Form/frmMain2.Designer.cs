namespace KMDIWinDoorsCS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain2));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlControlMain = new System.Windows.Forms.Panel();
            this.dgvControls = new System.Windows.Forms.DataGridView();
            this.ImageCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.DescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlProperties = new System.Windows.Forms.Panel();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.pnlPropertiesBody = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.mnsMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c70ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.premiLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmenuPanel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnNwin = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNdoor = new System.Windows.Forms.ToolStripButton();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stsEditor = new System.Windows.Forms.StatusStrip();
            this.tsSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmenuMultiP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.divTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mullionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trkZoom = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControls)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlProperties.SuspendLayout();
            this.mnsMainMenu.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.cmenuPanel.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.stsEditor.SuspendLayout();
            this.cmenuMultiP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 51);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlControlMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlMain);
            this.splitContainer1.Panel2.Controls.Add(this.pnlProperties);
            this.splitContainer1.Size = new System.Drawing.Size(916, 499);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlControlMain
            // 
            this.pnlControlMain.Controls.Add(this.dgvControls);
            this.pnlControlMain.Controls.Add(this.label1);
            this.pnlControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlControlMain.Name = "pnlControlMain";
            this.pnlControlMain.Size = new System.Drawing.Size(129, 497);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvControls.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvControls.Location = new System.Drawing.Point(0, 29);
            this.dgvControls.MultiSelect = false;
            this.dgvControls.Name = "dgvControls";
            this.dgvControls.ReadOnly = true;
            this.dgvControls.RowHeadersVisible = false;
            this.dgvControls.RowTemplate.Height = 55;
            this.dgvControls.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvControls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvControls.Size = new System.Drawing.Size(129, 468);
            this.dgvControls.TabIndex = 5;
            this.dgvControls.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvControls_CellMouseClick);
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
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Controls";
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.AutoSize = true;
            this.pnlMain.Controls.Add(this.flpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(139, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(640, 497);
            this.pnlMain.TabIndex = 3;
            this.pnlMain.SizeChanged += new System.EventHandler(this.Editors_SizeChanged);
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // flpMain
            // 
            this.flpMain.AccessibleDescription = "";
            this.flpMain.AccessibleName = "";
            this.flpMain.BackColor = System.Drawing.SystemColors.Control;
            this.flpMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flpMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMain.Location = new System.Drawing.Point(196, 84);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(300, 325);
            this.flpMain.TabIndex = 1;
            this.flpMain.Visible = false;
            this.flpMain.SizeChanged += new System.EventHandler(this.Editors_SizeChanged);
            this.flpMain.Paint += new System.Windows.Forms.PaintEventHandler(this.flpMain_Paint);
            this.flpMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.flpMain_MouseDoubleClick);
            // 
            // pnlProperties
            // 
            this.pnlProperties.AutoScroll = true;
            this.pnlProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProperties.Controls.Add(this.chkView);
            this.pnlProperties.Controls.Add(this.pnlPropertiesBody);
            this.pnlProperties.Controls.Add(this.label2);
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProperties.Location = new System.Drawing.Point(0, 0);
            this.pnlProperties.Margin = new System.Windows.Forms.Padding(2);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.Size = new System.Drawing.Size(139, 497);
            this.pnlProperties.TabIndex = 4;
            // 
            // chkView
            // 
            this.chkView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkView.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkView.AutoSize = true;
            this.chkView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chkView.FlatAppearance.BorderSize = 0;
            this.chkView.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.chkView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkView.Location = new System.Drawing.Point(93, 3);
            this.chkView.Margin = new System.Windows.Forms.Padding(2);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(40, 23);
            this.chkView.TabIndex = 2;
            this.chkView.Text = "View";
            this.chkView.UseVisualStyleBackColor = false;
            this.chkView.CheckedChanged += new System.EventHandler(this.chkView_CheckedChanged);
            // 
            // pnlPropertiesBody
            // 
            this.pnlPropertiesBody.AutoScroll = true;
            this.pnlPropertiesBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPropertiesBody.Location = new System.Drawing.Point(0, 29);
            this.pnlPropertiesBody.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPropertiesBody.Name = "pnlPropertiesBody";
            this.pnlPropertiesBody.Size = new System.Drawing.Size(137, 466);
            this.pnlPropertiesBody.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Properties";
            // 
            // mnsMainMenu
            // 
            this.mnsMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMainMenu.Name = "mnsMainMenu";
            this.mnsMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnsMainMenu.Size = new System.Drawing.Size(1084, 24);
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // c70ToolStripMenuItem
            // 
            this.c70ToolStripMenuItem.Name = "c70ToolStripMenuItem";
            this.c70ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.c70ToolStripMenuItem.Text = "C70";
            this.c70ToolStripMenuItem.Click += new System.EventHandler(this.ProfileTypeToolStripMenuItem_Click);
            // 
            // premiLineToolStripMenuItem
            // 
            this.premiLineToolStripMenuItem.Name = "premiLineToolStripMenuItem";
            this.premiLineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.premiLineToolStripMenuItem.Text = "PremiLine";
            this.premiLineToolStripMenuItem.Click += new System.EventHandler(this.ProfileTypeToolStripMenuItem_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.pnlItems);
            this.pnlRight.Controls.Add(this.label6);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(916, 51);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(168, 527);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlItems
            // 
            this.pnlItems.AutoScroll = true;
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 29);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(166, 496);
            this.pnlItems.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Items";
            // 
            // cmenuPanel
            // 
            this.cmenuPanel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmenuPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmenuPanel.Name = "cmenuPanel";
            this.cmenuPanel.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tsMain
            // 
            this.tsMain.Enabled = false;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNwin,
            this.tsBtnNdoor,
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMain.Size = new System.Drawing.Size(1084, 27);
            this.tsMain.TabIndex = 3;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsBtnNwin
            // 
            this.tsBtnNwin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNwin.Image = global::KMDIWinDoorsCS.Properties.Resources.AddNew_Window;
            this.tsBtnNwin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNwin.Name = "tsBtnNwin";
            this.tsBtnNwin.Size = new System.Drawing.Size(24, 24);
            this.tsBtnNwin.Text = "New Window";
            this.tsBtnNwin.Click += new System.EventHandler(this.tsBtnNewWindoor);
            // 
            // tsBtnNdoor
            // 
            this.tsBtnNdoor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNdoor.Image = global::KMDIWinDoorsCS.Properties.Resources.AddNew_Door;
            this.tsBtnNdoor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNdoor.Margin = new System.Windows.Forms.Padding(0);
            this.tsBtnNdoor.Name = "tsBtnNdoor";
            this.tsBtnNdoor.Size = new System.Drawing.Size(24, 27);
            this.tsBtnNdoor.Text = "New Door";
            this.tsBtnNdoor.Click += new System.EventHandler(this.tsBtnNewWindoor);
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Enabled = false;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.printToolStripButton.Text = "&Print";
            // 
            // stsEditor
            // 
            this.stsEditor.AutoSize = false;
            this.stsEditor.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSize,
            this.lblZoom});
            this.stsEditor.Location = new System.Drawing.Point(0, 550);
            this.stsEditor.Name = "stsEditor";
            this.stsEditor.Size = new System.Drawing.Size(916, 28);
            this.stsEditor.TabIndex = 2;
            this.stsEditor.Text = "statusStrip1";
            // 
            // tsSize
            // 
            this.tsSize.DoubleClickEnabled = true;
            this.tsSize.Name = "tsSize";
            this.tsSize.Size = new System.Drawing.Size(55, 23);
            this.tsSize.Text = "400 x 400";
            this.tsSize.DoubleClick += new System.EventHandler(this.tsSize_DoubleClick);
            // 
            // lblZoom
            // 
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(38, 23);
            this.lblZoom.Text = "100 %";
            // 
            // cmenuMultiP
            // 
            this.cmenuMultiP.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmenuMultiP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.divTypeToolStripMenuItem,
            this.divCountToolStripMenuItem});
            this.cmenuMultiP.Name = "cmenuMultiP";
            this.cmenuMultiP.Size = new System.Drawing.Size(130, 48);
            // 
            // divTypeToolStripMenuItem
            // 
            this.divTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mullionToolStripMenuItem,
            this.transomToolStripMenuItem});
            this.divTypeToolStripMenuItem.Name = "divTypeToolStripMenuItem";
            this.divTypeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.divTypeToolStripMenuItem.Text = "Div-Type";
            // 
            // mullionToolStripMenuItem
            // 
            this.mullionToolStripMenuItem.Name = "mullionToolStripMenuItem";
            this.mullionToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mullionToolStripMenuItem.Text = "Mullion";
            this.mullionToolStripMenuItem.Click += new System.EventHandler(this.tsmMultiP_Clicked);
            // 
            // transomToolStripMenuItem
            // 
            this.transomToolStripMenuItem.Name = "transomToolStripMenuItem";
            this.transomToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.transomToolStripMenuItem.Text = "Transom";
            this.transomToolStripMenuItem.Click += new System.EventHandler(this.tsmMultiP_Clicked);
            // 
            // divCountToolStripMenuItem
            // 
            this.divCountToolStripMenuItem.Name = "divCountToolStripMenuItem";
            this.divCountToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.divCountToolStripMenuItem.Text = "Div-Count";
            this.divCountToolStripMenuItem.Click += new System.EventHandler(this.tsmMultiP_Clicked);
            // 
            // trkZoom
            // 
            this.trkZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trkZoom.AutoSize = false;
            this.trkZoom.LargeChange = 25;
            this.trkZoom.Location = new System.Drawing.Point(92, 553);
            this.trkZoom.Margin = new System.Windows.Forms.Padding(2);
            this.trkZoom.Maximum = 300;
            this.trkZoom.Minimum = 5;
            this.trkZoom.Name = "trkZoom";
            this.trkZoom.Size = new System.Drawing.Size(142, 20);
            this.trkZoom.TabIndex = 4;
            this.trkZoom.TickFrequency = 25;
            this.trkZoom.Value = 100;
            this.trkZoom.ValueChanged += new System.EventHandler(this.trkZoom_ValueChanged);
            // 
            // frmMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 578);
            this.Controls.Add(this.trkZoom);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.stsEditor);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnsMainMenu);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnsMainMenu;
            this.Name = "frmMain2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TextChanged += new System.EventHandler(this.frmMain2_TextChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain2_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvControls)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlProperties.ResumeLayout(false);
            this.pnlProperties.PerformLayout();
            this.mnsMainMenu.ResumeLayout(false);
            this.mnsMainMenu.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.cmenuPanel.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.stsEditor.ResumeLayout(false);
            this.stsEditor.PerformLayout();
            this.cmenuMultiP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trkZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip mnsMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c70ToolStripMenuItem;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlItems;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlControlMain;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvControls;
        private System.Windows.Forms.DataGridViewImageColumn ImageCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCol;
        private System.Windows.Forms.ContextMenuStrip cmenuPanel;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.StatusStrip stsEditor;
        private System.Windows.Forms.ToolStripStatusLabel tsSize;
        private System.Windows.Forms.ContextMenuStrip cmenuMultiP;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mullionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsBtnNwin;
        private System.Windows.Forms.ToolStripButton tsBtnNdoor;
        private System.Windows.Forms.Panel pnlProperties;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlPropertiesBody;
        public System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.TrackBar trkZoom;
        private System.Windows.Forms.ToolStripStatusLabel lblZoom;
        private System.Windows.Forms.ToolStripMenuItem premiLineToolStripMenuItem;
    }
}

