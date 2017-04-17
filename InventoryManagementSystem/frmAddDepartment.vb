Option Explicit On
Option Strict On

Public Class frmAddDepartment

    Private mDept As New Department

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'set dashboard form MDI Parent and then show
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    Private Sub txtAddDepartment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddDepartment.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        txtAddDepartment.MaxLength = 2
    End Sub

    Private Sub frmAddDepartment_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim dept As Integer = CInt(txtAddDepartment.Text)
        Dim deptName As String = txtDepartmentName.Text

        mDept.Insert(dept, deptName)

    End Sub
End Class