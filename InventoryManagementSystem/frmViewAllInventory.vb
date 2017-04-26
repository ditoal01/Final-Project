Option Explicit On
Option Strict On

Public Class frmViewAllInventory
    'Class variables
    Private selectedItem As String
    Private mDept As New Department
    Private mItems As New Item
    Private formLoading As Boolean = True
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' View item button handler that sets parent
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnViewItem_Click(sender As Object, e As EventArgs) Handles btnViewItem.Click

        'Create view inventory form
        Dim viewInventory As New frmViewInventory
        'set view inventory MDI parent to parent form
        viewInventory.MdiParent = Me.ParentForm
        viewInventory.WindowState = FormWindowState.Maximized
        viewInventory.Show()

        viewInventory.input(CInt(selectedItem))
    End Sub

    ''' <summary>
    ''' Update button that calls update form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnUpdateItem_Click(sender As Object, e As EventArgs) Handles btnUpdateItem.Click
        'Create update inventory form
        Dim updateInventoryForm As New frmUpdateInventory
        'Set update MDI parent to parent form
        updateInventoryForm.MdiParent = Me.ParentForm
        updateInventoryForm.WindowState = FormWindowState.Maximized
        updateInventoryForm.Show()

        updateInventoryForm.input(CInt(selectedItem))
    End Sub

    ''' <summary>
    ''' Delete button that calls delete form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        'Create delete form
        Dim deleteInventory As New frmDeleteInventory
        'Set delete MDI parent to parent form
        deleteInventory.MdiParent = Me.ParentForm
        deleteInventory.WindowState = FormWindowState.Maximized
        deleteInventory.Show()

        deleteInventory.input(CInt(selectedItem))
    End Sub

    ''' <summary>
    ''' Cancel button that calls dashboard
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    ''' <summary>
    ''' Close form when deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmViewAllInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Load form that sets frm, updates datagridview and loads form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmViewAllInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        frm.clearStatus()

        dgvDepartment.DataSource = mItems.Items
        If dgvDepartment.RowCount > 0 Then
            selectedItem = dgvDepartment.Item(0, 0).Value.ToString
            cboDepartment.DataSource = mDept.Dept()
            cboDepartment.DisplayMember = "dept"
            cboDepartment.ValueMember = "dept"
            cboDepartment.SelectedIndex = -1
            frm.UpdateStatus("Select item and choose button to update database.")
        Else
            frm.UpdateStatus("Database is empty.")
        End If


        formLoading = False

    End Sub

    ''' <summary>
    ''' Set cell click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvDepartment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDepartment.CellClick
        Dim i As Integer
        i = e.RowIndex

        selectedItem = dgvDepartment.Item(0, i).Value.ToString
    End Sub

    ''' <summary>
    ''' Check is selected is changed in datagridview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        If Not formLoading Then
            Dim custId As Short = CShort(cboDepartment.SelectedValue)
            dgvDepartment.DataSource = mItems.GetDept(custId)
        End If

    End Sub
End Class