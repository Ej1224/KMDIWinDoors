<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctlWdw
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.cmenuWdw = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WindowTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FixedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AwningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvertedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CasementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmenuWdw.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmenuWdw
        '
        Me.cmenuWdw.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowTypeToolStripMenuItem})
        Me.cmenuWdw.Name = "cmenuWdw"
        Me.cmenuWdw.Size = New System.Drawing.Size(146, 26)
        '
        'WindowTypeToolStripMenuItem
        '
        Me.WindowTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FixedToolStripMenuItem, Me.AwningToolStripMenuItem, Me.CasementToolStripMenuItem})
        Me.WindowTypeToolStripMenuItem.Name = "WindowTypeToolStripMenuItem"
        Me.WindowTypeToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.WindowTypeToolStripMenuItem.Text = "Window Type"
        '
        'FixedToolStripMenuItem
        '
        Me.FixedToolStripMenuItem.Name = "FixedToolStripMenuItem"
        Me.FixedToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.FixedToolStripMenuItem.Text = "Fixed"
        '
        'AwningToolStripMenuItem
        '
        Me.AwningToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NormalToolStripMenuItem, Me.InvertedToolStripMenuItem})
        Me.AwningToolStripMenuItem.Name = "AwningToolStripMenuItem"
        Me.AwningToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.AwningToolStripMenuItem.Text = "Awning"
        '
        'NormalToolStripMenuItem
        '
        Me.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem"
        Me.NormalToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.NormalToolStripMenuItem.Text = "Normal"
        '
        'InvertedToolStripMenuItem
        '
        Me.InvertedToolStripMenuItem.Name = "InvertedToolStripMenuItem"
        Me.InvertedToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.InvertedToolStripMenuItem.Text = "Inverted"
        '
        'CasementToolStripMenuItem
        '
        Me.CasementToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LeftToolStripMenuItem, Me.RightToolStripMenuItem})
        Me.CasementToolStripMenuItem.Name = "CasementToolStripMenuItem"
        Me.CasementToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.CasementToolStripMenuItem.Text = "Casement"
        '
        'LeftToolStripMenuItem
        '
        Me.LeftToolStripMenuItem.Name = "LeftToolStripMenuItem"
        Me.LeftToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.LeftToolStripMenuItem.Text = "Left"
        '
        'RightToolStripMenuItem
        '
        Me.RightToolStripMenuItem.Name = "RightToolStripMenuItem"
        Me.RightToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.RightToolStripMenuItem.Text = "Right"
        '
        'ctlWdw
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "ctlWdw"
        Me.Size = New System.Drawing.Size(100, 100)
        Me.cmenuWdw.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmenuWdw As ContextMenuStrip
    Friend WithEvents WindowTypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FixedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AwningToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CasementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LeftToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RightToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NormalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InvertedToolStripMenuItem As ToolStripMenuItem
End Class
