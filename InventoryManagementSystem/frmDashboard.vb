Option Explicit On
Option Strict On

Public Class frmDashboard

    Private mItem As New Item

    Private Sub frmDashboard_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTotalNumberItem.Text = mItem.getTotalItems.ToString
        lblTotalNumberPieces.Text = mItem.getTotalPiece.ToString
        lblTotalNumberCases.Text = mItem.getNumberCases.ToString
    End Sub
End Class