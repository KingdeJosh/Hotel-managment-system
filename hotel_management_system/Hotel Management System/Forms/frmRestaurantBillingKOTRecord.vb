Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmRestaurantBillingKOTRecord
    Sub fillTicketNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TicketNo) FROM Restaurant_OrderInfoKOT", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbTicketNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbTicketNo.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Restaurant_OrderInfoKOT.Id) as [Ticket ID], RTRIM(TicketNo) as [Ticket No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(TableNo) as [Table No.],RTRIM(Restaurant_OrderInfoKOT.GrandTotal) as [Grand Total] from Restaurant_OrderInfoKOT  order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfoKOT")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfoKOT").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillTicketNo()
    End Sub
    Sub Reset()
        cmbTicketNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
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

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try

            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmRestaurantBillingKOT.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmRestaurantBillingKOT.txtTicketID.Text = dr.Cells(0).Value.ToString()
                frmRestaurantBillingKOT.txtTicketNo.Text = dr.Cells(1).Value.ToString()
                frmRestaurantBillingKOT.dtpTicketGenDate.Text = dr.Cells(2).Value.ToString()
                frmRestaurantBillingKOT.cmbTableNo.Text = dr.Cells(3).Value.ToString()
                frmRestaurantBillingKOT.txtGrandTotal.Text = dr.Cells(4).Value.ToString()
                frmRestaurantBillingKOT.btnSave.Enabled = False
                frmRestaurantBillingKOT.btnDelete.Enabled = True
                frmRestaurantBillingKOT.btnPrint.Enabled = True
                frmRestaurantBillingKOT.btnAdd_Food.Enabled = False
                frmRestaurantBillingKOT.btnAdd_Liquor.Enabled = False
                frmRestaurantBillingKOT.btnRemove.Enabled = False
                frmRestaurantBillingKOT.btnRemove1.Enabled = False
                frmRestaurantBillingKOT.dtpTicketGenDate.Enabled = False
                frmRestaurantBillingKOT.btnPrint.Enabled = True
                frmRestaurantBillingKOT.txtRestrict.Text = "Not Allowed"
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(Dish_Liquor),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),RTRIM(TotalAmount) from Restaurant_OrderInfoKOT,Restaurant_OrderedProductKOT where Restaurant_OrderInfoKOT.Id=Restaurant_OrderedProductKOT.TicketID and Restaurant_OrderInfoKOT.ID=" & dr.Cells(0).Value & " and Volumn= 0"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmRestaurantBillingKOT.DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    frmRestaurantBillingKOT.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                End While
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql1 As String = "Select RTRIM(Dish_Liquor),RTRIM(Volumn),RTRIM(Rate),RTRIM(TakenFrom),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),RTRIM(TotalAmount) from Restaurant_OrderInfoKOT,Restaurant_OrderedProductKOT where Restaurant_OrderInfoKOT.Id=Restaurant_OrderedProductKOT.TicketID and Restaurant_OrderInfoKOT.ID=" & dr.Cells(0).Value & " and Volumn > 0"
                cmd = New SqlCommand(sql1, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmRestaurantBillingKOT.DataGridView2.Rows.Clear()
                While (rdr.Read() = True)
                    frmRestaurantBillingKOT.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Restaurant_OrderInfoKOT.Id) as [Ticket ID], RTRIM(TicketNo) as [Ticket No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(TableNo) as [Table No.],RTRIM(Restaurant_OrderInfoKOT.GrandTotal) as [Grand Total] from Restaurant_OrderInfoKOT  where BillDate between @d1 and @d2 order by BillDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfoKOT")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfoKOT").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTicketNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTicketNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Restaurant_OrderInfoKOT.Id) as [Ticket ID], RTRIM(TicketNo) as [Ticket No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(TableNo) as [Table No.],RTRIM(Restaurant_OrderInfoKOT.GrandTotal) as [Grand Total] from Restaurant_OrderInfoKOT  where TicketNo='" & cmbTicketNo.Text & "' order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfoKOT")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfoKOT").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
