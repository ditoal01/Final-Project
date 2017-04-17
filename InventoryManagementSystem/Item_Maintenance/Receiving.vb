Public Class Receiving
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.ReceivingTableAdapter
    Private adapterItem As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter
    Private mItems As New Item

    Public ReadOnly Property receive As DataTable
        Get
            Return adapter.GetData()
        End Get
    End Property

    Public Function FindByDeptId(ByVal pReceiveId) As InventoryManagementSystemDataSet.ReceivingRow
        Dim table As InventoryManagementSystemDataSet.ReceivingDataTable
        table = adapter.GetData()
        Return table.FindById(pReceiveId)
    End Function

    Public Function Delete(ByVal pReceiveId As Integer) As Boolean
        Dim rowsAffected As Integer = 0
        Try
            rowsAffected = adapter.Delete(pReceiveId)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ", items in department")
        End Try

        Return rowsAffected > 0
    End Function

    Public Sub OnOrder()
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable = adapterItem.GetData()
        Dim row As InventoryManagementSystemDataSet.ItemDetailRow

        For Each trow In table.Rows

            row = CType(trow, InventoryManagementSystemDataSet.ItemDetailRow)
            Dim total As Integer = row.invshelf + row.invback
            If (total < (row.rate * 2)) Then
                Try
                    adapter.Insert(row.Id, row.casequanity, 0)
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ", Unable to create orders")
                End Try
            End If
        Next
    End Sub

End Class
