Option Explicit On
Option Strict On

Public Class frmOrderItem
    'Class variable
    Private mItems As New Item
    Private mReplenish As New Replenish
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' Cancel button handler that calls dashboard form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI Parent form to parent
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    ''' <summary>
    ''' Keypress handler that limits input for textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' Keypress handler that limits input for textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtOrder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrder.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Close form when deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOrderItem_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' load form that sets frm to parent and updates status label
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmOrderItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        frm.UpdateStatus("Enter item number to create an order.")
    End Sub

    ''' <summary>
    ''' Function that checks if id is found
    ''' </summary>
    ''' <param name="pId">item number</param>
    ''' <returns>if item is found</returns>
    Private Function search(ByVal pId As Integer) As Boolean

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow

        row = mItems.FindItem(pId)
        'Check if row is found, update form
        If row IsNot Nothing Then
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
        Else
            Return False
        End If


    End Function

    ''' <summary>
    ''' Search button handler that searchs for item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim id As Integer
        'check if textbox is empty
        If txtLookup.Text = String.Empty Then
            errorProvider.SetError(txtLookup, txtLookup.Text.ToString & " is empty")
            frm.clearStatus()
            Exit Sub
        End If
        'try to parse input
        If Integer.TryParse(txtLookup.Text, id) Then
            If search(id) Then
                frm.UpdateStatus("Item found in database.")
            Else
                frm.UpdateStatus("Item not found in database.")
            End If
        End If
    End Sub



    ''' <summary>
    ''' Order button handler that orders item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        'Check if textbox is empty
        If txtOrder.Text = String.Empty Then
            errorProvider.SetError(txtOrder, txtOrder.Name.ToString & " is empty")
            Exit Sub
        End If
        'Check if textbox is empty
        If txtLookup.Text = String.Empty Then
            errorProvider.SetError(txtOrder, txtOrder.Name.ToString & " is empty")
            Exit Sub
        End If
        'Check if item can be oreder
        If mReplenish.OnOrder(CInt(txtLookup.Text), CInt(txtOrder.Text)) Then
            frm.UpdateStatus("Order has been created for " & txtLookup.Text)
        Else
            frm.UpdateStatus("Item could not be ordered.")
        End If
    End Sub
End Class