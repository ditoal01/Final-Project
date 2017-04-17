Option Explicit On
Option Strict On

Public Class frmReceiving
    Private mReceiving As New Receiving

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI Parent to parent
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    Private Sub frmReceiving_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub frmReceiving_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mReceiving.OnOrder()
        dgvReceiveItems.DataSource = mReceiving.receive

    End Sub
End Class