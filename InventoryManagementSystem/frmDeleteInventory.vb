Option Explicit On
Option Strict On

Public Class frmDeleteInventory
    Private mItems As New Item
    Private frm As New frmMainInventoryForm

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI Parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    Private Sub txtLookup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLookup.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        txtLookup.MaxLength = 12
    End Sub

    Private Sub frmDeleteInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If txtLookup.Text = String.Empty Then
            errorProvider.SetError(txtLookup, txtLookup.Name.ToString & " is empty")
            Exit Sub
        End If

        Dim id As Integer
        id = CInt(txtLookup.Text)
        search(id)


    End Sub

    Private Function search(ByVal pId As Integer) As Boolean

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow

        row = mItems.FindItem(pId)
        lblItemNumber.Text = row.Id.ToString
        lblUPCNumber.Text = row.upc.ToString
        lblDescription.Text = row.description.ToString
        lblDepartmentNumber.Text = row.dept.ToString
        lblInventory.Text = row.inventory.ToString

        row2 = mItems.FindDetail(pId)
        lblShelfCap.Text = row2.shelfcap.ToString
        lblCaseQuanity.Text = row2.casequanity.ToString
        lblSalesRate.Text = row2.rate.ToString
        lblShelfTotal.Text = row2.invshelf.ToString
        lblBackroomTotal.Text = row2.invback.ToString

        row3 = mItems.FindSale(pId)
        lblSalePrice.Text = row3.price.ToString("c")
        lblCost.Text = row3.cost.ToString("c")
        lblMarkUp.Text = mItems.Markup(row3.price, row3.cost).ToString("P")

        Return True

    End Function

    Public Sub input(ByVal pId As Integer)
        txtLookup.Text = pId.ToString
        search(pId)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click


        If mItems.Delete(CInt(lblItemNumber.Text)) Then
            clear()
            mItems.LastStatus = " Item deleted"
        Else

            mItems.LastStatus = "Unable to delete the item"
        End If
        frm.UpdateStatus(mItems.LastStatus)
    End Sub

    Private Sub clear()
        For Each grp As GroupBox In Controls.OfType(Of GroupBox)
            For Each lbl As Label In grp.Controls.OfType(Of Label)
                If lbl.Name.Contains("lbl") Then
                    lbl.Text = String.Empty
                End If
            Next
        Next
        txtLookup.Clear()
    End Sub

End Class