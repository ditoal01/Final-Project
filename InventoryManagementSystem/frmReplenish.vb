Option Explicit On
Option Strict On

Public Class frmReplenish
    'Class variables
    Private mReplenish As New Replenish
    Private mItem As New Item
    Private selectedItem As String
    Private frm As New frmMainInventoryForm

    ''' <summary>
    ''' Cancel button handler that calls dashboard form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Create dashboard form
        Dim dashboard As New frmDashboard
        'Set dashboard MDI Parent to parent form
        dashboard.MdiParent = Me.ParentForm
        dashboard.WindowState = FormWindowState.Maximized
        dashboard.Show()
    End Sub

    ''' <summary>
    ''' Close form when deactivated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmReplenish_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Close form when inactive
        Me.Close()
    End Sub

    ''' <summary>
    ''' Load form and update status label
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmReplenish_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm = CType(Me.ParentForm, frmMainInventoryForm)
        frm.UpdateStatus("Select item to replenish sale floor inventory.")
        FrmLoad()


    End Sub

    ''' <summary>
    ''' Search for item in database
    ''' </summary>
    ''' <param name="pId">item number</param>
    Private Sub Search(ByVal pId As Integer)
        Dim rowItem As InventoryManagementSystemDataSet.ItemRow
        Dim rowDetail As InventoryManagementSystemDataSet.ItemDetailRow

        rowItem = mItem.FindItem(pId)
        rowDetail = mItem.FindDetail(pId)
        'Check if item and details are found and update labels
        If rowItem IsNot Nothing And rowDetail IsNot Nothing Then
            lblItemNumber.Text = rowItem.Id.ToString
            lblUPCNumber.Text = rowItem.upc.ToString
            lblDescription.Text = rowItem.description.ToString
            lblDepartmentNumber.Text = rowItem.dept.ToString
            lblInventory.Text = rowItem.inventory.ToString
            lblShelfCap.Text = rowDetail.shelfcap.ToString
            lblCaseQuanity.Text = rowDetail.casequanity.ToString
            lblSalesRate.Text = rowDetail.rate.ToString
            lblShelfTotal.Text = rowDetail.invshelf.ToString
            lblBackroomTotal.Text = rowDetail.invback.ToString
        Else

        End If
    End Sub

    ''' <summary>
    ''' Datagridview handler that updates form when cell is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvReplenish_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReplenish.CellClick
        Dim i As Integer
        i = e.RowIndex
        'update form
        selectedItem = dgvReplenish.Item(0, i).Value.ToString
        Search(CInt(selectedItem))
    End Sub

    ''' <summary>
    ''' Replenish button handler that updates database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnReplenish_Click(sender As Object, e As EventArgs) Handles btnReplenish.Click
        'Check if item is updated
        If mReplenish.UpdateInv(selectedItem) Then
            dgvReplenish.DataSource = mReplenish.Replenish
            'Check if items are in datagrid
            If dgvReplenish.RowCount >= 1 Then
                selectedItem = dgvReplenish.Item(0, 0).Value.ToString
                Search(CInt(selectedItem))
            Else
                selectedItem = String.Empty
            End If
            FrmLoad()
            frm.UpdateStatus("Item has been replenished.")
        Else
            frm.UpdateStatus("No item to replenish.")
        End If
    End Sub

    ''' <summary>
    ''' Procedure that updates form
    ''' </summary>
    Private Sub FrmLoad()
        dgvReplenish.DataSource = mReplenish.Replenish

        If dgvReplenish.RowCount > 0 Then
            selectedItem = dgvReplenish.Item(0, 0).Value.ToString
            Search(CInt(selectedItem))
        Else
            lblItemNumber.Text = String.Empty
            lblUPCNumber.Text = String.Empty
            lblDescription.Text = String.Empty
            lblDepartmentNumber.Text = String.Empty
            lblInventory.Text = String.Empty
            lblShelfCap.Text = String.Empty
            lblCaseQuanity.Text = String.Empty
            lblSalesRate.Text = String.Empty
            lblShelfTotal.Text = String.Empty
            lblBackroomTotal.Text = String.Empty
        End If
    End Sub
End Class