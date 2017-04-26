Option Explicit On
Option Strict On

Public Class frmUpdateDepartment
    'Class variables
    Private mDept As New Department
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' Cancel Button handler that loads dashboard
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
    ''' Close form when deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmUpdateDepartment_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Update button handler that udpates department in database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frm.clearStatus()
        errorProvider.Clear()
        Dim dept As Integer
        'Check if combobox has selected item
        If cboSelectDepartment.SelectedIndex = -1 Then
            errorProvider.SetError(cboSelectDepartment, "Select a department from list.")
            cboSelectDepartment.Focus()
            Exit Sub
        End If
        'Check if textbox is empty
        If txtDescription.Text = String.Empty Then
            errorProvider.SetError(txtDescription, txtDescription.Name.ToString & " is empty")
            txtDescription.Focus()
            Exit Sub
        End If
        'Check if input can be parsed, update database
        If Integer.TryParse(cboSelectDepartment.SelectedValue.ToString, dept) Then
            Dim description = txtDescription.Text

            If mDept.Update(dept, description) Then
                frm.UpdateStatus("Department Updated.")
            Else
                frm.UpdateStatus("Unable to updated department.")
            End If
        Else
            frm.UpdateStatus("No department selected.")
        End If
    End Sub

    ''' <summary>
    ''' Form load that sets frm and sets combobox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmUpdateDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        With cboSelectDepartment
            .DataSource = mDept.Dept()
            .DisplayMember = "dept"
            .ValueMember = "dept"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = -1
        End With
        frm.UpdateStatus("Select department number and enter description to update.")
    End Sub

End Class