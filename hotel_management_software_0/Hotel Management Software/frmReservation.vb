Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmReservation
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, a As Double
    Dim st2, GID As String
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
            num2 = CDbl(((Val(txtTotalRoomCharges.Text) + Val(txtExtraBedCharges.Text) + Val(txtExtraPersonCharges.Text)) * Val(txtDiscountPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount.Text = num2
            num3 = CDbl((Val(txtTotalRoomCharges.Text) + Val(txtExtraBedCharges.Text) + Val(txtExtraPersonCharges.Text)) - Val(txtDiscountAmount.Text))
            num3 = Math.Round(num3, 2)
            TextBox2.Text = num3
            num4 = CDbl((Val(TextBox2.Text) * Val(txtServiceTaxPer.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtServiceTaxAmount.Text = num4
            num5 = CDbl(((Val(TextBox2.Text) + Val(txtServiceTaxAmount.Text)) * Val(txtLuxuryTaxPer.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtLuxuryTaxAmount.Text = num5
            num10 = CDbl(Val(TextBox2.Text))
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

    Sub Reset()
        txtGender.Text = ""
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
        txtIDNumber.Text = ""
        txtNotes.Text = ""
        cmbRoomNo.SelectedIndex = -1
        cmbPlanCode.SelectedIndex = -1
        txtPlanName.Text = ""
        txtRoomCharges.Text = ""
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today
        txtNoOfMales.Text = 0
        txtNoOfFemales.Text = 0
        txtNoOfKids.Text = 0
        txtNoOfExtraBed.Text = 0
        txtNoOfExtraPerson.Text = 0
        txtNoOfDays.Text = ""
        txtTotalRoomCharges.Text = ""
        txtExtraBedCharges.Text = ""
        txtSubTotal.Text = ""
        txtLuxuryTaxPer.Text = ""
        txtReservationNo.Text = ""
        dtpReservationDate.Value = Now
        txtServiceTaxAmount.Text = ""
        txtServiceTaxPer.Text = ""
        txtLuxuryTaxAmount.Text = ""
        txtDiscountPer.Text = ""
        txtDiscountAmount.Text = ""
        txtGrandTotal.Text = ""
        txtTotalPaid.Text = 0
        txtBalance.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        dtpDateIn.Enabled = True
        dtpDateOut.Enabled = True
        cmbRoomNo.Enabled = True
        DataGridView2.Rows.Clear()
        btnRoomAvailability.Enabled = True
        lblStatus.Text = ""
        txtStatus.Text = ""
        Clear1()
        cmbPaymentMode.SelectedIndex = 1
        cmbPlanCode.Enabled = False
        cmbPlanCode.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRoomNo.Enabled = True
        cmbRoomNo1.Enabled = True
        btnCancelReservation.Enabled = False
        btnCancelReservationReceipt.Enabled = False
        btnPrint.Enabled = False
        txtCountry.Text = ""
        FillData()
        auto()
    End Sub
    Sub GetRoomID()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT R_ID FROM Room WHERE PlanCode=@d1 and RoomNo=@d2"
            cmd.Parameters.AddWithValue("@d1", cmbPlanCode.Text)
            cmd.Parameters.AddWithValue("@d2", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRoomID.Text = rdr.GetValue(0)
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
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
       
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub hsExtraBed_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsExtraBed.ValueChanged
        If Len(Trim(cmbRoomNo.Text)) = 0 Then
            MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRoomNo.Focus()
            Exit Sub
        End If
        txtNoOfExtraBed.Text = hsExtraBed.Value.ToString
        FillExtraBed()
        Compute()
    End Sub

    Private Sub hsExtraPerson_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsExtraPerson.ValueChanged
        If Len(Trim(cmbRoomNo.Text)) = 0 Then
            MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRoomNo.Focus()
            Exit Sub
        End If
        txtNoOfExtraPerson.Text = hsExtraPerson.Value.ToString
        FillExtraPerson()
        Compute()
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
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RoomNo) FROM Room where Active='Yes'", CN)
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
    Sub Clear1()
        cmbPaymentMode.SelectedIndex = -1
        txtPayment.Text = ""
        dtpPaymentDate.Text = Today
        btnAdd1.Enabled = True
        btnRemove1.Enabled = False
        btnListUpdate1.Enabled = False
    End Sub

    Private Sub frmReservation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillRoomNo()
        FillData()
    End Sub
    Sub Fill()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RoomCharges,RoomType FROM Room WHERE RoomNo=@d1 and PlanCode=@d2"
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", cmbPlanCode.Text)
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
            Compute()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub cmbRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Try
            cmbPlanCode.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(PlanCode) from Room where RoomNo=@d1", con)
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            cmbPlanCode.Items.Clear()
            While rdr.Read()
                cmbPlanCode.Items.Add(rdr(0))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Fill()
    End Sub
    Sub GetPlan()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT PlanName FROM [Plan] WHERE P_Code=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbPlanCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtPlanName.Text = rdr.GetValue(0)
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
                If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                    txtNoOfDays.Text = 1
                Else
                    txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
                End If
                txtExtraBedC.Text = rdr.GetValue(0) * Val(txtNoOfDays.Text)
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
                If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                    txtNoOfDays.Text = 1
                Else
                    txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
                End If
                txtExtraPersonC.Text = rdr.GetValue(0) * Val(txtNoOfDays.Text)
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
        Compute()
    End Sub

    Private Sub txtServiceTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceTaxPer.TextChanged
        Compute()
    End Sub

    Private Sub txtLuxuryTaxPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLuxuryTaxPer.TextChanged
        Compute()
    End Sub

    Private Sub txtGrandTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrandTotal.TextChanged
        Compute()
    End Sub

    Private Sub txtGrandTotal_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtGrandTotal.Validating
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Text = ""
            txtTotalPaid.Focus()
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
            If Len(Trim(cmbPlanCode.Text)) = 0 Then
                MessageBox.Show("Please select plan code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPlanCode.Focus()
                Exit Sub
            End If
            If (Val(txtNoOfFemales.Text) + Val(txtNoOfMales.Text) + Val(txtNoOfKids.Text)) = 0 Then
                MessageBox.Show("No. Of (Males + Females + Kids) must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim ct As String = "SELECT RoomNo FROM Reservation,Room where Room.R_ID=Reservation.RoomID and RoomNo=@d1 AND Status='Reserved' and Reservation.DateIn < @d2 AND Reservation.DateOut > @d3"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
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
            Dim ct1 As String = "SELECT RoomNo from Reservation,Room where Room.R_ID=Reservation.RoomID and RoomNo=@d1 AND Status='Check In' and Reservation.DateIn < @d2 AND Reservation.DateOut > @d3"
            cmd = New SqlCommand(ct1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room is already booked", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT MaxNoOfKids,MaxNoOfAdults FROM Room WHERE RoomNo=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txti1.Text = rdr.GetValue(0)
                txti2.Text = rdr.GetValue(1)
            End If
            If Val(txtNoOfMales.Text) + Val(txtNoOfFemales.Text) > Val(txti2.Text) Then
                MessageBox.Show("No. of adults (Males + Females) are more than allowed adults in a room", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Val(txtNoOfKids.Text) > Val(txti1.Text) Then
                MessageBox.Show("No. of kids are more than allowed kids in a room", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "From Guest's Account" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ctg As String = "select ISNULL(sum(Amount)-Sum(Deduction),0) from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID and GuestLedger.GuestID=@d1"
                        cmd = New SqlCommand(ctg)
                        cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                        cmd.Connection = con
                        rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            a = rdr.GetValue(0)
                        Else
                            a = 0
                        End If
                        con.Close()
                        If a >= TotalPayment1() Then
                            auto1()
                            Dim string1 As String = "Paid for room reservation"
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cbx As String = "insert into GuestLedger( Id,GuestID,Amount,Deduction,Date,Details,GL_Label) Values (" & txtGuestLedgerID.Text & "," & txtID.Text & ",0," & TotalPayment1() & ",@d1,@d2,'" & txtReservationNo.Text & "')"
                            cmd = New SqlCommand(cbx)
                            cmd.Parameters.AddWithValue("@d1", Now)
                            cmd.Parameters.AddWithValue("@d2", string1)
                            cmd.Connection = con
                            cmd.ExecuteReader()
                            con.Close()
                        Else
                            MessageBox.Show("Insufficient fund available in guest's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                End If
            Next
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Compute()
            GetRoomID()
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Reservation(Reserve_ID, Guest_ID, RoomID, RoomCharges, DateIN, DateOUT, NoOfDays, NoOfMales, NoOfFemales, NoOfKids, NoOfExtraBed, NoOfExtraPerson, ExtraPersonCharges, TotalRoomCharges,ExtraBedCharges, DiscountPer, DiscountAmount, STPer, STAmount, LuxuryTaxPer, LuxuryTaxAmount, SubTotal, GrandTotal, TotalPaid, Balance, Status, Notes,ReservationNo,ReservationDate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,@d15,@d16,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,'Reserved',@d28,@d29,@d30)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtReservationID.Text))
            cmd.Parameters.AddWithValue("@d2", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d3", Val(txtRoomID.Text))
            cmd.Parameters.AddWithValue("@d4", Val(txtRoomCharges.Text))
            cmd.Parameters.AddWithValue("@d5", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d6", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d7", Val(txtNoOfDays.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtNoOfMales.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtNoOfFemales.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtNoOfKids.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtNoOfExtraBed.Text))
            cmd.Parameters.AddWithValue("@d12", Val(txtNoOfExtraPerson.Text))
            cmd.Parameters.AddWithValue("@d14", Val(txtExtraPersonCharges.Text))
            cmd.Parameters.AddWithValue("@d15", Val(txtTotalRoomCharges.Text))
            cmd.Parameters.AddWithValue("@d16", Val(txtExtraBedCharges.Text))
            cmd.Parameters.AddWithValue("@d18", Val(txtDiscountPer.Text))
            cmd.Parameters.AddWithValue("@d19", Val(txtDiscountAmount.Text))
            cmd.Parameters.AddWithValue("@d20", Val(txtServiceTaxPer.Text))
            cmd.Parameters.AddWithValue("@d21", Val(txtServiceTaxAmount.Text))
            cmd.Parameters.AddWithValue("@d22", Val(txtLuxuryTaxPer.Text))
            cmd.Parameters.AddWithValue("@d23", Val(txtLuxuryTaxAmount.Text))
            cmd.Parameters.AddWithValue("@d24", Val(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@d25", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d26", Val(txtTotalPaid.Text))
            cmd.Parameters.AddWithValue("@d27", Val(txtBalance.Text))
            cmd.Parameters.AddWithValue("@d28", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d29", txtReservationNo.Text)
            cmd.Parameters.AddWithValue("@d30", dtpReservationDate.Value)
            cmd.ExecuteReader()
            con.Close()
            If DataGridView2.Rows.Count = 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cbV As String = "insert into Reservation_Payment(ReservationID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtReservationID.Text & " ,@d4,@d5,@d6)"
                cmd = New SqlCommand(cbV)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d4", "")
                cmd.Parameters.AddWithValue("@d5", 0.0)
                cmd.Parameters.AddWithValue("@d6", System.DateTime.Now)
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into Reservation_Payment(ReservationID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtReservationID.Text & " ,@d4,@d5,@d6)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d4", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d6", row.Cells(2).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            LedgerSave(dtpReservationDate.Value, txtGuestName.Text, txtReservationNo.Text, "Room Reservation", Val(txtGrandTotal.Text), 0, txtGuestID.Text)
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "By Cash" Or row.Cells(0).Value = "From Guest's Account" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Cash Account", txtReservationNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                    End If
                    If row.Cells(0).Value = "By Credit Card" Or row.Cells(0).Value = "By Debit Card" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Bank Account", txtReservationNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                    End If
                    If row.Cells(0).Value = "From Guest's Account" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtGuestName.Text, txtReservationNo.Text, "Guest's Account", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                    End If
                End If
            Next
            Dim st As String = "Reserved the room '" & cmbRoomNo.Text & "' for Guest '" & txtGuestName.Text & "' having reservation no. '" & txtReservationNo.Text & "'"
            LogFunc(lblUser.Text, st)
            SendSMS()
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim str As String = "select IsNull(Email,0) from Guest where Guest.ID=" & txtID.Text & ""
                cmd = New SqlCommand(str)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    GID = rdr.GetValue(0).ToString.Trim()
                End If
                If GID <> "0" Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctn As String = "select RTRIM(Username),RTRIM(Password),RTRIM(SMTPAddress),(Port) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
                    cmd = New SqlCommand(ctn)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        Dim rpt As New rptReservationInvoice 'The report you created.
                        Dim myConnection As SqlConnection
                        Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
                        Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
                        Dim myDS As New DataSet 'The DataSet you created.
                        If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                            System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                        End If
                        Dim pdfFile As String = Application.StartupPath & "\PDF Reports\ReservationInvoice " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
                        myConnection = New SqlConnection(cs)
                        MyCommand.Connection = myConnection
                        MyCommand1.Connection = myConnection
                        MyCommand2.Connection = myConnection
                        MyCommand.CommandText = "SELECT Guest.ID, Guest.GuestID, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color, Reservation.Reserve_ID, Reservation.ReservationNo, Reservation.ReservationDate,Reservation.Guest_ID, Reservation.RoomID, Reservation.RoomCharges, Reservation.DateIN, Reservation.DateOUT, Reservation.NoOfDays, Reservation.NoOfMales, Reservation.NoOfFemales, Reservation.NoOfKids, Reservation.NoOfExtraBed, Reservation.NoOfExtraPerson, Reservation.ExtraPersonCharges, Reservation.TotalRoomCharges, Reservation.ExtraBedCharges, Reservation.DiscountPer, Reservation.DiscountAmount, Reservation.STPer, Reservation.STAmount, Reservation.LuxuryTaxPer, Reservation.LuxuryTaxAmount, Reservation.SubTotal, Reservation.GrandTotal, Reservation.TotalPaid, Reservation.Balance, Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.MaxNoOfAdults,Room.MaxNoOfKids, Room.Active FROM Guest INNER JOIN Reservation ON Guest.ID = Reservation.Guest_ID INNER JOIN Room ON Reservation.RoomID = Room.R_ID and Reservation.ReservationNo='" & txtReservationNo.Text & "'"
                        MyCommand1.CommandText = "SELECT * from Hotel"
                        MyCommand2.CommandText = "SELECT * from Currency"
                        MyCommand.CommandType = CommandType.Text
                        MyCommand1.CommandType = CommandType.Text
                        MyCommand2.CommandType = CommandType.Text
                        myDA.SelectCommand = MyCommand
                        myDA1.SelectCommand = MyCommand1
                        myDA2.SelectCommand = MyCommand2
                        myDA.Fill(myDS, "Guest")
                        myDA.Fill(myDS, "Room")
                        myDA.Fill(myDS, "Reservation")
                        myDA1.Fill(myDS, "Hotel")
                        myDA2.Fill(myDS, "Currency")
                        rpt.SetDataSource(myDS)
                        'frmReport.CrystalReportViewer1.ReportSource = rpt
                        rpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFile)
                        SendMail(rdr.GetValue(0), GID, "Please find the attachment below", pdfFile, "Reservation Invoice", rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(0), Decrypt(rdr.GetValue(1)))
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                    End If
                End If
            End If
            btnSave.Enabled = False
            RefreshRecords()
            MessageBox.Show("Successfully Reserved", "Room", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnPrint.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub SendSMS()
        Try
            If CheckForInternetConnection() = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    st2 = rdr.GetValue(0)
                    Dim st3 As String = "Hello, " & txtGuestName.Text & " you have successfully reserved the room " & cmbRoomNo.Text & " having Reservation No. '" & txtReservationNo.Text & "'"
                    SMSFunc(txtGuestContactNo.Text.Trim, st3, st2)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub auto1()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM GuestLedger")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtGuestLedgerID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtGuestLedgerID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
                RefreshRecords()
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
            Dim cq As String = "delete from Reservation where Reserve_ID=" & txtReservationID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            con.Close()
            If RowsAffected > 0 Then
                LedgerDelete(txtReservationNo.Text, "Room Reservation")
                LedgerDelete(txtReservationNo.Text, "Payment")
                Dim st As String = "deleted the Reservation record having Reservation No. '" & txtReservationNo.Text & "'"
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
            Dim ct As String = "SELECT RoomNo from Reservation,Room where Room.R_ID=Reservation.RoomID and RoomNo=@d1 AND Status='Reserved' and Reservation.DateIn < @d2 AND Reservation.DateOut > @d3 union SELECT RoomNo FROM Reservation,Room where Room.R_ID=Reservation.RoomID and RoomNo=@d1 AND Status='Check In' and Reservation.DateIn < @d2 AND Reservation.DateOut > @d3"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
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
        Compute()
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
       
    End Sub

    Public Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(Reserve_ID) FROM Reservation")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtReservationID.Text = Num.ToString
            txtReservationNo.Text = "R" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtReservationID.Text = Num.ToString
            txtReservationNo.Text = "R" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
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
        Compute()
    End Sub


    Private Sub txtTotalPaid_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtTotalPaid.Validating
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Text = ""
            txtTotalPaid.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnAdd1_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd1.Click
        Try

            If cmbPaymentMode.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPaymentMode.Focus()
                Exit Sub
            End If
            If txtPayment.Text = "" Then
                MessageBox.Show("Please enter payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPayment.Focus()
                Exit Sub
            End If
            DataGridView2.Rows.Add(cmbPaymentMode.Text, Val(txtPayment.Text), dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPaid.Text = j
            Compute1()
            Clear1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnListReset1_Click(sender As System.Object, e As System.EventArgs) Handles btnListReset1.Click
        Clear1()
    End Sub

    Private Sub btnRemove1_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove1.Click
        Try
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = TotalPayment()
            k = Math.Round(k, 2)
            txtTotalPaid.Text = k
            Compute1()
            Compute()
            Clear1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnListUpdate1_Click(sender As System.Object, e As System.EventArgs) Handles btnListUpdate1.Click
        Try
            If cmbPaymentMode.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPaymentMode.Focus()
                Exit Sub
            End If
            If txtPayment.Text = "" Then
                MessageBox.Show("Please enter payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPayment.Focus()
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            DataGridView2.Rows.Add(cmbPaymentMode.Text, Val(txtPayment.Text), dtpPaymentDate.Value.Date)
            Dim j As Double = 0
            j = TotalPayment()
            j = Math.Round(j, 2)
            txtTotalPaid.Text = j
            Compute1()
            Clear1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function TotalPayment() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(1).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalPayment1() As Double
        Dim sum As Double = 0
        Try

            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If r.Cells(0).Value = "From Guest's Account" Then
                    sum = sum + r.Cells(1).Value
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalPayment2() As Double
        Dim sum As Double = 0
        Try

            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If r.Cells(0).Value = "From Guest's Account" And r.Cells(3).Value = "" Then
                    sum = sum + r.Cells(1).Value
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Compute1()
        Dim i As Double = 0
        i = Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)
        i = Math.Round(i, 2)
        txtBalance.Text = i
    End Sub
    Private Sub DataGridView2_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        btnRemove1.Enabled = True
        If (Me.DataGridView2.Rows.Count > 0) Then
            Dim row As DataGridViewRow = Me.DataGridView2.SelectedRows.Item(0)
            If lblStatus.Text = "Not allowed" And row.Cells(0).Value = "From Guest's Account" And row.Cells(3).Value = "Not allowed" Then
                Me.btnRemove1.Enabled = False
                Me.btnListUpdate1.Enabled = False
            Else
                Me.btnRemove1.Enabled = True
                Me.btnListUpdate1.Enabled = True
            End If
            Me.btnAdd1.Enabled = False

            Me.cmbPaymentMode.Text = (row.Cells.Item(0).Value)
            Me.txtPayment.Text = (row.Cells.Item(1).Value)
            Me.dtpPaymentDate.Text = (row.Cells.Item(2).Value)
        End If
    End Sub

    Private Sub DataGridView2_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView2.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlLightLight
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub txtPayment_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPayment.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtPayment.Text
            Dim selectionStart = Me.txtPayment.SelectionStart
            Dim selectionLength = Me.txtPayment.SelectionLength

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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmGuest.Reset()
        frmGuest.lblUser.Text = lblUser.Text
        frmGuest.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub txtRoomCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRoomCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtRoomCharges.Text
            Dim selectionStart = Me.txtRoomCharges.SelectionStart
            Dim selectionLength = Me.txtRoomCharges.SelectionLength

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

    Private Sub cmbPlan_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPlanCode.SelectedIndexChanged
        Fill()
        GetPlan()
    End Sub

    Private Sub btnCancelReservation_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelReservation.Click
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
            If (txtStatus.Text = "Cancelled") Then
                MessageBox.Show("Reservation is already cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If (txtStatus.Text = "Confirmed") Then
                MessageBox.Show("Reservation is confirmed and Guest is already Check In " & vbCrLf & " so it can not be cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If MessageBox.Show("Are you sure want to cancel this reservation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "update Reservation set Status='Cancelled' where Reserve_ID=" & txtReservationID.Text & ""
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()

                For Each row As DataGridViewRow In DataGridView2.Rows
                    If Not row.IsNewRow Then
                        If row.Cells(0).Value = "By Cash" Then
                            LedgerSave(System.DateTime.Now, "Cash Account", txtReservationNo.Text, "Payment", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                            LedgerSave(System.DateTime.Now, txtGuestName.Text, txtReservationNo.Text, "Reservation cancellation refund", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                        End If
                        If row.Cells(0).Value = "By Credit Card" Or row.Cells(0).Value = "By Debit Card" Then
                            LedgerSave(System.DateTime.Now, "Bank Account", txtReservationNo.Text, "Payment", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                            LedgerSave(System.DateTime.Now, txtGuestName.Text, txtReservationNo.Text, "Reservation cancellation refund", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                        End If
                        If row.Cells(0).Value = "From Guest's Account" Then
                            auto1()
                            Dim string1 As String = "Refund for Reservation Cancellation"
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cbx As String = "insert into GuestLedger(Id,GuestID,Amount,Deduction,Date,Details) Values (" & txtGuestLedgerID.Text & "," & txtID.Text & "," & TotalPayment1() & ",0,@d1,@d2)"
                            cmd = New SqlCommand(cbx)
                            cmd.Parameters.AddWithValue("@d1", Now)
                            cmd.Parameters.AddWithValue("@d2", string1)
                            cmd.Connection = con
                            cmd.ExecuteReader()
                            con.Close()
                            LedgerSave(System.DateTime.Now, "Cash Account", txtReservationNo.Text, "Payment", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                            LedgerSave(System.DateTime.Now, txtGuestName.Text, txtReservationNo.Text, "Reservation cancellation refund", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                        End If
                    End If
                Next
                Dim st As String = "cancelled the reservation having reservation no.'" & txtReservationNo.Text & "' of guest '" & txtGuestName.Text & "'"
                LogFunc(lblUser.Text, st)
                If CheckForInternetConnection() = True Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                    cmd = New SqlCommand(ctn)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        st2 = rdr.GetValue(0)
                        Dim st3 As String = "Hello, " & txtGuestName.Text & " your reservation has been cancelled having reservation no. " & txtReservationNo.Text & ""
                        SMSFunc(txtGuestContactNo.Text.Trim, st3, st2)
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                    End If
                    con.Close()
                End If
                MessageBox.Show("Successfully cancelled", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelReservation.Enabled = False
                btnCancelReservationReceipt.Enabled = True
                RefreshRecords()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print1()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            '  Dim rpt As New rptReservationCancellationReceipt 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            Dim pdfFile As String = Application.StartupPath & "\Report.Pdf"
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand.CommandText = "SELECT Guest.ID, Guest.GuestID, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color, Reservation.Reserve_ID, Reservation.ReservationNo, Reservation.ReservationDate,Reservation.Guest_ID, Reservation.RoomID, Reservation.RoomCharges, Reservation.DateIN, Reservation.DateOUT, Reservation.NoOfDays, Reservation.NoOfMales, Reservation.NoOfFemales, Reservation.NoOfKids, Reservation.NoOfExtraBed, Reservation.NoOfExtraPerson, Reservation.ExtraPersonCharges, Reservation.TotalRoomCharges, Reservation.ExtraBedCharges, Reservation.DiscountPer, Reservation.DiscountAmount, Reservation.STPer, Reservation.STAmount, Reservation.LuxuryTaxPer, Reservation.LuxuryTaxAmount, Reservation.SubTotal, Reservation.GrandTotal, Reservation.TotalPaid, Reservation.Balance, Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.MaxNoOfAdults,Room.MaxNoOfKids, Room.Active FROM Guest INNER JOIN Reservation ON Guest.ID = Reservation.Guest_ID INNER JOIN Room ON Reservation.RoomID = Room.R_ID and Status='Cancelled' and Reservation.ReservationNo='" & txtReservationNo.Text & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            MyCommand2.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "Reservation")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
            'rpt.SetDataSource(myDS)
            'frmReport.CrystalReportViewer1.ReportSource = rpt
            'frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptReservationInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            Dim pdfFile As String = Application.StartupPath & "\Report.Pdf"
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand.CommandText = "SELECT Guest.ID, Guest.GuestID, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color, Reservation.Reserve_ID, Reservation.ReservationNo, Reservation.ReservationDate,Reservation.Guest_ID, Reservation.RoomID, Reservation.RoomCharges, Reservation.DateIN, Reservation.DateOUT, Reservation.NoOfDays, Reservation.NoOfMales, Reservation.NoOfFemales, Reservation.NoOfKids, Reservation.NoOfExtraBed, Reservation.NoOfExtraPerson, Reservation.ExtraPersonCharges, Reservation.TotalRoomCharges, Reservation.ExtraBedCharges, Reservation.DiscountPer, Reservation.DiscountAmount, Reservation.STPer, Reservation.STAmount, Reservation.LuxuryTaxPer, Reservation.LuxuryTaxAmount, Reservation.SubTotal, Reservation.GrandTotal, Reservation.TotalPaid, Reservation.Balance, Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.MaxNoOfAdults,Room.MaxNoOfKids, Room.Active FROM Guest INNER JOIN Reservation ON Guest.ID = Reservation.Guest_ID INNER JOIN Room ON Reservation.RoomID = Room.R_ID and Reservation.ReservationNo='" & txtReservationNo.Text & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            MyCommand2.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "Reservation")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
            rpt.SetDataSource(myDS)
            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelReservationReceipt_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelReservationReceipt.Click
        Print1()
    End Sub
End Class
