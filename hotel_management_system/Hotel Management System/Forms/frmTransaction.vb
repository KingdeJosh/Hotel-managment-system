Imports System.Data.SqlClient
Public Class frmTransaction
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Trans")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtTransactionID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtTransactionID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Sub Reset()
        txtEmployeeName.Text = ""
        txtTransactionAmount.Text = ""
        dtpTransactionDate.Text = Now
        cmbTransactionType.SelectedIndex = -1
        cmbTransDetails.Text = ""
        cmbMonth.SelectedIndex = -1
        txtAmountReceived.Text = ""
        txtDueAmount.Text = ""
        txtEmployeeName.Focus()
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnSave.Enabled = True
        txtAmountReceived.ReadOnly = True
        dtpTransactionDate.Enabled = True
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtEmployeeName.Text)) = 0 Then
            MessageBox.Show("Please enter employee/party name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmployeeName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbTransactionType.Text)) = 0 Then
            MessageBox.Show("Please select transaction type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTransactionType.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbMonth.Text)) = 0 Then
            MessageBox.Show("Please select month", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbMonth.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTransactionAmount.Text)) = 0 Then
            MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTransactionAmount.Focus()
            Exit Sub
        End If
        Try
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Trans(Id,Employee_Party_Name,TransactionType,TransactionMonth,TransactionDate,TransactionAmount,AmountReceived,DueAmount,TransactionDetails) VALUES (" & txtTransactionID.Text & ",@d1,'" & cmbTransactionType.Text & "','" & cmbMonth.Text & "',@d3," & txtTransactionAmount.Text & ",0," & Val(txtTransactionAmount.Text) - Val(txtAmountReceived.Text) & ",@d2)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtEmployeeName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbTransDetails.Text)
            cmd.Parameters.AddWithValue("@d3", dtpTransactionDate.Value)
            cmd.ExecuteReader()
            btnSave.Enabled = False
            Autocomplete()
            fillTransDetails()
            con.Close()
            Dim st As String = "added the new transaction record of transaction id '" & txtTransactionID.Text & "' related to employee/party name '" & txtEmployeeName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Autocomplete()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmd As New SqlCommand("SELECT distinct Employee_Party_Name FROM Trans", con)
            Dim ds As New DataSet()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "Transaction")
            Dim col As New AutoCompleteStringCollection()
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("Employee_Party_Name").ToString())
            Next
            txtEmployeeName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtEmployeeName.AutoCompleteCustomSource = col
            txtEmployeeName.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Len(Trim(txtEmployeeName.Text)) = 0 Then
                MessageBox.Show("Please enter employee/party name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmployeeName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbTransactionType.Text)) = 0 Then
                MessageBox.Show("Please select transaction type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbTransactionType.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbMonth.Text)) = 0 Then
                MessageBox.Show("Please select month", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbMonth.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTransactionAmount.Text)) = 0 Then
                MessageBox.Show("Please enter transaction amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransactionAmount.Focus()
                Exit Sub
            End If
            If (txtAmountReceived.Text = "") Then
                txtAmountReceived.Text = 0
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Trans set Employee_Party_Name=@d1,TransactionType='" & cmbTransactionType.Text & "',TransactionMonth='" & cmbMonth.Text & "',TransactionAmount=" & txtTransactionAmount.Text & ",AmountReceived= " & txtAmountReceived.Text & ",TransactionDetails=@d2,DueAmount=" & txtDueAmount.Text & " where ID= " & txtTransactionID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtEmployeeName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbTransDetails.Text)
            cmd.ExecuteReader()
            btnUpdate.Enabled = False
            Autocomplete()
            fillTransDetails()
            con.Close()
            Dim st As String = "updated the transaction record of transaction id '" & txtTransactionID.Text & "' related to employee/party name '" & txtEmployeeName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Trans where ID = " & txtTransactionID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the transaction record of transaction id '" & txtTransactionID.Text & "' related to employee/party name '" & txtEmployeeName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Autocomplete()
                fillTransDetails()
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

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        frmTransactionRecord.lblSet.Text = "Transaction"
        frmTransactionRecord.Reset()
        frmTransactionRecord.ShowDialog()
    End Sub
    Sub fillTransDetails()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TransactionDetails) FROM trans", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbTransDetails.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbTransDetails.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTransactionAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransactionAmount.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAmountReceived_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmountReceived.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAmountReceived_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountReceived.Validating
        If Val(txtAmountReceived.Text) > Val(txtTransactionAmount.Text) Then
            MessageBox.Show("Received/Returned amount is more than Transaction amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmountReceived.Text = ""
            txtAmountReceived.Focus()
        End If
    End Sub

    Private Sub txtTransactionAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransactionAmount.TextChanged
        txtDueAmount.Text = Val(txtTransactionAmount.Text) - Val(txtAmountReceived.Text)
    End Sub

    Private Sub txtAmountReceived_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmountReceived.TextChanged
        txtDueAmount.Text = Val(txtTransactionAmount.Text) - Val(txtAmountReceived.Text)
    End Sub

    Private Sub frmTransaction_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Autocomplete()
        fillTransDetails()
    End Sub

    Private Sub cmbTransDetails_Format(sender As Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbTransDetails.Format
        If e.DesiredType Is GetType(String) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub
End Class
