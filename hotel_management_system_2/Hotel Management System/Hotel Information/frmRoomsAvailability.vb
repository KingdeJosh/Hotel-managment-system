Imports System.Data.OleDb
Public Class frmRoomsAvailability
    Private Const STR_SELECTFROMRoomAsRInnerJoinRoomAsSOnRRoomNoSRoomN As String = "SELECT * FROM Room as R Inner Join Room as S on R.RoomNo=S.RoomNo where R.RoomNo not in (Select RoomNo from Temp_Reservation where Status ='Reserved' and Temp_Reservation.DateIn < #"





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim sql As String = STR_SELECTFROMRoomAsRInnerJoinRoomAsSOnRRoomNoSRoomN & dtpDateOut.Value.Date & "# AND Temp_Reservation.DateOut > #" & dtpDateIn.Value.Date & "# ) and S.RoomNo not in (SELECT RoomNo FROM Checkin_Room where Status = 'Checked In' and Checkin_Room.DateIn < #" & dtpDateOut.Value & "# AND Checkin_Room.DateOut > #" & dtpDateIn.Value & "#) "
            cmd = New OleDbCommand(sql, con)
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
        frmMainMenu.Show()
    End Sub

Private Sub frmRoomsAvailability_Load( sender As Object,  e As EventArgs) Handles MyBase.Load

End Sub
End Class