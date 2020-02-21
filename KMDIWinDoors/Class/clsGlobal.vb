Public Class clsGlobal


    Sub AddTransom(obj As Object,
                   twidth As Integer)
        Dim newPnl4wdw As New Panel
        Dim ExistingCtrlWdw As Object = obj.Controls(0)
        Dim newctlWdw As New ctlWdw
        Dim ctlTransom As New ctlTransom
        Dim newWdwWidth As Integer = (ExistingCtrlWdw.Width - twidth) / 2
        With ctlTransom
            .Name = "Transom" & .TabIndex
            .Dock = DockStyle.Right
            .Width = twidth
            '.Dock = DockStyle.Fill
        End With

        With newPnl4wdw
            .Name = "newPnl4wdw" & .TabIndex
            .Dock = DockStyle.Right
            .Width = newWdwWidth
        End With

        With ExistingCtrlWdw
            .Name = "ExistingCtrlWdw" & .TabIndex
            .Dock = DockStyle.Fill
            '.Dock = DockStyle.Left
            '.Width = newWdwWidth
        End With

        With newctlWdw
            .Name = "newctlWdw" & .TabIndex
            .Dock = DockStyle.Fill
            .wdwtype = "Fixed"
        End With

        newPnl4wdw.Controls.Add(newctlWdw)
        obj.Controls.Add(newPnl4wdw)
        obj.Controls.Add(ctlTransom)
        ctlTransom.BringToFront()
        ExistingCtrlWdw.BringToFront()
    End Sub

End Class
