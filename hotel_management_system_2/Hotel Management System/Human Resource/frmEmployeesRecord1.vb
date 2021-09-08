Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Public Class frmEmployeesRecord1










    Private Sub button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGridView1.DataSource = Nothing

    End Sub
    

    
    

  
    Private Sub EmployeesRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DataGridView1.DataSource = Nothing
        
    End Sub

    


   



   

    

    Private Sub txtEmployee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployee.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (EmployeeID) as [Employee ID], (EmployeeName) as [Employee Name],(Address) as [Address],(MobileNo) as [Mobile No],(Email) as [Email],(BloodGroup) as [Blood Group],(Department) as [Department],(Designation) as [Designation],(DateOfJoining) as [Date Of Joining],(Salary) as [Basic Salary],(BasicWorkingTime) as [Basic Working Time] from employeeregistration where Employeename like '" & txtEmployee.Text & "%' order by EmployeeName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeRegistration")

            DataGridView1.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub
End Class