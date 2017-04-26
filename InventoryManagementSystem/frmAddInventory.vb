Option Explicit On
Option Strict On

Public Class frmAddInventory
    'Class variables
    Private mItems As New Item
    Private mDept As New Department
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' Cancel button handler that redirects to dashboard
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard form MDI to parent form and show
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    ''' <summary>
    ''' Keypress handler that only allows numbers entered into upc number textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' Keypress handler that only allows numbers entered into inventory textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtInventory_KeyPress(sender As Object, e As KeyPressEventArgs)
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Keypress Handler that only allows numbers entered into shelfcap textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtSelfCap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtShelfCap.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Keypress Handler that only allows numbers entered into case quantity textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtCaseQuanity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCaseQuanity.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Keypress Handler that only allows numbers entered into sales rate textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtSalesRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSalesRate.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Keypress Handler that only allows numbers entered into shelf total textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtShelfTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtShelfTotal.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Keypress Handler that only allows numbers entered into backroom total textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtBackroomTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBackroomTotal.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Closes form when it is deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAddInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Add button handler that adds inventory to database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim price, cost As Decimal
        'For loop that checks if textbox and combo box is not empty
        For Each grp As GroupBox In Controls.OfType(Of GroupBox)
            For Each cbo As ComboBox In grp.Controls.OfType(Of ComboBox)
                ' Set error provider if nothing is selected in combo box
                If cbo.SelectedIndex = -1 Then
                    errorProvider.SetError(cbo, "Select a department from list")
                    cbo.Focus()
                    Exit Sub
                End If
            Next
            'Set error provider if textbox is empty
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
        'If statement to check if currency value is entered
        If Not IsNumeric(Decimal.TryParse(txtSalePrice.Text.Replace("$", ""), price)) Then
            errorProvider.SetError(txtSalePrice, "Must be a currency value")
            Exit Sub

        End If
        'If statement to check if currency value is entered
        If Not IsNumeric(Decimal.TryParse(txtCost.Text.Replace("$", ""), cost)) Then
            errorProvider.SetError(txtCost, "Must be a currency value")
            Exit Sub

        End If
        'Set itmNum to item number from selected combobox
        Dim itmNum As Integer = mItems.GetId(CInt(cboDepartment.SelectedValue))
        lblItemNumber.Text = itmNum.ToString
        'Add shelf total and backroom for total inventory
        Dim total As Integer = CInt(txtShelfTotal.Text) + CInt(txtBackroomTotal.Text)
        'if statment to check if item is added to database
        If mItems.Insert(itmNum, txtUPCNumber.Text, CInt(cboDepartment.SelectedValue.ToString),
                      txtDescription.Text, total, CInt(txtShelfCap.Text), CInt(txtCaseQuanity.Text),
                      CInt(txtSalesRate.Text), CInt(txtShelfTotal.Text), CInt(txtBackroomTotal.Text),
                      price, cost) Then
            frm.UpdateStatus("Item added to database")
            lblItemNumber.Text = itmNum.ToString
            lblMarkUp.Text = mItems.Markup(price, cost).ToString("P")
            lblInventory.Text = total.ToString
        Else 'If item not added, them update status label
            frm.UpdateStatus("Item isn't able to be added to database")
            lblItemNumber.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' Form load that sets combobox and frm variable to parent
    ''' update status label
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmAddInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        With cboDepartment
            .DataSource = mDept.Dept
            .DisplayMember = "dept"
            .ValueMember = "dept"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = -1
        End With
        frm.UpdateStatus("Enter information to add item to database.")
    End Sub
End Class