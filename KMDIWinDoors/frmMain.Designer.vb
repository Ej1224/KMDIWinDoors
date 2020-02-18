<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.spltFrm = New System.Windows.Forms.SplitContainer()
        Me.pnlProperties = New System.Windows.Forms.Panel()
        Me.tblayoutProperties = New System.Windows.Forms.TableLayoutPanel()
        Me.cbxType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numWidth = New System.Windows.Forms.NumericUpDown()
        Me.numHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.spltMain = New System.Windows.Forms.SplitContainer()
        Me.pnlWindoors = New System.Windows.Forms.Panel()
        Me.pnlItems = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.C70ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PremiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tscZoom = New System.Windows.Forms.ToolStripComboBox()
        Me.tslStatus = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        CType(Me.spltFrm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spltFrm.Panel1.SuspendLayout()
        Me.spltFrm.Panel2.SuspendLayout()
        Me.spltFrm.SuspendLayout()
        Me.pnlProperties.SuspendLayout()
        Me.tblayoutProperties.SuspendLayout()
        CType(Me.numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spltMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spltMain.Panel1.SuspendLayout()
        Me.spltMain.Panel2.SuspendLayout()
        Me.spltMain.SuspendLayout()
        Me.pnlWindoors.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'spltFrm
        '
        Me.spltFrm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spltFrm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spltFrm.Location = New System.Drawing.Point(0, 25)
        Me.spltFrm.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.spltFrm.Name = "spltFrm"
        '
        'spltFrm.Panel1
        '
        Me.spltFrm.Panel1.Controls.Add(Me.pnlProperties)
        Me.spltFrm.Panel1MinSize = 125
        '
        'spltFrm.Panel2
        '
        Me.spltFrm.Panel2.Controls.Add(Me.spltMain)
        Me.spltFrm.Size = New System.Drawing.Size(938, 377)
        Me.spltFrm.SplitterDistance = 133
        Me.spltFrm.TabIndex = 0
        '
        'pnlProperties
        '
        Me.pnlProperties.Controls.Add(Me.tblayoutProperties)
        Me.pnlProperties.Controls.Add(Me.Label3)
        Me.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProperties.Location = New System.Drawing.Point(0, 0)
        Me.pnlProperties.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.pnlProperties.Name = "pnlProperties"
        Me.pnlProperties.Size = New System.Drawing.Size(131, 375)
        Me.pnlProperties.TabIndex = 1
        '
        'tblayoutProperties
        '
        Me.tblayoutProperties.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tblayoutProperties.ColumnCount = 2
        Me.tblayoutProperties.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblayoutProperties.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblayoutProperties.Controls.Add(Me.cbxType, 1, 0)
        Me.tblayoutProperties.Controls.Add(Me.Label5, 0, 0)
        Me.tblayoutProperties.Controls.Add(Me.Label2, 0, 1)
        Me.tblayoutProperties.Controls.Add(Me.Label1, 0, 2)
        Me.tblayoutProperties.Controls.Add(Me.numWidth, 1, 1)
        Me.tblayoutProperties.Controls.Add(Me.numHeight, 1, 2)
        Me.tblayoutProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblayoutProperties.Location = New System.Drawing.Point(0, 23)
        Me.tblayoutProperties.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.tblayoutProperties.Name = "tblayoutProperties"
        Me.tblayoutProperties.RowCount = 4
        Me.tblayoutProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tblayoutProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tblayoutProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tblayoutProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.tblayoutProperties.Size = New System.Drawing.Size(131, 352)
        Me.tblayoutProperties.TabIndex = 0
        '
        'cbxType
        '
        Me.cbxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxType.FormattingEnabled = True
        Me.cbxType.Items.AddRange(New Object() {"Window", "Door"})
        Me.cbxType.Location = New System.Drawing.Point(97, 6)
        Me.cbxType.Name = "cbxType"
        Me.cbxType.Size = New System.Drawing.Size(31, 25)
        Me.cbxType.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Width (mm)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Height (mm)"
        '
        'numWidth
        '
        Me.numWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numWidth.Location = New System.Drawing.Point(97, 42)
        Me.numWidth.Name = "numWidth"
        Me.numWidth.Size = New System.Drawing.Size(31, 25)
        Me.numWidth.TabIndex = 0
        '
        'numHeight
        '
        Me.numHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numHeight.Location = New System.Drawing.Point(97, 78)
        Me.numHeight.Name = "numHeight"
        Me.numHeight.Size = New System.Drawing.Size(31, 25)
        Me.numHeight.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Properties"
        '
        'spltMain
        '
        Me.spltMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spltMain.Location = New System.Drawing.Point(0, 0)
        Me.spltMain.Name = "spltMain"
        '
        'spltMain.Panel1
        '
        Me.spltMain.Panel1.Controls.Add(Me.pnlWindoors)
        Me.spltMain.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'spltMain.Panel2
        '
        Me.spltMain.Panel2.Controls.Add(Me.pnlMain)
        Me.spltMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.spltMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.spltMain.Size = New System.Drawing.Size(799, 375)
        Me.spltMain.SplitterDistance = 105
        Me.spltMain.TabIndex = 2
        '
        'pnlWindoors
        '
        Me.pnlWindoors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlWindoors.Controls.Add(Me.pnlItems)
        Me.pnlWindoors.Controls.Add(Me.Label4)
        Me.pnlWindoors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWindoors.Location = New System.Drawing.Point(0, 0)
        Me.pnlWindoors.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.pnlWindoors.Name = "pnlWindoors"
        Me.pnlWindoors.Size = New System.Drawing.Size(105, 375)
        Me.pnlWindoors.TabIndex = 1
        '
        'pnlItems
        '
        Me.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlItems.Location = New System.Drawing.Point(0, 23)
        Me.pnlItems.Name = "pnlItems"
        Me.pnlItems.Size = New System.Drawing.Size(103, 350)
        Me.pnlItems.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(103, 23)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Items"
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(690, 375)
        Me.pnlMain.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(938, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 19)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.C70ToolStripMenuItem, Me.PremiToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'C70ToolStripMenuItem
        '
        Me.C70ToolStripMenuItem.Name = "C70ToolStripMenuItem"
        Me.C70ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.C70ToolStripMenuItem.Text = "C70"
        '
        'PremiToolStripMenuItem
        '
        Me.PremiToolStripMenuItem.Name = "PremiToolStripMenuItem"
        Me.PremiToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.PremiToolStripMenuItem.Text = "Premiline"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscZoom, Me.tslStatus, Me.ToolStripSeparator1, Me.ToolStripProgressBar1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 402)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(938, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tscZoom
        '
        Me.tscZoom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.tscZoom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.tscZoom.AutoSize = False
        Me.tscZoom.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tscZoom.Items.AddRange(New Object() {"20 %", "50 %", "70 %", "100 %", "150 %", "200 %", "400 %"})
        Me.tscZoom.Name = "tscZoom"
        Me.tscZoom.Size = New System.Drawing.Size(60, 23)
        '
        'tslStatus
        '
        Me.tslStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(39, 22)
        Me.tslStatus.Text = "Status"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripProgressBar1.Value = 50
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 427)
        Me.Controls.Add(Me.spltFrm)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.spltFrm.Panel1.ResumeLayout(False)
        Me.spltFrm.Panel2.ResumeLayout(False)
        CType(Me.spltFrm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spltFrm.ResumeLayout(False)
        Me.pnlProperties.ResumeLayout(False)
        Me.tblayoutProperties.ResumeLayout(False)
        Me.tblayoutProperties.PerformLayout()
        CType(Me.numWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spltMain.Panel1.ResumeLayout(False)
        Me.spltMain.Panel2.ResumeLayout(False)
        CType(Me.spltMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spltMain.ResumeLayout(False)
        Me.pnlWindoors.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents spltFrm As SplitContainer
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlProperties As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents C70ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PremiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tblayoutProperties As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tscZoom As ToolStripComboBox
    Friend WithEvents tslStatus As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents pnlWindoors As Panel
    Friend WithEvents spltMain As SplitContainer
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlItems As Panel
    Friend WithEvents cbxType As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents numWidth As NumericUpDown
    Friend WithEvents numHeight As NumericUpDown
End Class
