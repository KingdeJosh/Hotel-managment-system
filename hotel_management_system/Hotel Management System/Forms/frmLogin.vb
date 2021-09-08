Imports System.Data.SqlClient
Public Class frmLogin
    Dim frm As New frmMainMenu

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If Len(Trim(UserID.Text)) = 0 Then
            MessageBox.Show("Please enter user id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UserID.Focus()
            Exit Sub
        End If
        If Len(Trim(Password.Text)) = 0 Then
            MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Password.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(Password) FROM Registration where UserID = @d1 and Password=@d2"
            cmd.Parameters.AddWithValue("@d1", UserID.Text)
            cmd.Parameters.AddWithValue("@d2", Encrypt(Password.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT usertype FROM Registration where UserID=@d3 and Password=@d4"
                cmd.Parameters.AddWithValue("@d3", UserID.Text)
                cmd.Parameters.AddWithValue("@d4", Encrypt(Password.Text))
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    UserType.Text = rdr.GetValue(0).ToString.Trim
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If


                If UserType.Text = "User" Then
                    frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = False
                    frmMainMenu.DataEntryToolStripMenuItem.Enabled = False
                    frmMainMenu.TransactionToolStripMenuItem.Enabled = False
                    frmMainMenu.UsersToolStripMenuItem.Enabled = False
                    frmMainMenu.MasterEntryToolStripMenuItem.Enabled = False
                    frmMainMenu.LogsToolStripMenuItem1.Enabled = False
                    frmMainMenu.ChatToolStripMenuItem1.Enabled = True
                    frmMainMenu.ReservationToolStripMenuItem.Enabled = False
                    frmMainMenu.CheckInToolStripMenuItem.Enabled = False
                    frmMainMenu.GuestToolStripMenuItem1.Enabled = False
                    frmMainMenu.StockToolStripMenuItem1.Enabled = False
                    frmMainMenu.OrderToolStripMenuItem.Enabled = True
                    frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                    frmMainMenu.CheckOutToolStripMenuItem.Enabled = False
                    frmMainMenu.EmployeeToolStripMenuItem1.Enabled = False
                    frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = False
                    frmMainMenu.AttendanceToolStripMenuItem2.Enabled = False
                    frmMainMenu.PaymentToolStripMenuItem1.Enabled = False
                    frmMainMenu.dgw.Enabled = False
                    frmMainMenu.DataGridView1.Enabled = False
                    frmMainMenu.DataGridView2.Enabled = False
                    frmMainMenu.DatabaseToolStripMenuItem.Enabled = False
                    frmMainMenu.btnSearch.Enabled = False
                    frmMainMenu.btnReset.Enabled = False
                    frmMainMenu.GroupBox2.Enabled = False
                    frmMainMenu.GroupBox1.Enabled = False
                    frmMainMenu.ReportsToolStripMenuItem.Enabled = False
                    frmMainMenu.lblUser.Text = UserID.Text
                    frmMainMenu.lblUserType.Text = UserType.Text
                    Dim st As String = "Successfully logged in"
                    LogFunc(UserID.Text, st)
                    Me.Hide()
                    frmMainMenu.lblUser.Text = UserID.Text
                    frmMainMenu.Show()
                End If
                If (UserType.Text = "Admin") Then
                    frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = True
                    frmMainMenu.DataEntryToolStripMenuItem.Enabled = True
                    frmMainMenu.TransactionToolStripMenuItem.Enabled = True
                    frmMainMenu.UsersToolStripMenuItem.Enabled = True
                    frmMainMenu.MasterEntryToolStripMenuItem.Enabled = True
                    frmMainMenu.LogsToolStripMenuItem1.Enabled = True
                    frmMainMenu.ChatToolStripMenuItem1.Enabled = True
                    frmMainMenu.ReservationToolStripMenuItem.Enabled = True
                    frmMainMenu.CheckInToolStripMenuItem.Enabled = True
                    frmMainMenu.GuestToolStripMenuItem1.Enabled = True
                    frmMainMenu.StockToolStripMenuItem1.Enabled = True
                    frmMainMenu.OrderToolStripMenuItem.Enabled = True
                    frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                    frmMainMenu.CheckOutToolStripMenuItem.Enabled = True
                    frmMainMenu.EmployeeToolStripMenuItem1.Enabled = True
                    frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = True
                    frmMainMenu.AttendanceToolStripMenuItem2.Enabled = True
                    frmMainMenu.PaymentToolStripMenuItem1.Enabled = True
                    frmMainMenu.dgw.Enabled = True
                    frmMainMenu.DataGridView1.Enabled = True
                    frmMainMenu.DataGridView2.Enabled = True
                    frmMainMenu.DatabaseToolStripMenuItem.Enabled = True
                    frmMainMenu.btnSearch.Enabled = True
                    frmMainMenu.btnReset.Enabled = True
                    frmMainMenu.ReportsToolStripMenuItem.Enabled = True
                    frmMainMenu.GroupBox2.Enabled = True
                    frmMainMenu.GroupBox1.Enabled = True
                    frmMainMenu.lblUser.Text = UserID.Text
                    frmMainMenu.lblUserType.Text = UserType.Text
                    Dim st As String = "Successfully logged in"
                    LogFunc(UserID.Text, st)
                    Me.Hide()
                    frmMainMenu.lblUser.Text = UserID.Text
                    frmMainMenu.Show()

                End If
                If UserType.Text = "Receptionist" Then
                    frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = False
                    frmMainMenu.DataEntryToolStripMenuItem.Enabled = False
                    frmMainMenu.TransactionToolStripMenuItem.Enabled = False
                    frmMainMenu.UsersToolStripMenuItem.Enabled = False
                    frmMainMenu.MasterEntryToolStripMenuItem.Enabled = False
                    frmMainMenu.LogsToolStripMenuItem1.Enabled = False
                    frmMainMenu.ChatToolStripMenuItem1.Enabled = True
                    frmMainMenu.ReservationToolStripMenuItem.Enabled = True
                    frmMainMenu.CheckInToolStripMenuItem.Enabled = True
                    frmMainMenu.GuestToolStripMenuItem1.Enabled = True
                    frmMainMenu.StockToolStripMenuItem1.Enabled = True
                    frmMainMenu.ReportsToolStripMenuItem.Enabled = True
                    frmMainMenu.OrderToolStripMenuItem.Enabled = True
                    frmMainMenu.RestaurantBillingToolStripMenuItem.Enabled = True
                    frmMainMenu.CheckOutToolStripMenuItem.Enabled = True
                    frmMainMenu.EmployeeToolStripMenuItem1.Enabled = False
                    frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = False
                    frmMainMenu.AttendanceToolStripMenuItem2.Enabled = True
                    frmMainMenu.PaymentToolStripMenuItem1.Enabled = False
                    frmMainMenu.dgw.Enabled = True
                    frmMainMenu.DataGridView1.Enabled = True
                    frmMainMenu.DataGridView2.Enabled = True
                    frmMainMenu.DatabaseToolStripMenuItem.Enabled = False
                    frmMainMenu.btnSearch.Enabled = True
                    frmMainMenu.btnReset.Enabled = True
                    frmMainMenu.ReportsToolStripMenuItem.Enabled = False
                    frmMainMenu.GroupBox2.Enabled = True
                    frmMainMenu.GroupBox1.Enabled = True
                    frmMainMenu.lblUser.Text = UserID.Text
                    frmMainMenu.lblUserType.Text = UserType.Text
                    Dim st As String = "Successfully logged in"
                    LogFunc(UserID.Text, st)
                    Me.Hide()
                    frmMainMenu.lblUser.Text = UserID.Text
                    frmMainMenu.Show()
                End If
            Else
                MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied")
                UserID.Text = ""
                Password.Text = ""
                UserID.Focus()
            End If
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        End
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Hide()
        frmChangePassword.Show()
        frmChangePassword.UserID.Text = ""
        frmChangePassword.OldPassword.Text = ""
        frmChangePassword.NewPassword.Text = ""
        frmChangePassword.ConfirmPassword.Text = ""
        frmChangePassword.UserID.Focus()
    End Sub

    Private Sub LoginForm1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
