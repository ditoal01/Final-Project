Option Strict On
Option Explicit On

Public Class Item
    'Class variables
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.ItemTableAdapter
    Private adapter2 As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter
    Private adapter3 As New InventoryManagementSystemDataSetTableAdapters.SaleTableAdapter
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' Function that gets total number in database
    ''' </summary>
    ''' <returns>total number</returns>
    Public Function getTotalItems() As Integer
        Dim table As InventoryManagementSystemDataSet.ItemDataTable
        table = adapter.GetData
        Return table.Count
    End Function

    ''' <summary>
    ''' Function that gets total number of pieces in database
    ''' </summary>
    ''' <returns>total number of pieces</returns>
    Public Function getTotalPiece() As Integer
        Dim table As InventoryManagementSystemDataSet.ItemDataTable
        table = adapter.GetData
        Dim sum As Integer
        If table.Count > 0 And table IsNot Nothing Then
            sum = Convert.ToInt32(table.Compute("SUM(inventory)", String.Empty))
            Return sum
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Function that gets number of cases
    ''' </summary>
    ''' <returns></returns>
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

    ''' <summary>
    ''' function that gets department data
    ''' </summary>
    ''' <param name="pDept">department number</param>
    ''' <returns>datatable</returns>
    Public Function GetDept(ByVal pDept As Integer) As DataTable
        Dim table As DataTable = adapter.GetData()
        table.DefaultView.RowFilter = "dept = " & pDept
        Return table
    End Function

    ''' <summary>
    ''' function that gets item number
    ''' </summary>
    ''' <param name="pDept">department number</param>
    ''' <returns>id</returns>
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

    ''' <summary>
    ''' Property for item
    ''' </summary>
    ''' <returns>datatable</returns>
    Public ReadOnly Property Items() As DataTable
        Get

            Dim table As DataTable = adapter.GetDataBy()
            table.DefaultView.Sort = "Id"
            Return table
        End Get
    End Property

    ''' <summary>
    ''' Add item to database
    ''' </summary>
    ''' <returns>return if successful</returns>
    Public Function Insert(ByVal pId As Integer, ByVal pUPC As String, ByVal pDept As Integer,
                           ByVal pDescription As String, ByVal pInventory As Integer, ByVal pCap As Integer,
                           ByVal pCase As Integer, ByVal pSaleRate As Integer, ByVal pShelf As Integer,
                           ByVal pBack As Integer, ByVal pSale As Decimal, ByVal pCost As Decimal) As Boolean

        Dim result As Boolean = False
        'Check if item is added
        Try
            If adapter.Insert(pId, pUPC, pDept, pDescription, pInventory) > 0 And
                adapter2.Insert(pId, pCap, pCase, pShelf, pBack, pSaleRate) > 0 And
                adapter3.Insert(pId, pSale, pCost) > 0 Then
                result = True
            Else
                result = False
            End If

        Catch ex As Exception
            result = False
        End Try

        Return result

    End Function

    ''' <summary>
    ''' Update item in databae
    ''' </summary>
    ''' <param name="pRow">datarow</param>
    ''' <returns>return if successful</returns>
    Public Function UpdateDetail(ByVal pRow As DataRow) As Boolean
        adapter2.Update(pRow)
        Return True
    End Function

    ''' <summary>
    ''' Update item in database
    ''' </summary>
    ''' <param name="pRow">datarow</param>
    ''' <returns>return if successful</returns>
    Public Overloads Function Udpate(ByVal pRow As DataRow) As Boolean
        adapter.Update(pRow)
        Return True
    End Function

    ''' <summary>
    ''' Update item in database
    ''' </summary>
    ''' <returns></returns>
    Public Overloads Function Update(ByVal pId As Integer, ByVal pUPC As String, ByVal pDept As Integer,
                           ByVal pDescription As String, ByVal pInventory As Integer, ByVal pCap As Integer,
                           ByVal pCase As Integer, ByVal pSaleRate As Integer, ByVal pShelf As Integer,
                           ByVal pBack As Integer, ByVal pSale As Decimal, ByVal pCost As Decimal) As Boolean
        'Check if item is updated in database
        Try
            adapter.Update(pId, pUPC, pDept, pDescription, pInventory)
            adapter2.Update(pId, pCap, pCase, pShelf, pBack, pSaleRate)
            adapter3.Update(pId, pSale, pCost)
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' delete item
    ''' </summary>
    ''' <param name="pId">item number</param>
    ''' <returns>return if true</returns>
    Public Function Delete(ByVal pId As Integer) As Boolean
        Dim rowsAffected As Integer = adapter.Delete(pId)
        Return rowsAffected > 0
    End Function


    ''' <summary>
    ''' Find information from id
    ''' </summary>
    ''' <param name="pId">item number</param>
    ''' <returns>item detail row</returns>
    Public Function FindDetail(ByVal pId As Integer) As InventoryManagementSystemDataSet.ItemDetailRow
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable
        table = adapter2.GetData()
        Return table.FindById(pId)
    End Function

    ''' <summary>
    ''' find sale information
    ''' </summary>
    ''' <param name="pId">item number</param>
    ''' <returns>sale row</returns>
    Public Function FindSale(ByVal pId As Integer) As InventoryManagementSystemDataSet.SaleRow
        Dim table As InventoryManagementSystemDataSet.SaleDataTable
        table = adapter3.GetData()
        Return table.FindById(pId)
    End Function

    ''' <summary>
    ''' Function to find markup
    ''' </summary>
    ''' <param name="pPrice">price</param>
    ''' <param name="pCost">cose</param>
    ''' <returns>return markup</returns>
    Public Function Markup(ByVal pPrice As Decimal, ByVal pCost As Decimal) As Decimal
        Dim grossProfitMargin As Decimal = pPrice - pCost
        Return grossProfitMargin / pCost
    End Function

    ''' <summary>
    ''' find item
    ''' </summary>
    ''' <param name="pId">item number</param>
    ''' <returns>item row</returns>
    Public Function FindItem(ByVal pId As Integer) As InventoryManagementSystemDataSet.ItemRow
        Dim table As InventoryManagementSystemDataSet.ItemDataTable
        table = adapter.GetData()
        Return table.FindById(pId)
    End Function

    ''' <summary>
    ''' Update dashboard listview
    ''' </summary>
    ''' <returns>array</returns>
    Public Function updateDashboard() As ArrayList
        Dim table As InventoryManagementSystemDataSet.ItemDataTable = adapter.GetData()
        Dim rowItem As InventoryManagementSystemDataSet.ItemDetailRow
        Dim rowReceive As InventoryManagementSystemDataSet.ReceivingRow
        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim array As New ArrayList
        Dim list As New ListViewItem()
        Dim fill As Char = " "c
        Dim check As Boolean = True
        'Add out of stock information to array
        For Each tRow In table.Rows
            row = CType(tRow, InventoryManagementSystemDataSet.ItemRow)
            If row.inventory = 0 Then
                If check Then
                    array.Add("Out of Stock")
                    array.Add("")
                    array.Add("")
                    array.Add("")
                    array.Add("Item Number")
                    array.Add("UPC")
                    array.Add("Description")
                    array.Add("Inventory")
                    check = False
                End If
                array.Add(row.Id.ToString)
                array.Add(row.upc)
                array.Add(row.description)
                array.Add(row.inventory.ToString)
            End If
        Next
        check = True
        'Add overstock information to array
        For Each tRow In table.Rows
            If check Then
                array.Add("Overstock:")
                array.Add("")
                array.Add("")
                array.Add("")
                array.Add("Item Number")
                array.Add("Shelf Stock")
                array.Add("Description")
                array.Add("Shelf Cap")
                check = False
            End If

            row = CType(tRow, InventoryManagementSystemDataSet.ItemRow)
            rowItem = FindDetail(row.Id)
            If rowItem.shelfcap < rowItem.invshelf Then

                array.Add(row.Id.ToString)
                array.Add(rowItem.invshelf.ToString)
                array.Add(row.description)
                array.Add(rowItem.shelfcap.ToString)
            End If
        Next

        check = True
        Dim receiving As New Receiving
        'Add receiving information to array
        For Each tRow In table.Rows
            If check Then
                array.Add("Receiving:")
                array.Add("")
                array.Add("")
                array.Add("")
                array.Add("Item Number")
                array.Add("Receive")
                array.Add("Description")
                array.Add("On Order")
                check = False
            End If

            row = CType(tRow, InventoryManagementSystemDataSet.ItemRow)
            rowReceive = receiving.FindById(row.Id)
            If rowReceive IsNot Nothing Then
                If (rowReceive.receivingDate <= Date.Today) Then

                    array.Add(row.Id.ToString)
                    array.Add(rowReceive.receivingDate)
                    array.Add(row.description)
                    array.Add(rowReceive.OnOrder)
                End If
            End If
        Next

        Return array
    End Function

End Class
