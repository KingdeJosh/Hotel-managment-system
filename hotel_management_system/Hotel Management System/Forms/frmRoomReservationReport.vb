Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
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
            Dim rpt As New rptRoomReservation 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Reservation.Id, Reservation.ReservationNo, Reservation.ReservationDate, Reservation.GuestID, Reservation.RoomNo, Reservation.DateIN, Reservation.DateOut, Reservation.Status, Reservation.Notes,Guest.ID AS Expr1, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1,Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3, Room.RoomNo AS Expr4, Room.RoomType, Room.RoomCharges FROM Reservation INNER JOIN Guest ON Reservation.GuestID = Guest.ID INNER JOIN Room ON Reservation.RoomNo = Room.RoomNo where ReservationDate between @d1 and @d2  order by ReservationDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker2.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker1.Value
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Reservation")
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("v1", DateTimePicker2.Value.Date)
            rpt.SetParameterValue("v2", DateTimePicker1.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
