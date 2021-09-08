Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Public Class frmEmployeePayment








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
    Public Sub AutoGenerate()
        PaymentID.Text = "SP-" & GetUniqueKey(9)
    End Sub
    Sub Employeenameyoni()

        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (employeename) FROM employeeRegistration,EmployeePayment where EmployeeRegistration.EmployeeID=Employeepayment.EmployeeID", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            ComboBox1S.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                ComboBox1S.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
  
    Private Sub EmployeePayment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        frmMainMenu.Show()
    End Sub
    Sub GetData()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT (EmployeeRegistration.EmployeeName) as [Employee Name],(EmployeeRegistration.EmployeeID) as [Employee ID] FROM EmployeeRegistration left join EmployeePayment on EmployeeRegistration.EmployeeID=EmployeePayment.EmployeeID group by EmployeeRegistration.employeename,employeeregistration.employeeid order by EmployeeName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeePayment")
            DataGridView1.DataSource = myDataSet.Tables("EmployeePayment").DefaultView()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EmployeePayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Employeenameyoni()
        GetData()
        fillcombo()
    End Sub
    Sub fillcombo()

        Try
           
            Dim CN As New oledbConnection(cs)

            CN.Open()
            adp = New oledbDataAdapter()
            adp.SelectCommand = New oledbCommand("SELECT distinct  (employeeid) FROM employeeregistration", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            EmployeeID.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                EmployeeID.Items.Add(drow(0).ToString())

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeID.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "select employeename,salary,designation,department from employeeregistration where employeeid=@find"

            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "employeeid"))
            cmd.Parameters("@find").Value = Trim(EmployeeID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                EmployeeName.Text = Trim(rdr.GetString(0))
                BasicSalary.Text = Trim(rdr.GetInt32(1))
                Designation.Text = Trim(rdr.GetString(2))
                Department.Text = Trim(rdr.GetString(3))
            End If

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            con.Close()
            con.Open()
            Dim cp As String = "select count(status) from employeeattendance where WorkingDate between #" & DateFrom.Value & "# And #" & DateTo.Value & "# and status='P' and  employeeid=@find "
            cmd = New OleDbCommand(cp)
            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "employeeid"))
            cmd.Parameters("@find").Value = Trim(EmployeeID.Text)
            Dim result = cmd.ExecuteScalar()
            PresentDays.Text = Convert.ToString(result)

            Salary.Text = CInt((Val(BasicSalary.Text) * Val(PresentDays.Text)) / 30)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Open()
            Dim cp1 As String = "select sum(amount)-sum(deduction) from advanceentry where employeeid=@find"

            cmd = New OleDbCommand(cp1)
            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "employeeid"))
            cmd.Parameters("@find").Value = Trim(EmployeeID.Text)
            Dim result1 = cmd.ExecuteScalar()
            Advance.Text = Convert.ToString(result1)
            If Advance.Text = Nothing Then
                Advance.Text = 0
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd = New OleDbCommand("select (Overtime) as [Overtime] from employeeAttendance where WorkingDate between #" & DateFrom.Value & "# And #" & DateTo.Value & "# and EmployeeId='" & EmployeeID.Text & "'", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeAttendance")

            Dim sumHour As Integer = 0

            Dim sumMinute As Integer = 0

            Dim sumSecond As Integer = 0

            For Each dr As DataRow In myDataSet.Tables("EmployeeAttendance").Rows

                Dim tim As TimeSpan = TimeSpan.Parse(dr("Overtime").ToString())


                sumHour += tim.Hours

                sumMinute += tim.Minutes

                sumSecond += tim.Seconds

            Next



            Dim sp As New TimeSpan(sumHour, sumMinute, sumSecond)

            Me.Overtime.Text = sp.ToString()

            con.Close()


            Deduction.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        DateFrom.value = Today
        DateTo.value = Today
        EmployeeID.Text = ""
        EmployeeName.Text = ""
        Designation.Text = ""
        Department.Text = ""
        Salary.Text = ""
        PresentDays.Text = ""
        Advance.Text = ""
        Deduction.Text = ""
        Overtime.Text = ""
        OvertimeRate.Text = ""
        OvertimeAmount.Text = ""
        PaymentDate.Text = Today
        paymentmode.Text = ""
        PaymentModeDetails.Text = ""
        NetPay.Text = ""
        PaymentID.Text = ""
        txtEmployee.Text = ""
        GetData()
        Save.Enabled = True
        Delete.Enabled = False
        Update_Record.Enabled = False
        btnSlip.Enabled = False
    End Sub
    Private Sub NewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRecord.Click
        Reset()
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvertimeAmount.TextChanged
        NetPay.Text = CInt(Val(Salary.Text) + Val(OvertimeAmount.Text) - Val(Deduction.Text))
    End Sub

    Private Sub OvertimeRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OvertimeRate.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub

    Private Sub OvertimeRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvertimeRate.TextChanged
        Dim ts As TimeSpan
        If TimeSpan.TryParse(Overtime.Text, ts) Then
            Dim rate As Integer
            If Integer.TryParse(OvertimeRate.Text, rate) Then
                OvertimeAmount.Text = CInt((ts.TotalMinutes * rate) / 60)
            End If

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlip.Click
        If Me.EmployeeID.Text = "" Then
            MessageBox.Show("Please select employee id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.EmployeeID.Focus()
            Exit Sub
        End If
       
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptSalarySlip() 'The report you created.
            Dim myConnection As OleDbConnection
            Dim MyCommand As New OleDbCommand()
            Dim myDA As New OleDbDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New OleDbConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "select PaymentID,Datefrom,dateTo,EmployeeRegistration.employeeid,employeename,designation,department,EmployeePayment.salary,presentdays,advance,deduction,overtime,overtimeamount,paymentdate,modeofpayment,netpay from EmployeePayment,EmployeeRegistration where EmployeeRegistration.EmployeeID=EmployeePayment.EmployeeID and PaymentID='" & PaymentID.Text & "'"
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "EmployeePayment")
            myDA.Fill(myDS, "EmployeeRegistration")
            rpt.SetDataSource(myDS)
            frmSalarySlip.CrystalReportViewer1.ReportSource = rpt
            frmSalarySlip.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        Try
            If Len(Trim(EmployeeID.Text)) = 0 Then
                MessageBox.Show("Please select employee id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                EmployeeID.Focus()
                Exit Sub
            End If

            If Len(Trim(OvertimeRate.Text)) = 0 Then
                MessageBox.Show("Please enter overtime rate", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                OvertimeRate.Focus()
                Exit Sub
            End If
            If Len(Trim(paymentmode.Text)) = 0 Then
                MessageBox.Show("Please select payment mode", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                paymentmode.Focus()
                Exit Sub
            End If
            If OvertimeAmount.Text = Nothing Then
                OvertimeAmount.Text = 0
            End If
            If Advance.Text = Nothing Then
                Advance.Text = 0
            End If
            If Val(Advance.Text) < Val(Deduction.Text) Then
                MessageBox.Show("You can not deduct amount more than advance amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Deduction.Focus()
                Exit Sub
            End If
            If Val(NetPay.Text) < 0 Then
                MessageBox.Show("net pay should be more than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "select employeeid,paymentdate from employeepayment where employeeid='" & EmployeeID.Text & "' and paymentdate= #" & PaymentDate.Text & "#"

            cmd = New OleDbCommand(ct)
            cmd.Connection = con

            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Employee is already paid today", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                EmployeeID.Focus()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If

            Else
                con = New OleDbConnection(cs)
                con.Open()
                AutoGenerate()
                Dim cb As String = "insert into employeepayment(PaymentID,DateFrom,DateTo,EmployeeID,PresentDays,Salary,Advance,Deduction,OverTime,OverTimeRate,OverTimeAmount,PaymentDate,ModeOfPayment,PaymentModeDetails,Netpay) values('" & PaymentID.Text & "','" & DateFrom.Text & "','" & DateTo.Text & "','" & EmployeeID.Text & "'," & PresentDays.Text & "," & Salary.Text & "," & Advance.Text & "," & Deduction.Text & ",'" & Overtime.Text & "'," & OvertimeRate.Text & "," & OvertimeAmount.Text & ",'" & PaymentDate.Text & "','" & paymentmode.Text & "','" & PaymentModeDetails.Text & "'," & NetPay.Text & ")"
                cmd = New OleDbCommand(cb)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                con.Close()
                con = New OleDbConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into advanceentry(workingdate,employeeid,amount,deduction) VALUES (@d1,@d2,@d3,@d4)"

                cmd = New OleDbCommand(cb1)

                cmd.Connection = con

                cmd.Parameters.Add(New OleDbParameter("@d1", OleDbType.VarChar, 30, "workingdate"))
                cmd.Parameters.Add(New OleDbParameter("@d2", OleDbType.VarChar, 30, "employeeid"))
                cmd.Parameters.Add(New OleDbParameter("@d3", OleDbType.Integer, 10, "amount"))
                cmd.Parameters.Add(New OleDbParameter("@d4", OleDbType.Integer, 10, "deduction"))
                cmd.Parameters("@d1").Value = PaymentDate.Text
                cmd.Parameters("@d2").Value = EmployeeID.Text
                cmd.Parameters("@d3").Value = 0
                cmd.Parameters("@d4").Value = CInt(Deduction.Text)
                cmd.ExecuteReader()
                Save.Enabled = False
                btnSlip.Enabled = True
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Deduction_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Deduction.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub

    Private Sub Deduction_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Deduction.TextChanged
        NetPay.Text = Val(Salary.Text) + Val(OvertimeAmount.Text) - Val(Deduction.Text)
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try

            If MessageBox.Show("Do you really want to delete the records?" & vbCrLf & "You can not restore the records" & vbCrLf & "It will delete all the records permanently" & vbCrLf & "related to selected employee", "Payment Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                delete_records()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub delete_records()
        Try
            Dim RowsAffected As Integer = 0
            con = New OleDbConnection(cs)

            con.Open()
            Dim cq As String = "delete from employeepayment where PaymentID=@DELETE1;"
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@DELETE1", OleDbType.VarChar, 30, "PaymentID"))
            cmd.Parameters("@DELETE1").Value = Trim(PaymentID.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                If con.State = ConnectionState.Open Then

                    con.Close()
                End If

                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Update_Record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_Record.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()

            Dim cb As String = "update employeepayment set datefrom=#" & DateFrom.Value & "#,dateto=#" & DateTo.Value & "#,employeeid='" & EmployeeID.Text & "',presentdays=" & PresentDays.Text & ",advance=" & Advance.Text & ",deduction=" & Deduction.Text & ",overtime='" & Overtime.Text & "',overtimerate=" & OvertimeRate.Text & ",overtimeamount=" & OvertimeAmount.Text & ",paymentdate=#" & PaymentDate.Text & "#,modeofpayment='" & paymentmode.Text & "',paymentmodedetails='" & PaymentModeDetails.Text & "',netpay=" & NetPay.Text & " where PaymentID='" & PaymentID.Text & "'"

            cmd = New oledbCommand(cb)

            cmd.Connection = con

            If MessageBox.Show("Are you sure want to update the record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Update_Record.Enabled = False

            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.EmployeeID.Text = dr.Cells(1).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtEmployee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployee.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT (EmployeeRegistration.EmployeeName) as [Employee Name],(EmployeeRegistration.EmployeeID) as [Employee ID] FROM EmployeeRegistration left join EmployeePayment on EmployeeRegistration.EmployeeID=EmployeePayment.EmployeeID where EmployeeName like '" & txtEmployee.Text & "%' group by EmployeeRegistration.employeename,employeeregistration.employeeid order by EmployeeName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeePayment")
            DataGridView1.DataSource = myDataSet.Tables("EmployeePayment").DefaultView()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Close()
    End Sub

    Private Sub ComboBox1S_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1S.SelectedIndexChanged
        Try

            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (PaymentID) as [Payment ID],(DateFrom) as [Date From],(dateto) as [Date To],(EmployeeRegistration.employeeid) as [Employee ID],(Employeename) as [Employee Name],(designation) as [Designation],(department) as [Department],(EmployeePayment.salary) as [Salary],(presentdays) as [Prsesent Days],(advance) as [Advance],(deduction) as [Deduction],(overtime) as [Overtime],(overtimerate)as [Overtime Rate],(overtimeamount) as [Overtime Amount],(paymentdate) as [Payment Date],(modeofpayment) as [Payment Mode],(paymentmodedetails) as [Payment Mode Details],(netpay) as [Net Pay] from employeepayment,EmployeeRegistration where EmployeeRegistration.EmployeeID=EmployeePayment.EmployeeID and Employeename = '" & ComboBox1S.Text & "'order by paymentdate", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeePayment")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            StaffRecord.DataSource = myDataSet.Tables("EmployeePayment").DefaultView
            StaffRecord.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub StaffRecord_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles StaffRecord.RowHeaderMouseClick
        Try

            Dim dr As DataGridViewRow = StaffRecord.SelectedRows(0)
            Me.PaymentID.Text = dr.Cells(0).Value.ToString()
            Me.DateFrom.Text = dr.Cells(1).Value.ToString()
            Me.DateTo.Text = dr.Cells(2).Value.ToString()
            Me.EmployeeID.Text = dr.Cells(3).Value.ToString()
            Me.EmployeeName.Text = dr.Cells(4).Value.ToString()
            Me.Designation.Text = dr.Cells(5).Value.ToString()
            Me.Department.Text = dr.Cells(6).Value.ToString()
            Me.Salary.Text = dr.Cells(7).Value.ToString()
            Me.PresentDays.Text = dr.Cells(8).Value.ToString()
            Me.Advance.Text = dr.Cells(9).Value.ToString()
            Me.Deduction.Text = dr.Cells(10).Value.ToString()
            Me.Overtime.Text = dr.Cells(11).Value.ToString()
            Me.OvertimeRate.Text = dr.Cells(12).Value.ToString()
            Me.OvertimeAmount.Text = dr.Cells(13).Value.ToString()
            Me.PaymentDate.Text = dr.Cells(14).Value.ToString()
            Me.paymentmode.Text = dr.Cells(15).Value.ToString()
            Me.PaymentModeDetails.Text = dr.Cells(16).Value.ToString()
            Me.NetPay.Text = dr.Cells(17).Value.ToString()
            Me.Save.Enabled = False
            Me.Delete.Enabled = True
            Me.Update_Record.Enabled = True
            Me.btnSlip.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    
End Class