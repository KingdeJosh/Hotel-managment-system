Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Public Class frmEmployeesRecord
    Private Const STR_SELECTDistinctEmployeenameFROMEmployeeregistrati As String = "SELECT distinct  (employeename) FROM employeeregistration"
    Private Const STR_SelectEmployeeIDAsEmployeeIDEmployeeNameAsEmploy As String = "select (EmployeeID) as [Employee ID], (EmployeeName) as [Employee Name],(Address) as [Address],(MobileNo) as [Mobile No],(Email) as [Email],(BloodGroup) as [Blood Group],(Department) as [Department],(Designation) as [Designation],(DateOfJoining) as [Date Of Joining],(Salary) as [Basic Salary],(BasicWorkingTime) as [Basic Working Time] from employeeregistration where Employeename = '"










   
   

    Private Sub EmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeName.SelectedIndexChanged
        Try
            con = New oledbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SelectEmployeeIDAsEmployeeIDEmployeeNameAsEmploy & EmployeeName.Text & "'", con)
            Dim myDA As oledbDataAdapter = New oledbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeRegistration")

            DataGridView1.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Sub fillcombo()

        Try
          
            Dim CN As New oledbConnection(cs)

            CN.Open()
            adp = New oledbDataAdapter()
            adp.SelectCommand = New oledbCommand(STR_SELECTDistinctEmployeenameFROMEmployeeregistrati, CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            EmployeeName.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                EmployeeName.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeesRecord_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        frmMainMenu.Show()
    End Sub
    Private Sub EmployeesRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcombo()
    End Sub
    
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
        frmMainMenu.Show()

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        EmployeeName.SelectedIndex = -1
        txtEmployee.Text = ""

    End Sub

   
End Class