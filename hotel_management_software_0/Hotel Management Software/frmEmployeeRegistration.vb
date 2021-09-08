﻿Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class frmEmployeeRegistration
    Dim Photoname As String = ""
    Dim IsImageChanged As Boolean = False
    Dim st1 As String
    Sub Reset()
        txtEmployeeID.Text = ""
        txtEmployeeName.Text = ""
        txtCity.Text = ""
        txtAddress.Text = ""
        txtContactNo.Text = ""
        txtEmail.Text = ""
        cmbDesignation.Text = ""
        cmbDepartment.Text = ""
        dtpDateOfJoining.Text = Today
        txtSalary.Text = ""
        cmbBloodGroup.SelectedIndex = -1
        cmbGender.SelectedIndex = -1
        txtBasicWorkingTime.Text = ""
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        chkActive.Checked = True
        btnSave.Enabled = True
        Picture.Image = My.Resources.photo
        auto()
        txtEmployeeName.Focus()
    End Sub
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM EmployeeRegistration")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtID.Text = Num.ToString
            txtEmployeeID.Text = "EMP-" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtID.Text = Num.ToString
            txtEmployeeID.Text = "EMP-" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Len(Trim(txtEmployeeName.Text)) = 0 Then
            MessageBox.Show("Please enter employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmployeeName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbGender.Text)) = 0 Then
            MessageBox.Show("Please select gender", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbGender.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCity.Text)) = 0 Then
            MessageBox.Show("Please enter city", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCity.Focus()
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbDepartment.Text)) = 0 Then
            MessageBox.Show("Please enter/select department", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbDepartment.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbDesignation.Text)) = 0 Then
            MessageBox.Show("Please enter/select designation", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbDesignation.Focus()
            Exit Sub
        End If
        If Len(Trim(txtSalary.Text)) = 0 Then
            MessageBox.Show("Please enter basic Salary", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSalary.Focus()
            Exit Sub
        End If
        If txtBasicWorkingTime.Text = "" Then
            MessageBox.Show("Please enter basic working time", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBasicWorkingTime.Focus()
            Exit Sub
        End If
        Try
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into employeeregistration(id,employeeid,employeename,Gender,address,City,contactno,email,bloodgroup,department,designation,dateofjoining,salary,basicworkingtime,photo,Active) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,'" & st1 & "')"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtEmployeeID.Text)
            cmd.Parameters.AddWithValue("@d2", txtEmployeeName.Text)
            cmd.Parameters.AddWithValue("@d3", cmbGender.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d5", txtCity.Text)
            Dim st As String = "added the new employee '" & txtEmployeeName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Employee Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
           con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   
    Private Sub Browse_Click(sender As System.Object, e As System.EventArgs) Handles Browse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
          
                Picture.Image = Image.FromFile(OpenFileDialog1.FileName)

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BRemove_Click(sender As System.Object, e As System.EventArgs) Handles BRemove.Click
        Picture.Image = My.Resources.photo
    End Sub

    Private Sub BStartCapture_Click(sender As System.Object, e As System.EventArgs) Handles BStartCapture.Click
        Dim k As New frmWeb
        k.ShowDialog()
        If TempFileNames2.Length > 0 Then

            Picture.Image = Image.FromFile(TempFileNames2)
            Photoname = TempFileNames2
            IsImageChanged = True
        End If
    End Sub

    Private Sub frmEmployeeRegistration_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      
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
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select EmployeeRegistration.ID from EmployeeRegistration,AdvanceEntry where EmployeeRegistration.ID=AdvanceEntry.EmployeeID and EmployeeRegistration.ID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Payroll Advance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl1 As String = "select EmployeeRegistration.ID from EmployeeRegistration,EmployeeAttendance where EmployeeRegistration.ID=EmployeeAttendance.EmployeeID and EmployeeRegistration.ID=@d1"
            cmd = New SqlCommand(cl1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Employee Attendance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con.Open()
            Dim cl2 As String = "select EmployeeRegistration.ID from EmployeeRegistration,EmployeePayment where EmployeeRegistration.ID=EmployeePayment.EmployeeID and EmployeeRegistration.ID=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Employee Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from EmployeeRegistration where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the record of employee '" & txtEmployeeName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtEmployeeName.Text)) = 0 Then
            MessageBox.Show("Please enter employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmployeeName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbGender.Text)) = 0 Then
            MessageBox.Show("Please select gender", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbGender.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtCity.Text)) = 0 Then
            MessageBox.Show("Please enter city", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCity.Focus()
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbDepartment.Text)) = 0 Then
            MessageBox.Show("Please enter/select department", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbDepartment.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbDesignation.Text)) = 0 Then
            MessageBox.Show("Please enter/select designation", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbDesignation.Focus()
            Exit Sub
        End If
        If Len(Trim(txtSalary.Text)) = 0 Then
            MessageBox.Show("Please enter basic Salary", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSalary.Focus()
            Exit Sub
        End If
        If txtBasicWorkingTime.Text = "" Then
            MessageBox.Show("Please enter basic working time", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBasicWorkingTime.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cbx As String = "update LedgerBook set [Name]=@d3 where PartyID=@d1 and Name=@d2"
            cmd = New SqlCommand(cbx)
            cmd.Parameters.AddWithValue("@d1", txtEmployeeID.Text)
            cmd.Parameters.AddWithValue("@d2", txtEmpName.Text)
            cmd.Parameters.AddWithValue("@d3", txtEmployeeName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update employeeregistration set employeeid=@d1,employeename=@d2,Gender=@d3,address=@d4,City=@d5,contactno=@d6,email=@d7,bloodgroup=@d8,department=@d9,designation=@d10,dateofjoining=@d11,salary=@d12,basicworkingtime=@d13,photo=@d14,Active='" & st1 & "' where id=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
           cmd.Parameters.AddWithValue("@d1", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d7", txtEmail.Text)
            cmd.Parameters.AddWithValue("@d8", cmbBloodGroup.Text)
            cmd.Parameters.AddWithValue("@d9", cmbDepartment.Text)
            cmd.Parameters.AddWithValue("@d10", cmbDesignation.Text)
            cmd.Parameters.AddWithValue("@d11", dtpDateOfJoining.Value.Date)
            cmd.Parameters.AddWithValue("@d12", Val(txtSalary.Text))
            cmd.Parameters.AddWithValue("@d13", txtBasicWorkingTime.Text)
            Dim ms3 As New MemoryStream()
            Dim bmpImage3 As New Bitmap(Picture.Image)
            bmpImage3.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data3 As Byte() = ms3.GetBuffer()
            Dim p3 As New SqlParameter("@d14", SqlDbType.Image)
            p3.Value = data3
            cmd.Parameters.Add(p3)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "updated the record of employee '" & txtEmployeeName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Employee Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
          
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbDepartment_Format(sender As Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbDepartment.Format
        If e.DesiredType Is GetType(String) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

 

    Private Sub cmbDesignation_Format(sender As Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbDesignation.Format
        If e.DesiredType Is GetType(String) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub txtSalary_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalary.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtSalary.Text
            Dim selectionStart = Me.txtSalary.SelectionStart
            Dim selectionLength = Me.txtSalary.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
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

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       
    End Sub

End Class
