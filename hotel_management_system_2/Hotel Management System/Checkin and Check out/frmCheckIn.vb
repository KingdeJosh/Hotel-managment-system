Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Security.Cryptography
Imports System.Text
Public Class frmCheckIn
    Private Const STR_TotalPaidCanNotBeMoreThanGrandTotal As String = "Total paid can not be more than grand total"
    Private Const STR_SelectedDateOutMustBeGreaterThanDateIn As String = "Selected date out must be greater than date in"
    Private Const STR_PleaseSelectRoomNo As String = "Please select room no."
    Private Const STR_SELECTRoomChargesFROMRoomWHERERoomNo As String = "SELECT RoomCharges FROM Room WHERE RoomNo= '"
    Private Const STR_SELECTDistinctRTRIMCS_CurrencyFROMCurrencySet As String = "SELECT distinct RTRIM(CS_Currency) FROM CurrencySet"
    Private Const STR_SELECTIDFROMHotelInfo As String = "SELECT ID FROM HotelInfo "
    Private Const STR_SELECTChargesFROMGarden As String = "SELECT Charges FROM Garden"
    Private Const STR_SELECTChargesFromHall As String = "SELECT Charges from Hall "
    Private Const STR_SELECTDistinctRTRIMRoomNoFROMRoom As String = "SELECT distinct RTRIM(RoomNo) FROM Room"
    Private Const STR_SELECTReservationIDAsReservationNoGuestGuestIDAs As String = "SELECT ReservationID as [Reservation No],Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No],RoomCharges as [Room Charges], DateIN as [Date IN], DateOUT as [Date OUT], Status, Temp_Reservation.Notes as [Notes] from Guest,Temp_Reservation,Room where Guest.GuestID=Temp_Reservation.GuestID and Room.RoomNo=Temp_Reservation.RoomNo and Status='Reserved' order by GuestName"
    Private Const STR_SELECTGuestIDasGuestIDGuestnameAsGuestNameaddres As String = "SELECT (GuestID)as [Guest ID],(Guestname) as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],Notes from Guest order by GuestName"
    Private Const STR_SELECTReservation_HallandGardenIDAsReservationID As String = "SELECT Reservation_HallandGarden.ID as [Reservation ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],DateFrom_Hall as [Hall Date From], DateTo_Hall as [Hall Date To], Days_Hall as [Hall Days], Rate_Hall as [Hall Rate],TotalCharges_Hall as [Hall Total Charges],DateFrom_Garden as [Garden Date From], DateTo_Garden as [Garden Date To,], Days_Garden as [Garden Days], Rate_Garden as [Garden Rate],TotalCharges_Garden as [Garden Total Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Reservation_HallandGarden.Notes from Guest,Reservation_HallandGarden,CurrencySet where Guest.GuestID=Reservation_HallandGarden.GuestID and CurrencySet.ID=Reservation_HallandGarden.CurrencyID   order by GuestName"
    Private Const STR_SELECTReservation_HallorGardenIDAsReservationIDG As String = "SELECT Reservation_HallorGarden.ID as [Reservation ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],Type as [Type],DateFrom as [Date From], DateTo as [Date To], Days as [No Of Days], Rate,TotalCharges as [Total Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],Cs_Currency as [Currency], Reservation_HallorGarden.Notes from Guest,Reservation_HallorGarden,CurrencySet where Guest.GuestID=Reservation_HallorGarden.GuestID and Reservation_HallorGarden.CurrencyID=CurrencySet.ID   order by GuestName"







    Dim ExtraBedStatus As String
    Dim num1, num2, num4, num5, num6, num7 As Double
    Public type As String

    Sub yoniman()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTReservation_HallorGardenIDAsReservationIDG, con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Reservation_HallorGarden")
            hallorgarden.DataSource = myDataSet.Tables("Guest").DefaultView
            hallorgarden.DataSource = myDataSet.Tables("Reservation_HallorGarden").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub yoniguestload()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTGuestIDasGuestIDGuestnameAsGuestNameaddres, con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            guestrr.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub yonatanreservationhallandgarden()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTReservation_HallandGardenIDAsReservationID, con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Reservation_HallandGarden")
            hallandgarden.DataSource = myDataSet.Tables("Guest").DefaultView
            hallandgarden.DataSource = myDataSet.Tables("Reservation_HallandGarden").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub yoniloadguest()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTGuestIDasGuestIDGuestnameAsGuestNameaddres, con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            guestR.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub yonigestrecordload()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTGuestIDasGuestIDGuestnameAsGuestNameaddres, con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            guestRecordG.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub yonireservationguest()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTReservationIDAsReservationNoGuestGuestIDAs, con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Temp_Reservation")
            reservationGR.DataSource = myDataSet.Tables("Guest").DefaultView
            reservationGR.DataSource = myDataSet.Tables("Room").DefaultView
            reservationGR.DataSource = myDataSet.Tables("Temp_Reservation").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Compute()
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Compute1()
        Try
            txtDaysHall.Text = dtpDateTo_Hall.Value.Date.Subtract(dtpDateFrom_Hall.Value.Date).Days.ToString
            txtDaysGarden.Text = dtpDateTo_Garden.Value.Date.Subtract(dtpDateFrom_Garden.Value.Date).Days.ToString
            txtTotalHall.Text = CInt(Val(txtDaysHall.Text) * Val(txtRateHall.Text)).ToString()
            txtTotalGarden.Text = CInt(Val(txtDaysGarden.Text) * Val(txtRateGarden.Text)).ToString()
            txtDiscount1.Text = CInt(((Val(txtTotalHall.Text) + Val(txtTotalGarden.Text) + Val(txtOtherCharges1.Text)) * Val(txtDiscountPer1.Text)) / 100).ToString()
            txtSubTotal1.Text = CInt(Val(txtTotalHall.Text) + Val(txtTotalGarden.Text) + Val(txtOtherCharges1.Text) - Val(txtDiscount1.Text)).ToString()
            num1 = CDbl((Val(txtSubTotal1.Text) * Val(txtServiceTaxPer1.Text)) / 100).ToString()
            num1 = Math.Round(num1, 2)
            txtServiceTaxAmount1.Text = num1
            num2 = CDbl(((Val(txtSubTotal1.Text) + Val(txtServiceTaxAmount1.Text)) * Val(txtLuxuryTaxPer1.Text)) / 100).ToString()
            num2 = Math.Round(num2, 2)
            txtLuxuryTaxAmount1.Text = num2
            txtGrandTotal1.Text = CInt(Val(txtSubTotal1.Text) + Val(txtServiceTaxAmount1.Text) + Val(txtLuxuryTaxAmount1.Text)).ToString()
            txtBalance1.Text = CInt(Val(txtGrandTotal1.Text) - Val(txtTotalPaid1.Text)).ToString()
            num4 = CDbl(Val(txtServiceTaxPer1.Text) * 2) / 100
            num4 = Math.Round(num4, 2)
            txtEducessTax.Text = num4
            num5 = CDbl((Val(txtServiceTaxAmount1.Text) * Val(txtEducessTax.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtEducessTaxAmount.Text = num5
            num6 = CDbl((Val(txtServiceTaxPer1.Text) * 1) / 100)
            num6 = Math.Round(num6, 2)
            txtHEduCessTax.Text = num6
            num7 = CDbl((Val(txtServiceTaxAmount1.Text) * Val(txtHEduCessTax.Text)) / 100)
            num7 = Math.Round(num7, 2)
            txtHEducessTaxAmount.Text = num7
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Compute2()
        Try
            txtNoOfDays1.Text = DateTo.Value.Date.Subtract(DateFrom.Value.Date).Days.ToString
            txtTotalCharges.Text = CInt(Val(txtNoOfDays1.Text) * Val(txtRate.Text)).ToString()
            txtDiscount2.Text = CInt(((Val(txtTotalCharges.Text) + Val(txtOtherCharges2.Text)) * Val(txtDiscountPer2.Text)) / 100).ToString()
            txtSubTotal2.Text = CInt(Val(txtTotalCharges.Text) + Val(txtOtherCharges2.Text) - Val(txtDiscount2.Text))
            num1 = CDbl((Val(txtSubTotal2.Text) * Val(txtServiceTaxPer2.Text)) / 100).ToString()
            num1 = Math.Round(num1, 2)
            txtServiceTaxAmount2.Text = num1
            num2 = CDbl(((Val(txtSubTotal2.Text) + Val(txtServiceTaxAmount2.Text)) * Val(txtLuxuryTaxPer2.Text)) / 100).ToString()
            num2 = Math.Round(num2, 2)
            txtLuxuryTaxAmount2.Text = num2
            txtGrandTotal2.Text = CInt(Val(txtSubTotal2.Text) + Val(txtServiceTaxAmount2.Text) + Val(txtLuxuryTaxAmount2.Text)).ToString()
            txtBalance2.Text = CInt(Val(txtGrandTotal2.Text) - Val(txtTotalPaid2.Text)).ToString()
            num4 = CDbl(Val(txtServiceTaxPer2.Text) * 2) / 100
            num4 = Math.Round(num4, 2)
            txteducessTax1.Text = num4
            num5 = CDbl((Val(txtServiceTaxAmount2.Text) * Val(txteducessTax1.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txteducessTaxAmount1.Text = num5
            num6 = CDbl((Val(txtServiceTaxPer2.Text) * 1) / 100)
            num6 = Math.Round(num6, 2)
            txtHeducessTax1.Text = num6
            num7 = CDbl((Val(txtServiceTaxAmount2.Text) * Val(txtHeducessTax1.Text)) / 100)
            num7 = Math.Round(num7, 2)
            txtHeducessTaxAmount1.Text = num7
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Shared Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        chars = "123456789".ToCharArray()
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function
    Sub fillRoomNo()
        Try
            Dim CN As New OleDbConnection(cs)
            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand(STR_SELECTDistinctRTRIMRoomNoFROMRoom, CN)
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
  
    Sub Charges_Hall()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = STR_SELECTChargesFromHall
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRateHall.Text = rdr.GetValue(0)
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
    Sub Charges_Garden()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = STR_SELECTChargesFROMGarden
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRateGarden.Text = rdr.GetValue(0)
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
    Sub HotelID()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = STR_SELECTIDFROMHotelInfo
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
            adp.SelectCommand = New OleDbCommand(STR_SELECTDistinctRTRIMCS_CurrencyFROMCurrencySet, CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCurrency.Items.Clear()
            cmbCurrency1.Items.Clear()
            cmbCurrency2.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCurrency.Items.Add(drow(0).ToString())
                cmbCurrency1.Items.Add(drow(0).ToString())
                cmbCurrency2.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmCheckIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        yoniman()
        yoniguestload()
        yonatanreservationhallandgarden()
        yoniloadguest()
        yonireservationguest()
        yonigestrecordload()
        fillRoomNo()
        Charges_Garden()
        Charges_Hall()
        Reset1()
        HotelID()
        fillCurrency()
    End Sub

    Private Sub cmbRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = STR_SELECTRoomChargesFROMRoomWHERERoomNo & cmbRoomNo.Text & "'"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRoomCharges.Text = rdr.GetValue(0)
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


    Private Sub hsKids_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hsKids.ValueChanged
        txtNoOfKids.Text = hsKids.Value.ToString
    End Sub

    Private Sub hsAdults_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hsAdults.ValueChanged
        txtNoOfAdults.Text = hsAdults.Value.ToString
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
        Compute()
    End Sub

    Private Sub dtpDateOut_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateOut.Validating
        Try
            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show(STR_PleaseSelectRoomNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbRoomNo.Focus()
                Exit Sub
            End If

            If dtpDateOut.Value.Date < dtpDateIn.Value.Date Then
                MessageBox.Show(STR_SelectedDateOutMustBeGreaterThanDateIn, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpDateOut.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

   
    Private Sub txtOtherCharges_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherCharges.TextChanged
        Compute()
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

    Private Sub txtServiceTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceTaxPer.TextChanged
        Compute()
    End Sub

    Private Sub txtLuxuryTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLuxuryTaxPer.TextChanged
        Compute()
    End Sub

   
    Private Sub txtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPer.TextChanged
        Compute()
    End Sub

    Private Sub txtDiscount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountPer.KeyPress
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

    Private Sub txtTotalPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid.TextChanged
        Compute()
    End Sub

    Private Sub txtTotalPaid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalPaid.Validating
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show(STR_TotalPaidCanNotBeMoreThanGrandTotal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Text = ""
            txtTotalPaid.Focus()
        End If
    End Sub
    Sub Reset()
        cmbCurrency2.Text = ""
        CheckBox1.Checked = False
        txtGuestID.Text = ""
        txtGuestName.Text = ""
        txtGuestAddress.Text = ""
        txtGuestCity.Text = ""
        txtGuestContactNo.Text = ""
        txtIDType.Text = ""
        txtIDNumber.Text = ""
        txtNotes.Text = ""
        cmbRoomNo.Text = ""
        txtRoomCharges.Text = ""
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today
        txtNoOfAdults.Text = 1
        txtNoOfKids.Text = 0
        txtNoOfDays.Text = ""
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
        btnCheckedIN.Enabled = False


    End Sub
    Sub Reset1()
        txtGuestID1.Text = ""
        cmbCurrency.Text = ""
        txtGuestName1.Text = ""
        txtGuestAddress1.Text = ""
        txtCity1.Text = ""
        txtContactNo1.Text = ""
        txtIDType1.Text = ""
        txtIDNumber1.Text = ""
        dtpDateFrom_Hall.Text = Today
        dtpDateTo_Hall.Text = Today
        txtDaysHall.Text = ""
        txtTotalHall.Text = ""
        dtpDateFrom_Garden.Text = Today
        dtpDateTo_Garden.Text = Today
        txtDaysGarden.Text = ""
        txtTotalGarden.Text = ""
        txtOtherCharges1.Text = ""
        txtSubTotal1.Text = ""
        txtServiceTaxPer1.Text = ""
        txtServiceTaxAmount1.Text = ""
        txtLuxuryTaxPer1.Text = ""
        txtLuxuryTaxAmount1.Text = ""
        txtDiscountPer1.Text = ""
        txtDiscount1.Text = ""
        txtGrandTotal1.Text = ""
        txtTotalPaid1.Text = ""
        txtBalance1.Text = ""
        txtID2.Text = ""
        btnSave1.Enabled = True
        btnDelete1.Enabled = False
        btnUpdate1.Enabled = False
        btnPrint.Enabled = False
    End Sub
    Sub Reset2()
        cmbCurrency1.Text = ""
        txtGuestID2.Text = ""
        txtGuestName2.Text = ""
        txtGuestAddress2.Text = ""
        txtGuestCity2.Text = ""
        txtGuestContactNo2.Text = ""
        txtIDType2.Text = ""
        txtIDNumber2.Text = ""
        DateFrom.Text = Today
        DateTo.Text = Today
        txtNoOfDays1.Text = ""
        txtRate.Text = ""
        txtTotalCharges.Text = ""
        txtOtherCharges2.Text = ""
        txtSubTotal2.Text = ""
        txtServiceTaxPer2.Text = ""
        txtServiceTaxAmount2.Text = ""
        txtLuxuryTaxPer2.Text = ""
        txtLuxuryTaxAmount2.Text = ""
        txtDiscountPer2.Text = ""
        txtDiscount2.Text = ""
        txtGrandTotal2.Text = ""
        txtTotalPaid2.Text = ""
        txtBalance2.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        btnSave2.Enabled = True
        btnDelete2.Enabled = False
        btnUpdate2.Enabled = False
        btnPrint1.Enabled = False

    End Sub
    Private Sub btnNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRecord.Click
        Reset()
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show(STR_PleaseSelectRoomNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCurrency2.Text)) = 0 Then
                MessageBox.Show("Please select currency", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCurrency2.Focus()
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
            If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show(STR_TotalPaidCanNotBeMoreThanGrandTotal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Text = ""
                txtTotalPaid.Focus()
                Exit Sub
            End If

            If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RoomNo FROM Temp_Reservation WHERE RoomNo='" & cmbRoomNo.Text & "' AND Status='Reserved' and Temp_Reservation.DateIn < #" & dtpDateOut.Value.Date & "# AND Temp_Reservation.DateOut > #" & dtpDateIN.Value.Date & "# "
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct1 As String = "SELECT RoomNo FROM CheckIn_Room WHERE RoomNo='" & cmbRoomNo.Text & "' AND Status='Checked In' and Checkin_Room.DateIn < #" & dtpDateOut.Value & "# AND Checkin_Room.DateOut > #" & dtpDateIn.Value & "# "
            cmd = New OleDbCommand(ct1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room is already booked", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            If CheckBox1.Checked = True Then
                ExtraBedStatus = "Yes"
            End If
            If CheckBox1.Checked = False Then
                ExtraBedStatus = "No"
            End If
          
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "insert into CheckIN_Room( GuestID, RoomNo, RoomCharges, DateIN, DateOUT, NoOfAdults, NoOfKids, NoOfDays, TotalRoomCharges, OtherCharges, SubTotal, ServiceTaxPer,ServiceTaxAmount, LuxuryTaxPer, LuxuryTaxAmount,DiscountPer, Discount, GrandTotal, TotalPaid, Balance,Status, Notes,ExtraBed,CurrencyID) VALUES ('" & txtGuestID.Text & "','" & cmbRoomNo.Text & "'," & txtRoomCharges.Text & ",#" & dtpDateIn.Text & "#,#" & dtpDateOut.Text & "#," & txtNoOfAdults.Text & "," & txtNoOfKids.Text & "," & txtNoOfDays.Text & "," & txtTotalRoomCharges.Text & "," & txtOtherCharges.Text & "," & txtSubTotal.Text & "," & txtServiceTaxPer.Text & "," & txtServiceTaxAmount.Text & "," & txtLuxuryTaxPer.Text & "," & txtLuxuryTaxAmount.Text & "," & txtDiscountPer.Text & "," & txtDiscount.Text & " ," & txtGrandTotal.Text & "," & txtTotalPaid.Text & "," & txtBalance.Text & ",'Checked In','" & txtNotes.Text & "','" & ExtraBedStatus & "'," & txtCurrencyID.Text & ")"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            btnSave.Enabled = False
            MessageBox.Show("Successfully Checked in", "Guest", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Dim cq As String = "delete from Checkin_room where ID=" & txtID1.Text & ""
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
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete1.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord1()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord1()
        Try
            Dim RowsAffected As Integer = 0
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct1 As String = "delete from Tax_ReservationHallandGarden where ReservationID='" & txtID2.Text & "'"
            cmd = New OleDbCommand(ct1)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cq As String = "delete from Reservation_HallandGarden where ID= '" & txtID2.Text & "'"
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset1()
                Reset1()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset1()
                Reset1()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete2.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord2()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord2()
        Try
            Dim RowsAffected As Integer = 0
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct1 As String = "delete from Tax_ReservationHallorGarden where ReservationID='" & txtID3.Text & "'"
            cmd = New OleDbCommand(ct1)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cq As String = "delete from Reservation_HallorGarden where ID= '" & txtID3.Text & "'"
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset2()
                Reset2()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset2()
                Reset2()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate_record.Click
        Try

            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show(STR_PleaseSelectRoomNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCurrency2.Text)) = 0 Then
                MessageBox.Show("Please select currency", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCurrency2.Focus()
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
            If (cmbRoomNo.Text <> cmbRoomNo1.Text) Then
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct As String = "SELECT RoomNo FROM Temp_Reservation WHERE RoomNo='" & cmbRoomNo.Text & "' AND Status='Reserved' and Temp_Reservation.DateIn < #" & dtpDateOut.Value.Date & "# AND Temp_Reservation.DateOut > #" & dtpDateIN.Value.Date & "# "
                cmd = New OleDbCommand(ct)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Selected Room is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct1 As String = "SELECT RoomNo FROM CheckIn_Room WHERE RoomNo='" & cmbRoomNo.Text & "' AND Status='Checked In' and Checkin_Room.DateIn < #" & dtpDateOut.Value & "# AND Checkin_Room.DateOut > #" & dtpDateIn.Value & "# "
                cmd = New OleDbCommand(ct1)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Selected Room is already booked", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
            End If
            If CheckBox1.Checked = True Then
                ExtraBedStatus = "Yes"
            End If
            If CheckBox1.Checked = False Then
                ExtraBedStatus = "No"
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "update CheckIN_Room set GuestID='" & txtGuestID.Text & "',RoomNo='" & cmbRoomNo.Text & "',RoomCharges=" & txtRoomCharges.Text & ",DateIN=#" & dtpDateIn.Text & "#,DateOUT=#" & dtpDateOut.Text & "#,NoOfAdults=" & txtNoOfAdults.Text & ",NoOfKids=" & txtNoOfKids.Text & ",NoOfDays=" & txtNoOfDays.Text & ",TotalRoomCharges=" & txtTotalRoomCharges.Text & ",OtherCharges=" & txtOtherCharges.Text & ",SubTotal=" & txtSubTotal.Text & ",ServiceTaxPer=" & txtServiceTaxPer.Text & ",ServiceTaxAmount=" & txtServiceTaxAmount.Text & ",LuxuryTaxPer=" & txtLuxuryTaxPer.Text & ",LuxuryTaxAmount=" & txtLuxuryTaxAmount.Text & ",DiscountPer=" & txtDiscountPer.Text & ",Discount=" & txtDiscount.Text & " ,GrandTotal=" & txtGrandTotal.Text & ",TotalPaid=" & txtTotalPaid.Text & ",Balance=" & txtBalance.Text & ",Notes='" & txtNotes.Text & "',ExtraBed='" & ExtraBedStatus & "',CurrencyID=" & txtCurrencyID.Text & " where ID=" & txtID1.Text & ""
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            btnUpdate_record.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave2.Click
        Try

            If Len(Trim(txtGuestID2.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestID2.Focus()
                Exit Sub
            End If
            If RadioButton1.Checked = False And RadioButton2.Checked = False Then
                MessageBox.Show("Please select type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If Len(Trim(txtRate.Text)) = 0 Then
                MessageBox.Show("Please enter rate", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRate.Focus()
                Exit Sub
            End If
            If Len(Trim(txtOtherCharges2.Text)) = 0 Then
                MessageBox.Show("Please enter other charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtOtherCharges2.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCurrency1.Text)) = 0 Then
                MessageBox.Show("Please select currency", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCurrency1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtServiceTaxPer2.Text)) = 0 Then
                MessageBox.Show("Please enter service tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtServiceTaxPer2.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLuxuryTaxPer2.Text)) = 0 Then
                MessageBox.Show("Please enter luxury tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLuxuryTaxPer2.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer2.Text)) = 0 Then
                MessageBox.Show("Please enter discount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDiscountPer2.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid2.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid2.Focus()
                Exit Sub
            End If
            If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show(STR_TotalPaidCanNotBeMoreThanGrandTotal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Text = ""
                txtTotalPaid.Focus()
                Exit Sub
            End If

            If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        
            If RadioButton1.Checked = True Then
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct2 As String = "SELECT * FROM Reservation_HallorGarden WHERE DateFrom < #" & DateTo.Value.Date & "# AND DateTo > #" & DateFrom.Value.Date & "# "
                cmd = New OleDbCommand(ct2)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Hall is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
            End If
            If RadioButton2.Checked = True Then
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct3 As String = "SELECT * FROM Reservation_HallorGarden WHERE DateFrom < #" & DateTo.Value.Date & "# AND DateTo > #" & DateFrom.Value.Date & "# "
                cmd = New OleDbCommand(ct3)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Garden is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
            End If
            If RadioButton1.Checked Then
                type = RadioButton1.Text
            ElseIf RadioButton2.Checked Then
                type = RadioButton2.Text
            End If
            txtID3.Text = "R-" & GetUniqueKey(5)
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "insert into Reservation_HallorGarden(ID,GuestID, Type, DateFrom, DateTo, Days, Rate, TotalCharges, OtherCharges, SubTotal, ServiceTaxPer, ServiceTaxAmount, LuxuryTaxPer,LuxuryTaxAmount, DiscountPer, Discount, GrandTotal, TotalPaid, Balance, Notes,HotelID,CurrencyID) Values ('" & txtID3.Text & "','" & txtGuestID2.Text & "','" & type & "',#" & DateFrom.Value.Date & "#,#" & DateTo.Value.Date & "#," & txtNoOfDays1.Text & "," & txtRate.Text & "," & txtTotalCharges.Text & "," & txtOtherCharges2.Text & "," & txtSubTotal2.Text & "," & txtServiceTaxPer2.Text & "," & txtServiceTaxAmount2.Text & "," & txtLuxuryTaxPer2.Text & "," & txtLuxuryTaxAmount2.Text & "," & txtDiscountPer2.Text & "," & txtDiscount2.Text & " ," & txtGrandTotal2.Text & "," & txtTotalPaid2.Text & "," & txtBalance2.Text & ",'" & txtNotes2.Text & "'," & txtHotelID.Text & "," & txtCurrencyID.Text & ")"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb2 As String = "insert Into Tax_ReservationHallorGarden(ReservationID, HEduTax, HEduTaxAmount, EducationalTax, EducationalTaxAmount) VALUES ('" & txtID3.Text & "'," & txtHeducessTax1.Text & "," & txtHeducessTaxAmount1.Text & "," & txteducessTax1.Text & "," & txteducessTaxAmount1.Text & ")"
            cmd = New OleDbCommand(cb2)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            btnSave2.Enabled = False
            btnPrint1.Enabled = True
            MessageBox.Show("Successfully Reserved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        frmCheckedInRecord2.Show()
        frmCheckedInRecord2.GetData()
    End Sub

    Private Sub btnNew1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew1.Click
        Reset1()
        Reset1()
    End Sub

    Private Sub btnSave1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave1.Click
        Try
            If Len(Trim(txtGuestID1.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestID1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtRateHall.Text)) = 0 Then
                MessageBox.Show("Please enter rate of hall", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRateHall.Focus()
                Exit Sub
            End If
            If Len(Trim(txtRateGarden.Text)) = 0 Then
                MessageBox.Show("Please enter rate of garden", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRateGarden.Focus()
                Exit Sub
            End If
            If Len(Trim(txtOtherCharges1.Text)) = 0 Then
                MessageBox.Show("Please enter other charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtOtherCharges1.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCurrency.Text)) = 0 Then
                MessageBox.Show("Please select currency", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCurrency.Focus()
                Exit Sub
            End If
            If Len(Trim(txtServiceTaxPer1.Text)) = 0 Then
                MessageBox.Show("Please enter service tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtServiceTaxPer1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLuxuryTaxPer1.Text)) = 0 Then
                MessageBox.Show("Please enter luxury tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLuxuryTaxPer1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer1.Text)) = 0 Then
                MessageBox.Show("Please enter discount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDiscountPer1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid1.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid1.Focus()
                Exit Sub
            End If
            If Val(txtBalance1.Text) < 0 Then
                MessageBox.Show("Balance can not be less than zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid1.Focus()
                Exit Sub
            End If
            If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show(STR_TotalPaidCanNotBeMoreThanGrandTotal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Text = ""
                txtTotalPaid.Focus()
                Exit Sub
            End If

            If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            con = New OleDbConnection(cs)
            con.Open()
            Dim ct2 As String = "SELECT * FROM Reservation_HallorGarden WHERE DateFrom < #" & dtpDateTo_Hall.Value.Date & "# AND DateTo > #" & dtpDateFrom_Hall.Value.Date & "# "
            cmd = New OleDbCommand(ct2)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Hall is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If


            con = New OleDbConnection(cs)
            con.Open()
            Dim ct3 As String = "SELECT * FROM Reservation_HallorGarden WHERE DateFrom < #" & dtpDateTo_Garden.Value.Date & "# AND DateTo > #" & dtpDateFrom_Garden.Value.Date & "# "
            cmd = New OleDbCommand(ct3)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Garden is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If

       

            txtID2.Text = "R-" & GetUniqueKey(5)
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "insert into Reservation_HallandGarden(ID,GuestID,Hall, DateFrom_Hall, DateTo_Hall, Days_Hall, Rate_Hall, TotalCharges_Hall,Garden, DateFrom_Garden, DateTo_Garden, Days_Garden, Rate_Garden,TotalCharges_Garden, OtherCharges, SubTotal, ServiceTaxPer, ServiceTaxAmount, LuxuryTaxPer, LuxuryTaxAmount, DiscountPer, Discount, GrandTotal,TotalPaid, Balance, Notes,HotelID,CurrencyID) Values ('" & txtID2.Text & "','" & txtGuestID1.Text & "','Hall',#" & dtpDateFrom_Hall.Value.Date & "#,#" & dtpDateTo_Hall.Value.Date & "#, " & txtDaysHall.Text & "," & txtRateHall.Text & "," & txtTotalHall.Text & ",'Garden',#" & dtpDateFrom_Garden.Value.Date & "#,#" & dtpDateTo_Garden.Value.Date & "#," & txtDaysGarden.Text & "," & txtRateGarden.Text & "," & txtTotalGarden.Text & "," & txtOtherCharges1.Text & "," & txtSubTotal1.Text & "," & txtServiceTaxPer1.Text & "," & txtServiceTaxAmount1.Text & "," & txtLuxuryTaxPer1.Text & "," & txtLuxuryTaxAmount1.Text & "," & txtDiscountPer1.Text & "," & txtDiscount1.Text & " ," & txtGrandTotal1.Text & "," & txtTotalPaid1.Text & "," & txtBalance1.Text & ",'" & txtNotes1.Text & "'," & txtHotelID.Text & "," & txtCurrencyID.Text & ")"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb2 As String = "insert Into Tax_ReservationHallandGarden(ReservationID, HEduTax, HEduTaxAmount, EducationalTax, EducationalTaxAmount) VALUES ('" & txtID2.Text & "'," & txtHEduCessTax.Text & "," & txtHEducessTaxAmount.Text & "," & txtEducessTax.Text & "," & txtEducessTaxAmount.Text & ")"
            cmd = New OleDbCommand(cb2)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            btnPrint.Enabled = True
            btnSave1.Enabled = False
            MessageBox.Show("Successfully Reserved", "Hall and Garden", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpDateTo_Hall_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateTo_Hall.ValueChanged
        txtDaysHall.Text = dtpDateTo_Hall.Value.Date.Subtract(dtpDateFrom_Hall.Value.Date).Days.ToString
        Compute1()
    End Sub

    Private Sub dtpDateTo_Garden_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateTo_Garden.ValueChanged
        txtDaysGarden.Text = dtpDateTo_Garden.Value.Date.Subtract(dtpDateFrom_Garden.Value.Date).Days.ToString
        Compute1()
    End Sub

    Private Sub txtRateHall_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRateHall.TextChanged
        txtTotalHall.Text = CInt(Val(txtDaysHall.Text) * Val(txtRateHall.Text)).ToString()
        Compute1()
    End Sub

    Private Sub txtRateGarden_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRateGarden.TextChanged
        txtTotalGarden.Text = CInt(Val(txtDaysGarden.Text) * Val(txtRateGarden.Text)).ToString()
        Compute1()
    End Sub

    Private Sub txtOtherCharges1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherCharges1.TextChanged
        Compute1()
    End Sub

    Private Sub txtServiceTaxPer1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceTaxPer1.TextChanged
        Compute1()
    End Sub

    Private Sub txtLuxuryTaxPer1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLuxuryTaxPer1.TextChanged
        Compute1()
    End Sub

    Private Sub txtDiscountPer1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPer1.TextChanged
        Compute1()
    End Sub

    Private Sub txtRateHall_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRateHall.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRateGarden_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRateGarden.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtOtherCharges1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherCharges1.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtServiceTaxPer1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServiceTaxPer1.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtServiceTaxPer1.Text
            Dim selectionStart = Me.txtServiceTaxPer1.SelectionStart
            Dim selectionLength = Me.txtServiceTaxPer1.SelectionLength

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

    Private Sub txtLuxuryTaxPer1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLuxuryTaxPer1.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtLuxuryTaxPer1.Text
            Dim selectionStart = Me.txtLuxuryTaxPer1.SelectionStart
            Dim selectionLength = Me.txtLuxuryTaxPer1.SelectionLength

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

    Private Sub txtDiscountPer1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountPer1.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscountPer1.Text
            Dim selectionStart = Me.txtDiscountPer1.SelectionStart
            Dim selectionLength = Me.txtDiscountPer1.SelectionLength

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

    Private Sub txtTotalPaid1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalPaid1.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

 
    Private Sub txtTotalPaid1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid1.TextChanged
        Compute1()
    End Sub

    Private Sub dtpDateTo_Hall_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateTo_Hall.Validating
        If (dtpDateTo_Hall.Value.Date < Today) Then
            MessageBox.Show("Reservation is not possible" & vbCrLf & "Selected OUT date for hall is less than today's date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateTo_Hall.Focus()
            Exit Sub
        End If

        If (dtpDateTo_Hall.Value.Date < dtpDateFrom_Hall.Value.Date) Then
            MessageBox.Show(" Reservation Date from is greater than Date To for hall", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Compute1()
    End Sub

    Private Sub dtpDateTo_Garden_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateTo_Garden.Validating
        If (dtpDateTo_Garden.Value.Date < Today) Then
            MessageBox.Show("Reservation is not possible" & vbCrLf & "Selected OUT date for garden is less than today's date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateTo_Garden.Focus()
            Exit Sub
        End If

        If (dtpDateTo_Garden.Value.Date < dtpDateFrom_Garden.Value.Date) Then
            MessageBox.Show(" Reservation Date from is greater than Date To for garden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

  
    Private Sub btnUpdate1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate1.Click
        Try
            If Len(Trim(txtGuestID1.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestID1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtOtherCharges1.Text)) = 0 Then
                MessageBox.Show("Please enter other charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtOtherCharges1.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCurrency.Text)) = 0 Then
                MessageBox.Show("Please select currency", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCurrency.Focus()
                Exit Sub
            End If
            If Len(Trim(txtServiceTaxPer1.Text)) = 0 Then
                MessageBox.Show("Please enter service tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtServiceTaxPer1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLuxuryTaxPer1.Text)) = 0 Then
                MessageBox.Show("Please enter luxury tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLuxuryTaxPer1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer1.Text)) = 0 Then
                MessageBox.Show("Please enter discount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDiscountPer1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid1.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid1.Focus()
                Exit Sub
            End If
            If Val(txtBalance1.Text) < 0 Then
                MessageBox.Show("Balance can not be less than zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid1.Focus()
                Exit Sub
            End If
            If (DateTimePicker3.Value.Date <> dtpDateFrom_Hall.Value.Date) And (DateTimePicker4.Value.Date <> dtpDateTo_Hall.Value.Date) And (DateTimePicker5.Value.Date <> dtpDateFrom_Garden.Value.Date) And (DateTimePicker6.Value.Date <> dtpDateTo_Garden.Value.Date) Then
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct2 As String = "SELECT * FROM Reservation_HallorGarden WHERE DateFrom < #" & dtpDateTo_Hall.Value.Date & "# AND DateTo > #" & dtpDateFrom_Hall.Value.Date & "# "
                cmd = New OleDbCommand(ct2)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Hall is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If


                con = New OleDbConnection(cs)
                con.Open()
                Dim ct3 As String = "SELECT * FROM Reservation_HallorGarden WHERE DateFrom < #" & dtpDateTo_Garden.Value.Date & "# AND DateTo > #" & dtpDateFrom_Garden.Value.Date & "# "
                cmd = New OleDbCommand(ct3)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Garden is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If

                con = New OleDbConnection(cs)
                con.Open()
                Dim ct As String = "SELECT * FROM Reservation_HallandGarden WHERE DateFrom_Hall < #" & dtpDateTo_Hall.Value.Date & "# AND DateTo_Hall > #" & dtpDateFrom_Hall.Value.Date & "# "
                cmd = New OleDbCommand(ct)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Hall is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct1 As String = "SELECT * FROM Reservation_HallandGarden WHERE DateFrom_Garden < #" & dtpDateTo_Garden.Value.Date & "# AND DateTo_Garden > #" & dtpDateFrom_Garden.Value.Date & "# "
                cmd = New OleDbCommand(ct1)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Garden is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "update Reservation_HallandGarden set GuestID='" & txtGuestID1.Text & "',DateFrom_hall=#" & dtpDateFrom_Hall.Value.Date & "#,DateTo_hall= #" & dtpDateTo_Hall.Value.Date & "#,Days_Hall= " & txtDaysHall.Text & ",Rate_Hall=" & txtRateHall.Text & ",TotalCharges_hall=" & txtTotalHall.Text & ",DateFrom_Garden = #" & dtpDateFrom_Garden.Value.Date & "#,DateTo_Garden=#" & dtpDateTo_Garden.Value.Date & "#,Days_Garden=" & txtDaysGarden.Text & ",Rate_Garden=" & txtRateGarden.Text & ",TotalCharges_Garden=" & txtTotalGarden.Text & ",OtherCharges=" & txtOtherCharges1.Text & ",SubTotal=" & txtSubTotal1.Text & ",ServiceTaxPer=" & txtServiceTaxPer1.Text & ",ServiceTaxAmount=" & txtServiceTaxAmount1.Text & ",LuxuryTaxPer=" & txtLuxuryTaxPer1.Text & ",LuxuryTaxAmount=" & txtLuxuryTaxAmount1.Text & ",DiscountPer=" & txtDiscountPer1.Text & ",Discount=" & txtDiscount1.Text & " ,GrandTotal=" & txtGrandTotal1.Text & ",TotalPaid=" & txtTotalPaid1.Text & ",Balance=" & txtBalance1.Text & ",Notes='" & txtNotes1.Text & "',CurrencyID=" & txtCurrencyID.Text & " where ID= '" & txtID2.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb1 As String = "Update Tax_ReservationHallandGarden set HEduTax=" & txtHEduCessTax.Text & ",HEduTaxAmount=" & txtHEducessTaxAmount.Text & ",EducationalTax=" & txtEducessTax.Text & ",EducationalTaxAmount=" & txtEducessTaxAmount.Text & " where ReservationID='" & txtID2.Text & "'"
            cmd = New OleDbCommand(cb1)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            btnUpdate1.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtOtherCharges2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherCharges2.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtServiceTaxPer2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServiceTaxPer2.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtServiceTaxPer2.Text
            Dim selectionStart = Me.txtServiceTaxPer2.SelectionStart
            Dim selectionLength = Me.txtServiceTaxPer2.SelectionLength

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

    Private Sub txtLuxuryTaxPer2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLuxuryTaxPer2.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtLuxuryTaxPer2.Text
            Dim selectionStart = Me.txtLuxuryTaxPer2.SelectionStart
            Dim selectionLength = Me.txtLuxuryTaxPer2.SelectionLength

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

    Private Sub txtDiscountPer2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountPer2.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscountPer2.Text
            Dim selectionStart = Me.txtDiscountPer2.SelectionStart
            Dim selectionLength = Me.txtDiscountPer2.SelectionLength

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

    Private Sub txtTotalPaid2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalPaid2.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnNew2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew2.Click
        Reset2()
        Reset2()
    End Sub

    Private Sub txtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged
        txtTotalCharges.Text = CInt(Val(txtNoOfDays1.Text) * Val(txtRate.Text)).ToString()
        Compute2()
    End Sub

    Private Sub txtServiceTaxPer2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceTaxPer2.TextChanged
 
        Compute2()
    End Sub

    Private Sub txtLuxuryTaxPer2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLuxuryTaxPer2.TextChanged

        Compute2()
    End Sub

    Private Sub txtDiscountPer2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPer2.TextChanged

        Compute2()
    End Sub

    Private Sub txtTotalPaid2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid2.TextChanged
        Compute2()
    End Sub

    Private Sub DateTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTo.ValueChanged
        txtNoOfDays1.Text = DateTo.Value.Date.Subtract(DateFrom.Value.Date).Days.ToString
        Compute2()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show(STR_PleaseSelectRoomNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RoomNo FROM Temp_Reservation WHERE RoomNo='" & cmbRoomNo.Text & "' AND Status='Reserved' and Temp_Reservation.DateIn < #" & dtpDateOut.Value.Date & "# AND Temp_Reservation.DateOut > #" & dtpDateIn.Value.Date & "#  union SELECT RoomNo FROM CheckIn_Room WHERE RoomNo='" & cmbRoomNo.Text & "' AND Status='Checked In' and Checkin_Room.DateIn < #" & dtpDateOut.Value & "# AND Checkin_Room.DateOut > #" & dtpDateIn.Value & "# "
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room is already reserved/booked", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Selected Room is available", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
             End If
            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptInvoice_HallandGarden() 'The report you created.
            Dim myConnection As OleDbConnection
            Dim MyCommand As New OleDbCommand()
            Dim myDA As New OleDbDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New OleDbConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "SELECT  Reservation_HallandGarden.CurrencyID, Reservation_HallandGarden.HotelID, Reservation_HallandGarden.Hall,Reservation_HallandGarden.DateFrom_Hall,Reservation_HallandGarden.DateTo_Hall, Reservation_HallandGarden.Days_Hall, Reservation_HallandGarden.Rate_Hall,Reservation_HallandGarden.TotalCharges_Hall, Reservation_HallandGarden.Garden, Reservation_HallandGarden.DateFrom_Garden, Reservation_HallandGarden.DateTo_Garden,Reservation_HallandGarden.Days_Garden, Reservation_HallandGarden.Rate_Garden, Reservation_HallandGarden.TotalCharges_Garden, Reservation_HallandGarden.OtherCharges,Reservation_HallandGarden.SubTotal, Reservation_HallandGarden.ServiceTaxPer, Reservation_HallandGarden.ServiceTaxAmount, Reservation_HallandGarden.LuxuryTaxPer,Reservation_HallandGarden.LuxuryTaxAmount, Reservation_HallandGarden.DiscountPer, Reservation_HallandGarden.Discount, Reservation_HallandGarden.GrandTotal, Reservation_HallandGarden.TotalPaid,Reservation_HallandGarden.Balance, Reservation_HallandGarden.Notes, Guest.GuestID, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.IDType, Guest.IDNumber, Guest.Notes AS Expr2, HotelInfo.HotelName, HotelInfo.Address AS Expr4, HotelInfo.ContactNo AS Expr5, HotelInfo.ContactNo1, HotelInfo.Email, HotelInfo.TIN, HotelInfo.STNo, HotelInfo.Logo, CurrencySet.CS_Currency  FROM(((Reservation_HallandGarden INNER JOIN Guest ON Reservation_HallandGarden.GuestID = Guest.GuestID) INNER JOIN HotelInfo ON Reservation_HallandGarden.HotelID = HotelInfo.ID) INNER JOIN CurrencySet ON Reservation_HallandGarden.CurrencyID = CurrencySet.ID) where Reservation_HallandGarden.ID='" & txtID2.Text & "'"
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Reservation_HallandGarden")
            myDA.Fill(myDS, "HotelInfo")
            myDA.Fill(myDS, "CurrencySet")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("variable", txtID2.Text)
            frmInvoice_HallandGarden.CrystalReportViewer1.ReportSource = rpt
            frmInvoice_HallandGarden.Show()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnGetData2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData2.Click
        frmReservationRecord_HallorGarden1.Show()
        frmReservationRecord_HallorGarden1.GetData()
    End Sub

    Private Sub btnPrint1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint1.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptInVoice_HallorGarden() 'The report you created.
            Dim myConnection As OleDbConnection
            Dim MyCommand As New OleDbCommand()
            Dim myDA As New OleDbDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New OleDbConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "SELECT  Reservation_HallorGarden.GuestID, Reservation_HallorGarden.Type, Reservation_HallorGarden.DateFrom, Reservation_HallorGarden.DateTo, Reservation_HallorGarden.Days,Reservation_HallorGarden.Rate, Reservation_HallorGarden.TotalCharges, Reservation_HallorGarden.OtherCharges, Reservation_HallorGarden.SubTotal, Reservation_HallorGarden.ServiceTaxPer,Reservation_HallorGarden.ServiceTaxAmount, Reservation_HallorGarden.LuxuryTaxPer, Reservation_HallorGarden.LuxuryTaxAmount, Reservation_HallorGarden.DiscountPer,Reservation_HallorGarden.Discount, Reservation_HallorGarden.GrandTotal, Reservation_HallorGarden.TotalPaid, Reservation_HallorGarden.Balance, Reservation_HallorGarden.Notes,Reservation_HallorGarden.CurrencyID, Reservation_HallorGarden.HotelID, CurrencySet.CS_Currency, HotelInfo.HotelName, HotelInfo.Address,HotelInfo.ContactNo, HotelInfo.ContactNo1, HotelInfo.Email, HotelInfo.TIN, HotelInfo.STNo, HotelInfo.Logo, Guest.GuestID AS Expr3, Guest.GuestName, Guest.Address AS Expr4, Guest.City,Guest.ContactNo AS Expr5, Guest.IDType, Guest.IDNumber FROM (((Reservation_HallorGarden INNER JOIN  Guest ON Reservation_HallorGarden.GuestID = Guest.GuestID) INNER JOIN HotelInfo ON Reservation_HallorGarden.HotelID = HotelInfo.ID) INNER JOIN CurrencySet ON Reservation_HallorGarden.CurrencyID = CurrencySet.ID) where  Reservation_HallorGarden.ID='" & txtID3.Text & "'"
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Reservation_HallorGarden")
            myDA.Fill(myDS, "HotelInfo")
            myDA.Fill(myDS, "CurrencySet")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("variable", txtID3.Text)
            frmInvoice_HallOrGarden.CrystalReportViewer1.ReportSource = rpt
            frmInvoice_HallOrGarden.Show()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate2.Click
        Try
            If Len(Trim(txtGuestID2.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestID2.Focus()
                Exit Sub
            End If
            If RadioButton1.Checked = False And RadioButton2.Checked = False Then
                MessageBox.Show("Please select type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Len(Trim(txtRate.Text)) = 0 Then
                MessageBox.Show("Please enter rate", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRate.Focus()
                Exit Sub
            End If
            If Len(Trim(txtOtherCharges2.Text)) = 0 Then
                MessageBox.Show("Please enter other charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtOtherCharges2.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCurrency1.Text)) = 0 Then
                MessageBox.Show("Please select currency", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCurrency1.Focus()
                Exit Sub
            End If
            If Len(Trim(txtServiceTaxPer2.Text)) = 0 Then
                MessageBox.Show("Please enter service tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtServiceTaxPer2.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLuxuryTaxPer2.Text)) = 0 Then
                MessageBox.Show("Please enter luxury tax %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLuxuryTaxPer2.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer2.Text)) = 0 Then
                MessageBox.Show("Please enter discount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDiscountPer2.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid2.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid2.Focus()
                Exit Sub
            End If
            If (DateTimePicker1.Value.Date <> DateFrom.Value.Date) And (DateTimePicker2.Value.Date <> DateTo.Value.Date) Then
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct As String = "SELECT * FROM Reservation_HallandGarden WHERE DateFrom_Hall < #" & DateTo.Value.Date & "# AND DateTo_Hall > #" & DateFrom.Value.Date & "# "
                cmd = New OleDbCommand(ct)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Hall is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct1 As String = "SELECT * FROM Reservation_HallandGarden WHERE DateFrom_Garden < #" & DateTo.Value.Date & "# AND DateTo_Garden > #" & DateFrom.Value.Date & "# "
                cmd = New OleDbCommand(ct1)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Garden is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
                If RadioButton1.Checked = True Then
                    con = New OleDbConnection(cs)
                    con.Open()
                    Dim ct2 As String = "SELECT * FROM Reservation_HallorGarden WHERE DateFrom < #" & DateTo.Value.Date & "# AND DateTo > #" & DateFrom.Value.Date & "# "
                    cmd = New OleDbCommand(ct2)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read Then
                        MessageBox.Show("Hall is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                        Exit Sub
                    End If
                End If
                If RadioButton2.Checked = True Then
                    con = New OleDbConnection(cs)
                    con.Open()
                    Dim ct3 As String = "SELECT * FROM Reservation_HallorGarden WHERE DateFrom < #" & DateTo.Value.Date & "# AND DateTo > #" & DateFrom.Value.Date & "# "
                    cmd = New OleDbCommand(ct3)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read Then
                        MessageBox.Show("Garden is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        If Not rdr Is Nothing Then
                            rdr.Close()
                        End If
                        Exit Sub
                    End If
                End If
            End If
            If RadioButton1.Checked Then
                type = RadioButton1.Text
            ElseIf RadioButton2.Checked Then
                type = RadioButton2.Text
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "update Reservation_HallorGarden set GuestID='" & txtGuestID2.Text & "',Type='" & type & "',DateFrom=#" & DateFrom.Value.Date & "#,DateTo=#" & DateTo.Value.Date & "#,Days=" & txtNoOfDays1.Text & ",Rate=" & txtRate.Text & ",TotalCharges=" & txtTotalCharges.Text & ",OtherCharges=" & txtOtherCharges2.Text & ",SubTotal=" & txtSubTotal2.Text & ",ServiceTaxPer=" & txtServiceTaxPer2.Text & ",ServiceTaxAmount=" & txtServiceTaxAmount2.Text & ",LuxuryTaxPer=" & txtLuxuryTaxPer2.Text & ",LuxuryTaxAmount=" & txtLuxuryTaxAmount2.Text & ",DiscountPer=" & txtDiscountPer2.Text & ",Discount=" & txtDiscount2.Text & " ,GrandTotal=" & txtGrandTotal2.Text & ",TotalPaid=" & txtTotalPaid2.Text & ",Balance=" & txtBalance2.Text & ",Notes='" & txtNotes2.Text & "',CurrencyID= '" & txtCurrencyID.Text & "' where ID='" & txtID3.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb1 As String = "Update Tax_ReservationHallorGarden set HEduTax=" & txtHeducessTax1.Text & ",HEduTaxAmount=" & txtHeducessTaxAmount1.Text & ",EducationalTax=" & txteducessTax1.Text & ",EducationalTaxAmount=" & txteducessTaxAmount1.Text & " where ReservationID='" & txtID3.Text & "'"
            cmd = New OleDbCommand(cb1)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            btnUpdate2.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTotalPaid2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalPaid2.Validating
        If Val(txtTotalPaid2.Text) > Val(txtGrandTotal2.Text) Then
            MessageBox.Show(STR_TotalPaidCanNotBeMoreThanGrandTotal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid2.Text = ""
            txtTotalPaid2.Focus()
        End If
    End Sub

    Private Sub txtTotalPaid1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalPaid1.Validating
        If Val(txtTotalPaid1.Text) > Val(txtGrandTotal1.Text) Then
            MessageBox.Show(STR_TotalPaidCanNotBeMoreThanGrandTotal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid1.Text = ""
            txtTotalPaid1.Focus()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Try
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct As String = "select Charges from ExtraBed"
                cmd = New OleDbCommand(ct)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    txtOtherCharges.Text = Val(txtOtherCharges.Text) + Val(rdr.GetValue(0))
                End If
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        If CheckBox1.Checked = False Then
            Try
                con = New OleDbConnection(cs)
                con.Open()
                Dim ct As String = "select Charges from ExtraBed"
                cmd = New OleDbCommand(ct)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    txtOtherCharges.Text = Val(txtOtherCharges.Text) - Val(rdr.GetValue(0))
                End If
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        Compute()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckedIN.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show(STR_PleaseSelectRoomNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbRoomNo.Focus()
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
            If CheckBox1.Checked = True Then
                ExtraBedStatus = "Yes"
            End If
            If CheckBox1.Checked = False Then
                ExtraBedStatus = "No"
            End If
            dtpDateIn.Text = Convert.ToDateTime(dtpDateIn.Value)
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "insert into CheckIN_Room( GuestID, RoomNo, RoomCharges, DateIN, DateOUT, NoOfAdults, NoOfKids, NoOfDays, TotalRoomCharges, OtherCharges, SubTotal, ServiceTaxPer,ServiceTaxAmount, LuxuryTaxPer, LuxuryTaxAmount,DiscountPer, Discount, GrandTotal, TotalPaid, Balance,Status, Notes,ExtraBed) VALUES ('" & txtGuestID.Text & "','" & cmbRoomNo.Text & "'," & txtRoomCharges.Text & ",#" & dtpDateIn.Value & "#,#" & dtpDateOut.Value & "#," & txtNoOfAdults.Text & "," & txtNoOfKids.Text & "," & txtNoOfDays.Text & "," & txtTotalRoomCharges.Text & "," & txtOtherCharges.Text & "," & txtSubTotal.Text & "," & txtServiceTaxPer.Text & "," & txtServiceTaxAmount.Text & "," & txtLuxuryTaxPer.Text & "," & txtLuxuryTaxAmount.Text & "," & txtDiscountPer.Text & "," & txtDiscount.Text & " ," & txtGrandTotal.Text & "," & txtTotalPaid.Text & "," & txtBalance.Text & ",'Checked In','" & txtNotes.Text & "','" & ExtraBedStatus & "')"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb2 As String = "delete from Temp_Reservation where ReservationID='" & txtReservationNo.Text & "'"
            cmd = New OleDbCommand(cb2)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            btnCheckedIN.Enabled = False
            MessageBox.Show("Successfully Checked in", "Guest", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub dtpDateFrom_Hall_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateFrom_Hall.Validating
        If (dtpDateFrom_Hall.Value.Date < Today) Then
            MessageBox.Show("Reservation is not possible" & vbCrLf & "Selected IN date for hall is less than today's date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateFrom_Hall.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub dtpDateFrom_Garden_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateFrom_Garden.Validating

        If (dtpDateFrom_Garden.Value.Date < Today) Then
            MessageBox.Show("Reservation is not possible" & vbCrLf & "Selected IN date for garden is less than today's date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateFrom_Garden.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub DateFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateFrom.Validating
        If (DateFrom.Value.Date < Today) Then
            MessageBox.Show("Reservation is not possible" & vbCrLf & "Selected IN date is less than today's date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateFrom.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub DateTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTo.Validating
        If (DateTo.Value.Date < Today) Then
            MessageBox.Show("Reservation is not possible" & vbCrLf & "Selected OUT is less than today's date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTo.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Try
                con = New OleDbConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT Charges FROM Hall"
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtRate.Text = rdr.GetValue(0)
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
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            Try
                con = New OleDbConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = STR_SELECTChargesFROMGarden
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtRate.Text = rdr.GetValue(0)
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
        End If
    End Sub

    Private Sub txtOtherCharges2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherCharges2.TextChanged
        Compute2()
    End Sub

    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        Reset1()
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


    Private Sub cmbCurrency1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCurrency1.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ID FROM CurrencySet where CS_Currency='" & cmbCurrency1.Text & "'"
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

    Private Sub cmbCurrency2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCurrency2.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ID FROM CurrencySet where CS_Currency='" & cmbCurrency2.Text & "'"
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


    Private Sub guestRecordG_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles guestRecordG.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = guestRecordG.SelectedRows(0)
           
            Me.txtGuestID.Text = dr.Cells(0).Value.ToString()
            Me.txtGuestName.Text = dr.Cells(1).Value.ToString()
            Me.txtGuestAddress.Text = dr.Cells(2).Value.ToString()
            Me.txtGuestCity.Text = dr.Cells(3).Value.ToString()
            Me.txtGuestContactNo.Text = dr.Cells(4).Value.ToString()
            Me.txtIDType.Text = dr.Cells(5).Value.ToString()
            Me.txtIDNumber.Text = dr.Cells(6).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub guestyonisearch_TextChanged(sender As Object, e As EventArgs) Handles guestyonisearch.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT (GuestID)as [Guest ID],(Guestname) as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],Notes from Guest where GuestName like '" + guestyonisearch.Text + "%' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            guestRecordG.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GroupControl3_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl3.Paint

    End Sub

    Private Sub reservationGR_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles reservationGR.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = reservationGR.SelectedRows(0)
         
            Me.txtReservationNo.Text = dr.Cells(0).Value.ToString()
            Me.txtGuestID.Text = dr.Cells(1).Value.ToString()
            Me.txtGuestName.Text = dr.Cells(2).Value.ToString()
            Me.txtGuestAddress.Text = dr.Cells(3).Value.ToString()
            Me.txtGuestCity.Text = dr.Cells(4).Value.ToString()
            Me.txtGuestContactNo.Text = dr.Cells(5).Value.ToString()
            Me.txtIDType.Text = dr.Cells(6).Value.ToString()
            Me.txtIDNumber.Text = dr.Cells(7).Value.ToString()
            Me.cmbRoomNo.Text = dr.Cells(8).Value.ToString()
            Me.txtRoomCharges.Text = dr.Cells(9).Value.ToString()
            Me.dtpDateIn.Text = dr.Cells(10).Value.ToString()
            Me.dtpDateOut.Text = dr.Cells(11).Value.ToString()
            Me.btnCheckedIN.Enabled = True
            Me.btnSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Searchreserved_TextChanged(sender As Object, e As EventArgs) Handles Searchreserved.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT ReservationID as [Reservation No],Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number], Room.RoomNo as [Room No],RoomCharges as [Room Charges], DateIN as [Date IN], DateOUT as [Date OUT], Status, Temp_Reservation.Notes as [Notes] from Guest,Temp_Reservation,Room where Guest.GuestID=Temp_Reservation.GuestID and Room.RoomNo=Temp_Reservation.RoomNo and Status='Reserved' and GuestName like '" & Searchreserved.Text & "%' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Room")
            myDA.Fill(myDataSet, "Temp_Reservation")
            reservationGR.DataSource = myDataSet.Tables("Guest").DefaultView
            reservationGR.DataSource = myDataSet.Tables("Room").DefaultView
            reservationGR.DataSource = myDataSet.Tables("Temp_Reservation").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

   

    
    Private Sub guestR_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles guestR.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = guestR.SelectedRows(0)
            Me.Hide()
            Me.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            Me.txtGuestID1.Text = dr.Cells(0).Value.ToString()
            Me.txtGuestName1.Text = dr.Cells(1).Value.ToString()
            Me.txtGuestAddress1.Text = dr.Cells(2).Value.ToString()
            Me.txtCity1.Text = dr.Cells(3).Value.ToString()
            Me.txtContactNo1.Text = dr.Cells(4).Value.ToString()
            Me.txtIDType1.Text = dr.Cells(5).Value.ToString()
            Me.txtIDNumber1.Text = dr.Cells(6).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub guestnameyoni_TextChanged(sender As Object, e As EventArgs) Handles guestnameyoni.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT (GuestID)as [Guest ID],(Guestname) as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],Notes from Guest where GuestName like '" + guestnameyoni.Text + "%' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            guestR.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Close()
    End Sub

    Private Sub hallandgarden_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles hallandgarden.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = hallandgarden.SelectedRows(0)
          
            Me.txtID2.Text = dr.Cells(0).Value.ToString()
            Me.txtGuestID1.Text = dr.Cells(1).Value.ToString()
            Me.txtGuestName1.Text = dr.Cells(2).Value.ToString()
            Me.txtGuestAddress1.Text = dr.Cells(3).Value.ToString()
            Me.txtCity1.Text = dr.Cells(4).Value.ToString()
            Me.txtContactNo1.Text = dr.Cells(5).Value.ToString()
            Me.txtIDType1.Text = dr.Cells(6).Value.ToString()
            Me.txtIDNumber1.Text = dr.Cells(7).Value.ToString()
            Me.dtpDateFrom_Hall.Text = dr.Cells(8).Value.ToString()
            Me.dtpDateTo_Hall.Text = dr.Cells(9).Value.ToString()
            Me.DateTimePicker3.Text = dr.Cells(8).Value.ToString()
            Me.DateTimePicker4.Text = dr.Cells(9).Value.ToString()
            Me.txtDaysHall.Text = dr.Cells(10).Value.ToString()
            Me.txtRateHall.Text = dr.Cells(11).Value.ToString()
            Me.txtTotalHall.Text = dr.Cells(12).Value.ToString()
            Me.dtpDateFrom_Garden.Text = dr.Cells(13).Value.ToString()
            Me.dtpDateTo_Garden.Text = dr.Cells(14).Value.ToString()
            Me.DateTimePicker5.Text = dr.Cells(13).Value.ToString()
            Me.DateTimePicker6.Text = dr.Cells(14).Value.ToString()
            Me.txtDaysGarden.Text = dr.Cells(15).Value.ToString()
            Me.txtRateGarden.Text = dr.Cells(16).Value.ToString()
            Me.txtTotalGarden.Text = dr.Cells(17).Value.ToString()
            Me.txtOtherCharges1.Text = dr.Cells(18).Value.ToString()
            Me.txtSubTotal1.Text = dr.Cells(19).Value.ToString()
            Me.txtServiceTaxPer1.Text = dr.Cells(20).Value.ToString()
            Me.txtServiceTaxAmount1.Text = dr.Cells(21).Value.ToString()
            Me.txtLuxuryTaxPer1.Text = dr.Cells(22).Value.ToString()
            Me.txtLuxuryTaxAmount1.Text = dr.Cells(23).Value.ToString()
            Me.txtDiscountPer1.Text = dr.Cells(24).Value.ToString()
            Me.txtDiscount1.Text = dr.Cells(25).Value.ToString()
            Me.txtGrandTotal1.Text = dr.Cells(26).Value.ToString()
            Me.txtTotalPaid1.Text = dr.Cells(27).Value.ToString()
            Me.txtBalance1.Text = dr.Cells(28).Value.ToString()
            Me.txtCurrencyID.Text = dr.Cells(29).Value.ToString()
            Me.cmbCurrency.Text = dr.Cells(30).Value.ToString()
            Me.txtNotes1.Text = dr.Cells(31).Value.ToString()
            Me.Compute1()
            Me.btnUpdate1.Enabled = True
            Me.btnDelete1.Enabled = True
            Me.btnSave1.Enabled = False
            Me.btnPrint.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub hallsearch_TextChanged(sender As Object, e As EventArgs) Handles hallsearch.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Reservation_HallandGarden.ID as [Reservation ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],DateFrom_Hall as [Hall Date From], DateTo_Hall as [Hall Date To], Days_Hall as [Hall Days], Rate_Hall as [Hall Rate],TotalCharges_Hall as [Hall Total Charges],DateFrom_Garden as [Garden Date From], DateTo_Garden as [Garden Date To,], Days_Garden as [Garden Days], Rate_Garden as [Garden Rate],TotalCharges_Garden as [Garden Total Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],CS_Currency as [Currency], Reservation_HallandGarden.Notes from Guest,Reservation_HallandGarden,CurrencySet where Guest.GuestID=Reservation_HallandGarden.GuestID and CurrencySet.ID=Reservation_HallandGarden.CurrencyID  and Guestname like  '" & hallsearch.Text & "%'  order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Reservation_HallandGarden")
            hallandgarden.DataSource = myDataSet.Tables("Guest").DefaultView
            hallandgarden.DataSource = myDataSet.Tables("Reservation_HallandGarden").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub guestrr_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles guestrr.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = guestrr.SelectedRows(0)

            Me.txtGuestID2.Text = dr.Cells(0).Value.ToString()
            Me.txtGuestName2.Text = dr.Cells(1).Value.ToString()
            Me.txtGuestAddress2.Text = dr.Cells(2).Value.ToString()
            Me.txtGuestCity2.Text = dr.Cells(3).Value.ToString()
            Me.txtGuestContactNo2.Text = dr.Cells(4).Value.ToString()
            Me.txtIDType2.Text = dr.Cells(5).Value.ToString()
            Me.txtIDNumber2.Text = dr.Cells(6).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub guests_Textchanged(sender As Object, e As EventArgs) Handles guests.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT (GuestID)as [Guest ID],(Guestname) as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],Notes from Guest where GuestName like '" + guests.Text + "%' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            guestrr.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub hallorgarden_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles hallorgarden.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = hallorgarden.SelectedRows(0)
           
            Me.txtID3.Text = dr.Cells(0).Value.ToString()
            Me.txtGuestID2.Text = dr.Cells(1).Value.ToString()
            Me.txtGuestName2.Text = dr.Cells(2).Value.ToString()
            Me.txtGuestAddress2.Text = dr.Cells(3).Value.ToString()
            Me.txtGuestCity2.Text = dr.Cells(4).Value.ToString()
            Me.txtGuestContactNo2.Text = dr.Cells(5).Value.ToString()
            Me.txtIDType2.Text = dr.Cells(6).Value.ToString()
            Me.txtIDNumber2.Text = dr.Cells(7).Value.ToString()
            Me.type = dr.Cells(8).Value.ToString()
            If (dr.Cells(8).Value.ToString() = "Hall") Then
                Me.RadioButton1.Checked = True
            Else
                Me.RadioButton2.Checked = True
            End If
            Me.DateFrom.Text = dr.Cells(9).Value.ToString()
            Me.DateTo.Text = dr.Cells(10).Value.ToString()
            Me.DateTimePicker1.Text = dr.Cells(9).Value.ToString()
            Me.DateTimePicker2.Text = dr.Cells(10).Value.ToString()
            Me.txtNoOfDays1.Text = dr.Cells(11).Value.ToString()
            Me.txtRate.Text = dr.Cells(12).Value.ToString()
            Me.txtTotalCharges.Text = dr.Cells(13).Value.ToString()
            Me.txtOtherCharges2.Text = dr.Cells(14).Value.ToString()
            Me.txtSubTotal2.Text = dr.Cells(15).Value.ToString()
            Me.txtServiceTaxPer2.Text = dr.Cells(16).Value.ToString()
            Me.txtServiceTaxAmount2.Text = dr.Cells(17).Value.ToString()
            Me.txtLuxuryTaxPer2.Text = dr.Cells(18).Value.ToString()
            Me.txtLuxuryTaxAmount2.Text = dr.Cells(19).Value.ToString()
            Me.txtDiscountPer2.Text = dr.Cells(20).Value.ToString()
            Me.txtDiscount2.Text = dr.Cells(21).Value.ToString()
            Me.txtGrandTotal2.Text = dr.Cells(22).Value.ToString()
            Me.txtTotalPaid2.Text = dr.Cells(23).Value.ToString()
            Me.txtBalance2.Text = dr.Cells(24).Value.ToString()
            Me.txtCurrencyID.Text = dr.Cells(25).Value.ToString()
            Me.cmbCurrency1.Text = dr.Cells(26).Value.ToString()
            Me.txtNotes2.Text = dr.Cells(27).Value.ToString()
            Me.Compute2()
            Me.btnUpdate2.Enabled = True
            Me.btnDelete2.Enabled = True
            Me.btnSave2.Enabled = False
            Me.btnPrint1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub searchallorgarden_TextChanged(sender As Object, e As EventArgs) Handles searchallorgarden.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT Reservation_HallorGarden.ID as [Reservation ID], Guest.GuestID as [Guest ID],GuestName as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],Type as [Type],DateFrom as [Date From], DateTo as [Date To], Days as [No Of Days], Rate,TotalCharges as [Total Charges], OtherCharges as [Other Charges], SubTotal as [Sub Total], ServiceTaxPer as [Service Tax %],ServiceTaxAmount as [Service Tax Amount], LuxuryTaxPer as [Luxury Tax %], LuxuryTaxAmount as [Luxury Tax Amount],DiscountPer as [Discount %], Discount, GrandTotal, TotalPaid as [Total Paid], Balance,CurrencySet.ID as [Currency ID],Cs_Currency as [Currency], Reservation_HallorGarden.Notes from Guest,Reservation_HallorGarden,CurrencySet where Guest.GuestID=Reservation_HallorGarden.GuestID and Reservation_HallorGarden.CurrencyID=CurrencySet.ID  and Guestname like '" & searchallorgarden.Text & "%'  order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            myDA.Fill(myDataSet, "Reservation_HallorGarden")
            hallorgarden.DataSource = myDataSet.Tables("Guest").DefaultView
            hallorgarden.DataSource = myDataSet.Tables("Reservation_HallorGarden").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Close()
    End Sub
End Class
