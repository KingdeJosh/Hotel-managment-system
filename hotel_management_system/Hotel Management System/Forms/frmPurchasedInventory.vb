Imports System.Data.SqlClient
Public Class frmPurchasedInventory
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM PurchasedInventory")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtPurchaseID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtPurchaseID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Sub Reset()
        cmbProductName.Text = ""
        txtQuantity.Text = ""
        cmbUnit.SelectedIndex = -1
        txtUnitPrice.Text = ""
        txtTotalPrice.Text = ""
        cmbCategory.Text = ""
        cmbPartyName.Text = ""
        cmbTransType.SelectedIndex = -1
        dtpPurchaseDate.Text = Today
        btnDelete.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = True
        cmbProductName.Focus()
    End Sub
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from PurchasedInventory where ID = " & txtPurchaseID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim st As String = "deleted the purchased inventory record for product '" & cmbProductName.Text & "'"
                Dim cb1 As String = "insert into Logs(userid,Operation,Date) VALUES (@d1,@d2,@d3)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", lblUser.Text)
                cmd.Parameters.AddWithValue("@d2", st)
                cmd.Parameters.AddWithValue("@d3", System.DateTime.Now)
                cmd.ExecuteReader()
                con.Close()
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                fillProductName()
                fillCategory()
                fillPartyname()
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmPurchasedInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillProductName()
        fillCategory()
        fillPartyname()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(cmbProductName.Text)) = 0 Then
            MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbProductName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbCategory.Text)) = 0 Then
            MessageBox.Show("Please enter Category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbTransType.Text)) = 0 Then
            MessageBox.Show("Please select transaction type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTransType.Focus()
            Exit Sub
        End If
        If Len(Trim(txtQuantity.Text)) = 0 Then
            MessageBox.Show("Please select quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbUnit.Text)) = 0 Then
            MessageBox.Show("Please select unit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbUnit.Focus()
            Exit Sub
        End If
        If Len(Trim(txtUnitPrice.Text)) = 0 Then
            MessageBox.Show("Please enter unit price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitPrice.Focus()
            Exit Sub
        End If
        Try
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into PurchasedInventory(ID,ProductName,Quantity,Unit,Price,PurchaseDate,TotalPrice,Category,TransactionType,PartyName) VALUES (" & txtPurchaseID.Text & ",@d1," & txtQuantity.Text & ",@d2," & txtUnitPrice.Text & ",@d3," & txtTotalPrice.Text & ",@d4,@d5,@d6)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbProductName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbUnit.Text)
            cmd.Parameters.AddWithValue("@d3", dtpPurchaseDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", cmbCategory.Text)
            cmd.Parameters.AddWithValue("@d5", cmbTransType.Text)
            cmd.Parameters.AddWithValue("@d6", cmbPartyName.Text)
            cmd.ExecuteReader()
            fillProductName()
            fillCategory()
            fillPartyname()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim st As String = "added the new purchased inventory record for product '" & cmbProductName.Text & "'"
            Dim cb1 As String = "insert into Logs(userid,Operation,Date) VALUES (@d1,@d2,@d3)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", lblUser.Text)
            cmd.Parameters.AddWithValue("@d2", st)
            cmd.Parameters.AddWithValue("@d3", System.DateTime.Now)
            cmd.ExecuteReader()
            con.Close()
            btnSave.Enabled = False
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(cmbProductName.Text)) = 0 Then
            MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbProductName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbCategory.Text)) = 0 Then
            MessageBox.Show("Please enter Category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbTransType.Text)) = 0 Then
            MessageBox.Show("Please select transaction type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTransType.Focus()
            Exit Sub
        End If
        If Len(Trim(txtQuantity.Text)) = 0 Then
            MessageBox.Show("Please select quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbUnit.Text)) = 0 Then
            MessageBox.Show("Please select unit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbUnit.Focus()
            Exit Sub
        End If
        If Len(Trim(txtUnitPrice.Text)) = 0 Then
            MessageBox.Show("Please enter unit price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitPrice.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update PurchasedInventory set ProductName=@d1,Quantity=" & txtQuantity.Text & ",Unit=@d2,Price=" & txtUnitPrice.Text & ",PurchaseDate=@d3,TotalPrice=" & txtTotalPrice.Text & ",Category=@d4,TransactionType=@d5,PartyName=@d6 where ID=" & txtPurchaseID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbProductName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbUnit.Text)
            cmd.Parameters.AddWithValue("@d3", dtpPurchaseDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", cmbCategory.Text)
            cmd.Parameters.AddWithValue("@d5", cmbTransType.Text)
            cmd.Parameters.AddWithValue("@d6", cmbPartyName.Text)
            cmd.ExecuteReader()
            fillProductName()
            fillCategory()
            fillPartyname()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim st As String = "updated the new purchased inventory record for product '" & cmbProductName.Text & "'"
            Dim cb1 As String = "insert into Logs(userid,Operation,Date) VALUES (@d1,@d2,@d3)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", lblUser.Text)
            cmd.Parameters.AddWithValue("@d2", st)
            cmd.Parameters.AddWithValue("@d3", System.DateTime.Now)
            cmd.ExecuteReader()
            con.Close()
            btnSave.Enabled = False
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillProductName()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ProductName) FROM PurchasedInventory", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbProductName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbProductName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillPartyname()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(PartyName) FROM PurchasedInventory", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbPartyName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbPartyName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCategory()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Category) FROM PurchasedInventory", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCategory.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        Me.Reset()
        frmPurchasedInventoryRecord.lblSet.Text = "Purchased Inventory"
        frmPurchasedInventoryRecord.Reset()
        frmPurchasedInventoryRecord.ShowDialog()
    End Sub

    Private Sub txtQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        Dim keyChar = e.KeyChar
        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtQuantity.Text
            Dim selectionStart = Me.txtQuantity.SelectionStart
            Dim selectionLength = Me.txtQuantity.SelectionLength
            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)
            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtUnitPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        Dim keyChar = e.KeyChar
        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtUnitPrice.Text
            Dim selectionStart = Me.txtUnitPrice.SelectionStart
            Dim selectionLength = Me.txtUnitPrice.SelectionLength
            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)
            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub
    Sub Compute()
        Dim num As Double
        num = Val(txtUnitPrice.Text) * Val(txtQuantity.Text)
        num = Math.Round(num, 2)
        txtTotalPrice.Text = num
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        Compute()
    End Sub

    Private Sub txtUnitPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitPrice.TextChanged
        Compute()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbCategory_Format(sender As Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbCategory.Format
        If e.DesiredType Is GetType(String) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub cmbPartyName_Format(sender As Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbPartyName.Format
        If e.DesiredType Is GetType(String) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub cmbProductName_Format(sender As Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbProductName.Format
        If e.DesiredType Is GetType(String) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub
End Class
