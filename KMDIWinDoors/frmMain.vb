Public Class frmMain
    Dim myGraphics As Graphics
    Dim blackPen As New Pen(Color.Black)
    Dim curr_fheight, curr_fwidth, curr_type As Integer
    Sub CreateFrame(ctrlFrame As ctlFrame,
                    fheight As Integer,
                    fwidth As Integer,
                    Type As Integer)

        myGraphics = Graphics.FromHwnd(ctrlFrame.Handle)

        'Dim center_X As Integer = (pnlMain.Width - fwidth) / 2,
        '    center_Y As Integer = (pnlMain.Height - fheight) / 2

        Dim center_X As Integer = 0,
            center_Y As Integer = 0

        Dim innf_width As Integer = fwidth - Type,
            innf_height As Integer = fheight - Type

        Dim innf_cX As Integer = ((fwidth - innf_width) / 2) + center_X,
            innf_cY As Integer = ((fheight - innf_height) / 2) + center_Y

        Dim graybrush As New SolidBrush(Color.Gray)
        Dim innf_rect As New Rectangle(innf_cX, innf_cY, innf_width, innf_height)
        Dim corner_points() As Point = {
            New Point(center_X, center_Y),
            New Point(innf_cX, innf_cY),
            New Point(center_X + fwidth, center_Y),
            New Point(innf_cX + innf_width, innf_cY),
            New Point(center_X, center_Y + fheight),
            New Point(innf_cX, innf_cY + innf_height),
            New Point(center_X + fwidth, center_Y + fheight),
            New Point(innf_cX + innf_width, innf_cY + innf_height)
        }

        Dim frames As Rectangle() = {
            New Rectangle(center_X, center_Y, fwidth, fheight),
           innf_rect
        }

        Dim windowtype As New Label
        With windowtype
            .Text = "Fixed"
            .Font = New Font("Segoe UI", 12)
            .Location = New Point((innf_width - .Width) / 2, (innf_height - .Height) / 2)
        End With

        myGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        myGraphics.FillRectangle(graybrush, innf_rect)
        For i = 0 To corner_points.Count - 1 Step 2
            myGraphics.DrawLine(blackPen, corner_points(i), corner_points(i + 1))
        Next
        myGraphics.DrawRectangles(blackPen, frames)

        ctrlFrame.Location = New Point((pnlMain.Width - fwidth) / 2, (pnlMain.Height - fheight) / 2)
        ctrlFrame.Controls.Add(windowtype)
        pnlMain.Controls.Add(ctrlFrame)
        AddHandler ctrlFrame.Paint, AddressOf obj_Paint
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tscZoom.Text = "50 %"
        numHeight.Maximum = Decimal.MaxValue
        numWidth.Maximum = Decimal.MaxValue

    End Sub
    Private Sub C70ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles C70ToolStripMenuItem.Click
        curr_fheight = 300
        curr_fwidth = 300
        curr_type = 53

        cbxType.SelectedIndex = 0
        numHeight.Value = curr_fheight
        numWidth.Value = curr_fwidth

        Dim ctlFrame As New ctlFrame()
        ctlFrame.curr_fheight = 300
        ctlFrame.curr_fwidth = 300
        ctlFrame.Width = 300
        ctlFrame.Height = 300
        ctlFrame.Location = New Point((pnlMain.Width - ctlFrame.Width) / 2, (pnlMain.Height - ctlFrame.Height) / 2)
        pnlMain.Controls.Add(ctlFrame)
        'CreateFrame(ctlFrame, curr_fheight, curr_fwidth, curr_type)
        'pnlMain.Controls(0).Invalidate()
    End Sub

    Private Sub numDimensions_ValueChanged(sender As Object, e As EventArgs) Handles numWidth.ValueChanged, numHeight.ValueChanged
        Try
            If sender Is numHeight Then
                curr_fheight = numHeight.Value
            ElseIf sender Is numWidth Then
                curr_fwidth = numWidth.Value
            End If

            'pnlMain.Controls(0).Invalidate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlMain.Controls(0).Size = New Size(300, 300)
        pnlMain.Controls(0).Location = New Point((pnlMain.Width - pnlMain.Controls(0).Width) / 2, (pnlMain.Height - pnlMain.Controls(0).Height) / 2)
        MsgBox(pnlMain.Controls(0).Name.ToString & vbCrLf & pnlMain.Controls(0).Size.ToString)
    End Sub

    Private Sub cbxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxType.SelectedIndexChanged
        If cbxType.SelectedIndex = 0 Then
            curr_type = 53
        ElseIf cbxType.SelectedIndex = 1 Then
            curr_type = 67
        End If
        'pnlMain.Controls(0).Invalidate()
    End Sub

    Private Sub obj_Paint(sender As Object, e As PaintEventArgs)
        'Dim ctlFrame As New ctlFrame()
        'CreateFrame(ctlFrame, curr_fheight, curr_fwidth, curr_type)
    End Sub

End Class
