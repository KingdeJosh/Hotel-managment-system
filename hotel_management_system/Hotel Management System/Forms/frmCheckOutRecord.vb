Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmCheckOutRecord
    Sub fillRoomNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RoomNo) FROM Checkout_Room,CheckIN_Room where Checkout_Room.CheckInID=CheckIn_Room.Cin_ID", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbRoomNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbRoomNo.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(CheckOut_Room.ID) as [Bill ID],RTRIM(BillNo) as [Bill No.],Convert(Datetime,BillDate,131) as [Bill Date],RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(TaxPaidRate) as [Tax Paid Rate], RTRIM(Checkout_Room.Notes) as [Notes] from CheckOut_Room,Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID and Checkout_Room.CheckInID=CheckIn_Room.Cin_ID and Room.RoomNo=CheckIn_Room.RoomNo  Order by DateOut", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillRoomNo()
    End Sub
    Sub Reset()
        cmbRoomNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        txtGuestName.Text = ""
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
                If lblSet.Text = "Check Out" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmCheckOut_Room.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmCheckOut_Room.txtBillID.Text = dr.Cells(0).Value.ToString()
                frmCheckOut_Room.txtBillNo.Text = dr.Cells(1).Value.ToString()
                frmCheckOut_Room.dtpBillDate.Text = dr.Cells(2).Value.ToString()
                frmCheckOut_Room.txtCheckInID.Text = dr.Cells(3).Value.ToString()
                frmCheckOut_Room.txtGuestID.Text = dr.Cells(4).Value.ToString()
                frmCheckOut_Room.txtGuestName.Text = dr.Cells(5).Value.ToString()
                frmCheckOut_Room.txtRoomNo.Text = dr.Cells(6).Value.ToString()
                frmCheckOut_Room.txtRoomCharges.Text = dr.Cells(7).Value.ToString()
                frmCheckOut_Room.dtpDateIn.Text = dr.Cells(8).Value.ToString()
                frmCheckOut_Room.dtpDateOut.Text = dr.Cells(9).Value.ToString()
                frmCheckOut_Room.txtNoOfDays.Text = dr.Cells(10).Value.ToString()
                frmCheckOut_Room.txtNoOfMales.Text = dr.Cells(11).Value.ToString()
                frmCheckOut_Room.txtNoOfFemales.Text = dr.Cells(12).Value.ToString()
                frmCheckOut_Room.txtNoOfKids.Text = dr.Cells(13).Value.ToString()
                frmCheckOut_Room.txtNoOfExtraBed.Text = dr.Cells(14).Value.ToString()
                frmCheckOut_Room.txtNoOfExtraPerson.Text = dr.Cells(15).Value.ToString()
                frmCheckOut_Room.txtRoomOrderCharges.Text = dr.Cells(16).Value.ToString()
                frmCheckOut_Room.txtExtraPersonCharges.Text = dr.Cells(17).Value.ToString()
                frmCheckOut_Room.txtTotalRoomCharges.Text = dr.Cells(18).Value.ToString()
                frmCheckOut_Room.txtExtraBedCharges.Text = dr.Cells(19).Value.ToString()
                frmCheckOut_Room.txtLaundryCharges.Text = dr.Cells(20).Value.ToString()
                frmCheckOut_Room.txtDiscountPer.Text = dr.Cells(21).Value.ToString()
                frmCheckOut_Room.txtDiscountAmount.Text = dr.Cells(22).Value.ToString()
                frmCheckOut_Room.txtServiceTaxPer.Text = dr.Cells(23).Value.ToString()
                frmCheckOut_Room.txtServiceTaxAmount.Text = dr.Cells(24).Value.ToString()
                frmCheckOut_Room.txtLuxuryTaxPer.Text = dr.Cells(25).Value.ToString()
                frmCheckOut_Room.txtLuxuryTaxAmount.Text = dr.Cells(26).Value.ToString()
                frmCheckOut_Room.txtSubTotal.Text = dr.Cells(27).Value.ToString()
                frmCheckOut_Room.txtGrandTotal.Text = dr.Cells(28).Value.ToString()
                frmCheckOut_Room.txtTotalPaid.Text = dr.Cells(29).Value.ToString()
                frmCheckOut_Room.txtBalance.Text = dr.Cells(30).Value.ToString()
                If dr.Cells(31).Value.ToString() = "Yes" Then
                    frmCheckOut_Room.CheckBox1.Checked = True
                End If
                If dr.Cells(31).Value.ToString() = "No" Then
                    frmCheckOut_Room.CheckBox1.Checked = False
                End If
                frmCheckOut_Room.txtNotes.Text = dr.Cells(32).Value.ToString()
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT ID, Address, City, ContactNo, Gender, Occupation, Religion, IDType, IDNumber from Guest WHERE GuestId='" & dr.Cells(4).Value & "'"
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    frmCheckOut_Room.txtID.Text = rdr.GetValue(0)
                    frmCheckOut_Room.txtGuestAddress.Text = rdr.GetValue(1)
                    frmCheckOut_Room.txtGuestCity.Text = rdr.GetValue(2)
                    frmCheckOut_Room.txtGuestContactNo.Text = rdr.GetValue(3)
                    frmCheckOut_Room.txtGender.Text = rdr.GetValue(4)
                    frmCheckOut_Room.txtOccupation.Text = rdr.GetValue(5)
                    frmCheckOut_Room.txtReligion.Text = rdr.GetString(6)
                    frmCheckOut_Room.txtIDType.Text = rdr.GetValue(7)
                    frmCheckOut_Room.txtIDNumber.Text = rdr.GetValue(8)
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                frmCheckOut_Room.btnSave.Enabled = False
                frmCheckOut_Room.btnUpdate.Enabled = True
                frmCheckOut_Room.btnDelete.Enabled = True
                frmCheckOut_Room.dtpBillDate.Enabled = False
                frmCheckOut_Room.btnPrint.Enabled = True
                frmCheckOut_Room.dtpDateIn.Enabled = False
                    frmCheckOut_Room.dtpDateOut.Enabled = False
                    lblSet.Text = ""
                End If
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


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(CheckOut_Room.ID) as [Bill ID],RTRIM(BillNo) as [Bill No.],Convert(Datetime,BillDate,131) as [Bill Date],RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(TaxPaidRate) as [Tax Paid Rate], RTRIM(Checkout_Room.Notes) as [Notes] from CheckOut_Room,Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID and Checkout_Room.CheckInID=CheckIn_Room.Cin_ID and Room.RoomNo=CheckIn_Room.RoomNo and GuestName like '" & txtGuestName.Text & "%'  Order by DateOut", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(CheckOut_Room.ID) as [Bill ID],RTRIM(BillNo) as [Bill No.],Convert(Datetime,BillDate,131) as [Bill Date],RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(TaxPaidRate) as [Tax Paid Rate], RTRIM(Checkout_Room.Notes) as [Notes] from CheckOut_Room,Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID and Checkout_Room.CheckInID=CheckIn_Room.Cin_ID and Room.RoomNo=CheckIn_Room.RoomNo and Room.RoomNo=@d1  Order by DateOut", con)
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(CheckOut_Room.ID) as [Bill ID],RTRIM(BillNo) as [Bill No.],Convert(Datetime,BillDate,131) as [Bill Date],RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(TaxPaidRate) as [Tax Paid Rate], RTRIM(Checkout_Room.Notes) as [Notes] from CheckOut_Room,Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID and Checkout_Room.CheckInID=CheckIn_Room.Cin_ID and Room.RoomNo=CheckIn_Room.RoomNo and DateOut between @d1 and @d2  Order by DateOut", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateOut").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateOut").Value = dtpDateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            dgw.DataSource = myDataSet.Tables("Room").DefaultView
            dgw.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub
End Class
