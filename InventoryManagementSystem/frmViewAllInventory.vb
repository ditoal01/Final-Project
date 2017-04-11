Option Explicit On
Option Strict On

Public Class frmViewAllInventory

    Private selectedItem As String
    Private mDept As New Department

    Private Sub btnViewItem_Click(sender As Object, e As EventArgs) Handles btnViewItem.Click

        'Create view inventory form
        Dim viewInventory As New frmViewInventory
        'set view inventory MDI parent to parent form
        viewInventory.MdiParent = Me.ParentForm
        viewInventory.WindowState = FormWindowState.Maximized
        viewInventory.Show()

        viewInventory.input(CInt(selectedItem))
    End Sub

    Private Sub btnUpdateItem_Click(sender As Object, e As EventArgs) Handles btnUpdateItem.Click
        'Create update inventory form
        Dim updateInventoryForm As New frmUpdateInventory
        'Set update MDI parent to parent form
        updateInventoryForm.MdiParent = Me.ParentForm
        updateInventoryForm.WindowState = FormWindowState.Maximized
        updateInventoryForm.Show()

        updateInventoryForm.input(CInt(selectedItem))
    End Sub

    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        'Create delete form
        Dim deleteInventory As New frmDeleteInventory
        'Set delete MDI parent to parent form
        deleteInventory.MdiParent = Me.ParentForm
        deleteInventory.WindowState = FormWindowState.Maximized
        deleteInventory.Show()

        deleteInventory.input(CInt(selectedItem))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    Private Sub frmViewAllInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub frmViewAllInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mItems As New Item
        dgvDepartment.DataSource = mItems.Items
        selectedItem = dgvDepartment.Item(0, 0).Value.ToString
        cboDepartment.DataSource = mDept.Dept()
        cboDepartment.DisplayMember = "dept"
        cboDepartment.ValueMember = "dept"

    End Sub

    Private Sub dgvDepartment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDepartment.CellClick
        Dim i As Integer
        i = e.RowIndex
        selectedItem = dgvDepartment.Item(0, i).Value.ToString
    End Sub
End Class