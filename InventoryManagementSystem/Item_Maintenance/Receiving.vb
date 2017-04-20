Option Explicit On
Option Strict On

Public Class Receiving
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.ReceivingTableAdapter
    Private adapterId As New InventoryManagementSystemDataSetTableAdapters.ItemTableAdapter
    Private adapterItem As New InventoryManagementSystemDataSetTableAdapters.ItemDetailTableAdapter
    Private mItems As New Item
    Public Shared Property LastError As String

    Public ReadOnly Property receive As DataTable
        Get
            Return adapter.GetData()
        End Get
    End Property

    Public Function getTotalItems() As Integer
        Dim table As InventoryManagementSystemDataSet.ReceivingDataTable
        table = adapter.GetData
        Return table.Count
    End Function

    Public Function getTotalPiece() As Integer
        Dim sum As Integer = 0
        Dim table As InventoryManagementSystemDataSet.ReceivingDataTable
        table = adapter.GetData
        If table.Count > 0 And table IsNot Nothing Then
            sum = Convert.ToInt32(table.Compute("SUM(OnOrder)", String.Empty))
        End If

        Return sum
    End Function

    Public Function getNumberCases() As Integer
        Dim cases As Double
        Dim array As New ArrayList
        Dim array2 As New ArrayList
        Dim table As InventoryManagementSystemDataSet.ReceivingDataTable = adapter.GetData
        Dim table2 As InventoryManagementSystemDataSet.ItemDetailDataTable = adapterItem.GetData

        Dim row As InventoryManagementSystemDataSet.ReceivingRow
        Dim row2 As InventoryManagementSystemDataSet.ItemDetailRow

        For Each tRow In table.Rows
            row = CType(tRow, InventoryManagementSystemDataSet.ReceivingRow)
            array.Add(row.OnOrder)
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

    Public Function FindById(ByVal pReceiveId As Integer) As InventoryManagementSystemDataSet.ReceivingRow
        Dim table As InventoryManagementSystemDataSet.ReceivingDataTable
        table = adapter.GetData()
        Return table.FindById(pReceiveId)
    End Function

    Public Function Delete(ByVal pReceiveId As Integer) As Boolean
        Dim rowsAffected As Integer = 0
        Try
            rowsAffected = adapter.Delete(pReceiveId)
        Catch ex As Exception
            LastError = ex.Message
        End Try

        Return rowsAffected > 0
    End Function

    Public Sub OnOrder()
        Dim table As InventoryManagementSystemDataSet.ItemDetailDataTable = adapterItem.GetData()
        Dim row As InventoryManagementSystemDataSet.ItemDetailRow
        Dim check As Boolean = False
        For Each trow In table.Rows

            row = CType(trow, InventoryManagementSystemDataSet.ItemDetailRow)

            Dim total As Integer = row.invshelf + row.invback
            If (total < (row.rate * 2)) And Not (total = 0) Then
                Try
                    Dim numberOfCases As Integer = CInt((row.rate * 2) / total)
                    adapter.Insert(row.Id, (row.casequanity * numberOfCases), check)
                Catch ex As Exception
                    LastError = ex.Message & ", Unable to create orders"
                End Try
            ElseIf total = 0 Then
                Try
                    adapter.Insert(row.Id, row.casequanity, check)
                Catch ex As Exception
                    LastError = ex.Message
                End Try

            End If
        Next
    End Sub

End Class
