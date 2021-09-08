Imports System.Data.SqlClient
Public Class frmLaundryBilling
    Dim num1, num2, num3, num4, num5, num6 As Double
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
    Sub fillServiceName()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ServiceName) FROM Laundry_Master", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbServiceName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbServiceName.Items.Add(drow(0).ToString())
            Next
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
        txtPaymentDue.Text = ""
        txtRate.Text = ""
        txtGrandTotal.Text = ""
        txtTotalPayment.Text = ""
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
        Clear()
        auto()
    End Sub



    Private Sub frmOrder1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillServiceName()
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
                DataGridView1.Rows.Add(cmbServiceName.Text, txtRate.Text, txtQty.Text, txtTotalAmt.Text)
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
            DataGridView1.Rows.Add(cmbServiceName.Text, txtRate.Text, txtQty.Text, txtTotalAmt.Text)
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
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
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
            MyCommand.CommandText = "SELECT Laundry_BillInfo.BillNo, Laundry_BillInfo.BillDate, Laundry_BillInfo.CheckInID, Laundry_BillInfo.GrandTotal, Laundry_BillInfo.TotalPayment, Laundry_BillInfo.PaymentDue, LaundryServices.LS_Id, LaundryServices.BillID, LaundryServices.Service, LaundryServices.Rate, LaundryServices.Qty, LaundryServices.TotalAmount, Laundry_Master.ServiceName,Laundry_Master.ChargesPerUnit, CheckIN_Room.Cin_Id, CheckIN_Room.GuestID, CheckIN_Room.RoomNo, CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson,CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.TaxPaidRate, CheckIN_Room.Notes, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr4,Room.RoomNo AS Expr5, Room.RoomType, Room.RoomCharges AS Expr6 FROM Laundry_BillInfo INNER JOIN LaundryServices ON Laundry_BillInfo.Id = LaundryServices.BillID INNER JOIN Laundry_Master ON LaundryServices.Service = Laundry_Master.ServiceName INNER JOIN CheckIN_Room ON Laundry_BillInfo.CheckInID = CheckIN_Room.Cin_Id INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Room ON CheckIN_Room.RoomNo = Room.RoomNo where Laundry_BillInfo.BillNo='" & txtBillNo.Text & "'"
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
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Button4.Focus()
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
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Laundry_BillInfo( Id, BillNo, BillDate, CheckInId, GrandTotal, TotalPayment, PaymentDue) Values (" & txtBillID.Text & ",'" & txtBillNo.Text & "',@d1," & txtCheckedInID.Text & "," & txtGrandTotal.Text & "," & txtTotalPayment.Text & "," & txtPaymentDue.Text & ")"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", dtpBillDate.Value)
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
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "added the new laundry billing record having bill no. '" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnSave.Enabled = False
            MessageBox.Show("Successfully done", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Print()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Button4.Focus()
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
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
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
            Dim st As String = "updated the laundry billing record having bill no '" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnUpdate.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        frmLaundryBillingRecord.lblSet.Text = "Laundry"
        frmLaundryBillingRecord.Reset()
        frmLaundryBillingRecord.ShowDialog()
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Compute()
    End Sub
End Class
