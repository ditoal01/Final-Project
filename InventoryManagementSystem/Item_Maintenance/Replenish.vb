Public Class Replenish
    Private adapterId As New InventoryManagementSystemDataSetTableAdapters.ItemTableAdapter
    Private adapterItem As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter

    Private mItems As New Item
    Public Shared Property LastError As String

    Public ReadOnly Property Replenish As DataTable
        Get
            Dim table As DataTable = adapterItem.GetData()
            table.DefaultView.RowFilter = "invshelf < rate AND invback > 0"
            Return table
        End Get
    End Property

    Public Function getTotalItems() As Integer
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable = adapterItem.GetData
        Dim row As InventoryManagementSystemDataSet.ItemDetailRow
        Dim counter As Integer = 0

        For Each tRow In table.Rows
            row = CType(tRow, InventoryManagementSystemDataSet.ItemDetailRow)
            If row.invshelf < row.rate And row.invback > 0 Then
                counter += 1
            End If
        Next

        Return counter
    End Function

    Public Function getOutStock() As Integer
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable = adapterItem.GetData
        Dim row As InventoryManagementSystemDataSet.ItemDetailRow
        Dim counter As Integer = 0

        For Each tRow In table.Rows
            row = CType(tRow, InventoryManagementSystemDataSet.ItemDetailRow)
            If (row.invback + row.invshelf) = 0 Then
                counter += 1
            End If
        Next

        Return counter
    End Function

    Public Function getOverstock() As Integer
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable = adapterItem.GetData
        Dim row As InventoryManagementSystemDataSet.ItemDetailRow
        Dim counter As Integer = 0

        For Each tRow In table.Rows
            row = CType(tRow, InventoryManagementSystemDataSet.ItemDetailRow)
            If row.invshelf > row.shelfcap Then
                counter += 1
            End If
        Next

        Return counter
    End Function

End Class
