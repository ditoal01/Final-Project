Option Explicit On
Option Strict On

Public Class frmUpdateInventory
    Private saleInventory, backInventory As Integer
    Private mItems As New Item
    Private mDept As New Department

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI parent to parent form
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
        'Close form when inactive
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim total As Integer
        saleInventory = CInt(txtShelfTotal.Text)
        backInventory = CInt(txtBackroomTotal.Text)
        total = saleInventory + backInventory
        lblInventory.Text = total.ToString

        If mItems.Update(CInt(txtItemNumber.Text), txtUPCNumber.Text, CInt(cboDepartment.SelectedIndex.ToString),
                      txtDescription.Text, total, CInt(txtShelfCap.Text), CInt(txtCaseQuanity.Text),
                      CInt(txtSalesRate.Text), CInt(txtShelfTotal.Text), CInt(txtBackroomTotal.Text),
                      CDec(txtSalePrice.Text), CDec(txtCost.Text)) Then
        Else
            Item.LastError = "Cannot update the Appointment."
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim id As Integer
        id = CInt(txtLookup.Text)
        Search(id)

    End Sub

    Private Function Search(ByVal pId As Integer) As Boolean

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow
        Dim row3 As InventoryManagementSystemDataSet.SaleRow

        For Each grp As GroupBox In Controls.OfType(Of GroupBox)
            grp.Enabled = True
        Next

        row = mItems.FindItem(pId)
        txtItemNumber.Text = row.Id.ToString
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

        Return True
    End Function

    Public Sub input(ByVal pId As Integer)
        txtLookup.Text = pId.ToString
        Search(pId)
    End Sub

    Private Sub frmUpdateInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDepartment.DataSource = mDept.Dept()
        cboDepartment.DisplayMember = "dept"
        cboDepartment.ValueMember = "dept"
    End Sub
End Class