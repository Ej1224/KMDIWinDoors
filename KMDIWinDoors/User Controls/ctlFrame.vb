Public Class ctlFrame
    Public curr_type As Integer
    Private Sub ctlFrame_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Padding = New Padding(curr_type)


        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim w As Integer = 2
        Dim w2 As Integer = Math.Floor(w / 2)
        e.Graphics.DrawRectangle(New Pen(Color.Black, w),
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

End Class
