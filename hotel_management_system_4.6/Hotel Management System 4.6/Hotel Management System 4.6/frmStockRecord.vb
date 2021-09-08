﻿Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmStockRecord

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(Stock_ID), [Date], Supplier.ID,RTRIM(Supplier.SupplierID),RTRIM(Supplier.Name), GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks) from Supplier,Stock where Supplier.ID=Stock.SupplierID order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                frmStock.Show()
                Me.Hide()
                frmStock.txtST_ID.Text = dr.Cells(0).Value.ToString()
                frmStock.txtStockID.Text = dr.Cells(1).Value.ToString()
                frmStock.dtpDate.Text = dr.Cells(2).Value.ToString()
                frmStock.txtSup_ID.Text = dr.Cells(3).Value.ToString()
                frmStock.txtSupplierID.Text = dr.Cells(4).Value.ToString()
                frmStock.txtSupplierName.Text = dr.Cells(5).Value.ToString()
                frmStock.txtGrandTotal.Text = dr.Cells(6).Value.ToString()
                frmStock.txtTotalPayment.Text = dr.Cells(7).Value.ToString()
                frmStock.txtPaymentDue.Text = dr.Cells(8).Value.ToString()
                frmStock.txtRemarks.Text = dr.Cells(9).Value.ToString()
                frmStock.btnSave.Enabled = False
                frmStock.btnUpdate.Enabled = True
                frmStock.dtpDate.Enabled = False
                frmStock.DataGridView1.Enabled = False
                frmStock.btnAdd.Enabled = False
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT PID,RTRIM(Product.ProductCode),RTRIM(Productname),Qty,Price,TotalAmount from Stock,Stock_Product,product where product.PID=Stock_product.ProductID and Stock.ST_ID=Stock_Product.StockID and ST_ID=" & dr.Cells(0).Value & ""
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmStock.DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    frmStock.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub Reset()
        txtSupplierName.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        DateTimePicker2.Text = Today
        DateTimePicker1.Text = Today
        Getdata()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtSupplierName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSupplierName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(Stock_ID), [Date], Supplier.ID,RTRIM(Supplier.SupplierID),RTRIM(Supplier.Name), GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks) from Supplier,Stock where Supplier.ID=Stock.SupplierID  and [Name] like '%" & txtSupplierName.Text & "%' order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = dgw.RowCount
            colsTotal = dgw.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = dgw.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = dgw.Rows(I).Cells(j).Value
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

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(Stock_ID), [Date], Supplier.ID,RTRIM(Supplier.SupplierID),RTRIM(Supplier.Name), GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks) from Supplier,Stock where Supplier.ID=Stock.SupplierID  and [Date] between @d1 and @d2 order by [Date]", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(Stock_ID), [Date], Supplier.ID,RTRIM(Supplier.SupplierID),RTRIM(Supplier.Name), GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks) from Supplier,Stock where Supplier.ID=Stock.SupplierID  and [Date] between @d1 and @d2 and PaymentDue > 0 order by [Date]", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
