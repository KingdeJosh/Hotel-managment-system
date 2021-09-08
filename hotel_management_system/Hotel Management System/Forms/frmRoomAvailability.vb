Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmRoomAvailability

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        Me.dtpDateIn.Text = Today
        Me.dtpDateOut.Text = Today
        dgw.Rows.Clear()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            dgw.Enabled = True
            If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpDateOut.Focus()
                dtpDateOut.Text = Today
                Exit Sub
            End If
            If dtpDateOut.Value.Date < dtpDateIn.Value.Date Then
                MessageBox.Show("Selected date out must be greater than date in", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpDateOut.Focus()
                dtpDateOut.Text = Today
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT RTRIM(R.RoomNo),RTRIM(R.RoomType),RTRIM(R.RoomCharges) FROM Room as R Inner Join Room as S on R.RoomNo=S.RoomNo where R.RoomNo not in (Select RoomNo from Temp_Reservation where Status ='Reserved' and Temp_Reservation.DateIn < @d1 AND Temp_Reservation.DateOut > @d2 ) and S.RoomNo not in (SELECT RoomNo FROM Checkin_Room where Status = 'Check In' and Checkin_Room.DateIn < @d1 AND Checkin_Room.DateOut > @d2) "
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
End Class
