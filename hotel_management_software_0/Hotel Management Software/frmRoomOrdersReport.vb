Imports System.Data.SqlClient

Public Class frmRoomOrdersReport


    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub
    Sub Reset()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
    End Sub
  

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

   
    Private Sub btnViewReport_Click(sender As System.Object, e As System.EventArgs) Handles btnViewReport.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            '  Dim rpt As New rptRoomOrders1 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Room_OrderInfo.ID,Checkin_Room.Cin_ID as Expr1,Guest.ID as Expr2,Guest_Docs.ID as Expr3, Room_OrderInfo.BillNo, Room_OrderInfo.BillDate, Room_OrderInfo.CheckInId,Operator, Room_OrderInfo.GrandTotal, Room_OrderInfo.TotalPayment, Room_OrderInfo.PaymentDue,Room_OrderedProduct.OP_Id, Room_OrderedProduct.BillID, Room_OrderedProduct.Dish_Liquor, Room_OrderedProduct.Volumn, Room_OrderedProduct.TakenFrom, Room_OrderedProduct.VATPer,Room_OrderedProduct.VATAmount, Room_OrderedProduct.STPer, Room_OrderedProduct.STAmount, Room_OrderedProduct.DiscountPer, Room_OrderedProduct.DiscountAmount, Room_OrderedProduct.Rate, Room_OrderedProduct.Quantity, Room_OrderedProduct.Amount, Room_OrderedProduct.TotalAmount, CheckIN_Room.RoomID,CheckIN_Room.DateIN, CheckIN_Room.DateOUT, Guest.GuestName,Room.RoomNo FROM Room_OrderInfo INNER JOIN Room_OrderedProduct ON Room_OrderInfo.Id = Room_OrderedProduct.BillID INNER JOIN CheckIN_Room ON Room_OrderInfo.CheckInId = Checkin_Room.Cin_ID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Guest_Docs ON Guest.ID = Guest_Docs.GuestID INNER JOIN Room ON CheckIN_Room.RoomID = Room.R_ID where BillDate between @d1 and @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Guest_Docs")
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "Room_OrderInfo")
            myDA.Fill(myDS, "CheckIn_Room")
            myDA.Fill(myDS, "Room_OrderedProduct")
            myDA1.Fill(myDS, "Hotel")
           ' frmReport.CrystalReportViewer1.ReportSource = rpt
            ' frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
