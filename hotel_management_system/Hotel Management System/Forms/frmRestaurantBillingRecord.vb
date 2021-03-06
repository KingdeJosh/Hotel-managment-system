Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmRestaurantBillingRecord
    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM Restaurant_OrderInfo", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbBillNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbBillNo.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Restaurant_OrderInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(Restaurant_OrderInfo.GrandTotal) as [Grand Total], RTRIM(Cash) as [Cash], RTRIM(Change) as [Change] from Restaurant_OrderInfo  order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillBillNo()
    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
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
                frmRestaurantBilling.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmRestaurantBilling.txtBillID.Text = dr.Cells(0).Value.ToString()
                frmRestaurantBilling.txtBillNo.Text = dr.Cells(1).Value.ToString()
                frmRestaurantBilling.dtpBillDate.Text = dr.Cells(2).Value.ToString()
                frmRestaurantBilling.txtGrandTotal.Text = dr.Cells(3).Value.ToString()
                frmRestaurantBilling.txtCash.Text = dr.Cells(4).Value.ToString()
                frmRestaurantBilling.txtChange.Text = dr.Cells(5).Value.ToString()
                frmRestaurantBilling.btnSave.Enabled = False
                frmRestaurantBilling.btnDelete.Enabled = True
                frmRestaurantBilling.btnUpdate.Enabled = True
                frmRestaurantBilling.btnPrint.Enabled = True
                frmRestaurantBilling.btnAdd_Food.Enabled = False
                frmRestaurantBilling.btnAdd_Liquor.Enabled = False
                frmRestaurantBilling.btnRemove.Enabled = False
                frmRestaurantBilling.btnRemove1.Enabled = False
                frmRestaurantBilling.dtpBillDate.Enabled = False
                frmRestaurantBilling.btnPrint.Enabled = True
                frmRestaurantBilling.txtRestrict.Text = "Not Allowed"
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(Dish_Liquor),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),RTRIM(TotalAmount) from Restaurant_OrderInfo,Restaurant_OrderedProduct where Restaurant_OrderInfo.Id=Restaurant_OrderedProduct.BillID and Restaurant_OrderInfo.ID=" & dr.Cells(0).Value & " and Volumn= 0"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmRestaurantBilling.DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    frmRestaurantBilling.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                End While
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql1 As String = "Select RTRIM(Dish_Liquor),RTRIM(Volumn),RTRIM(Rate),RTRIM(TakenFrom),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),RTRIM(TotalAmount) from Restaurant_OrderInfo,Restaurant_OrderedProduct where Restaurant_OrderInfo.Id=Restaurant_OrderedProduct.BillID and Restaurant_OrderInfo.ID=" & dr.Cells(0).Value & " and Volumn > 0"
                cmd = New SqlCommand(sql1, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmRestaurantBilling.DataGridView2.Rows.Clear()
                While (rdr.Read() = True)
                    frmRestaurantBilling.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
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
            cmd = New SqlCommand("Select RTRIM(Restaurant_OrderInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(Restaurant_OrderInfo.GrandTotal) as [Grand Total], RTRIM(Cash) as [Cash], RTRIM(Change) as [Change] from Restaurant_OrderInfo where BillDate between @d1 and @d2 order by BillDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Restaurant_OrderInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(Restaurant_OrderInfo.GrandTotal) as [Grand Total], RTRIM(Cash) as [Cash], RTRIM(Change) as [Change] from Restaurant_OrderInfo where BillNo='" & cmbBillNo.Text & "' order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Restaurant_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
