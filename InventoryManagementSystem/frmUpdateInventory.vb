Option Explicit On
Option Strict On

Public Class frmUpdateInventory
    'Class variables
    Private saleInventory, backInventory As Integer
    Private mItems As New Item
    Private mDept As New Department
    Private formLoading As Boolean = True
    Private runSearch As Boolean = False
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' Cancel button handler that loads dashboard
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        errorProvider.Clear()
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    ''' <summary>
    ''' Keypress handler that limits input for textbox
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
        txtUPCNumber.MaxLength = 13
    End Sub

    ''' <summary>
    ''' Keypress handler that limits input for textbox
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
    ''' Keypress handler that limits input for textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtShelfCap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtShelfCap.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Keypress handler that limits input for textbox
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
    ''' Keypress handler that limits input for textbox
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
    ''' Keypress handler that limits input for textbox
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
    ''' Keypress handler that limits input for textbox
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
    ''' Keypress handler that limits input for textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtLookup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLookup.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        txtLookup.MaxLength = 6
    End Sub

    ''' <summary>
    ''' Close form when deactivate
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmUpdateInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Update inventory handler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frm.clearStatus()
        'Check if search is true
        If runSearch Then
            Dim total As Integer
            Dim price, cost As Decimal
            errorProvider.Clear()
            'Check for empty textbox
            For Each grp As GroupBox In Controls.OfType(Of GroupBox)
                For Each txt As TextBox In grp.Controls.OfType(Of TextBox)
                    If txt.Text = String.Empty Then
                        errorProvider.SetError(txt, txt.Name.ToString & " is empty")
                        Exit Sub
                    End If
                Next
            Next
            'Check if input is currency
            If Not IsNumeric(Decimal.TryParse(txtSalePrice.Text.Replace("$", ""), price)) Then
                errorProvider.SetError(txtSalePrice, "Must be a currency value")
                Exit Sub

            End If
            'Check if input is currency
            If Not IsNumeric(Decimal.TryParse(txtCost.Text.Replace("$", ""), cost)) Then
                errorProvider.SetError(txtCost, "Must be a currency value")
                Exit Sub

            End If
            'Check if input is empty
            If txtLookup.Text = String.Empty Then
                errorProvider.SetError(txtLookup, txtLookup.Name.ToString & " is empty")
                Exit Sub
            End If

            saleInventory = CInt(txtShelfTotal.Text)
            backInventory = CInt(txtBackroomTotal.Text)
            total = saleInventory + backInventory
            lblInventory.Text = total.ToString

            lblMarkUp.Text = mItems.Markup(price, cost).ToString("P")
            'Check if item is updated
            If mItems.Update(CInt(lblItemNumber.Text), txtUPCNumber.Text, CInt(cboDepartment.SelectedValue.ToString),
                      txtDescription.Text, total, CInt(txtShelfCap.Text), CInt(txtCaseQuanity.Text),
                      CInt(txtSalesRate.Text), CInt(txtShelfTotal.Text), CInt(txtBackroomTotal.Text),
                      CDec(txtSalePrice.Text), CDec(txtCost.Text)) Then
                frm.UpdateStatus("Item updated in database.")
            Else

                frm.UpdateStatus("Cannot update the Appointment from database.")
            End If
        Else
            Clear()
            frm.UpdateStatus("No Item to Update, search for item to update")
        End If
        runSearch = False
    End Sub

    ''' <summary>
    ''' Search handler that searches for item in database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frm.clearStatus()
        Dim id As Integer

        If txtLookup.Text = String.Empty Then
            errorProvider.SetError(txtLookup, txtLookup.Text.ToString & " is empty")
            Exit Sub
        End If

        id = CInt(txtLookup.Text)
        If Search(id) Then
            frm.UpdateStatus("Item Found for update")
            runSearch = True
            For Each grp As GroupBox In Controls.OfType(Of GroupBox)
                grp.Enabled = True
            Next
        Else
            Clear()
            frm.UpdateStatus("No Item To search, please enter item number To start search.")
            runSearch = False
        End If
    End Sub

    ''' <summary>
    ''' function that searches for item in database
    ''' </summary>
    ''' <param name="pId">item number</param>
    ''' <returns>item is found</returns>
    Private Function Search(ByVal pId As Integer) As Boolean

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow



        row = mItems.FindItem(pId)
        'update form with input
        Try

            lblItemNumber.Text = row.Id.ToString
            txtUPCNumber.Text = row.upc.ToString
            txtDescription.Text = row.description.ToString
            lblInventory.Text = row.inventory.ToString
            cboDepartment.SelectedValue = row.dept

            row2 = mItems.FindDetail(pId)
            txtShelfCap.Text = row2.shelfcap.ToString
            txtCaseQuanity.Text = row2.casequanity.ToString
            txtSalesRate.Text = row2.rate.ToString
            txtShelfTotal.Text = row2.invshelf.ToString
            txtBackroomTotal.Text = row2.invback.ToString

            row3 = mItems.FindSale(pId)
            txtSalePrice.Text = row3.price.ToString("c")
            txtCost.Text = row3.cost.ToString("c")
            lblMarkUp.Text = mItems.Markup(row3.price, row3.cost).ToString("P")

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' procedure that checks item number
    ''' </summary>
    ''' <param name="pId"></param>
    Public Sub input(ByVal pId As Integer)
        txtLookup.Text = pId.ToString
        If Search(pId) Then
            frm.UpdateStatus("Item Found for update")
            For Each grp As GroupBox In Controls.OfType(Of GroupBox)
                grp.Enabled = True
            Next
            runSearch = True
        Else
            runSearch = False
            frm.UpdateStatus("Update Item could not be found")
        End If
    End Sub

    ''' <summary>
    ''' Form load sets frm to parent and updates form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmUpdateInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frm = CType(Me.ParentForm, frmMainInventoryForm)

        With cboDepartment
            .DataSource = mDept.Dept()
            .DisplayMember = "dept"
            .ValueMember = "dept"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = -1
        End With

        formLoading = False
        frm.UpdateStatus("Enter item to update in database.")
    End Sub

    ''' <summary>
    ''' Procedure that clears form
    ''' </summary>
    Private Sub Clear()
        For Each grp As GroupBox In Controls.OfType(Of GroupBox)
            grp.Enabled = False

            For Each txt As TextBox In grp.Controls.OfType(Of TextBox)
                txt.Clear()
            Next
            For Each lbl As Label In grp.Controls.OfType(Of Label)
                If lbl.Name.Contains("lbl") Then
                    lbl.Text = ""
                End If
            Next
        Next
        cboDepartment.SelectedIndex = -1
    End Sub

End Class