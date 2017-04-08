Public Class frmMainInventoryForm

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Dim dashboard As New frmDashboard()
        dashboard.MdiParent = Me
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()

    End Sub

    Private Sub frmMainInventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dashboard As New frmDashboard()
        dashboard.MdiParent = Me
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()

    End Sub

    Private Sub ManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem.Click
        Dim updateInventoryForm As New frmUpdateInventory()
        updateInventoryForm.MdiParent = Me
        updateInventoryForm.WindowState = FormWindowState.Maximized
        updateInventoryForm.Show()

    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Dim viewInventory As New frmViewInventory()
        viewInventory.MdiParent = Me
        viewInventory.WindowState = FormWindowState.Maximized
        viewInventory.Show()

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim addInventory As New frmAddInventory()
        addInventory.MdiParent = Me
        addInventory.WindowState = FormWindowState.Maximized
        addInventory.Show()

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim deleteInventory As New frmDeleteInventory()
        deleteInventory.MdiParent = Me
        deleteInventory.WindowState = FormWindowState.Maximized
        deleteInventory.Show()

    End Sub

    Private Sub RecieveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecieveToolStripMenuItem.Click
        Dim receiveInventory As New frmReceiving()
        receiveInventory.MdiParent = Me
        receiveInventory.WindowState = FormWindowState.Maximized
        receiveInventory.Show()

    End Sub

    Private Sub TransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransactionToolStripMenuItem.Click
        Dim transaction As New frmTransaction()
        transaction.MdiParent = Me
        transaction.WindowState = FormWindowState.Maximized
        transaction.Show()

    End Sub

    Private Sub ViewAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewAllToolStripMenuItem.Click
        Dim viewAllInventory As New frmViewAllInventory()
        viewAllInventory.MdiParent = Me
        viewAllInventory.WindowState = FormWindowState.Maximized
        viewAllInventory.Show()
    End Sub

    Private Sub StockingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockingToolStripMenuItem.Click
        Dim replenish As New frmReplenish()
        replenish.MdiParent = Me
        replenish.WindowState = FormWindowState.Maximized
        replenish.Show()
    End Sub

    Private Sub ViewDepartmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDepartmentsToolStripMenuItem.Click
        Dim viewDepartment As New frmViewDepartments()
        viewDepartment.MdiParent = Me
        viewDepartment.WindowState = FormWindowState.Maximized
        viewDepartment.Show()
    End Sub

    Private Sub AddDepartmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddDepartmentsToolStripMenuItem.Click
        Dim addDepartment As New frmAddDepartment()
        addDepartment.MdiParent = Me
        addDepartment.WindowState = FormWindowState.Maximized
        addDepartment.Show()
    End Sub

    Private Sub DeleteDepartmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteDepartmentsToolStripMenuItem.Click
        Dim deleteDepartment As New frmDeleteDepartment()
        deleteDepartment.MdiParent = Me
        deleteDepartment.WindowState = FormWindowState.Maximized
        deleteDepartment.Show()
    End Sub

    Private Sub UpdateDepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateDepartmentToolStripMenuItem.Click
        Dim updateDepartment As New frmUpdateDepartment()
        updateDepartment.MdiParent = Me
        updateDepartment.WindowState = FormWindowState.Maximized
        updateDepartment.Show()
    End Sub

    Private Sub OrderItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderItemToolStripMenuItem.Click
        Dim orderForm As New frmOrderItem()
        orderForm.MdiParent = Me
        orderForm.WindowState = FormWindowState.Maximized
        orderForm.Show()
    End Sub
End Class
