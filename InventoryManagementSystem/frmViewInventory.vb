Option Explicit On
Option Strict On

Public Class frmViewInventory
    'Class variables
    Private mItems As New Item
    Private mReceive As New Receiving
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' Cancel button that calls dashboard
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frm.clearStatus()
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
    ''' Close form when deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmViewInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Search button that searches item in database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim id As Integer
        'Check is textbox is empty
        If txtLookup.Text = String.Empty Then
            errorProvider.SetError(txtLookup, txtLookup.Text.ToString & " is empty")
            frm.clearStatus()
            Exit Sub
        End If
        'Check if input can be parsed and search for item
        If Integer.TryParse(txtLookup.Text, id) Then
            search(id)
        Else
            frm.UpdateStatus("Unable to find item in database.")
            txtLookup.Text = String.Empty
            txtLookup.Focus()
            Clear()
        End If

    End Sub

    ''' <summary>
    ''' Form load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmViewInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        frm.UpdateStatus("Enter item number to view item details.")
    End Sub

    ''' <summary>
    ''' Search for item in database
    ''' </summary>
    ''' <param name="pId">item number</param>
    Public Sub input(ByVal pId As Integer)
        txtLookup.Text = pId.ToString
        search(pId)
    End Sub

    ''' <summary>
    ''' Search for item in database and update form
    ''' </summary>
    ''' <param name="pId"></param>
    Private Sub search(ByVal pId As Integer)

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow
        Dim row4 As InventoryManagementSystemDataSet.ReceivingRow
        'Search for item
        Try
            row = mItems.FindItem(pId)
        Catch ex As Exception
            txtLookup.Text = String.Empty
            txtLookup.Focus()
            frm.UpdateStatus("Unable to find Item in database.")
            Clear()
            Exit Sub
        End Try
        'Check if row is nothing then update form
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

            row4 = mReceive.FindById(pId)
            If row4 IsNot Nothing Then
                lblOnOrder.Text = row4.OnOrder.ToString()
                lblOrderDate.Text = row4.receivingDate.ToString("d")
                lblReceived.Text = row4.ready.ToString()
            End If
            frm.UpdateStatus("Item found in database.")
            Exit Sub
        Else
            txtLookup.Text = String.Empty
            txtLookup.Focus()
            frm.UpdateStatus("Unable to find Item in database.")
            Clear()
        End If
    End Sub

    ''' <summary>
    ''' Clear form
    ''' </summary>
    Private Sub Clear()
        For Each grp As GroupBox In Controls.OfType(Of GroupBox)
            For Each lbl As Label In grp.Controls.OfType(Of Label)
                If lbl.Name.Contains("lbl") Then
                    lbl.Text = ""
                End If
            Next
        Next
    End Sub

End Class