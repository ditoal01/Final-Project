<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewAllInventory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgvDepartment = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.btnViewItem = New System.Windows.Forms.Button()
        Me.btnUpdateItem = New System.Windows.Forms.Button()
        Me.btnDeleteItem = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.dgvDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDepartment
        '
        Me.dgvDepartment.AllowUserToAddRows = False
        Me.dgvDepartment.AllowUserToDeleteRows = False
        Me.dgvDepartment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDepartment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDepartment.Location = New System.Drawing.Point(176, 32)
        Me.dgvDepartment.MultiSelect = False
        Me.dgvDepartment.Name = "dgvDepartment"
        Me.dgvDepartment.ReadOnly = True
        Me.dgvDepartment.RowHeadersVisible = False
        Me.dgvDepartment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDepartment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDepartment.Size = New System.Drawing.Size(632, 398)
        Me.dgvDepartment.TabIndex = 20
        Me.dgvDepartment.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(348, 457)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Select Department Number:"
        '
        'cboDepartment
        '
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(520, 457)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(121, 21)
        Me.cboDepartment.TabIndex = 4
        '
        'btnViewItem
        '
        Me.btnViewItem.Location = New System.Drawing.Point(24, 32)
        Me.btnViewItem.Name = "btnViewItem"
        Me.btnViewItem.Size = New System.Drawing.Size(124, 33)
        Me.btnViewItem.TabIndex = 0
        Me.btnViewItem.Text = "View Item Details"
        Me.btnViewItem.UseVisualStyleBackColor = True
        '
        'btnUpdateItem
        '
        Me.btnUpdateItem.Location = New System.Drawing.Point(24, 96)
        Me.btnUpdateItem.Name = "btnUpdateItem"
        Me.btnUpdateItem.Size = New System.Drawing.Size(124, 33)
        Me.btnUpdateItem.TabIndex = 1
        Me.btnUpdateItem.Text = "Update Item Details"
        Me.btnUpdateItem.UseVisualStyleBackColor = True
        '
        'btnDeleteItem
        '
        Me.btnDeleteItem.Location = New System.Drawing.Point(24, 160)
        Me.btnDeleteItem.Name = "btnDeleteItem"
        Me.btnDeleteItem.Size = New System.Drawing.Size(124, 33)
        Me.btnDeleteItem.TabIndex = 2
        Me.btnDeleteItem.Text = "Delete Item"
        Me.btnDeleteItem.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(24, 224)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(124, 33)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'errorProvider
        '
        Me.errorProvider.ContainerControl = Me
        '
        'frmViewAllInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 526)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDeleteItem)
        Me.Controls.Add(Me.btnUpdateItem)
        Me.Controls.Add(Me.btnViewItem)
        Me.Controls.Add(Me.cboDepartment)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDepartment)
        Me.Name = "frmViewAllInventory"
        Me.Text = "View All Items"
        CType(Me.dgvDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDepartment As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents btnViewItem As Button
    Friend WithEvents btnUpdateItem As Button
    Friend WithEvents btnDeleteItem As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents errorProvider As ErrorProvider
End Class
