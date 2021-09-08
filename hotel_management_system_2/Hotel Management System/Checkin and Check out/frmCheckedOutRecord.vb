Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmCheckedOutRecord
    Private Const STR_SELECTCheckout_RoomIDAsBillIDBillNoAsBillNoCheck As String = "SELECT Checkout_Room.ID as [Bill ID],BillNo as [Bill No],CheckInID as [Check In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOut as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkout_Room.Notes from Guest,Room,Checkin_Room,Checkout_room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and CheckIn_Room.ID=CheckOut_Room.CheckInID and CurrencySet.ID=Checkout_Room.CurrencyID and DateOUT between #"
    Private Const STR_SELECTCheckout_RoomIDAsBillIDBillNoAsBillNoCheck1 As String = "SELECT Checkout_Room.ID as [Bill ID],BillNo as [Bill No],CheckInID as [Check In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOut as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkout_Room.Notes from Guest,Room,Checkin_Room,Checkout_room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and CheckIn_Room.ID=CheckOut_Room.CheckInID and CurrencySet.ID=Checkout_Room.CurrencyID and Room.RoomNo='"
    Private Const STR_SELECTCheckout_RoomIDAsBillIDBillNoAsBillNoCheck2 As String = "SELECT Checkout_Room.ID as [Bill ID],BillNo as [Bill No],CheckInID as [Check In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOut as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkout_Room.Notes from Guest,Room,Checkin_Room,Checkout_room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and CheckIn_Room.ID=CheckOut_Room.CheckInID and CurrencySet.ID=Checkout_Room.CurrencyID and Guestname like '"
    Private Const STR_SELECTDistinctRTRIMRoomNoFROMCheckIn_RoomCheckou As String = "SELECT distinct RTRIM(RoomNo) FROM CheckIn_Room,Checkout_Room where CheckIn_Room.ID=Checkout_Room.CheckInID"
    Private Const STR_SELECTCheckout_RoomIDAsBillIDBillNoAsBillNoCheck3 As String = "SELECT Checkout_Room.ID as [Bill ID],BillNo as [Bill No],CheckInID as [Check In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOut as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkout_Room.Notes from Guest,Room,Checkin_Room,Checkout_room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and CheckIn_Room.ID=CheckOut_Room.CheckInID and CurrencySet.ID=Checkout_Room.CurrencyID order by GuestName"
    Private Const STR_InvalidSelection As String = "Invalid Selection"








    Sub yonatanloadcheck()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTCheckout_RoomIDAsBillIDBillNoAsBillNoCheck3, con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            myDA.Fill(myDataSet, "Checkout_room")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkout_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub yoniman()
        Try
            Dim CN As New OleDbConnection(cs)
            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand(STR_SELECTDistinctRTRIMRoomNoFROMCheckIn_RoomCheckou, CN)
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
    Private Sub frmCheckedInRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        yonatanloadcheck()
        yoniman()
    End Sub


    Private Sub dataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTCheckout_RoomIDAsBillIDBillNoAsBillNoCheck2 & txtGuestName.Text & "%' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            myDA.Fill(myDataSet, "Checkout_room")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkout_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTCheckout_RoomIDAsBillIDBillNoAsBillNoCheck1 & cmbRoomNo.Text & "' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            myDA.Fill(myDataSet, "Checkout_room")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkout_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTCheckout_RoomIDAsBillIDBillNoAsBillNoCheck & dtpDateFrom.Text & "# and #" & dtpDateTo.Text & "# order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            myDA.Fill(myDataSet, "Checkout_room")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkout_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        cmbRoomNo.SelectedIndex = -1
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        txtGuestName.Text = ""
        yonatanloadcheck()
    End Sub

    Private Sub dtpDateTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateTo.Validating
        If (dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date) Then
            MessageBox.Show(STR_InvalidSelection, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateTo.Focus()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub
End Class