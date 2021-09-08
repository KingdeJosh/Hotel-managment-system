Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmReservation_HallorGarden

    Dim num1, num2, num3, num4, num5, num6, num7 As Double
    Dim st2, GID As String

    Sub Compute()
        Try
            If DateTo.Value.Date = DateFrom.Value.Date Then
                txtNoOfDays.Text = 1
            Else
                txtNoOfDays.Text = DateTo.Value.Date.Subtract(DateFrom.Value.Date).Days.ToString
            End If
            num1 = CDbl(Val(txtRate.Text) * Val(txtNoOfDays.Text))
            num1 = Math.Round(num1, 2)
            txtTotalCharges.Text = num1
            num2 = CDbl(((Val(txtTotalCharges.Text) + Val(txtOtherCharges.Text)) * Val(txtDiscountPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscount.Text = num2
            num3 = CDbl(Val(txtTotalCharges.Text) + Val(txtOtherCharges.Text)) - Val(txtDiscount.Text)
            num3 = Math.Round(num3, 2)
            txtSubTotal.Text = num3
            num4 = CDbl((Val(txtSubTotal.Text) * Val(txtServiceTaxPer.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtServiceTaxAmount.Text = num4
            num5 = CDbl(((Val(txtSubTotal.Text) + Val(txtServiceTaxAmount.Text)) * Val(txtLuxuryTaxPer.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtLuxuryTaxAmount.Text = num5
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
        txtGuestID.Text = ""
        txtGuestName.Text = ""
        txtGuestAddress.Text = ""
        txtGuestCity.Text = ""
        txtGuestContactNo.Text = ""
        txtIDType.Text = ""
        txtIDNumber.Text = ""
        DateFrom.Text = Today
        DateTo.Text = Today
        txtNoOfDays.Text = ""
        txtRate.Text = ""
        txtTotalCharges.Text = ""
        txtOtherCharges.Text = "0.00"
        txtSubTotal.Text = ""
        txtServiceTaxPer.Text = ""
        txtServiceTaxAmount.Text = ""
        txtGender.Text = ""
        txtReligion.Text = ""
        txtOccupation.Text = ""
        txtLuxuryTaxPer.Text = ""
        txtLuxuryTaxAmount.Text = ""
        txtDiscountPer.Text = ""
        txtDiscount.Text = ""
        txtGrandTotal.Text = ""
        txtTotalPaid.Text = ""
        txtBalance.Text = ""
        cmbName.Enabled = False
        cmbName.SelectedIndex = -1
        txtBillNo.Text = ""
        dtpBillDate.Text = Now
        rbGarden.Checked = False
        rbHall.Checked = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnPrint.Enabled = False
        dtpBillDate.Enabled = True
        DateFrom.Enabled = True
        DateTo.Enabled = True
        btnAvailability.Enabled = True
        btnCancelReservation.Enabled = False
        txtCountry.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub DateTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTo.ValueChanged

        Try
            txtNoOfDays.Text = DateTo.Value.Date.Subtract(DateFrom.Value.Date).Days.ToString
            Compute()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
        Reset()
        Reset()
    End Sub
    Sub fillHall()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(HallName) FROM Hall", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbName.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillGarden()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(GardenName) FROM Garden", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbName.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub rbHall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbHall.CheckedChanged
        fillHall()
        cmbName.Enabled = True
    End Sub

    Private Sub cmbName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbName.SelectedIndexChanged
        If rbHall.Checked = True Then
            Try
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT Charges FROM Hall WHERE HallName= @d1"
                cmd.Parameters.AddWithValue("@d1", cmbName.Text)
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
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT Discount,ServiceTax,LuxuryTax FROM Tax WHERE Type='Hall'"
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtDiscountPer.Text = rdr.GetValue(0)
                    txtServiceTaxPer.Text = rdr.GetValue(1)
                    txtLuxuryTaxPer.Text = rdr.GetValue(2)
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
        If rbGarden.Checked = True Then
            Try
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT Charges FROM Garden WHERE GardenName= @d1"
                cmd.Parameters.AddWithValue("@d1", cmbName.Text)
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
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT Discount,ServiceTax,LuxuryTax FROM Tax WHERE Type='Garden'"
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtDiscountPer.Text = rdr.GetValue(0)
                    txtServiceTaxPer.Text = rdr.GetValue(1)
                    txtLuxuryTaxPer.Text = rdr.GetValue(2)
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

    Private Sub rbGarden_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGarden.CheckedChanged
        fillGarden()
        cmbName.Enabled = True
    End Sub
    Private Sub auto()

        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Reservation_Garden")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1

            If rbGarden.Checked = True Then
                txtBillID.Text = Num.ToString
                txtBillNo.Text = "WG" + Num.ToString
            End If

        Else

            If rbGarden.Checked = True Then
                Num = cmd.ExecuteScalar + 1
                txtBillID.Text = Num.ToString
                txtBillNo.Text = "WG" + Num.ToString
            End If

        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub auto1()

        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Reservation_Hall")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1

            If rbHall.Checked = True Then
                txtBillID.Text = Num.ToString
                txtBillNo.Text = "H" + Num.ToString
            End If

        Else

            If rbHall.Checked = True Then
                Num = cmd.ExecuteScalar + 1
                txtBillID.Text = Num.ToString
                txtBillNo.Text = "H" + Num.ToString
            End If

        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
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
            If (rbHall.Checked = True) Then
                Dim RowsAffected As Integer = 0
                con = New SqlConnection(cs)
                con.Open()
                Dim cq As String = "delete from Reservation_Hall where ID= " & txtBillID.Text & ""
                cmd = New SqlCommand(cq)
                cmd.Connection = con
                RowsAffected = cmd.ExecuteNonQuery()
                If RowsAffected > 0 Then
                    LedgerDelete(txtBillNo.Text, "Hall Reservation")
                    LedgerDelete(txtBillNo.Text, "Payment")
                    Dim st As String = "deleted the bill no '" & txtBillNo.Text & "'"
                    LogFunc(lblUser.Text, st)
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Reset()
                    Reset()
                    Reset()
                Else
                    MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Reset()
                    Reset()
                End If
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            If (rbGarden.Checked = True) Then
                Dim RowsAffected As Integer = 0
                con = New SqlConnection(cs)
                con.Open()
                Dim cq As String = "delete from Reservation_Garden where ID= " & txtBillID.Text & ""
                cmd = New SqlCommand(cq)
                cmd.Connection = con
                RowsAffected = cmd.ExecuteNonQuery()
                If RowsAffected > 0 Then
                    LedgerDelete(txtBillNo.Text, "Garden Reservation")
                    LedgerDelete(txtBillNo.Text, "Payment")
                    Dim st As String = "deleted the bill no '" & txtBillNo.Text & "'"
                    LogFunc(lblUser.Text, st)
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Reset()
                    Reset()
                    Reset()
                Else
                    MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Reset()
                    Reset()
                End If
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtOtherCharges_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtOtherCharges.Text
            Dim selectionStart = Me.txtOtherCharges.SelectionStart
            Dim selectionLength = Me.txtOtherCharges.SelectionLength

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

    Private Sub txtTotalPaid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalPaid.Validating
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Text = ""
            txtTotalPaid.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtOtherCharges_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherCharges.TextChanged
        Compute()
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

    Private Sub txtTotalPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid.TextChanged
        Compute()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If
            If rbGarden.Checked = False And rbHall.Checked = False Then
                MessageBox.Show("Please select type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Len(Trim(cmbName.Text)) = 0 Then
                MessageBox.Show("Please select hall/garden name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbName.Focus()
                Exit Sub
            End If
            If Len(Trim(txtOtherCharges.Text)) = 0 Then
                MessageBox.Show("Please enter other charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtOtherCharges.Focus()
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
                MessageBox.Show("Please enter discount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscountPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTotalPaid.Text)) = 0 Then
                MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPaid.Text = ""
                txtTotalPaid.Focus()
                Exit Sub
            End If
            If rbHall.Checked = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct2 As String = "SELECT * FROM Reservation_Hall WHERE DateFrom <= @d1 AND DateTo >= @d2 and Name=@d3 and Status='Confirmed'"
                cmd = New SqlCommand(ct2)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", DateTo.Value.Date)
                cmd.Parameters.AddWithValue("@d2", DateFrom.Value.Date)
                cmd.Parameters.AddWithValue("@d3", cmbName.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Hall is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
            End If
            If rbGarden.Checked = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct2 As String = "SELECT * FROM Reservation_Garden WHERE DateFrom <= @d1 AND DateTo >= @d2 and Name=@d3 and Status='Confirmed'"
                cmd = New SqlCommand(ct2)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", DateTo.Value.Date)
                cmd.Parameters.AddWithValue("@d2", DateFrom.Value.Date)
                cmd.Parameters.AddWithValue("@d3", cmbName.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Garden is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
            End If
            If rbHall.Checked = True Then
                auto1()
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "insert into Reservation_Hall( ID, BillNo, BillDate, GuestID,Type,Name, DateFrom, DateTo, Days, Rate,TotalCharges,OtherCharges, SubTotal, STPer, STAmount, LuxuryTaxPer,LuxuryTaxAmount, DiscountPer, DiscountAmount, GrandTotal, TotalPaid, Balance, Notes,Status) Values (" & txtBillID.Text & ",'" & txtBillNo.Text & "',@d5," & txtID.Text & ",'Hall',@d1,@d3,@d4," & txtNoOfDays.Text & "," & txtRate.Text & "," & txtTotalCharges.Text & "," & txtOtherCharges.Text & "," & txtSubTotal.Text & "," & txtServiceTaxPer.Text & "," & txtServiceTaxAmount.Text & "," & txtLuxuryTaxPer.Text & "," & txtLuxuryTaxAmount.Text & "," & txtDiscountPer.Text & "," & txtDiscount.Text & "," & txtGrandTotal.Text & "," & txtTotalPaid.Text & "," & txtBalance.Text & ",@d2,'Confirmed')"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", cmbName.Text)
                cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
                cmd.Parameters.AddWithValue("@d4", DateTo.Value.Date)
                cmd.Parameters.AddWithValue("@d3", DateFrom.Value.Date)
                cmd.Parameters.AddWithValue("@d5", dtpBillDate.Value)
                cmd.ExecuteReader()
                con.Close()
                LedgerSave(dtpBillDate.Value.Date, txtGuestName.Text, txtBillNo.Text, "Hall Reservation", Val(txtGrandTotal.Text), 0, txtGuestID.Text)
                LedgerSave(dtpBillDate.Value.Date, "Cash Account", txtBillNo.Text, "Payment", 0, Val(txtTotalPaid.Text), txtGuestID.Text)
                Dim st As String = "Reserved the hall '" & cmbName.Text & "' with bill no. '" & txtBillNo.Text & "'"
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
                        Dim st3 As String = "Hello, " & txtGuestName.Text & " you have successfully reserved the hall having reservation no. " & txtBillNo.Text & ""
                        SMSFunc(txtGuestContactNo.Text.Trim, st3, st2)
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                    End If
                    con.Close()
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
                            If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                                System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                            End If
                            Dim pdfFile As String = Application.StartupPath & "\PDF Reports\HallReservationInvoice " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"

                            Dim myConnection As SqlConnection
                            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
                            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
                            Dim myDS As New DataSet 'The DataSet you created.
                            myConnection = New SqlConnection(cs)
                            MyCommand.Connection = myConnection
                            MyCommand1.Connection = myConnection
                            MyCommand2.Connection = myConnection
                            MyCommand.CommandText = "SELECT Reservation_Hall.BillNo, Reservation_Hall.BillDate, Reservation_Hall.GuestID, Reservation_Hall.Type, Reservation_Hall.Name, Reservation_Hall.DateFrom, Reservation_Hall.DateTo,Reservation_Hall.Days, Reservation_Hall.Rate, Reservation_Hall.TotalCharges, Reservation_Hall.DiscountPer, Reservation_Hall.DiscountAmount, Reservation_Hall.OtherCharges, Reservation_Hall.SubTotal,Reservation_Hall.STPer, Reservation_Hall.STAmount, Reservation_Hall.LuxuryTaxPer, Reservation_Hall.LuxuryTaxAmount, Reservation_Hall.GrandTotal, Reservation_Hall.TotalPaid, Reservation_Hall.Balance,Reservation_Hall.Notes, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType,Guest.IDNumber FROM Reservation_Hall INNER JOIN Guest ON Reservation_Hall.GuestID = Guest.ID where Reservation_Hall.BillNo='" & txtBillNo.Text & "'"
                            MyCommand1.CommandText = "SELECT * from Hotel"
                            MyCommand2.CommandText = "SELECT * from Currency"
                            MyCommand.CommandType = CommandType.Text
                            MyCommand1.CommandType = CommandType.Text
                            MyCommand2.CommandType = CommandType.Text
                            myDA.SelectCommand = MyCommand
                            myDA1.SelectCommand = MyCommand1
                            myDA2.SelectCommand = MyCommand2
                            myDA.Fill(myDS, "Guest")
                            myDA.Fill(myDS, "Reservation_Hall")
                            myDA1.Fill(myDS, "Hotel")
                            myDA2.Fill(myDS, "Currency")
                           
                            SendMail(rdr.GetValue(0), GID, "Please find the attachment below", pdfFile, "Hall Reservation Invoice", rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(0), Decrypt(rdr.GetValue(1)))
                            If (rdr IsNot Nothing) Then
                                rdr.Close()
                            End If
                        End If
                    End If
                End If
            End If
            If rbGarden.Checked = True Then
                auto()
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "insert into Reservation_garden( ID, BillNo, BillDate, GuestID,Type, Name, DateFrom, DateTo, Days, Rate,TotalCharges,OtherCharges, SubTotal, STPer, STAmount, LuxuryTaxPer,LuxuryTaxAmount, DiscountPer, DiscountAmount, GrandTotal, TotalPaid, Balance, Notes,Status) Values (" & txtBillID.Text & ",'" & txtBillNo.Text & "',@d5," & txtID.Text & ",'Garden',@d1,@d3,@d4," & txtNoOfDays.Text & "," & txtRate.Text & "," & txtTotalCharges.Text & "," & txtOtherCharges.Text & "," & txtSubTotal.Text & "," & txtServiceTaxPer.Text & "," & txtServiceTaxAmount.Text & "," & txtLuxuryTaxPer.Text & "," & txtLuxuryTaxAmount.Text & "," & txtDiscountPer.Text & "," & txtDiscount.Text & " ," & txtGrandTotal.Text & "," & txtTotalPaid.Text & "," & txtBalance.Text & ",@d2,'Confirmed')"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", cmbName.Text)
                cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
                cmd.Parameters.AddWithValue("@d4", DateTo.Value.Date)
                cmd.Parameters.AddWithValue("@d3", DateFrom.Value.Date)
                cmd.Parameters.AddWithValue("@d5", dtpBillDate.Value)
                cmd.ExecuteReader()
                con.Close()
                LedgerSave(dtpBillDate.Value.Date, txtGuestName.Text, txtBillNo.Text, "Garden Reservation", Val(txtGrandTotal.Text), 0, txtGuestID.Text)
                LedgerSave(dtpBillDate.Value.Date, "Cash Account", txtBillNo.Text, "Payment", 0, Val(txtTotalPaid.Text), txtGuestID.Text)
                Dim st As String = "Reserved the garden '" & cmbName.Text & "' with bill no. '" & txtBillNo.Text & "'"
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
                        Dim st3 As String = "Hello, " & txtGuestName.Text & " you have successfully reserved the garden having reservation no. " & txtBillNo.Text & ""
                        SMSFunc(txtGuestContactNo.Text.Trim, st3, st2)
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                    End If
                    con.Close()
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
                            If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                                System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                            End If
                            Dim pdfFile As String = Application.StartupPath & "\PDF Reports\GardenReservationInvoice " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
                            '  Dim rpt As New rptGardenInvoice 'The report you created.
                            Dim myConnection As SqlConnection
                            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
                            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
                            Dim myDS As New DataSet 'The DataSet you created.
                            myConnection = New SqlConnection(cs)
                            MyCommand.Connection = myConnection
                            MyCommand1.Connection = myConnection
                            MyCommand2.Connection = myConnection
                            MyCommand.CommandText = "SELECT Reservation_Garden.BillNo, Reservation_Garden.BillDate, Reservation_Garden.GuestID, Reservation_Garden.Type, Reservation_Garden.Name, Reservation_Garden.DateFrom, Reservation_Garden.DateTo,Reservation_Garden.Days, Reservation_Garden.Rate, Reservation_Garden.TotalCharges, Reservation_Garden.DiscountPer, Reservation_Garden.DiscountAmount, Reservation_Garden.OtherCharges, Reservation_Garden.SubTotal,Reservation_Garden.STPer, Reservation_Garden.STAmount, Reservation_Garden.LuxuryTaxPer, Reservation_Garden.LuxuryTaxAmount, Reservation_Garden.GrandTotal, Reservation_Garden.TotalPaid, Reservation_Garden.Balance,Reservation_Garden.Notes, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType,Guest.IDNumber FROM Reservation_Garden INNER JOIN Guest ON Reservation_Garden.GuestID = Guest.ID where Reservation_Garden.BillNo='" & txtBillNo.Text & "'"
                            MyCommand1.CommandText = "SELECT * from Hotel"
                            MyCommand2.CommandText = "SELECT * from Currency"
                            MyCommand.CommandType = CommandType.Text
                            MyCommand1.CommandType = CommandType.Text
                            MyCommand2.CommandType = CommandType.Text
                            myDA.SelectCommand = MyCommand
                            myDA1.SelectCommand = MyCommand1
                            myDA2.SelectCommand = MyCommand2
                            myDA.Fill(myDS, "Guest")
                            myDA.Fill(myDS, "Reservation_Garden")
                            myDA1.Fill(myDS, "Hotel")
                            myDA2.Fill(myDS, "Currency")
                           
                            SendMail(rdr.GetValue(0), GID, "Please find the attachment below", pdfFile, "Garden Reservation Invoice", rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(0), Decrypt(rdr.GetValue(1)))
                            If (rdr IsNot Nothing) Then
                                rdr.Close()
                            End If
                        End If
                    End If
                End If
            End If
            btnSave.Enabled = False
            btnPrint.Enabled = True
            MessageBox.Show("Successfully Reserved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DateTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTo.Validating
        If (DateTo.Value.Date < DateFrom.Value.Date) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTo.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtGuestID.Text)) = 0 Then
            MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtGuestID.Focus()
            Exit Sub
        End If
        If rbGarden.Checked = False And rbHall.Checked = False Then
            MessageBox.Show("Please select type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Len(Trim(cmbName.Text)) = 0 Then
            MessageBox.Show("Please select hall/garden name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtOtherCharges.Text)) = 0 Then
            MessageBox.Show("Please enter other charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOtherCharges.Focus()
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
            MessageBox.Show("Please enter discount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDiscountPer.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTotalPaid.Text)) = 0 Then
            MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTotalPaid.Focus()
            Exit Sub
        End If
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPaid.Text = ""
            txtTotalPaid.Focus()
            Exit Sub
        End If
        If rbHall.Checked = True Then
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Reservation_Hall Set  BillNo='" & txtBillNo.Text & "',GuestID=" & txtID.Text & ",Name=@d1,DateFrom=@d3,DateTo=@d4,Days=" & txtNoOfDays.Text & ",Rate=" & txtRate.Text & ",TotalCharges=" & txtTotalCharges.Text & ",OtherCharges=" & txtOtherCharges.Text & ",SubTotal=" & txtSubTotal.Text & ",STPer=" & txtServiceTaxPer.Text & ",STAmount=" & txtServiceTaxAmount.Text & ",LuxuryTaxPer=" & txtLuxuryTaxPer.Text & ",LuxuryTaxAmount=" & txtLuxuryTaxAmount.Text & ",DiscountPer=" & txtDiscountPer.Text & ",DiscountAmount=" & txtDiscount.Text & ",GrandTotal=" & txtGrandTotal.Text & ",TotalPaid=" & txtTotalPaid.Text & ",Balance=" & txtBalance.Text & ",Notes=@d2 where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbName.Text)
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d4", DateTo.Value.Date)
            cmd.Parameters.AddWithValue("@d3", DateFrom.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            'Dim cb As String = "Update LedgerBook set Date=@d1, Name=@d2,Debit=@d3,Credit=@d4,PartyID=@d5 where LedgerNo=@d6 and Label=@d7"
            LedgerUpdate(dtpBillDate.Value.Date, txtGuestName.Text, Val(txtGrandTotal.Text), 0, txtGuestID.Text, txtBillNo.Text, "Hall Reservation")
            LedgerUpdate(dtpBillDate.Value.Date, "Cash Account", 0, Val(txtTotalPaid.Text), txtGuestID.Text, txtBillNo.Text, "Payment")
            Dim st As String = "Updated the record of the hall '" & cmbName.Text & "' having bill no. '" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
        End If
        If rbGarden.Checked = True Then
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Reservation_Garden Set BillNo='" & txtBillNo.Text & "',GuestID=" & txtID.Text & ",Name=@d1,DateFrom=@d3,DateTo=@d4,Days=" & txtNoOfDays.Text & ",Rate=" & txtRate.Text & ",TotalCharges=" & txtTotalCharges.Text & ",OtherCharges=" & txtOtherCharges.Text & ",SubTotal=" & txtSubTotal.Text & ",STPer=" & txtServiceTaxPer.Text & ",STAmount=" & txtServiceTaxAmount.Text & ",LuxuryTaxPer=" & txtLuxuryTaxPer.Text & ",LuxuryTaxAmount=" & txtLuxuryTaxAmount.Text & ",DiscountPer=" & txtDiscountPer.Text & ",DiscountAmount=" & txtDiscount.Text & ",GrandTotal=" & txtGrandTotal.Text & ",TotalPaid=" & txtTotalPaid.Text & ",Balance=" & txtBalance.Text & ",Notes=@d2 where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbName.Text)
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d4", DateTo.Value.Date)
            cmd.Parameters.AddWithValue("@d3", DateFrom.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            LedgerUpdate(dtpBillDate.Value.Date, txtGuestName.Text, Val(txtGrandTotal.Text), 0, txtGuestID.Text, txtBillNo.Text, "Garden Reservation")
            LedgerUpdate(dtpBillDate.Value.Date, "Cash Account", 0, Val(txtTotalPaid.Text), txtGuestID.Text, txtBillNo.Text, "Payment")
            Dim st As String = "updated the record of garden '" & cmbName.Text & "' having bill no. '" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
        End If
        btnUpdate.Enabled = False
        MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        
    End Sub

    Private Sub btnAvailability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvailability.Click
        Try

            If Len(Trim(cmbName.Text)) = 0 Then
                MessageBox.Show("Please select garden/hall", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbName.Focus()
                Exit Sub
            End If
            If rbHall.Checked = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct2 As String = "SELECT * FROM Reservation_Hall WHERE DateFrom <= @d1 AND DateTo >= @d2 and Name=@d3 and Status='Confirmed'"
                cmd = New SqlCommand(ct2)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", DateTo.Value.Date)
                cmd.Parameters.AddWithValue("@d2", DateFrom.Value.Date)
                cmd.Parameters.AddWithValue("@d3", cmbName.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Selected Hall is already reserved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Selected Hall is available for reserve", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            End If
            If rbGarden.Checked = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct2 As String = "SELECT * FROM Reservation_Garden WHERE DateFrom <= @d1 AND DateTo >= @d2 and Name=@d3 and Status='Confirmed'"
                cmd = New SqlCommand(ct2)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", DateTo.Value.Date)
                cmd.Parameters.AddWithValue("@d2", DateFrom.Value.Date)
                cmd.Parameters.AddWithValue("@d3", cmbName.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Selected garden is already reserved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Selected garden is available for reserve", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
      

        If rbGarden.Checked = True Then
            Try
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                ' Dim rpt As New rptGardenInvoice 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
                Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
                MyCommand2.Connection = myConnection
                MyCommand.CommandText = "SELECT Reservation_Garden.BillNo, Reservation_Garden.BillDate, Reservation_Garden.GuestID, Reservation_Garden.Type, Reservation_Garden.Name, Reservation_Garden.DateFrom, Reservation_Garden.DateTo,Reservation_Garden.Days, Reservation_Garden.Rate, Reservation_Garden.TotalCharges, Reservation_Garden.DiscountPer, Reservation_Garden.DiscountAmount, Reservation_Garden.OtherCharges, Reservation_Garden.SubTotal,Reservation_Garden.STPer, Reservation_Garden.STAmount, Reservation_Garden.LuxuryTaxPer, Reservation_Garden.LuxuryTaxAmount, Reservation_Garden.GrandTotal, Reservation_Garden.TotalPaid, Reservation_Garden.Balance,Reservation_Garden.Notes, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType,Guest.IDNumber FROM Reservation_Garden INNER JOIN Guest ON Reservation_Garden.GuestID = Guest.ID where Reservation_Garden.BillNo='" & txtBillNo.Text & "'"
                MyCommand1.CommandText = "SELECT * from Hotel"
                MyCommand2.CommandText = "SELECT * from Currency"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                MyCommand2.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA2.SelectCommand = MyCommand2
                myDA.Fill(myDS, "Guest")
                myDA.Fill(myDS, "Reservation_Garden")
                myDA1.Fill(myDS, "Hotel")
                myDA2.Fill(myDS, "Currency")
        
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnCancelReservation_Click(sender As Object, e As EventArgs) Handles btnCancelReservation.Click
        Try

            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If
            If (txtStatus.Text = "Cancelled") Then
                MessageBox.Show("Reservation is already cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Today > DateTo.Value.Date Then
                MessageBox.Show("Reservation can not be cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If MessageBox.Show("Are you sure want to cancel this reservation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                If rbHall.Checked = True Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb As String = "update Reservation_Hall set Status='Cancelled' where ID=" & txtBillID.Text & ""
                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.ExecuteReader()
                    con.Close()
                    LedgerSave(dtpBillDate.Value.Date, txtGuestName.Text, txtBillNo.Text, "Hall Reservation Refund", 0, Val(txtGrandTotal.Text), txtGuestID.Text)
                    LedgerSave(dtpBillDate.Value.Date, "Cash Account", txtBillNo.Text, "Payment", Val(txtTotalPaid.Text), 0, txtGuestID.Text)
                End If
                If rbGarden.Checked = True Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb As String = "update Reservation_Garden set Status='Cancelled' where ID=" & txtBillID.Text & ""
                    cmd = New SqlCommand(cb)
                    cmd.Connection = con
                    cmd.ExecuteReader()
                    con.Close()
                    LedgerSave(dtpBillDate.Value.Date, txtGuestName.Text, txtBillNo.Text, "Garden Reservation Refund", 0, Val(txtGrandTotal.Text), txtGuestID.Text)
                    LedgerSave(dtpBillDate.Value.Date, "Cash Account", txtBillNo.Text, "Payment", Val(txtTotalPaid.Text), 0, txtGuestID.Text)
                End If
                Dim st As String = "cancelled the reservation having bill no.'" & txtBillNo.Text & "' of guest '" & txtGuestName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully cancelled", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelReservation.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmReservation_HallorGarden_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
       
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmGuest.Reset()
        frmGuest.lblUser.Text = lblUser.Text
        frmGuest.ShowDialog()
    End Sub
End Class
