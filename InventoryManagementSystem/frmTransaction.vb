Option Explicit On
Option Strict On

Public Class frmTransaction
    Private mItems As New Item
    Private mTotal, mSubTotal As Decimal
    Private Const mTax As Decimal = 0.07D
    Private mList, mIds As New ArrayList
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.ItemTableAdapter
    Private detailAdapter As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter

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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim id As Integer
        id = CInt(txtAddItem.Text)
        lstRegister.Items.Add(Search(id))
        mIds.Add(id)
        calculate()
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow

        For Each item As Integer In mIds
            row = mItems.FindItem(item)
            row2 = mItems.FindDetail(item)
            row.inventory = row.inventory - 1
            row2.invshelf = row2.invshelf - 1

            adapter.Update(row)
            detailAdapter.Update(row2)
        Next
        clear()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        mList.RemoveAt(lstRegister.SelectedIndex)
        mIds.RemoveAt(lstRegister.SelectedIndex)
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

    Public Function UpdateUPC(ByVal pUPC As String) As String

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow
        Dim table As DataTable = adapter.GetData()

        For Each row In table.Rows
            If row.Item(1).Equals(pUPC) Then
                row.inventory = row.inventory - 1
                row3 = mItems.FindSale(row.Id)
                adapter.Update(row)
            End If
        Next

        Return row.upc.ToString & vbTab & row.description & vbTab & row3.price.ToString("C")
    End Function

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

    Private Sub clear()

        For i As Integer = GroupBox2.Controls.Count - 1 To 0 Step -1
            If TypeOf GroupBox2.Controls(i) Is Label Then
                Dim lbl As Label = CType(GroupBox2.Controls(i), Label)
                lbl.Text = String.Empty
            End If
        Next
        txtAddItem.Clear()
        lstRegister.Items.Clear()
        mList.Clear()
        mIds.Clear()
    End Sub

End Class