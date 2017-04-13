Option Strict On
Option Explicit On

Public Class Item
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.ItemTableAdapter
    Private adapter2 As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter
    Private adapter3 As New InventoryManagementSystemDataSetTableAdapters.SaleTableAdapter
    Public Shared Property LastError As String

    Public ReadOnly Property Items() As DataTable
        Get

            Dim table As DataTable = adapter.GetDataBy()
            table.DefaultView.Sort = "Id"
            Return table
        End Get
    End Property

    Public Function Insert(ByVal pId As Integer, ByVal pUPC As String, ByVal pDept As Integer,
                           ByVal pDescription As String, ByVal pInventory As Integer, ByVal pCap As Integer,
                           ByVal pCase As Integer, ByVal pSaleRate As Integer, ByVal pShelf As Integer,
                           ByVal pBack As Integer, ByVal pSale As Decimal, ByVal pCost As Decimal) As Boolean
        Dim result As Boolean = False
        Try
            If adapter.Insert(pId, pUPC, pDept, pDescription, pInventory) > 0 And
                adapter2.Insert(pId, pCap, pCase, pShelf, pBack, pSaleRate) > 0 And
                adapter3.Insert(pId, pSale, pCost) > 0 Then
                LastError = "Item added to database"
                result = True
            Else
                LastError = "Error Adding Item to database"
            End If

        Catch ex As Exception
            LastError = "Exception thrown adding to database"
        End Try

        Return result

    End Function

    Public Function Update(ByVal pId As Integer, ByVal pUPC As String, ByVal pDept As Integer,
                           ByVal pDescription As String, ByVal pInventory As Integer, ByVal pCap As Integer,
                           ByVal pCase As Integer, ByVal pSaleRate As Integer, ByVal pShelf As Integer,
                           ByVal pBack As Integer, ByVal pSale As Decimal, ByVal pCost As Decimal) As Boolean
        LastError = String.Empty
        Try
            adapter.Update(pId, pUPC, pDept, pDescription, pInventory)
            adapter2.Update(pId, pCap, pCase, pShelf, pBack, pSaleRate)
            adapter3.Update(pId, pSale, pCost)
            Return True

        Catch ex As Exception
            LastError = ex.Message
            Return False
        End Try
    End Function

    Public Function Delete(ByVal pId As Integer) As Boolean
        Dim rowsAffected As Integer = adapter.Delete(pId)
        Return rowsAffected > 0
    End Function


    Public Function FindDetail(ByVal pId As Integer) As InventoryManagementSystemDataSet.ItemDetailRow
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable
        table = adapter2.GetData()
        Return table.FindById(pId)
    End Function

    Public Function FindSale(ByVal pId As Integer) As InventoryManagementSystemDataSet.SaleRow
        Dim table As InventoryManagementSystemDataSet.SaleDataTable
        table = adapter3.GetData()
        Return table.FindById(pId)
    End Function

    Public Function Markup(ByVal pPrice As Decimal, ByVal pCost As Decimal) As Decimal
        Dim grossProfitMargin As Decimal = pPrice - pCost
        Return grossProfitMargin / pCost
    End Function

    Public Function FindItem(ByVal pId As Integer) As InventoryManagementSystemDataSet.ItemRow
        Dim table As InventoryManagementSystemDataSet.ItemDataTable
        table = adapter.GetData()
        Return table.FindById(pId)
    End Function

    Public Function FindUPC(ByVal pUPC As Integer) As InventoryManagementSystemDataSet.ItemRow
        Dim row, rowUPC As InventoryManagementSystemDataSet.ItemRow
        Dim table As InventoryManagementSystemDataSet.ItemDataTable = adapter.GetData()
        For Each row In table.Rows
            If row.Item(1).Equals(pUPC) Then
                rowUPC = row
            End If
        Next
        Return rowUPC
    End Function


End Class
