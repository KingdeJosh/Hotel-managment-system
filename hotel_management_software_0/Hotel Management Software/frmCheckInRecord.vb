Imports System.Data.SqlClient

Public Class frmCheckInRecord
    Sub fillRoomNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RoomNo) FROM CheckIN_Room,Room where Room.R_ID=CheckIN_Room.RoomID", CN)
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
            cmd = New SqlCommand("Select RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(CheckIn_Room.Notes) as [Notes] from Guest,Room,CheckIN_Room,[Plan] where Guest.ID=CheckIN_Room.GuestID and Status='Check In' and Room.R_ID=CheckIN_Room.RoomID and [Plan].P_Code=Room.PlanCode Order by DateIN", con)
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
        dtpDateTo.Text = Today
        txtGuestName.Text = ""
        cmbStatus.SelectedIndex = -1
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Check In" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmCheckIN.Show()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql2 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Room_OrderInfo where Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & " and RO_Status='Unpaid'"
                    cmd = New SqlCommand(sql2, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr.Read() Then
                        txtRoomCharges.Text = rdr.GetValue(0).ToString()
                    Else
                        txtRoomCharges.Text = 0
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql3 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Laundry_BillInfo where Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & " and LB_Status='Unpaid'"
                    cmd = New SqlCommand(sql3, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr.Read() Then
                        txtLaundryCharges.Text = rdr.GetValue(0).ToString()
                    Else
                        txtLaundryCharges.Text = 0
                    End If
                    con.Close()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmCheckIN.txtCheckInID.Text = dr.Cells(0).Value.ToString()
                    frmCheckIN.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmCheckIN.txtGuestName.Text = dr.Cells(2).Value.ToString()
                    frmCheckIN.cmbRoomNo.Text = dr.Cells(3).Value.ToString()
                    frmCheckIN.cmbRoomNo1.Text = dr.Cells(3).Value.ToString()
                    frmCheckIN.cmbPlanCode.Text = dr.Cells(4).Value.ToString()
                    frmCheckIN.txtPlanName.Text = dr.Cells(5).Value.ToString()
                    frmCheckIN.txtRoomCharges.Text = dr.Cells(6).Value.ToString()
                    frmCheckIN.dtpDateIn.Text = dr.Cells(7).Value.ToString()
                    frmCheckIN.dtpDateOut.Text = dr.Cells(8).Value.ToString()
                    frmCheckIN.txtNoOfDays.Text = dr.Cells(9).Value.ToString()
                    frmCheckIN.txtNoOfMales.Text = dr.Cells(10).Value.ToString()
                    frmCheckIN.txtNoOfFemales.Text = dr.Cells(11).Value.ToString()
                    frmCheckIN.txtNoOfKids.Text = dr.Cells(12).Value.ToString()
                    frmCheckIN.txtNoOfExtraBed.Text = dr.Cells(13).Value.ToString()
                    frmCheckIN.txtNoOfExtraPerson.Text = dr.Cells(14).Value.ToString()
                    frmCheckIN.txtRoomOrderCharges.Text = dr.Cells(15).Value.ToString() + Val(txtRoomCharges.Text)
                    frmCheckIN.txtExtraPersonCharges.Text = dr.Cells(16).Value.ToString()
                    frmCheckIN.txtTotalRoomCharges.Text = dr.Cells(17).Value.ToString()
                    frmCheckIN.txtExtraBedCharges.Text = dr.Cells(18).Value.ToString()
                    frmCheckIN.txtLaundryCharges.Text = dr.Cells(19).Value.ToString() + Val(txtLaundryCharges.Text)
                    frmCheckIN.txtDiscountPer.Text = dr.Cells(20).Value.ToString()
                    frmCheckIN.txtDiscountAmount.Text = dr.Cells(21).Value.ToString()
                    frmCheckIN.txtServiceTaxPer.Text = dr.Cells(22).Value.ToString()
                    frmCheckIN.txtServiceTaxAmount.Text = dr.Cells(23).Value.ToString()
                    frmCheckIN.txtLuxuryTaxPer.Text = dr.Cells(24).Value.ToString()
                    frmCheckIN.txtLuxuryTaxAmount.Text = dr.Cells(25).Value.ToString()
                    frmCheckIN.txtSubTotal.Text = dr.Cells(26).Value.ToString()
                    Dim num1, num2, num3 As Double
                    num1 = CDbl(dr.Cells(27).Value)
                    num1 = Math.Round(num1, 2)
                    num2 = CDbl(dr.Cells(28).Value)
                    num2 = Math.Round(num2, 2)
                    num3 = CDbl(dr.Cells(29).Value)
                    num3 = Math.Round(num3, 2)
                    frmCheckIN.txtGrandTotal.Text = num1
                    frmCheckIN.txtTotalPaid.Text = num2
                    frmCheckIN.txtBalance.Text = num3
                    frmCheckIN.txtNotes.Text = dr.Cells(30).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT ID, RTRIM(Address), RTRIM(City), RTRIM(ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion),RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        frmCheckIN.txtID.Text = rdr.GetValue(0)
                        frmCheckIN.txtGuestAddress.Text = rdr.GetValue(1)
                        frmCheckIN.txtGuestCity.Text = rdr.GetValue(2)
                        frmCheckIN.txtGuestContactNo.Text = rdr.GetValue(3)
                        frmCheckIN.txtGender.Text = rdr.GetValue(4)
                        frmCheckIN.txtOccupation.Text = rdr.GetValue(5)
                        frmCheckIN.txtReligion.Text = rdr.GetString(6)
                        frmCheckIN.txtIDType.Text = rdr.GetValue(7)
                        frmCheckIN.txtIDNumber.Text = rdr.GetValue(8)
                        frmCheckIN.txtCountry.Text = rdr.GetValue(9)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    frmCheckIN.btnSave.Enabled = False
                    frmCheckIN.btnUpdate.Enabled = True
                    frmCheckIN.btnDelete.Enabled = True

                    frmCheckIN.btnPrint.Enabled = True
                    frmCheckIN.Compute()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql1 As String = "SELECT RTRIM(PaymentMode),CheckIn_Payment.TotalPaid,PaymentDate from CheckIn_Room,CheckIN_Payment where CheckIn_Room.Cin_ID=CheckIn_Payment.CheckInID and CheckInID=@d1 and CheckIn_Payment.TotalPaid > 0"
                    cmd = New SqlCommand(sql1, con)
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmCheckIN.DataGridView2.Rows.Clear()
                    While (rdr.Read() = True)
                        frmCheckIN.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), "Not allowed")
                    End While
                    con.Close()
                    frmCheckIN.lblStatus.Text = "Not allowed"
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Check Out" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmCheckOut.Show()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql2 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Room_OrderInfo where Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & " and RO_Status='Unpaid'"
                    cmd = New SqlCommand(sql2, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr.Read() Then
                        txtRoomCharges.Text = rdr.GetValue(0).ToString()
                    Else
                        txtRoomCharges.Text = 0
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql3 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Laundry_BillInfo where Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & " and LB_Status='Unpaid'"
                    cmd = New SqlCommand(sql3, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr.Read() Then
                        txtLaundryCharges.Text = rdr.GetValue(0).ToString()
                    Else
                        txtLaundryCharges.Text = 0
                    End If
                    con.Close()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmCheckOut.txtCheckInID.Text = dr.Cells(0).Value.ToString()
                    frmCheckOut.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmCheckOut.txtGuestName.Text = dr.Cells(2).Value.ToString()
                    frmCheckOut.txtRoomNo.Text = dr.Cells(3).Value.ToString()
                    frmCheckOut.txtPlanCode.Text = dr.Cells(4).Value.ToString()
                    frmCheckOut.txtPlanName.Text = dr.Cells(5).Value.ToString()
                    frmCheckOut.txtRoomCharges.Text = dr.Cells(6).Value.ToString()
                    frmCheckOut.dtpDateIn.Text = dr.Cells(7).Value.ToString()
                    frmCheckOut.dtpDateOut.Text = dr.Cells(8).Value.ToString()
                    frmCheckOut.txtNoOfDays.Text = dr.Cells(9).Value.ToString()
                    frmCheckOut.txtNoOfMales.Text = dr.Cells(10).Value.ToString()
                    frmCheckOut.txtNoOfFemales.Text = dr.Cells(11).Value.ToString()
                    frmCheckOut.txtNoOfKids.Text = dr.Cells(12).Value.ToString()
                    frmCheckOut.txtNoOfExtraBed.Text = dr.Cells(13).Value.ToString()
                    frmCheckOut.txtNoOfExtraPerson.Text = dr.Cells(14).Value.ToString()
                    frmCheckOut.txtRoomOrderCharges.Text = dr.Cells(15).Value.ToString() + Val(txtRoomCharges.Text)
                    frmCheckOut.txtExtraPersonCharges.Text = dr.Cells(16).Value.ToString()
                    frmCheckOut.txtTotalRoomCharges.Text = dr.Cells(17).Value.ToString()
                    frmCheckOut.txtExtraBedCharges.Text = dr.Cells(18).Value.ToString()
                    frmCheckOut.txtLaundryCharges.Text = dr.Cells(19).Value.ToString() + Val(txtLaundryCharges.Text)
                    frmCheckOut.txtDiscountPer.Text = dr.Cells(20).Value.ToString()
                    frmCheckOut.txtDiscountAmount.Text = dr.Cells(21).Value.ToString()
                    frmCheckOut.txtServiceTaxPer.Text = dr.Cells(22).Value.ToString()
                    frmCheckOut.txtServiceTaxAmount.Text = dr.Cells(23).Value.ToString()
                    frmCheckOut.txtLuxuryTaxPer.Text = dr.Cells(24).Value.ToString()
                    frmCheckOut.txtLuxuryTaxAmount.Text = dr.Cells(25).Value.ToString()
                    frmCheckOut.txtSubTotal.Text = dr.Cells(26).Value.ToString()
                    Dim num1, num2, num3 As Double
                    num1 = CDbl(dr.Cells(27).Value)
                    num1 = Math.Round(num1, 2)
                    num2 = CDbl(dr.Cells(28).Value)
                    num2 = Math.Round(num2, 2)
                    num3 = CDbl(dr.Cells(29).Value)
                    num3 = Math.Round(num3, 2)
                    frmCheckOut.txtGrandTotal.Text = num1
                    frmCheckOut.txtTotalPaid.Text = num2
                    frmCheckOut.txtBalance.Text = num3
                    frmCheckOut.dtpDateIn.Enabled = False
                    frmCheckOut.dtpDateOut.Enabled = False
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT ID, RTRIM(Address), RTRIM(City), RTRIM(ContactNo), RTRIM(Gender), RTRIM(Occupation), RTRIM(Religion),RTRIM(IDType), RTRIM(IDNumber),RTRIM(Country) from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        frmCheckOut.txtID.Text = rdr.GetValue(0)
                        frmCheckOut.txtGuestAddress.Text = rdr.GetValue(1)
                        frmCheckOut.txtGuestCity.Text = rdr.GetValue(2)
                        frmCheckOut.txtGuestContactNo.Text = rdr.GetValue(3)
                        frmCheckOut.txtGender.Text = rdr.GetValue(4)
                        frmCheckOut.txtOccupation.Text = rdr.GetValue(5)
                        frmCheckOut.txtReligion.Text = rdr.GetString(6)
                        frmCheckOut.txtIDType.Text = rdr.GetValue(7)
                        frmCheckOut.txtIDNumber.Text = rdr.GetValue(8)
                        frmCheckOut.txtCountry.Text = rdr.GetValue(9)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    frmCheckOut.Fill()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql1 As String = "SELECT RTRIM(PaymentMode),CheckIn_Payment.TotalPaid,PaymentDate from CheckIn_Room,CheckIN_Payment where CheckIn_Room.Cin_ID=CheckIn_Payment.CheckInID and CheckInID=@d1 and CheckIn_Payment.TotalPaid > 0"
                    cmd = New SqlCommand(sql1, con)
                    cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value.ToString())
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmCheckOut.DataGridView2.Rows.Clear()
                    While (rdr.Read() = True)
                        frmCheckOut.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2))
                    End While
                    con.Close()
                    frmCheckOut.lblStatus.Text = "Not allowed"
                    frmCheckOut.GetRoomID()
                    frmCheckOut.GetPlan()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Room Order" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmOrder.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmOrder.txtCheckedInID.Text = dr.Cells(0).Value.ToString()
                    frmOrder.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmOrder.txtGuestName.Text = dr.Cells(2).Value.ToString()
                    frmOrder.txtRoomNo.Text = dr.Cells(3).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT RTRIM(ContactNo),ID from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        frmOrder.txtContactNo.Text = rdr.GetValue(0)
                        frmOrder.txtG_ID.Text = rdr.GetValue(1)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Laundry Billing" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmLaundryBilling.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmLaundryBilling.txtCheckedInID.Text = dr.Cells(0).Value.ToString()
                    frmLaundryBilling.txtGuestID.Text = dr.Cells(1).Value.ToString()
                    frmLaundryBilling.txtGuestName.Text = dr.Cells(2).Value.ToString()
                    frmLaundryBilling.txtRoomNo.Text = dr.Cells(3).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT RTRIM(ContactNo),ID from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        frmLaundryBilling.txtContactNo.Text = rdr.GetValue(0)
                        frmLaundryBilling.txtG_ID.Text = rdr.GetValue(1)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
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
        Dim b As Brush = SystemBrushes.ControlLightLight
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(CheckIn_Room.Notes) as [Notes] from Guest,Room,CheckIN_Room,[Plan] where Guest.ID=CheckIN_Room.GuestID and Status='Check In' and Room.R_ID=CheckIN_Room.RoomID and [Plan].P_Code=Room.PlanCode and GuestName like '%" & txtGuestName.Text & "%' Order by DateIN", con)
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
            cmd = New SqlCommand("Select RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(CheckIn_Room.Notes) as [Notes] from Guest,Room,CheckIN_Room,[Plan] where Guest.ID=CheckIN_Room.GuestID and Status='Check In' and Room.R_ID=CheckIN_Room.RoomID and [Plan].P_Code=Room.PlanCode and Room.RoomNo=@d1 Order by DateIN", con)
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
            cmd = New SqlCommand("Select RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(CheckIn_Room.Notes) as [Notes] from Guest,Room,CheckIN_Room,[Plan] where Guest.ID=CheckIN_Room.GuestID and Status='Check In' and Room.R_ID=CheckIN_Room.RoomID and [Plan].P_Code=Room.PlanCode and Status='Check In' and DateIN between @d1 and @d2 Order by DateIN", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date
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

    Private Sub cmbStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.],RTRIM(PlanCode) as [Plan Code],RTRIM(PlanName) as [Plan Name], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(CheckIn_Room.Notes) as [Notes] from Guest,Room,CheckIN_Room,[Plan] where Guest.ID=CheckIN_Room.GuestID and Room.R_ID=CheckIN_Room.RoomID and [Plan].P_Code=Room.PlanCode and Status=@d1 Order by DateIN", con)
            cmd.Parameters.AddWithValue("@d1", cmbStatus.Text)
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

    Private Sub cmbRoomNo_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbRoomNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

End Class
