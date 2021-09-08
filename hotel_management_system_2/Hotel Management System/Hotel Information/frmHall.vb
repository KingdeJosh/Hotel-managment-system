Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmHall
    Private Const STR_PleaseEnterCharges As String = "Please enter charges"
    Private Const STR_SelectCountFromHallHavingCount1 As String = "select count(*) from Hall Having count(*) >= 1"
    Private Const STR_RecordAlreadyExists As String = "Record Already Exists"
    Private Const STR_InsertIntoHallChargesHallNameVALUES As String = "insert into Hall(Charges) VALUES ('"
    Private Const STR_SuccessfullySaved As String = "Hall Charge Successfully saved"
    Private Const STR_DoYouReallyWantToDeleteThisRecord As String = "Do you really want to delete this record?"
    Private Const STR_DeleteFromHallWhereID As String = "delete from Hall where ID="
    Private Const STR_SuccessfullyDeleted As String = "Record Successfully deleted"
    Private Const STR_NoRecordFound As String = "No record found"
    Private Const STR_PleaseEnterCharges1 As String = "Please enter Hall Charges"
    Private Const STR_PleaseEnterHallName As String = "Please enter Hall Full Name"
    Private Const STR_UpdateHallSetChargesHallNameWhereID As String = "update Hall set Charges = '{0}' where ID= '{2}'"
    Private Const STR_TheRecoredIsSuccessfullyUpdated As String = " The Recored is Successfully updated"
    Private Const STR_SELECTFromHall As String = "SELECT * from Hall "









    Sub Reset()
        txtCharges.Text = ""
        btnSave.Enabled = True
        btnUpdate_record.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub frmLiquor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        GetData()

    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewRecord.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If Len(Trim(txtCharges.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterCharges, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCharges.Focus()
            Exit Sub
        End If
        Try

            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = STR_SelectCountFromHallHavingCount1
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show(STR_RecordAlreadyExists & vbCrLf & "please update the charges", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_InsertIntoHallChargesHallNameVALUES & txtCharges.Text & "')"

            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullySaved, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            btnSave.Enabled = False
            GetData()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show(STR_DoYouReallyWantToDeleteThisRecord, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
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
            Dim cq As String = STR_DeleteFromHallWhereID & txtID.Text & ""
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show(STR_SuccessfullyDeleted, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Reset()
                GetData()
            Else
                MessageBox.Show(STR_NoRecordFound, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_record_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate_record.Click
        Try

            If Len(Trim(txtCharges.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterCharges1, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCharges.Focus()
            

                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
          
            Dim cb As String = String.Format(STR_UpdateHallSetChargesHallNameWhereID, txtCharges.Text, txtID.Text)
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_TheRecoredIsSuccessfullyUpdated, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate_record.Enabled = False

            GetData()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRate_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCharges.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Sub GetData()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTFromHall, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            txtID.Text = dr.Cells(0).Value.ToString()
            txtCharges.Text = dr.Cells(1).Value.ToString()
            btnDelete.Enabled = True
            btnUpdate_record.Enabled = True
            btnSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub
End Class