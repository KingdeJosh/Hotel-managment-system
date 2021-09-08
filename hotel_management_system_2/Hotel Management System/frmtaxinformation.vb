Imports System.Data.OleDb
Public Class frmtaxinformation









    Sub yonitax()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT * from Taxinfo order by Salray", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmtaxinformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        yonitax()
    End Sub
   

    Private Sub txtclear_Click(sender As Object, e As EventArgs) Handles txtclear.Click
        txtsalray.Text = ""
        txtrateP.Text = ""
        btnSave.Enabled = True
        btnSave.Enabled = True
        txtUpdate.Enabled = False
        txtDelete.Enabled = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If Len(Trim(txtsalray.Text)) = 0 Then
            MessageBox.Show("Please enter Salrey Rainge", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtsalray.Focus()
            Exit Sub
        End If
        If Len(Trim(txtrateP.Text)) = 0 Then
            MessageBox.Show("Please enter Tax per %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtrateP.Focus()
            Exit Sub
        End If
        Try

            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "select count(*) from Taxinfo Having count(*) >= 1"
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Record Already Exists" & vbCrLf & "please update the charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "insert into Taxinfo(Salray,taxinP) VALUES ('" & txtsalray.Text & "'," & txtrateP.Text & ")"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            btnSave.Enabled = False

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            txtsalray.Text = dr.Cells(0).Value.ToString()
            txtrateP.Text = dr.Cells(1).Value.ToString()
            txtDelete.Enabled = True
            txtUpdate.Enabled = True
            btnSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDelete_Click(sender As Object, e As EventArgs) Handles txtDelete.Click
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
            con = New OleDbConnection(cs)
            con.Open()
            Dim cq As String = "delete from Taxinfo where salray=" & txtsalray.Text & ""
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Record Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Reset()
                yonitax()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub txtUpdate_Click(sender As Object, e As EventArgs) Handles txtUpdate.Click
        Try

            If Len(Trim(txtsalray.Text)) = 0 Then
                MessageBox.Show("Please enter Salrey Rainge", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtsalray.Focus()
                Exit Sub
            End If
            If Len(Trim(txtrateP.Text)) = 0 Then
                MessageBox.Show("Please enter Tax per %", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtrateP.Focus()
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()

            Dim cb As String = String.Format("update Taxinfo set Salrey = '{0}', taxinP = {1}  where Salray= '{0}'", txtsalray.Text, txtrateP.Text)
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(" The Recored is Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUpdate.Enabled = False

            yonitax()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class


