Option Explicit On
Option Strict On

Public Class frmTransaction
    'Class variables
    Private mItems As New Item
    Private mTotal, mSubTotal As Decimal
    Private Const mTax As Decimal = 0.07D
    Private mList, mIds As New ArrayList
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.ItemTableAdapter
    Private detailAdapter As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' Cancel button handler that loads dashboard form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    ''' <summary>
    ''' Keypress handler that limits input for textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' Close form when deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmTransaction_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Add button handler that adds item to listbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim id As Integer
        'Check if textbox is empty
        If txtAddItem.Text = String.Empty Then
            errorProvider.SetError(txtAddItem, txtAddItem.Name.ToString & " is empty")
            txtAddItem.Focus()
            Exit Sub
        End If
        'Check if input can be parsed
        If Integer.TryParse(txtAddItem.Text, id) Then
            Dim tempId As String
            tempId = Search(id)
            If tempId <> String.Empty Then
                lstRegister.Items.Add(tempId)
                mIds.Add(id)
                calculate()
                frm.UpdateStatus("Item added to shopping cart")
            Else
                frm.UpdateStatus("Item not found.")
            End If
        Else
            txtAddItem.Clear()
            frm.UpdateStatus("Item could not be added to shopping cart")
        End If

    End Sub

    ''' <summary>
    ''' Complete button handler that updates database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow
        'Update database
        For Each item As Integer In mIds
            row = mItems.FindItem(item)
            row2 = mItems.FindDetail(item)
            row.inventory = row.inventory - 1
            row2.invshelf = row2.invshelf - 1

            adapter.Update(row)
            detailAdapter.Update(row2)
        Next
        frm.UpdateStatus("Transaction Complete.")
        clear()

    End Sub

    ''' <summary>
    ''' Delete button handler that removes item from listbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstRegister.SelectedIndex <> -1 Then
            mList.RemoveAt(lstRegister.SelectedIndex)
            mIds.RemoveAt(lstRegister.SelectedIndex)
            lstRegister.Items.RemoveAt(lstRegister.SelectedIndex)
            calculate()
            frm.UpdateStatus("Item deleted from transaction")
        Else
            frm.UpdateStatus("No item selected to delete from transaction.")
        End If
    End Sub

    ''' <summary>
    ''' Function that searches for item
    ''' </summary>
    ''' <param name="pId">item number</param>
    ''' <returns></returns>
    Private Function Search(ByVal pId As Integer) As String
        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow

        row = mItems.FindItem(pId)
        row3 = mItems.FindSale(pId)
        'Check if row is found
        If row3 IsNot Nothing And row IsNot Nothing Then
            mList.Add(row3.price)
            Return row.upc.ToString & vbTab & row.description & vbTab & row3.price.ToString("c")
        Else
            Return String.Empty
        End If


    End Function

    ''' <summary>
    ''' Form load that sets frm and updates status label
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        frm.UpdateStatus("Enter item number to start transaction")
    End Sub

    ''' <summary>
    ''' Procedure that calculates items
    ''' </summary>
    Private Sub calculate()


        Dim price, tempTax, total As Decimal
        mSubTotal = 0D
        For Each price In mList
            mSubTotal += price
        Next
        'Calculate transaction
        tempTax = mSubTotal * mTax
        mTotal = mSubTotal + tempTax
        total = mList.Count
        'update form
        lblTotalItem.Text = total.ToString
        lblSubTotal.Text = mSubTotal.ToString("C")
        lblTax.Text = tempTax.ToString("C")
        lblTotal.Text = mTotal.ToString("C")
        txtAddItem.Clear()
    End Sub

    ''' <summary>
    ''' Clear procedure that clears form
    ''' </summary>
    Private Sub clear()

        For i As Integer = GroupBox2.Controls.Count - 1 To 0 Step -1
            If TypeOf GroupBox2.Controls(i) Is Label Then
                Dim lbl As Label = CType(GroupBox2.Controls(i), Label)
                If lbl.Name.Contains("lbl") Then
                    lbl.Text = String.Empty
                End If
            End If
        Next
        txtAddItem.Clear()
        lstRegister.Items.Clear()
        mList.Clear()
        mIds.Clear()
    End Sub

End Class