Public Class Department
    Private adapter As New InventoryManagementSystemDataSetTableAdapters.departmentTableAdapter
    Public Shared Property LastError As String


    ''' <summary>
    ''' Property for department
    ''' </summary>
    ''' <returns>Department data</returns>
    Public ReadOnly Property Dept As DataTable
        Get
            Return adapter.GetData()
        End Get
    End Property

    ''' <summary>
    ''' Search for department in database
    ''' </summary>
    ''' <param name="pDeptId">department number</param>
    ''' <returns>department data row</returns>
    Public Function FindByDeptId(ByVal pDeptId) As InventoryManagementSystemDataSet.departmentRow
        Dim table As InventoryManagementSystemDataSet.departmentDataTable
        table = adapter.GetData()
        Return table.FindBydept(pDeptId)
    End Function

    ''' <summary>
    ''' Add department to database
    ''' </summary>
    ''' <param name="pDeptId">department number</param>
    ''' <param name="pDescription">department description</param>
    ''' <returns>return if successful </returns>
    Public Function Insert(ByVal pDeptId, ByVal pDescription) As Boolean
        Try
            LastError = String.Empty
            adapter.Insert(pDeptId, pDescription)
            Return True

        Catch ex As Exception
            LastError = ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Delete department from database
    ''' </summary>
    ''' <param name="pDeptId">department number</param>
    ''' <returns>return if successful</returns>
    Public Function Delete(ByVal pDeptId As Integer) As Boolean
        Dim rowsAffected As Integer = 0
        Try
            rowsAffected = adapter.Delete(pDeptId)
        Catch ex As Exception
            LastError = ex.Message & ", items in department"
        End Try

        Return rowsAffected > 0
    End Function

    ''' <summary>
    ''' Update department information in database
    ''' </summary>
    ''' <param name="pDeptId">department number</param>
    ''' <param name="pDescription">department description</param>
    ''' <returns></returns>
    Public Function Update(ByVal pDeptId As Integer, ByVal pDescription As String) As Boolean
        LastError = String.Empty

        Try
            adapter.Update(pDeptId, pDescription)
            Return True

        Catch ex As Exception
            LastError = ex.Message
            Return False
        End Try
    End Function
End Class
