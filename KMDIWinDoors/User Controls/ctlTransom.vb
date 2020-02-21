Public Class ctlTransom

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
    Dim iniLoc, movLoc, diff As Integer
    Dim pnls(2) As Object
    Dim penColor As Color = Color.Black
    Dim borderWidth As Integer = 1

    Private Sub ToDragTransom_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        iniLoc = sender.Location.X
        Cursor = Cursors.SizeAll
        'MsgBox(sender.Name & vbCrLf & sender.Width)
    End Sub

    Private Sub ToDragTransom_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If allowCoolMove = True Then
            Dim objectToMove As Object = Nothing
            objectToMove = sender
            movLoc = objectToMove.Location.X + e.X - myCoolPoint.X
            diff = iniLoc - movLoc
        End If
    End Sub

    Private Sub ctlTransom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To sender.Parent.Controls.Count - 1
            If sender.Parent.Controls(i).Name.Contains("Transom") = False Then
                pnls(i) = sender.Parent.Controls(i)
            End If
        Next
    End Sub

    Private Sub ToDragTransom_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        Dim movdWidthPnl2 As Integer = pnls(0).Width - diff,
            movdWidthPnl3 As Integer = pnls(1).Width + diff
        If movdWidthPnl2 > 30 And movdWidthPnl3 > 30 Then
            pnls(0).Width -= diff
            pnls(1).Width += diff
        End If

        allowCoolMove = False
        Cursor = Cursors.Default
    End Sub

    Private Sub ctlTransom_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim w As Integer = borderWidth
        Dim w2 As Integer = Math.Floor(w / 2)
        e.Graphics.DrawRectangle(New Pen(penColor, w),
                                 New Rectangle(w2, w2,
                                               sender.ClientRectangle.Width - w,
                                               sender.ClientRectangle.Height - w))

    End Sub

    Private Sub ctlTransom_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        penColor = Color.Blue
        borderWidth = 2
        Invalidate()
    End Sub

    Private Sub ctlTransom_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        penColor = Color.Black
        borderWidth = 1
        Invalidate()
    End Sub

    Private Sub ctlTransom_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If curr_type = 53 Then
            Width = 82
        ElseIf curr_type = 67 Then
            Width = 112
        End If
        Invalidate()
    End Sub
End Class
