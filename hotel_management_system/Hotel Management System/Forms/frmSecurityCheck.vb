Imports System.Data.SqlClient
Public Class frmSecurityCheck

    
    Sub Reset()
        txtPassword.Text = ""
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Try
            If txtPassword.Text = "" Then
                MessageBox.Show("please enter the password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Exit Sub
            End If
            ds = New DataSet()
            Dim con As New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Password FROM Registration Where UserID=@d1", con)
            cmd.Parameters.AddWithValue("@d1", lblUser.Text)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds)
            con.Close()
            If ds.Tables(0).Rows.Count > 0 Then
                If Encrypt(txtPassword.Text) = Convert.ToString(ds.Tables(0).Rows(0)("Password")).Trim Then
                    frmEmployeeRegistration.DeleteRecord()
                    Close()
                Else
                    MessageBox.Show("Sorry!wrong password..please re-try", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPassword.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class
