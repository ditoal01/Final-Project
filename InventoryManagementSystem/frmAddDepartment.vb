Option Explicit On
Option Strict On

Public Class frmAddDepartment
    'Class variables
    Private mDept As New Department
    Private frm As New frmMainInventoryForm


    ''' <summary>
    ''' Button handler that shows parent form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'set dashboard form MDI Parent and then show
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show() 'Show dashboard
    End Sub

    ''' <summary>
    ''' Key press event that limits input from textbox add department
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' When form is deactivated, then close form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAddDepartment_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Button handler that adds department to database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        frm.clearStatus()
        errorProvider.Clear()
        Dim dept As Integer
        Dim deptName As String
        'Checks if textboxes are empty, if so set error
        For Each txt As TextBox In Controls.OfType(Of TextBox)
            If txt.Text = String.Empty Then
                errorProvider.SetError(txt, txt.Name.ToString & " is empty")
                txt.Focus()
                Exit Sub
            End If
        Next
        'if statement that checks if input can be parsed
        If Integer.TryParse(txtAddDepartment.Text, dept) Then
            deptName = txtDepartmentName.Text
            'if statment that checks if department is added to database
            If mDept.Insert(dept, deptName) Then
                frm.UpdateStatus("Department added to list.")
            Else
                frm.UpdateStatus("Unable to add department")
            End If

        Else
            frm.UpdateStatus("Unable to add department.")
        End If

    End Sub

    ''' <summary>
    ''' Form load that updates status and sets variable frm to parent
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAddDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        frm.UpdateStatus("Enter department number and name to add to list.")
    End Sub
End Class