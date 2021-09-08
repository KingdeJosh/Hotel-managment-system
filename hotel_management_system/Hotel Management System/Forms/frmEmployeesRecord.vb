Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmEmployeesRecord

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(employeeid) as [Employee ID],RTRIM(employeename) as [Employee Name],RTRIM(Gender) as [Gender],RTRIM(address) as [Address],RTRIM(City) as [City],RTRIM(contactno) as [Contact No.],RTRIM(email) as [Email],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(bloodgroup) as [Blood Group],CONVERT(DateTime,DateOfJoining,103) as [Joining Date],RTRIM(salary) as [Salary],RTRIM(basicworkingtime) as [Basic Working Time] from EmployeeRegistration order by EmployeeName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeeRegistration")
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
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try

            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Employee" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmEmployeeRegistration.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmEmployeeRegistration.txtID.Text = dr.Cells(0).Value.ToString()
                frmEmployeeRegistration.txtEmployeeID.Text = dr.Cells(1).Value.ToString()
                frmEmployeeRegistration.txtEmployeeName.Text = dr.Cells(2).Value.ToString()
                frmEmployeeRegistration.cmbGender.Text = dr.Cells(3).Value.ToString()
                frmEmployeeRegistration.txtAddress.Text = dr.Cells(4).Value.ToString()
                frmEmployeeRegistration.txtCity.Text = dr.Cells(5).Value.ToString()
                frmEmployeeRegistration.txtContactNo.Text = dr.Cells(6).Value.ToString()
                frmEmployeeRegistration.txtEmail.Text = dr.Cells(7).Value.ToString()
                frmEmployeeRegistration.cmbDepartment.Text = dr.Cells(8).Value.ToString()
                frmEmployeeRegistration.cmbDesignation.Text = dr.Cells(9).Value.ToString()
                frmEmployeeRegistration.cmbBloodGroup.Text = dr.Cells(10).Value.ToString()
                frmEmployeeRegistration.dtpDateOfJoining.Text = dr.Cells(11).Value.ToString()
                frmEmployeeRegistration.txtSalary.Text = dr.Cells(12).Value.ToString()
                frmEmployeeRegistration.txtBasicWorkingTime.Text = dr.Cells(13).Value.ToString()
                frmEmployeeRegistration.btnUpdate.Enabled = True
                frmEmployeeRegistration.btnDelete.Enabled = True
                frmEmployeeRegistration.btnSave.Enabled = False
                frmEmployeeRegistration.txtEmployeeName.Focus()
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT Photo from EmployeeRegistration where EmployeeRegistration.EmployeeID='" & dr.Cells(1).Value & "'", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                While (rdr.Read() = True)
                    Dim data As Byte() = DirectCast(rdr(0), Byte())
                    Dim ms As New MemoryStream(data)
                    frmEmployeeRegistration.Picture.Image = Image.FromStream(ms)
                End While
                    con.Close()
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
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub


    Private Sub txtEmployeeRegistrationName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployeeName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(employeeid) as [Employee ID],RTRIM(employeename) as [Employee Name],RTRIM(Gender) as [Gender],RTRIM(address) as [Address],RTRIM(City) as [City],RTRIM(contactno) as [Contact No.],RTRIM(email) as [Email],RTRIM(department) as [Department],RTRIM(designation) as [Designation],,RTRIM(bloodgroup) as [Blood Group],CONVERT(DateTime,DateOfJoining,103) as [Joining Date],RTRIM(salary) as [Salary],RTRIM(basicworkingtime) as [Basic Working Time] from EmployeeRegistration where EmployeeName like '" & txtEmployeeName.Text & "%' order by EmployeeName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeeRegistration")
            dgw.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
