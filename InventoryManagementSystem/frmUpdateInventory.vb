Option Explicit On
Option Strict On

Public Class frmUpdateInventory
    Private saleInventory, backInventory As Integer
    Private mItems As New Item
    Private mDept As New Department
    Private formLoading As Boolean = True
    Private runSearch As Boolean = False
    Private frm As New frmMainInventoryForm

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        errorProvider.Clear()
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
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

    Private Sub txtShelfCap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtShelfCap.KeyPress
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

    Private Sub txtBackroomTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBackroomTotal.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLookup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLookup.KeyPress
        errorProvider.Clear()
        'Enables control keys
        If Char.IsControl(e.KeyChar) Then Exit Sub
        'Key press for only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        txtLookup.MaxLength = 12
    End Sub

    Private Sub frmUpdateInventory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        mItems.LastStatus = String.Empty
        frm.UpdateStatus(mItems.LastStatus)
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        mItems.LastStatus = String.Empty

        If runSearch Then
            Dim total As Integer
            Dim price, cost As Decimal
            errorProvider.Clear()

            For Each grp As GroupBox In Controls.OfType(Of GroupBox)
                For Each txt As TextBox In grp.Controls.OfType(Of TextBox)
                    If txt.Text = String.Empty Then
                        errorProvider.SetError(txt, txt.Name.ToString & " is empty")
                        Exit Sub
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

            If txtLookup.Text = String.Empty Then
                errorProvider.SetError(txtLookup, txtLookup.Name.ToString & " is empty")
                Exit Sub
            End If

            saleInventory = CInt(txtShelfTotal.Text)
            backInventory = CInt(txtBackroomTotal.Text)
            total = saleInventory + backInventory
            lblInventory.Text = total.ToString

            lblMarkUp.Text = mItems.Markup(price, cost).ToString("P")

            If mItems.Update(CInt(lblItemNumber.Text), txtUPCNumber.Text, CInt(cboDepartment.SelectedValue.ToString),
                      txtDescription.Text, total, CInt(txtShelfCap.Text), CInt(txtCaseQuanity.Text),
                      CInt(txtSalesRate.Text), CInt(txtShelfTotal.Text), CInt(txtBackroomTotal.Text),
                      CDec(txtSalePrice.Text), CDec(txtCost.Text)) Then
            Else

                mItems.LastStatus = "Cannot update the Appointment."
            End If
        Else
            mItems.LastStatus = "No Item to search"
        End If
        frm.UpdateStatus(mItems.LastStatus)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        mItems.LastStatus = String.Empty
        Dim id As Integer

        If txtLookup.Text = String.Empty Then
            errorProvider.SetError(txtLookup, txtLookup.Text.ToString & " is empty")
            Exit Sub
        End If

        id = CInt(txtLookup.Text)
        If Search(id) Then
            mItems.LastStatus = "Item Found for update"
            runSearch = True
        Else
            mItems.LastStatus = "Update Item could not be found"
            runSearch = False
        End If
        frm.UpdateStatus(mItems.LastStatus)
    End Sub

    Private Function Search(ByVal pId As Integer) As Boolean

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow

        For Each grp As GroupBox In Controls.OfType(Of GroupBox)
            grp.Enabled = True
        Next

        row = mItems.FindItem(pId)
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
            mItems.LastStatus = ex.Message
        End Try


        Return True
    End Function

    Public Sub input(ByVal pId As Integer)
        txtLookup.Text = pId.ToString
        If Search(pId) Then
            mItems.LastStatus = "Item Found for update"
            runSearch = True
        Else
            runSearch = False
            mItems.LastStatus = "Update Item could not be found"
        End If
        frm.UpdateStatus(mItems.LastStatus)
    End Sub

    Private Sub frmUpdateInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mItems.LastStatus = String.Empty

        frm = CType(Me.ParentForm, frmMainInventoryForm)

        With cboDepartment
            .DataSource = mDept.Dept()
            .DisplayMember = "dept"
            .ValueMember = "dept"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = -1
        End With

        formLoading = False
        frm.UpdateStatus(mItems.LastStatus)
    End Sub

End Class