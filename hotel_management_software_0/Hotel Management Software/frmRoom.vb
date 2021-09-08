Imports System.Data.SqlClient
Public Class frmRoom
    Sub fillRoomType()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Type) FROM RoomType", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbRoomType.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbRoomType.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillPlanCode()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(P_Code) FROM [Plan]", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbPlanCode.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbPlanCode.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(R_ID) FROM Room")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Sub Reset()
        cmbRoomType.SelectedIndex = -1
        cmbPlanCode.SelectedIndex = -1
        txtPlanName.Text = ""
        txtRoomCharges.Text = ""
        txtSearchByRoom.Text = ""
        txtRoomNo.Text = ""
        txtMaxAdults.Text = ""
        txtMaxKids.Text = ""
        txtRoomNo.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnActivate_Deactivate.Enabled = False
        btnActivate_Deactivate.Text = "Activate/Deactivate"
        auto()
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtRoomNo.Text)) = 0 Then
            MessageBox.Show("Please enter room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomNo.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbRoomType.Text)) = 0 Then
            MessageBox.Show("Please select room type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRoomType.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbPlanCode.Text)) = 0 Then
            MessageBox.Show("Please select plan code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPlanCode.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRoomCharges.Text)) = 0 Then
            MessageBox.Show("Please enter room charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRoomCharges.Text)) = 0 Then
            MessageBox.Show("Please enter room charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtMaxAdults.Text)) = 0 Then
            MessageBox.Show("Please enter Max. No. of Adults allowed", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaxAdults.Focus()
            Exit Sub
        End If
        If Len(Trim(txtMaxKids.Text)) = 0 Then
            MessageBox.Show("Please enter Max. No. of Kids allowed", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaxKids.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select RoomNo,PlanCode from Room where RoomNo=@d1 and PlanCode=@d2"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", cmbPlanCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRoomNo.Text = ""
                txtRoomNo.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Room(RoomNo,RoomType,RoomCharges,MaxNoOfAdults,MaxNoOfKids,R_ID,PlanCode,Active,R_Status) VALUES (@d1,@d2," & txtRoomCharges.Text & "," & txtMaxAdults.Text & "," & txtMaxKids.Text & "," & txtID.Text & ",@d3,'Yes','Vacant Clean')"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", cmbRoomType.Text)
            cmd.Parameters.AddWithValue("@d3", cmbPlanCode.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new Room '" & txtRoomNo.Text & "' has plan '" & txtPlanName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
            RefreshRecords()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
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
    Private Sub DeleteRecord()

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select Room.R_ID from Room,CheckIN_Room where Room.R_ID=CheckIN_Room.RoomID and Room.R_ID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Check In and Out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl1 As String = "select R_ID from Room,Reservation where Room.R_ID=Reservation.RoomID and R_ID=@d1"
            cmd = New SqlCommand(cl1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Reservation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Room where RoomNo=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Room '" & txtRoomNo.Text & "' has plan '" & txtPlanName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                RefreshRecords()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Len(Trim(txtRoomNo.Text)) = 0 Then
                MessageBox.Show("Please enter room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRoomNo.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbRoomType.Text)) = 0 Then
                MessageBox.Show("Please select room type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomType.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbPlanCode.Text)) = 0 Then
                MessageBox.Show("Please select plan code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPlanCode.Focus()
                Exit Sub
            End If
            If Len(Trim(txtRoomCharges.Text)) = 0 Then
                MessageBox.Show("Please enter room charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRoomCharges.Focus()
                Exit Sub
            End If
            If Len(Trim(txtMaxAdults.Text)) = 0 Then
                MessageBox.Show("Please enter Max. No. of Adults allowed", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMaxAdults.Focus()
                Exit Sub
            End If
            If Len(Trim(txtMaxKids.Text)) = 0 Then
                MessageBox.Show("Please enter Max. No. of Kids allowed", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMaxKids.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Room set RoomNo=@d1,RoomType=@d2,RoomCharges=" & txtRoomCharges.Text & ",MaxNoOfAdults=" & txtMaxAdults.Text & ",MaxNoOfkids=" & txtMaxKids.Text & ",PlanCode=@d4 where R_ID=@d3"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", cmbRoomType.Text)
            cmd.Parameters.AddWithValue("@d3", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d4", cmbPlanCode.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the Room '" & txtRoomNo.Text & "' has plan '" & txtPlanName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Room Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
            RefreshRecords()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT R_ID, RTRIM(RoomNo), RTRIM(RoomType),RTRIM(PlanCode),RTRIM(PlanName), RTRIM(RoomCharges),MaxNoOfAdults,MaxNoOfKids,RTRIM(Active) from Room,[Plan] where Room.PlanCode=[Plan].P_Code order by RoomNo", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub


    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub frmRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        fillRoomType()
        fillPlanCode()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtRoomNo.Text = dr.Cells(1).Value.ToString()
                txtID.Text = dr.Cells(0).Value.ToString()
                cmbRoomType.Text = dr.Cells(2).Value.ToString()
                cmbPlanCode.Text = dr.Cells(3).Value.ToString()
                txtPlanName.Text = dr.Cells(4).Value.ToString()
                txtRoomCharges.Text = dr.Cells(5).Value.ToString()
                txtMaxAdults.Text = dr.Cells(6).Value.ToString()
                txtMaxKids.Text = dr.Cells(7).Value.ToString()
                If dr.Cells(8).Value = "Yes" Then
                    btnActivate_Deactivate.Text = "Deactivate"
                    btnActivate_Deactivate.Enabled = True
                End If
                If dr.Cells(8).Value = "No" Then
                    btnActivate_Deactivate.Text = "Activate"
                    btnActivate_Deactivate.Enabled = True
                End If
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtServiceTax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRoomCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtRoomCharges.Text
            Dim selectionStart = Me.txtRoomCharges.SelectionStart
            Dim selectionLength = Me.txtRoomCharges.SelectionLength

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

    Private Sub txtFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchByRoom.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT R_ID, RTRIM(RoomNo), RTRIM(RoomType),RTRIM(PlanCode),RTRIM(PlanName), RTRIM(RoomCharges),MaxNoOfAdults,MaxNoOfKids,RTRIM(Active) from Room,[Plan] where Room.PlanCode=[Plan].P_Code and RoomNo like '%" & txtSearchByRoom.Text & "%' order by RoomNo", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMaxAdults_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaxAdults.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMaxKids_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaxKids.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbPlanCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPlanCode.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT PlanName FROM [Plan] WHERE P_Code=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbPlanCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtPlanName.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnActivate_Deactivate_Click(sender As System.Object, e As System.EventArgs) Handles btnActivate_Deactivate.Click
        If Len(Trim(txtRoomNo.Text)) = 0 Then
            MessageBox.Show("Please enter room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoomNo.Focus()
            Exit Sub
        End If

        Try
            If btnActivate_Deactivate.Text = "Activate" Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "Update Room set RoomNo=@d1,Active='Yes' where R_ID=@d2"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
                cmd.Parameters.AddWithValue("@d2", Val(txtID.Text))
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "activated the room no. '" & txtRoomNo.Text & "' has plan '" & txtPlanName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully activated", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnActivate_Deactivate.Enabled = False
                Getdata()
                Reset()
            End If
            If btnActivate_Deactivate.Text = "Deactivate" Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "Update Room set RoomNo=@d1,Active='No' where R_ID=@d2"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtRoomNo.Text)
                cmd.Parameters.AddWithValue("@d2", Val(txtID.Text))
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "deactivated the room no. '" & txtRoomNo.Text & "' has plan '" & txtPlanName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deactivated", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnActivate_Deactivate.Enabled = False
                Getdata()
                Reset()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class
