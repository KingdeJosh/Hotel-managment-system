Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Public Class frmGuest
    Private Const STR_PleaseEnterGuestName As String = "Please enter guest name"
    Private Const STR_PleaseEnterGuestAddress As String = "Please enter guest address"
    Private Const STR_PleaseEnterGuestCity As String = "Please enter guest city"
    Private Const STR_PleaseEnterGuestContactNo As String = "Please enter guest contact no."
    Private Const STR_PleaseSelectIdType As String = "Please select id type"
    Private Const STR_PleaseEnterIdNumber As String = "Please enter id number"
    Private Const STR_InsertIntoGuestGuestIDGuestNameAddressCityContac As String = "insert into Guest(GuestID, GuestName, Address, City, ContactNo, IDType, IDNumber, Notes) VALUES ('"
    Private Const STR_SuccessfullySaved As String = "Successfully saved"
    Private Const STR_DoYouReallyWantToDeleteThisRecord As String = "Do you really want to delete this record?"
    Private Const STR_DeleteFromGuestWhereGuestID As String = "delete from guest where GuestID='"
    Private Const STR_SuccessfullyDeleted As String = "Successfully deleted"
    Private Const STR_NoRecordFound As String = "No record found"
    Private Const STR_UpdateGuestSetGuestName As String = "update Guest set GuestName='"
    Private Const STR_SuccessfullyUpdated As String = "Successfully updated"








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

    Sub yoniload()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT (GuestID)as [Guest ID],(Guestname) as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],Notes from Guest order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub clearingfilledyoni()
        txtGuestID.Text = ""
        txtGuestName.Text = ""
        txtGuestAddress.Text = ""
        txtGuestCity.Text = ""
        txtGuestContactNo.Text = ""
        cmbIDType.SelectedIndex = -1
        txtIDNumber.Text = ""
        txtNotes.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate_record.Enabled = False
        txtGuestName.Focus()
    End Sub
    Private Sub frmGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        yoniload()
    End Sub

    Private Sub txtGuestContactNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGuestContactNo.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRecord.Click
        clearingfilledyoni()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestName.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterGuestName, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestName.Focus()
                Exit Sub
            End If

            If Len(Trim(txtGuestAddress.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterGuestAddress, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestAddress.Focus()
                Exit Sub
            End If
            If Len(Trim(txtGuestCity.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterGuestCity, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestCity.Focus()
                Exit Sub
            End If

            If Len(Trim(txtGuestContactNo.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterGuestContactNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestContactNo.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbIDType.Text)) = 0 Then
                MessageBox.Show(STR_PleaseSelectIdType, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbIDType.Focus()
                Exit Sub
            End If
            If Len(Trim(txtIDNumber.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterIdNumber, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtIDNumber.Focus()
                Exit Sub
            End If
            txtGuestID.Text = "G-" & GetUniqueKey(6)
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_InsertIntoGuestGuestIDGuestNameAddressCityContac & txtGuestID.Text & "','" & txtGuestName.Text & "','" & txtGuestAddress.Text & "','" & txtGuestCity.Text & "','" & txtGuestContactNo.Text & "','" & cmbIDType.Text & "','" & txtIDNumber.Text & "','" & txtNotes.Text & "')"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullySaved, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim cq As String = STR_DeleteFromGuestWhereGuestID & txtGuestID.Text & "'"
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show(STR_SuccessfullyDeleted, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
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
            Dim cb As String = STR_UpdateGuestSetGuestName & txtGuestName.Text & "',Address='" & txtGuestAddress.Text & "',City='" & txtGuestCity.Text & "',ContactNo='" & txtGuestContactNo.Text & "',IDType='" & cmbIDType.Text & "',IDNumber='" & txtIDNumber.Text & "',Notes='" & txtNotes.Text & "' where GuestID='" & txtGuestID.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullyUpdated, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate_record.Enabled = False
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
        frmMainMenu.Show()


    End Sub

    Private Sub dataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
           
            Me.txtGuestID.Text = dr.Cells(0).Value.ToString()
            Me.txtGuestName.Text = dr.Cells(1).Value.ToString()
            Me.txtGuestAddress.Text = dr.Cells(2).Value.ToString()
            Me.txtGuestCity.Text = dr.Cells(3).Value.ToString()
            Me.txtGuestContactNo.Text = dr.Cells(4).Value.ToString()
            Me.cmbIDType.Text = dr.Cells(5).Value.ToString()
            Me.txtIDNumber.Text = dr.Cells(6).Value.ToString()
            Me.txtNotes.Text = dr.Cells(7).Value.ToString()
            Me.btnUpdate_record.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnSave.Enabled = False
            Me.txtGuestName.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub guestsearch_TextChanged(sender As Object, e As EventArgs) Handles guestsearch.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT (GuestID)as [Guest ID],(Guestname) as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],Notes from Guest where GuestName like '" + guestsearch.Text + "%' order by GuestName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class