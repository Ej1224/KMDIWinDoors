Public Class ctlFrame
    Dim myGraphics As Graphics
    Dim blackPen As New Pen(Color.Black)
    Public curr_fheight, curr_fwidth, curr_type As Integer

    'Private Sub ctlFrame_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
    '    Dim c As Control = TryCast(e.Data.GetData(e.Data.GetFormats()(0)), Control)
    '    If c IsNot Nothing Then
    '        c.Location = PointToClient(New Point(e.X, e.Y))
    '        Controls.Add(c)
    '    End If
    'End Sub

    'Private Sub ctlFrame_DragOver(sender As Object, e As DragEventArgs) Handles MyBase.DragOver
    '    e.Effect = DragDropEffects.Move
    'End Sub
    Private Sub ctlFrame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'myGraphics = Graphics.FromHwnd(Me.Handle)
        'Dim center_X As Integer = (Width - fwidth) / 2,
        '    center_Y As Integer = (pnlMain.Height - fheight) / 2

        'Dim innf_width As Integer = Width - curr_type,
        '    innf_height As Integer = Height - curr_type

        'Dim innf_cX As Integer = ((Width - innf_width) / 2),
        '    innf_cY As Integer = ((Width - innf_height) / 2)

        'Dim graybrush As New SolidBrush(Color.Gray)
        'Dim innf_rect As New Rectangle(innf_cX, innf_cY, innf_width, innf_height)
        'Dim corner_points() As Point = {
        '    New Point(0, 0),
        '    New Point(innf_cX, innf_cY),
        '    New Point(Width, 0),
        '    New Point(innf_cX + innf_width, innf_cY),
        '    New Point(0, Height),
        '    New Point(innf_cX, innf_cY + innf_height),
        '    New Point(Width, Height),
        '    New Point(innf_cX + innf_width, innf_cY + innf_height)
        '}

        'Dim frames As Rectangle() = {
        '    New Rectangle(0, 0, Width, Height),
        '   innf_rect
        '}

        'myGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        'myGraphics.FillRectangle(graybrush, innf_rect)
        'For i = 0 To corner_points.Count - 1 Step 2
        '    myGraphics.DrawLine(blackPen, corner_points(i), corner_points(i + 1))
        'Next
        'myGraphics.DrawString("Fixed", New Font("Segoe UI", 12), New SolidBrush(Color.Black), New Point(innf_cX + innf_width / 2, innf_cY + innf_height / 2))
        'myGraphics.DrawRectangles(blackPen, frames)
    End Sub
End Class
