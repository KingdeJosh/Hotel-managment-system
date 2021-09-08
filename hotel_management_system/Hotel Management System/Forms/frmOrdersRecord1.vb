Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmOrdersRecord1
    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM Room_OrderInfo", CN)
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
            cmd = New SqlCommand("SELECT RTRIM(Room_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Room_OrderInfo.BillDate,131) as [Bill Date],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Room_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Room_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Room_OrderedProduct.Rate) as [Rate], RTRIM(Room_OrderedProduct.Quantity) as [Quantity], RTRIM(Room_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Room_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Room_OrderedProduct.VATPer) as [VAT %], RTRIM(Room_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Room_OrderedProduct.STPer) as [Service Tax %], RTRIM(Room_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Room_OrderedProduct.TotalAmount) as [Total Amount] FROM Guest,CheckIN_Room,Room_OrderInfo,Room_OrderedProduct where Guest.ID=CheckIn_Room.GuestID and Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Room_OrderedProduct.BillID = Room_OrderInfo.ID order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Room_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Room_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub fillFoodCategory()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbFoodCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbFoodCategory.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillLiquorCategory()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category_Liquor", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbLiquorCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbLiquorCategory.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillBillNo()
        fillFoodCategory()
        fillLiquorCategory()
    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        txtGuestName.Text = ""
        DateTimePicker1.Text = Now
        DateTimePicker2.Text = Today
        DateTimePicker3.Text = Now
        DateTimePicker4.Text = Today
        cmbFoodCategory.SelectedIndex = -1
        cmbLiquorCategory.SelectedIndex = -1
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

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Room_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Room_OrderInfo.BillDate,131) as [Bill Date],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Room_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Room_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Room_OrderedProduct.Rate) as [Rate], RTRIM(Room_OrderedProduct.Quantity) as [Quantity], RTRIM(Room_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Room_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Room_OrderedProduct.VATPer) as [VAT %], RTRIM(Room_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Room_OrderedProduct.STPer) as [Service Tax %], RTRIM(Room_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Room_OrderedProduct.TotalAmount) as [Total Amount] FROM Guest,CheckIN_Room,Room_OrderInfo,Room_OrderedProduct where Guest.ID=CheckIn_Room.GuestID and Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Room_OrderedProduct.BillID = Room_OrderInfo.ID and GuestName like '" & txtGuestName.Text & "%' order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Room_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Room_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Room_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Room_OrderInfo.BillDate,131) as [Bill Date],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Room_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Room_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Room_OrderedProduct.Rate) as [Rate], RTRIM(Room_OrderedProduct.Quantity) as [Quantity], RTRIM(Room_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Room_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Room_OrderedProduct.VATPer) as [VAT %], RTRIM(Room_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Room_OrderedProduct.STPer) as [Service Tax %], RTRIM(Room_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Room_OrderedProduct.TotalAmount) as [Total Amount] FROM Guest,CheckIN_Room,Room_OrderInfo,Room_OrderedProduct where Guest.ID=CheckIn_Room.GuestID and Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Room_OrderedProduct.BillID = Room_OrderInfo.ID and BillDate between @d1 and @d2 order by BillDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Room_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Room_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Room_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Room_OrderInfo.BillDate,131) as [Bill Date],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Room_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Room_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Room_OrderedProduct.Rate) as [Rate], RTRIM(Room_OrderedProduct.Quantity) as [Quantity], RTRIM(Room_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Room_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Room_OrderedProduct.VATPer) as [VAT %], RTRIM(Room_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Room_OrderedProduct.STPer) as [Service Tax %], RTRIM(Room_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Room_OrderedProduct.TotalAmount) as [Total Amount] FROM Guest,CheckIN_Room,Room_OrderInfo,Room_OrderedProduct where Guest.ID=CheckIn_Room.GuestID and Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Room_OrderedProduct.BillID = Room_OrderInfo.ID and BillNo='" & cmbBillNo.Text & "' order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Room_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Room_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            If Len(Trim(cmbFoodCategory.Text)) = 0 Then
                MessageBox.Show("Please select food category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbFoodCategory.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Room_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Room_OrderInfo.BillDate,131) as [Bill Date],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Room_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Room_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Room_OrderedProduct.Rate) as [Rate], RTRIM(Room_OrderedProduct.Quantity) as [Quantity], RTRIM(Room_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Room_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Room_OrderedProduct.VATPer) as [VAT %], RTRIM(Room_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Room_OrderedProduct.STPer) as [Service Tax %], RTRIM(Room_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Room_OrderedProduct.TotalAmount) as [Total Amount] FROM Guest,CheckIN_Room,Room_OrderInfo,Room_OrderedProduct,Dish,Category where Room_OrderedProduct.BillID = Room_OrderInfo.ID and Category.categoryName=Dish.Category and Dish.DishName=Room_OrderedProduct.Dish_Liquor and Guest.ID=CheckIN_Room.GuestID and Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and BillDate between @d1 and @d2 and Dish.Category=@d3 order by BillDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker1.Value
            cmd.Parameters.Add("@d3", SqlDbType.NChar, 200, "Category").Value = cmbFoodCategory.Text
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Room_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Room_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            If Len(Trim(cmbLiquorCategory.Text)) = 0 Then
                MessageBox.Show("Please select liquor category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbLiquorCategory.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(Room_OrderInfo.BillNo) as [Bill No.], Convert(DateTime,Room_OrderInfo.BillDate,131) as [Bill Date],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Room_OrderedProduct.Dish_Liquor) as [Item Description], RTRIM(Room_OrderedProduct.Volumn) as [Volumn (in ML)],RTRIM(Room_OrderedProduct.Rate) as [Rate], RTRIM(Room_OrderedProduct.Quantity) as [Quantity], RTRIM(Room_OrderedProduct.DiscountPer) as [Discount %], RTRIM(Room_OrderedProduct.DiscountAmount) as [Discount Amount], RTRIM(Room_OrderedProduct.VATPer) as [VAT %], RTRIM(Room_OrderedProduct.VATAmount) as [VAT Amount], RTRIM(Room_OrderedProduct.STPer) as [Service Tax %], RTRIM(Room_OrderedProduct.STAmount) as [Service Tax Amount],RTRIM(Room_OrderedProduct.TotalAmount) as [Total Amount] FROM Guest,CheckIN_Room,Room_OrderInfo,Room_OrderedProduct,Liquor,Category_Liquor where Room_OrderedProduct.BillID = Room_OrderInfo.ID and Category_Liquor.categoryName=Liquor.Category and Liquor.LiquorName=Room_OrderedProduct.Dish_Liquor and Guest.ID=CheckIN_Room.GuestID and Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and BillDate between @d1 and @d2 and Category_Liquor.CategoryName=@d3 order by BillDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker4.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker3.Value
            cmd.Parameters.Add("@d3", SqlDbType.NChar, 200, "Category").Value = cmbLiquorCategory.Text
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Room_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Room_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
