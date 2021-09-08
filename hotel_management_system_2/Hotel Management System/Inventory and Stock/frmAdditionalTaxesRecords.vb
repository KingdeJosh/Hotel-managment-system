Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmAdditionalTaxesRecords







    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Order_Info.OrderNo as [Order No], Tax_order.HEduTax as [HEducess Tax %], Tax_order.HEduTaxAmount as [Heducess Tax Amount], Tax_order.EducationalTax as [Educess Tax %], Tax_order.EducationalTaxAmount as [Educess Tax Amount],Order_Info.OrderDate as [Order Date], Order_Info.SubTotal as [Sub Total], Order_Info.VATPer as [VAT %], Order_Info.VATAmount as [VAT Amount], Order_Info.STPer as [ST %], Order_Info.STAmount as [ST Amount], Order_Info.GrandTotal as [Grand Total], Order_Info.TotalPayment as [Total Payment],Order_Info.PaymentDue as [Payment Due] FROM (Tax_order INNER JOIN Order_Info ON Tax_order.OrderID = Order_Info.ID) where OrderDate between #" & dtpOrderDateFrom.Text & "# And #" & dtpOrderDateTo.Text & "# order by OrderDate", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "order_Info")
            DataGridView1.DataSource = myDataSet.Tables("Order_info").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpOrderDateTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpOrderDateTo.Validating
        If (dtpOrderDateFrom.Value.Date) > (dtpOrderDateTo.Value.Date) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpOrderDateTo.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dtpOrderDateFrom.Text = Today
        dtpOrderDateTo.Text = Today
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Restaurant_OrderInfo.OrderNo as [Order No], Tax_Restaurantorder.HEduTax as [Heducess Tax %], Tax_Restaurantorder.HEduTaxAmount as [Heducess Tax Amount], Tax_Restaurantorder.EducationalTax as [Educess Tax %], Tax_Restaurantorder.EducationalTaxAmount as [Educess Tax Amount], Restaurant_OrderInfo.OrderDate as [Order Date], Restaurant_OrderInfo.SubTotal as [Sub Total], Restaurant_OrderInfo.VATPer as [VAT %], Restaurant_OrderInfo.STPer as [ST %],Restaurant_OrderInfo.VATAmount as [VAT Amount], Restaurant_OrderInfo.STAmount as [ST Amount], Restaurant_OrderInfo.GrandTotal as [Grand Total], Restaurant_OrderInfo.TotalPayment as [Total Payment] FROM (Restaurant_OrderInfo INNER JOIN Tax_Restaurantorder ON Restaurant_OrderInfo.ID = Tax_Restaurantorder.OrderID) where OrderDate between #" & DateTimePicker2.Text & "# And #" & DateTimePicker1.Text & "# order by OrderDate", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Restaurant_OrderInfo")
            DataGridView2.DataSource = myDataSet.Tables("Restaurant_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DateTimePicker1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker1.Validating
        If (DateTimePicker2.Value.Date) > (DateTimePicker1.Value.Date) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DataGridView2.DataSource = Nothing
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
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

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        DateTimePicker3.Text = Today
        DateTimePicker4.Text = Today
        DataGridView3.DataSource = Nothing
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

    Private Sub DateTimePicker3_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker3.Validating
        If (DateTimePicker4.Value.Date) > (DateTimePicker3.Value.Date) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker3.Focus()
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        DateTimePicker5.Text = Today
        DateTimePicker6.Text = Today
        DateTimePicker10.Text = Today
        DateTimePicker9.Text = Today
        DataGridView4.DataSource = Nothing
    End Sub

    Private Sub DateTimePicker5_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker5.Validating
        If (DateTimePicker6.Value.Date) > (DateTimePicker5.Value.Date) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker5.Focus()
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If DataGridView4.RowCount = Nothing Then
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

            rowsTotal = DataGridView4.RowCount
            colsTotal = DataGridView4.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView4.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView4.Rows(I).Cells(j).Value
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

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        DateTimePicker7.Text = Today
        DateTimePicker8.Text = Today
        DataGridView5.DataSource = Nothing
    End Sub

    Private Sub DateTimePicker7_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker7.Validating
        If (DateTimePicker8.Value.Date) > (DateTimePicker7.Value.Date) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker7.Focus()
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If DataGridView5.RowCount = Nothing Then
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

            rowsTotal = DataGridView5.RowCount
            colsTotal = DataGridView5.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView5.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView5.Rows(I).Cells(j).Value
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
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT BillNo as [Bill No],HEduTax as [HEducess Tax %],HEduTaxAmount as [Heducess Tax Amount],EducationalTax as [Educess Tax %],EducationalTaxAmount as [Educess Tax Amount],GuestName as [Guest Name], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOut as [Date Out], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance from Guest,Room,Checkin_Room,Checkout_room,Tax_Room where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and CheckIn_Room.ID=CheckOut_Room.CheckInID and Checkout_Room.ID=Tax_Room.BillID and DateOUT between #" & DateTimePicker4.Text & "# and #" & DateTimePicker3.Text & "# order by DateOut", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Checkout_Room")
            DataGridView3.DataSource = myDataSet.Tables("Checkout_Room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Tax_ReservationHallandGarden.ReservationID as [Reservation ID], Tax_ReservationHallandGarden.HEduTax as [HEducess Tax %], Tax_ReservationHallandGarden.HEduTaxAmount as [HEducess Tax Amount],Tax_ReservationHallandGarden.EducationalTax as [Educess Tax %], Tax_ReservationHallandGarden.EducationalTaxAmount as [Educess Tax Amount],Reservation_HallandGarden.Hall, Reservation_HallandGarden.DateFrom_Hall as [Date From], Reservation_HallandGarden.DateTo_Hall as [Date To], Reservation_HallandGarden.Garden, Reservation_HallandGarden.DateFrom_Garden as [Date From 1], Reservation_HallandGarden.DateTo_Garden as [Date To 1],Reservation_HallandGarden.SubTotal as [Sub Total], Reservation_HallandGarden.ServiceTaxPer as [ST %], Reservation_HallandGarden.ServiceTaxAmount as [ST Amount], Reservation_HallandGarden.LuxuryTaxPer as [Luxury Tax %],Reservation_HallandGarden.LuxuryTaxAmount as [Luxury Tax Amount], Guest.GuestName as [Guest Name], Guest.City FROM  ((Tax_ReservationHallandGarden INNER JOIN Reservation_HallandGarden ON Tax_ReservationHallandGarden.ReservationID = Reservation_HallandGarden.ID) INNER JOIN Guest ON Reservation_HallandGarden.GuestID = Guest.GuestID) where DateTo_Garden between #" & DateTimePicker6.Text & "# And #" & DateTimePicker5.Text & "# order by DateTo_Garden", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Reservation_HallandGarden")
            DataGridView4.DataSource = myDataSet.Tables("Reservation_HallandGarden").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Tax_ReservationHallandGarden.ReservationID as [Reservation ID], Tax_ReservationHallandGarden.HEduTax as [HEducess Tax %], Tax_ReservationHallandGarden.HEduTaxAmount as [HEducess Tax Amount],Tax_ReservationHallandGarden.EducationalTax as [Educess Tax %], Tax_ReservationHallandGarden.EducationalTaxAmount as [Educess Tax Amount],Reservation_HallandGarden.Hall, Reservation_HallandGarden.DateFrom_Hall as [Date From], Reservation_HallandGarden.DateTo_Hall as [Date To], Reservation_HallandGarden.Garden, Reservation_HallandGarden.DateFrom_Garden as [Date From 1], Reservation_HallandGarden.DateTo_Garden as [Date To 1],Reservation_HallandGarden.SubTotal as [Sub Total], Reservation_HallandGarden.ServiceTaxPer as [ST %], Reservation_HallandGarden.ServiceTaxAmount as [ST Amount], Reservation_HallandGarden.LuxuryTaxPer as [Luxury Tax %],Reservation_HallandGarden.LuxuryTaxAmount as [Luxury Tax Amount], Guest.GuestName as [Guest Name], Guest.City FROM  ((Tax_ReservationHallandGarden INNER JOIN Reservation_HallandGarden ON Tax_ReservationHallandGarden.ReservationID = Reservation_HallandGarden.ID) INNER JOIN Guest ON Reservation_HallandGarden.GuestID = Guest.GuestID) where DateTo_Hall between #" & DateTimePicker10.Text & "# And #" & DateTimePicker9.Text & "# order by DateTo_Hall", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Reservation_HallandGarden")
            DataGridView4.DataSource = myDataSet.Tables("Reservation_HallandGarden").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        dtpOrderDateFrom.Text = Today
        dtpOrderDateTo.Text = Today
        DataGridView1.DataSource = Nothing
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Today
        DataGridView2.DataSource = Nothing
        DateTimePicker3.Text = Today
        DateTimePicker4.Text = Today
        DataGridView3.DataSource = Nothing
        DateTimePicker5.Text = Today
        DateTimePicker6.Text = Today
        DateTimePicker10.Text = Today
        DateTimePicker9.Text = Today
        DataGridView4.DataSource = Nothing
        DateTimePicker7.Text = Today
        DateTimePicker8.Text = Today
        DataGridView5.DataSource = Nothing
    End Sub

    Private Sub DateTimePicker9_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker9.Validating
        If (DateTimePicker10.Value.Date) > (DateTimePicker9.Value.Date) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker9.Focus()
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Tax_ReservationHallorGarden.ReservationID as [Reservation ID], Tax_ReservationHallorGarden.HEduTax as [Heducess Tax %], Tax_ReservationHallorGarden.HEduTaxAmount as [Heducess Tax Amount],Tax_ReservationHallorGarden.EducationalTax as [Educess Tax %], Tax_ReservationHallorGarden.EducationalTaxAmount as [Educess Tax Amount],Reservation_HallorGarden.Type, Reservation_HallorGarden.DateFrom as [Date From], Reservation_HallorGarden.DateTo as [Date To], Reservation_HallorGarden.SubTotal as [Sub Total], Reservation_HallorGarden.ServiceTaxPer as [Service Tax %], Reservation_HallorGarden.ServiceTaxAmount as [Service Tax Amount],Guest.GuestName as [Guest Name], Guest.City FROM ((Guest INNER JOIN Reservation_HallorGarden ON Guest.GuestID = Reservation_HallorGarden.GuestID) INNER JOIN Tax_ReservationHallorGarden ON Reservation_HallorGarden.ID = Tax_ReservationHallorGarden.ReservationID) where DateTo between #" & DateTimePicker8.Text & "# And #" & DateTimePicker7.Text & "# order by DateTo", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Reservation_HallorGarden")
            DataGridView5.DataSource = myDataSet.Tables("Reservation_HallorGarden").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Close()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Close()
    End Sub
End Class