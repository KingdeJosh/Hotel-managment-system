Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmCheckOut







    Dim num1, num2, num4, num5, num6, num7 As Double

    Sub yonatanabi()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Checkout_Room.ID as [Bill ID],BillNo as [Bill No],CheckInID as [Check In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOut as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkout_Room.Notes from Guest,Room,Checkin_Room,Checkout_room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and CheckIn_Room.ID=CheckOut_Room.CheckInID and CurrencySet.ID=Checkout_Room.CurrencyID order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            myDA.Fill(myDataSet, "Checkout_room")
            checkoutyoni.DataSource = myDataSet.Tables("Guest").DefaultView
            checkoutyoni.DataSource = myDataSet.Tables("Room").DefaultView
            checkoutyoni.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            checkoutyoni.DataSource = myDataSet.Tables("Checkout_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub yoniroomNo()
        Try
            Dim CN As New OleDbConnection(cs)
            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct RTRIM(RoomNo) FROM CheckIn_Room,Checkout_Room where CheckIn_Room.ID=Checkout_Room.CheckInID", CN)
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

    Sub yonatanload()
        con = New OleDbConnection(cs)
        con.Open()
        cmd = New OleDbCommand("SELECT Checkin_Room.ID as [Checked In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOUT as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,Status,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkin_Room.Notes from Guest,Room,Checkin_Room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and Checkin_Room.CurrencyID=CurrencySet.ID  and Status='Checked In' order by GuestName", con)
        Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        Dim myDataSet As DataSet = New DataSet()
        myDA.Fill(myDataSet, "Guest")
        myDA.Fill(myDataSet, "Room")
        myDA.Fill(myDataSet, "Checkin_room")
        checkedR.DataSource = myDataSet.Tables("Guest").DefaultView
        checkedR.DataSource = myDataSet.Tables("Room").DefaultView
        checkedR.DataSource = myDataSet.Tables("Checkin_room").DefaultView
        con.Close()


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
    Sub Calculate()
         Try
            If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                txtNoOfDays.Text = 1
            Else
                txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
            End If
            txtTotalRoomCharges.Text = CInt(Val(txtRoomCharges.Text) * Val(txtNoOfDays.Text)).ToString()
            txtDiscount.Text = CInt(((Val(txtTotalRoomCharges.Text) + Val(txtOtherCharges.Text)) * Val(txtDiscountPer.Text)) / 100).ToString()
            txtSubTotal.Text = CInt(Val(txtTotalRoomCharges.Text) + Val(txtOtherCharges.Text)) - Val(txtDiscount.Text).ToString()
            num1 = CDbl((Val(txtSubTotal.Text) * Val(txtServiceTaxPer.Text)) / 100).ToString()
            num1 = Math.Round(num1, 2)
            txtServiceTaxAmount.Text = num1
            num2 = CDbl(((Val(txtSubTotal.Text) + Val(txtServiceTaxAmount.Text)) * Val(txtLuxuryTaxPer.Text)) / 100).ToString()
            num2 = Math.Round(num2, 2)
            txtLuxuryTaxAmount.Text = num2
            txtGrandTotal.Text = CInt(Val(txtSubTotal.Text) + Val(txtServiceTaxAmount.Text) + Val(txtLuxuryTaxAmount.Text)).ToString()
            txtBalance.Text = CInt(Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)).ToString()
            num4 = CDbl(Val(txtServiceTaxPer.Text) * 2) / 100
            num4 = Math.Round(num4, 2)
            txtEducessTax.Text = num4
            num5 = CDbl((Val(txtServiceTaxAmount.Text) * Val(txtEducessTax.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtEducessTaxAmount.Text = num5
            num6 = CDbl((Val(txtServiceTaxPer.Text) * 1) / 100)
            num6 = Math.Round(num6, 2)
            txtHEduCessTax.Text = num6
            num7 = CDbl((Val(txtServiceTaxAmount.Text) * Val(txtHEduCessTax.Text)) / 100)
            num7 = Math.Round(num7, 2)
            txtHEducessTaxAmount.Text = num7
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtOtherCharges_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherCharges.TextChanged
      
        Calculate()
    End Sub

    Private Sub txtServiceTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceTaxPer.TextChanged
     
        Calculate()
    End Sub

    Private Sub txtLuxuryTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLuxuryTaxPer.TextChanged
   
        Calculate()
    End Sub

    Private Sub txtDiscountPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPer.TextChanged
     
        Calculate()
    End Sub

    Private Sub txtTotalPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid.TextChanged
        Calculate()
    End Sub

    Private Sub txtOtherCharges_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherCharges.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtServiceTaxPer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServiceTaxPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtServiceTaxPer.Text
            Dim selectionStart = Me.txtServiceTaxPer.SelectionStart
            Dim selectionLength = Me.txtServiceTaxPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an Integereger that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtLuxuryTaxPer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLuxuryTaxPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtLuxuryTaxPer.Text
            Dim selectionStart = Me.txtLuxuryTaxPer.SelectionStart
            Dim selectionLength = Me.txtLuxuryTaxPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an Integereger that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiscountPer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscountPer.Text
            Dim selectionStart = Me.txtDiscountPer.SelectionStart
            Dim selectionLength = Me.txtDiscountPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an Integereger that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalPaid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalPaid.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Sub Reset()
        txtGuestID.Text = ""
        cmbCurrency.Text = ""
        txtGuestName.Text = ""
        txtGuestAddress.Text = ""
        txtGuestCity.Text = ""
        txtGuestContactNo.Text = ""
        txtIDType.Text = ""
        txtIDNumber.Text = ""
        txtNotes.Text = ""
        txtRoomNo.Text = ""
        txtRoomCharges.Text = ""
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today
        txtNoOfKids.Text = ""
        txtNoOfAdults.Text = ""
        txtNoOfDays.Text = ""
        txtExtraBed.Text = ""
        txtTotalRoomCharges.Text = ""
        txtOtherCharges.Text = ""
        txtSubTotal.Text = ""
        txtServiceTaxPer.Text = ""
        txtServiceTaxAmount.Text = ""
        txtLuxuryTaxPer.Text = ""
        txtLuxuryTaxAmount.Text = ""
        txtDiscountPer.Text = ""
        txtDiscount.Text = ""
        txtGrandTotal.Text = ""
        txtTotalPaid.Text = ""
        txtBalance.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate_record.Enabled = False
        Button13.Focus()
        btnPrint.Enabled = False
    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRecord.Click
        Reset()
        Reset()
    End Sub

    Private Sub dtpDateOut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOut.ValueChanged
        Try
            If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                txtNoOfDays.Text = 1
            Else
                txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
            End If
            txtTotalRoomCharges.Text = CInt(Val(txtRoomCharges.Text) * Val(txtNoOfDays.Text)).ToString()
            txtOtherCharges.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Calculate()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct1 As String = "delete from Tax_Room where BillID=" & txtBillID.Text & ""
            cmd = New OleDbCommand(ct1)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cq As String = "delete from Checkout_Room where ID=" & txtBillID.Text & ""
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub auto()

        Dim Num As Integer = 0
        con = New OleDbConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM CheckOut_Room")
        cmd = New OleDbCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "B" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "B" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(cmbCurrency.Text)) = 0 Then
                MessageBox.Show("Please select currency", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCurrency.Focus()
                Exit Sub
            End If
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(txtOtherCharges.Text)) = 0 Then
                MessageBox.Show("Please enter other charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtOtherCharges.Focus()
                Exit Sub
            End If
            If Len(Trim(txtServiceTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter service tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtServiceTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLuxuryTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter luxury tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLuxuryTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer.Text)) = 0 Then
                MessageBox.Show("Please enter discount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtBalance.Text) < 0 Then
                MessageBox.Show("Balance can not be less than zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "select CheckInID from CheckOut_Room where CheckInID= " & txtID1.Text & ""
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Guest already checked out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Reset()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            auto()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "insert into CheckOut_Room(ID,BillNo,CheckInID,CheckOutDate,Notes,HotelID,CurrencyID ) VALUES (" & txtBillID.Text & ",'" & txtBillNo.Text & "'," & txtID1.Text & ",#" & DateTime.Now & "#,'" & txtNotes.Text & "'," & txtHotelID.Text & "," & txtCurrencyID.Text & ")"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb2 As String = "update CheckIN_Room set GuestID='" & txtGuestID.Text & "',RoomNo='" & txtRoomNo.Text & "',RoomCharges=" & txtRoomCharges.Text & ",DateIN=#" & dtpDateIn.Value & "#,DateOUT=#" & dtpDateOut.Value & "#,NoOfAdults=" & txtNoOfAdults.Text & ",NoOfKids=" & txtNoOfKids.Text & ",NoOfDays=" & txtNoOfDays.Text & ",TotalRoomCharges=" & txtTotalRoomCharges.Text & ",OtherCharges=" & txtOtherCharges.Text & ",SubTotal=" & txtSubTotal.Text & ",ServiceTaxPer=" & txtServiceTaxPer.Text & ",ServiceTaxAmount=" & txtServiceTaxAmount.Text & ",LuxuryTaxPer=" & txtLuxuryTaxPer.Text & ",LuxuryTaxAmount=" & txtLuxuryTaxAmount.Text & ",DiscountPer=" & txtDiscountPer.Text & ",Discount=" & txtDiscount.Text & " ,GrandTotal=" & txtGrandTotal.Text & ",TotalPaid=" & txtTotalPaid.Text & ",Balance=" & txtBalance.Text & ",Status='Checked Out',CurrencyID=" & txtCurrencyID.Text & " where ID=" & txtID1.Text & ""
            cmd = New OleDbCommand(cb2)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ID FROM Checkout_Room WHERE CheckInID= " & txtID1.Text & ""
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCheckOutID.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb3 As String = "insert Into Tax_Room(BillID, HEduTax, HEduTaxAmount, EducationalTax, EducationalTaxAmount) VALUES (" & txtBillID.Text & "," & txtHEduCessTax.Text & "," & txtHEducessTaxAmount.Text & "," & txtEducessTax.Text & "," & txtEducessTaxAmount.Text & ")"
            cmd = New OleDbCommand(cb3)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            btnSave.Enabled = False
            btnPrint.Enabled = True
            MessageBox.Show("Successfully Checked out", "Guest", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate_record.Click
        Try
            If Len(Trim(cmbCurrency.Text)) = 0 Then
                MessageBox.Show("Please select currency", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCurrency.Focus()
                Exit Sub
            End If
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(txtOtherCharges.Text)) = 0 Then
                MessageBox.Show("Please enter other charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtOtherCharges.Focus()
                Exit Sub
            End If
            If Len(Trim(txtServiceTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter service tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtServiceTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLuxuryTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter luxury tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLuxuryTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer.Text)) = 0 Then
                MessageBox.Show("Please enter discount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtBalance.Text) < 0 Then
                MessageBox.Show("Balance can not be less than zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "Update CheckOut_Room set Notes='" & txtNotes.Text & "',CurrencyID=" & txtCurrencyID.Text & " where ID= " & txtBillID.Text & ""
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb2 As String = "update CheckIN_Room set GuestID='" & txtGuestID.Text & "',RoomNo='" & txtRoomNo.Text & "',RoomCharges=" & txtRoomCharges.Text & ",DateIN=#" & dtpDateIn.Value & "#,DateOUT=#" & dtpDateOut.Value & "#,NoOfAdults=" & txtNoOfAdults.Text & ",NoOfKids=" & txtNoOfKids.Text & ",NoOfDays=" & txtNoOfDays.Text & ",TotalRoomCharges=" & txtTotalRoomCharges.Text & ",OtherCharges=" & txtOtherCharges.Text & ",SubTotal=" & txtSubTotal.Text & ",ServiceTaxPer=" & txtServiceTaxPer.Text & ",ServiceTaxAmount=" & txtServiceTaxAmount.Text & ",LuxuryTaxPer=" & txtLuxuryTaxPer.Text & ",LuxuryTaxAmount=" & txtLuxuryTaxAmount.Text & ",DiscountPer=" & txtDiscountPer.Text & ",Discount=" & txtDiscount.Text & " ,GrandTotal=" & txtGrandTotal.Text & ",TotalPaid=" & txtTotalPaid.Text & ",Balance=" & txtBalance.Text & ",CurrencyID=" & txtCurrencyID.Text & " where ID=" & txtID1.Text & ""
            cmd = New OleDbCommand(cb2)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb1 As String = "Update Tax_Room set HEduTax=" & txtHEduCessTax.Text & ",HEduTaxAmount=" & txtHEducessTaxAmount.Text & ",EducationalTax=" & txtEducessTax.Text & ",EducationalTaxAmount=" & txtEducessTaxAmount.Text & " where BillID=" & txtBillID.Text & ""
            cmd = New OleDbCommand(cb1)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            btnUpdate_record.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptInvoice_Room() 'The report you created.
            Dim myConnection As OleDbConnection
            Dim MyCommand As New OleDbCommand()
            Dim myDA As New OleDbDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New OleDbConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "SELECT CheckIN_Room.RoomNo, CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfAdults, CheckIN_Room.NoOfKids,CheckIN_Room.NoOfDays, CheckIN_Room.ExtraBed, CheckIN_Room.TotalRoomCharges, CheckIN_Room.OtherCharges, CheckIN_Room.SubTotal, CheckIN_Room.ServiceTaxPer,CheckIN_Room.ServiceTaxAmount, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.DiscountPer, CheckIN_Room.Discount, CheckIN_Room.GrandTotal, CheckIN_Room.TotalPaid,CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Checkout_Room.BillNo, Checkout_Room.CheckInID, Checkout_Room.CurrencyID, Checkout_Room.HotelID,Checkout_Room.CheckOutDate, Guest.GuestID, Guest.GuestName, Guest.Address , Guest.City, Guest.ContactNo, Guest.IDType, Guest.IDNumber, HotelInfo.HotelName, HotelInfo.Address AS Expr1 , HotelInfo.ContactNo  AS Expr2 , HotelInfo.ContactNo1,HotelInfo.Email, HotelInfo.TIN, HotelInfo.STNo, HotelInfo.Logo, CurrencySet.CS_Currency FROM (((((CheckIN_Room INNER JOIN Room ON CheckIN_Room.RoomNo = Room.RoomNo) INNER JOIN Checkout_Room ON CheckIN_Room.ID = Checkout_Room.CheckInID) INNER JOIN HotelInfo ON Checkout_Room.HotelID = HotelInfo.ID) INNER JOIN CurrencySet ON Checkout_Room.CurrencyID = CurrencySet.ID) INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.GuestID) where Checkout_Room.BillNo= '" & txtBillNo.Text & "'"
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "CheckIn_room")
            myDA.Fill(myDS, "Checkout_Room")
            myDA.Fill(myDS, "CurrencySet")
            myDA.Fill(myDS, "HotelInfo")
            rpt.SetDataSource(myDS)
            frmInvoice_Room.CrystalReportViewer1.ReportSource = rpt
            frmInvoice_Room.Show()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Sub HotelID()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ID FROM HotelInfo "
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtHotelID.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub fillCurrency()
        Try
            Dim CN As New OleDbConnection(cs)
            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct RTRIM(CS_Currency) FROM CurrencySet", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCurrency.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCurrency.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmCheckOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        yonatanabi()
        yonatanload()
        yoniroomNo()
        fillRoomNo()
        HotelID()
        fillCurrency()
    End Sub

    Private Sub cmbCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCurrency.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ID FROM CurrencySet where CS_Currency='" & cmbCurrency.Text & "'"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCurrencyID.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub txtTotalPaid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalPaid.Validating
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Text = ""
            txtTotalPaid.Focus()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()

    End Sub

    Private Sub checkedR_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles checkedR.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = checkedR.SelectedRows(0)
            Me.Hide()
            Me.Show()
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT sum(PaymentDue) FROM CheckIN_Room,Order_Info where Order_info.CheckInId=Checkin_Room.ID and Checkin_Room.ID= " & dr.Cells(0).Value.ToString() & ""
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                TextBox1.Text = rdr.GetValue(0).ToString()
            Else
                TextBox1.Text = 0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            
            Me.txtID1.Text = dr.Cells(0).Value.ToString()
            Me.txtGuestID.Text = dr.Cells(1).Value.ToString()
            Me.txtGuestName.Text = dr.Cells(2).Value.ToString()
            Me.txtGuestAddress.Text = dr.Cells(3).Value.ToString()
            Me.txtGuestCity.Text = dr.Cells(4).Value.ToString()
            Me.txtGuestContactNo.Text = dr.Cells(5).Value.ToString()
            Me.txtIDType.Text = dr.Cells(6).Value.ToString()
            Me.txtIDNumber.Text = dr.Cells(7).Value.ToString()
            Me.txtRoomNo.Text = dr.Cells(8).Value.ToString()
            Me.txtRoomCharges.Text = dr.Cells(9).Value.ToString()
            Me.dtpDateIn.Text = dr.Cells(10).Value.ToString()
            Me.dtpDateOut.Text = dr.Cells(11).Value.ToString()
            Me.txtNoOfAdults.Text = dr.Cells(12).Value.ToString()
            Me.txtNoOfKids.Text = dr.Cells(13).Value.ToString()
            Me.txtNoOfDays.Text = dr.Cells(14).Value.ToString()
            Me.txtExtraBed.Text = dr.Cells(15).Value.ToString()
            Me.txtTotalRoomCharges.Text = dr.Cells(16).Value.ToString()
            Me.txtOtherCharges.Text = dr.Cells(17).Value.ToString() + Val(TextBox1.Text)
            Me.txtSubTotal.Text = dr.Cells(18).Value.ToString()
            Me.txtServiceTaxPer.Text = dr.Cells(19).Value.ToString()
            Me.txtServiceTaxAmount.Text = dr.Cells(20).Value.ToString()
            Me.txtLuxuryTaxPer.Text = dr.Cells(21).Value.ToString()
            Me.txtLuxuryTaxAmount.Text = dr.Cells(22).Value.ToString()
            Me.txtDiscountPer.Text = dr.Cells(23).Value.ToString()
            Me.txtDiscount.Text = dr.Cells(24).Value.ToString()
            Me.txtGrandTotal.Text = dr.Cells(25).Value.ToString()
            Me.txtTotalPaid.Text = dr.Cells(26).Value.ToString()
            Me.txtBalance.Text = dr.Cells(27).Value.ToString()
            Me.txtCurrencyID.Text = dr.Cells(29).Value.ToString()
            Me.cmbCurrency.Text = dr.Cells(30).Value.ToString()
            Me.txtNotes.Text = dr.Cells(31).Value.ToString()
            Me.Calculate()
            Me.Button13.Focus()
            Me.txtBalance.Text = CInt(Val(Me.txtGrandTotal.Text) - Val(Me.txtTotalPaid.Text)).ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub SearchCyoni_TextChanged(sender As Object, e As EventArgs) Handles SearchCyoni.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Checkin_Room.ID as [Checked In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOUT as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,Status,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkin_Room.Notes from Guest,Room,Checkin_Room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and Checkin_Room.CurrencyID=CurrencySet.ID  and Status='Checked In' and GuestName like '" & SearchCyoni.Text & "%' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            checkedR.DataSource = myDataSet.Tables("Guest").DefaultView
            checkedR.DataSource = myDataSet.Tables("Room").DefaultView
            checkedR.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoomNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Checkin_Room.ID as [Checked In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOUT as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,Status,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkin_Room.Notes from Guest,Room,Checkin_Room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and Checkin_Room.CurrencyID=CurrencySet.ID  and Status='Checked In' and Room.RoomNo= '" & cmbRoomNo.Text & "' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            checkedR.DataSource = myDataSet.Tables("Guest").DefaultView
            checkedR.DataSource = myDataSet.Tables("Room").DefaultView
            checkedR.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub checkoutyoni_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles checkoutyoni.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = checkoutyoni.SelectedRows(0)
            
            Me.txtBillID.Text = dr.Cells(0).Value.ToString()
            Me.txtBillNo.Text = dr.Cells(1).Value.ToString()
            Me.txtID1.Text = dr.Cells(2).Value.ToString()
            Me.txtGuestID.Text = dr.Cells(3).Value.ToString()
            Me.txtGuestName.Text = dr.Cells(4).Value.ToString()
            Me.txtGuestAddress.Text = dr.Cells(5).Value.ToString()
            Me.txtGuestCity.Text = dr.Cells(6).Value.ToString()
            Me.txtGuestContactNo.Text = dr.Cells(7).Value.ToString()
            Me.txtIDType.Text = dr.Cells(8).Value.ToString()
            Me.txtIDNumber.Text = dr.Cells(9).Value.ToString()
            Me.txtRoomNo.Text = dr.Cells(10).Value.ToString()
            Me.txtRoomCharges.Text = dr.Cells(11).Value.ToString()
            Me.dtpDateIn.Text = dr.Cells(12).Value.ToString()
            Me.dtpDateOut.Text = dr.Cells(13).Value.ToString()
            Me.txtNoOfAdults.Text = dr.Cells(14).Value.ToString()
            Me.txtNoOfKids.Text = dr.Cells(15).Value.ToString()
            Me.txtNoOfDays.Text = dr.Cells(16).Value.ToString()
            Me.txtExtraBed.Text = dr.Cells(17).Value.ToString()
            Me.txtTotalRoomCharges.Text = dr.Cells(18).Value.ToString()
            Me.txtOtherCharges.Text = dr.Cells(19).Value.ToString()
            Me.txtSubTotal.Text = dr.Cells(20).Value.ToString()
            Me.txtServiceTaxPer.Text = dr.Cells(21).Value.ToString()
            Me.txtServiceTaxAmount.Text = dr.Cells(22).Value.ToString()
            Me.txtLuxuryTaxPer.Text = dr.Cells(23).Value.ToString()
            Me.txtLuxuryTaxAmount.Text = dr.Cells(24).Value.ToString()
            Me.txtDiscountPer.Text = dr.Cells(25).Value.ToString()
            Me.txtDiscount.Text = dr.Cells(26).Value.ToString()
            Me.txtGrandTotal.Text = dr.Cells(27).Value.ToString()
            Me.txtTotalPaid.Text = dr.Cells(28).Value.ToString()
            Me.txtBalance.Text = dr.Cells(29).Value.ToString()
            Me.txtCurrencyID.Text = dr.Cells(30).Value.ToString()
            Me.cmbCurrency.Text = dr.Cells(31).Value.ToString()
            Me.txtNotes.Text = dr.Cells(32).Value.ToString()
            Me.btnUpdate_record.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnSave.Enabled = False
            Me.btnPrint.Enabled = True
            Me.Button13.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub checkoutR_TextChanged(sender As Object, e As EventArgs) Handles checkoutR.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Checkout_Room.ID as [Bill ID],BillNo as [Bill No],CheckInID as [Check In ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No], Checkin_Room.RoomCharges as [Room Charges], DateIN as [Date IN], DateOut as [Date Out], NoOfAdults as [No Of Adults], NoOfKids as [No Of Kids], NoOfDays as [No Of Days],ExtraBed as [Extra Bed], TotalRoomCharges as [Total Room Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Checkout_Room.Notes from Guest,Room,Checkin_Room,Checkout_room,CurrencySet where Guest.GuestID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and CheckIn_Room.ID=CheckOut_Room.CheckInID and CurrencySet.ID=Checkout_Room.CurrencyID and Guestname like '" & checkoutR.Text & "%' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Checkin_room")
            myDA.Fill(myDataSet, "Checkout_room")
            checkoutyoni.DataSource = myDataSet.Tables("Guest").DefaultView
            checkoutyoni.DataSource = myDataSet.Tables("Room").DefaultView
            checkoutyoni.DataSource = myDataSet.Tables("Checkin_room").DefaultView
            checkoutyoni.DataSource = myDataSet.Tables("Checkout_room").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class