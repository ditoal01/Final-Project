Option Explicit On
Option Strict On

Public Class frmViewDepartments
    'Class variable
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' Load dashboard
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
    ''' Close form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmViewDepartments_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Load department information
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmViewDepartments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        Dim mDepartments As New Department
        dgvDepartmentList.DataSource = mDepartments.Dept
        If dgvDepartmentList.RowCount > 0 Then
            frm.UpdateStatus("List of all departments in database.")
        Else
            frm.UpdateStatus("No departments in database.")
        End If
    End Sub
End Class