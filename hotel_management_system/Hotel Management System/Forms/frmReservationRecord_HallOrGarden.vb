Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmReservationRecord_HallOrGarden
    Sub fillGarden()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Reservation_Garden", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbGardenName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbGardenName.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillHall()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Reservation_Hall", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbHallName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbHallName.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Reservation_Garden.ID) as [Bill ID], RTRIM(BillNo) as [Bill No.], Convert(DateTime,BillDate,131) as [Bill Date], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Type) as [Type],RTRIM(Name) as [Hall/Garden Name], Convert(DateTime,DateFrom,103) as [Date From], Convert(DateTime,DateTo,103) as [Date To], RTRIM(Days) as [No. Of Days], RTRIM(Rate) as [Rate],RTRIM(TotalCharges) as [Total Charges],RTRIM(OtherCharges) as [Laundry Charges], RTRIM(SubTotal) as [Sub Total], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax %],RTRIM(LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance],RTRIM(Status) as [Status], RTRIM(Reservation_Garden.Notes) as [Notes] from Guest,Reservation_Garden where Guest.ID=Reservation_Garden.GuestID union Select RTRIM(Reservation_Hall.ID) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Type) as [Type],RTRIM(Name) as [Hall/Hall Name], Convert(DateTime,DateFrom,103) as [Date From], Convert(DateTime,DateTo,103) as [Date To], RTRIM(Days) as [No. Of Days], RTRIM(Rate) as [Rate],RTRIM(TotalCharges) as [Total Charges],RTRIM(OtherCharges) as [Laundry Charges], RTRIM(SubTotal) as [Sub Total], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax %],RTRIM(LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance],RTRIM(Status) as [Status], RTRIM(Reservation_Hall.Notes) as [Notes] from Guest,Reservation_Hall where Guest.ID=Reservation_Hall.GuestID", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillHall()
        fillGarden()
    End Sub
    Sub Reset()
        cmbGardenName.SelectedIndex = -1
        cmbHallName.SelectedIndex = -1
        DateTimePicker1.Text = Now
        DateTimePicker2.Text = Today
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
                If lblSet.Text = "Reservation" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmReservation_HallorGarden.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmReservation_HallorGarden.txtBillID.Text = dr.Cells(0).Value.ToString()
                    frmReservation_HallorGarden.txtBillNo.Text = dr.Cells(1).Value.ToString()
                    frmReservation_HallorGarden.dtpBillDate.Text = Convert.ToDateTime(dr.Cells(2).Value)
                    frmReservation_HallorGarden.txtGuestID.Text = dr.Cells(3).Value.ToString()
                    frmReservation_HallorGarden.txtGuestName.Text = dr.Cells(4).Value.ToString()
                    If dr.Cells(5).Value.ToString() = "Hall" Then
                        frmReservation_HallorGarden.rbHall.Checked = True
                    End If
                    If dr.Cells(5).Value.ToString() = "Garden" Then
                        frmReservation_HallorGarden.rbGarden.Checked = True
                    End If
                    frmReservation_HallorGarden.cmbName.Text = dr.Cells(6).Value.ToString()
                    frmReservation_HallorGarden.DateFrom.Text = Convert.ToDateTime(dr.Cells(7).Value)
                    frmReservation_HallorGarden.DateTo.Text = Convert.ToDateTime(dr.Cells(8).Value)
                    frmReservation_HallorGarden.txtNoOfDays.Text = dr.Cells(9).Value.ToString()
                    frmReservation_HallorGarden.txtRate.Text = dr.Cells(10).Value.ToString()
                    frmReservation_HallorGarden.txtTotalCharges.Text = dr.Cells(11).Value.ToString()
                    frmReservation_HallorGarden.txtOtherCharges.Text = dr.Cells(12).Value.ToString()
                    frmReservation_HallorGarden.txtSubTotal.Text = dr.Cells(13).Value.ToString()
                    frmReservation_HallorGarden.txtServiceTaxPer.Text = dr.Cells(14).Value.ToString()
                    frmReservation_HallorGarden.txtServiceTaxAmount.Text = dr.Cells(15).Value.ToString()
                    frmReservation_HallorGarden.txtLuxuryTaxPer.Text = dr.Cells(16).Value.ToString()
                    frmReservation_HallorGarden.txtLuxuryTaxAmount.Text = dr.Cells(17).Value.ToString()
                    frmReservation_HallorGarden.txtDiscountPer.Text = dr.Cells(18).Value.ToString()
                    frmReservation_HallorGarden.txtDiscount.Text = dr.Cells(19).Value.ToString()
                    frmReservation_HallorGarden.txtGrandTotal.Text = dr.Cells(20).Value.ToString()
                    frmReservation_HallorGarden.txtTotalPaid.Text = dr.Cells(21).Value.ToString()
                    frmReservation_HallorGarden.txtBalance.Text = dr.Cells(22).Value.ToString()
                    frmReservation_HallorGarden.txtStatus.Text = dr.Cells(23).Value.ToString()
                    frmReservation_HallorGarden.txtNotes.Text = dr.Cells(24).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT ID, Address, City, ContactNo, Gender, Occupation, Religion, IDType, IDNumber from Guest WHERE GuestId='" & dr.Cells(3).Value & "'"
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        frmReservation_HallorGarden.txtID.Text = rdr.GetValue(0)
                        frmReservation_HallorGarden.txtGuestAddress.Text = rdr.GetValue(1)
                        frmReservation_HallorGarden.txtGuestCity.Text = rdr.GetValue(2)
                        frmReservation_HallorGarden.txtGuestContactNo.Text = rdr.GetValue(3)
                        frmReservation_HallorGarden.txtGender.Text = rdr.GetValue(4)
                        frmReservation_HallorGarden.txtOccupation.Text = rdr.GetValue(5)
                        frmReservation_HallorGarden.txtReligion.Text = rdr.GetString(6)
                        frmReservation_HallorGarden.txtIDType.Text = rdr.GetValue(7)
                        frmReservation_HallorGarden.txtIDNumber.Text = rdr.GetValue(8)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    frmReservation_HallorGarden.btnSave.Enabled = False
                    frmReservation_HallorGarden.btnUpdate.Enabled = True
                    frmReservation_HallorGarden.btnDelete.Enabled = True
                    frmReservation_HallorGarden.DateFrom.Enabled = False
                    frmReservation_HallorGarden.DateTo.Enabled = False
                    frmReservation_HallorGarden.dtpBillDate.Enabled = False
                    frmReservation_HallorGarden.btnAvailability.Enabled = False
                    frmReservation_HallorGarden.btnPrint.Enabled = True
                    frmReservation_HallorGarden.btnCancelReservation.Enabled = True
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(cmbGardenName.Text)) = 0 Then
                MessageBox.Show("Please select garden name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbGardenName.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Reservation_Garden.ID) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Type) as [Type],RTRIM(Name) as [Hall/Garden Name], Convert(DateTime,DateFrom,103) as [Date From], Convert(DateTime,DateTo,103) as [Date To], RTRIM(Days) as [No. Of Days], RTRIM(Rate) as [Rate],RTRIM(TotalCharges) as [Total Charges],RTRIM(OtherCharges) as [Laundry Charges], RTRIM(SubTotal) as [Sub Total], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax %],RTRIM(LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance],RTRIM(Status) as [Status], RTRIM(Reservation_Garden.Notes) as [Notes] from Guest,Reservation_Garden where Guest.ID=Reservation_Garden.GuestID and Name=@d1 and BillDate between @d2 and @d3 ", con)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateTo.Value
            cmd.Parameters.Add("@d1", SqlDbType.NChar, 150, "Name").Value = cmbGardenName.Text
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If Len(Trim(cmbHallName.Text)) = 0 Then
                MessageBox.Show("Please select hall name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbHallName.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Reservation_Hall.ID) as [Bill ID], RTRIM(BillNo) as [Bill No.], Convert(DateTime,BillDate,131) as [Bill Date], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Type) as [Type],RTRIM(Name) as [Hall/Hall Name], Convert(DateTime,DateFrom,103) as [Date From], Convert(DateTime,DateTo,103) as [Date To], RTRIM(Days) as [No. Of Days], RTRIM(Rate) as [Rate],RTRIM(TotalCharges) as [Total Charges],RTRIM(OtherCharges) as [Laundry Charges], RTRIM(SubTotal) as [Sub Total], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax %],RTRIM(LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance],RTRIM(Status) as [Status], RTRIM(Reservation_Hall.Notes) as [Notes] from Guest,Reservation_Hall where Guest.ID=Reservation_Hall.GuestID and Name=@d1 and BillDate between @d2 and @d3 ", con)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "BillDate").Value = DateTimePicker1.Value
            cmd.Parameters.Add("@d1", SqlDbType.NChar, 150, "Name").Value = cmbHallName.Text
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
