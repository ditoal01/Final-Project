<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainInventoryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartmentMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewDepartmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateDepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddDepartmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteDepartmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecievingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecieveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.InventoryToolStripMenuItem, Me.DepartmentMaintenanceToolStripMenuItem, Me.RecievingToolStripMenuItem, Me.SalesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(835, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.HomeToolStripMenuItem.Text = "Dashboard"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem, Me.ViewAllToolStripMenuItem, Me.ManageToolStripMenuItem, Me.AddToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(115, 20)
        Me.InventoryToolStripMenuItem.Text = "Item Maintenance"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ViewAllToolStripMenuItem
        '
        Me.ViewAllToolStripMenuItem.Name = "ViewAllToolStripMenuItem"
        Me.ViewAllToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ViewAllToolStripMenuItem.Text = "View All"
        '
        'ManageToolStripMenuItem
        '
        Me.ManageToolStripMenuItem.Name = "ManageToolStripMenuItem"
        Me.ManageToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ManageToolStripMenuItem.Text = "Update"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'DepartmentMaintenanceToolStripMenuItem
        '
        Me.DepartmentMaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDepartmentsToolStripMenuItem, Me.UpdateDepartmentToolStripMenuItem, Me.AddDepartmentsToolStripMenuItem, Me.DeleteDepartmentsToolStripMenuItem})
        Me.DepartmentMaintenanceToolStripMenuItem.Name = "DepartmentMaintenanceToolStripMenuItem"
        Me.DepartmentMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(154, 20)
        Me.DepartmentMaintenanceToolStripMenuItem.Text = "Department Maintenance"
        '
        'ViewDepartmentsToolStripMenuItem
        '
        Me.ViewDepartmentsToolStripMenuItem.Name = "ViewDepartmentsToolStripMenuItem"
        Me.ViewDepartmentsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ViewDepartmentsToolStripMenuItem.Text = "View Departments"
        '
        'UpdateDepartmentToolStripMenuItem
        '
        Me.UpdateDepartmentToolStripMenuItem.Name = "UpdateDepartmentToolStripMenuItem"
        Me.UpdateDepartmentToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.UpdateDepartmentToolStripMenuItem.Text = "Update Department"
        '
        'AddDepartmentsToolStripMenuItem
        '
        Me.AddDepartmentsToolStripMenuItem.Name = "AddDepartmentsToolStripMenuItem"
        Me.AddDepartmentsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.AddDepartmentsToolStripMenuItem.Text = "Add Department"
        '
        'DeleteDepartmentsToolStripMenuItem
        '
        Me.DeleteDepartmentsToolStripMenuItem.Name = "DeleteDepartmentsToolStripMenuItem"
        Me.DeleteDepartmentsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.DeleteDepartmentsToolStripMenuItem.Text = "Delete Department"
        '
        'RecievingToolStripMenuItem
        '
        Me.RecievingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecieveToolStripMenuItem, Me.StockingToolStripMenuItem, Me.OrderItemToolStripMenuItem})
        Me.RecievingToolStripMenuItem.Name = "RecievingToolStripMenuItem"
        Me.RecievingToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.RecievingToolStripMenuItem.Text = "Receiving"
        '
        'RecieveToolStripMenuItem
        '
        Me.RecieveToolStripMenuItem.Name = "RecieveToolStripMenuItem"
        Me.RecieveToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.RecieveToolStripMenuItem.Text = "Receive"
        '
        'StockingToolStripMenuItem
        '
        Me.StockingToolStripMenuItem.Name = "StockingToolStripMenuItem"
        Me.StockingToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.StockingToolStripMenuItem.Text = "Replenish"
        '
        'OrderItemToolStripMenuItem
        '
        Me.OrderItemToolStripMenuItem.AutoSize = False
        Me.OrderItemToolStripMenuItem.Name = "OrderItemToolStripMenuItem"
        Me.OrderItemToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OrderItemToolStripMenuItem.Text = "Order Item"
        '
        'SalesToolStripMenuItem
        '
        Me.SalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransactionToolStripMenuItem})
        Me.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem"
        Me.SalesToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.SalesToolStripMenuItem.Text = "Sales"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TransactionToolStripMenuItem.Text = "Transaction"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 525)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(835, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'frmMainInventoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(835, 547)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMainInventoryForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Control System"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HomeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecievingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecieveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DepartmentMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewDepartmentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddDepartmentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteDepartmentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateDepartmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrderItemToolStripMenuItem As ToolStripMenuItem
End Class
