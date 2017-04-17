Option Explicit On
Option Strict On

Public Class frmDeleteDepartment

    Private mDept As New Department

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    Private Sub frmDeleteDepartment_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If mDept.Delete(CInt(cboDeleteDepartment.SelectedValue)) Then
        Else
            MessageBox.Show("Unable to delete the item")
        End If
        loadCombo()

    End Sub

    Private Sub frmDeleteDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadCombo()

    End Sub

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