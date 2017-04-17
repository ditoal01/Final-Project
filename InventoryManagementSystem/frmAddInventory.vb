Option Explicit On
Option Strict On

Public Class frmAddInventory

    Private mItems As New Item
    Private mDept As New Department
    Private frm As New frmMainInventoryForm

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard form MDI to parent form and show
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
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
        mItems.LastStatus = String.Empty
        frm.UpdateStatus(mItems.LastStatus)
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim price, cost As Decimal

        For Each grp As GroupBox In Controls.OfType(Of GroupBox)
            For Each cbo As ComboBox In grp.Controls.OfType(Of ComboBox)

                If cbo.SelectedIndex = -1 Then
                    errorProvider.SetError(cbo, "Select a department")
                    cbo.Focus()
                    Exit Sub
                End If
            Next
            For Each txt As TextBox In grp.Controls.OfType(Of TextBox)

                If Not grp.Text = "Receiving Details" Then
                    If txt.Text = String.Empty Then
                        errorProvider.SetError(txt, txt.Name.ToString & " is empty")
                        txt.Focus()
                        Exit Sub
                    End If

                End If
            Next
        Next

        If Not IsNumeric(Decimal.TryParse(txtSalePrice.Text.Replace("$", ""), price)) Then
            errorProvider.SetError(txtSalePrice, "Must be a currency value")
            Exit Sub

        End If

        If Not IsNumeric(Decimal.TryParse(txtCost.Text.Replace("$", ""), cost)) Then
            errorProvider.SetError(txtCost, "Must be a currency value")
            Exit Sub

        End If

        Dim itmNum As Integer = mItems.GetId(CInt(cboDepartment.SelectedValue))
        lblItemNumber.Text = itmNum.ToString

        Dim total As Integer = CInt(txtShelfTotal.Text) + CInt(txtBackroomTotal.Text)

        If mItems.Insert(itmNum, txtUPCNumber.Text, CInt(cboDepartment.SelectedValue.ToString),
                      txtDescription.Text, total, CInt(txtShelfCap.Text), CInt(txtCaseQuanity.Text),
                      CInt(txtSalesRate.Text), CInt(txtShelfTotal.Text), CInt(txtBackroomTotal.Text),
                      price, cost) Then

            lblItemNumber.Text = itmNum.ToString
            lblMarkUp.Text = mItems.Markup(price, cost).ToString("P")
            lblInventory.Text = total.ToString
        Else
            lblItemNumber.Text = String.Empty
        End If

        frm.UpdateStatus(mItems.LastStatus)

    End Sub

    Private Sub frmAddInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        With cboDepartment
            .DataSource = mDept.Dept
            .DisplayMember = "dept"
            .ValueMember = "dept"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = -1
        End With

        frm.UpdateStatus(mItems.LastStatus)
    End Sub

End Class