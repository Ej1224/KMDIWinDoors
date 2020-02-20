Public Class frmMain
    Dim myGraphics As Graphics
    Dim blackPen As New Pen(Color.Black)
    Dim curr_fheight, curr_fwidth, curr_type As Integer

    Sub CreateWndr(wdrWidth As Integer,
                   wdrHeight As Integer,
                   wdrType As String)
        Dim ctlFrame As New ctlFrame
        With ctlFrame
            .Dock = DockStyle.Fill
            .curr_type = curr_type
        End With

        With pnlEditor
            .Width = wdrWidth + 40
            .Height = wdrHeight + 40
            .Location = New Point((pnlMain.Width - wdrWidth) / 2, (pnlMain.Height - wdrHeight) / 2)
            .Visible = True
            .Controls.Add(ctlFrame)
        End With

        Dim ctlWdw As New ctlWdw()
        ctlWdw.Dock = DockStyle.Fill
        ctlWdw.wdwtype = wdrType

        ctlFrame.Controls.Add(ctlWdw)
        ctlFrame.Invalidate()
        'pnlFrame.Controls.Add(ctlWdw)
        'pnlFrame.Invalidate()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tscZoom.Text = "50 %"
        numHeight.Maximum = Decimal.MaxValue
        numWidth.Maximum = Decimal.MaxValue
        curr_type = 53
    End Sub
    Private Sub C70ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles C70ToolStripMenuItem.Click
        curr_fheight = 300
        curr_fwidth = 300
        curr_type = 53

        cbxType.SelectedIndex = 0
        numHeight.Value = curr_fheight
        numWidth.Value = curr_fwidth

        CreateWndr(curr_fwidth, curr_fheight, "Fixed")
    End Sub

    Private Sub numDimensions_ValueChanged(sender As Object, e As EventArgs) Handles numWidth.ValueChanged, numHeight.ValueChanged
        Try
            If sender Is numHeight Then
                curr_fheight = numHeight.Value
            ElseIf sender Is numWidth Then
                curr_fwidth = numWidth.Value
            End If

            With pnlEditor
                .Width = curr_fwidth + 40
                .Height = curr_fheight + 40
                .Location = New Point((pnlMain.Width - .Width) / 2, (pnlMain.Height - .Height) / 2)
            End With

            If pnlEditor.Controls.Count > 0 Then
                pnlEditor.Controls(0).Invalidate()
            End If
            If pnlEditor.Controls.Count > 0 Then pnlEditor.Controls(0).Controls(0).Invalidate()
            'pnlFrame.Invalidate()
            'If pnlFrame.Controls.Count > 0 Then pnlFrame.Controls(0).Invalidate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cbxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxType.SelectedIndexChanged
        If cbxType.SelectedIndex = 0 Then
            curr_type = 53
        ElseIf cbxType.SelectedIndex = 1 Then
            curr_type = 67
        End If

        If pnlEditor.Controls.Count > 0 Then
            pnlEditor.Controls(0).Padding = New Padding(curr_type)
            'pnlEditor.Controls(0).Padding = New Padding(curr_type)
            pnlEditor.Controls(0).Invalidate()
        End If
        If pnlEditor.Controls.Count > 0 Then pnlEditor.Controls(0).Controls(0).Invalidate()

        'pnlFrame.Padding = New Padding(curr_type)
        'pnlFrame.Invalidate()
        'If pnlFrame.Controls.Count > 0 Then pnlFrame.Controls(0).Invalidate()
    End Sub

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
    Dim iniLoc, movLoc, diff As Integer

    Private Sub pnlMain_SizeChanged(sender As Object, e As EventArgs) Handles pnlMain.SizeChanged
        Dim cX, cY As Integer
        cX = (sender.Width - pnlEditor.Width) / 2
        cY = (sender.Height - pnlEditor.Height) / 2

        If cX > 0 And cY > 0 Then
            pnlEditor.Location = New Point(cX, cY)
        ElseIf cX < 0 And cY > 0 Then
            pnlEditor.Location = New Point(100, 100)
        ElseIf cX > 0 And cY < 0 Then
            pnlEditor.Location = New Point(100, 100)
        Else
            pnlEditor.Location = New Point(100, 100)
        End If
    End Sub

    Private Sub pnlFrame_Paint(sender As Object, e As PaintEventArgs) Handles pnlFrame.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim w As Integer = 2
        Dim w2 As Integer = CInt(Math.Floor(w / 2))
        e.Graphics.DrawRectangle(New Pen(Color.Black, w),
                                 New Rectangle(w2, w2,
                                               sender.ClientRectangle.Width - w,
                                               sender.ClientRectangle.Height - w))

        Dim corner_points() As Point = {
            New Point(0, 0),
            New Point(curr_type, curr_type),
            New Point(pnlFrame.Width, 0),
            New Point(pnlFrame.Width - curr_type, curr_type),
            New Point(0, pnlFrame.Height),
            New Point(curr_type, pnlFrame.Height - curr_type),
            New Point(pnlFrame.Width, pnlFrame.Height),
            New Point(pnlFrame.Width - curr_type, pnlFrame.Height - curr_type)
        }

        For i = 0 To corner_points.Count - 1 Step 2
            e.Graphics.DrawLine(blackPen, corner_points(i), corner_points(i + 1))
        Next
    End Sub

#Region "ToDragTransom"
    Private Sub ToDragTransom_MouseDown(sender As Object, e As MouseEventArgs)
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        iniLoc = sender.Location.X
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub ToDragTransom_MouseMove(sender As Object, e As MouseEventArgs)
        If allowCoolMove = True Then
            Dim objectToMove As Object = Nothing
            objectToMove = sender
            movLoc = objectToMove.Location.X + e.X - myCoolPoint.X
            diff = iniLoc - movLoc
        End If
    End Sub

    Private Sub ToDragTransom_MouseUp(sender As Object, e As MouseEventArgs)
        'Dim movdWidthPnl2 As Integer = Panel2.Width - diff,
        '    movdWidthPnl3 As Integer = Panel3.Width + diff
        'If movdWidthPnl2 > 30 And movdWidthPnl3 > 30 Then
        '    Panel2.Width -= diff
        '    Panel3.Width += diff
        'End If

        allowCoolMove = False
        Cursor = Cursors.Default
    End Sub
#End Region

#Region "CreateFrame"
    Sub CreateFrame(fheight As Integer,
                    fwidth As Integer,
                    Type As Integer)

        myGraphics = Graphics.FromHwnd(pnlMain.Handle)

        Dim center_X As Integer = (pnlMain.Width - fwidth) / 2,
            center_Y As Integer = (pnlMain.Height - fheight) / 2

        'Dim center_X As Integer = 0,
        '    center_Y As Integer = 0

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
        'For i = 0 To corner_points.Count - 1 Step 2
        '    myGraphics.DrawLine(blackPen, corner_points(i), corner_points(i + 1))
        'Next
        myGraphics.DrawRectangles(blackPen, frames)

        'ctrlFrame.Location = New Point((pnlMain.Width - fwidth) / 2, (pnlMain.Height - fheight) / 2)
        'ctrlFrame.Controls.Add(windowtype)
        'pnlMain.Controls.Add(ctrlFrame)
        'AddHandler ctrlFrame.Paint, AddressOf obj_Paint
    End Sub

#End Region
End Class
