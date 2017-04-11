Option Explicit On
Option Strict On

Public Class frmTransaction
    Private mItems As New Item
    Private mTotal, mSubTotal As Decimal
    Private Const mTax As Decimal = 0.07D
    Private mList As New ArrayList

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    Private Sub txtAddItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddItem.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        txtAddItem.MaxLength = 12
    End Sub

    Private Sub frmTransaction_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub calculate()


        Dim price, tempTax As Decimal
        mSubTotal = 0D
        For Each price In mList
            mSubTotal += price
        Next

        tempTax = mSubTotal * mTax
        mTotal = mSubTotal + tempTax

        lblTotalItem.Text = mList.Count.ToString
        lblSubTotal.Text = mSubTotal.ToString("C")
        lblTax.Text = tempTax.ToString("C")
        lblTotal.Text = mTotal.ToString("C")
        txtAddItem.Clear()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim id As Integer
        id = CInt(txtAddItem.Text)
        lstRegister.Items.Add(Search(id))
        calculate()

    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        mList.RemoveAt(lstRegister.SelectedIndex)
        lstRegister.Items.RemoveAt(lstRegister.SelectedIndex)
        calculate()
    End Sub

    Private Function Search(ByVal pId As Integer) As String
        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow

        row = mItems.FindItem(pId)
        row3 = mItems.FindSale(pId)
        mList.Add(row3.price)
        Return row.upc.ToString & vbTab & row.description & vbTab & row3.price.ToString("c")

    End Function

End Class