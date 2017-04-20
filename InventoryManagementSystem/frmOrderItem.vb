Option Explicit On
Option Strict On

Public Class frmOrderItem
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.ReceivingTableAdapter
    Private adapterItem As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter
    Private mItems As New Item

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI Parent form to parent
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

    Private Sub txtOrder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrder.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmOrderItem_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub frmOrderItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim id As Integer
        id = CInt(txtLookup.Text)
        search(id)
    End Sub

    Public Sub OnOrder(ByVal id As Integer, ByVal order As Integer)
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable = adapterItem.GetData()
        Dim row As InventoryManagementSystemDataSet.ItemDetailRow
        Dim LastError As String
        Dim check As Boolean = False

        Try
            adapter.Insert(id, order, check)
        Catch ex As Exception
            LastError = ex.Message & ", Unable to create orders"
        End Try
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        OnOrder(CInt(txtLookup.Text), CInt(txtOrder.Text))
    End Sub
End Class