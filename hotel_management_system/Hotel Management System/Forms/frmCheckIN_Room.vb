Imports System.Data.SqlClient
Public Class frmCheckIN_Room
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12 As Double
    Dim st1 As String
    Sub Compute()
        Try
            If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                txtNoOfDays.Text = 1
            Else
                txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
            End If
            num8 = CDbl(Val(txtNoOfExtraBed.Text) * Val(txtExtraBedC.Text))
            num8 = Math.Round(num8, 2)
            txtExtraBedCharges.Text = num8
            num9 = CDbl(Val(txtNoOfExtraPerson.Text) * Val(txtExtraPersonC.Text))
            num9 = Math.Round(num9, 2)
            txtExtraPersonCharges.Text = num9
            num1 = CDbl(Val(txtRoomCharges.Text) * Val(txtNoOfDays.Text))
            num1 = Math.Round(num1, 2)
            txtTotalRoomCharges.Text = num1
            num2 = CDbl(((Val(txtTotalRoomCharges.Text) + Val(txtLaundryCharges.Text) + Val(txtExtraBedCharges.Text) + Val(txtExtraPersonCharges.Text)) * Val(txtDiscountPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount.Text = num2
            num3 = CDbl((Val(txtTotalRoomCharges.Text) + Val(txtLaundryCharges.Text) + Val(txtExtraBedCharges.Text) + Val(txtExtraPersonCharges.Text)) - Val(txtDiscountAmount.Text))
            num3 = Math.Round(num3, 2)
            TextBox2.Text = num3
            num4 = CDbl((Val(TextBox2.Text) * Val(txtServiceTaxPer.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtServiceTaxAmount.Text = num4
            num5 = CDbl(((Val(TextBox2.Text) + Val(txtServiceTaxAmount.Text)) * Val(txtLuxuryTaxPer.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtLuxuryTaxAmount.Text = num5
            num10 = CDbl(Val(TextBox2.Text) + Val(txtRoomOrderCharges.Text))
            num10 = Math.Round(num10, 2)
            txtSubTotal.Text = num10
            num6 = CDbl(Val(txtSubTotal.Text) + Val(txtServiceTaxAmount.Text) + Val(txtLuxuryTaxAmount.Text))
            num6 = Math.Round(num6, 2)
            txtGrandTotal.Text = num6
            num7 = CDbl(Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text))
            num7 = Math.Round(num7, 2)
            txtBalance.Text = num7
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Compute1()
        Try
            If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                txtNoOfDays.Text = 1
            Else
                txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
            End If
            num8 = CDbl(Val(txtNoOfExtraBed.Text) * Val(txtExtraBedC.Text))
            num8 = Math.Round(num8, 2)
            txtExtraBedCharges.Text = num8
            num9 = CDbl(Val(txtNoOfExtraPerson.Text) * Val(txtExtraPersonC.Text))
            num9 = Math.Round(num9, 2)
            txtExtraPersonCharges.Text = num9
            num1 = CDbl(Val(txtRoomCharges.Text) * Val(txtNoOfDays.Text))
            num1 = Math.Round(num1, 2)
            txtTotalRoomCharges.Text = num1
            num2 = CDbl(((Val(txtTotalRoomCharges.Text) + Val(txtLaundryCharges.Text) + Val(txtExtraBedCharges.Text) + Val(txtExtraPersonCharges.Text)) * Val(txtDiscountPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount.Text = num2
            num3 = CDbl((Val(txtTotalRoomCharges.Text) + Val(txtLaundryCharges.Text) + Val(txtExtraBedCharges.Text) + Val(txtExtraPersonCharges.Text)) - Val(txtDiscountAmount.Text))
            num3 = Math.Round(num3, 2)
            TextBox3.Text = num3
            num4 = CDbl((Val(TextBox3.Text) * Val(txtServiceTaxPer.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtServiceTaxAmount.Text = num4
            num5 = CDbl(((Val(TextBox3.Text) + Val(txtServiceTaxAmount.Text)) * Val(txtLuxuryTaxPer.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtLuxuryTaxAmount.Text = num5
            num6 = CDbl(Val(TextBox3.Text) - Val(txtServiceTaxAmount.Text) - Val(txtLuxuryTaxAmount.Text))
            num6 = Math.Round(num6, 2)
            TextBox1.Text = num6
            num10 = CDbl((Val(TextBox1.Text) * Val(txtServiceTaxPer.Text)) / 100)
            num10 = Math.Round(num10, 2)
            txtServiceTaxAmount.Text = num10
            num11 = CDbl(((Val(TextBox1.Text) + Val(txtServiceTaxAmount.Text)) * Val(txtLuxuryTaxPer.Text)) / 100)
            num11 = Math.Round(num11, 2)
            txtLuxuryTaxAmount.Text = num11
            num12 = CDbl(Val(TextBox1.Text) + Val(txtRoomOrderCharges.Text))
            num12 = Math.Round(num12, 2)
            txtSubTotal.Text = num12
            num6 = CDbl(Val(txtSubTotal.Text) + Val(txtServiceTaxAmount.Text) + Val(txtLuxuryTaxAmount.Text))
            num6 = Math.Round(num6, 2)
            txtGrandTotal.Text = num6
            num7 = CDbl(Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text))
            num7 = Math.Round(num7, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        txtGender.Text = ""
        CheckBox1.Checked = False
        txtExtraBedCharges.Text = ""
        txtExtraPersonCharges.Text = ""
        txtReligion.Text = ""
        txtOccupation.Text = ""
        txtGuestID.Text = ""
        txtGuestName.Text = ""
        txtGuestAddress.Text = ""
        txtGuestCity.Text = ""
        txtGuestContactNo.Text = ""
        txtIDType.Text = ""
        txtLaundryCharges.Text = ""
        txtIDNumber.Text = ""
        txtNotes.Text = ""
        cmbRoomNo.Text = ""
        txtRoomCharges.Text = ""
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today
        txtNoOfMales.Text = 0
        txtNoOfFemales.Text = 0
        txtRoomOrderCharges.Text = 0
        txtLaundryCharges.Text = 0
        txtNoOfKids.Text = 0
        txtNoOfExtraBed.Text = 0
        txtNoOfExtraPerson.Text = 0
        txtNoOfDays.Text = ""
        txtTotalRoomCharges.Text = ""
        txtExtraBedCharges.Text = ""
        txtSubTotal.Text = ""
        txtLuxuryTaxPer.Text = ""
        txtServiceTaxAmount.Text = ""
        txtServiceTaxPer.Text = ""
        txtLuxuryTaxAmount.Text = ""
        txtDiscountPer.Text = ""
        txtDiscountAmount.Text = ""
        txtGrandTotal.Text = ""
        txtTotalPaid.Text = ""
        txtBalance.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCheckedIN.Enabled = False
        dtpDateIn.Enabled = True
        dtpDateOut.Enabled = True
        cmbRoomNo.Enabled = True
        btnRoomAvailability.Enabled = True
        FillData()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        frmGuestRecord1.lblSet.Text = "Check In"
        frmGuestRecord1.Reset()
        frmGuestRecord1.Show()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
        frmMainMenu.Reset()
        frmMainMenu.Show()
    End Sub

    Private Sub hsExtraBed_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsExtraBed.ValueChanged
        If Len(Trim(cmbRoomNo.Text)) = 0 Then
            MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRoomNo.Focus()
            Exit Sub
        End If
        txtNoOfExtraBed.Text = hsExtraBed.Value.ToString
        FillExtraBed()
        If CheckBox1.Checked = False Then
            Compute()
        End If
        If CheckBox1.Checked = True Then
            Compute1()
        End If
    End Sub

    Private Sub hsExtraPerson_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsExtraPerson.ValueChanged
        If Len(Trim(cmbRoomNo.Text)) = 0 Then
            MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRoomNo.Focus()
            Exit Sub
        End If
        txtNoOfExtraPerson.Text = hsExtraPerson.Value.ToString
        FillExtraPerson()
        If CheckBox1.Checked = False Then
            Compute()
        End If
        If CheckBox1.Checked = True Then
            Compute1()
        End If
    End Sub

    Private Sub hsFemales_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsFemales.ValueChanged
        txtNoOfFemales.Text = hsFemales.Value.ToString
    End Sub

    Private Sub hsKids_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsKids.ValueChanged
        txtNoOfKids.Text = hsKids.Value.ToString
    End Sub

    Private Sub hsNoOfMales_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsMales.ValueChanged
        txtNoOfMales.Text = hsMales.Value.ToString
    End Sub

    Private Sub dtpDateOut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOut.ValueChanged
        Try
            If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                txtNoOfDays.Text = 1
            Else
                txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
            End If
            txtTotalRoomCharges.Text = CInt(Val(txtRoomCharges.Text) * Val(txtNoOfDays.Text)).ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Compute()
    End Sub

    Private Sub dtpDateOut_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateOut.Validating

        Try
            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If

            If dtpDateOut.Value.Date < dtpDateIn.Value.Date Then
                MessageBox.Show("Selected date out must be greater than date in", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpDateOut.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub fillRoomNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RoomNo) FROM Room", CN)
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
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(Cin_ID) FROM CheckIn_Room")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtCheckInID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtCheckInID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Private Sub frmCheckIN_Room_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillRoomNo()
        FillData()
    End Sub
    Sub Fill()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RoomCharges,RoomType FROM Room WHERE RoomNo=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRoomCharges.Text = rdr.GetValue(0)
                txtRoomType.Text = rdr.GetString(1)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            FillData()
            FillExtraBed()
            FillExtraPerson()
            If CheckBox1.Checked = False Then
                Compute()
            End If
            If CheckBox1.Checked = True Then
                Compute1()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub cmbRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Fill()
    End Sub
    Sub FillData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ServiceTax,LuxuryTax,Discount FROM Tax WHERE Type='Room'"
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtServiceTaxPer.Text = rdr.GetValue(0)
                txtLuxuryTaxPer.Text = rdr.GetValue(1)
                txtDiscountPer.Text = rdr.GetValue(2)
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
    Sub FillExtraBed()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Charges FROM ExtraBed where RoomType=@d1"
            cmd.Parameters.AddWithValue("@d1", txtRoomType.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtExtraBedC.Text = rdr.GetValue(0)
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
    Sub FillExtraPerson()
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Charges FROM ExtraPerson where RoomType=@d1"
            cmd.Parameters.AddWithValue("@d1", txtRoomType.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtExtraPersonC.Text = rdr.GetValue(0)
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
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub txtDiscountPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPer.TextChanged
        If CheckBox1.Checked = False Then
            Compute()
        End If
        If CheckBox1.Checked = True Then
            Compute1()
        End If
    End Sub

    Private Sub txtServiceTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceTaxPer.TextChanged
        If CheckBox1.Checked = False Then
            Compute()
        End If
        If CheckBox1.Checked = True Then
            Compute1()
        End If
    End Sub

    Private Sub txtLuxuryTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLuxuryTaxPer.TextChanged
        If CheckBox1.Checked = False Then
            Compute()
        End If
        If CheckBox1.Checked = True Then
            Compute1()
        End If
    End Sub

    Private Sub txtGrandTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrandTotal.TextChanged
        If CheckBox1.Checked = False Then
            Compute()
        End If
        If CheckBox1.Checked = True Then
            Compute1()
        End If
    End Sub

    Private Sub txtGrandTotal_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtGrandTotal.Validating
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Text = ""
            txtTotalPaid.Focus()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            Compute()
        End If
        If CheckBox1.Checked = True Then
            Compute1()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If Len(Trim(txtServiceTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter service tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtServiceTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLuxuryTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter luxury tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLuxuryTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer.Text)) = 0 Then
                MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtBalance.Text) < 0 Then
                MessageBox.Show("Balance can not be less than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Text = ""
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RoomNo FROM Temp_Reservation WHERE RoomNo=@d3 AND Status='Reserved' and Temp_Reservation.DateIn < @d1 AND Temp_Reservation.DateOut > @d2 "
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d3", cmbRoomNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "SELECT RoomNo FROM CheckIn_Room WHERE RoomNo=@d3 AND Status='Check In' and Checkin_Room.DateIn < @d1 AND Checkin_Room.DateOut > @d2"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.AddWithValue("@d1", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d3", cmbRoomNo.Text)
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
                st1 = "Yes"
            End If
            If CheckBox1.Checked = False Then
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into CheckIN_Room(Cin_ID, GuestID, RoomNo, RoomCharges, DateIN, DateOUT, NoOfDays, NoOfMales, NoOfFemales, NoOfKids, NoOfExtraBed, NoOfExtraPerson, RoomOrderCharges, ExtraPersonCharges, TotalRoomCharges,ExtraBedCharges, OtherCharges, DiscountPer, DiscountAmount, STPer, STAmount, LuxuryTaxPer, LuxuryTaxAmount, SubTotal, GrandTotal, TotalPaid, Balance, Status, TaxPaidRate, Notes) VALUES (" & txtCheckInID.Text & "," & txtID.Text & ",@d1," & txtRoomCharges.Text & ",@d3,@d4," & txtNoOfDays.Text & "," & txtNoOfMales.Text & "," & txtNoOfFemales.Text & "," & txtNoOfKids.Text & "," & txtNoOfExtraBed.Text & "," & txtNoOfExtraPerson.Text & "," & txtRoomOrderCharges.Text & "," & txtExtraPersonCharges.Text & "," & txtTotalRoomCharges.Text & "," & txtExtraBedCharges.Text & "," & txtLaundryCharges.Text & "," & txtDiscountPer.Text & "," & txtDiscountAmount.Text & "," & txtServiceTaxPer.Text & "," & txtServiceTaxAmount.Text & "," & txtLuxuryTaxPer.Text & "," & txtLuxuryTaxAmount.Text & "," & txtSubTotal.Text & "," & txtGrandTotal.Text & "," & txtTotalPaid.Text & "," & txtBalance.Text & ",'Check In','" & st1 & "',@d2)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d4", dtpDateOut.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Check In guest '" & txtGuestName.Text & "' with Check In ID='" & txtCheckInID.Text & "'"
            LogFunc(lblUser.Text, st)
            btnSave.Enabled = False
            MessageBox.Show("Successfully Check In", "Guest", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmReservationRecord2.Show()
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
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from CheckIN_Room where Cin_ID=" & txtCheckInID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            con.Close()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Check In record having Check In ID '" & txtCheckInID.Text & "' of guest '" & txtGuestName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                frmMainMenu.GetData()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If Len(Trim(txtServiceTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter service tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtServiceTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLuxuryTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter luxury tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLuxuryTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer.Text)) = 0 Then
                MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtBalance.Text) < 0 Then
                MessageBox.Show("Balance can not be less than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Text = ""
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If (cmbRoomNo.Text <> cmbRoomNo1.Text) Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "SELECT RoomNo FROM Temp_Reservation WHERE RoomNo=@d3 AND Status='Reserved' and Temp_Reservation.DateIn < @d1 AND Temp_Reservation.DateOut > @d2"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", dtpDateOut.Value.Date)
                cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
                cmd.Parameters.AddWithValue("@d3", cmbRoomNo.Text)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Selected Room is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
                con = New SqlConnection(cs)
                con.Open()
                Dim ct1 As String = "SELECT RoomNo FROM CheckIn_Room WHERE RoomNo=@d3 AND Status='Check In' and Checkin_Room.DateIn < @d1 AND Checkin_Room.DateOut > @d2"
                cmd = New SqlCommand(ct1)
                cmd.Parameters.AddWithValue("@d1", dtpDateOut.Value.Date)
                cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
                cmd.Parameters.AddWithValue("@d3", cmbRoomNo.Text)
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
                st1 = "Yes"
            End If
            If CheckBox1.Checked = False Then
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update CheckIN_Room Set GuestID=" & txtID.Text & ",RoomNo=@d1,RoomCharges=" & txtRoomCharges.Text & ",DateIN=@d3,DateOut=@d4,NoOfDays=" & txtNoOfDays.Text & ",NoOfMales=" & txtNoOfMales.Text & ",NoOfFemales=" & txtNoOfFemales.Text & ",NoOfKids=" & txtNoOfKids.Text & ",NoOfExtraBed=" & txtNoOfExtraBed.Text & ",NoOfExtraPerson=" & txtNoOfExtraPerson.Text & ",RoomOrderCharges=" & txtRoomOrderCharges.Text & ",ExtraPersonCharges=" & txtExtraPersonCharges.Text & ",TotalRoomCharges=" & txtTotalRoomCharges.Text & ",ExtraBedCharges=" & txtExtraBedCharges.Text & ",OtherCharges=" & txtLaundryCharges.Text & ",DiscountPer=" & txtDiscountPer.Text & ",DiscountAmount=" & txtDiscountAmount.Text & ",StPer=" & txtServiceTaxPer.Text & ",STAmount=" & txtServiceTaxAmount.Text & ",LuxuryTaxPer=" & txtLuxuryTaxPer.Text & ",LuxuryTaxAmount=" & txtLuxuryTaxAmount.Text & ",SubTotal=" & txtSubTotal.Text & ",GrandTotal=" & txtGrandTotal.Text & ",TotalPaid=" & txtTotalPaid.Text & ",Balance=" & txtBalance.Text & ",TaxPaidRate='" & st1 & "',Notes=@d2 where Cin_ID=" & txtCheckInID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d4", dtpDateOut.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the record of Check In guest '" & txtGuestName.Text & "' having Check In ID='" & txtCheckInID.Text & "'"
            LogFunc(lblUser.Text, st)
            btnUpdate.Enabled = False
            MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmMainMenu.GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCheckedIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckedIN.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLaundryCharges.Text)) = 0 Then
                MessageBox.Show("Please enter other charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLaundryCharges.Focus()
                Exit Sub
            End If
            If Len(Trim(txtServiceTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter service tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtServiceTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtLuxuryTaxPer.Text)) = 0 Then
                MessageBox.Show("Please enter luxury tax %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLuxuryTaxPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscountPer.Text)) = 0 Then
                MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtBalance.Text) < 0 Then
                MessageBox.Show("Balance can not be less than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Text = ""
                txtTotalPaid.Focus()
                Exit Sub
            End If
            auto()
            If CheckBox1.Checked = True Then
                st1 = "Yes"
            End If
            If CheckBox1.Checked = False Then
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into CheckIN_Room(Cin_Id, GuestID, RoomNo, RoomCharges, DateIN, DateOUT, NoOfDays, NoOfMales, NoOfFemales, NoOfKids, NoOfExtraBed, NoOfExtraPerson, RoomOrderCharges, ExtraPersonCharges, TotalRoomCharges,ExtraBedCharges, OtherCharges, DiscountPer, DiscountAmount, STPer, STAmount, LuxuryTaxPer, LuxuryTaxAmount, SubTotal, GrandTotal, TotalPaid, Balance, Status, TaxPaidRate, Notes) VALUES (" & txtCheckInID.Text & "," & txtID.Text & ",@d1," & txtRoomCharges.Text & ",@d3,@d4," & txtNoOfDays.Text & "," & txtNoOfMales.Text & "," & txtNoOfFemales.Text & "," & txtNoOfKids.Text & "," & txtNoOfExtraBed.Text & "," & txtNoOfExtraPerson.Text & "," & txtRoomOrderCharges.Text & "," & txtExtraPersonCharges.Text & "," & txtTotalRoomCharges.Text & "," & txtExtraBedCharges.Text & "," & txtLaundryCharges.Text & "," & txtDiscountPer.Text & "," & txtDiscountAmount.Text & "," & txtServiceTaxPer.Text & "," & txtServiceTaxAmount.Text & "," & txtLuxuryTaxPer.Text & "," & txtLuxuryTaxAmount.Text & "," & txtSubTotal.Text & "," & txtGrandTotal.Text & "," & txtTotalPaid.Text & "," & txtBalance.Text & ",'Check In','" & st1 & "',@d2)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d4", dtpDateOut.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Check In guest '" & txtGuestName.Text & "' with Check In ID='" & txtCheckInID.Text & "'"
            LogFunc(lblUser.Text, st)
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "Update Reservation set Status='Confirmed' where ID=" & txtReservationID.Text & ""
            cmd = New SqlCommand(cb3)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb4 As String = "delete from Temp_Reservation where ID=" & txtReservationID.Text & ""
            cmd = New SqlCommand(cb4)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            btnCheckedIN.Enabled = False
            MessageBox.Show("Successfully Check In", "Guest", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim frm As New frmMainMenu
            frm.GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoomAvailability.Click
        Try

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RoomNo FROM Temp_Reservation WHERE RoomNo=@d3 AND Status='Reserved' and Temp_Reservation.DateIn < @d1 AND Temp_Reservation.DateOut > @d2 union SELECT RoomNo FROM CheckIn_Room WHERE RoomNo=@d3 AND Status='Check In' and Checkin_Room.DateIn < @d1 AND Checkin_Room.DateOut > @d2"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d3", cmbRoomNo.Text)
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

    Private Sub txtTotalPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid.TextChanged
        If CheckBox1.Checked = False Then
            Compute()
        End If
        If CheckBox1.Checked = True Then
            Compute1()
        End If
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        frmCheckInRecord.lblSet.Text = "Check In"
        frmCheckInRecord.GetData()
        frmCheckInRecord.Show()
    End Sub

    Private Sub Button4_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button4, "Select advanced reservation")
    End Sub

    Private Sub txtOtherCharges_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLaundryCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtLaundryCharges.Text
            Dim selectionStart = Me.txtLaundryCharges.SelectionStart
            Dim selectionLength = Me.txtLaundryCharges.SelectionLength

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

    Private Sub txtTotalPaid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalPaid.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTotalPaid.Text
            Dim selectionStart = Me.txtTotalPaid.SelectionStart
            Dim selectionLength = Me.txtTotalPaid.SelectionLength

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

    Private Sub txtRoomCharges_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRoomCharges.TextChanged
        If CheckBox1.Checked = False Then
            Compute()
        End If
        If CheckBox1.Checked = True Then
            Compute1()
        End If
    End Sub

  
    Private Sub txtTotalPaid_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtTotalPaid.Validating
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Text = ""
            txtTotalPaid.Focus()
            Exit Sub
        End If
    End Sub

End Class
