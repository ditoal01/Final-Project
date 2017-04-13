Public Class Department
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.departmentTableAdapter

    Public ReadOnly Property Dept() As DataTable
        Get
            Dim table As DataTable = adapter.GetData()
            table.DefaultView.Sort = "dept"
            Return table
        End Get
    End Property

End Class
