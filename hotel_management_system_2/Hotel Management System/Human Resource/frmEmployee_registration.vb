Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text
Public Class frmEmployee_registration
    Private Const STR_PleaseEnterAddress As String = "Please enter address"
    Private Const STR_PleaseEnterEmployeeName As String = "Please enter employee full name"
    Private Const STR_PleaseEnterMobileNo As String = "Please enter mobile no."
    Private Const STR_PleaseEnterDepartment As String = "Please enter department"
    Private Const STR_PleaseEnterDesignation As String = "Please enter designation"
    Private Const STR_PleaseEnterBasicSalary As String = "Please enter basic Salary"
    Private Const STR_PleaseEnterBasicWorkingTime As String = "Please enter basic working time"
    Private Const STR_InsertIntoEmployeeregistrationemployeeidemployee As String = "insert into employeeregistration(employeeid,employeename,address,mobileno,email,bloodgroup,department,designation,dateofjoining,salary,basicworkingtime) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
    Private Const STR_RecordSuccessfullySaved As String = "Employee Profile Successfully saved"
    Private Const STR_SELECTDistinctDepartmentFROMEmployeeregistration As String = "SELECT distinct (department) FROM employeeregistration"
    Private Const STR_SELECTDistinctDesignationFROMEmployeeregistratio As String = "SELECT distinct (designation) FROM employeeregistration"
    Private Const STR_PleaseSelectEmployeeId As String = "Please select employee id"
    Private Const STR_UpdateEmployeeregistrationSetEmployeename As String = "Update Employeeregistration set employeename='"
    Private Const STR_AreYouSureWantToUpdateTheRecord As String = "Are you sure want to update the record?"
    Private Const STR_RecordSuccessfullyUpdated As String = "Emplyee Record Successfully updated"
    Private Const STR_DoYouReallyWantToDeleteThisRecord As String = "Do you really want to delete this record?"
    Private Const STR_SelectEmployeeIDFromEmployeeattendanceWhereEmplo As String = "select EmployeeID from employeeattendance where EmployeeID=@find"
    Private Const STR_UnableToDeleteAlreadyInUse As String = "Unable to delete..Already in use"
    Private Const STR_SelectEmployeeIDFromEmployeepaymentWhereEmployee As String = "select EmployeeID from employeepayment where EmployeeID=@find"
    Private Const STR_SelectEmployeeIDFromAdvanceentryWhereEmployeeIDf As String = "select EmployeeID from advanceentry where EmployeeID=@find"
    Private Const STR_DeleteFromEmployeeregistrationWhereEmployeeIDDEL As String = "delete from employeeregistration where EmployeeID=@DELETE1;"
    Private Const STR_RecordSuccessfullyDeleted As String = "Record Successfully deleted"
    Private Const STR_NoRecordFound As String = "No record found"
    Private Const STR_AzAZw28azAZ09azAZ09wazAZ09azAZazAZazAZ As String = "^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
    Private Const STR_InvalidEmailAddress As String = "invalid email address"
    Private Const STR_SelectEmployeeIDAsEmployeeIDEmployeeNameAsEmploy As String = "select (EmployeeID) as [Employee ID], (EmployeeName) as [Employee Name],(Address) as [Address],(MobileNo) as [Mobile No],(Email) as [Email],(BloodGroup) as [Gender],(Department) as [Department],(Designation) as [Designation],(DateOfJoining) as [Date Of Joining],(Salary) as [Basic Salary],(BasicWorkingTime) as [Basic Working Time] from employeeregistration where Employeename like '"
    Private Const STR_SelectEmployeeIDAsEmployeeIDEmployeeNameAsEmploy1 As String = "select (EmployeeID) as [Employee ID], (EmployeeName) as [Employee Name],(Address) as [Address],(MobileNo) as [Mobile No],(Email) as [Email],(BloodGroup) as [gender],(Department) as [Department],(Designation) as [Designation],(DateOfJoining) as [Date Of Joining],(Salary) as [Basic Salary],(BasicWorkingTime) as [Basic Working Time] from employeeregistration order by EmployeeName,dateofjoining "
    Private Const STR_SorryNothingToExportIntoExcelSheet As String = "Sorry nothing to export into excel sheet.."

    Dim dtable As New DataTable








    Private Sub Employee_registration_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMainMenu.Show()
    End Sub
    Public Sub AutoGenerate()
        EmployeeID.Text = "E-" & GetUniqueKey(6)
    End Sub
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
    Sub Reset()
        EmployeeID.Text = ""
        EmployeeName.Text = ""
        Address.Text = ""
        MobileNo.Text = ""
        Email.Text = ""
        Designation.Text = ""
        Department.Text = ""
        DateOfJoining.Text = Today
        Salary.Text = ""
        BloodGroup.Text = ""
        BasicWorkingTime.Text = ""

        Update_Record.Enabled = False
        Delete.Enabled = False
        Save.Enabled = True
        EmployeeName.Focus()
    End Sub
    Sub exportExcel()
        If DataGridView1.RowCount = Nothing Then
            MessageBox.Show(STR_SorryNothingToExportIntoExcelSheet & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application

        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView1.RowCount
            colsTotal = DataGridView1.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView1.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView1.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub NewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRecord.Click
        Reset()
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click

        If Len(Trim(EmployeeName.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterEmployeeName, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EmployeeName.Focus()
            Exit Sub
        End If
        If Len(Trim(Address.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterAddress, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Address.Focus()
            Exit Sub
        End If
        If Len(Trim(MobileNo.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterMobileNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MobileNo.Focus()
            Exit Sub
        End If
        If Len(Trim(Department.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterDepartment, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Department.Focus()
            Exit Sub
        End If
        If Len(Trim(Designation.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterDesignation, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Designation.Focus()
            Exit Sub
        End If
        If Len(Trim(Salary.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterBasicSalary, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Salary.Focus()
            Exit Sub
        End If
        If Len(Trim(BasicWorkingTime.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterBasicWorkingTime, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BasicWorkingTime.Focus()
            Exit Sub
        End If
        Try
            AutoGenerate()
            con = New OleDbConnection(cs)
            con.Open()

            Dim cb As String = STR_InsertIntoEmployeeregistrationemployeeidemployee

            cmd = New OleDbCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New OleDbParameter("@d1", OleDbType.VarChar, 30, "employeeid"))

            cmd.Parameters.Add(New OleDbParameter("@d2", OleDbType.VarChar, 100, "employeename"))

            cmd.Parameters.Add(New OleDbParameter("@d3", OleDbType.VarChar, 200, "address"))

            cmd.Parameters.Add(New OleDbParameter("@d4", OleDbType.VarChar, 10, "mobileno"))

            cmd.Parameters.Add(New OleDbParameter("@d5", OleDbType.VarChar, 60, "email"))

            cmd.Parameters.Add(New OleDbParameter("@d6", OleDbType.VarChar, 10, "bloodgroup"))

            cmd.Parameters.Add(New OleDbParameter("@d7", OleDbType.VarChar, 60, "department"))

            cmd.Parameters.Add(New OleDbParameter("@d8", OleDbType.VarChar, 60, "designation"))

            cmd.Parameters.Add(New OleDbParameter("@d9", OleDbType.VarChar, 30, "dateofjoining"))

            cmd.Parameters.Add(New OleDbParameter("@d10", OleDbType.VarChar, 10, "salary"))

            cmd.Parameters.Add(New OleDbParameter("@d11", OleDbType.VarChar, 10, "basicworkingtime"))

            cmd.Parameters("@d1").Value = EmployeeID.Text

            cmd.Parameters("@d2").Value = EmployeeName.Text

            cmd.Parameters("@d3").Value = Address.Text

            cmd.Parameters("@d4").Value = MobileNo.Text

            cmd.Parameters("@d5").Value = Email.Text
            cmd.Parameters("@d6").Value = BloodGroup.Text

            cmd.Parameters("@d7").Value = Department.Text

            cmd.Parameters("@d8").Value = Designation.Text

            cmd.Parameters("@d9").Value = DateOfJoining.Text

            cmd.Parameters("@d10").Value = Salary.Text


            cmd.Parameters("@d11").Value = BasicWorkingTime.Text
            cmd.ExecuteReader()
            MessageBox.Show(STR_RecordSuccessfullySaved, "Employee Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Save.Enabled = False
            Filldepartment()
            FillDesignation()

            EmployeeID.Focus()

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Filldepartment()
        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand(STR_SELECTDistinctDepartmentFROMEmployeeregistration, CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            Department.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                Department.Items.Add(drow(0).ToString())

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillDesignation()
        Try

            Dim CN As New OleDbConnection(cs)

            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand(STR_SELECTDistinctDesignationFROMEmployeeregistratio, CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            Designation.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                Designation.Items.Add(drow(0).ToString())

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Employee_registration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Filldepartment()
        FillDesignation()
    End Sub

    Private Sub Salary_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Salary.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.Salary.Text
            Dim selectionStart = Me.Salary.SelectionStart
            Dim selectionLength = Me.Salary.SelectionLength

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

    Private Sub Department_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Department.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'space accepted
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then

            e.Handled = False
        End If
    End Sub

    Private Sub Designation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Designation.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'space accepted
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then

            e.Handled = False
        End If
    End Sub

    Private Sub EmployeeID_Format(ByVal sender As Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs)
        If e.DesiredType Is GetType(String) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub


    Private Sub Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_Record.Click
        Try
            If Len(Trim(EmployeeID.Text)) = 0 Then
                MessageBox.Show(STR_PleaseSelectEmployeeId, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                EmployeeID.Focus()
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()

            Dim cb As String = STR_UpdateEmployeeregistrationSetEmployeename & EmployeeName.Text & "',address='" & Address.Text & "',mobileno='" & MobileNo.Text & "',email='" & Email.Text & "',bloodgroup='" & BloodGroup.Text & "',department='" & Department.Text & "',designation='" & Designation.Text & "',dateofjoining='" & DateOfJoining.Text & "',salary='" & Salary.Text & "',basicworkingtime='" & BasicWorkingTime.Text & "' where employeeid='" & EmployeeID.Text & "'"

            cmd = New OleDbCommand(cb)

            cmd.Connection = con

            If MessageBox.Show(STR_AreYouSureWantToUpdateTheRecord, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                cmd.ExecuteReader()
                MessageBox.Show(STR_RecordSuccessfullyUpdated, "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Filldepartment()
                FillDesignation()

                EmployeeID.Focus()
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

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try

            If MsgBox(STR_DoYouReallyWantToDeleteThisRecord, MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                delete_records()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub delete_records()


        Try

            con = New OleDbConnection(cs)

            con.Open()
            Dim ct As String = STR_SelectEmployeeIDFromEmployeeattendanceWhereEmplo


            cmd = New OleDbCommand(ct)

            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "EmployeeID"))


            cmd.Parameters("@find").Value = EmployeeID.Text


            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show(STR_UnableToDeleteAlreadyInUse, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Reset()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If

            con = New OleDbConnection(cs)

            con.Open()
            Dim ct2 As String = STR_SelectEmployeeIDFromEmployeepaymentWhereEmployee


            cmd = New OleDbCommand(ct2)

            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "EmployeeID"))


            cmd.Parameters("@find").Value = EmployeeID.Text


            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show(STR_UnableToDeleteAlreadyInUse, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Reset()



                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If

            con = New OleDbConnection(cs)

            con.Open()
            Dim ct1 As String = STR_SelectEmployeeIDFromAdvanceentryWhereEmployeeIDf


            cmd = New OleDbCommand(ct1)

            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "EmployeeID"))


            cmd.Parameters("@find").Value = EmployeeID.Text


            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show(STR_UnableToDeleteAlreadyInUse, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Reset()



                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If

            Dim RowsAffected As Integer = 0

            con = New OleDbConnection(cs)

            con.Open()


            Dim cq As String = STR_DeleteFromEmployeeregistrationWhereEmployeeIDDEL


            cmd = New OleDbCommand(cq)

            cmd.Connection = con

            cmd.Parameters.Add(New OleDbParameter("@DELETE1", OleDbType.VarChar, 30, "EmployeeID"))


            cmd.Parameters("@DELETE1").Value = Trim(EmployeeID.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then

                MessageBox.Show(STR_RecordSuccessfullyDeleted, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Filldepartment()
                FillDesignation()
                Reset()
                EmployeeID.Focus()
                Update_Record.Enabled = False
                Delete.Enabled = False
            Else
                MessageBox.Show(STR_NoRecordFound, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub Department_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Department.TextChanged
        Dim selectionStart As Integer = Me.Department.SelectionStart

        Me.Department.Text = Me.Department.Text.ToUpper()
        Me.Department.SelectionStart = selectionStart
    End Sub

    Private Sub Designation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Designation.TextChanged
        Dim selectionStart As Integer = Me.Designation.SelectionStart

        Me.Designation.Text = Me.Designation.Text.ToUpper()
        Me.Designation.SelectionStart = selectionStart
    End Sub


    Private Sub EmployeeName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EmployeeName.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'space accepted
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then

            e.Handled = False
        End If
    End Sub

    Private Sub Email_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Email.Validating
        Dim rEMail As New System.Text.RegularExpressions.Regex(STR_AzAZw28azAZ09azAZ09wazAZ09azAZazAZazAZ)
        If Email.Text.Length > 0 Then
            If Not rEMail.IsMatch(Email.Text) Then
                MessageBox.Show(STR_InvalidEmailAddress, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Email.SelectAll()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub EmployeeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim selectionStart As Integer = Me.EmployeeID.SelectionStart

        Me.EmployeeID.Text = Me.EmployeeID.Text.ToUpper()
        Me.EmployeeID.SelectionStart = selectionStart
    End Sub


    Private Sub txtEmployee_TextChanged(sender As Object, e As EventArgs) Handles txtEmployee.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SelectEmployeeIDAsEmployeeIDEmployeeNameAsEmploy & EmployeeName.Text & "%' order by EmployeeName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeRegistration")

            DataGridView1.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
           
            Me.EmployeeID.Text = dr.Cells(0).Value.ToString()
            Me.EmployeeName.Text = dr.Cells(1).Value.ToString()
            Me.Address.Text = dr.Cells(2).Value.ToString()
            Me.MobileNo.Text = dr.Cells(3).Value.ToString()
            Me.Email.Text = dr.Cells(4).Value.ToString()
            Me.BloodGroup.Text = dr.Cells(5).Value.ToString()
            Me.Department.Text = dr.Cells(6).Value.ToString()
            Me.Designation.Text = dr.Cells(7).Value.ToString()
            Me.DateOfJoining.Text = dr.Cells(8).Value.ToString()
            Me.Salary.Text = dr.Cells(9).Value.ToString()
            Me.BasicWorkingTime.Text = dr.Cells(10).Value.ToString()
            Me.Update_Record.Enabled = True
            Me.Delete.Enabled = True
            Me.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        exportExcel()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SelectEmployeeIDAsEmployeeIDEmployeeNameAsEmploy1, con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeRegistration")

            DataGridView1.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView



            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        DataGridView1.DataSource = Nothing
        EmployeeName.Text = ""
    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Close()
    End Sub



End Class