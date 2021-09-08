Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmReservationRecord
    Sub fillRoomNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RoomNo) FROM Reservation", CN)
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
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(Date,DateIN,103),CONVERT(Date,DateOut,103),RTRIM(Reservation.Notes) from Reservation,Guest,Room where Reservation.GuestID=Guest.ID and Reservation.RoomNo=Room.RoomNo order by DateIN"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillRoomNo()
    End Sub
    Sub Reset()
        cmbRoomNo.Text = ""
        cmbStatus.SelectedIndex = -1
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        txtGuestName.Text = ""
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = dgw.RowCount
            colsTotal = dgw.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = dgw.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = dgw.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmReservation.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmReservation.txtReservationID.Text = dr.Cells(0).Value.ToString()
                frmReservation.txtReservationNo.Text = dr.Cells(1).Value.ToString()
                frmReservation.txtID.Text = dr.Cells(3).Value.ToString()
                frmReservation.txtGuestID.Text = dr.Cells(4).Value.ToString()
                frmReservation.txtGuestName.Text = dr.Cells(5).Value.ToString()
                frmReservation.cmbRoomNo.Text = dr.Cells(6).Value.ToString()
                frmReservation.cmbRoomNo1.Text = dr.Cells(6).Value.ToString()
                frmReservation.dtpDateIN.Text = dr.Cells(7).Value.ToString()
                frmReservation.dtpDateOut.Text = dr.Cells(8).Value.ToString()
                frmReservation.txtNotes.Text = dr.Cells(9).Value.ToString()
                frmReservation.btnSave.Enabled = False
                frmReservation.btnDelete.Enabled = True
                frmReservation.btnUpdate.Enabled = True
                frmReservation.btnCancelReservation.Enabled = True
                frmReservation.btnRoomAvailability.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(Date,DateIN,103),CONVERT(Date,DateOut,103),RTRIM(Reservation.Notes) from Reservation,Guest,Room where Reservation.GuestID=Guest.ID and Reservation.RoomNo=Room.RoomNo and GuestName like '" & txtGuestName.Text & "%' order by DateIN"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRoomNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(Date,DateIN,103),CONVERT(Date,DateOut,103),RTRIM(Reservation.Notes) from Reservation,Guest,Room where Reservation.GuestID=Guest.ID and Reservation.RoomNo=Room.RoomNo and Room.RoomNo=@d1 order by DateIN"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", cmbRoomNo.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(Date,DateIN,103),CONVERT(Date,DateOut,103),RTRIM(Reservation.Notes) from Reservation,Guest,Room where Reservation.GuestID=Guest.ID and Reservation.RoomNo=Room.RoomNo and Status='" & cmbStatus.Text & "' order by DateIN"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(Date,DateIN,103),CONVERT(Date,DateOut,103),RTRIM(Reservation.Notes) from Reservation,Guest,Room where Reservation.GuestID=Guest.ID and Reservation.RoomNo=Room.RoomNo and DateIN between @d1 and @d2 order by DateIN"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
