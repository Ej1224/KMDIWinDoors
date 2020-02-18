Public Class ctlFrame
    Dim myGraphics As Graphics
    Dim blackPen As New Pen(Color.Black)
    Public curr_fheight, curr_fwidth, curr_type As Integer

    Sub createFrame()
        myGraphics = Graphics.FromHwnd(Handle)

        Dim outf_X As Integer = 20,
            outf_Y As Integer = 20

        Dim innf_width As Integer = curr_fwidth - (curr_type * 2),
            innf_height As Integer = curr_fheight - (curr_type * 2)

        Dim innf_cX As Integer = ((curr_fwidth - innf_width) / 2) + outf_X,
            innf_cY As Integer = ((curr_fheight - innf_height) / 2) + outf_Y

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

        Dim frames As Rectangle() = {
            New Rectangle(outf_X, outf_Y, curr_fwidth, curr_fheight),
           innf_rect
        }

        Dim windowtype As New Label
        With windowtype
            .Text = "Fixed"
            .BackColor = Color.Gray
            .Font = New Font("Segoe UI", 12)
            .Location = New Point((innf_width - .Width), (innf_height - .Height))
        End With
        Controls.Add(windowtype)

        myGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        myGraphics.FillRectangle(graybrush, innf_rect)
        For i = 0 To corner_points.Count - 1 Step 2
            myGraphics.DrawLine(blackPen, corner_points(i), corner_points(i + 1))
        Next
        myGraphics.DrawRectangles(blackPen, frames)

    End Sub
    Private Sub ctlFrame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createFrame()
    End Sub

    Private Sub ctlFrame_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        createFrame()
    End Sub

End Class
