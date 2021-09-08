Imports System.Data.OleDb
Public Class frmRoom
    Private Const STR_SELECTFromRoomOrderByRoomNo As String = "SELECT * from Room order by RoomNo"
    Private Const STR_RoomNoAlreadyExists As String = "Room Number Already Exists"
    Private Const STR_SuccessfullySaved As String = " Room Successfully saved"
    Private Const STR_SELECTDistinctRoomNoFROMRoom As String = "SELECT distinct RoomNo FROM Room"
    Private Const STR_SuccessfullyDeleted As String = "Successfully deleted"
    Private Const STR_NoRecordFound As String = "No record found"
    Private Const STR_SuccessfullyUpdated As String = "Successfully updated"
    Private Const STR_InsertIntoRoomRoomNoRoomTypeRoomChargesVALUES As String = "insert into Room(RoomNo,RoomType,RoomCharges) VALUES ('{0}','{1}',{2})"
    Private Const STR_SelectRoomNoFromRoomWhereRoomNo As String = "select RoomNo from Room where RoomNo='{0}'"
    Private Const STR_DoYouReallyWantToDeleteThisRecord As String = "Do you really want to delete this record?"
    Private Const STR_DeleteFromRoomWhereRoomNo As String = "delete from Room where RoomNo='{0}'"
    Private Const STR_PleaseEnterRoomNo As String = "Please enter room no."
    Private Const STR_PleaseSelectRoomType As String = "Please select room type"
    Private Const STR_PleaseEnterRoomCharges As String = "Please enter room charges"
    Private Const STR_UpdateRoomSetRoomNoRoomTypeRoomChargesWhereRoomN As String = "update Room set RoomNo='{0}',RoomType='{1}',RoomCharges = {2} where RoomNo= '{3}'"
    Private Const STR_SELECTFromRoomWhereRoomNoLike As String = "SELECT * from Room where RoomNo like '"









    Public Sub Reset()
        txtRoomNo.Text = ""
        txtRoomCharges.Text = ""
        cmbRoomType.SelectedIndex = -1
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate_record.Enabled = False
        txtRoomNo.Focus()
    End Sub
    Sub GetData()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTFromRoomOrderByRoomNo, con)
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
    Private Sub frmRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtRoomNo.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterRoomNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRoomNo.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbRoomType.Text)) = 0 Then
            MessageBox.Show(STR_PleaseSelectRoomType, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbRoomType.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRoomCharges.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterRoomCharges, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRoomCharges.Focus()
            Exit Sub
        End If
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = String.Format(STR_SelectRoomNoFromRoomWhereRoomNo, txtRoomNo.Text)
            cmd = New OleDbCommand(ct)
            With cmd
                .Connection = con
            End With
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show(STR_RoomNoAlreadyExists, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRoomNo.Text = ""
                txtRoomNo.Focus()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = String.Format(STR_InsertIntoRoomRoomNoRoomTypeRoomChargesVALUES, txtRoomNo.Text, cmbRoomType.Text, txtRoomCharges.Text)
            cmd = New OleDbCommand(cb)
            With cmd
                .Connection = con
            End With
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullySaved, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Autocomplete()
            btnSave.Enabled = False
            GetData()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Autocomplete()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim cmd As New OleDbCommand(STR_SELECTDistinctRoomNoFROMRoom, con)
            Dim ds As New DataSet()
            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(ds, "Room")
            Dim col As New AutoCompleteStringCollection()
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("RoomNo").ToString())
            Next
            txtRoomNo.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtRoomNo.AutoCompleteCustomSource = col
            txtRoomNo.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
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
            Dim cq As String = String.Format(STR_DeleteFromRoomWhereRoomNo, txtRoomNo.Text)
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show(STR_SuccessfullyDeleted, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Autocomplete()
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

    Private Sub btnUpdate_record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate_record.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = String.Format(STR_UpdateRoomSetRoomNoRoomTypeRoomChargesWhereRoomN, txtRoomNo.Text, cmbRoomType.Text, txtRoomCharges.Text, TextBox1.Text)
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullyUpdated, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate_record.Enabled = False
            Autocomplete()
            con.Close()
            GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRoomCharges_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRoomCharges.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            txtRoomNo.Text = dr.Cells(0).Value.ToString()
            TextBox1.Text = dr.Cells(0).Value.ToString()
            cmbRoomType.Text = dr.Cells(1).Value.ToString()
            txtRoomCharges.Text = dr.Cells(2).Value.ToString()
            btnDelete.Enabled = True
            btnUpdate_record.Enabled = True
            btnSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRecord.Click
        Reset()
    End Sub

    Private Sub txtSearchByRoom_TextChanged(sender As Object, e As EventArgs) Handles txtSearchByRoom.TextChanged
        
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTFromRoomWhereRoomNoLike & txtSearchByRoom.Text & "%' order by RoomType", con)
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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub
End Class