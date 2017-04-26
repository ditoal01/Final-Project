Option Explicit On
Option Strict On

Public Class frmDashboard
    'Class level variables
    Private mItem As New Item
    Private mReceive As New Receiving
    Private mReplenish As New Replenish
    Private frm As New frmMainInventoryForm
    ''' <summary>
    ''' Close form when deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmDashboard_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub
    ''' <summary>
    ''' Form load that loads information into labels
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set frm variable to parent
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        frm.clearStatus()
        frm.UpdateStatus("Welcome to Inventory Management System")
        'Update labels
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

        lstExceptions.View = View.Details
        lstExceptions.Columns.Add("Id", 70, HorizontalAlignment.Left)
        lstExceptions.Columns.Add("UPC", 100, HorizontalAlignment.Left)
        lstExceptions.Columns.Add("Desciption", 210, HorizontalAlignment.Left)
        lstExceptions.Columns.Add("Inventory", 60, HorizontalAlignment.Left)
        'Set variables
        Dim count As Integer = 0
        Dim cnt As Integer = 0
        Dim check As Boolean = True
        Dim str(3) As String
        Dim strTotal(mItem.updateDashboard.Count) As String
        Dim itm As ListViewItem
        'for loop that inserts items to list view
        For Each item In mItem.updateDashboard
            str(count) = item.ToString

            If count = 3 Then
                itm = New ListViewItem(str)
                lstExceptions.Items.Add(itm)
                count = 0
            Else
                count += 1
            End If
            cnt += 1
        Next
        itm = New ListViewItem("")
        lstExceptions.Items.Add(itm)
    End Sub
End Class