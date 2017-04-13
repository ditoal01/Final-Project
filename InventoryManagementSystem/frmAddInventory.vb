Option Explicit On
Option Strict On

Public Class frmAddInventory

    Private mItems As New Item
    Private mDept As New Department

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard form MDI to parent form and show
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    Private Sub txtItemNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItemNumber.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        txtItemNumber.MaxLength = 7
    End Sub

    Private Sub txtUPCNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUPCNumber.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        txtUPCNumber.MaxLength = 12
    End Sub

    Private Sub txtInventory_KeyPress(sender As Object, e As KeyPressEventArgs)
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSelfCap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtShelfCap.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCaseQuanity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCaseQuanity.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSalesRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSalesRate.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtShelfTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtShelfTotal.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmAddInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim itmNum As Integer = 130007
        txtItemNumber.Text = itmNum.ToString

        Dim total As Integer = CInt(txtShelfTotal.Text) + CInt(txtBackroomTotal.Text)

        mItems.Insert(itmNum, txtUPCNumber.Text, CInt(cboDepartment.SelectedIndex.ToString),
                      txtDescription.Text, total, CInt(txtShelfCap.Text), CInt(txtCaseQuanity.Text),
                      CInt(txtSalesRate.Text), CInt(txtShelfTotal.Text), CInt(txtBackroomTotal.Text),
                      CDec(txtSalePrice.Text), CDec(txtCost.Text))
    End Sub

    Private Sub frmAddInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDepartment.DataSource = mDept.Dept
        cboDepartment.DisplayMember = "dept"
        cboDepartment.ValueMember = "dept"
    End Sub
End Class