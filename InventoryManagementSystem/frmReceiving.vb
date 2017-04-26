Option Explicit On
Option Strict On

Public Class frmReceiving
    Private mReceiving As New Receiving
    Private mItems As New Item
    Private selectedItem As String
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI Parent to parent
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    ''' <summary>
    ''' Close form is deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmReceiving_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Form load that sets frm to parent and updates status label
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmReceiving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        frm.UpdateStatus("Select item to complete receiving.")
        loadForm()

    End Sub

    ''' <summary>
    ''' Handles if cell is clicked and udpate form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvReceiveItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReceiveItems.CellClick
        Dim i As Integer
        i = e.RowIndex
        'Update form and select item
        selectedItem = dgvReceiveItems.Item(0, i).Value.ToString
        Search(CInt(selectedItem))
        frm.UpdateStatus("Select item to complete receiving.")
    End Sub

    ''' <summary>
    ''' Procedure that searches for item
    ''' </summary>
    ''' <param name="pId">item number</param>
    Private Sub Search(ByVal pId As Integer)

        Dim row As InventoryManagementSystemDataSet.ItemRow
        row = mItems.FindItem(pId)
        'Check if item is found
        If row IsNot Nothing Then
            lblItemNumber.Text = row.Id.ToString
            lblUPCNumber.Text = row.upc.ToString
            lblDescription.Text = row.description.ToString
            lblDepartmentNumber.Text = row.dept.ToString
        Else

        End If
    End Sub

    ''' <summary>
    ''' Update button handler that updates inventory
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim row As InventoryManagementSystemDataSet.ItemRow
        Dim rowDetail As InventoryManagementSystemDataSet.ItemDetailRow
        Dim receive As InventoryManagementSystemDataSet.ReceivingRow
        If dgvReceiveItems.RowCount > 0 Then
            'Check for items
            row = mItems.FindItem(CInt(selectedItem))
            receive = mReceiving.FindById(CInt(selectedItem))
            rowDetail = mItems.FindDetail(CInt(selectedItem))
            'Check if receiving details found
            If receive IsNot Nothing And (receive.receivingDate <= Date.Today) Then
                'udpate item
                row.inventory += receive.OnOrder
                mItems.Udpate(row)
                rowDetail.invback += receive.OnOrder
                mItems.UpdateDetail(rowDetail)

                mReceiving.Delete(CInt(selectedItem))
                dgvReceiveItems.DataSource = mReceiving.receive
                'Check if items in datagridview
                If dgvReceiveItems.RowCount = 1 Then
                    selectedItem = dgvReceiveItems.Item(0, 0).Value.ToString
                    Search(CInt(selectedItem))
                Else
                    selectedItem = String.Empty
                End If
                frm.UpdateStatus("Item has been received, inventory updated.")
            Else
                frm.UpdateStatus("Item not available yet, item will be ready on receive date.")
            End If
        Else
            selectedItem = String.Empty
        End If
        loadForm()
    End Sub

    ''' <summary>
    ''' Procedure that udpates form
    ''' </summary>
    Private Sub loadForm()
        mReceiving.OnOrder()
        dgvReceiveItems.DataSource = mReceiving.receive
        If dgvReceiveItems.RowCount > 0 Then
            selectedItem = dgvReceiveItems.Item(0, 0).Value.ToString
            Search(CInt(selectedItem))
        Else
            lblItemNumber.Text = String.Empty
            lblUPCNumber.Text = String.Empty
            lblDescription.Text = String.Empty
            lblDepartmentNumber.Text = String.Empty
        End If
        lblReceiveItem.Text = mReceiving.getTotalItems.ToString
        lblReceivePiece.Text = mReceiving.getTotalPiece.ToString
        lblReceiveCase.Text = mReceiving.getNumberCases.ToString
    End Sub

End Class