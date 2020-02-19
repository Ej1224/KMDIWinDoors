Public Class ctlFrame
    Dim blackPen As New Pen(Color.Black)
    Public curr_fheight, curr_fwidth, curr_type As Integer

    Private Sub ctlFrame_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim outf_X As Integer = 0,
            outf_Y As Integer = 0

        Dim innf_width As Integer = curr_fwidth - (curr_type * 2),
            innf_height As Integer = curr_fheight - (curr_type * 2)

        Dim innf_cX As Integer = ((curr_fwidth - innf_width) / 2) + outf_X,
            innf_cY As Integer = ((curr_fheight - innf_height) / 2) + outf_Y

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim w As Integer = 3
        Dim w2 As Integer = Math.Floor(w / 2)
        e.Graphics.DrawRectangle(New Pen(Color.Black, 3), New Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height))


        Dim graybrush As New SolidBrush(Color.Gray)
        Dim innf_rect As New Rectangle(innf_cX, innf_cY, innf_width, innf_height)
        Dim corner_points() As Point = {
            New Point(outf_X, outf_Y),
            New Point(innf_cX, innf_cY),
            New Point(outf_X + curr_fwidth, outf_Y),
            New Point(innf_cX + innf_width, innf_cY),
            New Point(outf_X, outf_Y + curr_fheight),
            New Point(innf_cX, innf_cY + innf_height),
            New Point(outf_X + curr_fwidth, outf_Y + curr_fheight),
            New Point(innf_cX + innf_width, innf_cY + innf_height)
        }

        e.Graphics.FillRectangle(graybrush, innf_rect)
        For i = 0 To corner_points.Count - 1 Step 2
            e.Graphics.DrawLine(blackPen, corner_points(i), corner_points(i + 1))
        Next
        e.Graphics.DrawRectangle(blackPen, innf_rect)

        Dim drawFont As New Font("Segoe UI", 20)
        Dim blackbrush As New SolidBrush(Color.Black)
        Dim drawFrmt As New StringFormat
        drawFrmt.Alignment = StringAlignment.Center
        drawFrmt.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString("Fixed", drawFont, blackbrush, innf_rect, drawFrmt)

    End Sub

End Class
