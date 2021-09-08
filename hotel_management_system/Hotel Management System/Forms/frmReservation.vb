Imports System.Data.SqlClient
Public Class frmReservation
    Sub Reset()
        txtGuestID.Text = ""
        txtGuestName.Text = ""
        txtReservationNo.Text = ""
        cmbRoomNo.SelectedIndex = -1
        cmbRoomNo1.SelectedIndex = -1
        txtNotes.Text = ""
        dtpDateIN.Text = Today
        dtpDateOut.Text = Today
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnRoomAvailability.Enabled = True
        btnSave.Enabled = True
        btnCancelReservation.Enabled = False
        auto()
    End Sub
    Public Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Reservation")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtReservationID.Text = Num.ToString
            txtReservationNo.Text = "R" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtReservationID.Text = Num.ToString
            txtReservationNo.Text = "R" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If dtpDateIN.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RoomNo FROM Temp_Reservation WHERE RoomNo=@d1 AND Status='Reserved' and Temp_Reservation.DateIn < @d2 AND Temp_Reservation.DateOut > @d3"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateIN.Value.Date)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "SELECT RoomNo FROM CheckIn_Room WHERE RoomNo=@d1 AND Status='Check In' and Checkin_Room.DateIn < @d2 AND Checkin_Room.DateOut > @d3"
            cmd = New SqlCommand(ct1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateIN.Value.Date)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room is already booked", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Reservation(ID,ReservationNo, GuestID, RoomNo, DateIN, DateOUT, Status, Notes,ReservationDate) VALUES (" & txtReservationID.Text & ",'" & txtReservationNo.Text & "'," & txtID.Text & ",@d1,@d4,@d5,'Reserved',@d2,@d3)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d3", Now)
            cmd.Parameters.AddWithValue("@d5", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d4", dtpDateIN.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Temp_Reservation(ID,ReservationNo, GuestID, RoomNo, DateIN, DateOUT, Status, Notes,ReservationDate) VALUES (" & txtReservationID.Text & ",'" & txtReservationNo.Text & "'," & txtID.Text & ",@d1,@d4,@d5,'Reserved',@d2,@d3)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d3", Now)
            cmd.Parameters.AddWithValue("@d5", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d4", dtpDateIN.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            con.Close()
            Dim st As String = "added the new reservation with reservation no. '" & txtReservationNo.Text & "' for guest '" & txtGuestName.Text & "'"
            LogFunc(lblUser.Text, st)
            btnSave.Enabled = False
            frmMainMenu.GetData()
            MessageBox.Show("Successfully Reserved", "Room", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Reservation where ID=" & txtReservationID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq1 As String = "delete from Temp_Reservation where ID=" & txtReservationID.Text & ""
            Dim cmd1 As SqlCommand = New SqlCommand(cq1)
            cmd1.Connection = con
            cmd1.ExecuteNonQuery()
            con.Close()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the reservation record with reservation no. '" & txtReservationNo.Text & "' of guest '" & txtGuestName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                frmMainMenu.GetData()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try

            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If (cmbRoomNo.Text <> cmbRoomNo1.Text) Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "SELECT RoomNo FROM Temp_Reservation WHERE RoomNo=@d1 AND Status='Reserved' and Temp_Reservation.DateIn < @d2 AND Temp_Reservation.DateOut >= @d3"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
                cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
                cmd.Parameters.AddWithValue("@d3", dtpDateIN.Value.Date)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Selected Room is already reserved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
                con = New SqlConnection(cs)
                con.Open()
                Dim ct1 As String = "SELECT RoomNo FROM CheckIn_Room WHERE RoomNo=@d1 AND Status='Check In' and Checkin_Room.DateIn < @d2 AND Checkin_Room.DateOut >= @d3"
                cmd = New SqlCommand(ct1)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
                cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
                cmd.Parameters.AddWithValue("@d3", dtpDateIN.Value.Date)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Selected Room is already booked", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Reservation set ReservationNo='" & txtReservationNo.Text & "', GuestID=" & txtGuestID.Text & ",RoomNo=@d1,DateIN=@d3,DateOUT=@d4,Notes=@d2 where ID=" & txtReservationNo.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d4", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateIN.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "update Temp_Reservation set ReservationNo='" & txtReservationNo.Text & "', GuestID=" & txtGuestID.Text & ",RoomNo=@d1,DateIN=@d3,DateOUT=@d4,Notes=@d2 where ID=" & txtReservationNo.Text & ""
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d4", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateIN.Value.Date)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the reservation record with reservation no. '" & txtReservationNo.Text & "' of guest '" & txtGuestName.Text & "'"
            LogFunc(lblUser.Text, st)
            btnUpdate.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmMainMenu.GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelReservation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelReservation.Click
        Try

            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestID.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If (txtStatus.Text = "Cancelled") Then
                MessageBox.Show("Reservation is already cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If (txtStatus.Text = "Confirmed") Then
                MessageBox.Show("Reservation is confirmed and Guest is already Check In " & vbCritical & " so it can not be cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If MessageBox.Show("Are you sure want to cancel this reservation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "update Reservation set Status='Cancelled' where ID=" & txtReservationID.Text & ""
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()

                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "update Temp_Reservation set Status='Cancelled' where ID=" & txtReservationID.Text & ""
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "cancelled the reservation having reservation no.'" & txtReservationNo.Text & "' of guest '" & txtGuestName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully cancelled", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelReservation.Enabled = False
                frmMainMenu.GetData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpDateOut_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateOut.Validating
        If (dtpDateOut.Value.Date < Today) Then
            MessageBox.Show("Reservation is not possible" & vbCrLf & "Selected OUT date is less than today's date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateOut.Focus()
            Exit Sub
        End If
        If dtpDateIN.Value.Date = dtpDateOut.Value.Date Then
            MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If dtpDateOut.Value.Date < dtpDateIN.Value.Date Then
            MessageBox.Show("Selected date out must be greater than date in", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateOut.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub dtpDateIN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateIN.Validating
        If (dtpDateIN.Value.Date < Today) Then
            MessageBox.Show("Reservation is not possible" & vbCrLf & "Selected IN date is less than today's date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateIN.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        frmReservationRecord.Reset()
        frmReservationRecord.ShowDialog()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
        frmMainMenu.Reset()
        frmMainMenu.Show()
    End Sub
    Sub fillRoomNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RoomNo) FROM Room", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbRoomNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbRoomNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmReservation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillRoomNo()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmGuestRecord1.lblSet.Text = "Reservation"
        frmGuestRecord1.Reset()
        frmGuestRecord1.ShowDialog()
    End Sub

    Private Sub btnRoomAvailability_Click(sender As System.Object, e As System.EventArgs) Handles btnRoomAvailability.Click
        Try

            If Len(Trim(cmbRoomNo.Text)) = 0 Then
                MessageBox.Show("Please select room no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRoomNo.Focus()
                Exit Sub
            End If
            If dtpDateIN.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RoomNo FROM Temp_Reservation WHERE RoomNo=@d1 AND Status='Reserved' and Temp_Reservation.DateIn < @d2 AND Temp_Reservation.DateOut > @d3 union SELECT RoomNo FROM CheckIn_Room WHERE RoomNo=@d1 AND Status='Check In' and Checkin_Room.DateIn < @d2 AND Checkin_Room.DateOut > @d3"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            cmd.Parameters.AddWithValue("@d2", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d3", dtpDateIN.Value.Date)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Selected Room is already reserved/booked", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Selected Room is available", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

End Class
