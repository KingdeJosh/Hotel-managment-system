Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmCheckOut
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, a As Double
    Dim st2, GID As String
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
    Sub Compute()
        Try
            If dtpDateOut.Value.Date = dtpDateIn.Value.Date Then
                txtNoOfDays.Text = 1
            Else
                txtNoOfDays.Text = dtpDateOut.Value.Date.Subtract(dtpDateIn.Value.Date).Days.ToString
            End If
            num8 = CDbl(Val(txtNoOfExtraBed.Text) * Val(txtExtraBedC.Text) * Val(txtNoOfDays.Text))
            num8 = Math.Round(num8, 2)
            txtExtraBedCharges.Text = num8
            num9 = CDbl(Val(txtNoOfExtraPerson.Text) * Val(txtExtraPersonC.Text) * Val(txtNoOfDays.Text))
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
    Sub Reset()
        txtGender.Text = ""
        txtBillNo.Text = ""
        dtpBillDate.Text = Now
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
        txtRoomNo.Text = ""
        txtRoomCharges.Text = ""
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today
        txtNoOfMales.Text = 0
        txtNoOfFemales.Text = 0
        txtRoomOrderCharges.Text = 0
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
        txtTotalPaid.Text = 0
        txtBalance.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        dtpDateIn.Enabled = True
        dtpDateOut.Enabled = True
        btnPrint.Enabled = False
        dtpBillDate.Enabled = True
        btnAdd1.Enabled = True
        btnListReset1.Enabled = True
        btnPrint1.Enabled = False
        DataGridView2.Rows.Clear()
        lblStatus.Text = ""
        txtCountry.Text = ""
        txtPlanCode.Text = ""
        txtPlanName.Text = ""
        Clear1()
        cmbPaymentMode.SelectedIndex = 1
        FillData()
    End Sub
    Sub GetRoomID()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT R_ID FROM Room WHERE PlanCode=@d1 and RoomNo=@d2"
            cmd.Parameters.AddWithValue("@d1", txtPlanCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtRoomNo.Text)
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
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub hsExtraBed_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsExtraBed.ValueChanged
        If Len(Trim(txtRoomNo.Text)) = 0 Then
            MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomNo.Focus()
            Exit Sub
        End If
        txtNoOfExtraBed.Text = hsExtraBed.Value.ToString
        FillExtraBed()
        Compute()
    End Sub

    Private Sub hsExtraPerson_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsExtraPerson.ValueChanged
        If Len(Trim(txtRoomNo.Text)) = 0 Then
            MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomNo.Focus()
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
            If Len(Trim(txtRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRoomNo.Focus()
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
    Sub Fill()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT CheckIn_Room.RoomCharges,RTRIM(RoomType) FROM Room,CheckIn_Room WHERE CheckIn_Room.RoomID=Room.R_ID and RoomNo=@d1 and PlanCode=@d2 and Cin_ID=@d3"
            cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtPlanCode.Text)
            cmd.Parameters.AddWithValue("@d3", Val(txtCheckInID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRoomCharges.Text = rdr.GetValue(0)
                txtRoomType.Text = rdr.GetValue(1)
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
    Sub GetPlan()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT PlanName FROM [Plan] WHERE P_Code=@d1"
            cmd.Parameters.AddWithValue("@d1", txtPlanCode.Text)
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
    Private Sub cmbRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Fill()
    End Sub
    Sub FillData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ServiceTax,LuxuryTax,Discount FROM Tax WHERE Type='Room'"
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Compute()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(txtRoomNo.Text)) = 0 Then
                MessageBox.Show("Please retrieve room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRoomNo.Focus()
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
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT MaxNoOfKids,MaxNoOfAdults FROM Room WHERE RoomNo=@d1"
            cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
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
                    If row.Cells(0).Value = "From Guest's Account" And row.Cells(3).Value = "" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cbz1 As String = "Delete from GuestLedger where GL_Label='" & txtCheckInID.Text & "'"
                        cmd = New SqlCommand(cbz1)
                        cmd.Connection = con
                        cmd.ExecuteReader()
                        con.Close()
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
                            Dim string1 As String = "Paid for room charges"
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cbx As String = "insert into GuestLedger( Id,GuestID,Amount,Deduction,Date,Details,GL_Label) Values (" & txtGuestLedgerID.Text & "," & txtID.Text & ",0," & TotalPayment1() & ",@d1,@d2,'" & txtBillNo.Text & "')"
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
            auto()
            GetRoomID()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into CheckOut_Room(ID,BillNo,CheckInID,BillDate,Notes ) VALUES (" & txtBillID.Text & ",'" & txtBillNo.Text & "'," & txtCheckInID.Text & ",@d2,@d1)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d2", dtpBillDate.Value)
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update CheckIN_Room Set GuestID=" & txtID.Text & ",RoomID=@d1,RoomCharges=" & txtRoomCharges.Text & ",DateIN=@d3,DateOut=@d4,NoOfDays=" & txtNoOfDays.Text & ",NoOfMales=" & txtNoOfMales.Text & ",NoOfFemales=" & txtNoOfFemales.Text & ",NoOfKids=" & txtNoOfKids.Text & ",NoOfExtraBed=" & txtNoOfExtraBed.Text & ",NoOfExtraPerson=" & txtNoOfExtraPerson.Text & ",RoomOrderCharges=" & txtRoomOrderCharges.Text & ",ExtraPersonCharges=" & txtExtraPersonCharges.Text & ",TotalRoomCharges=" & txtTotalRoomCharges.Text & ",ExtraBedCharges=" & txtExtraBedCharges.Text & ",OtherCharges=" & txtLaundryCharges.Text & ",DiscountPer=" & txtDiscountPer.Text & ",DiscountAmount=" & txtDiscountAmount.Text & ",StPer=" & txtServiceTaxPer.Text & ",STAmount=" & txtServiceTaxAmount.Text & ",LuxuryTaxPer=" & txtLuxuryTaxPer.Text & ",LuxuryTaxAmount=" & txtLuxuryTaxAmount.Text & ",SubTotal=" & txtSubTotal.Text & ",GrandTotal=" & txtGrandTotal.Text & ",TotalPaid=" & txtTotalPaid.Text & ",Balance=" & txtBalance.Text & ",Status='Checked Out',Notes=@d2 where Cin_ID=" & txtCheckInID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtRoomID.Text))
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDateIn.Value.Date)
            cmd.Parameters.AddWithValue("@d4", dtpDateOut.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbZ As String = "Update Room_OrderInfo set RO_Status='Paid' where CheckInID=" & txtCheckInID.Text & ""
            cmd = New SqlCommand(cbZ)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con = New SqlConnection(cs)
            Dim cq As String = "delete from CheckIn_Payment where CheckInID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", txtCheckInID.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into CheckIn_Payment(CheckInID,PaymentMode,TotalPaid,PaymentDate) VALUES (" & txtCheckInID.Text & " ,@d4,@d5,@d6)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbC As String = "update Room set R_Status='Vacant Dirty' where RoomNo=@d1"
            cmd = New SqlCommand(cbC)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
            cmd.ExecuteReader()
            con.Close()
            LedgerDelete(txtCheckInID.Text, "Payment")
            LedgerDelete(txtCheckInID.Text, "Room Charges")
            LedgerDelete(txtCheckInID.Text, "Guest's Account")
            LedgerSave(dtpDateIn.Value.Date, txtGuestName.Text, txtBillNo.Text, "Room Charges", Val(txtGrandTotal.Text) - Val(txtLaundryCharges.Text) - Val(txtRoomOrderCharges.Text), 0, txtGuestID.Text)
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "By Cash" Or row.Cells(0).Value = "From Guest's Account" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Cash Account", txtBillNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                    End If
                    If row.Cells(0).Value = "By Credit Card" Or row.Cells(0).Value = "By Debit Card" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), "Bank Account", txtBillNo.Text, "Payment", 0, Val(row.Cells(1).Value), txtGuestID.Text)
                    End If
                    If row.Cells(0).Value = "From Guest's Account" Then
                        LedgerSave(Convert.ToDateTime(row.Cells(2).Value), txtGuestName.Text, txtBillNo.Text, "Guest's Account", Val(row.Cells(1).Value), 0, txtGuestID.Text)
                    End If
                End If
            Next
            Dim st As String = "Checked Out guest '" & txtGuestName.Text & "' with Bill no.'" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    st2 = rdr.GetValue(0)
                    Dim st3 As String = "Hello, " & txtGuestName.Text & " you have successfully Checked out from room no. " & txtRoomNo.Text & ""
                    SMSFunc(txtGuestContactNo.Text.Trim, st3, st2)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                End If
            End If
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
                        'Dim rpt As New rptRoomInvoice 'The report you created.
                        Dim myConnection As SqlConnection
                        Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
                        Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
                        Dim myDS As New DataSet 'The DataSet you created.
                        If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                            System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                        End If
                        Dim pdfFile As String = Application.StartupPath & "\PDF Reports\RoomInvoice " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
                        myConnection = New SqlConnection(cs)
                        MyCommand.Connection = myConnection
                        MyCommand1.Connection = myConnection
                        MyCommand2.Connection = myConnection
                        MyCommand.CommandText = "SELECT Checkin_Room.Cin_Id,Guest.ID,CheckIN_Room.GuestID, CheckIN_Room.RoomID, CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales,CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.DiscountAmount, CheckIN_Room.STPer,CheckIN_Room.STAmount, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.GrandTotal, CheckIN_Room.TotalPaid, CheckIN_Room.Balance,CheckIN_Room.Status, CheckIN_Room.Notes, Room.RoomType, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo,Guest.Country, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr5,Guest_Docs.Id AS Expr6, Guest_Docs.GuestID AS Expr7, Guest_Docs.Image1, Guest_Docs.Image2, Guest_Docs.Image3 FROM CheckIN_Room INNER JOIN Room ON CheckIN_Room.RoomID = Room.R_ID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Guest_Docs ON Guest.ID = Guest_Docs.GuestID where Status='Checked Out' and Cin_ID=" & txtCheckInID.Text & ""
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
                        myDA.Fill(myDS, "CheckIn_Room")
                        myDA.Fill(myDS, "Guest_Docs")
                        myDA1.Fill(myDS, "Hotel")
                        myDA2.Fill(myDS, "Currency")

                        SendMail(rdr.GetValue(0), GID, "Please find the attachment below", pdfFile, "Room Invoice", rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(0), Decrypt(rdr.GetValue(1)))
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                    End If
                End If
            End If
            btnSave.Enabled = False
            RefreshRecords()
            MessageBox.Show("Successfully Checked out", "Guest", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnPrint.Enabled = True
            btnPrint1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmCheckInRecord.lblSet.Text = "Check Out"
        frmCheckInRecord.Reset()
        frmCheckInRecord.ShowDialog()
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
            Dim cq As String = "delete from CheckOut_Room where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            con.Close()
            If RowsAffected > 0 Then
                LedgerDelete(txtBillNo.Text, "Room Charges")
                LedgerDelete(txtBillNo.Text, "Payment")
                Dim st As String = "deleted the checked out record having Bill No. '" & txtBillNo.Text & "' of guest '" & txtGuestName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                RefreshRecords()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        If Len(Trim(txtGuestID.Text)) = 0 Then
            MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtGuestID.Focus()
            Exit Sub
        End If

        If Len(Trim(txtRoomNo.Text)) = 0 Then
            MessageBox.Show("Please retrieve room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomNo.Focus()
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
        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT MaxNoOfKids,MaxNoOfAdults FROM Room WHERE RoomNo=@d1"
        cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
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
                If row.Cells(0).Value = "From Guest's Account" And row.Cells(3).Value = "" Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cbzx As String = "Delete from GuestLedger where GL_Label='" & txtBillNo.Text & "'"
                    cmd = New SqlCommand(cbzx)
                    cmd.Connection = con
                    cmd.ExecuteReader()
                    con.Close()
                    con = New SqlConnection(cs)
                End If
            End If
        Next
        GetRoomID()
        con = New SqlConnection(cs)
        con.Open()
        Dim cq As String = "delete from CheckIn_Payment where CheckInID=@d1"
        cmd = New SqlCommand(cq)
        cmd.Parameters.AddWithValue("@d1", Val(txtCheckInID.Text))
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()

    End Sub
    Private Sub auto()

        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM CheckOut_Room")
        cmd = New SqlCommand(sql)
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

    Private Sub txtTotalPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid.TextChanged
        Compute()
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click

    End Sub

    Private Sub Button4_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button4, "Select Check In guest")
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            'Dim rpt As New rptRoomInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            Dim pdfFile As String = Application.StartupPath & "\Report.Pdf"
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand.CommandText = "SELECT Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.RoomCharges, Room.MaxNoOfAdults, Room.MaxNoOfKids, Room.Active, CheckIN_Room.Cin_Id, CheckIN_Room.GuestID,CheckIN_Room.RoomID, CheckIN_Room.RoomCharges AS Expr1, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales,  CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.DiscountAmount, CheckIN_Room.STPer, CheckIN_Room.STAmount, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.GrandTotal, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Guest.ID, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,  Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color FROM Room INNER JOIN CheckIN_Room ON Room.R_ID = CheckIN_Room.RoomID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID where Status='Checked Out' and Cin_ID=" & txtCheckInID.Text & ""
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
            myDA.Fill(myDS, "CheckIn_Room")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRoomCharges_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRoomCharges.TextChanged
        Compute()
    End Sub
    Public Function TotalPayment1() As Double
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

    Private Sub txtTotalPaid_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtTotalPaid.Validating
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Text = ""
            txtTotalPaid.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnListReset1_Click(sender As System.Object, e As System.EventArgs) Handles btnListReset1.Click
        Clear1()
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
    Sub Compute1()
        Dim i As Double = 0
        i = Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)
        i = Math.Round(i, 2)
        txtBalance.Text = i
    End Sub

    Private Sub DataGridView2_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
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
    Sub Clear1()
        cmbPaymentMode.SelectedIndex = -1
        txtPayment.Text = ""
        dtpPaymentDate.Text = Today
        btnAdd1.Enabled = True
        btnRemove1.Enabled = False
        btnListUpdate1.Enabled = False
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint1.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2, MyCommand3, MyCommand4 As New SqlCommand()
            Dim myDA, myDA1, myDA2, myDA3, myDA4 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            Dim pdfFile As String = Application.StartupPath & "\Report.Pdf"
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand3.Connection = myConnection
            MyCommand4.Connection = myConnection
            MyCommand.CommandText = "SELECT Room.R_ID, Room.RoomNo, Room.PlanCode, Room.RoomType, Room.RoomCharges, Room.MaxNoOfAdults, Room.MaxNoOfKids, Room.Active, CheckIN_Room.Cin_Id, CheckIN_Room.GuestID,CheckIN_Room.RoomID, CheckIN_Room.RoomCharges AS Expr1, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales,  CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.DiscountAmount, CheckIN_Room.STPer, CheckIN_Room.STAmount, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.GrandTotal, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Guest.ID, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.Country, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.Email, Guest.IDType, Guest.IDNumber,  Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3, Guest.Company, Guest.Model, Guest.VehicleNo, Guest.Color FROM Room INNER JOIN CheckIN_Room ON Room.R_ID = CheckIN_Room.RoomID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID where Status='Checked Out' and Cin_ID=" & txtCheckInID.Text & ""
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand3.CommandText = "SELECT Laundry_BillInfo.Id, Laundry_BillInfo.BillNo, Laundry_BillInfo.BillDate, Laundry_BillInfo.CheckInID, Laundry_BillInfo.GrandTotal, Laundry_BillInfo.PaymentMode, Laundry_BillInfo.TotalPayment,Laundry_BillInfo.PaymentDue, Laundry_BillInfo.LB_Status, LaundryServices.LS_Id, LaundryServices.BillID, LaundryServices.Service, LaundryServices.Rate, LaundryServices.Qty, LaundryServices.TotalAmount,CheckIN_Room.Cin_Id, CheckIN_Room.GuestID, CheckIN_Room.RoomID, CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges,CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.DiscountAmount, CheckIN_Room.STPer,CheckIN_Room.STAmount, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.GrandTotal AS Expr1, CheckIN_Room.TotalPaid, CheckIN_Room.Balance,CheckIN_Room.Status, CheckIN_Room.Notes FROM Laundry_BillInfo INNER JOIN LaundryServices ON Laundry_BillInfo.Id = LaundryServices.BillID INNER JOIN CheckIN_Room ON Laundry_BillInfo.CheckInID = CheckIN_Room.Cin_Id where Status='Checked Out' and Cin_ID=" & txtCheckInID.Text & " order by BillNo"
            MyCommand4.CommandText = "SELECT Room_OrderInfo.Id, Room_OrderInfo.BillNo, Room_OrderInfo.BillDate, Room_OrderInfo.CheckInId, Room_OrderInfo.GrandTotal, Room_OrderInfo.PaymentMode, Room_OrderInfo.TotalPayment,Room_OrderInfo.PaymentDue, Room_OrderInfo.Operator, Room_OrderInfo.RO_Status, Room_OrderedProduct.OP_Id, Room_OrderedProduct.BillID, Room_OrderedProduct.Dish_Liquor,Room_OrderedProduct.Volumn, Room_OrderedProduct.TakenFrom, Room_OrderedProduct.VATPer, Room_OrderedProduct.VATAmount, Room_OrderedProduct.STPer, Room_OrderedProduct.STAmount, Room_OrderedProduct.DiscountPer, Room_OrderedProduct.DiscountAmount, Room_OrderedProduct.Rate, Room_OrderedProduct.Quantity, Room_OrderedProduct.Amount, Room_OrderedProduct.TotalAmount,CheckIN_Room.Cin_Id, CheckIN_Room.GuestID, CheckIN_Room.RoomID, CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales,CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer AS Expr1, CheckIN_Room.DiscountAmount AS Expr2, CheckIN_Room.STPer AS Expr3, CheckIN_Room.STAmount AS Expr4, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.GrandTotal AS Expr5, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes FROM Room_OrderInfo INNER JOIN Room_OrderedProduct ON Room_OrderInfo.Id = Room_OrderedProduct.BillID INNER JOIN CheckIN_Room ON Room_OrderInfo.CheckInId = CheckIN_Room.Cin_Id where Status='Checked Out' and Cin_ID=" & txtCheckInID.Text & " order by BillNo"
           
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA3.SelectCommand = MyCommand3
            myDA4.SelectCommand = MyCommand4
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "CheckIn_Room")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
            myDA3.Fill(myDS, "Laundry_BillInfo")
            myDA3.Fill(myDS, "CheckIn_Room")
            myDA3.Fill(myDS, "LaundryServices")
            myDA4.Fill(myDS, "Room_OrderInfo")
            myDA4.Fill(myDS, "Checkin_Room")
            myDA4.Fill(myDS, "Room_OrderedProduct")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
