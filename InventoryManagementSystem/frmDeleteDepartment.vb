Option Explicit On
Option Strict On

Public Class frmDeleteDepartment
    'Class variables
    Private mDept As New Department
    Private frm As New frmMainInventoryForm
    ''' <summary>
    ''' Cancel button handler that loads dashboard form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub
    ''' <summary>
    ''' Closes form when deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmDeleteDepartment_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub
    ''' <summary>
    ''' Delete button handler that deletes department from database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        frm.clearStatus()
        errorProvider.Clear()
        'Check if combobox has nothing selected
        If cboDeleteDepartment.SelectedIndex = -1 Then
            errorProvider.SetError(cboDeleteDepartment, "Select a department from list")
            cboDeleteDepartment.Focus()
            Exit Sub
        End If
        'if statement that checks if department is deleted
        If mDept.Delete(CInt(cboDeleteDepartment.SelectedValue)) Then
            frm.UpdateStatus("Department deleted from list.")
        Else 'if not deleted, then update status label
            frm.UpdateStatus("Unable to delete department. Make sure all items are deleted in department")
        End If
        loadCombo() 'call load procedure

    End Sub
    ''' <summary>
    ''' Form load that sets frm variable to parent and calls loadcombo procedure
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmDeleteDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        loadCombo()
        frm.UpdateStatus("Select department number to delete from list.")
    End Sub

    ''' <summary>
    ''' Procedure that sets combobox selection
    ''' </summary>
    Private Sub loadCombo()
        With cboDeleteDepartment
            .DataSource = mDept.Dept()
            .DisplayMember = "dept"
            .ValueMember = "dept"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = -1
        End With
    End Sub

End Class