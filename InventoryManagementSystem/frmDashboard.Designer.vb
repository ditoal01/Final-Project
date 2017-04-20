<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblReceivePiece = New System.Windows.Forms.Label()
        Me.lblReceiveCase = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblReceiveItem = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotalNumberPieces = New System.Windows.Forms.Label()
        Me.lblTotalNumberCases = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalNumberItem = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblOverstock = New System.Windows.Forms.Label()
        Me.lblOutOfStock = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblReplenish = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lstExceptions = New System.Windows.Forms.ListView()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblReceivePiece)
        Me.GroupBox2.Controls.Add(Me.lblReceiveCase)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblReceiveItem)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(24, 336)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 136)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Receiving Details"
        '
        'lblReceivePiece
        '
        Me.lblReceivePiece.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReceivePiece.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivePiece.Location = New System.Drawing.Point(176, 88)
        Me.lblReceivePiece.Name = "lblReceivePiece"
        Me.lblReceivePiece.Size = New System.Drawing.Size(100, 20)
        Me.lblReceivePiece.TabIndex = 20
        Me.lblReceivePiece.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReceiveCase
        '
        Me.lblReceiveCase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReceiveCase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiveCase.Location = New System.Drawing.Point(176, 56)
        Me.lblReceiveCase.Name = "lblReceiveCase"
        Me.lblReceiveCase.Size = New System.Drawing.Size(100, 20)
        Me.lblReceiveCase.TabIndex = 19
        Me.lblReceiveCase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Total Number of Pieces:"
        '
        'lblReceiveItem
        '
        Me.lblReceiveItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReceiveItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiveItem.Location = New System.Drawing.Point(176, 24)
        Me.lblReceiveItem.Name = "lblReceiveItem"
        Me.lblReceiveItem.Size = New System.Drawing.Size(100, 20)
        Me.lblReceiveItem.TabIndex = 18
        Me.lblReceiveItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Total Number of Cases:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Number of Items:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTotalNumberPieces)
        Me.GroupBox1.Controls.Add(Me.lblTotalNumberCases)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblTotalNumberItem)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(24, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 136)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inventory Details"
        '
        'lblTotalNumberPieces
        '
        Me.lblTotalNumberPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalNumberPieces.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNumberPieces.Location = New System.Drawing.Point(168, 88)
        Me.lblTotalNumberPieces.Name = "lblTotalNumberPieces"
        Me.lblTotalNumberPieces.Size = New System.Drawing.Size(100, 20)
        Me.lblTotalNumberPieces.TabIndex = 20
        Me.lblTotalNumberPieces.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalNumberCases
        '
        Me.lblTotalNumberCases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalNumberCases.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNumberCases.Location = New System.Drawing.Point(168, 56)
        Me.lblTotalNumberCases.Name = "lblTotalNumberCases"
        Me.lblTotalNumberCases.Size = New System.Drawing.Size(100, 20)
        Me.lblTotalNumberCases.TabIndex = 19
        Me.lblTotalNumberCases.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Total Number of Pieces:"
        '
        'lblTotalNumberItem
        '
        Me.lblTotalNumberItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalNumberItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNumberItem.Location = New System.Drawing.Point(168, 24)
        Me.lblTotalNumberItem.Name = "lblTotalNumberItem"
        Me.lblTotalNumberItem.Size = New System.Drawing.Size(100, 20)
        Me.lblTotalNumberItem.TabIndex = 18
        Me.lblTotalNumberItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(32, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Total Number of Cases:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(32, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Total Number of Items:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblOverstock)
        Me.GroupBox3.Controls.Add(Me.lblOutOfStock)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.lblReplenish)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(24, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(294, 136)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Dashboard"
        '
        'lblOverstock
        '
        Me.lblOverstock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOverstock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverstock.Location = New System.Drawing.Point(168, 88)
        Me.lblOverstock.Name = "lblOverstock"
        Me.lblOverstock.Size = New System.Drawing.Size(100, 20)
        Me.lblOverstock.TabIndex = 20
        Me.lblOverstock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOutOfStock
        '
        Me.lblOutOfStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOutOfStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutOfStock.Location = New System.Drawing.Point(168, 56)
        Me.lblOutOfStock.Name = "lblOutOfStock"
        Me.lblOutOfStock.Size = New System.Drawing.Size(100, 20)
        Me.lblOutOfStock.TabIndex = 19
        Me.lblOutOfStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(32, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Overstock:"
        '
        'lblReplenish
        '
        Me.lblReplenish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReplenish.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReplenish.Location = New System.Drawing.Point(168, 24)
        Me.lblReplenish.Name = "lblReplenish"
        Me.lblReplenish.Size = New System.Drawing.Size(100, 20)
        Me.lblReplenish.TabIndex = 18
        Me.lblReplenish.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(32, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Out of Stock:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(32, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(109, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Number of Replenish:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(512, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 13)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Current Exceptions:"
        '
        'errorProvider
        '
        Me.errorProvider.ContainerControl = Me
        '
        'lstExceptions
        '
        Me.lstExceptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstExceptions.Location = New System.Drawing.Point(352, 88)
        Me.lstExceptions.MultiSelect = False
        Me.lstExceptions.Name = "lstExceptions"
        Me.lstExceptions.Size = New System.Drawing.Size(440, 384)
        Me.lstExceptions.TabIndex = 23
        Me.lstExceptions.UseCompatibleStateImageBehavior = False
        Me.lstExceptions.View = System.Windows.Forms.View.Details
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 570)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstExceptions)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmDashboard"
        Me.Text = "DashBoard"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblReceivePiece As Label
    Friend WithEvents lblReceiveCase As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblReceiveItem As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTotalNumberPieces As Label
    Friend WithEvents lblTotalNumberCases As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotalNumberItem As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblOverstock As Label
    Friend WithEvents lblOutOfStock As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblReplenish As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents errorProvider As ErrorProvider
    Friend WithEvents lstExceptions As ListView
End Class
