Option Explicit On
Option Strict On

Public Class frmDashboard

    Private mItem As New Item
    Private mReceive As New Receiving
    Private mReplenish As New Replenish

    Private Sub frmDashboard_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTotalNumberItem.Text = mItem.getTotalItems.ToString
        lblTotalNumberPieces.Text = mItem.getTotalPiece.ToString
        lblTotalNumberCases.Text = mItem.getNumberCases.ToString

        lblReplenish.Text = mReplenish.getTotalItems.ToString
        lblOutOfStock.Text = mReplenish.getOutStock.ToString
        lblOverstock.Text = mReplenish.getOverstock.ToString

        mReceive.OnOrder()

        lblReceiveItem.Text = mReceive.getTotalItems.ToString
        lblReceivePiece.Text = mReceive.getTotalPiece.ToString
        lblReceiveCase.Text = mReceive.getNumberCases.ToString

    End Sub
End Class