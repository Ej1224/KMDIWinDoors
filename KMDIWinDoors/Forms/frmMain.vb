Imports System.Drawing.Drawing2D
Public Class frmMain
    Dim myGraphics As Graphics
    Dim blackPen As New Pen(Color.Black)
    Dim curr_fheight, curr_fwidth As Integer ', curr_type

    Sub CreateWndr(wdrWidth As Integer,
                   wdrHeight As Integer,
                   wdrType As String)
        Dim ctlFrame As New ctlFrame
        With ctlFrame
            .Dock = DockStyle.Fill
            '.curr_type = curr_type
        End With

        With pnlEditor
            .Width = wdrWidth + 40
            .Height = wdrHeight + 40
            .Visible = True
            .Controls.Add(ctlFrame)
        End With

        Dim ctlWdw As New ctlWdw()
        ctlWdw.Dock = DockStyle.Fill
        ctlWdw.wdwtype = wdrType

        ctlFrame.Controls.Add(ctlWdw)
        ctlFrame.Invalidate()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tscZoom.Text = "50 %"
        numHeight.Maximum = Decimal.MaxValue
        numWidth.Maximum = Decimal.MaxValue
        curr_type = 53
    End Sub
    Private Sub C70ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles C70ToolStripMenuItem.Click
        curr_fheight = 400
        curr_fwidth = 400
        curr_type = 53

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
        Catch ex As Exception
        MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub pnlMain_SizeChanged(sender As Object, e As EventArgs) Handles pnlMain.SizeChanged
        Dim cX, cY As Integer
        cX = (sender.Width - pnlEditor.Width) / 2
        cY = (sender.Height - pnlEditor.Height) / 2

        pnlEditor.Location = New Point(cX, cY)

        'If cX > 0 And cY > 0 Then
        '    pnlEditor.Location = New Point(cX, cY)
        'ElseIf cX < 0 And cY > 0 Then
        '    pnlEditor.Location = New Point(100, 100)
        'ElseIf cX > 0 And cY < 0 Then
        '    pnlEditor.Location = New Point(100, 100)
        'Else
        '    pnlEditor.Location = New Point(100, 100)
        'End If
    End Sub

    'Private Sub pnlEditor_Paint(sender As Object, e As PaintEventArgs) Handles pnlEditor.Paint
    '    Dim capPath As New GraphicsPath
    '    With capPath
    '        .AddLine(-20, 0, 20, 0)
    '        .AddLine(-20, 0, 0, 20)
    '        .AddLine(0, 20, 20, 0)
    '        .AddString("300",
    '                   family:=New FontFamily("Segoe UI"),
    '                   style:=0,
    '                   emSize:=10,
    '                   origin:=New Point(50, 0),
    '                   format:=New StringFormat(StringFormat.GenericDefault))
    '    End With

    '    blackPen = New Pen(Color.Black)
    '    blackPen.CustomEndCap = New CustomLineCap(Nothing, capPath)

    '    e.Graphics.DrawLine(blackPen, 20, 10, sender.Width - 20, 10)
    'End Sub

#Region "ToDragTransom"

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
    Dim iniLoc, movLoc, diff As Integer

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

        Dim fra As Rectangle()

        fra(1) = New Rectangle(center_X, center_Y, fwidth, fheight)

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
