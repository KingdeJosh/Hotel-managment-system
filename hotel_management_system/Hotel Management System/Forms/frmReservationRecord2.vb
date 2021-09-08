Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmReservationRecord2
    Sub fillRoomNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RoomNo) FROM Temp_Reservation", CN)
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
            Dim sql As String = "Select RTRIM(Temp_Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(Date,DateIN,103),CONVERT(Date,DateOut,103),RTRIM(Temp_Reservation.Notes) from Temp_Reservation,Guest,Room where Temp_Reservation.GuestID=Guest.ID and Temp_Reservation.RoomNo=Room.RoomNo order by DateIN"
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
                frmCheckIN_Room.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmCheckIN_Room.txtReservationID.Text = dr.Cells(0).Value.ToString()
                frmCheckIN_Room.txtID.Text = dr.Cells(3).Value.ToString()
                frmCheckIN_Room.cmbRoomNo.Text = dr.Cells(6).Value.ToString()
                frmCheckIN_Room.dtpDateIn.Text = dr.Cells(7).Value.ToString()
                frmCheckIN_Room.dtpDateOut.Text = dr.Cells(8).Value.ToString()
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT GuestID, GuestName, Address, City, ContactNo, Gender, Occupation, Religion, IDType, IDNumber from Guest WHERE Id=" & dr.Cells(3).Value & ""
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    frmCheckIN_Room.txtGuestID.Text = rdr.GetValue(0)
                    frmCheckIN_Room.txtGuestName.Text = rdr.GetValue(1)
                    frmCheckIN_Room.txtGuestAddress.Text = rdr.GetValue(2)
                    frmCheckIN_Room.txtGuestCity.Text = rdr.GetValue(3)
                    frmCheckIN_Room.txtGuestContactNo.Text = rdr.GetValue(4)
                    frmCheckIN_Room.txtGender.Text = rdr.GetValue(5)
                    frmCheckIN_Room.txtOccupation.Text = rdr.GetValue(6)
                    frmCheckIN_Room.txtReligion.Text = rdr.GetString(7)
                    frmCheckIN_Room.txtIDType.Text = rdr.GetValue(8)
                    frmCheckIN_Room.txtIDNumber.Text = rdr.GetValue(9)
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                frmCheckIN_Room.btnCheckedIN.Enabled = True
                frmCheckIN_Room.btnSave.Enabled = False
                frmCheckIN_Room.dtpDateIn.Enabled = False
                frmCheckIN_Room.dtpDateOut.Enabled = False
                frmCheckIN_Room.cmbRoomNo.Enabled = False
                frmCheckIN_Room.btnRoomAvailability.Enabled = False
                frmCheckIN_Room.Fill()
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
            Dim sql As String = "Select RTRIM(Temp_Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(Date,DateIN,103),CONVERT(Date,DateOut,103),RTRIM(Temp_Reservation.Notes) from Temp_Reservation,Guest,Room where Temp_Reservation.GuestID=Guest.ID and Temp_Reservation.RoomNo=Room.RoomNo and GuestName like '" & txtGuestName.Text & "%' order by DateIN"
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
            Dim sql As String = "Select RTRIM(Temp_Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(Date,DateIN,103),CONVERT(Date,DateOut,103),RTRIM(Temp_Reservation.Notes) from Temp_Reservation,Guest,Room where Temp_Reservation.GuestID=Guest.ID and Temp_Reservation.RoomNo=Room.RoomNo and Room.RoomNo=@d1 order by DateIN"
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(Temp_Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(Date,DateIN,103),CONVERT(Date,DateOut,103),RTRIM(Temp_Reservation.Notes) from Temp_Reservation,Guest,Room where Temp_Reservation.GuestID=Guest.ID and Temp_Reservation.RoomNo=Room.RoomNo and DateIN between @d1 and @d2 order by DateIN"
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
