Option Explicit On
Option Strict On

Public Class frmUpdateDepartment
    Private mDept As New Department
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    Private Sub frmUpdateDepartment_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim dept = CInt(cboSelectDepartment.SelectedValue.ToString)
        'Dim newDept = CInt(txtChange.Text)
        Dim description = txtDescription.Text

        If mDept.Update(dept, description) Then
        Else
            'Item.LastError = "Cannot update department"
        End If

    End Sub

    Private Sub frmUpdateDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With cboSelectDepartment
            .DataSource = mDept.Dept()
            .DisplayMember = "dept"
            .ValueMember = "dept"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = -1
        End With
    End Sub

End Class