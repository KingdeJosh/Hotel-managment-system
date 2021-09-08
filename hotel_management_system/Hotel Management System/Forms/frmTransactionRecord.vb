Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmTransactionRecord
    Sub fillEmployeeName()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Employee_Party_Name) FROM Trans", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbEmployeeName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbEmployeeName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If lblSet.Text = "Transaction" Then
                    Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                    Me.Hide()
                    frmTransaction.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmTransaction.txtTransactionID.Text = dr.Cells(0).Value.ToString()
                    frmTransaction.txtEmployeeName.Text = dr.Cells(1).Value.ToString()
                    frmTransaction.cmbTransactionType.Text = dr.Cells(2).Value.ToString()
                    frmTransaction.cmbTransDetails.Text = dr.Cells(3).Value.ToString()
                    frmTransaction.cmbMonth.Text = dr.Cells(4).Value.ToString()
                    frmTransaction.dtpTransactionDate.Text = dr.Cells(5).Value.ToString()
                    frmTransaction.txtTransactionAmount.Text = dr.Cells(6).Value.ToString()
                    frmTransaction.txtAmountReceived.Text = dr.Cells(7).Value.ToString()
                    frmTransaction.txtDueAmount.Text = dr.Cells(8).Value.ToString()
                    frmTransaction.btnUpdate.Enabled = True
                    frmTransaction.btnDelete.Enabled = True
                    frmTransaction.btnSave.Enabled = False
                    frmTransaction.txtAmountReceived.ReadOnly = False
                    frmTransaction.dtpTransactionDate.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick

        Try
            If DataGridView2.Rows.Count > 0 Then
                If lblSet.Text = "Transaction" Then
                    Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
                    Me.Hide()
                    frmTransaction.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmTransaction.txtTransactionID.Text = dr.Cells(0).Value.ToString()
                    frmTransaction.txtEmployeeName.Text = dr.Cells(1).Value.ToString()
                    frmTransaction.cmbTransactionType.Text = dr.Cells(2).Value.ToString()
                    frmTransaction.cmbTransDetails.Text = dr.Cells(3).Value.ToString()
                    frmTransaction.cmbMonth.Text = dr.Cells(4).Value.ToString()
                    frmTransaction.dtpTransactionDate.Text = dr.Cells(5).Value.ToString()
                    frmTransaction.txtTransactionAmount.Text = dr.Cells(6).Value.ToString()
                    frmTransaction.txtAmountReceived.Text = dr.Cells(7).Value.ToString()
                    frmTransaction.txtDueAmount.Text = dr.Cells(8).Value.ToString()
                    frmTransaction.btnUpdate.Enabled = True
                    frmTransaction.btnDelete.Enabled = True
                    frmTransaction.btnSave.Enabled = False
                    frmTransaction.txtAmountReceived.ReadOnly = False
                    frmTransaction.dtpTransactionDate.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub DataGridView2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView2.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub Reset()
        DateFrom.Text = Today
        DateTo.Text = Now
        DataGridView2.DataSource = Nothing
        cmbEmployeeName.Text = ""
        txtEmployeeName.Text = ""
        DataGridView1.DataSource = Nothing
        DataGridView3.DataSource = Nothing
        cmbTransactionType.SelectedIndex = -1
        DateTimePicker2.Text = Today
        DateTimePicker1.Text = Now
        fillEmployeeName()
    End Sub
    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        Reset()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If DataGridView1.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView1.RowCount
            colsTotal = DataGridView1.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView1.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView1.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView2.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView2.RowCount
            colsTotal = DataGridView2.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView2.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView2.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [Transaction ID], RTRIM(Employee_Party_name) as [Employee/Party Name],RTRIM(TransactionType) as [Transaction Type],RTRIM(TransactionDetails) as [Transaction Details],RTRIM(TransactionMonth) as [Month],CONVERT(DateTime,TransactionDate,131) as [Transaction Date],RTRIM(TransactionAmount) as [Transaction Amount],RTRIM(AmountReceived) as [Amount Received/Returned],RTRIM(DueAmount) as [Due Amount] from Trans where TransactionDate between @d1 and @d2 order by Employee_Party_Name,TransactionDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Trans")
            DataGridView2.DataSource = myDataSet.Tables("Trans").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        cmbEmployeeName.Text = ""
        txtEmployeeName.Text = ""
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView2.DataSource = Nothing
        DateFrom.Text = Today
        DateTo.Text = Today

    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Me.Close()
    End Sub

    Private Sub cmbEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmployeeName.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [Transaction ID], RTRIM(Employee_Party_name) as [Employee/Party Name],RTRIM(TransactionType) as [Transaction Type],RTRIM(TransactionDetails) as [Transaction Details],RTRIM(TransactionMonth) as [Month],CONVERT(DateTime,TransactionDate,131) as [Transaction Date],RTRIM(TransactionAmount) as [Transaction Amount],RTRIM(AmountReceived) as [Amount Received/Returned],RTRIM(DueAmount) as [Due Amount] from Trans where Employee_Party_Name=@d1 order by Employee_Party_Name,TransactionDate", con)
            cmd.Parameters.AddWithValue("@d1", cmbEmployeeName.Text)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Trans")
            DataGridView1.DataSource = myDataSet.Tables("Trans").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtEmployeeName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployeeName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [Transaction ID], RTRIM(Employee_Party_name) as [Employee/Party Name],RTRIM(TransactionType) as [Transaction Type],RTRIM(TransactionDetails) as [Transaction Details],RTRIM(TransactionMonth) as [Month],CONVERT(DateTime,TransactionDate,131) as [Transaction Date],RTRIM(TransactionAmount) as [Transaction Amount],RTRIM(AmountReceived) as [Amount Received/Returned],RTRIM(DueAmount) as [Due Amount] from Trans where Employee_Party_Name like '" & txtEmployeeName.Text & "%' order by Employee_Party_Name,TransactionDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Trans")
            DataGridView1.DataSource = myDataSet.Tables("Trans").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If DataGridView3.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView3.RowCount
            colsTotal = DataGridView3.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView3.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView3.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        cmbTransactionType.SelectedIndex = -1
        DateTimePicker2.Text = Today
        DateTimePicker1.Text = Today
        DataGridView3.DataSource = Nothing
    End Sub

    Private Sub DataGridView3_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView3.MouseClick
        Try
            If DataGridView3.Rows.Count > 0 Then
                If lblSet.Text = "Transaction" Then
                    Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
                    Me.Hide()
                    frmTransaction.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmTransaction.txtTransactionID.Text = dr.Cells(0).Value.ToString()
                    frmTransaction.txtEmployeeName.Text = dr.Cells(1).Value.ToString()
                    frmTransaction.cmbTransactionType.Text = dr.Cells(2).Value.ToString()
                    frmTransaction.cmbTransDetails.Text = dr.Cells(3).Value.ToString()
                    frmTransaction.cmbMonth.Text = dr.Cells(4).Value.ToString()
                    frmTransaction.dtpTransactionDate.Text = dr.Cells(5).Value.ToString()
                    frmTransaction.txtTransactionAmount.Text = dr.Cells(6).Value.ToString()
                    frmTransaction.txtAmountReceived.Text = dr.Cells(7).Value.ToString()
                    frmTransaction.txtDueAmount.Text = dr.Cells(8).Value.ToString()
                    frmTransaction.btnUpdate.Enabled = True
                    frmTransaction.btnDelete.Enabled = True
                    frmTransaction.btnSave.Enabled = False
                    frmTransaction.txtAmountReceived.ReadOnly = False
                    frmTransaction.dtpTransactionDate.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView3_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView3.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If Len(Trim(cmbTransactionType.Text)) = 0 Then
                MessageBox.Show("Please select transaction type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbTransactionType.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [Transaction ID], RTRIM(Employee_Party_name) as [Employee/Party Name],RTRIM(TransactionType) as [Transaction Type],RTRIM(TransactionDetails) as [Transaction Details],RTRIM(TransactionMonth) as [Month],CONVERT(DateTime,TransactionDate,131) as [Transaction Date],RTRIM(TransactionAmount) as [Transaction Amount],RTRIM(AmountReceived) as [Amount Received/Returned],RTRIM(DueAmount) as [Due Amount] from Trans where TransactionDate between @d1 and @d2 and TransactionType='" & cmbTransactionType.Text & "' order by Employee_Party_Name,TransactionDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Trans")
            DataGridView3.DataSource = myDataSet.Tables("Trans").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmTransactionRecord_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillEmployeeName()
    End Sub
End Class
