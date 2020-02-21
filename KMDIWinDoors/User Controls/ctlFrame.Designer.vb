<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlFrame
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmenuFrame = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddTransomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmenuFrame.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmenuFrame
        '
        Me.cmenuFrame.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TypeToolStripMenuItem, Me.AddTransomToolStripMenuItem})
        Me.cmenuFrame.Name = "ContextMenuStrip1"
        Me.cmenuFrame.Size = New System.Drawing.Size(153, 70)
        '
        'TypeToolStripMenuItem
        '
        Me.TypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowToolStripMenuItem, Me.DoorToolStripMenuItem})
        Me.TypeToolStripMenuItem.Name = "TypeToolStripMenuItem"
        Me.TypeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TypeToolStripMenuItem.Text = "Type"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'DoorToolStripMenuItem
        '
        Me.DoorToolStripMenuItem.Name = "DoorToolStripMenuItem"
        Me.DoorToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DoorToolStripMenuItem.Text = "Door"
        '
        'AddTransomToolStripMenuItem
        '
        Me.AddTransomToolStripMenuItem.Name = "AddTransomToolStripMenuItem"
        Me.AddTransomToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddTransomToolStripMenuItem.Text = "Add Transom"
        '
        'ctlFrame
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "ctlFrame"
        Me.Size = New System.Drawing.Size(100, 100)
        Me.cmenuFrame.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmenuFrame As ContextMenuStrip
    Friend WithEvents TypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DoorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddTransomToolStripMenuItem As ToolStripMenuItem
End Class
