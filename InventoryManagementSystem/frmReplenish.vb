Option Explicit On
Option Strict On

Public Class frmReplenish
    Private mReplenish As New Replenish
    Private mItem As New Item
    Private selectedItem As String

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI Parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    Private Sub frmReplenish_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub frmReplenish_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FrmLoad()


    End Sub

    Private Sub Search(ByVal pId As Integer)
        Dim rowItem As InventoryManagementSystemDataSet.ItemRow
        Dim rowDetail As InventoryManagementSystemDataSet.ItemDetailRow

        rowItem = mItem.FindItem(pId)
        rowDetail = mItem.FindDetail(pId)
        If rowItem IsNot Nothing And rowDetail IsNot Nothing Then
            lblItemNumber.Text = rowItem.Id.ToString
            lblUPCNumber.Text = rowItem.upc.ToString
            lblDescription.Text = rowItem.description.ToString
            lblDepartmentNumber.Text = rowItem.dept.ToString
            lblInventory.Text = rowItem.inventory.ToString
            lblShelfCap.Text = rowDetail.shelfcap.ToString
            lblCaseQuanity.Text = rowDetail.casequanity.ToString
            lblSalesRate.Text = rowDetail.rate.ToString
            lblShelfTotal.Text = rowDetail.invshelf.ToString
            lblBackroomTotal.Text = rowDetail.invback.ToString
        Else

        End If
    End Sub

    Private Sub dgvReplenish_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReplenish.CellClick
        Dim i As Integer
        i = e.RowIndex

        selectedItem = dgvReplenish.Item(0, i).Value.ToString
        Search(CInt(selectedItem))
    End Sub

    Private Sub btnReplenish_Click(sender As Object, e As EventArgs) Handles btnReplenish.Click
        mReplenish.UpdateInv(selectedItem)
        dgvReplenish.DataSource = mReplenish.Replenish
        If dgvReplenish.RowCount >= 1 Then
            selectedItem = dgvReplenish.Item(0, 0).Value.ToString
            Search(CInt(selectedItem))
        Else
            selectedItem = String.Empty
        End If
        FrmLoad()
    End Sub

    Private Sub FrmLoad()
        dgvReplenish.DataSource = mReplenish.Replenish

        If dgvReplenish.RowCount > 0 Then
            selectedItem = dgvReplenish.Item(0, 0).Value.ToString
            Search(CInt(selectedItem))
        Else
            lblItemNumber.Text = String.Empty
            lblUPCNumber.Text = String.Empty
            lblDescription.Text = String.Empty
            lblDepartmentNumber.Text = String.Empty
            lblInventory.Text = String.Empty
            lblShelfCap.Text = String.Empty
            lblCaseQuanity.Text = String.Empty
            lblSalesRate.Text = String.Empty
            lblShelfTotal.Text = String.Empty
            lblBackroomTotal.Text = String.Empty
        End If
    End Sub

End Class