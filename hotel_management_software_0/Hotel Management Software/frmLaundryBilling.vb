Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmLaundryBilling
    Dim num1, num2, num3, num4, num5, num6, a As Double
    Dim st2, GID As String
    Sub Compute()
        Try

            num1 = CDbl(Val(txtRate.Text) * Val(txtQty.Text))
            num1 = Math.Round(num1, 2)
            txtTotalAmt.Text = num1
            Compute1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Compute1()
        Try
            Dim number As Double
            number = CDbl(Val(txtGrandTotal.Text) - Val(txtTotalPayment.Text))
            number = Math.Round(number, 2)
            txtPaymentDue.Text = number
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub Reset()
        txtBillID.Text = ""
        txtBillNo.Text = ""
        txtGuestID.Text = ""
        txtGuestName.Text = ""
        txtPaymentDue.Text = "0.00"
        txtRate.Text = ""
        txtGrandTotal.Text = "0.00"
        txtTotalPayment.Text = "0.00"
        txtRoomNo.Text = ""
        dtpBillDate.Text = Now
        dtpBillDate.Enabled = True
        DataGridView1.Rows.Clear()
        btnPrint.Enabled = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnAdd.Enabled = True
        btnRemove.Enabled = False
        cmbPaymentMode.Enabled = True
        cmbPaymentMode.SelectedIndex = 1
        txtTotalPayment.ReadOnly = True
        txtTotalPayment.Enabled = False
        btnListOfGuest.Enabled = True
        Clear()
        auto()
    End Sub



    Private Sub frmOrder1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtQty.Text = 0 Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(cmbServiceName.Text, Val(txtRate.Text), Val(txtQty.Text), Val(txtTotalAmt.Text))
                Dim k As Double = 0
                k = GrandTotal()
                k = Math.Round(k, 2)
                txtGrandTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(0).Value = cmbServiceName.Text Then
                    r.Cells(0).Value = cmbServiceName.Text
                    r.Cells(1).Value = txtRate.Text
                    r.Cells(2).Value = Val(r.Cells(2).Value) + Val(txtQty.Text)
                    r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtTotalAmt.Text)
                    Dim i As Double = 0
                    i = GrandTotal()
                    i = Math.Round(i, 2)
                    txtGrandTotal.Text = i
                    Clear()
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(cmbServiceName.Text, Val(txtRate.Text), Val(txtQty.Text), Val(txtTotalAmt.Text))
            Dim j As Double = 0
            j = GrandTotal()
            j = Math.Round(j, 2)
            txtGrandTotal.Text = j
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Clear()
        cmbServiceName.Text = ""
        txtRate.Text = ""
        txtQty.Text = ""
        txtTotalAmt.Text = ""
        cmbServiceName.Focus()
    End Sub

    Public Function GrandTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(3).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
        Reset()
    End Sub



    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Laundry_BillInfo")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "L" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "L" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListOfGuest.Click
        frmCheckInRecord.Reset()
        frmCheckInRecord.lblSet.Text = "Laundry Billing"
        frmCheckInRecord.ShowDialog()
    End Sub
    Sub Print()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptLaundryBillingInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Laundry_BillInfo.BillNo, Laundry_BillInfo.BillDate, Laundry_BillInfo.CheckInID, Laundry_BillInfo.GrandTotal, Laundry_BillInfo.TotalPayment, Laundry_BillInfo.PaymentDue, LaundryServices.LS_Id, LaundryServices.BillID, LaundryServices.Service, LaundryServices.Rate, LaundryServices.Qty, LaundryServices.TotalAmount, Laundry_Master.ServiceName,Laundry_Master.ChargesPerUnit, CheckIN_Room.Cin_Id, CheckIN_Room.GuestID, CheckIN_Room.RoomID, CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson,CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr4,Room.RoomNo, Room.RoomType, Room.RoomCharges AS Expr6 FROM Laundry_BillInfo INNER JOIN LaundryServices ON Laundry_BillInfo.Id = LaundryServices.BillID INNER JOIN Laundry_Master ON LaundryServices.Service = Laundry_Master.ServiceName INNER JOIN CheckIN_Room ON Laundry_BillInfo.CheckInID = CheckIN_Room.Cin_Id INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Room ON CheckIN_Room.RoomID = Room.R_ID where Laundry_BillInfo.BillNo='" & txtBillNo.Text & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "Laundry_BillInfo")
            myDA.Fill(myDS, "CheckIn_Room")
            myDA.Fill(myDS, "LaundryServices")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve Guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnListOfGuest.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("sorry no service added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Len(Trim(txtTotalPayment.Text)) = 0 Then
                MessageBox.Show("Please enter total payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPayment.Focus()
                Exit Sub
            End If
            If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPayment.Focus()
                Exit Sub
            End If
            If cmbPaymentMode.SelectedIndex = 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select ISNULL(sum(Amount)-Sum(Deduction),0) from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID and GuestLedger.GuestID=@d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", Val(txtG_ID.Text))
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    a = rdr.GetValue(0)
                Else
                    a = 0
                End If
                con.Close()
                If a >= Val(txtTotalPayment.Text) Then
                    auto1()
                    Dim string1 As String = "Paid for laundry services"
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cbx As String = "insert into GuestLedger( Id,GuestID,Amount,Deduction,Date,Details) Values (" & txtGuestLedgerID.Text & "," & txtG_ID.Text & ",0," & txtTotalPayment.Text & ",@d1,@d2)"
                    cmd = New SqlCommand(cbx)
                    cmd.Parameters.AddWithValue("@d1", Now)
                    cmd.Parameters.AddWithValue("@d2", string1)
                    cmd.Connection = con
                    cmd.ExecuteReader()
                    con.Close()
                Else
                    MessageBox.Show("Insufficient fund available in Guest's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Laundry_BillInfo( Id, BillNo, BillDate, CheckInId, GrandTotal, TotalPayment, PaymentDue,PaymentMode,LB_Status) Values (" & txtBillID.Text & ",'" & txtBillNo.Text & "',@d1," & txtCheckedInID.Text & "," & txtGrandTotal.Text & "," & txtTotalPayment.Text & "," & txtPaymentDue.Text & ",@d2,'Unpaid')"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", dtpBillDate.Value)
            cmd.Parameters.AddWithValue("@d2", cmbPaymentMode.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into LaundryServices(BillID,Service,Rate,Qty,TotalAmount) VALUES (" & txtBillID.Text & ",@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            LedgerSave(dtpBillDate.Value.Date, txtGuestName.Text, txtBillNo.Text, "Laundry Services", Val(txtGrandTotal.Text), 0, txtGuestID.Text)
            If Val(txtTotalPayment.Text) > 0 Then
                If cmbPaymentMode.Text = "By Cash" Or cmbPaymentMode.Text = "From Guest's Account" Then
                    LedgerSave(Convert.ToDateTime(dtpBillDate.Value), "Cash Account", txtBillNo.Text, "Payment", 0, Val(txtTotalPayment.Text), txtGuestID.Text)
                End If
                If cmbPaymentMode.Text = "From Guest's Account" Then
                    LedgerSave(Convert.ToDateTime(dtpBillDate.Value), txtGuestName.Text, txtBillNo.Text, "Guest's Account", Val(txtTotalPayment.Text), 0, txtGuestID.Text)
                End If
                If cmbPaymentMode.Text = "By Credit Card" Or cmbPaymentMode.Text = "By Debit Card" Then
                    LedgerSave(Convert.ToDateTime(dtpBillDate.Value), "Bank Account", txtBillNo.Text, "Payment", 0, Val(txtTotalPayment.Text), txtGuestID.Text)
                End If
            End If
            Dim st As String = "added the new laundry billing record having bill no. '" & txtBillNo.Text & "'"
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
                    Dim st3 As String = "Hello, " & txtGuestName.Text & " you have successfully placed the laundry order having order no. " & txtBillNo.Text & ""
                    SMSFunc(txtContactNo.Text.Trim, st3, st2)
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
                Dim str As String = "select IsNull(Email,0) from Guest where Guest.GuestID='" & txtGuestID.Text & "'"
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
                        Dim pdfFile As String = Application.StartupPath & "\PDF Reports\LaundryBillingInvoice " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
                        Dim rpt As New rptLaundryBillingInvoice 'The report you created.
                        Dim myConnection As SqlConnection
                        Dim MyCommand, MyCommand1 As New SqlCommand()
                        Dim myDA, myDA1 As New SqlDataAdapter()
                        Dim myDS As New DataSet 'The DataSet you created.
                        myConnection = New SqlConnection(cs)
                        MyCommand.Connection = myConnection
                        MyCommand1.Connection = myConnection
                        MyCommand.CommandText = "SELECT Laundry_BillInfo.BillNo, Laundry_BillInfo.BillDate, Laundry_BillInfo.CheckInID, Laundry_BillInfo.GrandTotal, Laundry_BillInfo.TotalPayment, Laundry_BillInfo.PaymentDue, LaundryServices.LS_Id, LaundryServices.BillID, LaundryServices.Service, LaundryServices.Rate, LaundryServices.Qty, LaundryServices.TotalAmount, Laundry_Master.ServiceName,Laundry_Master.ChargesPerUnit, CheckIN_Room.Cin_Id, CheckIN_Room.GuestID, CheckIN_Room.RoomID, CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson,CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr4,Room.RoomNo, Room.RoomType, Room.RoomCharges AS Expr6 FROM Laundry_BillInfo INNER JOIN LaundryServices ON Laundry_BillInfo.Id = LaundryServices.BillID INNER JOIN Laundry_Master ON LaundryServices.Service = Laundry_Master.ServiceName INNER JOIN CheckIN_Room ON Laundry_BillInfo.CheckInID = CheckIN_Room.Cin_Id INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Room ON CheckIN_Room.RoomID = Room.R_ID where Laundry_BillInfo.BillNo='" & txtBillNo.Text & "'"
                        MyCommand1.CommandText = "SELECT * from Hotel"
                        MyCommand.CommandType = CommandType.Text
                        MyCommand1.CommandType = CommandType.Text
                        myDA.SelectCommand = MyCommand
                        myDA1.SelectCommand = MyCommand1
                        myDA.Fill(myDS, "Guest")
                        myDA.Fill(myDS, "Room")
                        myDA.Fill(myDS, "Laundry_BillInfo")
                        myDA.Fill(myDS, "CheckIn_Room")
                        myDA.Fill(myDS, "LaundryServices")
                        myDA1.Fill(myDS, "Hotel")
                        rpt.SetDataSource(myDS)

                        rpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFile)
                        SendMail(rdr.GetValue(0), GID, "Please find the attachment below", pdfFile, "Laundry Biiling Invoice", rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(0), Decrypt(rdr.GetValue(1)))
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                    End If
                End If
            End If
            btnSave.Enabled = False
            MessageBox.Show("Successfully done", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Print()
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
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "delete from Laundry_BillInfo where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                LedgerDelete(txtBillNo.Text, "Laundry Services")
                LedgerDelete(txtBillNo.Text, "Payment")
                Dim st As String = "deleted the laundry billing record having bill no '" & txtBillNo.Text & "'"
                LogFunc(lblUser.Text, st)
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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub txtTotalPayment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPayment.TextChanged
        Compute1()
    End Sub

    Private Sub txtTotalPayment_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalPayment.Validating
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Exit Sub
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtGuestID.Text)) = 0 Then
            MessageBox.Show("Please retrieve Guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnListOfGuest.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(txtTotalPayment.Text)) = 0 Then
            MessageBox.Show("Please enter total payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTotalPayment.Focus()
            Exit Sub
        End If
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPayment.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Status from CheckIn_Room where Checkin_Room.Cin_ID=" & txtCheckedInID.Text & " and Status='Checked out'"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Updating record is not possible" & vbCrLf & "Guest is already checked out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If

            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "delete from LaundryServices where BillID=" & txtBillID.Text & ""
            cmd = New SqlCommand(ct1)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into LaundryServices(BillID,Service,Rate,Qty,TotalAmount) VALUES (" & txtBillID.Text & ",@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Laundry_BillInfo set CheckinID=" & txtCheckedInID.Text & ",GrandTotal=" & txtGrandTotal.Text & ",TotalPayment=" & txtTotalPayment.Text & ",PaymentDue=" & txtPaymentDue.Text & " where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            LedgerUpdate(dtpBillDate.Value.Date, "Cash Account", 0, Val(txtTotalPayment.Text), txtGuestID.Text, txtBillNo.Text, "Payment")
            Dim st As String = "updated the laundry billing record having bill no '" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnUpdate.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
       
    End Sub

    Private Sub txtQty_Liquor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtQty_Food_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        btnRemove.Enabled = True
    End Sub


    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal()
            k = Math.Round(k, 2)
            txtGrandTotal.Text = k
            Compute()
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Print()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub cmbServiceName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbServiceName.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT ChargesPerUnit FROM Laundry_Master WHERE ServiceName=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbServiceName.Text)
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
            txtQty.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Compute()
    End Sub


    Private Sub cmbPaymentMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPaymentMode.SelectedIndexChanged
        If cmbPaymentMode.Text = "Credit Order" Then
            txtTotalPayment.Text = "0.00"
            txtTotalPayment.ReadOnly = True
            txtTotalPayment.Enabled = False
        Else
            txtTotalPayment.Text = "0.00"
            txtTotalPayment.ReadOnly = False
            txtTotalPayment.Enabled = True
        End If
    End Sub
End Class
