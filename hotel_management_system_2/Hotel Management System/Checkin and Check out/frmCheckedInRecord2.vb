Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmCheckedInRecord2








    Sub GetData()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Checkin_Room.ID as [Checked In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOUT as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,Status,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkin_Room.Notes from Guest,Room,Checkin_Room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and Checkin_Room.CurrencyID=CurrencySet.ID and Checkin_Room.Status='Checked In'  order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillRoomNo()
        Try
            Dim CN As New OleDbConnection(cs)
            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct RTRIM(RoomNo) FROM CheckIn_Room", CN)
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
        GetData()
        fillRoomNo()
    End Sub

    Private Sub dataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
            Me.Hide()
            frmCheckIn.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmCheckIn.txtID1.Text = dr.Cells(0).Value.ToString()
            frmCheckIn.txtGuestID.Text = dr.Cells(1).Value.ToString()
            frmCheckIn.txtGuestName.Text = dr.Cells(2).Value.ToString()
            frmCheckIn.txtGuestAddress.Text = dr.Cells(3).Value.ToString()
            frmCheckIn.txtGuestCity.Text = dr.Cells(4).Value.ToString()
            frmCheckIn.txtGuestContactNo.Text = dr.Cells(5).Value.ToString()
            frmCheckIn.txtIDType.Text = dr.Cells(6).Value.ToString()
            frmCheckIn.txtIDNumber.Text = dr.Cells(7).Value.ToString()
            frmCheckIn.cmbRoomNo.Text = dr.Cells(8).Value.ToString()
            frmCheckIn.cmbRoomNo1.Text = dr.Cells(8).Value.ToString()
            frmCheckIn.txtRoomCharges.Text = dr.Cells(9).Value.ToString()
            frmCheckIn.dtpDateIn.Text = dr.Cells(10).Value.ToString()
            frmCheckIn.dtpDateOut.Text = dr.Cells(11).Value.ToString()
            frmCheckIn.txtNoOfAdults.Text = dr.Cells(12).Value.ToString()
            frmCheckIn.txtNoOfKids.Text = dr.Cells(13).Value.ToString()
            frmCheckIn.txtNoOfDays.Text = dr.Cells(14).Value.ToString()
            If (dr.Cells(15).Value.ToString() = "Yes") Then
                frmCheckIn.CheckBox1.Checked = True
            Else
                frmCheckIn.CheckBox1.Checked = False
            End If
            frmCheckIn.txtTotalRoomCharges.Text = dr.Cells(16).Value.ToString()
            frmCheckIn.txtOtherCharges.Text = dr.Cells(17).Value.ToString()
            frmCheckIn.txtSubTotal.Text = dr.Cells(18).Value.ToString()
            frmCheckIn.txtServiceTaxPer.Text = dr.Cells(19).Value.ToString()
            frmCheckIn.txtServiceTaxAmount.Text = dr.Cells(20).Value.ToString()
            frmCheckIn.txtLuxuryTaxPer.Text = dr.Cells(21).Value.ToString()
            frmCheckIn.txtLuxuryTaxAmount.Text = dr.Cells(22).Value.ToString()
            frmCheckIn.txtDiscountPer.Text = dr.Cells(23).Value.ToString()
            frmCheckIn.txtDiscount.Text = dr.Cells(24).Value.ToString()
            frmCheckIn.txtGrandTotal.Text = dr.Cells(25).Value.ToString()
            frmCheckIn.txtTotalPaid.Text = dr.Cells(26).Value.ToString()
            frmCheckIn.txtBalance.Text = dr.Cells(27).Value.ToString()
            frmCheckIn.txtCurrencyID.Text = dr.Cells(29).Value.ToString()
            frmCheckIn.cmbCurrency2.Text = dr.Cells(30).Value.ToString()
            frmCheckIn.txtNotes.Text = dr.Cells(31).Value.ToString()
            frmCheckIn.btnUpdate_record.Enabled = True
            frmCheckIn.btnDelete.Enabled = True
            frmCheckIn.btnSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            cmd = New OleDbCommand("SELECT Checkin_Room.ID as [Checked In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOUT as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,Status,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkin_Room.Notes from Guest,Room,Checkin_Room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and Checkin_Room.CurrencyID=CurrencySet.ID and Checkin_Room.Status='Checked In'  and GuestName like '" & txtGuestName.Text & "%' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Checkin_Room.ID as [Checked In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOUT as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,Status,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkin_Room.Notes from Guest,Room,Checkin_Room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and Checkin_Room.CurrencyID=CurrencySet.ID and Checkin_Room.Status='Checked In'  and Room.RoomNo= '" & cmbRoomNo.Text & "' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Checkin_Room.ID as [Checked In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOUT as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,Status,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkin_Room.Notes from Guest,Room,Checkin_Room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and Checkin_Room.CurrencyID=CurrencySet.ID and Checkin_Room.Status='Checked In'  and DateIN between #" & dtpDateFrom.Value.Date & "# and #" & dtpDateTo.Value.Date & "# order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Room").DefaultView
            dataGridView1.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        cmbRoomNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        txtGuestName.Text = ""
        GetData()
    End Sub


    Private Sub dtpDateTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateTo.Validating
        If (dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateTo.Focus()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub
End Class