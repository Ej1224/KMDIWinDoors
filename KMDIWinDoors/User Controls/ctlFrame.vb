Public Class ctlFrame
    Dim penColor As Color
    Dim borderWidth As Integer
    Dim clsGlobal As New clsGlobal
    Dim objsel As Object

    Private Sub ctlFrame_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Padding = New Padding(curr_type)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim w As Integer = borderWidth
        Dim w2 As Integer = Math.Floor(w / 2)
        e.Graphics.DrawRectangle(New Pen(penColor, w),
                                 New Rectangle(w2, w2,
                                               sender.ClientRectangle.Width - w,
                                               sender.ClientRectangle.Height - w))

        Dim corner_points() As Point = {
            New Point(0, 0),
            New Point(curr_type, curr_type),
            New Point(Width, 0),
            New Point(Width - curr_type, curr_type),
            New Point(0, Height),
            New Point(curr_type, Height - curr_type),
            New Point(Width, Height),
            New Point(Width - curr_type, Height - curr_type)
        }

        Dim blackPen As New Pen(Color.Black)
        For i = 0 To corner_points.Count - 1 Step 2
            e.Graphics.DrawLine(blackPen, corner_points(i), corner_points(i + 1))
        Next
    End Sub

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowToolStripMenuItem.Click,
                                                                                  DoorToolStripMenuItem.Click
        If sender Is WindowToolStripMenuItem Then
            curr_type = 53
        ElseIf sender Is DoorToolStripMenuItem Then
            curr_type = 67
        End If
        Invalidate()
    End Sub

    Private Sub ctlFrame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        penColor = Color.Black
        borderWidth = 1
    End Sub

    Private Sub ctlFrame_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter,
                                                                              cmenuFrame.MouseEnter,
                                                                              WindowToolStripMenuItem.MouseEnter,
                                                                              DoorToolStripMenuItem.MouseEnter
        penColor = Color.Blue
        borderWidth = 2
        Invalidate()
    End Sub

    Private Sub ctlFrame_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave,
                                                                              cmenuFrame.MouseLeave,
                                                                              WindowToolStripMenuItem.MouseLeave,
                                                                              DoorToolStripMenuItem.MouseLeave
        penColor = Color.Black
        borderWidth = 1
        Invalidate()
    End Sub

    Private Sub ctlFrame_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Right Then
            cmenuFrame.Show(MousePosition.X, MousePosition.Y)
        End If
        objsel = sender
    End Sub

    Private Sub AddTransomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTransomToolStripMenuItem.Click
        If curr_type = 53 Then
            clsGlobal.AddTransom(objsel, 82)
        ElseIf curr_type = 67 Then
            clsGlobal.AddTransom(objsel, 112)
        End If
    End Sub
End Class
