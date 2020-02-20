Public Class ctlWdw
    Public wdwtype As String
    Dim penColor As Color
    Dim borderWidth As Integer
    Private Sub ctlFrame_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim dGrayPen As New Pen(Color.DimGray)

        Dim w As Integer = borderWidth
        Dim w2 As Integer = CInt(Math.Floor(w / 2))
        e.Graphics.DrawRectangle(New Pen(penColor, w),
                                 New Rectangle(w2, w2,
                                               sender.ClientRectangle.Width - w,
                                               sender.ClientRectangle.Height - w))
        If wdwtype = "Fixed" Then
            Dim drawFont As New Font("Segoe UI", 12)
            Dim blackbrush As New SolidBrush(Color.Black)
            Dim drawFrmt As New StringFormat
            drawFrmt.Alignment = StringAlignment.Center
            drawFrmt.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(wdwtype, drawFont, blackbrush, ClientRectangle, drawFrmt)

        Else
            With dGrayPen
                .DashStyle = Drawing2D.DashStyle.Dash
                .Width = 3
            End With

            If wdwtype = "CasementL" Then
                e.Graphics.DrawLine(dGrayPen, pt1:=New PointF(Width, 0), pt2:=New PointF(0, Height / 2))
                e.Graphics.DrawLine(dGrayPen, pt1:=New PointF(0, Height / 2), pt2:=New PointF(Width, Height))

            ElseIf wdwtype = "CasementR" Then
                e.Graphics.DrawLine(dGrayPen, pt1:=New PointF(0, 0), pt2:=New PointF(Width, Height / 2))
                e.Graphics.DrawLine(dGrayPen, pt1:=New PointF(Width, Height / 2), pt2:=New PointF(0, Height))

            ElseIf wdwtype = "AwningN" Then
                e.Graphics.DrawLine(dGrayPen, pt1:=New PointF(0, Height), pt2:=New PointF(Width / 2, 0))
                e.Graphics.DrawLine(dGrayPen, pt1:=New PointF(Width / 2, 0), pt2:=New PointF(Width, Height))

            ElseIf wdwtype = "AwningInv" Then
                e.Graphics.DrawLine(dGrayPen, pt1:=New PointF(0, 0), pt2:=New PointF(Width / 2, Height))
                e.Graphics.DrawLine(dGrayPen, pt1:=New PointF(Width / 2, Height), pt2:=New PointF(Width, 0))
            End If
        End If
    End Sub

    Private Sub ctlWdw_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If e.Button = MouseButtons.Right Then
            cmenuWdw.Show(MousePosition.X, MousePosition.Y)
        End If
        penColor = Color.Blue
        borderWidth = 2
        Invalidate()
    End Sub

    Private Sub ctlWdw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        penColor = Color.Black
        borderWidth = 1
    End Sub

    Private Sub ctlWdw_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            penColor = Color.Black
            borderWidth = 1
            Invalidate()
        End If
    End Sub

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixedToolStripMenuItem.Click,
                                                                                  LeftToolStripMenuItem.Click,
                                                                                  RightToolStripMenuItem.Click,
                                                                                  NormalToolStripMenuItem.Click,
                                                                                  InvertedToolStripMenuItem.Click
        If sender Is FixedToolStripMenuItem Then
            wdwtype = "Fixed"
        ElseIf sender Is LeftToolStripMenuItem Then
            wdwtype = "CasementL"
        ElseIf sender Is RightToolStripMenuItem Then
            wdwtype = "CasementR"
        ElseIf sender Is NormalToolStripMenuItem Then
            wdwtype = "AwningN"
        ElseIf sender Is InvertedToolStripMenuItem Then
            wdwtype = "AwningInv"
        End If
        Invalidate()
    End Sub

End Class
