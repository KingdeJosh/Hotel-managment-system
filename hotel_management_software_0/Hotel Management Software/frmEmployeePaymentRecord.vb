Imports System.Data.SqlClient

Public Class frmEmployeePaymentRecord

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(EmployeePayment.ID) as [ID],(PaymentID) as [Payment ID],Convert(DateTime,DateFrom,103) as [Date From],Convert(DateTime,dateto,103) as [Date To],RTRIM(EmployeeRegistration.id) as [Emp ID],RTRIM(EmployeeRegistration.employeeid) as [Employee ID],RTRIM(Employeename) as [Employee Name],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(EmployeePayment.salary) as [Salary],RTRIM(presentdays) as [Prsesent Days],RTRIM(advance) as [Advance],RTRIM(deduction) as [Deduction],RTRIM(overtime) as [Overtime],RTRIM(overtimerate) as [Overtime Rate],RTRIM(overtimeamount) as [Overtime Amount],Convert(DateTime,paymentdate,131) as [Payment Date],RTRIM(modeofpayment) as [Payment Mode],RTRIM(paymentmodedetails) as [Payment Mode Details],RTRIM(netpay) as [Net Pay] from employeepayment,EmployeeRegistration where EmployeeRegistration.ID=EmployeePayment.EmployeeID order by paymentdate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeePayment")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            dgw.DataSource = myDataSet.Tables("EmployeePayment").DefaultView
            dgw.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Sub Reset()
        txtEmployeeName.Text = ""
        DateFrom.Text = Today
        DateTo.Text = Now
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Payment" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmEmployeePayment.txtID.Text = dr.Cells(0).Value.ToString()
                frmEmployeePayment.PaymentID.Text = dr.Cells(1).Value.ToString()
                frmEmployeePayment.DateFrom.Text = dr.Cells(2).Value.ToString()
                frmEmployeePayment.DateTo.Text = dr.Cells(3).Value.ToString()
                frmEmployeePayment.txtEmpID.Text = dr.Cells(4).Value.ToString()
                frmEmployeePayment.EmployeeID.Text = dr.Cells(5).Value.ToString()
                frmEmployeePayment.EmployeeName.Text = dr.Cells(6).Value.ToString()
                frmEmployeePayment.Designation.Text = dr.Cells(8).Value.ToString()
                frmEmployeePayment.Department.Text = dr.Cells(7).Value.ToString()
                con = New SqlConnection(cs)
                con.Open()
                Dim cp1 As String = "select Salary from EmployeeRegistration where id=" & dr.Cells(4).Value & ""
                cmd = New SqlCommand(cp1)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    frmEmployeePayment.txtSalary.Text = rdr.GetValue(0)
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                frmEmployeePayment.Salary.Text = dr.Cells(9).Value.ToString()
                frmEmployeePayment.PresentDays.Text = dr.Cells(10).Value.ToString()
                frmEmployeePayment.Advance.Text = dr.Cells(11).Value.ToString()
                frmEmployeePayment.Deduction.Text = dr.Cells(12).Value.ToString()
                frmEmployeePayment.Overtime.Text = dr.Cells(13).Value.ToString()
                frmEmployeePayment.OvertimeRate.Text = dr.Cells(14).Value.ToString()
                frmEmployeePayment.OvertimeAmount.Text = dr.Cells(15).Value.ToString()
                frmEmployeePayment.PaymentDate.Text = dr.Cells(16).Value.ToString()
                frmEmployeePayment.paymentmode.Text = dr.Cells(17).Value.ToString()
                frmEmployeePayment.PaymentModeDetails.Text = dr.Cells(18).Value.ToString()
                frmEmployeePayment.NetPay.Text = dr.Cells(19).Value.ToString()
                frmEmployeePayment.btnSave.Enabled = False
                frmEmployeePayment.btnDelete.Enabled = True
                frmEmployeePayment.btnUpdate.Enabled = True
                frmEmployeePayment.btnPrint.Enabled = True
                frmEmployeePayment.DateFrom.Enabled = False
                frmEmployeePayment.DateTo.Enabled = False
                frmEmployeePayment.PaymentDate.Enabled = False
                frmEmployeePayment.Deduction.ReadOnly = True
                frmEmployeePayment.dgw.Enabled = False
                    lblSet.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlLightLight
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub txtEmployeeName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmployeeName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(EmployeePayment.ID) as [ID],(PaymentID) as [Payment ID],Convert(DateTime,DateFrom,103) as [Date From],Convert(DateTime,dateto,103) as [Date To],RTRIM(EmployeeRegistration.id) as [Emp ID],RTRIM(EmployeeRegistration.employeeid) as [Employee ID],RTRIM(Employeename) as [Employee Name],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(EmployeePayment.salary) as [Salary],RTRIM(presentdays) as [Prsesent Days],RTRIM(advance) as [Advance],RTRIM(deduction) as [Deduction],RTRIM(overtime) as [Overtime],RTRIM(overtimerate) as [Overtime Rate],RTRIM(overtimeamount) as [Overtime Amount],Convert(DateTime,paymentdate,131) as [Payment Date],RTRIM(modeofpayment) as [Payment Mode],RTRIM(paymentmodedetails) as [Payment Mode Details],RTRIM(netpay) as [Net Pay] from employeepayment,EmployeeRegistration where EmployeeRegistration.ID=EmployeePayment.EmployeeID and Employeename like '%" & txtEmployeeName.Text & "%' order by paymentdate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeePayment")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            dgw.DataSource = myDataSet.Tables("EmployeePayment").DefaultView
            dgw.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(EmployeePayment.ID) as [ID],(PaymentID) as [Payment ID],Convert(DateTime,DateFrom,103) as [Date From],Convert(DateTime,dateto,103) as [Date To],RTRIM(EmployeeRegistration.id) as [Emp ID],RTRIM(EmployeeRegistration.employeeid) as [Employee ID],RTRIM(Employeename) as [Employee Name],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(EmployeePayment.salary) as [Salary],RTRIM(presentdays) as [Prsesent Days],RTRIM(advance) as [Advance],RTRIM(deduction) as [Deduction],RTRIM(overtime) as [Overtime],RTRIM(overtimerate) as [Overtime Rate],RTRIM(overtimeamount) as [Overtime Amount],Convert(DateTime,paymentdate,131) as [Payment Date],RTRIM(modeofpayment) as [Payment Mode],RTRIM(paymentmodedetails) as [Payment Mode Details],RTRIM(netpay) as [Net Pay] from employeepayment,EmployeeRegistration where EmployeeRegistration.ID=EmployeePayment.EmployeeID and PaymentDate Between @d1 and @d2 order by paymentdate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = DateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = DateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeePayment")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            dgw.DataSource = myDataSet.Tables("EmployeePayment").DefaultView
            dgw.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
