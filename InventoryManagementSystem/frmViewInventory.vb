Option Explicit On
Option Strict On

Public Class frmViewInventory

    Private mItems As New Item
    Private mReceive As New Receiving

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
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

    Private Sub frmViewInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim id As Integer
        id = CInt(txtLookup.Text)
        search(id)
        'lblItemNumber.Text = mItems.Items.Rows(0)(0).ToString()
    End Sub

    Private Sub frmViewInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub input(ByVal pId As Integer)
        txtLookup.Text = pId.ToString
        search(pId)
    End Sub

    Private Function search(ByVal pId As Integer) As Boolean

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow
        Dim row4 As InventoryManagementSystemDataSet.ReceivingRow

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

        row4 = mReceive.FindById(pId)
        If row4 IsNot Nothing Then
            lblOnOrder.Text = row4.OnOrder.ToString()
            lblOrderDate.Text = row4.receivingDate.ToString("d")
            lblReceived.Text = row4.ready.ToString()
        End If



        Return True

    End Function

End Class