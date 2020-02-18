Public Class ctlFrame
    Dim myGraphics As Graphics
    Dim blackPen As New Pen(Color.Black)
    Public curr_fheight, curr_fwidth, curr_type As Integer

    Private Sub ctlFrame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myGraphics = Graphics.FromHwnd(Handle)

        'Width = curr_fwidth
        'Height = curr_fheight

        Dim center_X As Integer = 0,
            center_Y As Integer = 0

        'Dim innf_width As Integer = fwidth - Type,
        '    innf_height As Integer = fheight - Type

        'Dim innf_cX As Integer = ((fwidth - innf_width) / 2) + center_X,
        '    innf_cY As Integer = ((fheight - innf_height) / 2) + center_Y

        'Dim graybrush As New SolidBrush(Color.Gray)
        'Dim innf_rect As New Rectangle(innf_cX, innf_cY, innf_width, innf_height)
        'Dim corner_points() As Point = {
        '    New Point(center_X, center_Y),
        '    New Point(innf_cX, innf_cY),
        '    New Point(center_X + fwidth, center_Y),
        '    New Point(innf_cX + innf_width, innf_cY),
        '    New Point(center_X, center_Y + fheight),
        '    New Point(innf_cX, innf_cY + innf_height),
        '    New Point(center_X + fwidth, center_Y + fheight),
        '    New Point(innf_cX + innf_width, innf_cY + innf_height)
        '}

        Dim frames As Rectangle() = {
            New Rectangle(center_X, center_Y, curr_fwidth, curr_fheight)} ',
        'innf_rect
        '}

        myGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        'myGraphics.FillRectangle(graybrush, innf_rect)
        'For i = 0 To corner_points.Count - 1 Step 2
        '    myGraphics.DrawLine(blackPen, corner_points(i), corner_points(i + 1))
        'Next
        myGraphics.DrawRectangles(blackPen, frames)

        'ctrlFrame.Location = New Point((pnlMain.Width - fwidth) / 2, (pnlMain.Height - fheight) / 2)
        'ctrlFrame.Controls.Add(windowtype)
        'pnlMain.Controls.Add(ctrlFrame)
        'AddHandler ctrlFrame.Paint, AddressOf obj_Paint
    End Sub
End Class
