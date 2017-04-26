Option Explicit On
Option Strict On

Public Class frmDeleteInventory
    'Class variables
    Private mItems As New Item
    Private mReceive As New Receiving
    Private frm As New frmMainInventoryForm
    ''' <summary>
    ''' Cancel button handler that calls dashboard form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI Parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub
    ''' <summary>
    ''' Keypress Handler that only allows numbers entered into lookup textbox
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
        txtLookup.MaxLength = 6
    End Sub
    ''' <summary>
    ''' Closes form when deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmDeleteInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub
    ''' <summary>
    ''' Search button handler that searches for an item in database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Check is textbox is empty
        If txtLookup.Text = String.Empty Then
            errorProvider.SetError(txtLookup, txtLookup.Name.ToString & " is empty")
            Exit Sub
        End If
        Dim id As Integer
        'if statement to check if input can be parsed
        If Integer.TryParse(txtLookup.Text, id) Then
            search(id)
        Else
            frm.UpdateStatus("Item not found in database.")
        End If


    End Sub

    ''' <summary>
    ''' Procedure that searches for item in database and updates form
    ''' </summary>
    ''' <param name="pId">item number</param>
    Private Sub search(ByVal pId As Integer)

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow
        Dim row4 As InventoryManagementSystemDataSet.ReceivingRow
        'Check if item exist
        Try
            row = mItems.FindItem(pId)
        Catch ex As Exception
            txtLookup.Text = String.Empty
            txtLookup.Focus()
            frm.UpdateStatus("Unable to find Item in database.")
            Exit Sub
        End Try
        'if row isnot nothing then update form
        If row IsNot Nothing Then
            'update form
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

            row4 = mReceive.FindById(pId)
            If row4 IsNot Nothing Then
                lblOnOrder.Text = row4.OnOrder.ToString()
                lblOrderDate.Text = row4.receivingDate.ToString("d")
                lblReceived.Text = row4.ready.ToString()
            End If
            frm.UpdateStatus("Item found in database")

            ' update status label if error
        Else
            txtLookup.Text = String.Empty
            txtLookup.Focus()
            frm.UpdateStatus("Unable to find Item in database.")
        End If

    End Sub

    ''' <summary>
    ''' Procedure that searches for item number
    ''' </summary>
    ''' <param name="pId">item number</param>
    Public Sub input(ByVal pId As Integer)
        txtLookup.Text = pId.ToString
        search(pId)
    End Sub
    ''' <summary>
    ''' Delete handler that deletes item from database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim item As Integer
        'If statement that checks if input can be parsed
        If Integer.TryParse(txtLookup.Text, item) Then
            If mItems.Delete(CInt(item)) Or mReceive.Delete(CInt(item)) Then
                clear()
                frm.UpdateStatus("Item deleted")
            Else

                frm.UpdateStatus("Unable to delete the item")
            End If
        Else
            frm.UpdateStatus("Enter a correct item number")
            txtLookup.Clear()
            txtLookup.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Procedure that clears form
    ''' </summary>
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
    ''' <summary>
    ''' form load that sets frm variable to parent and update status label
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmDeleteInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        frm.UpdateStatus("Enter item number to delete from database.")
    End Sub
End Class