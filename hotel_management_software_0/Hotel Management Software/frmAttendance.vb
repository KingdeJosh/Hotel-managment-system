Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class frmAttendance
    Sub Reset()
        WorkingDate.Text = Today
        EmployeeID.Text = ""
        EmployeeName.Text = ""
        InTime.Text = Now
        OutTime.Text = Now
        Overtime.Text = ""
        Status.SelectedIndex = -1
        BasicWorkingTime.Text = ""
        txtEmployee.Text = ""
        GetData()
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        txtOutTime.Visible = False
        txtInTime.Visible = False
        btnSave.Enabled = True
        WorkingDate.Enabled = True
        InTime.Enabled = False
        OutTime.Enabled = False
    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT RTRIM(EmployeeRegistration.ID),RTRIM(EmployeeRegistration.EmployeeID),RTRIM(EmployeeName),RTRIM(BasicWorkingTime) from EmployeeRegistration where Active='Yes' order by EmployeeName"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(EmployeeID.Text)) = 0 Then
            MessageBox.Show("Please retrieve employee id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EmployeeID.Focus()
            Exit Sub
        End If
        If Len(Trim(Status.Text)) = 0 Then
            MessageBox.Show("Please select Status", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Status.Focus()
            Exit Sub
        End If
        If Len(Trim(Overtime.Text)) = 0 Then
            MessageBox.Show("Please select retrieve overtime", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Overtime.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select employeeid,workingdate from employeeattendance where employeeid=" & txtEmpID.Text & " and workingdate=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(WorkingDate.Value.Date))
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Employee today's attendance is already saved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            auto()
          
            Dim st As String = "added the new attendance entry having id '" & txtID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
            GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(EmployeeID.Text)) = 0 Then
            MessageBox.Show("Please retrieve employee id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EmployeeID.Focus()
            Exit Sub
        End If
        If Len(Trim(Status.Text)) = 0 Then
            MessageBox.Show("Please select Status", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Status.Focus()
            Exit Sub
        End If
        If Len(Trim(Overtime.Text)) = 0 Then
            MessageBox.Show("Please select retrieve overtime", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Overtime.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update employeeAttendance set employeeid=@d2,status=@d3,intime=@d4,outtime=@d5,overtime=@d6,basicworkingtime=@d7 where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d2", Val(txtEmpID.Text))
            cmd.Parameters.AddWithValue("@d3", Status.Text)
            If Status.Text = "P" Then
                cmd.Parameters.AddWithValue("@d4", InTime.Text)
                cmd.Parameters.AddWithValue("@d5", OutTime.Text)
            ElseIf Status.Text = "A" Then
                cmd.Parameters.AddWithValue("@d4", txtInTime.Text)
                cmd.Parameters.AddWithValue("@d5", txtOutTime.Text)
            End If
            cmd.Parameters.AddWithValue("@d6", Overtime.Text)
            cmd.Parameters.AddWithValue("@d7", BasicWorkingTime.Text)
            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            Dim st As String = "updated the attendance entry having id '" & txtID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            con.Close()
            GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from EmployeeAttendance where id=" & txtID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the attendance entry having id '" & txtID.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GetData()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub frmAdvanceEntry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtEmpID.Text = dr.Cells(0).Value.ToString
                EmployeeID.Text = dr.Cells(1).Value.ToString
                EmployeeName.Text = dr.Cells(2).Value.ToString
                BasicWorkingTime.Text = dr.Cells(3).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 (ID) FROM EmployeeAttendance ORDER BY ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function
    Public Sub auto()
        Try
            txtId.Text = GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmAttendanceEntryRecord.lblSet.Text = "Attendance Entry"
        frmAttendanceEntryRecord.Reset()
        frmAttendanceEntryRecord.ShowDialog()
    End Sub

    Private Sub Status_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Status.SelectedIndexChanged
        If Status.Text = "P" Then
            txtOutTime.Visible = False
            txtInTime.Visible = False
            InTime.Enabled = True
            OutTime.Enabled = True
            InTime.Text = Now
            OutTime.Text = Now
            Overtime.Text = ""


        ElseIf Status.Text = "A" Then
            txtOutTime.Visible = True
            txtInTime.Visible = True
            txtOutTime.Text = "00:00:00"
            txtInTime.Text = "00:00:00"
            Overtime.Text = "00:00:00"
        End If
    End Sub

    Private Sub InTime_ValueChanged(sender As Object, e As System.EventArgs) Handles InTime.ValueChanged
        Dim ts As TimeSpan
        TimeSpan.TryParse(BasicWorkingTime.Text, ts)
        Dim duration As TimeSpan = OutTime.Value - InTime.Value
        Overtime.Text = Convert.ToString(duration - ts)
    End Sub

    Private Sub OutTime_ValueChanged(sender As Object, e As System.EventArgs) Handles OutTime.ValueChanged
        Dim ts As TimeSpan
        TimeSpan.TryParse(BasicWorkingTime.Text, ts)
        Dim duration As TimeSpan = OutTime.Value - InTime.Value
        Overtime.Text = Convert.ToString(duration - ts)
    End Sub

    Private Sub txtEmployee_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEmployee.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT RTRIM(EmployeeRegistration.ID),RTRIM(EmployeeRegistration.EmployeeID),RTRIM(EmployeeName),RTRIM(BasicWorkingTime) from EmployeeRegistration where Active='Yes' and EmployeeName like '%" & txtEmployee.Text & "%' order by EmployeeName"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
