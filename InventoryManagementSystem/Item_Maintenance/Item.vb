Option Strict On
Option Explicit On

Public Class Item
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.ItemTableAdapter
    Private adapter2 As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter
    Private adapter3 As New InventoryManagementSystemDataSetTableAdapters.SaleTableAdapter
    Private frm As New frmMainInventoryForm

    Public Shared Property LastStatus As String

    Public Function getTotalItems() As Integer
        Dim table As InventoryManagementSystemDataSet.ItemDataTable
        table = adapter.GetData
        Return table.Count
    End Function

    Public Function getTotalPiece() As Integer
        Dim table As InventoryManagementSystemDataSet.ItemDataTable
        table = adapter.GetData
        Dim sum As Integer = Convert.ToInt32(table.Compute("SUM(inventory)", String.Empty))
        Return sum
    End Function

    Public Function getNumberCases() As Integer
        Dim cases As Double
        Dim array As New ArrayList
        Dim array2 As New ArrayList
        Dim table As InventoryManagementSystemDataSet.ItemDataTable = adapter.GetData
        Dim table2 As InventoryManagementSystemDataSet.ItemDetailDataTable = adapter2.GetData

        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow

        For Each tRow In table.Rows
            row = CType(tRow, InventoryManagementSystemDataSet.ItemRow)
            array.Add(row.inventory)
        Next

        For Each tRow In table2.Rows
            row2 = CType(tRow, InventoryManagementSystemDataSet.ItemDetailRow)
            array2.Add(row2.casequanity)
        Next

        For i As Integer = 0 To array.Count - 1
            Dim num1 As Integer = CInt(array.Item(i))
            Dim num2 As Integer = CInt(array2.Item(i))
            cases += num1 / num2
        Next

        Dim r As Double = Math.Ceiling(cases * 1)

        Return CInt(r)
    End Function

    Public Function GetDept(ByVal pDept As Integer) As DataTable
        Dim table As DataTable = adapter.GetData()
        table.DefaultView.RowFilter = "dept = " & pDept
        Return table
    End Function

    Public Function GetId(ByVal pDept As Integer) As Integer
        Dim id As Integer
        Dim table As InventoryManagementSystemDataSet.ItemDataTable
        table = adapter.GetDataByDept(pDept)
        If Not table.Rows.Count = 0 Then
            Dim tId As Integer = CInt(table.Compute("Max(Id)", Nothing))
            id = tId + 1
        Else
            id = pDept * 10000 + 1
        End If
        Return id
    End Function

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
                LastStatus = "Item added to database"
                result = True
            Else
                result = False
                LastStatus = "Error Adding Item to database"
            End If

        Catch ex As Exception
            result = False
            LastStatus = "Exception thrown adding to database"
        End Try

        Return result

    End Function

    Public Function Update(ByVal pId As Integer, ByVal pUPC As String, ByVal pDept As Integer,
                           ByVal pDescription As String, ByVal pInventory As Integer, ByVal pCap As Integer,
                           ByVal pCase As Integer, ByVal pSaleRate As Integer, ByVal pShelf As Integer,
                           ByVal pBack As Integer, ByVal pSale As Decimal, ByVal pCost As Decimal) As Boolean
        LastStatus = String.Empty
        Try
            adapter.Update(pId, pUPC, pDept, pDescription, pInventory)
            adapter2.Update(pId, pCap, pCase, pShelf, pBack, pSaleRate)
            adapter3.Update(pId, pSale, pCost)

            LastStatus = "Item Updated"
            Return True

        Catch ex As Exception
            LastStatus = ex.Message
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
