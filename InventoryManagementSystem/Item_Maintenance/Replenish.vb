Public Class Replenish
    Private adapterId As New InventoryManagementSystemDataSetTableAdapters.ItemTableAdapter
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.ReceivingTableAdapter
    Private adapterItem As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter

    Private mItems As New Item

    Public ReadOnly Property Replenish As DataTable
        Get
            Dim table As DataTable = adapterItem.GetData()
            table.DefaultView.RowFilter = "(invshelf < rate AND invback > 0) OR (invshelf = 0 AND invback > 0)"
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

    Public Function UpdateInv(ByVal selectedItem As String) As Boolean
        Dim row As InventoryManagementSystemDataSet.ItemDetailRow
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable = adapterItem.GetData
        Dim selected As Integer
        If Integer.TryParse(selectedItem, selected) Then

            row = mItems.FindDetail(selected)

            Dim transfer As Integer = row.casequanity
            Dim total As Integer = 0
            Dim check As Boolean = True

            While (check)
                total += transfer
                If total >= row.shelfcap Then
                    check = False
                End If
            End While


            If row IsNot Nothing Then
                row.invback -= total
                row.invshelf += total
                mItems.UpdateDetail(row)
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Function OnOrder(ByVal id As Integer, ByVal order As Integer) As Boolean
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable = adapterItem.GetData()
        Dim check As Boolean = False

        Try
            adapter.Insert(id, order, check)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
