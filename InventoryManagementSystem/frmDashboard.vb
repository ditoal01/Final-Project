Option Explicit On
Option Strict On

Public Class frmDashboard
    Private Sub frmDashboard_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub
End Class