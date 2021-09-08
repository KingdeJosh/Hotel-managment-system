Imports System.Data.SqlClient

Public Class frmRoomReservationReport
 

    Sub Reset()
        DateTimePicker1.Text = Today
        DateTimePicker2.Text = Now
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Reservation.ReservationNo, Reservation.ReservationDate,Reservation.DateIN, Reservation.DateOut, Reservation.Status,Guest.GuestName,Room.RoomNo FROM Reservation INNER JOIN Guest ON Reservation.Guest_ID = Guest.ID INNER JOIN Room ON Reservation.RoomID = Room.R_ID where ReservationDate between @d1 and @d2  order by ReservationDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker1.Value
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("Reservation.xml")
            'Dim rpt As New rptRoomReservation
           
          
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
