Imports System.Data.SqlClient

Public Class frmAttendanceEntryRecord

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(EmployeeAttendance.ID) as [Attendance ID],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(EmployeeRegistration.BasicWorkingTime) as [Basic Working Time], Convert(DateTime,WorkingDate,103) as [Working Date],RTRIM(Status) as [Status], RTRIM(InTime) as [In Time],RTRIM(OutTime) as [Out Time],RTRIM(Overtime) as [Overtime] from employeeAttendance,EmployeeRegistration where EmployeeRegistration.ID=EmployeeAttendance.EmployeeID order by workingdate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeeAttendance")
            dgw.DataSource = myDataSet.Tables("EmployeeAttendance").DefaultView
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
                If lblSet.Text = "Attendance Entry" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmAttendance.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmAttendance.txtID.Text = dr.Cells(0).Value.ToString()
                frmAttendance.txtEmpID.Text = dr.Cells(1).Value.ToString()
                frmAttendance.EmployeeID.Text = dr.Cells(2).Value.ToString()
                frmAttendance.EmployeeName.Text = dr.Cells(3).Value.ToString()
                frmAttendance.BasicWorkingTime.Text = dr.Cells(4).Value.ToString()
                frmAttendance.WorkingDate.Text = dr.Cells(5).Value.ToString()
                frmAttendance.Status.Text = dr.Cells(6).Value.ToString()
                frmAttendance.InTime.Text = dr.Cells(7).Value.ToString()
                frmAttendance.OutTime.Text = dr.Cells(8).Value.ToString()
                frmAttendance.Overtime.Text = dr.Cells(9).Value.ToString()
                frmAttendance.btnSave.Enabled = False
                frmAttendance.btnUpdate.Enabled = True
                frmAttendance.btnDelete.Enabled = True
                    frmAttendance.WorkingDate.Enabled = False
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
            cmd = New SqlCommand("select RTRIM(EmployeeAttendance.ID) as [Attendance ID],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(EmployeeRegistration.BasicWorkingTime) as [Basic Working Time], Convert(DateTime,WorkingDate,103) as [Working Date],RTRIM(Status) as [Status], RTRIM(InTime) as [In Time],RTRIM(OutTime) as [Out Time],RTRIM(Overtime) as [Overtime] from employeeAttendance,EmployeeRegistration where EmployeeRegistration.ID=EmployeeAttendance.EmployeeID and EmployeeName like '%" & txtEmployeeName.Text & "%' order by workingdate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeeAttendance")
            dgw.DataSource = myDataSet.Tables("EmployeeAttendance").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("select RTRIM(EmployeeAttendance.ID) as [Attendance ID],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(EmployeeRegistration.BasicWorkingTime) as [Basic Working Time], Convert(DateTime,WorkingDate,103) as [Working Date],RTRIM(Status) as [Status], RTRIM(InTime) as [In Time],RTRIM(OutTime) as [Out Time],RTRIM(Overtime) as [Overtime] from employeeAttendance,EmployeeRegistration where EmployeeRegistration.ID=EmployeeAttendance.EmployeeID and WorkingDate Between @d1 and @d2 order by workingdate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = DateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = DateTo.Value
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeeAttendance")
            dgw.DataSource = myDataSet.Tables("EmployeeAttendance").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
